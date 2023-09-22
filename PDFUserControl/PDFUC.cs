using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFUserControl
{
    public partial class PDFUC : UserControl
    {
        public PDFUC()
        {
            InitializeComponent();
           

        }
        public void SetSrc(string src)
        {
            try
            {
                Console.WriteLine("ok");
                pdf.LoadFile(src);
                pdf.src = src;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
          
        }
    }
}
