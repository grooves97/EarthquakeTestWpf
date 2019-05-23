using EarthquakeTestWpf.DTO;
using EarthquakeTestWpf.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EarthquakeTestWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task FillDataGridAsync(int count)
        {
            progressBar.Visibility = Visibility.Visible;
            progressBar.IsIndeterminate = true;
            progressTextBlock.Text = "Идет загрузка...";

            Downloader downloader = new Downloader();

            string json = await downloader.DownloadRawJsonDataAsync($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit={count}");

            featuresDataGrid.ItemsSource = JsonConvert.DeserializeObject<FeatureCollection>(json).Features;

            progressBar.Visibility = Visibility.Collapsed;
            progressBar.IsIndeterminate = false;
            progressTextBlock.Text = "Готово";
        }
        
        private async void GetDataKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!int.TryParse(featuresCountTextBox.Text, out int count))
                {
                    MessageBox.Show("Please, enter correct number!");
                    return;
                }

                await FillDataGridAsync(count);
            }
        }

        private async void GetDataButtonClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(featuresCountTextBox.Text, out int count))
            {
                await FillDataGridAsync(count);
            }
            else
            {
                MessageBox.Show("Please, enter correct number!");
            }
        }
    }
}