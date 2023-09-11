using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HERA.UI.VLC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VLCUserControl vLCUserControl = new VLCUserControl();
        TestWindow testWindow = new TestWindow();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
            SizeChanged += MainWindowSizeChanged;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            testWindow.Show();
            MainGrid.Children.Add(vLCUserControl);

            testWindow.OnEvent += (vlcSender, vlcEvet) =>
            {
                switch (vlcEvet.State)
                {
                    case "Play":
                        VLCPlay();
                        break;
                    case "Pause":
                        VLCPause();
                        break;
                    case "Stop":
                        VLCStop();
                        break;
                    case "Mute":
                        VLCMute();
                        break;
                    case "Voice":
                        VLCVolume(vlcEvet.Volume);
                        break;
                    case "Path":
                        VLCPath(vlcEvet.Path);
                        break;
                    case "Contrast":
                        VLCContrast(vlcEvet.Value); 
                        break;
                    case "Brightness":
                        VLCBrightness(vlcEvet.Value);
                        break;
                    case "Hue":
                        VLCHue(vlcEvet.Value);
                        break;
                    case "Saturation":
                        VLCSaturation(vlcEvet.Value);
                        break;
                    case "Gamma":
                        VLCGamma(vlcEvet.Value);
                        break;
                }
            };

        }


        public void VLCPlay()
        {
            vLCUserControl.Play();
        }

        public void VLCPause()
        {
            vLCUserControl.Pause();
        }

        public void VLCStop()
        {
            vLCUserControl.Stop();
        }

        public void VLCMute()
        {
            vLCUserControl.Mute();
        }

        public void VLCVolume(int volume)
        {
            vLCUserControl.SetVolume(volume);
        }

        public void VLCPath(string path)
        {
            Console.WriteLine(path);
            vLCUserControl.SetPath(path);
        }

        public void VLCContrast(float contrast)
        {
            vLCUserControl.SetContrast(contrast);
        }

        public void VLCBrightness(float brightness)
        {
            vLCUserControl.SetBrightness(brightness);
        }
        public void VLCHue(float hue)
        {
            vLCUserControl.SetHue(hue);
        }
        public void VLCSaturation(float saturation)
        {
            vLCUserControl.SetSaturation(saturation);
        }
        public void VLCGamma(float gamma)
        {
            vLCUserControl.SetGamma(gamma);
        }
        public void MainWindowSizeChanged(object sender, RoutedEventArgs e)      
        {
            Console.WriteLine(ActualHeight + " " + ActualWidth);
            vLCUserControl.SetAspectRatio((int)ActualWidth, (int)ActualHeight);
        }



    }
}
