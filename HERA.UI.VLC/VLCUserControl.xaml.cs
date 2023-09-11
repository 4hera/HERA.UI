using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Windows;
using System.Windows.Controls;
using LibVLCSharp.Shared;
namespace HERA.UI.VLC
{
    /// <summary>
    /// Interaction logic for VLCUserControl.xaml
    /// </summary>
    public partial class VLCUserControl : UserControl
    {
        private LibVLC _libVLC;
        LibVLCSharp.Shared.MediaPlayer _mediaPlayer;
        private string _path;
        public List<string> parameters = new List<string>();
        public List<string> extraParameters = new List<string>();
        public string Crop;
        private float _Brightness = VLC_Constant.DEFAULT_BRIGHTNESS;
        private float _Contrast = VLC_Constant.DEFAULT_CONTRAST;
        private float _Hue = VLC_Constant.DEFAULT_HUE;
        private float _Saturation = VLC_Constant.DEFAULT_SATURATION;
        private float _Gamma = 0.01f;
        public bool Loop = true;
        public Media media;
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
            //m _mediaPlayer.TakeSnapshot
            SetAspectRatio((int)ActualWidth, (int)ActualHeight);

        }

        private void InitializeParameters()
        {
            parameters.Clear();
            parameters.Add("--aout=directsound");
            if (Loop)
            {
                parameters.Add("--input-repeat=65535");
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
            SetOptions();
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
            SetBrightness(0.5f);
        }

        public bool isMuted()
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

        public void SetOptions()
        {
            if (_mediaPlayer is not null)
            {
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Enable, 1);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Brightness, _Brightness);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Contrast, _Contrast);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Hue, _Hue);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Saturation, _Saturation);
                _mediaPlayer.SetAdjustFloat(VideoAdjustOption.Gamma, _Gamma);
                
            //    _mediaPlayer.SetLogoInt(VideoLogoOption.Enable, 1);
            //    _mediaPlayer.SetLogoString(VideoLogoOption.File, @"C:\Users\AliEmirErcan\Downloads\instagram.png");
             //   _mediaPlayer.SetMarqueeString(VideoMarqueeOption.Enable, "Enable");
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Enable, 1);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Position, 5);
                _mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Color, 0x800000);
                // Şu an saat: %Date%
                _mediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, $"Şu an saat: \"%Y-%m-%d,%H:%M:%S\"\nMerhaba");
                /*
                wscTask = new WSCTask(() =>, 1000);
                wscTask.Start();
                */

            }
        }

        public void SetBrightness(float brightness)
        {
            brightness = Math.Clamp(brightness, VLC_Constant.MIN_BRIGHTNESS, VLC_Constant.MAX_BRIGHTNESS);
            _Brightness = brightness;
            SetOptions();
        }

        public float GetBrightness() { 
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Brightness);
        }

        public void SetContrast(float contrast)
        {
            contrast = Math.Clamp(contrast, VLC_Constant.MIN_CONTRAST, VLC_Constant.MAX_CONTRAST);
            _Contrast = contrast;
            SetOptions();
        }
        public float GetContrast()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Contrast);
        }
        public void SetHue(float hue)
        {
            hue = Math.Clamp(hue, VLC_Constant.MIN_HUE, VLC_Constant.MAX_HUE);
            _Hue = hue;
            SetOptions();
        }
        public float GetHue()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Hue);
        }

        public void SetSaturation(float saturation)
        {
            saturation = Math.Clamp(saturation, VLC_Constant.MIN_SATURATION, VLC_Constant.MAX_SATURATION);
            _Saturation = saturation;
            SetOptions();
        }

        public float GetSaturation()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Saturation);
        }

        public void SetGamma(float gamma)
        {
            gamma = Math.Clamp(gamma, VLC_Constant.MIN_GAMMA, VLC_Constant.MAX_GAMMA);
            _Gamma = gamma;
            SetOptions();
        }

        public float GetGamma()
        {
            return _mediaPlayer.AdjustFloat(VideoAdjustOption.Gamma);
        }


    }
}
