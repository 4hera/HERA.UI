# ChromeUserControl Usage Guide

The `ChromeUserControl` represents a custom user control containing a Chromium-based web browser. When using this control, the following functions and properties are provided:

- [Initial Setup](#initial-setup)
- [Usage](#usage)
  - [Basic Functions](#basic-functions)
    - [SetAdress(string address)](#setaddressstring-adress)
    - [SetZoom(double zoom)](#setzoomdouble-zoom)
    - [GetZoom(double zoom)](#getzoomdouble-zoom)
    - [SetLocation(int x, int y)](#setlocationint-x-int-y)
    - [GetLocation(int x, int y)](#getlocationint-x-int-y)
    - [HideScroll(bool isHide)](#hidescrollbool-ishide)
    - [SetCropEnable(bool isEnable)](#setcropenablebool-isenable)
    - [Crop(int x, int y, double z, double sx, double sy, int sl, int st)](#cropint-x-int-y-double-z-double-sx-double-sy-int-sl-int-st)
    - [GoBack() and GoForward()](#goback-and-goforward)
    - [SetNewWindowEnable(bool isEnable)](#setnewwindowenablebool-isenable)
- [License](#license)


# Initial Setup

Before using the `ChromeUserControl` class, make sure that the `CefSharp` library is installed, and Chromium browser settings are configured.

```csharp
using CefSharp;
using CefSharp.Wpf;
```

# Usage

To initialize the control, create an instance of the ChromeUserControl:

```csharp
ChromeUserControl chromeControl = new ChromeUserControl();
```
## Basic Functions

### SetAdress(string adress)
Used to navigate to the specified URL.

```csharp
chromeControl.SetAdress("https://example.com");
```

### SetZoom(double zoom)
Sets the browser zoom level.

```csharp
chromeControl.SetZoom(1.5); // Zoom in by 1.5x
```


### GetZoom()
Retrieves the current zoom level.

```csharp
double currentZoom = chromeControl.GetZoom();
```

### SetLocation(int x, int y)
Used to scroll to specific coordinates on the page.


```csharp
chromeControl.SetLocation(100, 200);
```

### GetLocation()
Retrieves the current page scroll position.

```csharp
Point location = chromeControl.GetLocation();
```

### HideScroll(bool isHide)
Used to hide or show page scrollbars.

```csharp
chromeControl.HideScroll(true); // Hide scrollbars
chromeControl.HideScroll(false); // Show scrollbars
```

### SetCropEnable(bool isEnable)
Enables or disables the page cropping feature.

```csharp
chromeControl.SetCropEnable(true); // Enable cropping
chromeControl.SetCropEnable(false); // Disable cropping
```
### Crop(int x, int y, double z, double sx, double sy, int sl, int st)

The `Crop` method in the `ChromeUserControl` class is used to perform page cropping with specified parameters. It allows you to control the zoom level, scaling, and origin point for cropping a web page. Before using this method, ensure that the cropping feature is enabled using the `SetCropEnable` method.

#### Parameters

- `x`: The X-coordinate to scroll to.
- `y`: The Y-coordinate to scroll to.
- `z`: The zoom level to set.
- `sx`: The horizontal scale factor for cropping.
- `sy`: The vertical scale factor for cropping.
- `sl`: The left origin point for cropping.
- `st`: The top origin point for cropping.

```csharp
chromeControl.SetCropEnable(true);
chromeControl.Crop(100, 200, 1.5, 1.2, 1.2, 0, 0);
```

### GoBack() and GoForward()
Used for navigating back and forward in the browser history.

```csharp
chromeControl.GoBack(); // Go back
chromeControl.GoForward(); // Go forward
```

### SetNewWindowEnable(bool isEnable)
Enables or disables opening new windows(pop-ups).

```csharp
chromeControl.SetNewWindowEnable(true); // Enable new windows
chromeControl.SetNewWindowEnable(false); // Disable new windows
```



### License
[MIT](https://choosealicense.com/licenses/mit/)
