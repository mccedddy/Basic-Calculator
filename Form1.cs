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
        private void btn_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                // If display.text does not have a decimal point, add a decimal point
                if (!display.Text.Contains("."))
                { display.Text = display.Text + "."; }

                // If display.text has a decimal point, don't add a decimal point
                else
                { display.Text = display.Text; }
            }
            else if (button.Text == "0")
            {
                // If display.text is not 0, add 0
                if (display.Text == "0") 
                { display.Text = display.Text; }

                // If display.text is 0, don't add 0
                else
                { display.Text = display.Text + "0"; }
            }
            else
            { 
                // If display.text is 0, remove the text
                if (display.Text == "0") 
                { display.Text = ""; }

                // Input button.text
                display.Text = display.Text + button.Text;
            }
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            // Set display.text as num1
            num1 = display.Text;

            // If there's still no MDAS, set button.text as MDAS
            if (MDAS == "")
            { MDAS = MDAS + button.Text; }

            // If there's already MDAS, clear MDAS and set button.text as MDAS
            else
            {
                MDAS = "";
                MDAS = MDAS + button.Text;
            }

            // Clear display.text
            display.Text = "";
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

            // Display result
            display.Text = Convert.ToString(result);

            // Clear num2 and MDAS
            num2 = "";
            MDAS = "";
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
            // Clear MDAS, num1, num2, result, and display
            MDAS = "";
            num1 = "";
            num2 = "";
            result = 0;
            display.Text = "0";
        }
        private void btn_CE_Click(object sender, EventArgs e)
        {
            // Clear display
            display.Text = "0";
        }
    }
}
