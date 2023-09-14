using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace HERA.UI.EDGE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EdgeUserControl edgeUserControl = new EdgeUserControl();
        TestWindow testWindow = new TestWindow();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindowLoaded;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {

            MainGrid.Children.Add(edgeUserControl);
            testWindow.OnEvent += (edgeSender, edgeEvent) =>
            {
                switch (edgeEvent.State)
                {
                    case "OpenLink":
                        EdgeOpenLink(edgeEvent.Source);
                        break;
                    case "Zoom":
                        EdgeZoom(edgeEvent.Zoom);
                        break;
                    case "LastVisited":
                        EdgeGetLastVisited();
                        break;
                    case "HideScroll":
                        EdgeHideScroll(edgeEvent.HideScroll);
                        break;
                    case "SetLocation":
                        EdgeSetLocation(edgeEvent.LocationX,edgeEvent.LocationY);
                        break;
                    case "GetLocation":
                        EdgeGetLastLocation();
                        break;
                    case "CropEnable":
                        EdgeSetCropEnable(edgeEvent.isEnable);
                        break;
                    case "Crop":
                        EdgeCrop(edgeEvent.Crop);
                        break;
                    case "Back":
                        EdgeBack();
                        break;
                    case "Forward":
                        EdgeForward();
                        break;
                    case "NewWindow":
                        EdgeNewWindow(edgeEvent.isEnable);
                        break;
                }
            };
            testWindow.Show();
   
        }

        

        public void EdgeOpenLink(Uri uri)
        {
            edgeUserControl.SetSource(uri);
        }

        public void EdgeZoom(double zoom)
        {
            edgeUserControl.SetZoom(zoom);
        }

        public string EdgeGetLastVisited()
        {
            Console.WriteLine(edgeUserControl.LastVisitedUrl);
            return edgeUserControl.LastVisitedUrl;
        }

        public void EdgeHideScroll(bool hideScroll)
        {
            edgeUserControl.HideScroll(hideScroll);
        }

        public void EdgeSetLocation(int x,int y)
        {
            edgeUserControl.SetLocation(x, y);
        }

        public Point EdgeGetLastLocation()
        {
            Console.WriteLine(edgeUserControl.LastLocationPoint+"lasttt");
            return edgeUserControl.LastLocationPoint;
        }

        public void EdgeSetCropEnable(bool isEnable)
        {
            edgeUserControl.CropEnable = isEnable;
        }

        public void EdgeCrop(CropParameter crop)
        {
            int x = crop.x;
            int y = crop.y;
            double z = crop.z;
            double sx = crop.sx;
            double sy = crop.sy;
            int sl = crop.sl;
            int st = crop.st;
            edgeUserControl.Crop(x, y, z, sx, sy, sl, st);
        }
        
        public void EdgeBack()
        {
            edgeUserControl.GoBack();
        }

        public void EdgeForward()
        {
            edgeUserControl.GoForward();
        }

        private void EdgeNewWindow(bool isEnable)
        {
            edgeUserControl.NewWindowEnable = isEnable;
        }
    }
}
