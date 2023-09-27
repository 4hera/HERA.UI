
using System;
using System.Windows;
using System.Windows.Forms;

namespace HERA.UI.PDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        PDFUserControl pDFUserControl = new PDFUserControl();
        TestWindow testWindow = new TestWindow();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            testWindow.OnEvent += (pdfSender, pdfEvent) =>
            {
                switch (pdfEvent.State)
                {
                    case "OpenFile":
                        OpenFile(pdfEvent.Path);
                        break;
                    case "GoNextPage":
                        GoNextPage();
                        break;
                    case "GoPreviousPage":
                        GoPreviousPage();
                        break;
                    case "Zoom":
                        Zoom(pdfEvent.Zoom);
                        break;
                    case "ZoomToHeight":
                        ZoomToHeight();
                        break;
                    case "ZoomToWidth":
                        ZoomToWidth();
                        break;
                    case "SetFixedZoom":
                        SetFixedZoom();
                        break;
                    case "GoToPage":
                        GoToPage(pdfEvent.PageNumber);
                        break;
                    case "SetPageRowDisplay":
                        SetPageRowDisplay(pdfEvent.DisplayType);
                        break;
                    case "SetViewType":
                        SetViewType(pdfEvent.ViewType);
                        break;
                }
            };
            testWindow.Show();
            MainGrid.Children.Add(pDFUserControl);
            pDFUserControl.Loaded += (s, e) =>
            {
                pDFUserControl.ZoomToWidth();
            };
            pDFUserControl.PageChanged += (s, e) =>
            {
                Console.WriteLine($"{e}/{pDFUserControl.TotalPage}");
            };
        }

        private void OpenFile(string path)
        {
            pDFUserControl.OpenFile(path);
        }
        private void GoNextPage()
        {
            pDFUserControl.GoNextPage();
        }

        private void GoPreviousPage()
        {
            pDFUserControl.GoPreviousPage();
        }

        private void Zoom(double zoom)
        {
            pDFUserControl.Zoom(zoom);
        }

        private void ZoomToWidth()
        {
            pDFUserControl.ZoomToWidth();
        }

        private void ZoomToHeight()
        {
            pDFUserControl.ZoomToHeight();
        }

        private void SetFixedZoom()
        {
            pDFUserControl.SetFixedZoom();
        }

        private void GoToPage(int pageNumber)
        {
            pDFUserControl.GoToPage(pageNumber);
        }

        private void SetPageRowDisplay(System.Data.MoonPdf.Wpf.PageRowDisplayType displayType)
        {
            pDFUserControl.SetPageRowDisplay(displayType);
        }

        private void SetViewType(System.Data.MoonPdf.Wpf.ViewType viewType)
        {
            pDFUserControl.SetViewType(viewType);
        }
    }
}
