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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PDFUserControl;
namespace HERA.UI.PDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PDFUC pDFUserControl = new PDFUC();

        public MainWindow()
        {
            InitializeComponent();
            MyForm.Child = pDFUserControl;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            MyForm.Loaded += PDFUserControl_Load;
            

            
        }

        private void PDFUserControl_Load(object? sender, EventArgs e)
        {
            Console.WriteLine(1);
          //  pDFUserControl.SetSrc(@"C:\Users\AliEmirErcan\Desktop\abonelik_belgeleri.pdf");
        }
    }
}
