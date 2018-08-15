/*
 * Created by SharpDevelop.
 * User: Salazar
 * Date: 15/11/2016
 * Time: 14:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace test
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.TextBox txtLetras;
		private System.Windows.Forms.TextBox txtDecimal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.txtLetras = new System.Windows.Forms.TextBox();
			this.txtDecimal = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(151, 35);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(105, 20);
			this.txtNumero.TabIndex = 0;
			this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumeroKeyPress);
			// 
			// txtLetras
			// 
			this.txtLetras.Location = new System.Drawing.Point(151, 61);
			this.txtLetras.Name = "txtLetras";
			this.txtLetras.Size = new System.Drawing.Size(105, 20);
			this.txtLetras.TabIndex = 1;
			this.txtLetras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLetrasKeyPress);
			// 
			// txtDecimal
			// 
			this.txtDecimal.Location = new System.Drawing.Point(151, 85);
			this.txtDecimal.Name = "txtDecimal";
			this.txtDecimal.Size = new System.Drawing.Size(105, 20);
			this.txtDecimal.TabIndex = 2;
			this.txtDecimal.TextChanged += new System.EventHandler(this.TxtDecimalTextChanged);
			this.txtDecimal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimalKeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(92, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Números";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(92, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Letras";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(92, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "Decimal";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(93, 148);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(195, 20);
			this.dateTimePicker1.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(470, 262);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDecimal);
			this.Controls.Add(this.txtLetras);
			this.Controls.Add(this.txtNumero);
			this.Name = "MainForm";
			this.Text = "test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
