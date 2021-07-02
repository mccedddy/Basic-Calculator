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
        // OOP Format
        calcClass calc = new calcClass();

        public void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // If num1 and MDAS have value
            if (calc.num1 != "" && calc.MDAS != "")
            {
                // If num2 is empty
                if (calc.num2 == "")
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
                calc.num2 = display.Text;
            }

            // If the decimal button is pressed
            if (button.Text == ".")
            {
                decimalpoint();
            }

            // If the zero button is pressed
            else if (button.Text == "0")
            {
                zeroInput();

                // If there is an MDAS, set display.text as num2
                if (calc.MDAS != "")
                { calc.num2 = display.Text; }
            }

            // If a number button is pressed
            else
            {
                numberInput(button.Text);
            }
        }
        public void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            
            // If num1, num2, and MDAS have value
            if (calc.num1 != "" && calc.num2 != "" && calc.MDAS != "")
            {
                // Solve and show result
                calc.operation();
                display.Text = Convert.ToString(calc.result);

                // Set display.text as num1 and clear num2
                calc.num1 = display.Text;
                calc.num2 = "";
            }

            // If there's still no MDAS, set button.text as MDAS
            if (calc.MDAS == "")
            {
                calc.MDAS = calc.MDAS + button.Text;

                // Set display.text as num1
                calc.num1 = display.Text;
            }

            // If there's already MDAS, clear MDAS and set button.text as MDAS
            else if (calc.MDAS != "")
            {
                calc.MDAS = "";
                calc.MDAS = calc.MDAS + button.Text;
            }

            // Check if there is an error
            checkZeroError();
            buttonEnabled();
        }
        public void btn_Equals(object sender, EventArgs e)
        {
            // Set display.text as num2
            calc.num2 = display.Text;

            // Perform operations according to MDAS
            calc.operation();

            // Show result
            display.Text = Convert.ToString(calc.result);

            // Check if there is an error
            checkZeroError();
            buttonEnabled();

            // Clear num2 and MDAS
            calc.num2 = "";
            calc.MDAS = "";

            // Set operationDone as true
            calc.operationDone = true;
        }
        public void btn_negative_Click(object sender, EventArgs e)
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
        public void btn_C_Click(object sender, EventArgs e)
        {
            // Clear all
            clearall();
            checkZeroError();
            buttonEnabled();
        }
        public void btn_CE_Click(object sender, EventArgs e)
        {
            // Clear display
            display.Text = "0";

            // If zeroError is true, clear all
            if (calc.zeroError == true)
            {
                clearall();
                checkZeroError();
                buttonEnabled();
            }
        }

        // Methods
        private void decimalpoint()
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
            if (calc.operationDone == true)
            {
                display.Text = "0.";
                calc.operationDone = false;
            }
        }
        private void zeroInput()
        {
            // If zeroError is true
            fixZeroError();

            // If display.text is not 0
            if (display.Text != "0")
            {
                // Add 0
                display.Text = display.Text + "0";
            }

            // If an operation has already been performed, set display.text as 0 and reset operationDone
            if (calc.operationDone == true)
            {
                display.Text = "0";
                calc.operationDone = false;
            }
        }
        private void numberInput(string buttontext)
        {
            // If zeroError is true, reset zeroError and display.text
            fixZeroError();

            // If display.text is 0 or an operation has already been performed
            if (display.Text == "0" | calc.operationDone == true)
            {
                // If num2 is empty, clear display.text and reset operationDone
                if (calc.num2 == "")
                { display.Text = ""; }
                calc.operationDone = false;
            }

            // If MDAS is empty, input button.text
            if (calc.MDAS == "")
            {
                display.Text = display.Text + buttontext;
            }
        }
       
        private void clearall()
        {
            // Reset all variables
            calc.MDAS = "";
            calc.num1 = "";
            calc.num2 = "";
            calc.result = 0;
            display.Text = "0";
            calc.zeroError = false;
            calc.operationDone = false;
            checkZeroError();
            buttonEnabled();
        }
        private void checkZeroError()
        {
            // If display.text is infinite or NaN, show error and check zero error
            if (display.Text == "∞" | display.Text == "-∞")
            {
                clearall();
                calc.zeroError = true;
                display.Text = "Cannot divide by zero";
            }
            if (display.Text == "NaN")
            {
                clearall();
                calc.zeroError = true;
                display.Text = "Result is undefined";
            }
        }
        private void fixZeroError()
        {
            if (calc.zeroError == true)
            {
                calc.zeroError = false;
                display.Text = "0";
                checkZeroError();
                buttonEnabled();
            }
        }
        private void buttonEnabled()
        {
            // if zero error is true, disable MDAS, negative and decimal buttons
            if (calc.zeroError == true)
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
    }
}
