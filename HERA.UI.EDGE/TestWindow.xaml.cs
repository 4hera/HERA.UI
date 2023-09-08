using System;
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
                "https://expired.badssl.com/"
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


        private void LinkComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetUrl();

        }
        public void SetUrl()
        {
            string selectedLink = LinkComboBox.SelectedItem as string;
            Console.WriteLine(selectedLink);
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
    }
}
