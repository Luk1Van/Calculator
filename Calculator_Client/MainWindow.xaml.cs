using System.Dynamic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        decimal number1;
        decimal number2;
        char action;
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7252/api/Calculator");
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Output.Text != "Error")
            {
                try
                {
                    Button num_button = (Button)sender;
                    Output.Text += num_button.Content.ToString();
                    var (value, error) = Converter_Decimal();
                    number1 = value.Value;

                }
                catch(Exception ex)
                {
                    Output.Text = "Error";
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Output.Text != "" && Output.Text != null && Output.Text != "Error")
            {
                try
                {
                    var (value, error) = Converter_Decimal();
                    number2 = value.Value;
                    action = '+';
                    Output.Text = "";
                }
                catch(Exception ex)
                {
                    Output.Text =  "Error";
                }
            }          
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if(Output.Text != "" && Output.Text != null && Output.Text != "Error")
            {
                try
                {
                    var (value, error) = Converter_Decimal();
                    number2 = value.Value;
                    action = '-';
                    Output.Text = "";
                }
                catch(Exception ex)
                {
                    Output.Text = "Error";
                }
            }
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            if (Output.Text != "" && Output.Text != null && Output.Text != "Error")
            {
                try
                {
                    var (value, error) = Converter_Decimal();
                    number2 = value.Value;
                    action = '/';
                    Output.Text = "";
                }
                catch (Exception ex)
                {
                    Output.Text = "Error";
                }
            }  
        }

        private void multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (Output.Text != "" && Output.Text != null && Output.Text != "Error")
            {
                try
                {
                    var (value, error) = Converter_Decimal();
                    number2 = value.Value;
                    action = '*';
                    Output.Text = "";
                }
                catch(Exception ex)
                {
                    Output.Text = "Error";
                }
            }
        }

        private async void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (Output.Text != "" && Output.Text != null && Output.Text!= "Error")
            {
                //client.BaseAddress = new Uri("https://localhost:7252/api/Calculator");
                var (value, error) = Converter_Decimal();
                number1 = value.Value;

                switch (action)
                {
                    case '/':
                        if (number1 != 0)
                        {
                            Output.Text = await Api_caller("/Division");
                        }
                        else
                        {
                            Output.Text = "Error";
                        }
                        break;
                    case '*':
                        if (number1 != 0)
                        {
                            Output.Text = await Api_caller("/Multiplication");
                        }
                        else
                        {
                            Output.Text = "Error";
                        }
                        break;
                    case '+':
                        if (number1 != 0)
                        {
                            Output.Text = await Api_caller("/Addition");
                        }
                        else
                        {
                            Output.Text = "Error";
                        }
                        break;
                    case '-':
                        if (number1 != 0)
                        {
                            Output.Text = await Api_caller("/Substraction");
                        }
                        else
                        {
                            Output.Text = "Error";
                        }
                        break;
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = "";
        }

        private void Decimal_value(object sender, RoutedEventArgs e)
        {
            if(!Output.Text.Contains(".") && Output.Text!= "Error")
            {
                Output.Text += ".";
            }
        }

        private(decimal? value, string error) Converter_Decimal()
        {
            try
            {
                decimal number = decimal.Parse(Output.Text, System.Globalization.CultureInfo.InvariantCulture);
                return (number, null); 
            }
            catch (FormatException ex) 
            {
                return (null, "Invalid input");
            }
        }

        private async Task<string> Api_caller(string uri)
        {
            var numbers = new { Number1 = number1, Number2 = number2 };
            var json = JsonSerializer.Serialize(numbers);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(client.BaseAddress + uri, content);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
                
            }
            else
            {
                return  "Error";
            }
        }
     
    }
}