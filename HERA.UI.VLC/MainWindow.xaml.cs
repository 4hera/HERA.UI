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
                    default:
                        VLCVoice(vlcEvet.Volume);
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

        public void VLCVoice(int volume)
        {
            vLCUserControl.setVoice(volume);
        }


        public void MainWindowSizeChanged(object sender, RoutedEventArgs e)      
        {
            Console.WriteLine(ActualHeight + " " + ActualWidth);
            vLCUserControl.SetAspectRatio((int)ActualWidth, (int)ActualHeight);
        }



    }
}
