/*
 * Created by SharpDevelop.
 * User: Salazar
 * Date: 15/11/2016
 * Time: 14:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace test
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void TxtNumeroKeyPress(object sender, KeyPressEventArgs e)//Evento para validar números en textbox
		{
			
			if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
			{
			      e.Handled = true;
			      return;
			}
	
		}
		void TxtLetrasKeyPress(object sender, KeyPressEventArgs e)//Evento para validar letras en textbox
		{
			if ( (char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
			{
			      e.Handled = true;
			      return;
			}
	
		}
		
		
	
		void TxtDecimalKeyPress(object sender, KeyPressEventArgs e)//Evento para validar decimales
		{
			
			if (txtDecimal.Text.Contains("."))
           {
				if(!char.IsDigit(e.KeyChar) || (txtDecimal.Text=="."))
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
		void TxtDecimalTextChanged(object sender,EventArgs e)//Evento para validar decimales
		{
			if(txtDecimal.Text=="."){
				
				txtDecimal.Text= "";
			
			}
		}
		
		
		
	}
}
