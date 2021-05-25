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
        // Fields
        string MDAS = "";
        string num1;
        string num2;
        double result;
        bool operationDone = false;
        bool zeroError = false;
        private void btn_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            
            // If the decimal button is pressed
            if (button.Text == ".")
            {
                // If zeroError is false
                if (zeroError == false)
                {
                    // If display.text does not have a decimal point, add a decimal point
                    if (!display.Text.Contains("."))
                    { display.Text = display.Text + "."; }
                }
            }

            // If the zero button is pressed
            else if (button.Text == "0")
            {
                // If zeroError is true
                if (zeroError == true)
                {
                    zeroError = false;
                    display.Text = "0";
                }

                // If display.text is 0, don't add 0
                if (display.Text == "0") 
                { display.Text = display.Text; }

                // If display.text is not 0
                else if (display.Text != "0")
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
            }

            // If a number button is pressed
            else
            {
                // If zeroError is true
                if (zeroError == true)
                {
                    zeroError = false;
                    display.Text = "0";
                }

                // If display.text is 0 or an operation has already been performed
                if (display.Text == "0" | operationDone == true)
                { 
                    // Clear display.text and reset operationDone
                    display.Text = "";
                    operationDone = false;
                }

                // Input button.text
                display.Text = display.Text + button.Text;
            }
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            // If zeroError is false
            if (zeroError == false)
            {
                // Set display.text as num1
                num1 = display.Text;

                // If there's still no MDAS, set button.text as MDAS
                if (MDAS == "")
                { MDAS = MDAS + button.Text; }

                // If there's already MDAS, clear MDAS and set button.text as MDAS
                else if (MDAS != "")
                {
                    MDAS = "";
                    MDAS = MDAS + button.Text;
                }

                // Clear display.text
                display.Text = "";
            }
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            // If zeroError is false
            if (zeroError == false)
            {
                // Set display.text as num2 and zeroError as false
                num2 = display.Text;
                zeroError = false;

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
                if (display.Text == "∞" | display.Text == "-∞")
                {
                    display.Text = "Cannot divide by zero";
                    zeroError = true;
                }

                // Clear num2 and MDAS
                num2 = "";
                MDAS = "";
                operationDone = true;
            }
        }
        private void btn_negative_Click(object sender, EventArgs e)
        {
            // If zeroError is false
            if (zeroError == false)
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
        }
        private void btn_C_Click(object sender, EventArgs e)
        {
            // Clear all
            MDAS = "";
            num1 = "";
            num2 = "";
            result = 0;
            display.Text = "0";
            zeroError = false;
        }
        private void btn_CE_Click(object sender, EventArgs e)
        {
            // Clear display
            display.Text = "0";

            // If zeroError is true, clear all
            if (zeroError == true)
            {
                MDAS = "";
                num1 = "";
                num2 = "";
                result = 0;
                display.Text = "0";
                zeroError = false;
            }
        }
    }
}
