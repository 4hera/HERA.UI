using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HERA.UI.MAP
{
    /// <summary>
    /// Interaction logic for RedDotMarker.xaml
    /// </summary>
    public partial class RedDotMarker : UserControl
    {

        Popup Popup;
        Label Label;
        GMapMarker Marker;
        MainWindow MainWindow;
        public RedDotMarker()
        {
            InitializeComponent();

      

            Popup = new Popup();
            Label = new Label();
            Popup.Placement = PlacementMode.Mouse;
            {
                Label.Background = Brushes.Blue;
                Label.Foreground = Brushes.White;
                Label.BorderBrush = Brushes.WhiteSmoke;
                Label.BorderThickness = new Thickness(2);
                Label.Padding = new Thickness(5);
                Label.FontSize = 22;
         
            }
            Popup.Child = Label;
        }

       
    }
}
