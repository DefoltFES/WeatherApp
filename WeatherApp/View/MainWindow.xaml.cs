using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.ViewModel;

namespace WeatherApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                (DataContext as WeatherReportVM).GetWeatherForecast(TitleCityTextBox.Text.ToLower());
        }
    }
}