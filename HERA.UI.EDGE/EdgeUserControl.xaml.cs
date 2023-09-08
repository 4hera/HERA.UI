using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HERA.UI.EDGE
{
    /// <summary>
    /// Interaction logic for EdgeUserControl.xaml
    /// </summary>
    public partial class EdgeUserControl : UserControl
    {
        public WebView2 EdgeWebView;
        public string Url = "about:blank";
        public string LastVisitedUrl;
        public Point LastLocationPoint = new Point();
        public bool CropEnable = false;
        public EdgeUserControl()
        {
            InitializeComponent();
            Loaded += EdgeLoaded;
        }

        private void EdgeLoaded(object sender, RoutedEventArgs e)
        {
            InitializeEdge();

        }

        public async void InitializeEdge()
        {
            EdgeWebView = new WebView2();
            WebViewDock.Children.Add(EdgeWebView);
            var op = new CoreWebView2EnvironmentOptions("--ignore-certificate-errors");
            var env = await CoreWebView2Environment.CreateAsync(null, null, op);
            await EdgeWebView.EnsureCoreWebView2Async(env);
            if (EdgeWebView != null && EdgeWebView.CoreWebView2 != null)
            {
                EdgeWebView.ZoomFactor = 1.0f;
                EdgeWebView.Source = new Uri(Url);
            }
            EdgeWebView.SourceChanged += (s, e) =>
            {
                LastVisitedUrl = EdgeWebView.Source.ToString();
            };
            EdgeWebView.CoreWebView2.DOMContentLoaded += (s, e) =>
            {
                if (EdgeWebView != null && EdgeWebView.CoreWebView2 != null)
                {

                    HideScroll(false);
                }
            };
        }


        public void SetSource(Uri path)
        {
            if (path is not null)
            {
                if (EdgeWebView != null && EdgeWebView.CoreWebView2 != null)
                {
                    EdgeWebView.Source = path;
                }
            }
        }

        public void SetZoom(double zoom)
        {
            if (zoom <= 0)
            {
                EdgeWebView.ZoomFactor = 1.0f;
            }
            else if (zoom > 5)
            {
                EdgeWebView.ZoomFactor = 1.0f;
            }
            else
            {
                EdgeWebView.ZoomFactor = zoom;
            }
        }
        
        public void SetLocation(int x , int y)
        {
            string script = $"window.scrollTo( {x}, {y} );";
            EdgeWebView.CoreWebView2.ExecuteScriptAsync(script);
            LastLocationPoint.X = x; 
            LastLocationPoint.Y = y;
        }
        public Point GetLocation() {
            return LastLocationPoint; 
        }
        public void HideScroll(bool isHide)
        {
            if (EdgeWebView != null && EdgeWebView.CoreWebView2 != null)
            {   
                if(isHide) {
                    string script = "document.body.style.overflow = 'hidden';";
                    EdgeWebView.CoreWebView2.ExecuteScriptAsync(script);
                }
                else {
                    string script = "document.body.style.overflow = 'visible';";
                    EdgeWebView.CoreWebView2.ExecuteScriptAsync(script);
                }     
            }
        }

        public void SetCropEnable(bool isEnable)
        {
            CropEnable = isEnable;
        }

        public void Crop(int x,int y,double z,double sx,double sy,int sl,int st)
        {
            Console.WriteLine(CropEnable);
            

            string bodyTransformOrigin = "document.body.style.transformOrigin = '" + sl + "px " + st + "px'";
            string bodyScaleScript = "document.body.style.transform = 'scale(" + sx + "," + sy + ")'";
            string Location = $"window.scrollTo( {x}, {y} );";

            if(CropEnable)
            {
                if (z < 1.0f)
                {
                    EdgeWebView.ZoomFactor = 1.0f;
                }

                EdgeWebView.ZoomFactor = z;
                EdgeWebView.CoreWebView2.ExecuteScriptAsync(bodyScaleScript);
                EdgeWebView.CoreWebView2.ExecuteScriptAsync(bodyTransformOrigin);
            }

            EdgeWebView.CoreWebView2.ExecuteScriptAsync(Location);
        }

    }
}
