using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
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



namespace HERA.UI.VLC
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {

        public event EventHandler<VLCState> OnEvent = delegate { };
        public string MainFolderPath = "C:\\Users\\AliEmirErcan\\Desktop\\VideoTest";
        public TestWindow()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                ListFilesInFolder(MainFolderPath);
            };

            fileComboBox.SelectionChanged += fileComboBoxSelectionChanged;
        }


        private void PlayClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Play"
                });
            }
        }

        private void PauseClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Pause"
                });
            }
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Stop"
                });
            }
        }

        private void MuteClick(object sender, RoutedEventArgs e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Mute"
                });
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OnEvent is not null)
            {
                OnEvent(this, new()
                {
                    State = "Voice",
           
                    Volume = (int)e.NewValue
                });
            }
        } 



        private void fileComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFileName = fileComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedFileName))
            {
          
                string selectedFilePath = Path.Combine(MainFolderPath, selectedFileName);

                if (OnEvent is not null)
                {
                    OnEvent(this, new()
                    {
                        State = "Path",

                        Path = selectedFilePath
                    });
                }
            }
        }
        private void ListFilesInFolder(string folderPath)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath);

                // ComboBox'ı temizle
                fileComboBox.Items.Clear();

                // Dosyaları ComboBox'a ekle
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    fileComboBox.Items.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
