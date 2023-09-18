using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.CHROME
{
    public class CustomLifeSpanHandler: ILifeSpanHandler
    {
        public bool NewWindowEnable;

        public CustomLifeSpanHandler(bool newWindowEnable )
        {
            NewWindowEnable = newWindowEnable;
        }
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return true;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
       
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            if(NewWindowEnable)
            {
                browser.MainFrame.LoadUrl(targetUrl);
                newBrowser = null;
                return true;
            }
            else
            {
                newBrowser = null;
                return true;
            }
            
        }
    }
}
