using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HERA.UI.CHROME
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public event EventHandler<ChromeState> OnEvent = delegate { };
        public TestWindow()
        {
            InitializeComponent();
            List<string> links = new List<string>
            {
                "http://www.dummysoftware.com/popupdummy_testpage.html",
                "https://www.milliyet.com.tr",
                "https://www.microsoft.com",
                "https://www.youtube.com",
                "https://expired.badssl.com/",
                "http://demo.4hera.com:92/login"
            };

            Loaded += (s, e) =>
            {
                LinkComboBox.ItemsSource = links;
            };

            HideScrollCheckBox.Click += HideScrollCheckBoxClicked;
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetAddress",
                    Adress = AdressText.Text
                }); ;
            }
        }



        private void LinkComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetAddress",
                    Adress = LinkComboBox.SelectedItem.ToString()
                }); ;
            }
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine(ZoomSlider.Value);
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetZoom",
                    Zoom = ZoomSlider.Value
                }); ;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void HideScrollCheckBoxClicked(object sender, RoutedEventArgs e)
        {

            bool hideScroll = HideScrollCheckBox.IsChecked ?? false;

            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetHideScroll",
                    HideScroll = hideScroll
                });
            }
        }

        private void CropEnableCheckBoxClicked(object sender, RoutedEventArgs e)
        {

            bool isEnable = CropEnableCheckBox.IsChecked ?? false;
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetCropEnable",
                    CropEnable = isEnable
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
                State = "SetCrop",
                Crop = crop
            });
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GoForward",
                });
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GoBack",
                });
            }
        }

        private void LastVisitedClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GetLastVisited",
                });
            }
        }

        private void LastLocationClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GetLastLocation",
                });
            }
        }

        private void NewWindowEnableCheckBoxClicked(object sender, RoutedEventArgs e)
        {
            bool isEnable = NewWindowEnableCheckBox.IsChecked ?? false;
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetNewWindowEnable",
                    NewWindowEnable = isEnable
                });
            }
        }
    }
}
