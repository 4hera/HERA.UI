using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.VLC
{
    public static class VLC_Constant
    {
        #region CONTRAST
        public static float MIN_CONTRAST = 0.0f;
        public static float MAX_CONTRAST = 2.0f;
        public static float DEFAULT_CONTRAST = 1.0f;
        #endregion

        #region BRIGHTNESS
        public static float MIN_BRIGHTNESS = 0.0f;
        public static float MAX_BRIGHTNESS = 2.0f;
        public static float DEFAULT_BRIGHTNESS = 1.0f;
        #endregion

        #region HUE
        public static float MIN_HUE = -180.0f;
        public static float MAX_HUE = 180.0f;
        public static float DEFAULT_HUE = 0.0f;
        #endregion

        #region SATURATION
        public static float MIN_SATURATION = 0.0f;
        public static float MAX_SATURATION = 2.0f;
        public static float DEFAULT_SATURATION = 1.0f;
        #endregion

        #region GAMMA
        public static float MIN_GAMMA = 0.0f;
        public static float MAX_GAMMA = 2.0f;
        public static float DEFAULT_GAMMA = 1.0f;
        #endregion

        #region MARQUEE_POSITION
        public static int MIN_MARQUEE_POSITION = 0;
        public static int MAX_MARQUEE_POSITION = 8;
        public static int DEFAULT_MARQUEE_POSITION = 5;
        #endregion

        #region MARQUEE_OPACITY
        public static int MIN_MARQUEE_OPACITY = 0;
        public static int MAX_MARQUEE_OPACITY = 255;
        public static int DEFAULT_MARQUEE_OPACITY = 255;
        #endregion

        #region MARQUEE_SIZE
        public static int MIN_MARQUEE_SIZE = 0;
        public static int MAX_MARQUEE_SIZE = 4096;
        public static int DEFAULT_MARQUEE_SIZE = 100;
        #endregion

        #region MARQUEE_POSITION
        public static int DEFAULT_MARQUEE_X = 0;
        public static int DEFAULT_MARQUEE_Y = 0;
        #endregion

        #region LOGO_OPACITY
        public static int MIN_LOGO_OPACITY = 0;
        public static int MAX_LOGO_OPACITY = 255;
        public static int DEFAULT_LOGO_OPACITY = 255;
        #endregion

    }
}
