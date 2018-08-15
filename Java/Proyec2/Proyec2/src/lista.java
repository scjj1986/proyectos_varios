import java.io.BufferedReader;
import java.io.InputStreamReader;


public class lista {
 

// apunta a vehiculos- una lista simple
	 vehiculos l;
	//  clase 
	 
	 
	BufferedReader leer=new BufferedReader(new InputStreamReader(System.in));

	// REGISTRAR UN VEHICULO AL INCIO DE LA LISTA 
	void registrar_veh( ){
	   	
		try{
	     vehiculos nv = new vehiculos () ;
               nv.llenarve();
               
           if(l!=null){
        	   nv.sig=l;
        	   
           }
               l=nv;
		}catch(Exception e){e.printStackTrace();}
	}
	
	
	// MODIFICAR UN VEHICULO DE ACUERDO AL MODELO , INTRODUCIDO POR EL USUARIO
	
	 void modificar_veh( vehiculos aux){
		   
		   String mode ="";
		   
	         if ( aux == null ) 
	              System.out.println("No hay nada que modificar");
	         else {     
	                 if ( aux == l) {
	                	 
	                	 
	                    try{System.out.println("Introduzca el modelo del auto que desea modificar "); 
	                     mode=leer.readLine();
	 
	                    }catch (Exception e) {e.printStackTrace();}  
	                   if( aux.mod == mode  ){ 
	                           aux.llenarve(); 
	                   }
	                    else{ 
	                           if ( aux.sig != null){
	                                  modificar_veh(aux.sig);
	                           }     
	                            else{
	                                 System.out.println("No se encontró el auto ");
	                            }
	                           }
	                   

	                         }
	                   
	                    }
	       

	         
	   } 
	 
	 // MENU DE VEHICULOS 
	public void menu_veh(){
		   
		    int opc;
			   
		    try{
		    	do{
		    		System.out.println(" ");	
		    		System.out.println("QUE DESEA HACER CON UN VEHICULO");
		    		System.out.println(" ");
		    		System.out.println(" 1) registrar ");
		    		System.out.println(" 2) modificar");
		    		System.out.println(" 3) eliminar ");
		    		
		    		System.out.println(" 0) salir");
		    		opc=Integer.parseInt(leer.readLine());
		    		
		    		switch(opc){
		    	    case 1: registrar_veh(); break;
		    	//    case 2: modificar_veh (vehiculos); break;
		    		   //case 3: eliminar(); break;
		    		
		    		case 0: System.out.println(" Feliz dia"); break;
		    		}
		    		
		    	}while(opc!=0);
		    	}catch(Exception e){e.printStackTrace();}
		    
	 }	   
	
	// MOSTRAR LA LISTA DE ESPERA DE UN VEHICULO, A PARTIR DE UN MODELO INTRODUCIDO POR EL USUSARIO 
	
 public  void mostrar_esp( vehiculos aux, String mod){
	
	 try{
	   if (aux== null){
		  
		  System.out.println("No hay nada que mostrar- lista de espera vacía");
	   }
		  else{
	
			    if(aux== l){
			    	System.out.println("introduzca el modelo del vehiculo");
			    	mod=leer.readLine();
			    }
			    
			      if( aux.mod==mod){
			    	  aux.c.mostrar();
			    	
			      }else{
			    		if( aux.sig != null){
			    			
			    			mostrar_esp(aux.sig,mod);
			    		}
			            else{
                            System.out.println("No se encontró el auto ");
                       }
			    	}
			    	
			      
		  }
	 
			    }catch (Exception e){e.printStackTrace();} 
	  
	   }
 //Método que cuenta los  consumidores de una lista d espera donde el vehículo cuesta más de 250
 
  
 void  contar_esp (vehiculos aux , int cont)  {
	 double precio=250.000;
	   
	   if(aux.c== null){
		   
		   System.out.println(" no hay nada que contar");
//		     contar_esp = cont ;
	   }
		     else{
		    	 
		    	 if( aux.pre >= precio){
	//	    		 contar_esp(aux.sig, cont+aux.contar(aux.c));
		    		 
		    	 }else{
		    		 contar_esp(aux.sig,cont);
		     }
		   
	   }
	 
   }
 
  
 void mostrar_50( vehiculos aux ){
	 
	 if (aux.c== null){
		 
		 System.out.println(" No hay nada que mostrar- lista vacia");
		 
	 }
	    if(aux != null){
             
	    //if ( aux.contar ==" 50"){
	    	 aux.c.mostrar();
	     }else {
	    	 
	    	  mostrar_50(aux.sig);
	      }
	    } 
	
 //Muestra el vehiculo donde se encuentra anotado un cliente en especifico
 
 void mos_vehcon(vehiculos aux, String ci ){
	 
	try{
	 if( aux.c==null){
		 
		 System.out.println(" Error , lista de clientes vacia");
		 
	 } else{
			 
			if( aux.c== aux.aux.c){
				
			//System.out.println(" Introduzca el número de cedula del cliente")
				ci= leer.readLine();
				
			}
			  // buscar (String ci );
			// if( aux.buscar== true){
				 
				 aux.mostrar();
				 
			//	 else{
					 
					 if( aux.c != null){
						 
		//				 mos_vehcon(aux.c.sig);
					 }
				 }
					 
					 
		//		 }
			
				
	 	
			
	//	 }
	 
	 
 }catch(Exception e ){e.printStackTrace();}
	
 }
}