using GoogleMaps.LocationServices;


AddressData[] addresses = new AddressData[]
{
    new AddressData // Belgium
    {
        Address = "Rue du Cornet 6",
        City = "VERVIERS",
        State = null,
        Country = "Belgium",
        Zip = "B-4800"
    },
    new AddressData
    {
        Address = "1600 Pennsylvania ave",
        City = "Washington",
        State = "DC"
    },
    new AddressData
    {
        Address = "407 N Maple Dr. #1",
        City = "Beverly Hills",
        State = "CA"
    }
};

// Constructor has 3 overload
// No parameters. It does not use API Key
//var gls = new GoogleLocationService();

// Boolean parameter to force the requests to use https 
// var gls = new GoogleLocationService(useHttps: true);

// String paremeter that provides the google map api key
var gls = new GoogleLocationService(apikey: "AIzaSyBTS1GZrKmMTskKuPv2tVbFCuPwIu5cEV4");
foreach (var address in addresses)
{
    try
    {
        var latlong = gls.GetLatLongFromAddress(address);
        var Latitude = latlong.Latitude;
        var Longitude = latlong.Longitude;
        System.Console.WriteLine("Address ({0}) is at {1},{2}", address, Latitude, Longitude);
    }
    catch (System.Net.WebException ex)
    {
        System.Console.WriteLine("Google Maps API Error {0}", ex.Message);
    }

}