import java.io.*;


public class MINIPROYECTO1 {

    static class empleado {	
    	String codigo,nombre,apellido;
    	int cedula,pago_hora,horas_trabajadas;
    	public void llenar() throws Exception
    	{
    		
    		String cad;
    		BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
    		System.out.println("\nCodigo del empleado:\n ");
    		codigo = teclado.readLine();
    		System.out.println("\nCedula del empleado:\n ");
    		cad = teclado.readLine();
    		while( !numerico(cad) || (Integer.parseInt(cad)<1) )
    		{
    			
    			System.out.println("\nLa cedula debe ser numerica y mayor que 0. Ingrese dicho valor:\n ");
    			cad = teclado.readLine();
    		}
    		cedula = Integer.parseInt(cad);
    		System.out.println("\nNombre del empleado:\n ");
    		nombre = teclado.readLine();
    		System.out.println("\nApellido del empleado:\n ");
    		apellido = teclado.readLine();
    		System.out.println("\nPago por hora trabajada (Bs.):\n ");
    		cad = teclado.readLine();
    		while ( (!numerico(cad)) || (Integer.parseInt(cad)<1) )
    		{
    			
    			System.out.println("\nEl pago por hora trabajada debe ser numerico y mayor que 0. Ingrese dicho valor: \n ");
    			cad = teclado.readLine();
    		}
    		pago_hora=Integer.parseInt(cad);
    		System.out.println("\nTotal de horas trabajadas (Bs.): \n ");
    		cad = teclado.readLine();
    		while ( (!numerico(cad)) || (Integer.parseInt(cad)<1) )
    		{
    			
    			System.out.println("\nLa cantidad de horas trabajadas debe ser numerico mayor que 0. Ingrese dicho valor: \n ");
    			horas_trabajadas = Integer.parseInt(teclado.readLine());
    		}
    		horas_trabajadas=Integer.parseInt(cad);	
    	}
    	public boolean codigo_repetido (empleado[] ar_empleados, int i)
    	{
    		
    		int j= i-1;
    		
    		while (j>=0)
    		{
    			
    			if (ar_empleados[i].codigo.compareTo(ar_empleados[j].codigo)==0)
    			{
    				
    				return true;
    			}
    			j--;
    		}
    		return false;
    	}  	
    	public boolean cedula_repetida (empleado[] ar_empleados, int i)
    	{
    		
    		int j= i-1;
    		
    		while (j>=0)
    		{
    			
    			if (ar_empleados[j].cedula==ar_empleados[i].cedula)
    			{
    				
    				return true;
    			}
    			j--;
    		}
    		return false;
    	}   	
    	public boolean numerico (String cad)
    	{  
			for(int i = 0; i<cad.length(); i++)  
				if( !Character.isDigit(cad.charAt(i)) )  
 					return false;  
			return true;  
		}  	
    }
    
    public static void main(String[] args) throws Exception /*principal*/
    {
    	
    	empleado ar_empleados[];
    	ar_empleados= new empleado[5];
    	BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
    	int monto=0;
    	String cad= " ";
    	System.out.println("\nBienvenidos a la aplicacion que calcula los sueldos de los empleados de una empresa\n");
    	for (int i=0;i<5;i++)
    	{
    		ar_empleados[i]= new empleado();
    		System.out.println("-------------------------- Procesando empleado # "+(i+1)+" ----------------------------- \n ");
    		ar_empleados[i].llenar();
    		if (i!=0)
    		{
    			while (ar_empleados[i].codigo_repetido(ar_empleados,i))
    			{
    				
    				System.out.println("\nCodigo del empleado repetido. Ingrese nuevamente dicho valor:\n ");
    				ar_empleados[i].codigo = teclado.readLine();
    			}
    			
    			while(ar_empleados[i].cedula_repetida(ar_empleados,i))
    			{
    				
    				System.out.println("\nCedula del empleado debe ser irrepetible. Ingrese nuevamente dicho valor:\n ");
    				cad=teclado.readLine();
    				while ((!ar_empleados[i].numerico(cad)) || (Integer.parseInt(cad)<1) )
    				{
    					System.out.println("\nCedula del empleado debe ser numerica y mayor que 0. Ingrese nuevamente dicho valor:\n ");
    					cad=teclado.readLine();
    				}
    				ar_empleados[i].cedula=Integer.parseInt(cad);
    			}
    			
    		}
    		System.out.println("\nEl sueldo correspondiente del empleado es de "+(ar_empleados[i].pago_hora*ar_empleados[i].horas_trabajadas)+" Bs.\n ");
    		monto+=ar_empleados[i].pago_hora*ar_empleados[i].horas_trabajadas;
    		
    	}
    	System.out.println("\nTotal cancelado por la empresa: "+monto+" Bs.\n ");	
    }
}