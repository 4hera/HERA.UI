using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERA.UI.PDF
{
    public class PDFState
    {
        public string State { get; set; }
        public string Path { get; set; }    
        public double Zoom { get; set; }

        public int PageNumber { get; set; }

        public System.Data.MoonPdf.Wpf.PageRowDisplayType DisplayType { get; set; }
        public System.Data.MoonPdf.Wpf.ViewType ViewType { get; set; }  
    }
}
