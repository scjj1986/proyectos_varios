
using System;
using System.Collections;
using System.Windows.Forms;

namespace ReglaDivisibilidad
{
	/// <summary>
	/// Description of Pila.
	/// </summary>
	public class Pila
	{
		public Stack pta;
		public Stack pta2;
		
		public Pila()
		{
			pta=new Stack();
			pta2=new Stack();
		}
		
		public bool repetido(string linea){
		
		
			bool encontrado=false;
			while (pta.Count>0){
			
				if(pta.Peek().ToString().Equals(linea)){
				
				
					encontrado=true;
				}
				pta2.Push(pta.Peek().ToString());
				pta.Pop();
			
			}
			while (pta2.Count>0){
			
				pta.Push(pta2.Peek().ToString());
				pta2.Pop();
			
			}
			return encontrado;
		}
		
		
		public int validar_archivo_entrada(String nombrearchivo,int Err){
		
			string linea;
			long valor=1;
			Err = 0;
			
			if (!nombrearchivo.EndsWith(".txt")){
				   return 1;
			}
			else{
					System.IO.StreamReader lector = new System.IO.StreamReader(nombrearchivo);
					while(  ((linea = lector.ReadLine()) != null))
					{
						if (!long.TryParse(linea, out valor)){
							return 2;
						} 
						// disable once RedundantIfElseBlock
						else if (repetido(linea)) {
						return 3;
						} else {
							pta.Push(linea);
						}
					}
						
					lector.Close();
					
			}
			return 0;
		
		}
		
		public bool div_2(String numero){
		
			if (numero.EndsWith("2") ||  numero.EndsWith("4") ||  numero.EndsWith("6") ||  numero.EndsWith("8") ||  numero.EndsWith("0")){
				return true;
			}
			return false;
		
		
		}
		
		public bool div_3(String numero){
		
			int valor=Int32.Parse(numero);
			int i;
			while (valor>9){
			
				valor=0;
				for (i=0;i<numero.Length;i++){
				
					
					valor=valor + Int32.Parse(numero[i].ToString());
					
					
				
				}
				numero = valor.ToString();
				
			
			}
			if (valor==9 || valor==6 || valor==3){
			
				return true;
			}
				
			return false;
		}
		public bool div_4(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>9){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(a*2)-b;
				numero=valor.ToString();
			}
			if (valor==8 || valor==4 || valor==0 || valor==-4){
			
				return true;
			}
			return false;
		}
		public bool div_5(String numero){
		
			if (numero.EndsWith("5") ||  numero.EndsWith("0")){
				return true;
			}
			return false;
		
		
		}
		public bool div_7(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>9){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(b*2)-a;
				if (valor<0){
					valor=-valor;
				}
				numero=valor.ToString();
			}
			if (valor==7 || valor==0){
			
				return true;
			}
			return false;
		}
		public bool div_8(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>9){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(a*2)+b;
				numero=valor.ToString();
			}
			if (valor==8 || valor==0){
			
				return true;
			}
			return false;
		}
		public bool div_9(String numero){
		
			int valor=Int32.Parse(numero);
			int i;
			while (valor>9){
			
				valor=0;
				for (i=0;i<numero.Length;i++){
				
					
					valor=valor + Int32.Parse(numero[i].ToString());
					
					
				
				}
				numero = valor.ToString();
				
			
			}
			if (valor==9){
			
				return true;
			}
				
			return false;
		}
		
		
		public bool div_11(String numero){
			int valor=Int32.Parse(numero);
			int a,b,i;
			a=b=0;
			bool par=false;
			while (valor>11){
				a=b=0;
				for (i=0;i<numero.Length;i++){
					if (!par){
				
						a=a+Int32.Parse(numero[i].ToString());
						par=true;
				
					}
					else{
						b=b+Int32.Parse(numero[i].ToString());
						par=false;
					
					}
				}
				if (valor<0){
					valor=-valor;
				}
				valor=a-b;
				numero=valor.ToString();
			}
			if (valor==11 || valor==0){
			
				return true;
			}
			return false;
		}
		public bool div_13(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>13){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(a*3)-b;
				numero=valor.ToString();
			}
			if (valor==13 || valor==0){
			
				return true;
			}
			return false;
		}
		public bool div_16(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>16){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(a*6)-b;
				numero=valor.ToString();
			}
			if (valor==16 || valor==0){
			
				return true;
			}
			return false;
		}
		public bool div_17(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>17){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(b*5)-a;
				if (valor<0){
					valor=-valor;
				}
				numero=valor.ToString();
			}
			if (valor==17 || valor==0){
			
				return true;
			}
			return false;
		}
		public bool div_19(String numero){
			int valor=Int32.Parse(numero);
			int a,b;
			a=b=0;
			while (valor>19){
			
				b=Int32.Parse(numero[numero.Length-1].ToString());
				numero = numero.Remove(numero.Length-1,1);
				a=Int32.Parse(numero);
				valor=(b*2)+a;
				numero=valor.ToString();
			}
			if (valor==19 || valor==0){
			
				return true;
			}
			return false;
		}
		
		
		/*public Nodo apilar(Nodo pt,Nodo n){
		
			if (pt!=null){
			n.sig=pt;
			}
			return n;
		
		}
		/*public Nodo desapilar(Nodo pt,Nodo pt2){
		
			if (pt!=null){
			
				aux=pt;
				if (pt.sig!=null){
				
					pt=pt.sig;
				}
				else {
				
					pt=null;
				}
				aux.sig=null;
				pt2=apilar(pt2,aux);
			}
			return pt;
		
		}*/
	}
}
