using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using LibVLCSharp.Shared;
using LibVLCSharp.Shared.Structures;

namespace HERA.UI.VLC
{
    /// <summary>
    /// Interaction logic for VLCUserControl.xaml
    /// </summary>
    public partial class VLCUserControl : UserControl
    {
        private LibVLC _libVLC;
        LibVLCSharp.Shared.MediaPlayer _mediaPlayer;
        public Media media;
        private string _path;
        public List<string> parameters = new List<string>();
        public List<string> extraParameters = new List<string>();
        public string Crop;
        #region Video Options Property
        public bool VideoOptionsEnable = true;
        private float _Brightness = VLC_Constant.DEFAULT_BRIGHTNESS;
        private float _Contrast = VLC_Constant.DEFAULT_CONTRAST;
        private float _Hue = VLC_Constant.DEFAULT_HUE;
        private float _Saturation = VLC_Constant.DEFAULT_SATURATION;
        private float _Gamma = VLC_Constant.DEFAULT_GAMMA;
        public bool Loop = true;
        #endregion
        #region Marquee Property
        public bool MarqueeOptionsEnable = false;
        private String _MarqueeText;
        private Color.ColorHex _Color = Color.ColorHex.White;
        private Position.TextPosition _MarqueePosition = Position.TextPosition.TopLeft;
        private int _MarqueeOpacity = VLC_Constant.DEFAULT_MARQUEE_OPACITY;
        private int _MarquurRefresh = 1;
        private int _MarqueeSize = VLC_Constant.DEFAULT_MARQUEE_SIZE;
        private int _MarqueeX = VLC_Constant.DEFAULT_MARQUEE_X;
        private int _MarqueeY = VLC_Constant.DEFAULT_MARQUEE_Y;
        #endregion
        #region Logo Property
        public bool LogoEnable = true;
        private string _LogoFilePath;
        private int _LogoX;
        private int _LogoY;
        private Position.LogoPosition _LogoPosition;
        private int _LogoOpacity = VLC_Constant.DEFAULT_LOGO_OPACITY;
        #endregion
        IEnumerable<AudioOutputDescription> audioOutputDescription = new List<AudioOutputDescription>();
        IEnumerable<AudioOutputDevice> audioOutputDevice = new List<AudioOutputDevice>();
        public string DeviceName;
        public string DeviceIdentifier;

        public VLCUserControl()
        {
            InitializeComponent();

            Unloaded += (s, e) =>
            {
                if (_mediaPlayer is not null)
                {
                    _mediaPlayer.Dispose();
                }
            };
        }

        public void vlcPlayerLoaded(object sender, RoutedEventArgs e)
        {
            SetPath("C:\\Users\\AliEmirErcan\\Desktop\\VideoTest\\Basketball.mp4");
            InitializeVLC();
            SetAspectRatio((int)ActualWidth, (int)ActualHeight);
        }

        private void InitializeParameters()
        {
            parameters.Clear();
            parameters.Add("--aout=any");
          
            if (Loop)
            {
                parameters.Add("--input-repeat=65535");
                //parameters.Add("--no-accel");
            }
            if (extraParameters.Count > 0)
            {
                foreach (var item in extraParameters)
                {
                    parameters.Add($"{item}");
                }
            }
        }
        private void InitializeVLC()
        {
            InitializeParameters();
            Core.Initialize();
            _libVLC = new LibVLC(parameters.ToArray());
            _mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            vlcPlayer.MediaPlayer = _mediaPlayer;
            media = new Media(_libVLC, new Uri(_path));
            _mediaPlayer.EnableHardwareDecoding = true;
            _libVLC.Log += _libVLC_Log;
            SetCropGeometry();
            SetVideoOptions();
            SetMarqueeOptions();
            SetLogoOptions();
            if (DeviceName != null && DeviceIdentifier != null)
            {
                _mediaPlayer.SetAudioOutput(DeviceName);
                _mediaPlayer.SetOutputDevice(DeviceIdentifier, DeviceName);
            }
            _mediaPlayer.Play(media);        
        }


        private void _libVLC_Log(object? sender, LogEventArgs e)
        {
            //Console.WriteLine($"Log: {e.FormattedLog}");
        }

