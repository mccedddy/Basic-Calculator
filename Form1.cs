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
        string MDAS;
        string num1;
        string num2;
        double dnum1;
        double dnum2;
        double result;
        public Basic_Calculator()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox.Text = textBox.Text + button.Text;
        }
        private void btn_MDAS(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (result == 0) { num1 = num1 + textBox.Text; }
            MDAS = MDAS + button.Text;
            textBox.Text = "";
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            num2 = num2 + textBox.Text;
            dnum1 = double.Parse(num1);
            dnum2 = double.Parse(num2);
            if (MDAS == "+") { result = dnum1 + dnum2; }
            if (MDAS == "-") { result = dnum1 - dnum2; }
            if (MDAS == "x") { result = dnum1 * dnum2; }
            if (MDAS == "/") { result = dnum1 / dnum2; }
            textBox.Text = Convert.ToString(result);
            num1 = Convert.ToString(result);
            dnum1 = result;
            num2 = "";
            MDAS = "";
        }
        private void btn_C_Click(object sender, EventArgs e)
        {
            MDAS = "";
            num1 = "";
            num2 = "";
            dnum1 = 0;
            dnum2 = 0;
            result = 0;
        }
        private void btn_CE_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
        }
    }
}
