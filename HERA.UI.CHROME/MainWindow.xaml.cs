using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using CefSharp;
using CefSharp.Wpf;

namespace HERA.UI.CHROME
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChromeUserControl chromeUserControl = new ChromeUserControl();
        TestWindow testWindow = new TestWindow();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;  
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {

            MainGrid.Children.Add(chromeUserControl);
            testWindow.OnEvent += (chromeSender, chromeEvent) =>
            {
                switch (chromeEvent.State)
                {
                    case "SetAddress":
                        ChromeSetAddress(chromeEvent.Adress);
                        break;
                    case "SetZoom":
                        ChromeSetZoom(chromeEvent.Zoom);
                        break;
                    case "SetLocation":
                        ChromeSetLocation(chromeEvent.LocationX, chromeEvent.LocationY); 
                        break;
                    case "SetHideScroll":
                        ChromeSetHideScroll(chromeEvent.HideScroll);
                        break;
                    case "SetCrop":
                        ChromeSetCrop(chromeEvent.Crop);
                        break;
                    case "SetCropEnable":
                        ChromeSetCropEnable(chromeEvent.CropEnable);
                        break;
                    case "GoForward":
                        ChromeForward();
                        break;
                    case "GoBack":
                        ChromeBack();
                        break;
                    case "GetLastVisited":
                        ChromeGetLastVisited();
                        break;
                    case "GetLastLocation":
                        ChromeGetLastLocation();
                        break;
                    case "SetNewWindowEnable":
                        ChromeSetNewWindowEnable(chromeEvent.NewWindowEnable);
                        break;
                }
            };
            testWindow.Show();
        }

       
        public void ChromeSetAddress(string adress)
        {
            chromeUserControl.SetAddress(adress);
        }

        public void ChromeSetZoom(double zoom)
        {
            chromeUserControl.SetZoom(zoom);
        }

        private void ChromeSetLocation(int locationX, int locationY)
        {
            chromeUserControl.SetLocation(locationX, locationY);
        }

        private void ChromeSetHideScroll(bool hideScroll)
        {
            chromeUserControl.HideScroll(hideScroll);
        }

        private void ChromeSetCrop(CropParameter crop)
        {
            int x = crop.x;
            int y = crop.y;
            double z = crop.z;
            double sx = crop.sx;
            double sy = crop.sy;
            int sl = crop.sl;
            int st = crop.st;
            chromeUserControl.Crop(x, y, z, sx, sy, sl, st);
        }

        private void ChromeSetCropEnable(bool cropEnable)
        {
            chromeUserControl.SetCropEnable(cropEnable);
        }

        private void ChromeForward()
        {
            chromeUserControl.GoForward();
        }

        private void ChromeBack()
        {
            chromeUserControl.GoBack();
        }

        private void ChromeGetLastVisited()
        {
            Console.WriteLine(chromeUserControl.LastVisited);
        }


        private void ChromeGetLastLocation()
        {
            Console.WriteLine(chromeUserControl.LastLocationPoint);
        }

        private void ChromeSetNewWindowEnable(bool isEnable)
        {
            chromeUserControl.SetNewWindowEnable(isEnable);
        }


    }
}
