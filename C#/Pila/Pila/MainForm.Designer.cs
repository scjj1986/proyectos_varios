
namespace Pila
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckedListBox listadiv;
		private System.Windows.Forms.DataGridView tablares;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button botbus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
		private System.Windows.Forms.OpenFileDialog buscar;
		private System.Windows.Forms.CheckBox seltodo;
		private System.Windows.Forms.Label lab;
		
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.listadiv = new System.Windows.Forms.CheckedListBox();
			this.tablares = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.botbus = new System.Windows.Forms.Button();
			this.buscar = new System.Windows.Forms.OpenFileDialog();
			this.seltodo = new System.Windows.Forms.CheckBox();
			this.lab = new System.Windows.Forms.Label();
			this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.tablares)).BeginInit();
			this.SuspendLayout();
			// 
			// listadiv
			// 
			this.listadiv.FormattingEnabled = true;
			this.listadiv.Items.AddRange(new object[] {
			"2",
			"3",
			"5",
			"7",
			"11",
			"13",
			"17",
			"19",
			"23",
			"29"});
			this.listadiv.Location = new System.Drawing.Point(16, 64);
			this.listadiv.Name = "listadiv";
			this.listadiv.Size = new System.Drawing.Size(108, 154);
			this.listadiv.TabIndex = 0;
			// 
			// tablares
			// 
			this.tablares.AllowUserToAddRows = false;
			this.tablares.AllowUserToDeleteRows = false;
			this.tablares.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.tablares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.tablares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tablares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column11,
			this.Column1,
			this.Column2,
			this.Column3,
			this.Column4,
			this.Column5,
			this.Column6,
			this.Column7,
			this.Column8,
			this.Column9,
			this.Column10});
			this.tablares.Location = new System.Drawing.Point(209, 45);
			this.tablares.Name = "tablares";
			this.tablares.Size = new System.Drawing.Size(414, 173);
			this.tablares.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Lista de Números";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(209, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Resultados";
			// 
			// botbus
			// 
			this.botbus.Location = new System.Drawing.Point(145, 45);
			this.botbus.Name = "botbus";
			this.botbus.Size = new System.Drawing.Size(37, 25);
			this.botbus.TabIndex = 4;
			this.botbus.Text = "...";
			this.botbus.UseVisualStyleBackColor = true;
			this.botbus.Click += new System.EventHandler(this.BotbusClick);
			// 
			// seltodo
			// 
			this.seltodo.Location = new System.Drawing.Point(18, 42);
			this.seltodo.Name = "seltodo";
			this.seltodo.Size = new System.Drawing.Size(16, 21);
			this.seltodo.TabIndex = 5;
			this.seltodo.Text = "checkBox1";
			this.seltodo.UseVisualStyleBackColor = true;
			this.seltodo.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// lab
			// 
			this.lab.Location = new System.Drawing.Point(34, 45);
			this.lab.Name = "lab";
			this.lab.Size = new System.Drawing.Size(99, 18);
			this.lab.TabIndex = 6;
			this.lab.Text = "Sel./Desel. Todo ";
			// 
			// Column11
			// 
			this.Column11.HeaderText = "Número";
			this.Column11.Name = "Column11";
			this.Column11.Width = 70;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "2";
			this.Column1.Name = "Column1";
			this.Column1.Width = 30;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "3";
			this.Column2.Name = "Column2";
			this.Column2.Width = 30;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "5";
			this.Column3.Name = "Column3";
			this.Column3.Width = 30;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "7";
			this.Column4.Name = "Column4";
			this.Column4.Width = 30;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "11";
			this.Column5.Name = "Column5";
			this.Column5.Width = 30;
			// 
			// Column6
			// 
			this.Column6.HeaderText = "13";
			this.Column6.Name = "Column6";
			this.Column6.Width = 30;
			// 
			// Column7
			// 
			this.Column7.HeaderText = "17";
			this.Column7.Name = "Column7";
			this.Column7.Width = 30;
			// 
			// Column8
			// 
			this.Column8.HeaderText = "19";
			this.Column8.Name = "Column8";
			this.Column8.Width = 30;
			// 
			// Column9
			// 
			this.Column9.HeaderText = "23";
			this.Column9.Name = "Column9";
			this.Column9.Width = 30;
			// 
			// Column10
			// 
			this.Column10.HeaderText = "29";
			this.Column10.Name = "Column10";
			this.Column10.Width = 30;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 231);
			this.Controls.Add(this.lab);
			this.Controls.Add(this.seltodo);
			this.Controls.Add(this.botbus);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tablares);
			this.Controls.Add(this.listadiv);
			this.Name = "MainForm";
			this.Text = "Miniprograma de Pila";
			((System.ComponentModel.ISupportInitialize)(this.tablares)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
