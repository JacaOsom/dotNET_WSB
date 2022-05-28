using System.Windows;
using System.Windows.Controls;

namespace Calculator_dotNET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            displayResult.Text = string.Empty;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            var currentNumber = button.Name[1];

            displayResult.Text += currentNumber;
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            var compute = displayResult.Text;
            
            if (operationCheck(compute))
            {
                displayResult.Text = Calculate(compute).ToString();
            }

            displayResult.Text += "/";
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            var compute = displayResult.Text;
           
            if (operationCheck(compute))
            {
                displayResult.Text = Calculate(compute).ToString();
            }
            displayResult.Text += "*";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var compute = displayResult.Text;
           
            if (operationCheck(compute))
            {
                displayResult.Text = Calculate(compute).ToString();
            }
            displayResult.Text += "+";
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            var compute = displayResult.Text;
            
            if (operationCheck(compute))
            {

                displayResult.Text = Calculate(compute).ToString();
            }
            displayResult.Text += "-";
        }
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            var compute = displayResult.Text;

            displayResult.Text = Calculate(compute).ToString();


        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            displayResult.Text = string.Empty;
        }

        private bool operationCheck(string operation)
        {
            return operation.Contains('+') || operation.Contains('-') || operation.Contains('*') || operation.Contains('/');

        }

        public double Calculate(string compute)
        {

            if (compute.Contains('+'))
            {
                var elements = compute.Split('+');

                return double.Parse(elements[0]) + double.Parse(elements[1]);
            }
            if (compute.Contains('-'))
            {
                if (compute.StartsWith('-'))
                {
                    var elementsSub = compute.Substring(1);

                    if (elementsSub.Contains('+'))
                    {
                        var elements = elementsSub.Split('+');
                        return (-double.Parse(elements[0]) + double.Parse(elements[1]));
                    }
                    if (elementsSub.Contains('-'))
                    {
                        var elements = elementsSub.Split('-');
                        return (-double.Parse(elements[0]) - double.Parse(elements[1]));
                    }
                    if (elementsSub.Contains('*'))
                    {
                        var elements = elementsSub.Split('*');
                        return (-double.Parse(elements[0]) * double.Parse(elements[1]));
                    }
                    if (elementsSub.Contains('/'))
                    {
                        var elements = elementsSub.Split('/');
                        return (-double.Parse(elements[0]) / double.Parse(elements[1]));
                    }
                    double result = double.Parse(displayResult.Text);
                    return result;
                }
                else
                {
                    var elements = compute.Split('-');

                    return double.Parse(elements[0]) - double.Parse(elements[1]);
                }

            }
            if (compute.Contains('*'))
            {
                var elements = compute.Split('*');

                return double.Parse(elements[0]) * double.Parse(elements[1]);
            }
            if (compute.Contains('/'))
            {
                var elements = compute.Split('/');

                return double.Parse(elements[0]) / double.Parse(elements[1]);
            }
            return 0;
        }

    }
}
