
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace ReglaDivisibilidad
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public Pila p;
		public int Err=0;
		public MainForm()
		{
			InitializeComponent();
			p=new Pila();
			dtgResultado.AllowUserToAddRows=false;
			cmbNumDiv.SelectedIndex=0;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		public void cargar_datagrid(){
		
			int max=0;
			int i=0;
			int contdiv;
			String detalles;
			if (cmbNumDiv.SelectedIndex==0){
				
				max=10;
			}
			else{
				
				max=20;
			}
			while (p.pta.Count>0){
			
			
				detalles="";
				contdiv=0;
				for(i=2;i<=max;i++){
				
					if (i<=Int32.Parse(p.pta.Peek().ToString())){
					
					
						
						if (i==2){
						
							if (p.div_2(p.pta.Peek().ToString())){
								
								detalles = detalles+"2,";
								contdiv++;
							}
						}
						else if (i==3){
						
							if (p.div_3(p.pta.Peek().ToString())){
								
								detalles = detalles+"3,";
								contdiv++;
							}
						}
						else if (i==4){
						
							if (p.div_4(p.pta.Peek().ToString())){
								
								detalles = detalles+"4,";
								contdiv++;
							}
						}
						else if (i==5){
						
							if (p.div_5(p.pta.Peek().ToString())){
								
								detalles = detalles+"5,";
								contdiv++;
							}
						}
						else if (i==6){
						
							if (p.div_2(p.pta.Peek().ToString())  &&  p.div_3(p.pta.Peek().ToString())){
								
								detalles = detalles+"6,";
								contdiv++;
							}
						}
						else if (i==7){
						
							if (p.div_7(p.pta.Peek().ToString())){
								
								detalles = detalles+"7,";
								contdiv++;
							}
						}
						else if (i==8){
						
							if (p.div_8(p.pta.Peek().ToString())){
								
								detalles = detalles+"8,";
								contdiv++;
							}
						}
						else if (i==9){
						
							if (p.div_9(p.pta.Peek().ToString())){
								
								detalles = detalles+"9,";
								contdiv++;
							}
						}
						else if (i==10){
						
							if (p.div_2(p.pta.Peek().ToString())  &&  p.div_5(p.pta.Peek().ToString())){
								
								detalles = detalles+"10,";
								contdiv++;
							}
						}
						else if (i==11){
						
							if (p.div_11(p.pta.Peek().ToString())){
								
								detalles = detalles+"11,";
								contdiv++;
							}
						}
						else if (i==12){
						
							if (p.div_4(p.pta.Peek().ToString())  &&  p.div_3(p.pta.Peek().ToString())){
								
								detalles = detalles+"12,";
								contdiv++;
							}
						}
						else if (i==13){
						
							if (p.div_13(p.pta.Peek().ToString())){
								
								detalles = detalles+"13,";
								contdiv++;
							}
						}
						else if (i==14){
						
							if (p.div_2(p.pta.Peek().ToString())  &&  p.div_7(p.pta.Peek().ToString())){
								
								detalles = detalles+"14,";
								contdiv++;
							}
						}
						else if (i==15){
						
							if (p.div_5(p.pta.Peek().ToString())  &&  p.div_3(p.pta.Peek().ToString())){
								
								detalles = detalles+"15,";
								contdiv++;
							}
						}
						else if (i==16){
						
							if (p.div_16(p.pta.Peek().ToString())){
								
								detalles = detalles+"16,";
								contdiv++;
							}
						}
						else if (i==17){
						
							if (p.div_17(p.pta.Peek().ToString())){
								
								detalles = detalles+"17,";
								contdiv++;
							}
						}
						else if (i==18){
						
							if (p.div_2(p.pta.Peek().ToString())  &&  p.div_9(p.pta.Peek().ToString())){
								
								detalles = detalles+"18,";
								contdiv++;
							}
						}
						else if (i==19){
						
							if (p.div_19(p.pta.Peek().ToString())){
								
								detalles = detalles+"19,";
								contdiv++;
							}
						}
						else{
						
							if (p.div_5(p.pta.Peek().ToString())  &&  p.div_4(p.pta.Peek().ToString())){
								
								detalles = detalles+"2,";
								contdiv++;
							}
						}
					
					}
				}
				if (contdiv==0){
				
					detalles="No es divisible entre el rango de numeros seleccionados";
				
				}
				else{
						
							detalles = "Divisible entre: "+detalles;
							detalles = detalles.Remove(detalles.Length-1,1);
						
				}
				dtgResultado.Rows.Add(p.pta.Peek().ToString(),detalles);
				p.pta.Pop();
				
			
			}
		
		}
		
		
		void BtnBuscarClick(object sender, EventArgs e)
		{
			
			dtgResultado.Rows.Clear();
			p.pta.Clear();
			p.pta2.Clear();
			if(bscArchivo.ShowDialog() == DialogResult.OK){
			
				Err = p.validar_archivo_entrada(bscArchivo.FileName,Err);
				if (Err ==1){
			
			
				MessageBox.Show("Formato de archivo incorrecto","Error");
				dtgResultado.Rows.Clear();
			
				}
				else if (Err ==2){
				
				
					MessageBox.Show("Error en lectura de archivo","Error");
					dtgResultado.Rows.Clear();
				
				}
				else if (Err==3){
				
				
					MessageBox.Show("Los valores contenidos en el archivo deben ser irrepetibles","Error");
					dtgResultado.Rows.Clear();
				
				}
				else{
				
				
					MessageBox.Show("Archivo cargado satisfactoriamente. Se procedera a la prueba de divisibilidad","Exitoso");
					cargar_datagrid();
					
				
				}
				
			 }
			
			}		
	
		}
		
	}
