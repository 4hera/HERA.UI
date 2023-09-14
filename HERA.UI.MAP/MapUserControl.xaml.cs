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
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;
using GMap.NET;

namespace HERA.UI.MAP
{
    /// <summary>
    /// Interaction logic for MapUserControl.xaml
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        GMapControl Map;
        public double Lat = 39.925533;
        public double Lng = 32.866287;
        GMapMarker gMapMarker;
        RedDotMarker redDotMarker = new RedDotMarker();

        public MapUserControl()
        {
            InitializeComponent();
            Loaded += MapLoaded;
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            InitializeMap();
        }

        private void InitializeMap()
        {
            Map = new GMapControl();
            Map.MapProvider = GMapProviders.GoogleMap;
            MapDock.Children.Add(Map);
            SetPosition();
            Map.MinZoom = 1;
            Map.MaxZoom = 100;
            Map.Zoom = 15;
            Map.ShowCenter = false;
            PointLatLng pointLatLng = new PointLatLng(Lat, Lng);
            gMapMarker = new GMapMarker(pointLatLng);

            gMapMarker.Shape = new Ellipse { 
                Width = 40,
                Height = 40,
                Stroke = Brushes.Red,
                StrokeThickness = 1.5
            };
           
            Map.Markers.Add(gMapMarker);
        }

        public void SetPosition() {
            PointLatLng pointLatLng = new PointLatLng(Lat, Lng);
            foreach (GMapMarker marker in Map.Markers)
            {
                marker.Position = pointLatLng;
            }
            Map.Position = pointLatLng;
        }

        public void SetLat(double lat)
        {
            Lat = lat;
            SetPosition();
        }

        public void SetLng(double lng)
        {
            Lng = lng;
            SetPosition();
        }

        public void SetZoom(double zoom)
        {
            if(Map is not null) {
                Map.Zoom = zoom;
            }
            
        }



    }
}
