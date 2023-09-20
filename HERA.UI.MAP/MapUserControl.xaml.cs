
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
using System.Collections.Generic;
using System.Linq;

namespace HERA.UI.MAP
{
    /// <summary>
    /// Interaction logic for MapUserControl.xaml
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        GMapControl Map;
        public double Lat = 39.97890358816007;
        public double Lng = 32.73618203701316;
        public int MarkerWidth = 40;
        public int MarkerHeight = 40;
        public string MarkerColor = "#32a852";
        GMapMarker gMapMarker;
    

        public MapUserControl()
        {
            InitializeComponent();
            Loaded += MapLoaded;
            GMapProviders.YahooMap.ForceBasicHttpAuthentication("ercan_emir@yahoo.com", "tekken3gon");
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            InitializeMap();
        }

        private void InitializeMap()
        {
            Map = new GMapControl();
            Map.MapProvider = GMapProviders.CustomMap;

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
         
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
            GMapProviders.GoogleMap.ApiKey = "";
            var pos = GMapProviders.GoogleTerrainMap.GetPoint("Ostim Teknopark Turuncu Bina", out status);
            if (pos != null && status == GeoCoderStatusCode.OK)
            {
                Console.WriteLine(status);
                Console.WriteLine(pos.Value);
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
      
                Point point = new Point();
                point.X = Lat;  
                point.Y = Lng;
                IEnumerable<PointLatLng> points = new List<PointLatLng>()
                {
                    new PointLatLng(point.X, point.Y),
                    new PointLatLng(39.97894114439201, 32.736123288931964),
                    new PointLatLng(39.978514093293235, 32.73639066391127),
                    new PointLatLng(39.97855188020591, 32.736826883789156),
                    //new PointLatLng(39.93547475673178, 32.81945932221276),
                   // new PointLatLng(40.93547475673178, 32.81945932221276),
                };
    
                GMapPolygon poly = new GMapPolygon(points);
                GMapRoute route = new GMapRoute(points);
                GMapImage gMapImage = new GMapImage();
                Map.Markers.Add(route);
                Map.Markers.Add(poly);
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
        }
    }
}
