# VLCUserControl Usage Guide

The VLCUserControl is a custom user control for playing video using the LibVLCSharp library. This guide provides an overview of the functions and properties available when using this control.

- [Initial Setup](#initial-setup)
- [Usage](#usage)
  - [Basic Functions](#basic-functions)
    - [`SetPath(string path)`](#setpathstring-path)
    - [`Play()`](#play)
    - [`Pause()`](#pause)
    - [`Stop()`](#stop)
    - [`SetVolume(int volume)`](#setvolumeint-volume)
    - [`Mute()`](#mute)
    - [`IsMuted()`](#Ismuted)
  - [Video Options](#video-options)
    - [`SetBrightness(float brightness)`](#setbrightnessfloat-brightness)
    - [`GetBrightness()`](#getbrightness)
    - [`SetContrast(float contrast)`](#setcontrastfloat-contrast)
    - [`GetContrast()`](#getcontrast)
    - [`SetHue(float hue)`](#sethuefloat-hue)
    - [`GetHue()`](#gethue)
    - [`SetSaturation(float saturation)`](#setsaturationfloat-saturation)
    - [`GetSaturation()`](#getsaturation)
    - [`SetGamma(float gamma)`](#setgammafloat-gamma)
    - [`GetGamma()`](#getgamma)
  - [Marquee Options](#marquee-options)
    - [`SetMarqueeText(string marqueeText)`](#setmarqueetextstring-marqueetext)
    - [`GetMarqueeText()`](#getmarqueetext)
    - [`SetMarqueeColor(Color.ColorHex color)`](#setmarqueecolorcolorcolorhex-color)
    - [`SetMarqueePosition(Position.TextPosition position)`](#setmarqueepositionpositiontextposition-position)
    - [`GetMarqueePosition()`](#getmarqueeposition)
    - [`SetMarqueeOpacity(int opacity)`](#setmarqueeopacityint-opacity)
    - [`GetMarqueeOpacity()`](#getmarqueeopacity)
    - [`SetMarqueeRefresh(int refresh)`](#setmarqueerefreshint-refresh)
    - [`GetMarqueeRefresh()`](#getmarqueerefresh)
    - [`SetMarqueeSize(int size)`](#setmarqueesizeint-size)
    - [`GetMarqueeSize()`](#getmarqueesize)
    - [`SetMarqueeX(int x)`](#setmarqueexint-x)
    - [`GetMarqueeX()`](#getmarqueex)
    - [`SetMarqueeY(int y)`](#setmarqueeyint-y)
    - [`GetMarqueeY()`](#getmarqueey)
  - [Logo Options](#logo-options)
    - [`SetLogoFile(string filepath)`](#setlogofilestring-filepath)
    - [`GetLogoFilePath()`](#getlogofilepath)
    - [`SetLogoX(int x)`](#setlogoxint-x)
    - [`GetLogoX()`](#getlogox)
    - [`SetLogoY(int y)`](#setlogoyint-y)
    - [`GetLogoY()`](#getlogoy)
    - [`SetLogoPosition(Position.LogoPosition position)`](#setlogopositionpositionlogoposition-position)
    - [`SetLogoOpacity(int opacity)`](#setlogoopacityint-opacity)
    - [`GetLogoOpacity()`](#getlogoopacity)
  - [Audio Options](#audio-options)
    - [`GetAudioOutputs(ref IEnumerable<AudioOutputDescription> audioOutputDescription)`](#getaudiooutputsref-ienumerableaudiooutputdescription-audiooutputdescription)
    - [`GetAudioDevices(ref IEnumerable<AudioOutputDevice> audioOutputDevices, string name)`](#getaudiodevicesref-ienumerableaudiooutputdevice-audiooutputdevices-string-name)
    - [`SetAudioDevice(string deviceName, string deviceIdentifier)`](#setaudiodevicestring-devicename-string-deviceidentifier)
- [License](#license)


## Initial Setup
Before using the VLCUserControl class, make sure that you have the LibVLCSharp library installed and configured properly in your project. Additionally, ensure that you have included the necessary using directives:

```csharp
using LibVLCSharp.Shared;
using LibVLCSharp.Shared.Structures;
```
# Usage

To initialize the control, create an instance of the `VLCUserControl`:
```csharp
VLCUserControl vlcControl = new VLCUserControl();
```
## Basic Functions

### SetPath(string path)
Sets the path to the video file that you want to play.
```csharp
vlcControl.SetPath("C:\\Users\\YourUser\\Videos\\sample.mp4");
```

### Play()
Starts playing the video.
```csharp
vlcControl.Play();
```
### Pause()
Pauses the currently playing video.

```csharp
vlcControl.Pause();
```

### Stop()
Stops the video playback.

```csharp
vlcControl.Stop();
```

### SetVolume(int volume)
Sets the volume level of the video. The volume parameter should be an integer value between 0 and 200.

```csharp
vlcControl.SetVolume(50); // Set volume to 50%
```

### Mute()
Toggles the mute state of the video.

```csharp
vlcControl.Mute();
```

### IsMuted()
Checks if the video is currently muted.

```csharp
bool muted = vlcControl.IsMuted();
```

## Video Options

### SetBrightness(float brightness)
Sets the brightness of the video. The brightness parameter should be a float value between 0.0 and 2.0.

```csharp
vlcControl.SetBrightness(1.5f);
```

### GetBrightness()
Gets the current brightness value of the video.

```csharp
float brightness = vlcControl.GetBrightness();
```
### SetContrast(float contrast)
Sets the contrast of the video. The contrast parameter should be a float value between 0.0 and 2.0.

```csharp
vlcControl.SetContrast(1.2f);
```
### GetContrast()
Gets the current contrast value of the video.

```csharp
float contrast = vlcControl.GetContrast();
```
### SetHue(float hue)
Sets the hue of the video. The hue parameter should be a float value between -180.0 and 180.0.

```csharp
vlcControl.SetHue(45.0f);
```
### GetHue()
Gets the current hue value of the video.

```csharp
float hue = vlcControl.GetHue();
```
### SetSaturation(float saturation)
Sets the saturation of the video. The saturation parameter should be a float value between 0.0 and 2.0.

```csharp
vlcControl.SetSaturation(1.2f);
```
###  GetSaturation()
Gets the current saturation value of the video.

```csharp
float saturation = vlcControl.GetSaturation();
```
### SetGamma(float gamma)
Sets the gamma of the video. The gamma parameter should be a float value between 0.0 and 2.0.

```csharp
vlcControl.SetGamma(1.5f);
```
### GetGamma()
Gets the current gamma value of the video.

```csharp
float gamma = vlcControl.GetGamma()
```

## Marquee Options

### SetMarqueeText(string marqueeText)
Sets the text for the marquee display on the video.

```csharp
vlcControl.SetMarqueeText("Now playing: Sample Video");
```

### GetMarqueeText()
Gets the current marquee text.

```csharp
string marqueeText = vlcControl.GetMarqueeText();
```
### SetMarqueeColor(Color.ColorHex color)
Sets the color of the marquee text. The color parameter should be a hexadecimal color code.

```csharp
vlcControl.SetMarqueeColor(Color.ColorHex.Red);
```
### SetMarqueePosition(Position.TextPosition position)
Sets the position of the marquee text on the video. The position parameter should be one of the available position values.

```csharp
vlcControl.SetMarqueePosition(Position.TextPosition.BottomRight);
```
### GetMarqueePosition()
Gets the current position of the marquee text.

```csharp
Position.TextPosition position = vlcControl.GetMarqueePosition();
```
### SetMarqueeOpacity(int opacity)
Sets the opacity of the marquee text. The opacity parameter should be an integer value between 0 and 255.

```csharp
vlcControl.SetMarqueeOpacity(200);
```
### GetMarqueeOpacity()
Gets the current opacity of the marquee text.

```csharp
int opacity = vlcControl.GetMarqueeOpacity();
```
### SetMarqueeRefresh(int refresh)
Sets the refresh rate of the marquee text, in milliseconds.

```csharp
vlcControl.SetMarqueeRefresh(1000); // Set refresh rate to 1 second
``` 
### GetMarqueeRefresh()
Gets the current refresh rate of the marquee text, in milliseconds.

```csharp
int refresh = vlcControl.GetMarqueeRefresh();
```
### SetMarqueeSize(int size)
Sets the font size of the marquee text.

```csharp
vlcControl.SetMarqueeSize(24);
```
### GetMarqueeSize()
Gets the current font size of the marquee text.

```csharp
int size = vlcControl.GetMarqueeSize();
```
### SetMarqueeX(int x)
Sets the X-coordinate position of the marquee text.

```csharp
vlcControl.SetMarqueeX(50);
```
### GetMarqueeX()
Gets the current X-coordinate position of the marquee text.

```csharp
int x = vlcControl.GetMarqueeX();
```

### SetMarqueeY(int y)
Sets the Y-coordinate position of the marquee text.

```csharp
vlcControl.SetMarqueeY(50);
```

### GetMarqueeY()
Gets the current Y-coordinate position of the marquee text.

```csharp
int y = vlcControl.GetMarqueeY();
```

## Logo Options


### SetLogoFile(string filepath)
Sets the file path for a logo to be displayed on the video.

```csharp
vlcControl.SetLogoFile("C:\\Users\\YourUser\\Images\\logo.png");
```
### GetLogoFilePath()
Gets the current file path for the logo.

```csharp
string logoFilePath = vlcControl.GetLogoFilePath();
```
### SetLogoX(int x)
Sets the X-coordinate position of the logo on the video.

```csharp
vlcControl.SetLogoX(20);
```
### GetLogoX()
Gets the current X-coordinate position of the logo on the video.

```csharp
int x = vlcControl.GetLogoX();
```
### SetLogoY(int y)
Sets the Y-coordinate position of the logo on the video.

```csharp
vlcControl.SetLogoY(20);
```
### GetLogoY()
Gets the current Y-coordinate position of the logo on the video.

```csharp
int y = vlcControl.GetLogoY();
```
### SetLogoPosition(Position.LogoPosition position)
Sets the position of the logo on the video. The position parameter should be one of the available logo position values.

```csharp
vlcControl.SetLogoPosition(Position.LogoPosition.TopRight);
```
### SetLogoOpacity(int opacity)
Sets the opacity of the logo on the video. The opacity parameter should be an integer value between 0 and 255.

```csharp
vlcControl.SetLogoOpacity(150);
```
### GetLogoOpacity()
Gets the current opacity of the logo on the video.

```csharp
int opacity = vlcControl.GetLogoOpacity();
```

## Audio Options 

### GetAudioOutputs(ref IEnumerable<AudioOutputDescription> audioOutputDescription)
Retrieves a list of available audio outputs and populates the audioOutputDescription parameter with the list.
```csharp
IEnumerable<AudioOutputDescription> outputDescriptions = null;
vlcControl.GetAudioOutputs(ref outputDescriptions);
```

### GetAudioDevices(ref IEnumerable<AudioOutputDevice> audioOutputDevices, string name)
Retrieves a list of audio devices for a specific audio output and populates the audioOutputDevices parameter with the list. Provide the audio output name as the name parameter.
```csharp
IEnumerable<AudioOutputDevice> outputDevices = null;
string outputName = "YourOutputName";
vlcControl.GetAudioDevices(ref outputDevices, outputName);
```

### SetAudioDevice(string deviceName, string deviceIdentifier)
Sets the audio output device for playback. Provide the deviceName and deviceIdentifier parameters to specify the audio device.
```csharp
string deviceName = "YourDeviceName";
string deviceIdentifier = "YourDeviceIdentifier";
vlcControl.SetAudioDevice(deviceName, deviceIdentifier);
```


### License
[MIT](https://choosealicense.com/licenses/mit/)