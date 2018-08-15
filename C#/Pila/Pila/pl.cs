
using System;

namespace Pila
{
	/// <summary>
	/// Description of pl.
	/// </summary>
	public class pl
	{
		
		public nd tope;
		public int[] s13,s17,s19,s23,s29;
		
		public pl()
		{
			tope = null;
			s13 = new int[] {1,3,4,1,3,4};
			s13[1]=-3;
			s13[2]=-4;
			s13[3]=-1;
			
		}
		
		public void apilar (nd nuevo){
		
			if (tope!=null){
			
				nuevo.sig=tope;
			}
			tope = nuevo;
			
		}
		public void desapilar (){
			
			if (tope!=null){
			
				tope=tope.sig;
			}
		
			
		}
		public Boolean entre2(String nr){
		
			if (nr[nr.Length-1]=='2' || nr[nr.Length-1]=='4' || nr[nr.Length-1]=='6' || nr[nr.Length-1]=='8' || nr[nr.Length-1]=='0'){
				return true;
			
			}
			else {return false;}
		}
		public Boolean entre3(String nr){
		
			int i;
			int suma=0;
			while (Int32.Parse(nr)>9){
				
				i=0;
				suma=0;
				while (i<nr.Length){
				
					suma+=(int)Char.GetNumericValue(nr[i]);
					i++;
				}
				nr=suma.ToString();
			}
			if (nr.Equals("9") ||nr.Equals("6") || nr.Equals("3")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre5(String nr){
		
			if (nr[nr.Length-1]=='5' || nr[nr.Length-1]=='0'){
				return true;
			
			}
			else {return false;}
		}
		public Boolean entre7(String nr){
		
			int der,izq=0;
			while (Int32.Parse(nr)>9){
				
				der=(int)Char.GetNumericValue(nr[nr.Length-1]);
				izq=Int32.Parse(nr.Remove(nr.Length-1,1));
				nr=((3*izq)+der).ToString();
			}
			if ( nr.Equals("0") || nr.Equals("7") ){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre11(String nr){
		
			int der,izq=0;
			while (Int32.Parse(nr)>10){
				
				der=(int)Char.GetNumericValue(nr[nr.Length-1]);
				izq=Int32.Parse(nr.Remove(nr.Length-1,1));
				nr=(izq-der).ToString();
			}
			if ( nr.Equals("0")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre13(String nr){
		
			int suma,i,j;
			while (Int32.Parse(nr)>13){
				i=0;
				j=nr.Length-1;
				suma=0;
				while  (j>=0){
					suma+=(int)Char.GetNumericValue(nr[j])*s13[i];
					i++;
					if (i==6){
					
						i=0;
					
					}
					j--;
				
				}
				nr=Math.Abs(suma).ToString();
			
			}
			if ( nr.Equals("0") || nr.Equals("13")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre17(String nr){
		
			int der,izq=0;
			while (Int32.Parse(nr)>17){
				
				der=(int)Char.GetNumericValue(nr[nr.Length-1]);
				izq=Int32.Parse(nr.Remove(nr.Length-1,1));
				nr=((izq*7)-der).ToString();
			}
			if ( nr.Equals("17") || nr.Equals("0")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre19(String nr){
		
			int der,izq=0;
			while (Int32.Parse(nr)>19){
				
				der=(int)Char.GetNumericValue(nr[nr.Length-1]);
				izq=Int32.Parse(nr.Remove(nr.Length-1,1));
				nr=((izq*9)-der).ToString();
			}
			if ( nr.Equals("19") || nr.Equals("0")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre23(String nr){
		
			int der,izq=0;
			while (Int32.Parse(nr)>23){
				
				der=(int)Char.GetNumericValue(nr[nr.Length-1]);
				izq=Int32.Parse(nr.Remove(nr.Length-1,1));
				nr=(izq+(der*7)).ToString();
			}
			if ( nr.Equals("23")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		public Boolean entre29(String nr){
		
			int der,izq=0;
			while (Int32.Parse(nr)>29){
				
				der=(int)Char.GetNumericValue(nr[nr.Length-1]);
				izq=Int32.Parse(nr.Remove(nr.Length-1,1));
				nr=(izq+(der*3)).ToString();
			}
			if ( nr.Equals("29")){
				return true;
			
			}
			else {
			
				return false;
			}
		
		}
		
	}
}
