import java.io.BufferedReader;

import java.io.InputStreamReader;

import java.io.FileWriter;

import java.io.FileReader;

/**
 * Proyecto Información asegurada
 *
 * Bachilleres:
 *
 * Salazar,Juan 
 *
 * C.I.: 17.846.688
 *
 * Mata,Jhonatan
 *
 * C.I,: 18.401.436 
 */
public class PROYECTO1 
{
	
	static class fecha//Clase para registrar fecha(s)
	{
		
		int dia;
		
		int mes;
		
		int year;
		
		public void llenar() throws Exception
		{
			
		    BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		   
		    System.out.println("Ingrese el año \n");
		    
		    year = Integer.parseInt(teclado.readLine());
		    
		    System.out.println();
		    
		    while (year <= 0)
		    {
		    	
		    	System.out.println("El año debe ser mayor que 0. Ingrese nuevamente el año");
		    
		        year = Integer.parseInt(teclado.readLine());
		        
		        System.out.println();
		        
		    }
		    
		    System.out.println("Ingrese el mes \n");
		    
		    mes = Integer.parseInt(teclado.readLine());
		    
		    System.out.println();
		    
		    while ((mes <= 0) || (mes > 12))
		    {
		    	
		    	System.out.println("El mes debe oscilar entre 1 y 12. Ingrese nuevamente el mes");
		    
		        mes = Integer.parseInt(teclado.readLine());
		        
		        System.out.println();
		        
		    }
		    
		    System.out.println("Ingrese el dia \n");
		    
		    dia = Integer.parseInt(teclado.readLine());
		    
		    System.out.println();
		    
		    if ((mes == 1) || (mes == 3) || (mes == 5) || (mes == 7) || (mes == 8) || (mes == 10) || (mes ==12))
		    {
		    	
		    	while ((dia <=0) || (dia > 31))
		    	{
		    		
		    	    System.out.println("El dia debe oscilar entre 1 y 31. Ingrese nuevamente el dia");
		    
		            dia = Integer.parseInt(teclado.readLine());
		            
		            System.out.println();	
		    	}
		    }
		    
		    if ((mes == 4) || (mes == 6) || (mes == 9) || (mes == 11))
		    {
		    	
		    	while ((dia <=0) || (dia > 30))
		    	{
		    		
		    	    System.out.println("El dia debe oscilar entre 1 y 30. Ingrese nuevamente el dia");
		    
		            dia = Integer.parseInt(teclado.readLine());
		            
		            System.out.println();	
		    	}
		    }
		    
		    if (mes == 2)
		    {
		    	
		    	while ((dia <=0) || (dia > 28))
		    	{
		    		
		    	    System.out.println("El dia debe oscilar entre 1 y 28. Ingrese nuevamente el dia");
		    
		            dia = Integer.parseInt(teclado.readLine());
		            
		            System.out.println();	
		    	}
		    	
		    } 
		}//Método empleado para ingresar cualquier fecha específica por el usuario,con sus respectivas validaciones
		
		public boolean menorigual(fecha a,fecha b) throws Exception
		{
			
			if (a.year > b.year)
		    {
		    	
		    	return false;
		    	
		    }
		    
		    if (a.year == b.year)
		    {
		    	
		       if (a.mes > b.mes)
		       {
		       	
		       	  return false;
		       	  
		       }
		       
		       if (a.mes == b.mes)
		       {
		       	
		       	  if (a.dia > b.dia)
		       	  {
		       	  	
		       	  	 return false;
		       	  }
		       	  
		       	  else
		       	  {
		       	  	
		       	  	 return true;
		       	  	 
		       	  }
		       	  
		       }
		       
		       if (a.mes < b.mes)
		       {
		       	
		       	  return true;
		       	  
		       }   
		       
		    }
		    
		    if (a.year < b.year)
		    {
		       	
		       return true;
		       	  
		    }
		    
		    return true;
		}//Metodo que compara dos fechas,cuyo método devuelve un valor de tipo lógico si una fecha es menor o igual que otra fecha
		
	}
	
	static class asegurado//Clase para registrar los datos de póliza de un cliente
	{
		
		int n_poliza;
		
		fecha fecha_adq;
		
		fecha fecha_venc;
		
		ing_egr ing;
		
