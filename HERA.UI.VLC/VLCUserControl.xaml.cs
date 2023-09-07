using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibVLCSharp.Shared;
namespace HERA.UI.VLC
{
    /// <summary>
    /// Interaction logic for VLCUserControl.xaml
    /// </summary>
    public partial class VLCUserControl : UserControl
    {
        private LibVLC _libVLC;
        MediaPlayer _mediaPlayer;
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

        public void vlcPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("vlc loaded");
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            vlcPlayer.MediaPlayer = _mediaPlayer;
            var media = new Media(_libVLC, new Uri("C:\\Users\\AliEmirErcan\\Desktop\\VideoTest\\BasketballVoice.mp4"));
            _mediaPlayer.Play(media);
            //m _mediaPlayer.TakeSnapshot
            SetAspectRatio((int)ActualWidth, (int)ActualHeight);
            
        }

        public void Play()
        {
            if(_mediaPlayer is not null)
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
            if(_mediaPlayer is not null)
            {
                _mediaPlayer.Mute = !_mediaPlayer.Mute;
            }
        }

        public bool isMuted()
        {
            if(_mediaPlayer is not null)
            {
                return _mediaPlayer.Mute;
            }

            return true;
        }


        public void SetAspectRatio(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            if (_mediaPlayer != null)
            {
                _mediaPlayer.AspectRatio = width + ":" + height;
            }
        }
    }
}
