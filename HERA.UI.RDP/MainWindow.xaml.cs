using MSTSCLib;

using System.Windows;
using System.Windows.Forms.Integration;
using AxMSTSCLib;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using WindowsFormsApp2;
using System.Diagnostics;

namespace HERA.UI.RDP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       RDPUserControl userControl = new RDPUserControl();
        public MainWindow()
        {
            InitializeComponent();

            MyForm.Child = userControl;
          
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userControl.Connect(ServerText.Text, UserNameText.Text, PasswordText.Text);
            }catch (Exception ex)
            {
                ConsoleText.AppendText(ex.Message + "\n");
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            userControl.Disconnect();
        }

        private void SetPortButton_Click(object sender, RoutedEventArgs e)
        {
            userControl.SetPort(int.Parse(PortText.Text));
        }
    }
}
