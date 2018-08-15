
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class vehiculos {

//LISTA ENLAZADA SIMPLE 
	
	String mar,mod; 
	double pre;
	int ano;
	vehiculos sig;
  	vehiculos aux;
	consumidores c;

	
 BufferedReader leer=new BufferedReader(new InputStreamReader(System.in));

//REGISTRAR UN CONSUMIDOR A LA LISTA DE ESPERA
 
  void registrar_con( consumidores aux, consumidores nv){                                                                                                                                                             
  
		  if((aux != null) | (aux== c)){

                  nv.llenar();
                  c= nv;
                
           }else{
        	
        	   
        	   if ( aux.sig!=null){
        		   
    
        		   nv.llenar();
        		   aux.sig=nv;
        		   nv.ant=nv;
        		   
        	   }else{  
        		   
        		   registrar_con(aux.sig, nv);
        		   
        	   }
           }
               
	}

 /* public consumidores buscar ( consumidores aux, String ced)  {
	  
	 
	  if ( aux== null){
		  
		  return null ;
		  
	  }else{
		  
		  
	    if ( aux== c){
	    
	     System.out.println("Introduzca el número de cedula del cliente ")	;
	      ced= leer.readLine();
	    }
	      if( aux.ced==ced){
	    	  
	    	  return true ;
	    	
	    	 
	    	  else {
	    		  
	    		     buscar(aux.ced)= buscar(aux.sig, ced);
	    		     
	    	  }
	    	  
	      }
	      
	  
	}*/
  	
    	
	    
	
	// Metodo para llenar los datos de un vehiculo 
  
  void llenarve(){
	
	 int num=0;
  try{	 
	System.out.println("Introduzca las siguientes  caracteristicas del auto");
	System.out.println(" Marca:");
	mar=leer.readLine();
	System.out.println("Modelo:");
	mod=leer.readLine();
	 while( num==0){ //validar que el usuario introduzca un entero//
     	 try{
                num=1;
			System.out.println(" año");
			año=Integer.parseInt(leer.readLine());

     	 }catch (Exception e) {num=0;System.err.println(" El año debe ser un entero");}
	 }     	 
     	 while( num==0){ //validar que le usuarion introduzca un entero//
         	 try{
        	 
			System.out.println(" precio ");
			pre =Double.parseDouble(leer.readLine());
         	}catch (Exception e) {num=0;System.err.println(" El precio debe ser un entero");}
         	  
          sig=null;
     	 }
       }catch (Exception e){e.printStackTrace();}
	
	
	 }

   
  //Muestra los datos de un vehiculo 
  
 void mostrar ( ){
	 
	System.out.println("Caracteristicas del vehículo ");
	System.out.println("Marca"+mar);
	System.out.println("modelo "+mod);
	System.out.println("año"+año);
	System.out.println("precio"+pre);
	
	 
   }
 
 // Menu de los consumidores 
 
   void menu_con( consumidores aux){
	   
    int opc;
	   
    try{
    	do{
    		System.out.println(" ");	
    		System.out.println("QUE DESEA HACER CON UN CLIENTE");
    		System.out.println(" ");
    		System.out.println(" 1) registrar ");
    		System.out.println(" 2) modificar");
    		System.out.println(" 3) eliminar ");
    		
    		System.out.println(" 0) salir");
    		opc=Integer.parseInt(leer.readLine());
    		
    		
    		switch(opc){
    			case 1:registrar_con(   ) ; break;
    	 //   case 2: modificar_consu(null); break;
    		//case 3: eliminar(); break;
    		
    		case 0: System.out.println(" Feliz dia"); break;
    		}
    	    
    		}while(opc!=0);
    	}catch(Exception e){e.printStackTrace();}
    	
    	    
	   
   } 

   
   // Modificar consumidores , de acuerdo al número de cedula 

   
   void modificar_consu( consumidores aux){
   
	   String ci ="";
	   
         if ( aux == null ) 
              System.out.println("No hay nada que modificar");
         else {     
                 if ( aux == c) {
                	 
                	 
                    try{System.out.println("el numero de cedula del cliente que desea modificar "); 
                     ci=leer.readLine();
 
                    }catch (Exception e) {e.printStackTrace();}  
                   if( aux.ced ==ci  ){ 
                           aux.llenar ();
                   }
                    else{ 
                           if ( aux.sig != null){
                                  modificar_consu(aux.sig);
                           }     
                            else{
                                 System.out.println("No se encontró el cliente");
                            }
                           }
                   

                         }
                   
                    }
       

         
   }
   
   
     
   //CUENTA LOS CONSUMIDORES DE LA LISTA DE ESPERA  
   
   int contar (consumidores aux, int con){
	   
	   if(c== null){ 
		   
		   System.out.println(" No hay nada que contar");
		   
           //  contar = con ;
		   
	   }else {
		   
		   if( c != null){
			   
			   con= con+1;
			   contar( aux.sig, con);
			   
		   }
	   }
   }
   
   
   
}

  

