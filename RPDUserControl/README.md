# RDPUserControl Usage Guide

The `RDPUserControl` is a custom user control for integrating Remote Desktop Protocol (RDP) functionality into your application. This guide provides an overview of the functions and properties available when using this control.


- [Initial Setup](#initial-setup)
- [Usage](#usage)
  - [Create an Instance](#create-an-instance)
  - [Basic Functions](#basic-functions)
    - [Connect](#connectstring-server-string-username-string-password)
    - [SetPort](#setportint-port)
    - [Disconnect](#disconnect)
    - [GetStatus](#getstatus)
    - [SetAuthenticationLevel](#setauthenticationleveluint-level)
    - [SetColorDepth](#setcolordepthint-colordepth)
    - [SetRedirectPrinters](#setredirectprintersbool-redirectprinters)
    - [SetRedirectSmartCards](#setredirectsmartcardsbool-redirectsmartcards)
    - [SetEnableCredSspSupport](#setenablecredsspsupportbool-enablecredsspsupport)
    - [SetRedirectDrives](#setredirectdrivesbool-redirectdrives)
    - [SetDesktopWidth](#setdesktopwidthint-width)
    - [SetDesktopHeight](#setdesktopheightint-height)
  - [Events](#events)
- [License](#license)

## Initial Setup

Before using the `RDPUserControl` class, make sure you have the necessary references and configurations in your project. Additionally, include the required `using` directives:


```csharp
using AxMSTSCLib;
using MSTSCLib;
```

# Usage

To use the control, create an instance of the `RDPUserControl`: 


```csharp
// Create an instance of the RDPUserControl
RDPUserControl rdpControl = new RDPUserControl();

// Create a Windows Forms Host control
WindowsFormsHost host = new WindowsFormsHost();

// Add the RDPUserControl as a child of the Windows Forms Host
host.Child = rdpControl;
```

## Basic Functions


### Connect(string Server, String UserName, String Password)

Establishes an RDP connection to the specified server with the provided credentials.



```csharp
rdpControl.Connect("000.000.0.000", "username", "password");
```

### SetPort(int port)
Sets the RDP port to be used for the connection.



```csharp
rdpControl.SetPort(3389); // Default RDP port
```

### Disconnect()
Closes the RDP connection.


```csharp
rdpControl.Disconnect();
```

### GetStatus()
Returns the current status of the RDP connection.

```csharp
RDPUserControl.Status status = rdpControl.GetStatus();
/*{
    Default,
    Connected,
    Connecting,
    Disconnected,
    Warning,
    Error
}*/
```

### SetAuthenticationLevel(uint level)
Sets the authentication level for the RDP connection.

```csharp
rdpControl.SetAuthenticationLevel(0); // 0,1,2
```

### SetColorDepth(int colorDepth)
Sets the color depth for the RDP session.


```csharp
rdpControl.SetColorDepth(24); // 8,15,16,24
```

### SetRedirectPrinters(bool redirectPrinters)
Configures whether to redirect printers to the RDP session.

```csharp
rdpControl.SetRedirectPrinters(true); // Enable printer redirection
```

### SetRedirectSmartCards(bool redirectSmartCards)
Configures whether to redirect smart cards to the RDP session.
 
```csharp
rdpControl.SetRedirectSmartCards(true); // Enable smart card redirection
```

### SetEnableCredSspSupport(bool enableCredSspSupport)
Enables or disables Credential Security Support Provider (CredSSP) support.

```csharp
rdpControl.SetEnableCredSspSupport(true); // Enable CredSSP support
```

### SetRedirectDrives(bool redirectDrives)
Configures whether to redirect drives to the RDP session.

```csharp
rdpControl.SetRedirectDrives(true); // Enable drive redirection
```

### SetDesktopWidth(int width)
Sets the desktop width for the RDP session.

```csharp
rdpControl.SetDesktopWidth(1280); // Example desktop width
```

### SetDesktopHeight(int height)
Sets the desktop height for the RDP session.

```csharp
rdpControl.SetDesktopHeight(720); // Example desktop height
```

### Events

- `Connecting`: Triggered when the RDP connection is in progress.
- `Connected`: Triggered when the RDP connection is successfully established.
- `Disconnected`: Triggered when the RDP connection is disconnected. Provides a reason for disconnection.
- `Warning`: Triggered when a warning occurs during the RDP session.
- `FatalError`: Triggered when a fatal error occurs during the RDP session.
- `LogonError`: Triggered when a logon error occurs during the RDP session.
- `ConnectionError`: Triggered when a general connection error occurs.
- `DisconnectionError`: Triggered when a disconnection error occurs.
- `Error`:  Triggered when any other error occurs during the RDP session.

Example event subscription:
```csharp
rdpControl.Connected += (sender, e) =>
{
    // Handle the connected event
};
```

### License
[MIT](https://choosealicense.com/licenses/mit/)
