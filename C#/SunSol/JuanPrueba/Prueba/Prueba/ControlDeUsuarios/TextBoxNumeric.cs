using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contratos
{
    public partial class TextBoxNumeric : TextBox
    {
        public TextBoxNumeric()
        {
            InitializeComponent();
        }
        //Sobreescribir el metodo OnKeyPress de la clase TextBox

        protected override void OnTextChanged(EventArgs e)
        {
            int i = 0;
            if (!int.TryParse(this.Text, out i))
            {
                this.Text = "";
            }
            
        }
    }
}
