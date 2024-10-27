using System;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class CalculatorPage : ContentPage
    {
        private string currentValue = "0";
        private string previousValue = "";
        private string operation = "";

        public CalculatorPage()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string number = button.Text;

            if (currentValue == "0" && number != ".")
                currentValue = number;
            else
                currentValue += number;

            UpdateDisplay();
        }

        private void OnOperationClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            operation = button.Text;
            previousValue = currentValue;
            currentValue = "0";
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (double.TryParse(previousValue, out double num1) && double.TryParse(currentValue, out double num2))
            {
                double result = operation switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num2 != 0 ? num1 / num2 : 0,
                    _ => 0
                };
                currentValue = result.ToString();
                previousValue = "";
                operation = "";
                UpdateDisplay();
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentValue = "0";
            previousValue = "";
            operation = "";
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            DisplayLabel.Text = currentValue;
        }
    }
}
