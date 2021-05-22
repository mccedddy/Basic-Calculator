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
        string MDAS = "";
        string num1;
        string num2;
        double result;
        public Basic_Calculator()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            if (MDAS != "") { display.Text = ""; }
            Button button = (Button)sender;
            display.Text = display.Text + button.Text;
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (MDAS == "")
            {
                if (result == 0) { num1 = num1 + display.Text; }
                MDAS = MDAS + button.Text;
            }
            else 
            {
                if (result == 0) { num1 = num1 + display.Text; }
                MDAS = "";
                MDAS = MDAS + button.Text;
            }
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            num2 = num2 + display.Text;
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
            num1 = Convert.ToString(result);
            num2 = "";
            MDAS = "";
        }
        private void btn_point_Click(object sender, EventArgs e)
        {
            //display.Text = display.Text + ".";
        }
        private void btn_negative_Click(object sender, EventArgs e)
        {
            double negative = double.Parse(display.Text);
            if (negative - negative == 0) { negative = negative - negative * 2; }
            else { negative = negative - negative * 2; }
            num1 = Convert.ToString(negative);
            display.Text = num1;
        }
        private void btn_C_Click(object sender, EventArgs e)
        {
            MDAS = "";
            num1 = "";
            num2 = "";
            result = 0;
            display.Text = "";
        }
        private void btn_CE_Click(object sender, EventArgs e)
        {
            display.Text = "";
        }
    }
}
