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
using CefSharp;
using CefSharp.DevTools.Network;
using CefSharp.Wpf;


namespace HERA.UI.CHROME
{
    /// <summary>
    /// Interaction logic for ChromeUserControl.xaml
    /// </summary>
    public partial class ChromeUserControl : UserControl
    {
        ChromiumWebBrowser chromiumWebBrowser;
        public Point LastLocationPoint = new Point();
        public bool CropEnable = false;
        public string LastVisited;
        public bool NewWindowEnable = false;

        public ChromeUserControl()
        {
            InitializeComponent();
            Loaded += ChromeLoaded;
        }

        private void ChromeLoaded(object sender, RoutedEventArgs e)
        {
            InitializeChrome();
        }

        private void InitializeChrome()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("ignore-certificate-errors");
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settings.CachePath = path.ToString();

            //settings.UserDataPath = path.ToString();

            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream", "1");

            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capture", "1");

            settings.CefCommandLineArgs.Add("enable-media-stream", "1");

            settings.LogSeverity = LogSeverity.Disable;

            Cef.Initialize(settings);
            chromiumWebBrowser = new ChromiumWebBrowser();
            chromiumWebBrowser.Address = "http://www.google.com";
            chromiumWebBrowser.AddressChanged += (s, e) =>
            {
                LastVisited = chromiumWebBrowser.Address;
            };
            chromiumWebBrowser.LifeSpanHandler = new CustomLifeSpanHandler(false);
            WebViewDock.Children.Add(chromiumWebBrowser);

        }

        public void SetAdress(string adress)
        {
            chromiumWebBrowser.Address = adress;
        }

        public void SetZoom(double zoom)
        {
            chromiumWebBrowser.ZoomLevel = zoom;
        }

        public double GetZoom()
        {
            return chromiumWebBrowser.ZoomLevel;    
        }

        public void SetLocation(int x , int y)
        {
            string script = $"window.scrollTo( {x}, {y} );";
            chromiumWebBrowser.EvaluateScriptAsync(script);
            LastLocationPoint.X = x;
            LastLocationPoint.Y = y;
        }

        public Point GetLocation()
        {
            return LastLocationPoint;
        }

        public void HideScroll(bool isHide)
        {
            if (chromiumWebBrowser is not null)
            {
                if (isHide)
                {
                    string script = "document.body.style.overflow = 'hidden';";
                    chromiumWebBrowser.EvaluateScriptAsync(script);
                }
                else
                {
                    string script = "document.body.style.overflow = 'visible';";
                    chromiumWebBrowser.EvaluateScriptAsync(script);
                }
            }
        }

        public void SetCropEnable(bool isEnable)
        {


            CropEnable = isEnable;
        }

        public void Crop(int x, int y, double z, double sx, double sy, int sl, int st)
        {
            Console.WriteLine(CropEnable);
            string bodyTransformOrigin = "document.body.style.transformOrigin = '" + sl + "px " + st + "px'";
            string bodyScaleScript = "document.body.style.transform = 'scale(" + sx + "," + sy + ")'";
            string Location = $"window.scrollTo( {x}, {y} );";

            if (CropEnable)
            {
                if (z < 1)
                {
                    chromiumWebBrowser.ZoomLevel = 1;
                }

                chromiumWebBrowser.ZoomLevel = z;
                chromiumWebBrowser.EvaluateScriptAsync(bodyScaleScript);
                chromiumWebBrowser.EvaluateScriptAsync(bodyTransformOrigin);
            }
            chromiumWebBrowser.EvaluateScriptAsync(Location);
        }

        public void GoBack()
        {
            chromiumWebBrowser.Back();
        }

        public void GoForward()
        {
            chromiumWebBrowser.Forward();
        }


        public void SetNewWindowEnable(bool isEnable)
        {
            Console.WriteLine(isEnable);
            chromiumWebBrowser.LifeSpanHandler = new CustomLifeSpanHandler(isEnable);
        }


    }
}
