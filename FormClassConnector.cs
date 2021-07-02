using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Calculator
{
    class FormClassConnector
    {
        Basic_Calculator mainform = new Basic_Calculator();
        public TextBox displayText
        {
            get { return mainform.display; }
        }
    }
}
