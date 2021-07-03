using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Calculator
{
    class calcClass 
    {
        // Fields
        public string MDAS = "";
        public string num1 = "";
        public string num2 = "";
        public double result;
        public bool operationDone = false;
        public bool zeroError = false;

        // Methods
        public void operation()
        {
            // Solve according to MDAS
            switch (MDAS)
            {
                case "+":
                    result = double.Parse(num1) + double.Parse(num2);
                    break;
                case "-":
                    result = double.Parse(num1) - double.Parse(num2);
                    break;
                case "x":
                    result = double.Parse(num1) * double.Parse(num2);
                    break;
                case "/":
                    result = double.Parse(num1) / double.Parse(num2);
                    break;
            }
        }
        public void decimalpoint(TextBox display)
        {
            // Add decimal point
            if (!display.Text.Contains("."))
            {
                display.Text = display.Text + ".";
                if (display.Text == ".")
                { display.Text = "0."; }
            }

            // If an operation has been performed, set display.text as "0." and reset operationDone
            if (operationDone == true)
            {
                display.Text = "0.";
                operationDone = false;
            }
        }
        public void zeroInput(TextBox display)
        {
            // Add 0
            if (display.Text != "0")
            {
                display.Text = display.Text + "0";
            }

            // If an operation has already been performed, reset display.text and operationDone
            if (operationDone == true)
            {
                display.Text = "0";
                operationDone = false;
            }
        }
        public void numberInput(TextBox display, string buttontext)
        {
            // Clear display.text
            if (display.Text == "0" | operationDone == true)
            {
                // If num2 is empty, clear display.text and reset operationDone
                if (num2 == "")
                { display.Text = ""; }
                operationDone = false;
            }

            // Input number
            if (MDAS == "")
            {
                display.Text = display.Text + buttontext;
            }
        }
        public void checkZeroError(TextBox display)
        {
            // If display.text is infinite or NaN, show error
            if (display.Text == "∞" | display.Text == "-∞")
            {
                zeroError = true;
                display.Text = "Cannot divide by zero";
            }
            if (display.Text == "NaN")
            {
                zeroError = true;
                display.Text = "Result is undefined";
            }
        }
        public void clearall()
        {
            // Reset everything
            MDAS = "";
            num1 = "";
            num2 = "";
            result = 0;
            zeroError = false;
            operationDone = false;
        }
        public void fixZeroError(TextBox display)
        {
            // If zero error is true, clear all
            if (zeroError == true)
            {
                display.Text = "0";
                clearall();
            }
        }
    }
}
