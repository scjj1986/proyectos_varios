import java.io.*;


public class vehiculos {

    
    public static void main(String[] args) {
		
try{
	
		vehiculo nodo_veh,aux_veh;
		consumidores nodo_cons,aux_cons;
		lista l=new lista();
		l.lv=null;
		
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
		System.out.println(" 1) Agregar Vehiculo");
		System.out.println(" 2) Agregar Clientes.");
		System.out.println(" 3) Mostrar vehiculos en los cuales se encuentra un cliente en especifico");
		System.out.println(" 4) Cantidad de clientes que esperan un carro cuyo precio es mayor o igual a  250.000");
		System.out.println(" 5) Mostrar la lista de clientes que esperan a un vehiculo");
		System.out.println(" 6) Cantidad de vehiculos que tienen una lista de espera mayor a 100 clientes");
		System.out.println(" 7) Mostrar aquellos vehculos cuya lista de espera sea igual o mayor a  50  clientes");
		System.out.println(" 0) SALIR" ) ;
		opc=Integer.parseInt(leer.readLine());
		
     	switch(opc){
		
     	 case 1: nodo_veh= new vehiculo();
     	 		 nodo_veh.llenarve();
     	 		 aux_veh=l.lv;
     	 		 nodo_veh.item=nodo_veh.nodos(l.lv,aux_veh)+1; 
     	 		 nodo_veh.c=null;
     	 		 l.agregar_vehiculo(nodo_veh);
     	 		 break;
	     case 2: if (l.lv==null){
	     		 
	     		 	System.out.println("No se puede agregar clientes porque no hay vehiculos registrados");
	     		 
	     		 
	     		 }
	     		 else{
	     		 	
	     		 nodo_cons=new consumidores();
	    		 nodo_cons.llenar();
	    		 aux_veh=l.lv;
	    		 aux_cons=l.lv.c;
	    		 l.registrar_consumidor(aux_cons,nodo_cons);	
	     		 	
	     		 }
	     		 break;
		case 3:if (l.lv==null){
	     		 
	     		 	System.out.println("Lista vacia.");
	     		 
	     		 
	     		 }
	     		 else{
	     		 	
	     		 	aux_cons=l.lv.c;
	     		 	l.buscar_consumidor(aux_cons);
	     		 	
	     		 	} break;
		case 4:if (l.lv==null){
	     		 
	     		 	System.out.println("La cantidad es 0.");
	     		 
	     		 
	     		 }
	     		 else{
	     		 	
	     		 	aux_cons=l.lv.c;
	     		 	System.out.println("La cantidad es: "+l.mayor_250000(aux_cons));
	     		 	
	     		 	} break;
		case 5:if (l.lv==null){
	     		 
	     		 	System.out.println("Lista vacia.");
	     		 
	     		 
	     		 }
	     		 else{
	     		 	
	     		 	aux_cons=l.lv.c;
	     		 	System.out.println("Listado de consumidores en espera.");
	     		 	System.out.println();
	     		 	System.out.println();
	     		 	l.listado_consumidores(aux_cons);
	     		 	
	     		 	} break;
		case 6:if (l.lv==null){
	     		 
	     		 	System.out.println("Lista vacia.");
	     		 
	     		 
	     		 }
	     		 else{
	     		 	
	     		 	aux_cons=l.lv.c;
	     		 	System.out.println("Listado de vehiculos con mas de 100 clientes en espera.");
	     		 	System.out.println();
	     		 	System.out.println();
	     		 	l.masde100cli(aux_cons);
	     		 	
	     		 	} break;
	     case 7:if (l.lv==null){
	     		 
	     		 	System.out.println("Lista vacia.");
	     		 
	     		 
	     		 }
	     		 else{
	     		 	
	     		 	aux_cons=l.lv.c;
	     		 	System.out.println("Listado de vehiculos con mas de 100 clientes en espera.");
	     		 	System.out.println();
	     		 	System.out.println();
	     		 	l.masde50cli(aux_cons);
	     		 	
	     		 	} break;
		case 0: System.out.println("Ha finalizado "); break;
		} 
		
	}while(opc!=0); 
	}catch(Exception e){e.printStackTrace();}

}
    
    
}

class consumidores {

	// LISTA DE CLIENTES EN ESPERA PARA OPTAR POR UN VEHICULO
	
	// LISTA DOBLEMENTE ENLAZADA  
	
	String nom,ape, ced,correo,tlf ;
	consumidores sig;
			
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
          System.out.println("Telefno:");
          tlf=leer.readLine();
      
