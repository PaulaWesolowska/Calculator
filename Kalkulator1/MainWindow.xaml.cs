using System;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator1
{
    public partial class MainWindow : Window
    {
        int opP = 0;
        double val1 = 0;
        double val2 = 0;
        double result = 0;
        string op = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        public double add(double a, double b)
        {
            return (a + b);
        }

        public double subtract(double a, double b)
        {
            return (a - b);
        }

        public double multiply(double a, double b)
        {
            return (a * b);
        }

        public double divide(double a, double b)
        {
            return (a / b);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            displayTextBox.Text += button.Content.ToString();
        }
        private void OnOffButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == onButton)
            {
                displayTextBox.Text = "";
                displayTextBox.IsEnabled = true;
            }
            else if (sender == offButton)
            {
                displayTextBox.Text = "Off";
                displayTextBox.IsEnabled = false;
            }
            else if (sender == delButton)
            {
                displayTextBox.Text = "";
            }
        }
        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception ex)
            {
                displayTextBox.Text = "BŁĄD. Spróbuj ponownie.";
            }
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == delButton)
            {
                displayTextBox.Text = "";

            }
        }
        private void Calculate()
        {
            if (displayTextBox.Text.Contains("*"))
            {
                opP = displayTextBox.Text.IndexOf("*");
            }
            else if (displayTextBox.Text.Contains("+"))
            {
                opP = displayTextBox.Text.IndexOf("+");
            }
            else if (displayTextBox.Text.Contains("-"))
            {
                opP = displayTextBox.Text.IndexOf("-");
            }
            else if (displayTextBox.Text.Contains("/"))
            {
                opP = displayTextBox.Text.IndexOf("/");
            }

            val1 = double.Parse(displayTextBox.Text.Substring(0, opP));
            op = displayTextBox.Text.Substring(opP, 1);
            val2 = double.Parse(displayTextBox.Text.Substring(opP + 1, displayTextBox.Text.Length - opP - 1));
                if (op == "*")
                {
                    result = multiply(val1, val2);
                    displayTextBox.Text = result.ToString();
                    val1 = result;
            }
                else if (op == "/")
                {
                    if (val2 == 0)
                    {
                        displayTextBox.Text = "Nie można dzielić przez zero!";
                    }
                    else
                    {
                        result = divide(val1, val2);
                        displayTextBox.Text = result.ToString();
                        val1 = result;
                }
                }
                else if (op == "+")
                {
                    result = add(val1, val2);
                    displayTextBox.Text = result.ToString();
                    val1 = result;
            }
                else if (op == "-")
                {
                    result = subtract(val1, val2);
                    displayTextBox.Text = result.ToString();
                    val1 = result;
                }
                }

        }
    }

