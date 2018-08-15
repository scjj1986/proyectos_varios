

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class principal{

	  
	public static void main(String[] args) {
		
try{
	
		lista lis = new lista();
		  // lis.l.llenarve();
		 
			
                                
	
	//MENU DE NUESTRO SEGUNDO  PROYECTO///
	
	
 	int opc;
	BufferedReader leer	=new BufferedReader(new InputStreamReader(System.in));

	do{
		System.out.println(" ");
		System.out.println("  MENU DE COMPRA Y VENTA DE UN VEHICULO ");
		System.out.println("         ");
		System.out.println("Seleccione una de las siguientes:");
		System.out.println("         ");
		System.out.println(" 1) VEHICULO");
		System.out.println(" 2) CLIENTES");
		System.out.println(" 3) Mostrar los vehículos en los cuales se encuentra un cliente en especifico");
		System.out.println(" 4) Cantidad de clientes que esperan un carro cuyo precio es mayor o igual a  250.000");
		System.out.println(" 5) Mostrar la lista de clientes que esperan a un vehículo");
		System.out.println(" 6) Cantidad de vehículos que tienen una lista de espera mayor a 100 clientes");
		System.out.println(" 7) Mostrar aquellos vehículos cuya lista de espera sea igual o mayor a  50  clientes");
		System.out.println(" 0) SALIR" ) ;
		opc=Integer.parseInt(leer.readLine());
		
     	switch(opc){
		
     	 case 1: lis.menu_veh (); break;
	    //case 2: av.menu(); break;
		//case 3:c.menu(); break;
		//case 4: a.menu(); break;
		//case 5: p.menu();break;
		//case 6: v.menu();break;
		case 0: System.out.println("Ha finalizado "); break;
		} 
		
	}while(opc!=0); 
	}catch(Exception e){e.printStackTrace();}

}


}
	


