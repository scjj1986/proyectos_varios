

import java.io.BufferedReader;
import java.io.InputStreamReader;


public class consumidores {

	// LISTA DE CLIENTES EN ESPERA PARA OPTAR POR UN VEHICULO
	
	// LISTA DOBLEMENTE ENLAZADA  
	
	String nom,ape, ced,correo,tlf ;
	consumidores ant,sig;
			
	BufferedReader leer=new BufferedReader(new InputStreamReader(System.in));

	// SE SOLICITAN LOS DATOS DE LOS CLIENTES		
  void llenar (){
	 
	  try{
			
          System.out.println("Introduzca los siguientes datos del cliente ");
          System.out.println("Cedula:");
          ced=leer.readLine();
          System.out.println("nombre:");
          nom=leer.readLine();
          System.out.println("Apellido:");
          ape=leer.readLine();
          System.out.println("correo electronico");
          correo=leer.readLine();
          System.out.println("Telefóno:");
          tlf=leer.readLine();
      
             sig=null;
             ant=null;
          
       }catch (Exception e ){e.printStackTrace();}

	
  }	

   // Muestra los datos de un cliente
  void mostrar (){
	  
	  System.out.println("Datos del cliente ");
      System.out.println("Cedula:"+ced);
      
      System.out.println("nombre:"+nom);
      
      System.out.println("Apellido:"+ ape);
      
      System.out.println("correo electronico"+correo);
      
      System.out.println("Telefóno:"+tlf);
      
  
	  
    }
  
}
