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

            // For inputting num2
            if (num1 != "" && MDAS != "")
            {
                // Clear display.text
                if (num2 == "")
                {
                    if (display.Text == "0.") { display.Text = ""; }
                    else { display.Text = ""; }
                }
                if (button.Text != "0")
                {
                    if (button.Text == ".") { }
                    else { display.Text = display.Text + button.Text; }
                }
                num2 = display.Text;
            }

            // For decimal input
            if (button.Text == ".")
            {
                if (!display.Text.Contains("."))
                {
                    display.Text = display.Text + ".";
                    if (display.Text == ".")
                    { display.Text = "0."; }
                }

                // If an operation has been performed, reset display.text and operationDone
                if (operationDone == true)
                {
                    display.Text = "0.";
                    operationDone = false;
                }
            }

            // For zero input
            else if (button.Text == "0")
            {
                // Fix zero error
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

                // If there is an MDAS, set num2
                if (MDAS != "")
                { num2 = display.Text; }
            }

            // For number input
            else
            {
                // Fix zero error
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

                // Clear display.text
                if (display.Text == "0" | operationDone == true)
                {
                    if (num2 == "")
                    { display.Text = ""; }
                    operationDone = false;
                }

                // Input number
                if (MDAS == "")
                {
                    display.Text = display.Text + button.Text;
                }
            }
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            
            // For continuous operation
            if (num1 != "" && num2 != "" && MDAS != "")
            {
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
                num1 = display.Text;
                num2 = "";
            }

            // Set MDAS
            if (MDAS == "")
            {
                MDAS = MDAS + button.Text;
                num1 = display.Text;
            }

            // For changing MDAS
            else if (MDAS != "")
            {
                MDAS = "";
                MDAS = MDAS + button.Text;
            }

            // Check if there is an error
            if (display.Text == "∞" | display.Text == "-∞")
            {
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

            // if there is an error, disable MDAS, negative and decimal buttons
            if (zeroError == true)
            {
                btn_add.Enabled = false;
                btn_subtract.Enabled = false;
                btn_multiply.Enabled = false;
                btn_divide.Enabled = false;
                btn_negative.Enabled = false;
                btn_point.Enabled = false;
            }
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            num2 = display.Text;

            // Perform operations
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

            // Check if there is an error
            if (display.Text == "∞" | display.Text == "-∞")
            {
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

            // if there is an error, disable MDAS, negative and decimal buttons
            if (zeroError == true)
            {
                btn_add.Enabled = false;
                btn_subtract.Enabled = false;
                btn_multiply.Enabled = false;
                btn_divide.Enabled = false;
                btn_negative.Enabled = false;
                btn_point.Enabled = false;
            }
            
            // Clear num2 and MDAS
            num2 = "";
            MDAS = "";
            operationDone = true;
        }
        private void btn_negative_Click(object sender, EventArgs e)
        {
            // Add or remove negative sign
            if (!display.Text.Contains("-") && display.Text != "0")
            { display.Text = display.Text.Insert(0, "-"); }
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

            // If zeroError is true, reset everything
            if (zeroError == true)
            {
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
