using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    class function
    {
        // Objects
        input inp = new input();
        zero zer = new zero();

        // Fields
        public double result;
        public bool operationDone = false;

        // Methods
        public void operation()
        {
            // Solve according to MDAS
            switch (inp.MDAS)
            {
                case "+":
                    result = double.Parse(inp.num1) + double.Parse(inp.num2);
                    break;
                case "-":
                    result = double.Parse(inp.num1) - double.Parse(inp.num2);
                    break;
                case "x":
                    result = double.Parse(inp.num1) * double.Parse(inp.num2);
                    break;
                case "/":
                    result = double.Parse(inp.num1) / double.Parse(inp.num2);
                    break;
            }
        }
        public void clearall()
        {
            // Reset all variables
            inp.MDAS = "";
            inp.num1 = "";
            inp.num2 = "";
            result = 0;
            display.Text = "0";
            zer.zeroError = false;
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
