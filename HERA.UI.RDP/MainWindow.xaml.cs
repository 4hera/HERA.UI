using MSTSCLib;

using System.Windows;
using System.Windows.Forms.Integration;

using Microsoft.VisualBasic.ApplicationServices;
using System;
using WindowsFormsApp2;
using System.Diagnostics;
using System.Windows.Controls;

namespace HERA.UI.RDP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       RDPUserControl userControl = new RDPUserControl();
        Status Status = new Status();
        public MainWindow()
        {
            InitializeComponent();

            MyForm.Child = userControl;
            userControl.Connecting += UserControl_Connecting;
            userControl.Connected += UserControl_Connected;
            userControl.Disconnected += UserControl_Disconnected;
            userControl.ConnectionError += UserControl_ConnectionError;
            userControl.DisconnectionError += UserControl_DisconnectionError;
            userControl.FatalError += UserControl_FatalError;
            userControl.LogonError += UserControl_LogonError;
            userControl.Error += UserControl_Error;
            SetStatus();
            AuthenticationLevelComboBox.SelectedIndex = 0;  
            ColorDepthComboBox.SelectedIndex = 2;
            EnableSspSupportComboBox.SelectedIndex = 1;
            RedirectSmartCardComboBox.SelectedIndex = 0;
            RedirectPrintersComboBox.SelectedIndex = 0;
            RedirectDrivesComboBox.SelectedIndex = 0;
           

        }

        private void UserControl_Error(object? sender, string e)
        {
            ConsoleText.AppendText($"Error: {e} \n");
            SetStatus();
        }

        private void UserControl_DisconnectionError(object? sender, string e)
        {
            ConsoleText.AppendText($"Disconnection error: {e} \n");
            SetStatus();
        }

        private void UserControl_ConnectionError(object? sender, string e)
        {
            ConsoleText.AppendText($"Connection error: {e} \n");
            SetStatus();
        }

        private void UserControl_Disconnected(object? sender, string e)
        {
            ConsoleText.AppendText("Disconnected..." + "\n");
            ConsoleText.AppendText($"Disconnect Reason: {e} \n");
            SetStatus();
        }

        private void UserControl_Connected(object? sender, EventArgs e)
        {
            ConsoleText.AppendText("Connected..." + "\n");
            SetStatus();
        }

        private void UserControl_Connecting(object? sender, EventArgs e)
        {
            ConsoleText.AppendText("Connecting..." + "\n");
            SetStatus();

        }

        private void UserControl_LogonError(object? sender, string e)
        {
            ConsoleText.AppendText($"Logon error: {e} \n");
            SetStatus();
        }

        private void UserControl_FatalError(object? sender, string e)
        {
            ConsoleText.AppendText($"Fatal error: {e} \n");
            SetStatus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userControl.Connect(ServerText.Text, UserNameText.Text, PasswordText.Text);
            SetStatus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userControl.Disconnect();
            SetStatus();
        }

        private void SetPortButton_Click(object sender, RoutedEventArgs e)
        {
            userControl.SetPort(int.Parse(PortText.Text));
        }

        private void SetStatus()
        {
            System.Windows.Media.SolidColorBrush myBrush = new System.Windows.Media.SolidColorBrush();
            if (userControl.GetStatus() == Status.Default)
            {
                myBrush.Color = System.Windows.Media.Colors.White;
                StatusColor.Fill = myBrush;
                StatusText.Content = "Default";
            }else if (userControl.GetStatus() == Status.Connecting)
            {
                myBrush.Color = System.Windows.Media.Colors.Yellow;
                StatusColor.Fill = myBrush;
                StatusText.Content = "Connecting";
            }else if (userControl.GetStatus() == Status.Connected)
            {
                myBrush.Color = System.Windows.Media.Colors.Green;
                StatusColor.Fill = myBrush;
                StatusText.Content = "Connected";
            }else if(userControl.GetStatus() == Status.Disconnected)
            {
                myBrush.Color = System.Windows.Media.Colors.Gray;
                StatusColor.Fill = myBrush;
                StatusText.Content = "Disconnected";
            }else if(userControl.GetStatus() == Status.Warning)
            {
                myBrush.Color = System.Windows.Media.Colors.YellowGreen;
                StatusColor.Fill = myBrush;
                StatusText.Content = "Warning";
            }else if(userControl.GetStatus() == Status.Error)
            {
                myBrush.Color = System.Windows.Media.Colors.Red;
                StatusColor.Fill = myBrush;
                StatusText.Content = "Error";
            }
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Console.WriteLine(AuthenticationLevelComboBox.SelectedValue);
            var item = (ComboBoxItem)AuthenticationLevelComboBox.SelectedValue;
            var content = (string)item.Content;

            userControl.SetAuthenticationLevel(uint.Parse(content));
            SetStatus();
        }

        private void EnableSspSupportComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            userControl.SetEnableCredSspSupport(EnableSspSupportComboBox.SelectedItem.ToString() == "True");
            SetStatus();
        }

        private void RedirectPrintersComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            userControl.SetRedirectPrinters(RedirectPrintersComboBox.SelectedItem.ToString() == "True");
            SetStatus();
        }

        private void RedirectSmartCardComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            userControl.SetRedirectSmartCards(RedirectSmartCardComboBox.SelectedItem.ToString() == "True");
            SetStatus();
        }

        private void ColorDepthComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)ColorDepthComboBox.SelectedValue;
            var content = (string)item.Content;
            userControl.SetColorDepth(int.Parse(content));
            SetStatus();
        }

        private void SetSizeButton_Click(object sender, RoutedEventArgs e)
        {
            userControl.SetDesktopHeight(int.Parse(DesktopHeightText.Text));
            userControl.SetDesktopWidth(int.Parse(DesktopWidthText.Text));
            SetStatus();
        }

        private void RedirectDrivesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userControl.SetRedirectDrives(RedirectDrivesComboBox.SelectedItem.ToString() == "True");
        }
    }
}
