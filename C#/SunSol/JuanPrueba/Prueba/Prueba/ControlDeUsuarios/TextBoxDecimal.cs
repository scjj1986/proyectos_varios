using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Contratos
{
    public partial class TextBoxDecimal : TextBox
    {
        public TextBoxDecimal()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
                   if (this.Text.Contains('.'))
                   {
                              if(!char.IsDigit(e.KeyChar))
                              {
                                       e.Handled = true;
                               }

                               if (e.KeyChar == '\b')
                               {
                                        e.Handled = false;
                                }
                   }
                   else
                   {
                                  if(!char.IsDigit(e.KeyChar))
                                  {
                                          e.Handled = true;
                                   }

                                   if(e.KeyChar=='.' || e.KeyChar=='\b')
                                  {
                                           e.Handled = false;
                                  }
                    }
        }
    }
}
