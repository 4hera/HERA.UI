using AxMSTSCLib;
using MSTSCLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class RDPUserControl : UserControl
    {

        public event EventHandler Connecting;
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler Warning;

        public RDPUserControl()
        {
            InitializeComponent();
            rdp.DesktopHeight = 768; // +
            rdp.DesktopWidth = 1200; // +
            rdp.AdvancedSettings9.AuthenticationLevel = 0; // +
            rdp.AdvancedSettings9.EnableCredSspSupport = true; // +
            rdp.AdvancedSettings9.RedirectPrinters = false;         
            rdp.AdvancedSettings9.RedirectSmartCards = false;
            rdp.AdvancedSettings9.RDPPort = 3389; // +
            rdp.ColorDepth = 16; // +
            rdp.OnConnecting += rdp_OnConnecting;
            rdp.OnConnected += rdp_OnConnected;
                        
        }

        public event EventHandler rdpEvent;


        public void Connect(string Server, String UserName, String Password)
        {
           

                if (Server == null || Server == "")
                {
                    throw new Exception("Server address is required.");
                }
                if (UserName == null || UserName == "")
                {
                    throw new Exception("Username address is required.");
                }
                if (Password == null)
                {
                    throw new Exception("Password address is required.");
                }
                rdp.Server = Server; // +
                rdp.UserName = UserName;// +
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = Password;
                rdp.AdvancedSettings9.ClearTextPassword = Password;
                rdp.Connect();
            
        }

        public void SetPort(int Port)
        {
            rdp.AdvancedSettings9.RDPPort = Port;
        }


        public void Disconnect()
        {
            rdp.Disconnect();
        }

        private void rdp_OnConnecting(object sender, EventArgs e)
        {
            Console.WriteLine("connecting...");
            OnConnecting(e);
          
        }

        private void rdp_OnConnected(object sender, EventArgs e)
        {
            Console.WriteLine("connected");
            OnConnected(e);
        }

        private void rdp_OnDisconnected(object sender, EventArgs e)
        {
            Console.WriteLine("disconnected");
            OnDisconnected(e);
        }

        private void rdp_OnWarning(object sender, EventArgs e)
        {
            Console.WriteLine("onwarning");
            OnWarning(e);
        }

        
        public virtual void OnConnecting(EventArgs e)
        {
            Connecting?.Invoke(this, e);
        }

        public virtual void OnConnected(EventArgs e)
        {
            Connected?.Invoke(this, e);
        }

        public virtual void OnDisconnected(EventArgs e)
        {
            Disconnected?.Invoke(this, e);
        }

        public virtual void OnWarning(EventArgs e)
        {
            Warning?.Invoke(this, e);
        }


    }
}
