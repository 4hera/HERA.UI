using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
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

namespace HERA.UI.MAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapUserControl mapUserControl;

        private int _udpPort = 2222;
        public UdpClient udpClient;
        private CancellationTokenSource cancellationTokenSource;
        public MainWindow()
        {
            InitializeComponent();
           // StartDiscoverServer();
            mapUserControl = new MapUserControl();
            
            MainMapDock.Children.Add(mapUserControl);
               
            foreach (var prov in MapProviders.Maps)
            {
                ProviderComboBox.Items.Add(prov.Key);
            }
        }
        public void StartDiscoverServer()
        {
            try
            {
                cancellationTokenSource = new CancellationTokenSource();

                Task.Run(async () =>
                {
                    Console.WriteLine("UDP broadcast started to listening...");
                    udpClient = new UdpClient(_udpPort);
                    udpClient.EnableBroadcast = true;
                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        try
                        {
                            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, _udpPort);
                            UdpReceiveResult result = await udpClient.ReceiveAsync();
                            byte[] receivedBytes = result.Buffer;
                            string receivedMessage = Encoding.ASCII.GetString(receivedBytes);
                            Console.WriteLine(receivedMessage);
                            string[] latlng = receivedMessage.Split(",");

                            double _lat = double.Parse(latlng[0]);
                            double _lng = double.Parse(latlng[1]);
                            this.Dispatcher.Invoke((Action)(() =>
                            {
                                mapUserControl.SetLat(_lat);
                                mapUserControl.SetLng(_lng);
                            }));

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }, cancellationTokenSource.Token).ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine(t.Exception.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            double lat = mapUserControl.Lat + 0.001;
            mapUserControl.SetLat(lat);
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            double lat = mapUserControl.Lat - 0.001;
            mapUserControl.SetLat(lat);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            double lng = mapUserControl.Lng + 0.001;
            mapUserControl.SetLng(lng);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            double lng = mapUserControl.Lng - 0.001;
            mapUserControl.SetLng(lng);
        }


        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mapUserControl is not null)
            {
                mapUserControl.SetZoom(ZoomSlider.Value);
            }

        }

        private void MarkerWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int value = (int)MarkerWidth.Value;
            mapUserControl.SetMarkerWidth(value);
        }

        private void MarkerHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int value = (int)MarkerHeight.Value;
            mapUserControl.SetMarkerHeight(value);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                mapUserControl.SetMarkerColor(HexColor.Text);
            }
        }

        private void ProviderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            /*foreach (GMapProvider pr in GMapProviders.List)
            {
                if (pr.Name == ProviderComboBox.SelectedItem.ToString())
                {
                    mapUserControl.SetMapProvider(pr);
                }
            }*/


            GMapProvider map = MapProviders.Maps[ProviderComboBox.SelectedItem.ToString()];

            mapUserControl.SetMapProvider(map);





        }
    }
}