             sig=null;
          
       }catch (Exception e ){e.printStackTrace();}

	
  }	

   // Muestra los datos de un cliente
  void mostrar (){
	  
	  System.out.println("Datos del cliente ");
      System.out.println("Cedula:"+ced);
      
      System.out.println("nombre:"+nom);
      
      System.out.println("Apellido:"+ ape);
      
      System.out.println("correo electronico"+correo);
      
      System.out.println("Telefno:"+tlf);
      
  
	  
    }
  
}

class vehiculo {

//LISTA ENLAZADA SIMPLE 
	
	String mar,mod; 
	double pre;
	int ano,item;
	vehiculo sig;
  	vehiculo aux;
	consumidores c;

	
 BufferedReader leer=new BufferedReader(new InputStreamReader(System.in));
 
 int nodos(vehiculo lv,vehiculo aux){
 	int i;
 	i=0;
 	while (aux!=null){
 		
 		aux=aux.sig;
 		i++;
 	}
 	return i;
 	
 	
 	
 }

//REGISTRAR UN CONSUMIDOR A LA LISTA DE ESPERA

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
			ano=Integer.parseInt(leer.readLine());

     	 }catch (Exception e) {num=0;System.err.println(" El año debe ser un entero");}
	 }
	 num=0;     	 
     	 while( num==0){ //validar que le usuarion introduzca un entero//
         	 try{
        	 	num=1;
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
	System.out.println("año"+ano);
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
    			//case 1:registrar_con(   ) ; break;
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
	   return con;
   }
   
   
   
}

class lista{
	
	vehiculo lv;
	BufferedReader leer=new BufferedReader(new InputStreamReader(System.in));
	 public void agregar_vehiculo(vehiculo nuevo){//metodo para agregar vehiculo en específico
	 vehiculo aux=lv;
 	
 	if (lv==null){//si la lista de vehicluos es nula...
 		
 		lv=nuevo;//..le asignamos el nodo nuevo
 	}
 	else{//sino, se recorre hasta llegar al nodo final
 		
 		while (aux.sig!=null){
 			
 			aux=aux.sig;
 		}
 		aux.sig=nuevo;
 	}
 	
 }
 
   public void registrar_consumidor(consumidores aux, consumidores nv) throws Exception{
  	//método para registrar un cliente
  	int num=0;
  	int valor=0;
  	boolean encontrado=false;
  	vehiculo auxv=lv;
  	//Se muestra la lista de los vehiculos disponibles...
  	System.out.println("Vehiculos disponibles:");
  	while (auxv!=null){
  		System.out.println("*Item: "+auxv.item);
  		System.out.println(" Marca: "+auxv.mar);
  		System.out.println(" Modelo: "+auxv.mod);
  		System.out.println(" Precio (Bs.): "+auxv.pre);
  		System.out.println();
  		System.out.println();
  		auxv=auxv.sig;
  	}
  	while( num==0){ //validar que el usuario introduzca un entero y que el item se encuente en la lista//
     try{
            num=1;
			System.out.println("Ingrese el item del vehículo que desea adquirir");
			valor=Integer.parseInt(leer.readLine());

     	 }catch (Exception e) {num=0;System.err.println(" El item debe ser un entero");}
     	 if (num!=0){
     	 	
     	 	auxv=lv;
     	 	while (auxv!=null){
     	 		
     	 		if(auxv.item==valor){//una vez encontrado se agrega al final de la lista del vehículo que eligió
     	 			encontrado=true;
     	 			
     	 			aux=auxv.c;
     	 			if (aux==null){
     	 				
     	 				auxv.c=nv;
     	 			}
     	 			else{
     	 			
     	 				while (aux.sig!=null){
     	 					
     	 					aux=aux.sig;
     	 				}
     	 				aux.sig=nv;	
     	 				
     	 			}
     	 			
     	 			System.out.println("Cliente guardado satisfactoriamente");
     	 			
     	 		}
     	 		auxv=auxv.sig;
     	 		
     	 		}
     	 		
     	 	  if (encontrado==false){
     	 	  	
     	 	  	num=0;
				System.out.println("Item no encontrado. Ingreselo de nuevo");
				valor=Integer.parseInt(leer.readLine());
     	 	  }
     	 	
     	 	}
     	 	  	 	
	 }
               
	}
	
