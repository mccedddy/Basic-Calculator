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
        string num1 = "";
        string num2 = "";
        double result;
        bool operationDone = false;
        bool zeroError = false;
        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // If num1 and MDAS have value and num2 is empty
            if (num1 != "" && MDAS != "" && num2 == "")
            {
                display.Text = "0";
            }
            
            // If the decimal button is pressed
            if (button.Text == ".")
            {
                decimalpoint();
            }

            // If the zero button is pressed
            else if (button.Text == "0")
            {
                zeroinput();
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

                // If num1 and MDAS have value and num2 is empty
                if (num1 != "" && MDAS != "" && num2 == "")
                {
                    
                    // Clear display.text and add button.text
                    display.Text = "";
                    display.Text = display.Text + button.Text;
                    
                    // Set display.text as num2
                    num2 = display.Text;
                }
            }
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            // If zeroError is false
            if (zeroError == false)
            {
                if (num1 != "" && num2 != "" && MDAS != "")
                {
                    operation();
                    display.Text = Convert.ToString(result);
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
                operation();

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

        // Methods
        
        private void decimalpoint()
        {
            // If zeroError is false
            if (zeroError == false)
            {
                // If display.text does not have a decimal point, add a decimal point
                if (!display.Text.Contains("."))
                { display.Text = display.Text + "."; }

                // If an operation has been performed, clear display.text and add a decimal point
                if (operationDone == true)
                {
                    display.Text = "0.";
                    operationDone = false;
                }
            }
        }
        private void zeroinput()
        {
            // If zeroError is true
            if (zeroError == true)
            {
                zeroError = false;
                display.Text = "0";
            }

            // If display.text is 0, don't add 0
            if (display.Text == "0")
            { }

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
        private void operation()
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
        }
        private void debug()
        {
            MessageBox.Show("num1 = " + num1 +
                "\nMDAS = " + MDAS +
                "\nnum2 = " + num2 +
                "\noperationDone = " + operationDone);
        }
    }
}
