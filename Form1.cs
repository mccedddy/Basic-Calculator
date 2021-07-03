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
        calcClass calc = new calcClass();

        public Basic_Calculator()
        {
            InitializeComponent();
        }
        // OOP Format
        public void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // For inputting num2
            if (calc.num1 != "" && calc.MDAS != "")
            {
                // if there is num1 and MDAS, clear display.text
                if (calc.num2 == "")
                {
                    if (display.Text == "0.") { display.Text = ""; }
                    else { display.Text = ""; }
                }

                // If button.text is not 0, add the number to display
                if (button.Text != "0")
                {   // If button.text is ".", do nothing
                    if (button.Text == ".") { }
                    else { display.Text = display.Text + button.Text; }
                }
                calc.num2 = display.Text;
            }

            // For decimal input
            if (button.Text == ".")
            {
                calc.decimalpoint(display);
            }

            // For zero input
            else if (button.Text == "0")
            {
                fixZeroError();
                calc.zeroInput(display);
                // If there is an MDAS, set display.text as num2
                if (calc.MDAS != "")
                { calc.num2 = display.Text; }
            }

            // For number input
            else
            {
                fixZeroError();
                calc.numberInput(display, button.Text);
            }
        }
        public void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            
            // For continuous operation
            if (calc.num1 != "" && calc.num2 != "" && calc.MDAS != "")
            {
                calc.operation();
                display.Text = Convert.ToString(calc.result);
                calc.num1 = display.Text;
                calc.num2 = "";
            }

            // Input MDAS and set display.text as num1
            if (calc.MDAS == "")
            {
                calc.MDAS = calc.MDAS + button.Text;
                calc.num1 = display.Text;
            }

            // To change MDAS
            else if (calc.MDAS != "")
            {
                calc.MDAS = "";
                calc.MDAS = calc.MDAS + button.Text;
            }

            // Check if there is an error
            calc.checkZeroError(display);
            buttonEnabled();
        }
        public void btn_Equals(object sender, EventArgs e)
        {
            // Set display.text as num2
            calc.num2 = display.Text;

            // Perform operations
            calc.operation();
            display.Text = Convert.ToString(calc.result);

            // Check if there is an error
            calc.checkZeroError(display);
            buttonEnabled();

            // Clear num2 and MDAS
            calc.num2 = "";
            calc.MDAS = "";
            calc.operationDone = true;
        }
        public void btn_negative_Click(object sender, EventArgs e)
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
        public void btn_C_Click(object sender, EventArgs e)
        {
            // Clear all
            clearall();
            calc.checkZeroError(display);
            buttonEnabled();
        }
        public void btn_CE_Click(object sender, EventArgs e)
        {
            // Clear display
            display.Text = "0";
            if (calc.zeroError == true)
            {
                clearall();
                calc.checkZeroError(display);
                buttonEnabled();
            }
        }

        // Methods
        private void clearall()
        {
            // Reset everything
            calc.MDAS = "";
            calc.num1 = "";
            calc.num2 = "";
            calc.result = 0;
            display.Text = "0";
            calc.zeroError = false;
            calc.operationDone = false;
            btn_add.Enabled = true;
            btn_subtract.Enabled = true;
            btn_multiply.Enabled = true;
            btn_divide.Enabled = true;
            btn_negative.Enabled = true;
            btn_point.Enabled = true;
        }
        
        private void fixZeroError()
        {
            // If zero error is true, clear all
            if (calc.zeroError == true)
            {
                clearall();
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
