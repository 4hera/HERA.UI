using GMap.NET.MapProviders;
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
        MapUserControl mapUserControl;


        public MainWindow()
        {
            InitializeComponent();
            mapUserControl = new MapUserControl();
            MainMapDock.Children.Add(mapUserControl);
            foreach (GMapProvider prov in GMapProviders.List)
            {
                ProviderComboBox.Items.Add(prov.Name);
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
            if(mapUserControl is not null)
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

            foreach (GMapProvider pr in GMapProviders.List)
            {
                if (pr.Name == ProviderComboBox.SelectedItem.ToString())
                {
                    mapUserControl.SetMapProvider(pr);
                }
            }

       
                
            

            

           

        }
    }
}
