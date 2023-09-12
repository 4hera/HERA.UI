using LibVLCSharp.Shared;
using LibVLCSharp.Shared.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace HERA.UI.VLC
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        public event EventHandler<VLCState> OnEvent = delegate { };
        public string MainFolderPath = "C:\\Users\\AliEmirErcan\\Desktop\\VideoTest";
        public string MainImagesFolderPath = "C:\\Users\\AliEmirErcan\\Desktop\\ImageTest";
        
        public TestWindow()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                ListFilesInFolder(MainFolderPath);
                ListImagesInFolder(MainImagesFolderPath);
            };
            ColorComboBox.ItemsSource = Enum.GetValues(typeof(Color.ColorHex));
            TextPositionComboBox.ItemsSource = Enum.GetValues(typeof(Position.TextPosition));
            LogoPositionComboBox.ItemsSource = Enum.GetValues(typeof (Position.LogoPosition));
            ColorComboBox.SelectionChanged += ColorComboBoxSelectionChanged;
            fileComboBox.SelectionChanged += fileComboBoxSelectionChanged;
            LogoFilePathComboBox.SelectionChanged += LogoFilePathComboBoxSelectionChanged;

        }

        public void GetAudioOutputs(ref IEnumerable<AudioOutputDescription> audioOutputDescription)
        {
            LibVLC libvlc = new LibVLC();
            audioOutputDescription = libvlc.AudioOutputs;
            libvlc.Dispose();
        }

        public void GetAudioDevices(ref IEnumerable<AudioOutputDevice> audioOutputDevices, string name)
        {
            LibVLC libvlc = new LibVLC();
            audioOutputDevices = libvlc.AudioOutputDevices(name);
            libvlc.Dispose();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Play"
                });
            }
        }

        private void PauseClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Pause"
                });
            }
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Stop"
                });
            }
        }

        private void MuteClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Mute"
                });
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Voice",
           
                    Volume = (int)e.NewValue
                });
            }
        }

        private void ColorComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem != null)
            {
                if (OnEvent is not null)
                {
                    OnEvent(this, new()
                    {
                        State = "Color",
                        Color = (Color.ColorHex)ColorComboBox.SelectedItem
                    }); ;
                }
            }
            
        }


        private void fileComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFileName = fileComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedFileName))
            {
          
                string selectedFilePath = Path.Combine(MainFolderPath, selectedFileName);

                if (OnEvent is not null)
                {
                    OnEvent(this, new()
                    {
                        State = "Path",

                        Path = selectedFilePath
                    });
                }
            }
        }

        private void LogoFilePathComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFileName = LogoFilePathComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedFileName))
            {

                string selectedFilePath = Path.Combine(MainImagesFolderPath, selectedFileName);

                if (OnEvent is not null)
                {
                    OnEvent(this, new()
                    {
                        State = "SetLogo",

                        Path = selectedFilePath
                    });
                }
            }
        }
        private void ListFilesInFolder(string folderPath)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath);

                // ComboBox'ı temizle
                fileComboBox.Items.Clear();

                // Dosyaları ComboBox'a ekle
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    fileComboBox.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListImagesInFolder(string folderPath)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath);

                // ComboBox'ı temizle
                LogoFilePathComboBox.Items.Clear();

                // Dosyaları ComboBox'a ekle
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    LogoFilePathComboBox.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContrastSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Contrast",
                    Value = (float)ContrastSlider.Value
                }); 
            }
            if(ContrastLabel is not null)
            {
                ContrastLabel.Content = ContrastSlider.Value.ToString("F1");
            }
            
        }

        private void BrightnessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Brightness",
                    Value = (float)BrightnessSlider.Value
                });
            }
            if (BrightnessLabel is not null)
            {
                BrightnessLabel.Content = BrightnessSlider.Value.ToString("F1");
            }
            
        }

        private void HueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Hue",
                    Value = (float)HueSlider.Value
                });
            }
            if (HueLabel is not null)
            {
                HueLabel.Content = HueSlider.Value.ToString("F1");
            }
        }

        private void SaturationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Saturation",
                    Value = (float)SaturationSlider.Value
                });
            }
            if (SaturationLabel is not null)
            {
                SaturationLabel.Content = SaturationSlider.Value.ToString("F1");
            }
        }

        private void GammaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Gamma",
                    Value = (float)GammaSlider.Value
                });
            }
            if (GammaLabel is not null)
            {
                GammaLabel.Content = GammaSlider.Value.ToString("F1");
            }

        }

        private void TextOpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "TextOpacity",
                    Value = (int)TextOpacitySlider.Value
                });
            }
            if (TextOpacityLabel is not null)
            {
                TextOpacityLabel.Content = TextOpacitySlider.Value.ToString("F1");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "TextChanged",
                    Text = TextBox.Text
                }); ;
            }
        }

        private void TextPositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextPositionComboBox.SelectedItem != null)
            {
                if (OnEvent is not null)
                {
                    OnEvent(this, new()
                    {
                        State = "TextPosition",
                        TextPosition = (Position.TextPosition)TextPositionComboBox.SelectedItem
                    }); ;
                }
            }
        }

        private void Marquee_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "MarqueEnable",
                    MarqueEnable = (bool)MarqueCheckBox.IsChecked
                }); ; ;
            }
            
        }

        private void TextSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "TextSize",
                    Volume = (int)TextSizeSlider.Value
                }); ; ;
            }
            if (TextSizeLabel is not null)
            {
                TextSizeLabel.Content = TextSizeSlider.Value.ToString("F1");
            }
        }


        private void TextRefreshSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "TextRefresh",
                    Volume = (int)TextRefreshSlider.Value
                }); ; ;
            }

            if (RefreshLabel is not null)
            {
                RefreshLabel.Content = TextRefreshSlider.Value.ToString("F1");
            }
        }

        private void TextXSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "TextX",
                    Volume = (int)TextXSlider.Value
                }); ; ;
            }
            if (XLabel is not null)
            {
                XLabel.Content = TextXSlider.Value.ToString("F1");
            }
        }

        private void TextYSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "TextY",
                    Volume = (int)TextYSlider.Value
                }); ; ;
            }
            if (YLabel is not null)
            {
                YLabel.Content = TextYSlider.Value.ToString("F1");
            }
        }

        private void LogoXSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "LogoX",
                    Volume = (int)LogoXSlider.Value
                }); ; ;
            }
            if (XLabel is not null)
            {
                LogoXLabel.Content = LogoXSlider.Value.ToString("F1");
            }
        }

        private void LogoYSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "LogoY",
                    Volume = (int)LogoYSlider.Value
                }); ; ;
            }
            if (XLabel is not null)
            {
                LogoYLabel.Content = LogoYSlider.Value.ToString("F1");
            }
        }

        private void LogoOpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "LogoOpacity",
                    Volume = (int)LogoOpacitySlider.Value
                }); 
            }
            if (XLabel is not null)
            {
                LogoOpacityLabel.Content = LogoOpacitySlider.Value.ToString("F1");
            }
        }

        private void LogoPositionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem != null)
            {
                if (OnEvent is not null)
                {
                    OnEvent(this, new()
                    {
                        State = "LogoPosition",
                        LogoPosition = (Position.LogoPosition)LogoPositionComboBox.SelectedItem
                    }); ; ;
                }
            }
        }
    }
}
