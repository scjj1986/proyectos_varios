
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pila
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public pl MiPila;
		public nd nodo_aux,nodo_nuevo;
		public int i;
		public String[] fila;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			fila = new String[11];
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BotbusClick(object sender, EventArgs e)
		{
			String ln="";
			int cnv=0;
			bool exito=true;
			tablares.Rows.Clear();
			MiPila = new pl();
			if (buscar.ShowDialog() == DialogResult.OK){
			
				if (!buscar.FileName.EndsWith(".txt")){
				
					MessageBox.Show("No se puede abrir el archivo");
					exito=false;
				
				}
				else {
				
					System.IO.StreamReader fr = new System.IO.StreamReader(buscar.FileName);
					while ((  ((ln = fr.ReadLine()) != null))){
					
						if (!int.TryParse(ln, out cnv)){
							MessageBox.Show("Error de sintaxis de achivo");
							exito=false;
						}
						else {
						
							nodo_nuevo = new nd(ln);
							MiPila.apilar(nodo_nuevo);
						}
					}
					
				
				}
				
				if (exito){
				
					if (listadiv.CheckedItems.Count==0){
					
						MessageBox.Show("Debe elegir algun numero en la lista de numeros primos");
					
					}
					else{
						
						while (MiPila.tope!=null){
						
							fila[0]=MiPila.tope.nr;
							for (i=0;i<=listadiv.Items.Count-1;i++){
							
								switch (listadiv.Items[i].ToString() ){
										
										case "2": 
											if (  Int32.Parse(MiPila.tope.nr)>=2  &&  MiPila.entre2(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[1]="Si";
											}
											else if ( ( !MiPila.entre2(MiPila.tope.nr) || Int32.Parse(MiPila.tope.nr)<2  ) && listadiv.GetItemChecked(i)){
												fila[1]="No";
											
												
											}
											else {
										
												fila[1]="X";
											}
											break;
											
										case "3": 
											if (  Int32.Parse(MiPila.tope.nr)>=3  &&  MiPila.entre3(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[2]="Si";
											}
											else if (!MiPila.entre3(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[2]="No";
											
												
											}
											else {
										
												fila[2]="X";
											}
											break;
											
										case "5": 
											if (  Int32.Parse(MiPila.tope.nr)>=5  &&  MiPila.entre5(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[3]="Si";
											}
											else if (!MiPila.entre5(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[3]="No";
											
												
											}
											else {
										
												fila[3]="X";
											}
											break;
											
										case "7": 
											if (  Int32.Parse(MiPila.tope.nr)>=7  &&  MiPila.entre7(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[4]="Si";
											}
											else if (!MiPila.entre7(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[4]="No";
											
												
											}
											else {
										
												fila[4]="X";
											}
											break;
											
										case "11": 
											if (  Int32.Parse(MiPila.tope.nr)>=11  &&  MiPila.entre11(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[5]="Si";
											}
											else if (!MiPila.entre11(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[5]="No";
											
												
											}
											else {
										
												fila[5]="X";
											}
											break;
											
										case "13": 
											if (  Int32.Parse(MiPila.tope.nr)>=13  &&  MiPila.entre13(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[6]="Si";
											}
											else if (!MiPila.entre13(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[6]="No";
											
												
											}
											else {
										
												fila[6]="X";
											}
											break;
											
										case "17": 
											if (  Int32.Parse(MiPila.tope.nr)>=17  &&  MiPila.entre17(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[7]="Si";
											}
											else if (!MiPila.entre17(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[7]="No";
											
												
											}
											else {
										
												fila[7]="X";
											}
											break;
											
										case "19": 
											if (  Int32.Parse(MiPila.tope.nr)>=19  &&  MiPila.entre19(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[8]="Si";
											}
											else if (!MiPila.entre19(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[8]="No";
											
												
											}
											else {
										
												fila[8]="X";
											}
											break;
											
										case "23": 
											if (  Int32.Parse(MiPila.tope.nr)>=23  &&  MiPila.entre23(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[9]="Si";
											}
											else if (!MiPila.entre23(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[9]="No";
											
												
											}
											else {
										
												fila[9]="X";
											}
											break;
											
										case "29": 
											if (  Int32.Parse(MiPila.tope.nr)>=17  &&  MiPila.entre29(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[10]="Si";
											}
											else if (!MiPila.entre29(MiPila.tope.nr) && listadiv.GetItemChecked(i)){
												fila[10]="No";
											
												
											}
											else {
										
												fila[10]="X";
											}
											break;
								
								}
							
							}
							MiPila.desapilar();
							tablares.Rows.Add(fila);
							
							
						}
						
					
						
					}
				}
			
			
			}
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			bool chk = seltodo.Checked;
			for (int i=0;i<listadiv.Items.Count;i++){
			
				listadiv.SetItemChecked(i,chk);
			}
		}
		
	}
}
