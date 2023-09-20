using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.MAP
{
    public static class MapProviders
    {
        public static Dictionary<string, GMapProvider> Maps = new Dictionary<string, GMapProvider>()
        {
            {"Google"               ,GMapProviders.GoogleMap},               // 
            {"Bing"                 ,GMapProviders.BingMap},
            {"BingSatelliteMap"     ,GMapProviders.BingSatelliteMap},               // 
            {"BingHybridMap"        ,GMapProviders.BingHybridMap},                 // 
            {"BingOSMap"            ,GMapProviders.BingOSMap},              //
            {"OpenCycle"            ,GMapProviders.OpenCycleMap},            // 
            {"OpenStreet"           ,GMapProviders.OpenStreetMap},            // 
            {"OpenCycleLandscapeMap",GMapProviders.OpenCycleLandscapeMap},                 // 
            {"OpenCycleTransportMap",GMapProviders.OpenCycleTransportMap},                // 
            {"OpenStreet4UMap"      ,GMapProviders.OpenStreet4UMap},               // 
            {"OpenSeaMapHybrid"     ,GMapProviders.OpenSeaMapHybrid},                 // 
            {"WikiMapiaMap"         ,GMapProviders.WikiMapiaMap},                                                                                 // 
            {"GoogleSatelliteMap"   ,GMapProviders.GoogleSatelliteMap},                                                                   // 
            {"GoogleHybridMap"      ,GMapProviders.GoogleHybridMap},                 // 
            {"GoogleTerrainMap"     ,GMapProviders.GoogleTerrainMap},
            {"Yaho", GMapProviders.YahooMap }// 
        };
    }
}