	public void buscar_consumidor(consumidores aux) throws Exception{//buscar cliente
		
		
		int num=0;
		String valor;
		boolean encontrado=false;
		System.out.println("Ingrese la cedula del consumidor a buscar:");
		valor=leer.readLine();
	   vehiculo auxv=lv;
	   while (auxv!=null){//recorrer lista de vehiculo
	   	
	   		aux=auxv.c;
	   		
	   		while (aux!=null){//recorrer lista de clientes a un vehícluo específico
	   			if (Integer.parseInt(valor)==Integer.parseInt(aux.ced)){//si hay coincidencia, se muestra
	   				if (encontrado==false){
	   					
	   					System.out.println("Datos de la persona:");
	   					System.out.println("*Cedula: "+aux.ced);
  						System.out.println(" Nombre: "+aux.nom);
  						System.out.println(" Apellido: "+aux.ape);
  						System.out.println(" Telefono: "+aux.tlf);
  						System.out.println(" E-mail: "+aux.correo);
  						encontrado=true;
	   				}
	   				System.out.println();
	   				System.out.println();
	   				System.out.println("Datos del vehiculo:");
	   				System.out.println(" Marca: "+auxv.mar);
  					System.out.println(" Modelo: "+auxv.mod);
  					System.out.println(" Precio (Bs.): "+auxv.pre);
	   				
	   			}
	   			aux=aux.sig;
	   			
	   		}
	   		auxv=auxv.sig;
	   }
	   if (encontrado==false){//de no encontrrse, se muestra el mensaje de no coincidencias
	   		System.out.println();
	   		System.out.println();
	   		System.out.println("No hubo coincidencias");
	   	
	   	
	   }
	   
	
	}
	
	public int mayor_250000(consumidores aux) throws Exception{
		
	   int cont=0;
	   vehiculo auxv=lv;
	   while (auxv!=null){
	   	
	   		aux=auxv.c;	
	   		while (aux!=null){
	   			if (auxv.pre>=250000){//Si la lista de turno, pertenece a un vehículo con precio mayor a 250000 Bs, se autoincrementa la variable cont
	   				cont++;
	   				
	   			}
	   			aux=aux.sig;
	   			
	   		}
	   		auxv=auxv.sig;
	   }
	   return cont;//El método devolverá el valor que tenga cont
	
	}
	
	public void listado_consumidores(consumidores aux) throws Exception{//Recorrido de la listas de vehículo, para mostrat la sublista de clientes en espera	
	   vehiculo auxv=lv;
	   while (auxv!=null){
	   		aux=auxv.c;
	   		while (aux!=null){	
	   					System.out.println("Datos de la persona:");
	   					System.out.println("*Cedula: "+aux.ced);
  						System.out.println(" Nombre: "+aux.nom);
  						System.out.println(" Apellido: "+aux.ape);
  						System.out.println(" Telefono: "+aux.tlf);
  						System.out.println(" E-mail: "+aux.correo);
  						System.out.println();
  						System.out.println();
	   			aux=aux.sig;
	   			
	   		}
	   		auxv=auxv.sig;
	   		
	   		}
	   
	
	}
	
	public void masde100cli(consumidores aux) throws Exception{
		int cont;	
	   vehiculo auxv=lv;
	   boolean encontrado=false;
	   while (auxv!=null){
	   		aux=auxv.c;
	   		cont=0;
	   		while (aux!=null){//se contabiliza cada nodo de la sublista de clientes de un vehículo en específico	
	   		    cont++;
	   			aux=aux.sig;
	   			
	   		}
	   		if (cont>100){//si hay más de 100 clientes en espera vinculados a un vehículo determinado...
	   			encontrado=true;
	   			System.out.println("Datos del vehiculo:");
	   			System.out.println(" Marca: "+auxv.mar);
  				System.out.println(" Modelo: "+auxv.mod);
  				System.out.println(" Precio (Bs.): "+auxv.pre);
  				System.out.println();
  				System.out.println();
	   			//se muestra en pantalla
	   			
	   		}
	   		auxv=auxv.sig;
	   		
	   		}
	   		
	   		if (encontrado==false){
	   			
	   			System.out.println("No hubo coincidencias");
	   		}
	   
	
	}
	
	public void masde50cli(consumidores aux) throws Exception{
		int cont;	
	   vehiculo auxv=lv;
	   boolean encontrado=false;
	   while (auxv!=null){
	   		aux=auxv.c;
	   		cont=0;
	   		while (aux!=null){//se contabiliza cada nodo de la sublista de clientes de un vehículo en específico	
	   		    cont++;
	   			aux=aux.sig;
	   			
	   		}
	   		if (cont>=50){//si hay más de 100 clientes en espera vinculados a un vehículo determinado...
	   			encontrado=true;
	   			System.out.println("Datos del vehiculo:");
	   			System.out.println(" Marca: "+auxv.mar);
  				System.out.println(" Modelo: "+auxv.mod);
  				System.out.println(" Precio (Bs.): "+auxv.pre);
  				System.out.println();
  				System.out.println();
	   			
	   			
	   		}
	   		auxv=auxv.sig;
	   		
	   		}
	   		//se muestra en pantalla
	   		if (encontrado==false){
	   			
	   			System.out.println("No hubo coincidencias");
	   		}
	   
	
	}
	
	
}