        public void Play()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Play();
            }
        }

        public void Pause()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Pause();
                _mediaPlayer.TakeSnapshot(0, "C:\\Users\\AliEmirErcan\\Desktop\\VideoTest", 0, 0);
            }

           

        }

        public void Stop()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Stop();
            }
        }

        public void SetVolume(int volume)
        {
            if (volume < 0)
            {
                _mediaPlayer.Volume = 0;
            }
            if (volume > 200)
            {
                _mediaPlayer.Volume = 200;
            }
            _mediaPlayer.Volume = volume;
        }
        public void Mute()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Mute = !_mediaPlayer.Mute;
            }
        }

        public bool IsMuted()
        {
            if (_mediaPlayer is not null)
            {
                return _mediaPlayer.Mute;
            }

            return true;
        }

        public void SetPath(string path)
        {
            _path = path;
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.Dispose();
                InitializeVLC();
            }
        }

        public void SetAspectRatio(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.AspectRatio = width + ":" + height;
            }
        }

        public void SetCropGeometry()
        {
            if (_mediaPlayer is not null)
            {
                if (Crop is not null)
                {
                    _mediaPlayer.CropGeometry = Crop;
                }
                else
                {
                    _mediaPlayer.CropGeometry = String.Empty;
                }

            }
        }

        #region VideoOptions
        public void SetVideoOptions()
        {
            if (_mediaPlayer is not null)
            {
                if(VideoOptionsEnable)
                {
                    _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Enable, 1);
                }
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Brightness, _Brightness);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Contrast, _Contrast);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Hue, _Hue);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Saturation, _Saturation);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Gamma, _Gamma);
                
            //    _mediaPlayer.SetLogoInt(VideoLogoOption.Enable, 1);
            //    _mediaPlayer.SetLogoString(VideoLogoOption.File, @"C:\Users\AliEmirErcan\Downloads\instagram.png");
             //   _mediaPlayer.SetMarqueeString(VideoMarqueeOption.Enable, "Enable");

                // Şu an saat: %Date%
                //_mediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, $"Şu an saat: \"%Y-%m-%d,%H:%M:%S\"\nMerhaba");
                //_mediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, $"Şu an saat: \"%Y-%m-%d,%H:%M:%S\"\nMerscsahaba");


            }
        }

        public void SetBrightness(float brightness)
        {
            brightness = Math.Clamp(brightness, VLC_Constant.MIN_BRIGHTNESS, VLC_Constant.MAX_BRIGHTNESS);
            _Brightness = brightness;
            SetVideoOptions();
        }

        public float GetBrightness() { 
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Brightness);
        }

        public void SetContrast(float contrast)
        {
            contrast = Math.Clamp(contrast, VLC_Constant.MIN_CONTRAST, VLC_Constant.MAX_CONTRAST);
            _Contrast = contrast;
            SetVideoOptions();
        }
        public float GetContrast()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Contrast);
        }
        public void SetHue(float hue)
        {
            hue = Math.Clamp(hue, VLC_Constant.MIN_HUE, VLC_Constant.MAX_HUE);
            _Hue = hue;
            SetVideoOptions();
        }
        public float GetHue()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Hue);
        }

        public void SetSaturation(float saturation)
        {
            saturation = Math.Clamp(saturation, VLC_Constant.MIN_SATURATION, VLC_Constant.MAX_SATURATION);
            _Saturation = saturation;
            SetVideoOptions();
        }

        public float GetSaturation()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Saturation);
        }

        public void SetGamma(float gamma)
        {
            gamma = Math.Clamp(gamma, VLC_Constant.MIN_GAMMA, VLC_Constant.MAX_GAMMA);
            _Gamma = gamma;
            SetVideoOptions();
        }

        public float GetGamma()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Gamma);
        }
        #endregion

        #region MarqueeOptions

        public void SetMarqueeOptions()
        {
            if(_mediaPlayer is not null)
            {
                if (MarqueeOptionsEnable)
                {
                    _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Enable, 1);
                }
                else
                {
                    _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Enable, 0);
                }
                _mediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, _MarqueeText);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Position, ((int)_MarqueePosition));
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Color, (int)(uint)_Color);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Opacity, _MarqueeOpacity);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Refresh, _MarquurRefresh);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Size, _MarqueeSize);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.X, _MarqueeX);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Y, _MarqueeY);
            }
        }

        public void SetMarqueeText(string marqueeText)
        {
            _MarqueeText = marqueeText;
            SetMarqueeOptions();
        }

        public string GetMarqueeText()
        {
            return _MarqueeText;
        }
    
        public void SetMarqueeColor(Color.ColorHex color)
        {
            _Color = color; 
            SetMarqueeOptions();
        }

        public void SetMarqueePosition(Position.TextPosition position)
        {
            //position = (int)Math.Clamp(position, VLC_Constant.MIN_MARQUEE_POSITION, VLC_Constant.MAX_MARQUEE_POSITION);
            _MarqueePosition = position;    
            SetMarqueeOptions();
        }

        public int GetMarqueePosition()
        {
            return _mediaPlayer.MarqueeInt(VideoMarqueeOption.Position);
        }

        public void SetMarqueeOpacity(int opacity)
        {
            opacity = (int)Math.Clamp(opacity, VLC_Constant.MIN_MARQUEE_OPACITY, VLC_Constant.MAX_MARQUEE_OPACITY);
            _MarqueeOpacity = opacity;
            SetMarqueeOptions();
        }

        public int GetMarqueeOpacity()
        {
            return _mediaPlayer.MarqueeInt(VideoMarqueeOption.Opacity);
        }

        public void SetMarqueeRefresh(int refresh)
        {
            if (refresh <= 0)
            {
                refresh = 1;
            }
            _MarquurRefresh = refresh*1000;  
            SetMarqueeOptions() ;   
        }

        public int GetMarqueeRefresh()
        {
            return _mediaPlayer.MarqueeInt(VideoMarqueeOption.Refresh);
        }

        public void SetMarqueeSize(int size)
        {
            size = (int)Math.Clamp(size, VLC_Constant.MIN_MARQUEE_SIZE, VLC_Constant.MAX_MARQUEE_SIZE);
            _MarqueeSize = size;
            SetMarqueeOptions();
        }

        public int GetMarqueeSize()
        {
            return _mediaPlayer.MarqueeInt(VideoMarqueeOption.Size);
        }

        public void SetMarqueeX(int x)
        {
            _MarqueeX = x;
            SetMarqueeOptions();
        }

        public int GetMarqueeX()
        {
            return _mediaPlayer.MarqueeInt(VideoMarqueeOption.X);
        }

        public void SetMarqueeY(int y)
        {
            _MarqueeY = y;
            SetMarqueeOptions();
        }

        public int GetMarqueeY()
        {
            return _mediaPlayer.MarqueeInt(VideoMarqueeOption.Y);
        }
        #endregion

        #region LogoOptions
        public void SetLogoOptions()
        {
            if(_mediaPlayer is not null)
            {
                if (LogoEnable)
                {
                    _mediaPlayer.SetLogoInt(VideoLogoOption.Enable, 1);
                }
                else
                {
                    _mediaPlayer.SetLogoInt(VideoLogoOption.Enable, 0);
                }
                _mediaPlayer.SetLogoString(VideoLogoOption.File, _LogoFilePath);
                _mediaPlayer.SetLogoInt(VideoLogoOption.Opacity, _LogoOpacity);
               //_mediaPlayer.SetLogoInt(VideoLogoOption.Position, ((int)_LogoPosition));
                _mediaPlayer.SetLogoInt(VideoLogoOption.X, _LogoX);
                _mediaPlayer.SetLogoInt(VideoLogoOption.Y, _LogoY);
            }
        }

        public void SetLogoFile(string filepath)
        {
            _LogoFilePath = filepath;
            SetLogoOptions();
        }

        public string GetLogoFilePath() { 
            return _LogoFilePath;
        }

        public void SetLogoX(int x)
        {
            Console.WriteLine(x);
            _LogoX = x; 
            SetLogoOptions();
        }

        public int GetLogoX()
        {
            return _mediaPlayer.LogoInt(VideoLogoOption.X);
        }

        public void SetLogoY(int y)
        {
            _LogoY = y;
            SetLogoOptions();
        }

        public int GetLogoY()
        {
            return _mediaPlayer.LogoInt(VideoLogoOption.Y);
        }

        public void SetLogoPosition(Position.LogoPosition position)
        {
            _LogoPosition = position;
            SetLogoOptions();
        }

        public void SetLogoOpacity(int opacity)
        {
            opacity = (int)Math.Clamp(opacity, VLC_Constant.MIN_LOGO_OPACITY, VLC_Constant.MAX_LOGO_OPACITY);
            _LogoOpacity = opacity;
            SetLogoOptions();
        }

        public int GetLogoOpacity()
        {
            
            return _mediaPlayer.LogoInt(VideoLogoOption.Opacity);
        }

        #endregion

        public void GetAudioOutputs(ref IEnumerable<AudioOutputDescription> audioOutputDescription)
        {
            LibVLC libvlc = new LibVLC();
            audioOutputDescription = libvlc.AudioOutputs;
            libvlc.Dispose();
        }

        public void GetAudioDevices(ref IEnumerable<AudioOutputDevice> audioOutputDevices, string name)
        {
            LibVLC libvlc = new LibVLC();
            audioOutputDevices = libvlc.AudioOutputDevices(name);
            libvlc.Dispose();
        }

        public void SetAudioDevice(string deviceName, string deviceIdentifier)
        {
            Console.WriteLine("setaudio");
            Console.WriteLine(deviceName);
            Console.WriteLine( deviceIdentifier);
            DeviceName = deviceName;
            DeviceIdentifier = deviceIdentifier;
            if (_mediaPlayer != null) 
            {
                _mediaPlayer.Dispose();
                InitializeVLC();
            }
            
        }


    }



}
