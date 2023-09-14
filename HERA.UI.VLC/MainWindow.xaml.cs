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
            
            MainGrid.Children.Add(vLCUserControl);
            testWindow.Show();
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
                    case "TextOpacity":
                        VLCTextOpacity((int)vlcEvet.Value);
                        break;
                    case "TextChanged":
                        VLCSetText(vlcEvet.Text); 
                        break;
                    case "Color":
                        VLCSetTextColor(vlcEvet.Color);
                        break;
                    case "TextPosition":
                        VLCSetTextPosition(vlcEvet.TextPosition); 
                        break;
                    case "MarqueEnable":
                        VLCSetMarqueEnable(vlcEvet.MarqueEnable);
                        break;
                    case "TextSize":
                        VLCSetTextSize(vlcEvet.Volume);
                        break;
                    case "TextRefresh":
                        VLCSetRefresh(vlcEvet.Volume);
                        break;
                    case "TextX":
                        VLCSetX(vlcEvet.Volume);
                        break;
                    case "TextY":
                        VLCSetY(vlcEvet.Volume);
                        break;
                    case "SetLogo":
                        VLCSetLogo(vlcEvet.Path);
                        break;
                    case "LogoX":
                        VLCSetLogoX(vlcEvet.Volume);
                        break;
                    case "LogoY":
                        VLCSetLogoY(vlcEvet.Volume);
                        break;
                    case "LogoOpacity":
                        VLCLogoOpacity(vlcEvet.Volume);
                        break;
                    case "LogoPosition":
                        VLCLogoPosition(vlcEvet.LogoPosition);
                        break;
                    case "AudioOutput":
                        VLCSetAudioOutput(vlcEvet.AudioOutput, vlcEvet.AudioDevice);
                        break;
                    
                }
            };

        }

        private void VLCSetAudioOutput(string audioOutput, string audioDevice)
        {
            vLCUserControl.SetAudioDevice(audioOutput, audioDevice);
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
        public void VLCSetText(string text)
        {
            vLCUserControl.SetMarqueeText(text);    
        }
        public void VLCTextOpacity(int opacity)
        {
            vLCUserControl.SetMarqueeOpacity(opacity);
        }
        public void VLCSetTextColor(Color.ColorHex color)
        {
            vLCUserControl.SetMarqueeColor(color);
        }

        public void VLCSetTextPosition(Position.TextPosition position)
        {
            vLCUserControl.SetMarqueePosition(position);
        }
        public void MainWindowSizeChanged(object sender, RoutedEventArgs e)      
        {
            Console.WriteLine(ActualHeight + " " + ActualWidth);
            vLCUserControl.SetAspectRatio((int)ActualWidth, (int)ActualHeight);
        }

        public void VLCSetMarqueEnable(bool marqueEnable)
        {
            
            vLCUserControl.MarqueeOptionsEnable = marqueEnable;
            vLCUserControl.SetMarqueeOptions();
        }

        public void VLCSetTextSize(int size)
        {

            vLCUserControl.SetMarqueeSize(size);
        }

        public void VLCSetRefresh(int refresh)
        {
            vLCUserControl.SetMarqueeRefresh(refresh);
        }

        public void VLCSetX(int x)
        {
            vLCUserControl.SetMarqueeX(x);
        }

        public void VLCSetY(int y)
        {
            vLCUserControl.SetMarqueeY(y);
        }

        public void VLCSetLogo(string logoPath)
        {
            vLCUserControl.SetLogoFile(logoPath);
        }

        public void VLCSetLogoX(int x)
        {
            Console.WriteLine(x);
            vLCUserControl.SetLogoX(x);
        }
        public void VLCSetLogoY(int y)
        {
            vLCUserControl.SetLogoY(y);
        }

        public void VLCLogoOpacity(int opacity)
        {
            vLCUserControl.SetLogoOpacity(opacity);
        }

        public void VLCLogoPosition(Position.LogoPosition position)
        {
            vLCUserControl.SetLogoPosition(position);
        }
    }
}
