
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;
using GMap.NET;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Net;

namespace HERA.UI.MAP
{
    /// <summary>
    /// Interaction logic for MapUserControl.xaml
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        GMapControl Map;
        public double Lat = 39.93147475673178;
        public double Lng = 32.81545932221276;
        public int MarkerWidth = 40;
        public int MarkerHeight = 40;
        public string MarkerColor = "#32a852";
        GMapMarker gMapMarker;
    

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
            Map.MapProvider = GMapProviders.CustomMap;
            foreach (GMapProvider prov in GMapProviders.List)
            {
            //    Console.WriteLine(prov.Name);
            }
           // GMapProviders.YahooMap.ForceBasicHttpAuthentication();
            GMaps.Instance.Mode = AccessMode.ServerOnly;
         
            MapDock.Children.Add(Map);
            SetPosition();
            Map.MinZoom = 1;
            Map.MaxZoom = 100;
            Map.Zoom = 15;
            Map.ShowCenter = false;
            PointLatLng pointLatLng = new PointLatLng(Lat, Lng);
            gMapMarker = new GMapMarker(pointLatLng);
            SetMarker();
            GeoCoderStatusCode status;
            var pos = GMapProviders.GoogleTerrainMap.GetPoint("Ostim Teknopark Turuncu Bina", out status);
        //    Console.WriteLine(status);
            if (pos != null && status == GeoCoderStatusCode.OK)
            {
             //   Console.WriteLine(pos.Value);
            }
        }


        public void SetPosition()
        {
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
            if (Map is not null)
            { 
                Map.Zoom = zoom;
            }
        }

        public void SetMarker()
        {
            try
            {
                Color color = (Color)ColorConverter.ConvertFromString(MarkerColor);
                SolidColorBrush brush = new SolidColorBrush(color);
                Map.Markers.Clear();
                gMapMarker.Shape = new Ellipse
                {
                    Width = MarkerWidth,
                    Height = MarkerHeight,
                    Fill = brush,
                    Effect = new DropShadowEffect()
                };
                Map.Markers.Add(gMapMarker);
                SetPosition();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void SetMarkerWidth(int width)
        {
            MarkerWidth = width;
            SetMarker();
        }

        public void SetMarkerHeight(int height)
        {
            MarkerHeight = height;
            SetMarker();
        }

        public void SetMarkerColor(string hex)
        {
            MarkerColor = hex;
            SetMarker();
        }

        public void SetMapProvider(GMapProvider gMapProvider)
        {
            Map.MapProvider = gMapProvider;
            Console.WriteLine(Map.MapProvider.Copyright);
            Console.WriteLine(Map.MapProvider.Name);
            Console.WriteLine(Map.MapProvider.Id);
        }
    }
}
