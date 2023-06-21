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

namespace CALVULADORA23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;

                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsPoint(value))
                {
                    HandlePoint(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperator(value);
                }
                else if (value == "CE")
                {
                    Screen.Clear();
                }
                else if (value == "C")
                {
                    Screen.Clear();
                }
                else if (value == "=")
                {
                    HandleEquals(Screen.Text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        private bool IsNumber(string num)
        {
            return double.TryParse(num, out _);
        }

        private void HandleNumbers(string value)
        {
            if (string.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;
            }
        }
        private void HandleOperator(string value)
        {
            if (!string.IsNullOrEmpty(Screen.Text) && !ContaintOperators(Screen.Text))
            {
                Screen.Text += " " + value + " ";
            }
        }
        private bool IsPoint(string value)
        {
            return value == ".";
        }

        private void HandlePoint(string value)
        {
            if (!string.IsNullOrEmpty(Screen.Text) && ExistNumberBeforePoint(Screen.Text) && !DoublePoint(Screen.Text))
            {
                Screen.Text += value;
            }
        }

        private bool ExistNumberBeforePoint(string screenContent)
        {
            char ultimoCaracter = screenContent[screenContent.Length - 1];
            return Char.IsDigit(ultimoCaracter);
        }

        private bool DoublePoint(string screenContent)
        {
            char ultimoCaracter = screenContent[screenContent.Length - 1];
            return ultimoCaracter == '.';
        }

        public bool ContaintOperators(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-") || screenContent.Contains("*") || screenContent.Contains("/");
        }

        public void HandleEquals(string ScreenContent)
        {
            string op = FindOperator(ScreenContent);
            if (op != null)
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = Sum();
                        break;
                    case "-":
                        Screen.Text = Resta();
                        break;
                    case "*":
                        Screen.Text = Multiplicacion();
                        break;
                    case "/":
                        Screen.Text = Division();
                        break;
                }
            }
        }
        private string FindOperator(string ScreenContent)
        {
            foreach (var item in ScreenContent)
            {
                if (IsOperator(item.ToString()))
                {
                    return item.ToString();
                }
            }
            return ScreenContent;
        }
        private bool IsOperator(string posibleOperator)
        {
            if (posibleOperator == "+" || posibleOperator == "-" || posibleOperator == "*" || posibleOperator == "/")
            {
                return true;
            }
            return false;
        }

        //Operaciones
        private string Sum()
        {
            string[] numbers = Screen.Text.Split('+');

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString();
        }
        private string Resta()
        {
            string[] numbers = Screen.Text.Split('-');

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 - n2, 12).ToString();
        }
        private string Multiplicacion()
        {
            string[] numbers = Screen.Text.Split('*');

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Division()
        {
            string[] numbers = Screen.Text.Split('/');

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
        }

    }
}
    

