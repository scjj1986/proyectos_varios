namespace ReglaDivisibilidad
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.OpenFileDialog bscArchivo;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbNumDiv;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader Numero;
		private System.Windows.Forms.ColumnHeader Detalles;
		private System.Windows.Forms.DataGridView dtgResultado;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		
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
        private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtgResultado = new System.Windows.Forms.DataGridView();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbNumDiv = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bscArchivo = new System.Windows.Forms.OpenFileDialog();
			this.Numero = new System.Windows.Forms.ColumnHeader();
			this.Detalles = new System.Windows.Forms.ColumnHeader();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgResultado)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtgResultado);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbNumDiv);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(529, 303);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Valores a evaluar";
			// 
			// dtgResultado
			// 
			this.dtgResultado.BackgroundColor = System.Drawing.Color.White;
			this.dtgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1,
			this.Column2});
			this.dtgResultado.Location = new System.Drawing.Point(115, 91);
			this.dtgResultado.Name = "dtgResultado";
			this.dtgResultado.RowHeadersWidth = 15;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtgResultado.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dtgResultado.Size = new System.Drawing.Size(328, 189);
			this.dtgResultado.TabIndex = 0;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBuscar.Location = new System.Drawing.Point(271, 39);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(130, 24);
			this.btnBuscar.TabIndex = 0;
			this.btnBuscar.Text = "Cargar Archivo";
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.BtnBuscarClick);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(158, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "Archivo de Numeros:";
			// 
			// cmbNumDiv
			// 
			this.cmbNumDiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNumDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbNumDiv.FormattingEnabled = true;
			this.cmbNumDiv.Items.AddRange(new object[] {
			"Del 2 al 10",
			"Del 2 al 20"});
			this.cmbNumDiv.Location = new System.Drawing.Point(115, 39);
			this.cmbNumDiv.Name = "cmbNumDiv";
			this.cmbNumDiv.Size = new System.Drawing.Size(141, 21);
			this.cmbNumDiv.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 27);
			this.label1.TabIndex = 0;
			this.label1.Text = "Numeros para el criterio de divisibilidad:";
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Numero";
			this.Column1.MinimumWidth = 60;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 60;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Detalles";
			this.Column2.MinimumWidth = 60;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 250;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(796, 330);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Regla de Divisibilidad";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgResultado)).EndInit();
			this.ResumeLayout(false);

		}

		}
	}
