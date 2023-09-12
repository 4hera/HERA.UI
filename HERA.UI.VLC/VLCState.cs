using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.VLC
{
    public class VLCState
    {
        public string State { get; set; }
        public int Volume { get; set; }
        public float Value;
        public string Text {  get; set; }
        public string Path { get; set; }
        public bool MarqueEnable { get; set; }
        public Color.ColorHex Color { get; set; }   
        public Position.TextPosition TextPosition { get; set; }   

        public Position.LogoPosition LogoPosition { get; set; } 
    }
}
