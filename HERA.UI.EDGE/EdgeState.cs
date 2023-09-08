using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.EDGE
{
    public class EdgeState
    {
        public string State { get; set; }
        public Uri Source { get; set; }
        public double Zoom { get; set; }
        public bool HideScroll { get; set; }
        public bool isEnable { get; set; }  
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public CropParameter Crop { get; set; }
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
