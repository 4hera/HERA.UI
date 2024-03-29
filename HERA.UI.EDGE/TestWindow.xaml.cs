﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace HERA.UI.EDGE
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        public event EventHandler<EdgeState> OnEvent = delegate { };
        public TestWindow()
        {
            InitializeComponent();
            List<string> links = new List<string>
            {
                "https://www.milliyet.com.tr",
                "https://www.microsoft.com",
                "https://www.youtube.com",
                "https://expired.badssl.com/",
                "http://demo.4hera.com:92/login"
            };
            Loaded += (s, e) =>
            {
                LinkComboBox.ItemsSource = links;
                ZoomSlider.Value = 1;
                LinkComboBox.SelectedIndex = 0;
                SetUrl();
            };


            LinkComboBox.SelectionChanged += LinkComboBoxSelectionChanged;
            ZoomSlider.ValueChanged += ZoomSliderValueChanged;
            HideScrollCheckBox.Click += HideScrollCheckBoxClicked;
            CropEnableCheckBox.Click += CropEnableCheckBoxClicked;
        }


        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(LinkText.Text);
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "OpenLink",
                    Source = uri
                }); ;
            }
        }
        private const string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
        private static Regex regexExtractId = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
        private static string[] validAuthorities = { "youtube.com", "www.youtube.com", "youtu.be", "www.youtu.be" };

        public string ExtractVideoIdFromUri(Uri uri)
        {
            try
            {
                string authority = new UriBuilder(uri).Uri.Authority.ToLower();

                //check if the url is a youtube url
                if (validAuthorities.Contains(authority))
                {
                    //and extract the id
                    var regRes = regexExtractId.Match(uri.ToString());
                    if (regRes.Success)
                    {
                        return regRes.Groups[1].Value;
                    }
                }
            }
            catch { }


            return null;
        }
        public void MakeYoutubeLink(ref string link)
        {
            //g3bCNztipPQ
            StringBuilder youtube = new StringBuilder();
            youtube.Append("https://www.youtube.com/embed/");
            youtube.Append(link);
            youtube.Append("?autoplay=1&mute=1&version=3&loop=1&playlist=");
            youtube.Append(link);
            link = youtube.ToString();
        }
        private void GoYoutubeButtonClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(LinkText.Text);
            string youtubeId= ExtractVideoIdFromUri(uri);
            MakeYoutubeLink(ref youtubeId);
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "OpenLink",
                    Source = new Uri(youtubeId)
                }); ;
            }
        }
        
        private void LinkComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetUrl();

        }
        public void SetUrl()
        {
            string selectedLink = LinkComboBox.SelectedItem as string;
            Uri uri = new Uri(selectedLink);
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "OpenLink",
                    Source = uri
                });
            }
        }

        private void ZoomSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Zoom",
                    Zoom = ZoomSlider.Value
                });
            }
        }

        private void LastVisitedClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "LastVisited",
                });
            }
        }

        private void HideScrollCheckBoxClicked(object sender, RoutedEventArgs e)
        {

            bool hideScroll = HideScrollCheckBox.IsChecked ?? false;

            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "HideScroll",
                    HideScroll = hideScroll
                });
            }
        }

        private void SetLocationClick(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(LocationXTextBox.Text);
            int y = int.Parse(LocationYTextBox.Text);

            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetLocation",
                    LocationX = x,
                    LocationY = y
                });
            }
        }

        private void LastLocationClick(object sender, RoutedEventArgs e)
        {
            OnEvent(this, new()
            {
                State = "GetLocation",
            });
        }

        private void CropEnableCheckBoxClicked(object sender, RoutedEventArgs e)
        {

            bool isEnable = CropEnableCheckBox.IsChecked ?? false;

            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "CropEnable",
                    isEnable = isEnable
                });
            }
        }

        private void CropClick(object sender, RoutedEventArgs e)
        {
            Crop();
        }


        public void Crop()
        {
            int x = int.Parse(LocationXTextBox.Text);
            int y = int.Parse(LocationYTextBox.Text);
            double z = ZoomSlider.Value;
            double sx = sxSlider.Value;
            double sy = sySlider.Value;
            int sl = int.Parse(slTextBox.Text);
            int st = int.Parse(stTextBox.Text);

            CropParameter crop = new CropParameter(x, y, z, sx, sy, sl, st);

            OnEvent(this, new()
            {
                State = "Crop",
                Crop = crop
            });
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void sxSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (sxSlider is not null && sxLabel is not null)
                {
                    sxLabel.Content = sxSlider.Value;
                    Crop();
                }

            });
          
        }

        private void sySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (sySlider is not null && syLabel is not null)
                {
                    syLabel.Content = sySlider.Value;
                    Crop();
                }
            });
            
        }

       
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Back"
                });
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Forward"
                });
            }
        }

        private void NewWindowEnableButton_Checked(object sender, RoutedEventArgs e)
        {
            bool isEnable = NewWindowEnableButton.IsChecked ?? false;

            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "NewWindow",
                    isEnable = isEnable
                });
            }
        }
    }
}
