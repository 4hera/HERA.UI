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

namespace HERA.UI.MAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapUserControl mapUserControl = new MapUserControl();
        public MainWindow()
        {
            InitializeComponent();

            MainMapDock.Children.Add(mapUserControl);
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
            Console.WriteLine(ZoomSlider.Value);
            mapUserControl.SetZoom(ZoomSlider.Value);
        }
    }
}