		public void llenar(fecha fecha_actual) throws Exception//Metodo que procesa los datos de póliza de cada cliente(ingresos monetarios)
		{
			
           
           
           fecha aux;//Se declara un objeto auxiliar de tipo fecha
           
           boolean salir = false;
           
           aux = new fecha();
           
           fecha_adq = new fecha();
           
           fecha_venc = new fecha();
           
           ing = new ing_egr();
           
           aux = fecha_actual;//Se le asigna al auxiliar la fecha actual
		   
		   BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		   
		   System.out.println("Introduzca el numero de poliza \n ");
		   
		   n_poliza = Integer.parseInt(teclado.readLine());
		   
		   System.out.println();
		   
		   System.out.println("Tipo de asegurado : natural o juridico \n ");
		   
		   ing.tipo_cli = teclado.readLine();
		   
		   System.out.println();
		   
		   while ((ing.tipo_cli.compareTo("natural") != 0) && (ing.tipo_cli.compareTo("juridico") != 0))//Validación:Mientras que el tipo de asegurado procesado no sea natural ni jurídico
		   {
		   	   
		   	   System.out.println("Tipo de cliente invalido. Ingrese nuevamente el tipo de cliente \n ");//Mensaje de error
		   
		       ing.tipo_cli = teclado.readLine();//Se procesa nuevamente el tipo de asegurado
		       
		       System.out.println();
		       
		   }
		   
		   if(ing.tipo_cli.compareTo("natural") == 0)//Si el tipo de asegurado es natural
		   {
		   	   
		   	   System.out.println("Nombre del cliente \n ");
		   
		       ing.nombre = teclado.readLine();
		       
		       System.out.println();
		       
		       System.out.println("Cedula del cliente \n ");
		   
		       ing.cedula = Integer.parseInt(teclado.readLine());
		       
		       System.out.println();
		       
		       while(ing.cedula <=0)//Validación: Si la cédula procesada es menor o igual que 0
		       {
		       	  
		       	  System.out.println("El numero de cedula debe ser mayor que 0. Ingrese nuevamente la cedula del cliente \n ");//Mensaje de error
		   
		          ing.cedula = Integer.parseInt(teclado.readLine());//Se procesa nuevamente el número de cédula del cliente
		          
		          System.out.println();
		          
		       }
		       
		   }
		   
		   else//Si no
		   {
		   	
		   	   System.out.println("Ingrese el RIF (Registro Interno Fiscal) \n ");
		   
		       ing.rif = teclado.readLine();
		       
		       System.out.println();
		       
		   }
		   
		   System.out.println("Concepto de la poliza \n ");
		   
		   ing.concepto = teclado.readLine();
		   
		   System.out.println();
		   
		   System.out.println("A continuacion debera ingresar la fecha de adquisicion del seguro \n ");
		   
		   fecha_adq.llenar();//Se procesa la fecha de adquisición del seguro 
		   
		   while (fecha_adq.menorigual(fecha_adq,aux) == false)//Validación: Mientras que la fecha de adquisición del seguro es mayor que aux(fecha actual)...........
		   {
		   	
		   	    System.out.println("La fecha de adquisicion debe ser menor que la fecha actual. Ingrese nuevamente la fecha de adquisicion \n ");//Mensaje de error
		   	    
		   	    fecha_adq.llenar();//Se procesa nuevamente la fecha de adquisición del seguro
		   	    
		   }
		   
		   System.out.println("Ahora debera ingresar la fecha de vencimiento del seguro \n ");
		   
		   fecha_venc.llenar();//Se procesa la fecha de vencimiento del seguro
		   
		   while (fecha_venc.menorigual(fecha_venc,fecha_adq) == true)//Validación: Mientras que la fecha de vencimiento del seguro es menor que la fecha de adquisición.............
		   {
		   	
		   	    System.out.println("La fecha de vencimiento debe ser mayor que la fecha de adquisicion. Ingrese nuevamente la fecha de vencimiento \n ");//Mensaje de error
		   	    
		   	    fecha_venc.llenar();//Se procesa nuevamente la fecha de vencimiento del seguro
		   	    
		   }
		   
		   System.out.println("A continuacion debera ingresar la fecha del pago de poliza \n ");
           
           ing.fech.llenar();//Se procesa la fecha de pago de póliza
		   
		   while(salir == false)//Validación de la fecha de pago de la póliza en 3 casos:
		   {
		   	   
		   	  salir = true;
		   	  
		   	  if (ing.fech.menorigual(ing.fech,aux) == false)//Caso 1: Si la fecha de pago es mayor que la fecha actual
		      {
		   	
		   	      System.out.println("La fecha del pago de poliza debe ser menor que la fecha actual. Ingrese nuevamente la fecha del pago de poliza \n ");//Mensaje de error
		   	      
		   	      salir = false;
		   	    
		      }
		      
		      else//Si la fecha de pago es menor que la fecha actual.....
		      {
		      	
		      	  if (ing.fech.menorigual(fecha_venc,ing.fech) == true)//Caso 2: Si la fecha de pago es mayor que la fecha de vencimiento
		      	  {
		      	  	
		      	  	 System.out.println("La fecha del pago de poliza debe ser menor que la fecha de vencimiento. Ingrese nuevamente la fecha del pago de poliza \n ");//Mensaje de error
		      	  	 
		      	  	 salir = false; 
		      	  }
		      	  
		      	  if (ing.fech.menorigual(fecha_adq,ing.fech) == false)//Caso 3: Si la fecha de pago es menor que la fecha de adquisición
		      	  {
		      	  	  
		      	  	 System.out.println("La fecha del pago de poliza debe ser mayor que la fecha de adquisicion. Ingrese nuevamente la fecha del pago de poliza \n ");//Mensaje de error
		   	    
		   	         salir = false;
		      	  }
		      	  
		      }
		      
		      if (salir == false)//Si la fecha de pago coincide con alguno de los casos planteados previamente................
		      {
		      	
		      	  ing.fech.llenar();//Se procesa nuevamente la fecha de pago de póliza
		      	  
		      }
		       
		   }
		   
		   
		   
		   System.out.println("Introduzca el monto del pago de poliza \n ");
		   
		   ing.monto = Integer.parseInt(teclado.readLine());
		   
		   System.out.println();
		   
		   while(ing.monto <= 0)//Validación:Mientras que el monto procesado sea menor o igual a 0
           { 
      
              System.out.println("El monto debe ser mayor que 0. Ingrese nuevamente el monto de pago de la poliza \n ");//Mensaje de error
      
              ing.monto = Integer.parseInt(teclado.readLine());//Se procesa nuevamente el monto
              
              System.out.println();
              
           }
		  
		}
		
	}
	
