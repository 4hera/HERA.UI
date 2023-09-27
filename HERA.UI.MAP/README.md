# MapUserControl Usage Guide

`MapUserControl` represents a custom user control containing a map powered by GMap.NET. This guide provides an overview of the functions and properties available when using this control.

- [Initial Setup](#initial-setup)
- [Usage](#usage)
  - [Basic Functions](#basic-functions)
    - [SetPosition(double lat, double lng)](#setpositiondouble-lat-double-lng)
    - [SetLat(double lat)](#setlatdouble-lat)
    - [SetLng(double lng)](#setlngdouble-lng)
    - [SetZoom(double zoom)](#setzoomdouble-zoom)
    - [SearchLocation(string text)](#searchlocationstring-text)
    - [SetMarkerWidth(int width)](#setmarkerwidthint-width)
    - [SetMarkerHeight(int height)](#setmarkerheightint-height)
    - [SetMarkerColor(string hex)](#setmarkercolorstring-hex)
    - [SetMapProvider(GMapProvider gMapProvider)](#setmapprovidergmapprovider-gmapprovider)
- [License](#license)

## Initial Setup

Before using the `MapUserControl` class, make sure that you have GMap.NET installed and configured properly in your project. Also, ensure that you have included the necessary `using` directives:

```csharp
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;
using GMap.NET;
```
# Usage

To initialize the control, create an instance of the MapUserControl:
```csharp
MapUserControl mapControl = new MapUserControl();
```
## Basic Functions

### SetPosition(double lat, double lng)
Sets the initial position of the map using latitude (lat) and longitude (lng) coordinates.

```csharp
mapControl.SetPosition(39.9789, 32.7362);
```

### SetLat(double lat)
Sets the latitude coordinate of the map's center.

```csharp
mapControl.SetLat(39.9789);
```


### SetLng(double lng)
Sets the longitude coordinate of the map's center.

```csharp
mapControl.SetLng(32.7362);
```

### SetZoom(double zoom)
Sets the zoom level of the map.

```csharp
mapControl.SetZoom(15);
```

## SetMarkerWidth(int width)
Sets the width of the marker.

```csharp
mapControl.SetMarkerWidth(40);
```
## SetMarkerHeight(int height)
Sets the height of the marker.

```csharp
mapControl.SetMarkerHeight(40);
```
## SetMarkerColor(string hex)
Sets the color of the marker in hexadecimal format.

```csharp
mapControl.SetMarkerColor("#32a852");
```

## SearchLocation(string text)
Searches for a location by text and updates the map's position accordingly.

```csharp
mapControl.SearchLocation("New York");
```

### License
[MIT](https://choosealicense.com/licenses/mit/)