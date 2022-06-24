using DesktopWCFApp.ServiceReference1;
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

namespace DesktopWCFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            type_field.Text = String.Empty;
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            //do poprawnego działania aplikacji musi być włączona usługa z zadania WCFService
            var display = type_field.Text;
            SearchByLastNameServiceClient client = new SearchByLastNameServiceClient();

            var output = client.GetDataByLastName(display);

            display_field.Text = output;

            client.Close();
        }
    }
}
