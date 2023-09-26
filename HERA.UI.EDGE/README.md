# EdgeUserControl Usage Guide

`EdgeUserControl` represents a custom user control containing a Chromium-based web browser using the WebView2 control. This guide provides an overview of the functions and properties available when using this control.

- [Initial Setup](#initial-setup)
- [Usage](#usage)
  - [Basic Functions](#basic-functions)
    - [SetSource(Uri path)](#setsourceuri-path)
    - [SetZoom(double zoom)](#setzoomdouble-zoom)
    - [GetZoom()](#getzoom)
    - [SetLocation(int x, int y)](#setlocationint-x-int-y)
    - [GetLocation()](#getlocation)
    - [HideScroll(bool isHide)](#hidescrollbool-ishide)
    - [SetCropEnable(bool isEnable)](#setcropenablebool-isenable)
    - [Crop(int x, int y, double z, double sx, double sy, int sl, int st)](#cropint-x-int-y-double-z-double-sx-double-sy-int-sl-int-st)
    - [GoBack() and GoForward()](#goback-and-goforward)
    - [SetNewWindowEnable(bool isEnable)](#setnewwindowenablebool-isenable)
- [License](#license)

## Initial Setup

Before using the `EdgeUserControl` class, ensure that the `Microsoft.Web.WebView2` library is properly installed, and Chromium browser settings are configured.

```csharp
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
```


# Usage

To initialize the control, create an instance of the EdgeUserControl:

```csharp
EdgeUserControl edgeControl = new EdgeUserControl();
```
## Basic Functions

### SetSource(Uri path)
Used to navigate to the specified URL.

```csharp
edgeControl.SetSource(new Uri("https://example.com"));
```

### SetZoom(double zoom)
Sets the browser zoom level.

- `Minimum Zoom`: 0.0001f
- `Maximum Zoom`: 5

```csharp
edgeControl.SetZoom(1.5); // Zoom in by 1.5x
```

### GetZoom()
Retrieves the current zoom level.

```csharp
double currentZoom = edgeControl.GetZoom();
```

### SetLocation(int x, int y)
Used to scroll to specific coordinates on the page.


```csharp
edgeControl.SetLocation(100, 200);
```

### GetLocation()
Retrieves the current page scroll position.

```csharp
Point location = edgeControl.GetLocation();
```

### HideScroll(bool isHide)
Used to hide or show page scrollbars.

```csharp
edgeControl.HideScroll(true); // Hide scrollbars
edgeControl.HideScroll(false); // Show scrollbars
```

### SetCropEnable(bool isEnable)
Enables or disables the page cropping feature.

```csharp
edgeControl.SetCropEnable(true); // Enable cropping
edgeControl.SetCropEnable(false); // Disable cropping
```
### Crop(int x, int y, double z, double sx, double sy, int sl, int st)

The `Crop` method in the `EdgeUserControl` class is used to perform page cropping with specified parameters. It allows you to control the zoom level, scaling, and origin point for cropping a web page. Before using this method, ensure that the cropping feature is enabled using the `SetCropEnable` method.

#### Parameters

- `x`: The X-coordinate to scroll to.
- `y`: The Y-coordinate to scroll to.
- `z`: The zoom level to set.
- `sx`: The horizontal scale factor for cropping.
- `sy`: The vertical scale factor for cropping.
- `sl`: The left origin point for cropping.
- `st`: The top origin point for cropping.

```csharp
edgeControl.SetCropEnable(true);
edgeControl.Crop(100, 200, 1.5, 1.2, 1.2, 0, 0);
```

### GoBack() and GoForward()
Used for navigating back and forward in the browser history.

```csharp
edgeControl.GoBack(); // Go back
edgeControl.GoForward(); // Go forward
```

### SetNewWindowEnable(bool isEnable)
Enables or disables opening new windows(pop-ups).

```csharp
edgeControl.SetNewWindowEnable(true); // Enable new windows
edgeControl.SetNewWindowEnable(false); // Disable new windows
```



### License
[MIT](https://choosealicense.com/licenses/mit/)