using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    class zero
    {
        // Objects
        input input = new input();
        function function = new function();

        // Fields
        public bool zeroError = false;

        // Methods
        public void checkZeroError(string displayText)
        {
            // If display.text is infinite or NaN, show error and check zero error
            if (display.Text == "∞" | display.Text == "-∞")
            {
                function.clearall();
                zeroError = true;
                display.Text = "Cannot divide by zero";
            }
            if (display.Text == "NaN")
            {
                function.clearall();
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
        public void fixZeroError()
        {
            if (zeroError == true)
            {
                zeroError = false;
                display.Text = "0";
                checkZeroError(); // no parameter
            }
        }
    }
}
