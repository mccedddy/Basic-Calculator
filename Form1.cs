using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Calculator
{
    public partial class Basic_Calculator : Form
    {
        public Basic_Calculator()
        {
            InitializeComponent();
        }
        // Procedural Programming Format
        // Fields
        string MDAS = "";
        string num1 = "";
        string num2 = "";
        double result;
        bool operationDone = false;
        bool zeroError = false;
        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // If num1 and MDAS have value
            if (num1 != "" && MDAS != "")
            {
                // If num2 is empty
                if (num2 == "")
                {   // If display.text is 0., clear display.text
                    if (display.Text == "0.") { display.Text = ""; }
                    // If display.text is not 0., clear display.text
                    else { display.Text = ""; }
                }

                // If button.text is not 0
                if (button.Text != "0")
                {
                    // If button.text is ".", do nothing
                    if (button.Text == ".") { }
                    // If button.text is not ".", add button.text
                    else { display.Text = display.Text + button.Text; }
                }

                // Set display.text as num2
                num2 = display.Text;
            }

            // If the decimal button is pressed
            if (button.Text == ".")
            {
                // If display.text does not have a decimal point, add a decimal point
                if (!display.Text.Contains("."))
                {
                    display.Text = display.Text + ".";

                    // If display.text is ".", set display.text as "0."
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

            // If the zero button is pressed
            else if (button.Text == "0")
            {
                // If zeroError is true, reset zero error and display.text
                if (zeroError == true)
                {
                    zeroError = false;
                    display.Text = "0";
                    btn_add.Enabled = true;
                    btn_subtract.Enabled = true;
                    btn_multiply.Enabled = true;
                    btn_divide.Enabled = true;
                    btn_negative.Enabled = true;
                    btn_point.Enabled = true;
                }

                // If display.text is not 0
                if (display.Text != "0")
                {
                    // Add 0
                    display.Text = display.Text + "0";
                }

                // If an operation has already been performed, set display.text as 0 and reset operationDone
                if (operationDone == true)
                {
                    display.Text = "0";
                    operationDone = false;
                }

                // If there is an MDAS, set display.text as num2
                if (MDAS != "")
                { num2 = display.Text; }
            }

            // If a number button is pressed
            else
            {
                // If zeroError is true, reset zeroError and display.text
                if (zeroError == true)
                {
                    zeroError = false;
                    display.Text = "0";
                    btn_add.Enabled = true;
                    btn_subtract.Enabled = true;
                    btn_multiply.Enabled = true;
                    btn_divide.Enabled = true;
                    btn_negative.Enabled = true;
                    btn_point.Enabled = true;
                }

                // If display.text is 0 or an operation has already been performed
                if (display.Text == "0" | operationDone == true)
                {
                    // If num2 is empty, clear display.text and reset operationDone
                    if (num2 == "")
                    { display.Text = ""; }
                    operationDone = false;
                }

                // If MDAS is empty, input button.text
                if (MDAS == "")
                {
                    display.Text = display.Text + button.Text;
                }
            }
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            
            // If num1, num2, and MDAS have value
            if (num1 != "" && num2 != "" && MDAS != "")
            {
                // Solve and show result
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
                display.Text = Convert.ToString(result);

                // Set display.text as num1 and clear num2
                num1 = display.Text;
                num2 = "";
            }

            // If there's still no MDAS, set button.text as MDAS
            if (MDAS == "")
            {
                MDAS = MDAS + button.Text;

                // Set display.text as num1
                num1 = display.Text;
            }

            // If there's already MDAS, clear MDAS and set button.text as MDAS
            else if (MDAS != "")
            {
                MDAS = "";
                MDAS = MDAS + button.Text;
            }

            // If display.text is infinite or NaN, show error and check zero error
            if (display.Text == "∞" | display.Text == "-∞")
            {
                // Reset all variables
                MDAS = "";
                num1 = "";
                num2 = "";
                result = 0;
                display.Text = "0";
                operationDone = false;
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;
                zeroError = true;
                display.Text = "Cannot divide by zero";
            }
            if (display.Text == "NaN")
            {
                // Reset all variables
                MDAS = "";
                num1 = "";
                num2 = "";
                result = 0;
                display.Text = "0";
                operationDone = false;
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;
                zeroError = true;
                display.Text = "Result is undefined";
            }

            // if zero error is true, disable MDAS, negative and decimal buttons
            if (zeroError == true)
            {
                btn_add.Enabled = false;
                btn_subtract.Enabled = false;
                btn_multiply.Enabled = false;
                btn_divide.Enabled = false;
                btn_negative.Enabled = false;
                btn_point.Enabled = false;
            }
            else
            {
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;
            }
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            // Set display.text as num2
            num2 = display.Text;

            // Perform operations according to MDAS
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

            // Show result
            display.Text = Convert.ToString(result);

            // If display.text is infinite or NaN, show error and check zero error
            if (display.Text == "∞" | display.Text == "-∞")
            {
                // Reset all variables
                MDAS = "";
                num1 = "";
                num2 = "";
                result = 0;
                display.Text = "0";
                zeroError = false;
                operationDone = false;
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;

                zeroError = true;
                display.Text = "Cannot divide by zero";
            }
            if (display.Text == "NaN")
            {
                // Reset all variables
                MDAS = "";
                num1 = "";
                num2 = "";
                result = 0;
                display.Text = "0";
                zeroError = false;
                operationDone = false;
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;

                zeroError = true;
                display.Text = "Result is undefined";
            }

            // if zero error is true, disable MDAS, negative and decimal buttons
            if (zeroError == true)
            {
                btn_add.Enabled = false;
                btn_subtract.Enabled = false;
                btn_multiply.Enabled = false;
                btn_divide.Enabled = false;
                btn_negative.Enabled = false;
                btn_point.Enabled = false;
            }
            else
            {
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;
            }

            // Clear num2 and MDAS
            num2 = "";
            MDAS = "";

            // Set operationDone as true
            operationDone = true;
        }
        private void btn_negative_Click(object sender, EventArgs e)
        {
            // If display.text is positive, add negative sign
            if (!display.Text.Contains("-") && display.Text != "0")
            { display.Text = display.Text.Insert(0, "-"); }

            // If display.text is negative, remove negative sign
            else
            {
                if (display.Text != "0")
                { display.Text = display.Text.Remove(0, 1); }
            }
        }
        private void btn_C_Click(object sender, EventArgs e)
        {
            // Reset all variables
            MDAS = "";
            num1 = "";
            num2 = "";
            result = 0;
            display.Text = "0";
            zeroError = false;
            operationDone = false;
            btn_add.Enabled = true;
            btn_subtract.Enabled = true;
            btn_multiply.Enabled = true;
            btn_divide.Enabled = true;
            btn_negative.Enabled = true;
            btn_point.Enabled = true;
        }
        private void btn_CE_Click(object sender, EventArgs e)
        {
            // Clear display
            display.Text = "0";

            // If zeroError is true, clear all
            if (zeroError == true)
            {
                // Reset all variables
                MDAS = "";
                num1 = "";
                num2 = "";
                result = 0;
                display.Text = "0";
                zeroError = false;
                operationDone = false;
                btn_add.Enabled = true;
                btn_subtract.Enabled = true;
                btn_multiply.Enabled = true;
                btn_divide.Enabled = true;
                btn_negative.Enabled = true;
                btn_point.Enabled = true;
            }
        }
    }
}
