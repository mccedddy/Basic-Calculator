using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    class input
    {
        // Objects
        function function = new function();
        zero zero = new zero();

        // Fields
        public string MDAS = "";
        public string num1 = "";
        public string num2 = "";
        public string displayTextOutput;

        // Methods
        public void decimalpoint()
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
            if (function.operationDone == true)
            {
                display.Text = "0.";
                function.operationDone = false;
            }
        }
        public void zeroInput()
        {
            // If zeroError is true
            zero.fixZeroError();

            // If display.text is not 0
            if (display.Text != "0")
            {
                // Add 0
                display.Text = display.Text + "0";
            }

            // If an operation has already been performed, set display.text as 0 and reset operationDone
            if (function.operationDone == true)
            {
                display.Text = "0";
                function.operationDone = false;
            }
        }
        public void numberInput(string buttontext)
        {
            // If zeroError is true, reset zeroError and display.text
            zero.fixZeroError();

            // If display.text is 0 or an operation has already been performed
            if (display.Text == "0" | function.operationDone == true)
            {
                // If num2 is empty, clear display.text and reset operationDone
                if (num2 == "")
                { display.Text = ""; }
                function.operationDone = false;
            }

            // If MDAS is empty, input button.text
            if (MDAS == "")
            {
                display.Text = display.Text + buttontext;
            }
        }
    }
}
