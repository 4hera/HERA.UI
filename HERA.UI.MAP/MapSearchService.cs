using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.MAP
{
    public class MapSearchService
    {
        public string ApiKey { get; set; } = "AIzaSyBTS1GZrKmMTskKuPv2tVbFCuPwIu5cEV4";

        public PointLatLng? SearchLocation(string text)
        {
            GMapProviders.GoogleMap.ApiKey = ApiKey;
            GeoCoderStatusCode status;
            var pos = GMapProviders.GoogleMap.GetPoint(text, out status);
            
            if (pos != null && status == GeoCoderStatusCode.OK)
            {
                return (PointLatLng)pos;
            }

            return null;
        }

    }
}
