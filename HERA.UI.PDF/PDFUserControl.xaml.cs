using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HERA.UI.PDF
{
    /// <summary>
    /// PDFUserControl.xaml etkileşim mantığı
    /// </summary>
    public partial class PDFUserControl : UserControl
    {
        public event EventHandler<int> PageChanged;
        public int CurrentPageNumber = 1;
        public int TotalPage;
        public PDFUserControl()
        {
            InitializeComponent();
            Loaded += PdfWindow_Loaded;
            moonPdfPanel.SizeChanged += MoonPdfPanel_SizeChanged;
            moonPdfPanel.PdfLoaded += MoonPdfPanel_PdfLoaded;
            
        }

       

        public void InitializePdf()
        {
            Console.WriteLine($"TotalPages: {moonPdfPanel.TotalPages}");
            Console.WriteLine($"GetCurrentPageNumber: {moonPdfPanel.GetCurrentPageNumber()}");
            moonPdfPanel.ZoomToWidth();
            TotalPage = moonPdfPanel.TotalPages;
        }
        private void MoonPdfPanel_PageRowDisplayChanged(object? sender, EventArgs e)
        {
            Console.WriteLine($"GetCurrentPageNumber: {moonPdfPanel.GetCurrentPageNumber()}");
        }

        private void MoonPdfPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            moonPdfPanel.ZoomToWidth();
        }

        private void MoonPdfPanel_PdfLoaded(object? sender, EventArgs e)
        {
           InitializePdf();
        }

        private void PdfWindow_Loaded(object sender, RoutedEventArgs e)
        {
            moonPdfPanel.OpenFile(@"C:\Users\90543\Downloads\yokAcikBilim_10288855.pdf");
        }

        public void OpenFile(string path)
        {
            try
            {
                moonPdfPanel.OpenFile(path);
                InitializePdf();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void GoNextPage()
        {
            moonPdfPanel.GotoNextPage();
        }
        public void GoPreviousPage()
        {
            moonPdfPanel.GotoPreviousPage();
        }

        public void GoToPage(int pageNumber)
        {
            moonPdfPanel.GotoPage(pageNumber);
            int PageNumber = moonPdfPanel.GetCurrentPageNumber();
            CurrentPageNumber = PageNumber;
            OnPageChanged(pageNumber);
        }

        public int GetCurrentPage()
        {
            return moonPdfPanel.GetCurrentPageNumber();
        }

        public int GetTotalPage()
        {
            return moonPdfPanel.TotalPages;
        }

        public void Zoom(double zoom)
        {
            Math.Clamp(zoom, 0, 6);
            moonPdfPanel.Zoom(zoom);
        }
        public void ZoomToWidth()
        {   
            moonPdfPanel.ZoomToWidth();
        }
        public void ZoomToHeight()
        {
            moonPdfPanel.ZoomToHeight();
        }
        public void SetFixedZoom()
        {
            moonPdfPanel.SetFixedZoom();
            int data = moonPdfPanel.GetCurrentPageNumber();
            Console.WriteLine(data);
            Console.WriteLine(moonPdfPanel.TotalPages);
        }

        public void SetPageRowDisplay(System.Data.MoonPdf.Wpf.PageRowDisplayType pageRowDisplayType)
        {
            moonPdfPanel.PageRowDisplay = pageRowDisplayType;
        }

        public void SetViewType(System.Data.MoonPdf.Wpf.ViewType viewType)
        {
            moonPdfPanel.ViewType = viewType;
        }

        private void moonPdfPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            int pageNumber = moonPdfPanel.GetCurrentPageNumber();
            if(pageNumber != CurrentPageNumber)
            {
                CurrentPageNumber = pageNumber;
                OnPageChanged(pageNumber);
            }
            
        }

        private void moonPdfPanel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            int pageNumber = moonPdfPanel.GetCurrentPageNumber();
            if (pageNumber != CurrentPageNumber)
            {
                CurrentPageNumber = pageNumber;
                OnPageChanged(pageNumber);
            }
        }

        public virtual void OnPageChanged(int pageNumber)
        {
            PageChanged?.Invoke(this, pageNumber);
        }
    }
}
