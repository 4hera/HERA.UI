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
        public enum DisconnectReason : int
        {
            SocketClosed = 2308,
            ByServer = 3,
            ClientDecompressionError = 3080,
            ConnectionTimedOut = 264,
            DecryptionError = 3078,
            DNSLookupFailed = 260,
            DNSLookupFailed2 = 1288,
            EncryptionError = 2822,
            GetHostByNameFailed = 1540,
            HostNotFound = 520,
            InternalError = 1032,
            InternalSecurityError = 2310,
            InternalSecurityError2 = 2566,
            InvalidEncryption = 1286,
            InvalidIP = 2052,
            InvalidServerSecurityInfo = 1542,
            InvalidSecurityData = 1030,
            InvalidIPAddr = 776,
            LicensingFailed = 2056,
            LicensingTimeout = 2312,
            LocalNotError = 1,
            NoInfo = 0,
            OutOfMemory = 262,
            OutOfMemory2 = 518,
            OutOfMemory3 = 774,
            RemoteByUser = 2,
            ServerCertificateUnpackErr = 1798,
            SocketConnectFailed = 516,
            SocketRecvFailed = 1028,
            TimeoutOccurred = 1796,
            TimerError = 1544,
            WinsockSendFailed = 772,
            DISABLED = 2823,
            EXPIRED = 3591,
            LOCKED_OUT = 3335,
            RESTRICTION = 3079,
            IRED = 6919,
            ON_POLICY = 5639,
            ED_REQUIRED_BY_SERVER = 8455,
            ILURE = 2055,
            NTICATING_AUTHORITY = 6151,
            USER = 2567,
            _EXPIRED = 3847,
            _MUST_CHANGE = 4615,
            TLM_ONLY = 5895,
            D_CARD_BLOCKED = 8711,
            D_WRONG_PIN = 7175,
            ConnectionCanceled = 7943
        }

        public enum FatalErrorType
        {
            Unknown = 0,
            Internal_1 = 1,
            OutOfMemory = 2,
            WindowCreation = 3,
            Internal_2 = 4,
            Internal_3 = 5,
            Internal_4 = 6,
            Unrecoverable = 7,
            Winsock = 100
        };

        public enum LogonErrorType
        {

            ARBITRATION_CODE_BUMP_OPTIONS = -5,         //Winlogon is displaying the Session Contention dialog box.
            ARBITRATION_CODE_CONTINUE_LOGON = -2,       //Winlogon is continuing with the logon process.
            ARBITRATION_CODE_CONTINUE_TERMINATE = -3,   //Winlogon is ending silently.
            ARBITRATION_CODE_NOPERM_DIALOG = -6,        //Winlogon is displaying the No Permissions dialog box.
            ARBITRATION_CODE_REFUSED_DIALOG = -7,       //Winlogon is displaying the Disconnect Refused dialog box.
            ARBITRATION_CODE_RECONN_OPTIONS = -4,       //Winlogon is displaying the Reconnect dialog box.
            ERROR_CODE_ACCESS_DENIED = -1,              //The user was denied access.
            LOGON_FAILED_BAD_PASSWORD = 0,              //The logon failed because the logon credentials are not valid.
            LOGON_FAILED_UPDATE_PASSWORD = 1,           //The password is expired. The user must update their password to continue logging on. 
            LOGON_FAILED_OTHER = 2,                     //Another logon or post-logon error occurred. The Remote Desktop client displays a logon screen to the user.
            LOGON_WARNING = 3,                          //The Remote Desktop client displays a dialog box that contains important information for the user.
            STATUS_ACCOUNT_RESTRICTION = -1073741714,   //The user name and authentication information are valid, but authentication was blocked due to restrictions on the user account, such as time-of-day restrictions.
            STATUS_LOGON_FAILURE = -1073741715,         //The attempted logon is not valid. This is due to either an incorrect user name or incorrect authentication information.
            STATUS_PASSWORD_MUST_CHANGE = -1073741276   //The password is expired. The user must update their password to continue logging on.
        }

        public enum WarningType
        {
            bitmapCorrupt = 1      //Bitmap cache is corrupt
        }

        public enum ConnectionStatusEnum : short
        {
            Disconnected = 0,
            Connected = 1,
            Connecting = 2
        }
        public event EventHandler Connecting;
        public event EventHandler Connected;
        public event EventHandler<string> Disconnected;
        public event EventHandler Warning;
        public event EventHandler<string> FatalError;
        public event EventHandler<string> LogonError;
        public event EventHandler<string> ConnectionError;
        public event EventHandler<string> DisconnectionError;
        public event EventHandler<string> Error;
        public int DesktopHeight  = 768 ;
        public int DesktopWidth = 1200;
        public uint AuthenticationLevel = 0;
        public int RDPPort = 3389;
        public int ColorDepth = 16;
        public bool RedirectDrives = false;
        public string RDPServer;
        public string RDPUserName;
        public string RDPPassword;
        public bool EnableCredSspSupport = true;
        public bool RedirectPrinters  = false;
        public bool RedirectSmartCards = false;
        public Status status = Status.Default;
        public RDPUserControl()
        {
            InitializeComponent();
            rdp.DesktopHeight = DesktopHeight; // +
            rdp.DesktopWidth = DesktopWidth; // +
            rdp.AdvancedSettings9.AuthenticationLevel = AuthenticationLevel; // +
            rdp.AdvancedSettings9.EnableCredSspSupport = EnableCredSspSupport; // +
            rdp.AdvancedSettings9.RedirectPrinters = RedirectPrinters;
            rdp.AdvancedSettings9.RedirectSmartCards = RedirectSmartCards;
            rdp.AdvancedSettings9.RedirectDrives = RedirectDrives;
            rdp.AdvancedSettings9.RDPPort = RDPPort; // +
            rdp.ColorDepth = ColorDepth; // +
           rdp.AdvancedSettings9.re
            rdp.OnConnecting += rdp_OnConnecting;
            rdp.OnConnected += rdp_OnConnected;
            rdp.OnDisconnected += rdp_OnDisconnected;
            rdp.OnFatalError += Rdp_OnFatalError;
            rdp.OnLogonError += Rdp_OnLogonError;
            
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

            try
            {
                rdp.Server = Server; // +
                rdp.UserName = UserName;// +
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = Password;
                rdp.AdvancedSettings9.ClearTextPassword = Password;
                rdp.Connect();
            }
            catch (Exception ex)
            {
                OnConnectionError(ex.Message);
                status = Status.Error;
            }


        }

        public void SetPort(int Port)
        {
            rdp.AdvancedSettings9.RDPPort = Port;
        }


        public void Disconnect()
        {
            try
            {
                rdp.Disconnect();
            }
            catch (Exception ex)
            {
                OnDisconnectionError(ex.Message);
                status = Status.Error;
            }

        }

        public Status GetStatus()
        {
            return status;
        }

        public void SetAuthenticationLevel(uint level)
        {
            try
            {
                rdp.AdvancedSettings9.AuthenticationLevel = level;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
        }   

        public void SetColorDepth(int colorDepth)
        {
            try
            {
                rdp.ColorDepth = colorDepth;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
            
        }

        public void SetRedirectPrinters(bool redirectPrinters)
        {
            try
            {
                rdp.AdvancedSettings9.RedirectPrinters = redirectPrinters;
            }catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
            
        }

        public void SetRedirectSmartCards(bool redirectSmartCards)
        {
            try
            {
                rdp.AdvancedSettings9.RedirectSmartCards = redirectSmartCards;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
            
        }

        public void SetEnableCredSspSupport(bool enableCredSspSupport)
        {
            try
            {
                rdp.AdvancedSettings9.EnableCredSspSupport = enableCredSspSupport;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
            
        }

        public void SetDesktopWidth(int width)
        {
            try
            {
                rdp.DesktopWidth = width;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
            
        }

        public void SetDesktopHeight(int height)
        {
            try
            {
                rdp.DesktopHeight= height;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
        }

        public void SetRedirectDrives(bool redirectDrives)
        {
            try
            {
                rdp.AdvancedSettings9.RedirectDrives = redirectDrives;
            }catch (Exception ex)
            {
                OnError(ex.Message);
                status = Status.Error;
            }
        }
        private void rdp_OnConnecting(object sender, EventArgs e)
        {
            status = Status.Connecting;
            OnConnecting(e);

        }

        private void rdp_OnConnected(object sender, EventArgs e)
        {
            status = Status.Connected;
            OnConnected(e);
        }

        private void rdp_OnDisconnected(object sender, IMsTscAxEvents_OnDisconnectedEvent e)
        {
            status = Status.Disconnected;
            OnDisconnected(e);
        }

        private void rdp_OnWarning(object sender, EventArgs e)
        {
            status = Status.Warning;
            OnWarning(e);
        }

        private void Rdp_OnLogonError(object sender, IMsTscAxEvents_OnLogonErrorEvent e)
        {
            OnLogonError(e);
            status = Status.Error;
        }

        private void Rdp_OnFatalError(object sender, IMsTscAxEvents_OnFatalErrorEvent e)
        {
            OnFatalError(e);
            status = Status.Error;
        }


        public virtual void OnConnecting(EventArgs e)
        {
            Connecting?.Invoke(this, e);
        }

        public virtual void OnConnected(EventArgs e)
        {
            Connected?.Invoke(this, e);
        }

        public virtual void OnDisconnected(IMsTscAxEvents_OnDisconnectedEvent e)
        {
            Disconnected?.Invoke(this, ((DisconnectReason)e.discReason).ToString());
        }

        public virtual void OnWarning(EventArgs e)
        {
            Warning?.Invoke(this, e);
        }

        public virtual void OnConnectionError(string errorMessage)
        {
            ConnectionError?.Invoke(this, errorMessage);
        }

        public virtual void OnDisconnectionError(string errorMessage)
        {
            DisconnectionError?.Invoke(this, errorMessage);
        }

        public virtual void OnFatalError(IMsTscAxEvents_OnFatalErrorEvent e)
        {

            FatalError?.Invoke(this, ((LogonErrorType)e.errorCode).ToString());
        }

        public virtual void OnLogonError(IMsTscAxEvents_OnLogonErrorEvent e)
        {

            LogonError?.Invoke(this, ((LogonErrorType)e.lError).ToString());
        }

        public virtual void OnError(string errorMessage)
        {
            Error?.Invoke(this, errorMessage);
        }
    }

    public enum Status
    {
        Default,
        Connected,
        Connecting,
        Disconnected,
        Warning,
        Error
    }
}
