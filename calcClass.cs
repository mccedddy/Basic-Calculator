using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
