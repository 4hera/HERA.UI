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
using System.Windows.Shapes;

namespace HERA.UI.PDF
{
    /// <summary>
    /// TestWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class TestWindow : Window
    {


        public event EventHandler<PDFState> OnEvent = delegate { };
        public TestWindow()
        {
            InitializeComponent();
        }

        private void GoPreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GoPreviousPage",
                }); ;
            }
        }

        private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GoNextPage",
                }); ;
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "OpenFile",
                    Path = PathTextBox.Text
                }); ; ;
            }
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ZoomLabel.Content = ZoomSlider.Value;
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Zoom",
                    Zoom = ZoomSlider.Value
                }) ; 
            }
        }

        private void ZoomToWidth_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "ZoomToWidth",
                }); ;
            }
        }

        private void ZoomToHeight_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "ZoomToHeight",
                }); ;
            }
        }

        private void SetFixedZoom_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "SetFixedZoom",
                }); ;
            }
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "GoToPage",
                    PageNumber = int.Parse(PageNumberTextBox.Text)
                }); ;
            }
        }

        private void PageDisplayComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)PageDisplayComboBox.SelectedItem;

            if (selectedItem != null)
            {
                string selectedValue = selectedItem.Content.ToString();

                if (selectedValue == "Continuous Page Rows")
                {
                    if(OnEvent is not null)
                    {
                        OnEvent(this, new()
                        {
                            State = "SetPageRowDisplay",
                            DisplayType = System.Data.MoonPdf.Wpf.PageRowDisplayType.ContinuousPageRows
                        }); ;
                    }
                    
                }
                else if (selectedValue == "Single Page Row")
                {
                    if (OnEvent is not null)
                    {
                        OnEvent(this, new()
                        {
                            State = "SetPageRowDisplay",
                            DisplayType = System.Data.MoonPdf.Wpf.PageRowDisplayType.SinglePageRow
                        }); ;
                    }
                }
            }
        }

        private void ViewTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)ViewTypeComboBox.SelectedItem;

            if (selectedItem != null)
            {
                string selectedValue = selectedItem.Content.ToString();

                if (selectedValue == "Single Page")
                {
                    if (OnEvent is not null)
                    {
                        OnEvent(this, new()
                        {
                            State = "SetViewType",
                            ViewType = System.Data.MoonPdf.Wpf.ViewType.SinglePage
                        }); ;
                    }

                }
                else if (selectedValue == "Facing")
                {
                    if (OnEvent is not null)
                    {
                        OnEvent(this, new()
                        {
                            State = "SetViewType",
                            ViewType = System.Data.MoonPdf.Wpf.ViewType.Facing
                        }); ;
                    }
                }
                else if (selectedValue == "Book View")
                {
                    if (OnEvent is not null)
                    {
                        OnEvent(this, new()
                        {
                            State = "SetViewType",
                            ViewType = System.Data.MoonPdf.Wpf.ViewType.BookView
                        }); ;
                    }
                }
            }
        }
    }
}
