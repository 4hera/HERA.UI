using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.CHROME
{
    public class ChromeState
    {
        public string State { get; set; }
        public string Adress { get; set; }
        public double Zoom { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public bool HideScroll { get; set; }
        public bool CropEnable { get; set; }
        public CropParameter Crop { get; set; }
        public bool NewWindowEnable { get; set; }
    }

    public class CropParameter
    {
        public int x; public int y; public double z; public double sx; public double sy; public int sl; public int st;

        public CropParameter(int x, int y, double z, double sx, double sy, int sl, int st)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.sx = sx;
            this.sy = sy;
            this.sl = sl;
            this.st = st;
        }
    }
}
