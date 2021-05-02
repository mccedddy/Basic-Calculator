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
        string num1 = "";
        string num2 = "";
        double result = 0;
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
            num1 = num1 + textBox.Text;
            MDAS = MDAS + button.Text;
            textBox.Text = "";
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            num2 = num2 + textBox.Text;
            //MessageBox.Show(num1 + " " + MDAS + " " + num2 + " " + "=" + result);
        }
    }
}