	static class ing_egr//Clase para procesar un egreso o ingreso de la compañía de seguro
	{
		
		fecha fech = new fecha();
		
		String concepto;
		
		int monto;
		
		String tipo_cli;
		
		String nombre;
		
		int cedula;
		
		String rif;
		
	
    }
    public static void main(String[] args) throws Exception 
    {
      
      BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		   
      int tamanho = 0;
      
      int tamanho2 = 0;
      
      int cont = 0;
      
      int cont2 = 0;
      
      int cont3 = 0;
      
      int n_poliza;
      
      int natural = 0;//Variable que evalúa la cantidad de clientes de tipo natural
      
      int juridico = 0;//Variable que evalúa la cantidad de clientes de tipo juridico
      
      int ganancia = 0;//Variable que evalúa los ingresos monetarios totales de la compañía
      
      int perdida = 0;//Variable que evalúa los egresos monetarios totales de la compañía
      
      int ganancia2 = 0;//Variable que evalúa los ingresos monetarios desde una fecha dada hasta la actual
      
      int perdida2 = 0;//Variable que evalúa los egresos monetarios desde una fecha dada hasta la actual
      
      fecha aux = new fecha();
      
      fecha aux2 = new fecha();
      
      fecha aux3 = new fecha();
      
      fecha aux4 = new fecha();
      
      boolean encontrado;
      
      boolean salir;
      
      asegurado arreing [];//Se declara un arreglo de objetos de tipo asegurado,el cual almacenará los datos de los clientes y los datos de sus ingresos(pago de número de póliza) 
      
      ing_egr arreegr [];//Se declara un arreglo de objetos de tipo ing_egr,el cual almacenará los datos de los egresos monetarios y los datos de los clientes que corresponden a dicho egreso
      
      System.out.println("##################### Seguros NPI(Nadie Puede Identicarlo) ##################### \n ");
		   
	  fecha fecha_actual = new fecha();
		   
	  System.out.println("Ingrese la fecha actual \n ");
      
      fecha_actual.llenar();//Se procesa la fecha actual
      
      System.out.println("Ingrese la cantidad de clientes existentes en la compañia \n ");
      
      tamanho = Integer.parseInt(teclado.readLine());
      
      System.out.println();
      
      while(tamanho <= 0)//Validación: Mientras que la cantidad de clientes es menor o igual que 0
      { 
      
          System.out.println("La cantidad de clientes debe ser mayor que 0. Ingrese la cantidad de clientes a procesar \n ");
      
          tamanho = Integer.parseInt(teclado.readLine());//Se procesa nuevamente la cantidad de clientes
          
          System.out.println();
      }
      
      arreing = new asegurado [tamanho];//Se le asigna el tamaño al arreglo de objetos de acuerdo a la cantidad de clientes previamente solicitada
      
      for( cont = 0; cont < tamanho; cont++)//Se procesa cliente por cliente
      {
      	  
      	  System.out.println("-------------------------- Procesando cliente # "+(cont+1)+" ------------------------------ \n ");
      	  
      	  arreing[cont] = new asegurado();
      	  
      	  arreing[cont].llenar (fecha_actual);//Se procesa los datos de póliza de cada cliente(ingresos monetarios)
      	  
      	  ganancia += arreing[cont].ing.monto;
      	  
      	  cont2 = cont;
      	  	
      	  while (cont2 > 0)//Validación: Se verifica si el número de póliza registrado por el cliente recién procesado esté repetido
      	  {
      	  	  
      	  	  cont2--;
      	  	  
      	  	  
      	  	  if (arreing[cont].n_poliza == arreing[cont2].n_poliza)//Si es repetido
      	  	  {
      	  	  	 
      	  	  	 System.out.println("Error.el numero de poliza ingresado pertenece a otro cliente previamente procesado \n " );//Mensaje de error
       	   	    
       	   	     System.out.println("Ingrese nuevamente el numero de poliza del cliente \n " );
       	   	     
       	   	     arreing[cont].n_poliza = Integer.parseInt(teclado.readLine());//Se procesa nuevamente el número de póliza
       	   	     
       	   	     System.out.println();
      	  	  	 
      	  	  	 cont2 = cont;
      	  	  	 
      	  	  }
      	  	  
      	  }
      	  
      	  cont2 = cont;
      	  
      	  while (cont2 > 0)//Validación: Se verifica si el número de cedula o RIF registrado por el cliente recién procesado esté repetido
      	  { 
      	  	  
      	  	  cont2--;
      	  	  
      	  	  if ((arreing[cont].ing.tipo_cli.compareTo("natural") == 0) && (arreing[cont2].ing.tipo_cli.compareTo("natural") == 0))
      	  	  {
      	  	  	 
      	  	  	 if (arreing[cont].ing.cedula == arreing[cont2].ing.cedula)//Si la cédula es repetida
      	  	     {
      	  	  	 
      	  	  	    System.out.println("Error.el numero de cedula ingresado pertenece a otro cliente previamente procesado \n " );//Mensaje de error
       	   	    
       	   	        System.out.println("Ingrese nuevamente la cedula del cliente \n " );
      	  	  	 
      	  	  	    arreing[cont].ing.cedula = Integer.parseInt(teclado.readLine());//Se procesa nuevamente la cedula
      	  	  	    
      	  	  	    System.out.println();
      	  	  	    
      	  	  	    cont2 = cont;
      	  	  	  
      	  	     }
      	  	     
      	  	  }
      	  	  
      	  	  if ((arreing[cont].ing.tipo_cli.compareTo("juridico") == 0) && (arreing[cont2].ing.tipo_cli.compareTo("juridico") == 0))
      	  	  {
      	  	  	 
      	  	  	 if (arreing[cont].ing.rif.compareTo(arreing[cont2].ing.rif) == 0)//Si el rif es repetido
      	  	     {
      	  	  	 
      	  	  	    System.out.println("Error.el rif ingresado pertenece a otro cliente previamente procesado \n " );//Mensaje de error
       	   	    
       	   	        System.out.println("Ingrese nuevamente el rif del cliente \n " );
      	  	  	 
      	  	  	    arreing[cont].ing.rif = teclado.readLine();//Se procesa nuevamente el rif
      	  	  	    
      	  	  	    System.out.println();
      	  	  	    
      	  	  	    cont2 = cont;
      	  	  	  
      	  	     }
      	  	     
      	  	  }	  	  
      	  	  
      	  } 	         	  
      	  
      }
      
      System.out.println("--------------------------------------------------------------------------------\n");
      
      System.out.println("Introduzca la cantidad de clientes a procesar en la lista de egresos monetarios de la compañia de seguros  \n " );
      
      tamanho2 = Integer.parseInt(teclado.readLine());
      
      System.out.println();
      
      while ((tamanho2 < 1) || (tamanho2 > tamanho))//Validación: Mientras que la cantidad de clientes sea menor que 1 ó mayor que la cantidad de clientes procesados en la lista de ingresos previamente registrada
      { 
      
            System.out.println("La cantidad de clientes debe oscilar entre 1 y "+tamanho+". Ingrese la cantidad de clientes a procesar \n ");//Mensaje de error
      
            tamanho2 = Integer.parseInt(teclado.readLine());//Se procesa nuevamente la cantidad de clientes
          
            System.out.println();
            
      }
      
      arreegr = new ing_egr [tamanho2];//Se le asigna el tamaño al arreglo de objetos de acuerdo a la cantidad de clientes previamente solicitada
      
      for (cont = 0; cont < tamanho2; cont++)
      {
      	 
      	  arreegr[cont] = new ing_egr();
      	  
      	  System.out.println("++++++++++++++++++++++++++ Procesando cliente # "+(cont+1)+" ++++++++++++++++++++++++++++++ \n ");
      	  
      	  System.out.println("Ingrese el numero de poliza correspondiente a un cliente en especifico\n");
      	  
      	  n_poliza = Integer.parseInt(teclado.readLine());
      	  
      	  System.out.println();
      	  
      	  cont2 = 0;
      	  
      	  salir = false;
      	  
      	  encontrado = false;
      	  
      	  while (salir == false)//Validación: Mientras que el número de póliza sea repetido ó no aparezca registrado
      	  {
      	  	   
      	  	   while (encontrado == false)//Validación: Mientras que ingrese un número de póliza que no se encuentre en la lista de ingresos
      	       {
      	  	
      	  	        if (n_poliza == arreing[cont2].n_poliza)//Si se encontró
      	  	        {
      	  	 	       
      	  	 	       cont3 = cont2;//Se almacena en cont3 la posición del cliente en el cual coincidió con el número de póliza
      	  	 	
      	  	 	       encontrado = true;
      	  	 	       
      	  	 	       salir = true;	
      	  	 	
      	  	        }
      	  	        
      	  	        cont2++;
      	  	 
      	  	        if ((cont2 == tamanho) && (encontrado == false))//Si no
      	  	        {
      	  	 	
      	  	 	       System.out.println("Error. Numero de poliza no encontrado. Ingrese nuevamente el numero de poliza\n");//Mensaje de error
      	  
      	               n_poliza = Integer.parseInt(teclado.readLine());
      	               
      	               System.out.println();
      	        
      	               cont2 = 0;
      	        
      	  	        }
      	  	        
      	  	    }    
      	  	 
      	  	    cont2  = cont;
      	  	 
      	  	    while (cont2 > 0)//Validación: Mientras que ingrese un número de póliza repetido
      	  	    {
      	  	 	
      	  	 	     cont2--;
      	  	 	  
      	  	 	     if ((arreing[cont3].ing.tipo_cli.compareTo("natural") == 0) && (arreegr[cont2].tipo_cli.compareTo("natural") == 0))
      	  	 	     {
      	  	 	     
      	  	 	        if (arreegr[cont2].cedula == arreing[cont3].ing.cedula)
      	  	 	        {
      	  	 	  	 
      	  	 	  	        System.out.println("Error.El numero de poliza introducido corresponde a un cliente previamente procesado en la lista de egresos. Ingrese nuevamente el numero de poliza\n");//Mensaje de error
      	  
      	                    n_poliza = Integer.parseInt(teclado.readLine());//Se procesa nuevamente el numero de póliza
      	                 
      	                    System.out.println();
      	                 
      	                    salir = false;
      	                 
      	                    encontrado = false;
      	                    
      	                    cont2 = 0;
      	                 
      	  	 	        }     	  	 	       
      	  	 	        
      	  	         }
      	  	         
      	  	         if ((arreing[cont3].ing.tipo_cli.compareTo("juridico") == 0) && (arreegr[cont2].tipo_cli.compareTo("juridico") == 0))
      	  	         {
      	  	         	
      	  	         	if (arreegr[cont2].rif.compareTo(arreing[cont3].ing.rif) == 0)
      	  	 	        {
      	  	 	  	 
      	  	 	  	        System.out.println("Error.El numero de poliza introducido corresponde a un cliente previamente procesado en la lista de egresos. Ingrese nuevamente el numero de poliza\n");//Mensaje de error 
      	  
      	                    n_poliza = Integer.parseInt(teclado.readLine());
      	                 
      	                    System.out.println();
      	                 
      	                    salir = false;
      	                 
      	                    encontrado = false;
      	                    
      	                    cont2 = 0;
      	                 
      	  	 	        }
      	  	 	        
      	  	         }
      	         
      	        }
      	        
      	  }           
      	  
      	  if (arreing[cont3].ing.tipo_cli.compareTo("natural") == 0)
      	  {
      	  	
      	  	 natural++;

      	  	 System.out.println("El numero de poliza ingresado pertenece a un asegurado de tipo natural, cuyos datos personales son:\n");
      	  	 
      	  	 System.out.println("Nombre: "+arreing[cont3].ing.nombre+" \n");
      	  	  
      	  	 System.out.println("Cedula: "+arreing[cont3].ing.cedula+" \n");
      	  	 
      	  	 System.out.println();
      	  	 
      	  	 arreegr[cont].nombre = arreing[cont3].ing.nombre;
      	  	 
      	  	 arreegr[cont].cedula = arreing[cont3].ing.cedula;
      	  	 
      	  }
      	  
      	  else
      	  {
      	  	
      	  	  juridico ++;
      	  	  
      	  	  System.out.println("El numero de poliza ingresado pertenece a un cliente de tipo juridico, cuyo RIF es: "+arreing[cont3].ing.rif+"\n");
      	  	  
      	  	  arreegr[cont].rif = arreing[cont3].ing.rif;
      	  	  
      	  	  
      	  }
      	  
      	  arreegr[cont].concepto = arreing[cont3].ing.concepto;
      	  	 
      	  arreegr[cont].tipo_cli = arreing[cont3].ing.tipo_cli;       
      	  
      	  System.out.println("Introduzca el monto de egreso \n");
      	  	 
      	  arreegr[cont].monto = Integer.parseInt(teclado.readLine());
      	  	 
      	  System.out.println();
		   
		  while (arreegr[cont].monto <= 0)//Validación: Si el monto es menor o igual a 0
          { 
      
               System.out.println("El monto debe ser mayor que 0. Ingrese nuevamente el monto de egreso \n ");//Mensaje de error
      
               arreegr[cont].monto = Integer.parseInt(teclado.readLine());//Se procesa nuevamente el monto
              
               System.out.println();
              
          }
          
          perdida += arreegr[cont].monto;
          
          System.out.println("Introduzca la fecha de egreso \n");
          
          System.out.println();
          
          arreegr[cont].fech.llenar();//Se procesa la fecha de egreso
          
          aux = arreegr[cont].fech;//Se le asigna a aux la fecha de egreso recién procesada 
          
          aux2 = arreing[cont3].ing.fech;//Se le asigna a aux2 la fecha de ingreso de la posición del cliente en el cual coincidió con el número de póliza      	  	 	
          
          aux3 = arreing[cont3].fecha_venc;//Se le asigna a aux2 la fecha de vencimiento de la posición del cliente en el cual coincidió con el número de póliza
          
          salir = false;
          
          while(salir == false)//Validacion a la fecha de egreso en 3 casos:
		  {
		   	   
		   	  salir = true;
		   	  
		   	  if (arreegr[cont].fech.menorigual(aux,fecha_actual) == false)//Caso 1: Si la fecha de egreso es mayor que la fecha actual
		      {
		   	
		   	      System.out.println("La fecha de egreso debe ser menor o igual que la fecha actual. Ingrese nuevamente la fecha de egreso \n ");//Mensaje de error
		   	      
		   	      salir = false;
		   	    
		      }
		      
		      else//Si es menor..........
		      {
		      	
		      	  if (arreegr[cont].fech.menorigual(aux3,aux) == true)//Caso 2: Si la fecha de egreso es mayor que la fecha de vencimiento
		      	  {
		      	  	
		      	  	 System.out.println("La fecha de egreso debe ser menor que la fecha de vencimiento del seguro. Ingrese nuevamente la fecha de egreso \n ");//Mensaje de error
		      	  	 
		      	  	 salir = false; 
		      	  }
		      	  
		      	  if (arreegr[cont].fech.menorigual(aux2,aux) == false)//Caso 3: Si la fecha de egreso es menor que la de ingreso 
		      	  {
		      	  	  
		      	  	 System.out.println("La fecha de egreso debe ser mayor que la fecha de pago de poliza. Ingrese nuevamente la fecha de egreso \n ");//Mensaje de error
		   	    
		   	         salir = false;
		      	  }
		      	  
		      }
		      
		      if (salir == false)//Si la fecha coincidió con alguno de los casos recientemente formulados........
		      {
		      	
		      	  aux.llenar();//Se procesa nuevamente aux
		      	  
		      }
		       
		  }
		  
		  arreegr[cont].fech = aux;//Una vez validada la fecha de egreso(contenida en aux),se le asigna a la fecha de la lista de egresos 	  	  	  
      	  
      }
      
      System.out.println("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
      
      if (natural > juridico)
      {
      	
      	System.out.println("Tipo de asegurado que ha recibido mas beneficios por parte del seguro: natural \n");
      	
      }
      
      else
      {
      	
      	 if ( natural < juridico)
      	 {
      	 	
      	 	System.out.println("Tipo de asegurado que ha recibido mas beneficios por parte del seguro: juridico \n");
      	 }
      	 
      	 else
      	 {
      	 	
      	 	System.out.println("Ambos tipos de asegurados han recibido la misma cantidad de beneficios por parte del seguro \n");
      	 }
      	 
      }
      
      System.out.println("Introduzca una fecha en especifico para determinar la cantidad de ganancia o perdida hasta la fecha actual \n");
      
      aux4.llenar();//La fecha ingresada se guardará en aux4
      
      while (aux.menorigual(fecha_actual,aux4) == true)//Validación: Mientras que la fecha es mayor que la fecha actual
      {
      	
      	System.out.println("La fecha debe ser menor que la fecha actual. Ingrese nuevamente la fecha \n");//Mensaje de error
      	
      	aux4.llenar();//Se procesa nuevamente la fecha solicitada
      }
      
      for (cont = 0; cont < tamanho; cont++)
      {
      	
      	 cont2 = cont;
      	 
      	 aux2 = arreing[cont].ing.fech;//en aux2 se guarda momentáneamente la fecha de ingreso
      	 
      	 if (aux.menorigual(aux4,aux2) == true)//Si la fecha de ingreso es mayor que la fecha solicitada
      	 {
      	 	
      	 	ganancia2 += arreing[cont].ing.monto;
      	 	
      	 }
      	 
      	 if (cont2 < tamanho2)
      	 {
      	 	
      	 	aux2 = arreegr[cont].fech;//en aux2 se guarda momentáneamente la fecha de egreso
      	 	
      	 	if (aux.menorigual(aux4,aux2) == true)//Si la fecha de egreso es mayor que la fecha solicitada
      	 	{
      	 		
      	 		perdida2 += arreegr[cont2].monto;
      	 		
      	 	}
      	 	
      	 }
      	 
      }
      
      if (ganancia2 > perdida2)
      {
      	
      	 System.out.println("Desde el "+aux4.dia+"/"+aux4.mes+"/"+aux4.year+" hasta la fecha actual se obtuvo un monto de ganancia de "+(ganancia2 - perdida2)+" Bs \n");
      	 
      }
      
      else
      {
      	
      	 if (ganancia2 < perdida2)
         {
      	
      	    System.out.println("Desde el "+aux4.dia+"/"+aux4.mes+"/"+aux4.year+" hasta la fecha actual se obtuvo un monto de perdida de "+(perdida2 - ganancia2)+" Bs \n");
      	    
         }
      
         else
         {
      	
      	    System.out.println("Desde el "+aux4.dia+"/"+aux4.mes+"/"+aux4.year+" hasta la fecha actual no hubo ganancia ni perdida\n");
      	    
         }
         
      }
      
      String entrada_txt = "entrada.txt";
      
      FileWriter fw = new FileWriter (entrada_txt);//Cargando datos en el archivo entrada.txt
      
      fw.write("**************************** Archivo entrada.txt *******************************\n");
      
      fw.write("                                                      Fecha actual: "+fecha_actual.dia+"/"+fecha_actual.mes+"/"+fecha_actual.year+" \n");//Cargando datos en el archivo entrada.txt
      
      fw.write("\n");
      
      fw.write("========= Lista de ingresos monetaros de los clientes de la compañia ===========\n");
      
      for (cont = 0;cont < tamanho; cont ++)
      {
      	 
      	 if (arreing[cont].ing.tipo_cli.compareTo("natural") == 0)
      	 {
      	 	
      	 	fw.write(" Cliente # " +(cont+1));
      	 	
      	 	fw.write(" \n");
      	 	
      	 	fw.write("Tipo de asegurado: natural || Nombre: "+arreing[cont].ing.nombre+" || Cedula: "+arreing[cont].ing.cedula+" || Numero de Poliza: "+arreing[cont].n_poliza+" || Concepto del seguro: "+arreing[cont].ing.concepto+" || Fecha de adquisicion: "+arreing[cont].fecha_adq.dia+"/"+arreing[cont].fecha_adq.mes+"/"+arreing[cont].fecha_adq.year+" || Fecha de vencimiento: "+arreing[cont].fecha_venc.dia+"/"+arreing[cont].fecha_venc.mes+"/"+arreing[cont].fecha_venc.year+" || Fecha de pago: "+arreing[cont].ing.fech.dia+"/"+arreing[cont].ing.fech.mes+"/"+arreing[cont].ing.fech.year+" || Monto pagado: "+arreing[cont].ing.monto+" Bs \n");
      	 	
      	 	fw.write("\n");
      	 	
      	 }
      	 
      	 else
      	 {
      	 	
      	 	fw.write("Cliente # " +(cont+1));
      	 	
      	 	fw.write("\n");
      	 	
      	 	fw.write("Tipo de asegurado: juridico || RIF: "+arreing[cont].ing.rif+" || Numero de Poliza: "+arreing[cont].n_poliza+" || Concepto del seguro: "+arreing[cont].ing.concepto+" || Fecha de adquisicion: "+arreing[cont].fecha_adq.dia+"/"+arreing[cont].fecha_adq.mes+"/"+arreing[cont].fecha_adq.year+" || Fecha de vencimiento: "+arreing[cont].fecha_venc.dia+"/"+arreing[cont].fecha_venc.mes+"/"+arreing[cont].fecha_venc.year+" || Fecha de pago: "+arreing[cont].ing.fech.dia+"/"+arreing[cont].ing.fech.mes+"/"+arreing[cont].ing.fech.year+" || Monto pagado: "+arreing[cont].ing.monto+" Bs");
      	 	
      	 	fw.write("\n");
      	 	
      	 }
      	 
      }
      
      fw.write("========= Lista de egresos monetaros de los clientes de la compañia ============\n");
      
      for (cont = 0; cont < tamanho2; cont++)
      {
      	  
      	  fw.write(" Cliente # " +(cont+1));
      	 	
      	  fw.write(" \n");
      	  
      	  if (arreegr[cont].tipo_cli.compareTo("natural") == 0)
      	  {
      	 	 
      	 	 fw.write("Tipo de asegurado: natural || Nombre: "+arreegr[cont].nombre+" || Cedula: "+arreegr[cont].cedula+" || Concepto: "+arreegr[cont].concepto+" || Fecha de pago: "+arreegr[cont].fech.dia+"/"+arreegr[cont].fech.mes+"/"+arreegr[cont].fech.year+" || Monto: "+arreegr[cont].monto+" Bs");
      	 	 
      	 	 fw.write("\n");
      	 	 
      	  }
      	  
      	  else
      	  {
    
      	 	 fw.write(" Tipo de asegurado: juridico || RIF: "+arreegr[cont].rif+" || Concepto: "+arreegr[cont].concepto+" || Fecha de pago: "+arreegr[cont].fech.dia+"/"+arreegr[cont].fech.mes+"/"+arreegr[cont].fech.year+" || Monto: "+arreegr[cont].monto+" Bs");
      	 	 
      	 	 fw.write(" \n");
      	 	 
      	  }
      	  
      }
      
      fw.write("\n");
      
      fw.write("********************************************************************************\n");
      
      fw.write("\n");
      
      fw.write("\n");
      
      fw.close();
      
      String balance_txt = "balance.txt";
      
      FileWriter fw2 = new FileWriter (balance_txt);
      
      fw2.write("**************************** Archivo balance.txt *******************************\n");;//Cargando datos en el archivo balance.txt
      
      fw2.write("                                                      Fecha actual: "+fecha_actual.dia+"/"+fecha_actual.mes+"/"+fecha_actual.year+" \n");
      
      fw2.write("\n");
      
      fw2.write(" Tipo de asegurado con mas beneficios: ");
      
      if (natural > juridico)
      {
      	
      	 fw2.write("Natural ");
      	 
      	 fw2.write("\n");
      }
      
      else
      {
      	
      	 if (natural < juridico)
         {
      	
      	    fw2.write("Juridico ");
      	 
      	    fw2.write("\n");
         }
      
         else
         {
      	
      	   fw2.write("Tanto el asegurado de tipo natural como el juridico, obtienen la misma cantidad de beneficios");
      	 
      	   fw2.write(" \n");
      	 
         }
         
      }
      
      if (ganancia2 > perdida2)
      {
      	
      	 fw2.write(" Desde el "+aux4.dia+"/"+aux4.mes+"/"+aux4.year+" hasta la fecha actual se obtuvo un monto de ganancia de "+(ganancia2 - perdida2)+" Bs");
      	 
      	 fw2.write(" \n");
      	 
      }
      
      else
      {
      	
      	 if (ganancia2 < perdida2)
         {
      	
      	    fw2.write(" Desde el "+aux4.dia+"/"+aux4.mes+"/"+aux4.year+" hasta la fecha actual se obtuvo un monto de perdida de "+(perdida2 - ganancia2)+" Bs" );
      	 
      	    fw2.write(" \n");
      	 
         }
      
         else
         {
      	
      	   fw2.write("Desde el "+aux4.dia+"/"+aux4.mes+"/"+aux4.year+" hasta la fecha actual no hubo ganancia ni perdida ");
      	 
      	   fw2.write(" \n");
      	   
         }
         
      }
      
      fw2.write("==================== Montos globales hasta la fecha actual =====================\n");
      
      fw2.write("\n");
      
      fw2.write(" Monto total de ingresos :" +ganancia+" Bs");
      
      fw2.write(" \n");
      
      fw2.write(" Monto total de egresos :" +perdida+" Bs");
     
      fw2.write("\n");
      
      fw2.write("\n");
      
      fw2.write("********************************************************************************\n");
      
      fw2.close();
      
    }
       
}
