import java.io.BufferedReader;

import java.io.InputStreamReader;

import java.io.FileWriter;

import java.io.FileReader;   

public class PROYECTO1
{
	
	static class fecha /*clase fecha*/
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
		}
		public boolean iguales(transaccion[] artrans, int ntrans)/*metodo para mostrar una transaccion de acuerdo a una fecha dada*/ throws Exception
		{
			
			boolean enc=false;
			
			for(int i=0;i<ntrans;i++)
			{
				
				if((dia==artrans[i].f_trans.dia)&&(mes==artrans[i].f_trans.mes)&&(year==artrans[i].f_trans.year))
				{
					System.out.println("+++++++++++++++++++++++++++++++\n ");
					
					System.out.println("Tipo de transaccion: "+artrans[i].tipo+"\n");
					
					System.out.println("Id de la propiedad: "+artrans[i].prop.id+"\n");
					
					System.out.println("Tipo de propiedad: "+artrans[i].prop.tipo+"\n");
					
					System.out.println("Metros cuadrados: "+artrans[i].prop.m2+"\n");
					
					System.out.println("Ubicacion: "+artrans[i].prop.ubicacion+"\n");
					
					System.out.println("Monto de la transaccion: "+artrans[i].monto+" Bs.F.\n");
					
					System.out.println("--------------Datos del cliente---------------\n");
					
					System.out.println("Cedula: "+artrans[i].cli.cedula+"\n");
					
					System.out.println("Nombre: "+artrans[i].cli.nombre+"\n");
					
					System.out.println("Apellido: "+artrans[i].cli.apellido+"\n");
					
					System.out.println("Direccion: "+artrans[i].cli.direccion+"\n");
					
					System.out.println("Tlf: "+artrans[i].cli.tlf+"\n");
					
					System.out.println("---------------------------------------------\n ");
					
					System.out.println("--------------Datos del promotor---------------\n ");
					
					System.out.println("Cedula: "+artrans[i].prom.cedula+"\n");
					
					System.out.println("Nombre: "+artrans[i].prom.nombre+"\n");
					
					System.out.println("Apellido: "+artrans[i].prom.apellido+"\n");
					
					System.out.println("---------------------------------------------\n");
					
					enc=true;
					
				}
			}
			
			if(enc==true)
			{
				
				System.out.println("+++++++++++++++++++++++++++++++\n ");
				return true;
			}
			return false;
		}
	}
	
	static class promotor/*clase en donde se guarda los promotores*/
	{
		
		Integer cedula;
		String nombre;
		String apellido;
		String direccion;
		Integer tlf;
		fecha f_ing;
		float comision=0;
		public void llenar() throws Exception
		{
			
		   BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		   
		   System.out.println("Cedula \n ");
		   
		   cedula = Integer.parseInt(teclado.readLine());
		   
		   while(cedula<=0)
		   {
		   	
		   		System.out.println("El numero de cedula debe ser mayor que 0.Ingrese nuevamente la cedula \n ");
		   
		   		cedula = Integer.parseInt(teclado.readLine());
		   }
		   
		   System.out.println("Nombre \n ");
		   
		   nombre = teclado.readLine();
		   
		   System.out.println("Apellido \n ");
		   
		   apellido = teclado.readLine();
		   
		   System.out.println("Direccion \n ");
		   
		   direccion = teclado.readLine();
		   
		   System.out.println("Telefono \n ");
		   
		   tlf = Integer.parseInt(teclado.readLine());
		   
		   System.out.println("Fecha de ingreso \n ");
		   
		   f_ing=new fecha();
		   
		   f_ing.llenar();
		   
		}
		public boolean repetido (promotor[] arprom,int i)/*en caso de que se introduzca un promotor con una cedula repetida*/throws Exception
		{
			int j;
			
			j=i-1;
			
			if(j>=0)
			{
				
				while(j>=0)
				{
					
					if(arprom[i].cedula==arprom[j].cedula)
					{
						
						
						
						return true;
					}
					else
					{
						
						j--;
					}
				}
				
			}
				
			return false;
		}
		public boolean mostrar_comi(promotor[]arprom,int numprom,int ced)/*metodo para mostrar la comision de un promotor en especifico*/throws Exception
		{
			
			for(int i=0; i<numprom;i++)
			{
				
				if(ced==arprom[i].cedula)
				{
					
					System.out.println("Comision total para el promotor de cedula "+arprom[i].cedula+": "+arprom[i].comision+" \n ");
					
					return true;
				}
			}
			
			return false;
		}
		
	}
	static class propiedad
	{
		
		String id;
		int m2;
		String ubicacion;
		Integer monto;
		String tipo;
		boolean disponible=true;
		int mts_cons;
		int years_cons;
		int piso;
		String limites;
		
		public void llenar() throws Exception
		{
			
		   BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		   
		   System.out.println("Id de la propiedad (letras y numeros) \n ");
		   
		   id = teclado.readLine();
		   
		   System.out.println("Metros cuadrados \n ");
		   
		   m2 = Integer.parseInt(teclado.readLine());
		   
		   while(m2<=0)
		   {
		   	
		   		System.out.println("la cantidad de metros cuadrados debe ser mayor que 0.Ingrese nuevamente la cantidad de metros cuadrados \n ");
		   
		   		m2 = Integer.parseInt(teclado.readLine());
		   }
		   
		   System.out.println("Ubicacion de la propiedad \n ");
		   
		   ubicacion = teclado.readLine();
		   
		     
		}
		
		public boolean idrepetido(propiedad[] arprop, int i)/*en caso de que se introduzca una propiedad con un id repetido*/throws Exception
		{
			
			int j;
			
			j=i-1;
			
			if(j>=0)
			{
				
				while(j>=0)
				{
					
					if(arprop[i].id.compareTo(arprop[j].id)==0)
					{
						
						return true;
					}
					else
					{
						
						j--;
					}
					
				}
				
			 }
				
			 return false;
		}
		
		public boolean registrado(propiedad[] arprop,int totpro,String id)/*para buscar una propiedad de acuerdo a un id dado por el usuario*/ throws Exception
		{
			
			for (int i=0;i<totpro;i++)
			{
				
				if(arprop[i].id.compareTo(id)==0)
				{
					return true;
				}
			}
			return false;
		}
		
		public void casa()/*para llenar una propiedad de tipo casa*/ throws Exception
		{
			
			   BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
			   
			   System.out.println("cantidad de metros de construccion \n ");
		   		
		   	   mts_cons = Integer.parseInt(teclado.readLine());
		   					 
		   	   while(mts_cons<=0)
		   	   {
		   					 	
		   	      System.out.println("la cantidad de metros de construccion debe ser mayor que 0.Ingrese nuevamente la cantidad de metros de construccion \n ");
		   
		   		  mts_cons = Integer.parseInt(teclado.readLine());
		   		  
		   		}
		   					 
		   		System.out.println("Años de construccion \n ");
		   		
		   		years_cons = Integer.parseInt(teclado.readLine());
		   					 
		   		while(years_cons<=0)
		   		{
		   					 	
		   			System.out.println("la cantidad de metros de construccion debe ser mayor que 0.Ingrese nuevamente la cantidad de metros de construccion \n ");
		   
		   			years_cons = Integer.parseInt(teclado.readLine());
		   		}
		}
		
		public void apart()/*para llenar una propiedad de tipo apartamento*/ throws Exception
		{
			
			BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
			
			System.out.println("Numero de piso en donde se encuentra ubicada \n ");
		   		
		   	piso = Integer.parseInt(teclado.readLine());
		   					 
		   	while(piso<=0)
		   	{
		   					 	
		   		System.out.println("la cantidad de metros de construccion debe ser mayor que 0.Ingrese nuevamente la cantidad de metros de construccion \n ");
		   
		   		piso = Integer.parseInt(teclado.readLine());
		   			
		   	}
		}
		
		public void terreno()/*para llenar una propiedad de tipo terreno*/ throws Exception
		{
			
			BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
			
			System.out.println("Limites del terreno \n ");
		   		
		   	limites=teclado.readLine();
		}
		
		public boolean numlet()/*Si el id posee letras y numeros en todos sus caracteres*/ throws Exception
		{
			
			char caract;
			
			for(int i=0; i < id.length();i++)
			{
				
				caract=id.charAt(i);
				
				switch(caract)
				{
					
					case '0':break;
	  	 
	  	  			case '1':break;
	  	 
	  	  			case '2':break;
	  	         
	  	   			case '3':break;
	  	         
	  	  			case '4':break;
	  	         
	  	  			case '5':break;
	  	         
	  	  			case '6':break;
	  	         
	  	  			case '7':break;
	  	         
	  	  			case '8':break;
	  	         
	  	  			case '9':break;
	  	         
	  	 			case 'a':break;
	  	         
	  	  			case 'b':break; 
	  	  
	  	  			case 'c':break;
	  	 
	  	  			case 'd':break;
	   	  
	  	  			case 'e':break;
	  	         
	  	  			case 'f':break;
	  	  
	  	  			case 'g':break;
	  	  
	  	  			case 'h':break;
	  	         
	  	  			case 'i':break; 

	  	  			case 'j':break;
	  	         
	  	  			case 'k':break;
	  	         
	  	  			case 'l':break;
	  	 
	  	 		 	case 'm':break;
	  	         
	  	  			case 'n':break;
	  	  			
	  	  			case 'ñ':break;
       
	  	  			case 'o':break;
	  	         
	  	  			case 'p':break;
	  	         
	  	  			case 'q':break;
	  	         
	  	  			case 'r':break;
	  	 
	  	  			case 's':break;
	  	         
	  	  			case 't':break;
	  	         
	  	  			case 'u':break;
	  	         
	  	  			case 'v':break;
	  	         
	  	  			case 'w':break;
	  	         
	  	  			case 'x':break;
	  	 
	  	  			case 'y':break;
	  	         
	  	  			case 'z':break;
	  	         
	  	  			default:return false;
	  	  					
				}
				
			}
			return true;
		}
		
		public void propiedad_txt(propiedad[] arprop, int totpro)/*para llenar el archivo de texto propiedad.txt*/throws Exception
		{
			String propiedad="Propiedad.txt";
			
			FileWriter fw = new FileWriter (propiedad);
			
			fw.write("================ Datos de las propiedades ===================== \n");
			
			for(int i=0; i<totpro;i++)
			{
				if(arprop[i].tipo.compareTo("casa")==0)
				{
					
					fw.write("----------"+arprop[i].tipo+" # "+(i+1)+"------------> Id: "+arprop[i].id+"# Extension(m2): "+arprop[i].m2+"# Ubicacion: "+arprop[i].ubicacion+"# Metros de construccion: "+arprop[i].mts_cons+"# Años de construccion: "+arprop[i].years_cons+"\n");
				}
				
				if(arprop[i].tipo.compareTo("apartamento")==0)
				{
					
					fw.write("----------"+arprop[i].tipo+" # "+(i+1)+"------------> Id: "+arprop[i].id+"# Extension(m2): "+arprop[i].m2+"# Ubicacion: "+arprop[i].ubicacion+"# Piso: "+arprop[i].piso+"\n");
				}
				
				if(arprop[i].tipo.compareTo("terreno")==0)
				{
					
					fw.write("----------"+arprop[i].tipo+" # "+(i+1)+"------------> Id: "+arprop[i].id+"# Extension(m2): "+arprop[i].m2+"# Ubicacion: "+arprop[i].ubicacion+"# Limites: "+arprop[i].limites+"\n");
				}
				
			}
			
			fw.close();
			
		}
		
	}
		
	static class transaccion//clase transaccion
	{
		cliente cli;/*va a apuntar al cliente involucrado en la transaccion*/
		promotor prom;/*va a apuntar al promotor involucrado en la transaccion*/
		propiedad prop;/*va a apuntar a la propiedad involucrada en la transaccion*/
		String tipo;
		fecha f_trans;/*va a apuntar a la fecha en que se realizo la transaccion*/
		Integer monto;
		
		public boolean buscapromo(promotor[] arprom,transaccion[] artrans,int numprom,int ced,int prom)/*metodo para buscar un promotor cuando se realiza una transaccion*/
		{
			
			int i;
			
			for(i=0;i<numprom;i++)
			{
				
				if(ced==arprom[i].cedula)
				{
						
					
					artrans[prom].prom=new promotor();
					artrans[prom].prom=arprom[i];
					prom=i;
					return true;
				}
			}
			
			return false;
		}
		
		public boolean dispon(propiedad[] arprop,transaccion[] artrans,int totpro,String id, int prop)/*metodo para saber si una propiedad se encuentra disponible en el momento de una transaccion*/
		{
			
			int i;
			
			for(i=0;i<totpro;i++)
			{
				
				if(arprop[i].id.compareTo(id)==0)
				{
						
					
					if(arprop[i].disponible==false)
					{
						return false;
					}
					else
					{
						artrans[prop].prop=new propiedad();
						artrans[prop].prop=arprop[i];
						arprop[i].disponible=false;
						return true;
					}
				}
			}
			
			return false;
		}
		
		public void llenar() throws Exception
		{
			
			BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
			
			System.out.println("tipo de transaccion \n ");
			
			tipo = teclado.readLine();
			
			tipo = tipo.toLowerCase();
			
			while((tipo.compareTo("venta")!=0)&&(tipo.compareTo("alquiler")!=0))
			{
				
				System.out.println("tipo de transaccion invalido, ingrese nuevamente el tipo de transaccion \n ");
			
				tipo = teclado.readLine();
				
				tipo = tipo.toLowerCase();
			}
			
			System.out.println("fecha de la transaccion \n ");
			
			f_trans=new fecha();
			
			f_trans.llenar();
			
			
		}
		
		public boolean mostrar_prop(transaccion[] artrans,int ntrans,String trans)/*metodos para mostrar las propiedades, dependiendo el tipo de transaccion*/ throws Exception
		{
			boolean enc=false;
			
			for (int i=0;i<ntrans;i++)
			{
				
				if(artrans[i].tipo.compareTo(trans)==0)
				{
					
					if(trans.compareTo("venta")==0)
					{
						if (enc==false)
						{
							
							System.out.println("+++++ Lista de propiedades vendidas++++++\n ");
							
							enc=true;
						}
						if(enc=true)
						{
							
							System.out.println("Id de la propiedad: "+artrans[i].prop.id+"\n ");
							
							System.out.println("Tipo de propiedad: "+artrans[i].prop.tipo+"\n");
					
							System.out.println("Metros cuadrados: "+artrans[i].prop.m2+"\n");
					
							System.out.println("Ubicacion: "+artrans[i].prop.ubicacion+"\n");
							
							System.out.println("++++++++++++++++++++++++++++++++++++++++++\n ");
							
							
						}
						
					}
					else
					{
						
						if (enc==false)
						{
							
							System.out.println("+++++ Lista de propiedades alquiladas+++++++\n ");
						}
						else
						{
							
							System.out.println("Id de la propiedad: "+artrans[i].prop.id+"\n ");
							
							System.out.println("Tipo de propiedad: "+artrans[i].prop.tipo+"\n");
					
							System.out.println("Metros cuadrados: "+artrans[i].prop.m2+"\n");
					
							System.out.println("Ubicacion: "+artrans[i].prop.ubicacion+"\n");
							
							System.out.println("++++++++++++++++++++++++++++++++++++++++++\n ");
							
						}
					}
					
					enc=true;
				}
			}
			if((enc==false)&&(trans.compareTo("venta")==0))
			{
				
				System.out.println("No hay casas vendidas\n");
				return false;
			}
			if( (enc==false) && (trans.compareTo ("alquiler")==0 ))
			{
				
				System.out.println("No hay casas alquiladas\n");
				return false;
			}
			
			return true;
			 
		}
		
		public void mostrar_trans(transaccion[] artrans,int ntrans,String id)/*metodo para mostrar una transaccion, dependiendo del id de propiedad que emita el usuario*/throws Exception
		{
			boolean enc=false;
			for (int i=0;i<ntrans;i++)
			{
				
				if(artrans[i].prop.id.compareTo(id)==0)
				{
					
					System.out.println("+++++ Transaccion correspondiente a la propiedad, cuyo id es: "+artrans[i].prop.id+"+++++\n ");
					
					System.out.println("            Datos del cliente       \n");
					
					System.out.println("Cedula: "+artrans[i].cli.cedula+"\n");
					
					System.out.println("Nombre: "+artrans[i].cli.nombre+"\n");
					
					System.out.println("Apellido: "+artrans[i].cli.apellido+"\n");
					
					System.out.println("Direccion: "+artrans[i].cli.direccion+"\n");
					
					System.out.println("Telefono: "+artrans[i].cli.tlf+"\n");
					
					System.out.println("            Datos del promotor       \n");
					
					System.out.println("Cedula: "+artrans[i].prom.cedula+"\n");
					
					System.out.println("Nombre: "+artrans[i].prom.nombre+"\n");
					
					System.out.println("Apellido: "+artrans[i].prom.apellido+"\n");
					
					enc=true;
					
				}
			}
			
			if(enc==false)
			{
				
				System.out.println("la propiedad no se encuentra involucrada en ninguna transaccion\n");
			}
		}
		
		public void persona_txt(transaccion[] artrans,promotor[] arprom,int ntrans, int numprom)/*metodo para crear y escribir en el archivo persona.txt*/throws Exception
		{
			
			String persona="Persona.txt";
			
			FileWriter fw = new FileWriter (persona);
			
			fw.write("================ Datos de los clientes ===================== \n");
			
			for(int i=0; i<ntrans;i++)
			{
				
				fw.write("----------Cliente # "+(i+1)+"------------> Cedula: "+artrans[i].cli.cedula+"# Nombre: "+artrans[i].cli.nombre+"# Apellido: "+artrans[i].cli.apellido+"# Direccion: "+artrans[i].cli.direccion+"# Telefono: "+artrans[i].cli.tlf+"\n");
			}
			
			fw.write("================ Datos de los promotores ===================== \n");
			
			for(int i=0; i<numprom;i++)
			{
				
				fw.write("----------Promotor # "+(i+1)+"------------> Cedula: "+arprom[i].cedula+"# Nombre: "+arprom[i].nombre+"# Apellido: "+arprom[i].apellido+"# Direccion: "+arprom[i].direccion+"# Telefono: "+arprom[i].tlf+"# Año de ingreso: "+arprom[i].f_ing.year+"# Mes de ingreso: "+arprom[i].f_ing.mes+"# Dia de ingreso: "+arprom[i].f_ing.dia+"# Comision: "+arprom[i].comision+"\n");
			}
			
			fw.close();
			
		}
		
		public void transaccion_txt(transaccion[] artrans,int ntrans)/*metodo para crear y escribir en el archivo persona.txt*/throws Exception
		{
			
			String trans="Transaccion.txt";
			
			FileWriter fw = new FileWriter (trans);
			
			for(int i=0;i<ntrans;i++)
			{
				fw.write("++++++++++++++ Transaccion # "+(i+1)+"++++++++++++++++#Tipo de transaccion: "+artrans[i].tipo+"# Id de la propiedad: "+artrans[i].prop.id+"# Tipo de propiedad: "+artrans[i].prop.tipo);
					
				fw.write("# Metros cuadrados: "+artrans[i].prop.m2+"# Ubicacion: "+artrans[i].prop.ubicacion+"# Monto de la transaccion: "+artrans[i].monto+" Bs.F.\n");
					
				fw.write("--------------Datos del cliente---------------# Cedula: "+artrans[i].cli.cedula+"# Nombre: "+artrans[i].cli.nombre+"# Apellido: "+artrans[i].cli.apellido+"# Direccion: "+artrans[i].cli.direccion+"# Tlf: "+artrans[i].cli.tlf+"\n");
					
				fw.write("--------------Datos del promotor---------------# Cedula: "+artrans[i].prom.cedula+"# Nombre: "+artrans[i].prom.nombre+"# Apellido: "+artrans[i].prom.apellido+"\n");
				
			}
			
			fw.close();
		}
		
	}
	static class cliente //clase cliente
	{
		Integer cedula;
		String nombre;
		String apellido;
		String direccion;
		Integer tlf;
		
		public void llenar()throws Exception
		{
			
		   BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		   
		   System.out.println("Cedula \n ");
		   
		   cedula = Integer.parseInt(teclado.readLine());
		   
		   while(cedula<=0)
		   {
		   	
		   		System.out.println("El numero de cedula debe ser mayor que 0.Ingrese nuevamente la cedula \n ");
		   
		   		cedula = Integer.parseInt(teclado.readLine());
		   }
		   
		   System.out.println("Nombre \n ");
		   
		   nombre = teclado.readLine();
		   
		   System.out.println("Apellido \n ");
		   
		   apellido = teclado.readLine();
		   
		   System.out.println("Direccion \n ");
		   
		   direccion = teclado.readLine();
		   
		   System.out.println("Telefono \n ");
		   
		   tlf = Integer.parseInt(teclado.readLine());
		}
		
	}
	
	public static void main(String[] args) throws Exception /*principal*/
	{
		
		BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
		
		promotor arprom[];/*arreglo de objetos de los promotores, en donde cada posicion es un objeto de tipo promotor*/
		
		propiedad arprop[];/*arreglo de objetos de las propiedad, en donde cada posicion es un objeto de tipo propiedad*/
		
		transaccion artrans[];/*arreglo de objetos de las transacciones, en donde cada posicion es un objeto de tipo transaccion*/
		
		int numprom,numprop,j,k,numcas,numap,numt,totpro,ntrans,ced,prom,prop,opc;
		
		System.out.println("##################### Empresa Century 21 Margarita ##################### \n ");
		
		System.out.println("Ingrese la cantidad de promotores a procesar \n ");
		
		numprom=Integer.parseInt(teclado.readLine());
		
		while((numprom<=0)||(numprom>25))/*validando el numero de promotores 1-25*/
		{
			System.out.println("Error, la cantidad debe oscilar entre 1 y 25 \n ");
			
			System.out.println("Ingrese nuevamente la cantidad de promotores a procesar \n ");
		
			numprom=Integer.parseInt(teclado.readLine());
			
		}
		
		arprom=new promotor[numprom];
		
		for(int i=0; i<numprom; i++)
		{
			
			System.out.println("-------------------------- Procesando promotor # "+(i+1)+" ----------------------------- \n ");
			
			arprom[i]=new promotor();/*cada posicion del arreglo de objetos se debe inicializar con new*/
			
			arprom[i].llenar();
			
			while(arprom[i].repetido(arprom,i)==true)/*numero de cedula repetido*/
			{
				
				System.out.println("Error, el numero de cedula que introdujo, corresponde con el de un promotor previamente procesado, ingrese nuevamente el numero de cedula \n ");
						
				arprom[i].cedula=Integer.parseInt(teclado.readLine());
			}
				
			
		}
		
		System.out.println("A continuacion, se procesaran las propiedades existentes en la empresa \n ");
		
		System.out.println("Indique la cantidad de casas a procesar \n ");
		
		numcas=Integer.parseInt(teclado.readLine());
		
		while((numcas<=0)||(numcas>90))/*validando el numero de casas 1-90*/
		{
			
			System.out.println("La cantidad de casas debe oscilar entre 1 y 90.Introduzca nuevamente la cantidad de casas a procesar \n ");
		
			numcas=Integer.parseInt(teclado.readLine());
		}
		
		
		System.out.println("Indique la cantidad de apartamentos a procesar \n ");
		
		numap=Integer.parseInt(teclado.readLine());
		
		while((numap<=0)||(numap>70))/*validando el numero de apartamentos 1-70*/
		{
			
			System.out.println("La cantidad de apartamentos debe oscilar entre 1 y 70.Introduzca nuevamente la cantidad de apartamentos a procesar \n ");
		
			numap=Integer.parseInt(teclado.readLine());
			
		}
		
		System.out.println("Indique la cantidad de terrenos a procesar \n ");
		
		numt=Integer.parseInt(teclado.readLine());
		
		while((numt<=0)||(numt>40))/*validando el numero de terrenos 1-40*/
		{
			
			System.out.println("La cantidad de terrenos debe oscilar entre 1 y 40.Introduzca nuevamente la cantidad de terrenos a procesar \n ");
		
			numt=Integer.parseInt(teclado.readLine());
		}
		
		totpro=numcas+numap+numt; 
		
		arprop= new propiedad[totpro];
		
		k=0;
		
		for(int i=0;i<numcas;i++)//Este for es para llenar las casas
		{
			
			System.out.println("-------------------------- Procesando casa # "+(k+1)+" ----------------------------- \n ");
			
			arprop[i]=new propiedad();
			
			arprop[i].tipo="casa";
			
			arprop[i].llenar();
			
			arprop[i].casa();
			
			while((arprop[i].idrepetido(arprop,i)==true)||(arprop[i].numlet()==false))//validando de que el id no sea repetido y que tenga numeros y letras
			
			{
				
				if(arprop[i].numlet()==false)
				{
				
					System.out.println("Error, el id de la propiedad debe contener letras y numeros, ingrese nuevamente el id de la propiedad \n");
				
					arprop[i].id=teclado.readLine();
				}
				
				if(arprop[i].idrepetido(arprop,i)==true)
				{
					
					System.out.println("Error, el id de la propiedad que introdujo, corresponde con el de una propiedad previamente procesada, ingrese nuevamente el id ed la propiedad \n ");
						
					arprop[i].id=teclado.readLine();
				}
			}
			
			
			k++;
			
		}
					
		k=0;
		
		for(int i=numcas;i<numcas+numap;i++)//Este for es para llenar los apartamentos
		{
			
			System.out.println("-------------------------- Procesando apartamento # "+(k+1)+" ----------------------------- \n ");
			
			arprop[i]=new propiedad();
			
			arprop[i].tipo="apartamento";
			
			arprop[i].llenar();
			
			arprop[i].apart();
			
			while((arprop[i].idrepetido(arprop,i)==true)||(arprop[i].numlet()==false))//validando de que el id no sea repetido y que tenga numeros y letras
			
			{
				
				if(arprop[i].numlet()==false)
				{
				
					System.out.println("Error, el id de la propiedad debe contener letras y numeros, ingrese nuevamente el id de la propiedad \n");
				
					arprop[i].id=teclado.readLine();
				}
				
				if(arprop[i].idrepetido(arprop,i)==true)
				{
					
					System.out.println("Error, el id de la propiedad que introdujo, corresponde con el de una propiedad previamente procesada, ingrese nuevamente el id ed la propiedad \n ");
						
					arprop[i].id=teclado.readLine();
				}
			}
			
			
			k++;
			
		}
		
		k=0;
		
		for(int i=numcas+numap;i<totpro;i++)//for para los terrenos
		{
			
			System.out.println("-------------------------- Procesando terreno # "+(k+1)+" ----------------------------- \n ");
			
			arprop[i]=new propiedad();
			
			arprop[i].tipo="terreno";
			
			arprop[i].llenar();
			
			arprop[i].terreno();
			
			while((arprop[i].idrepetido(arprop,i)==true)||(arprop[i].numlet()==false))//validando de que el id no sea repetido y que tenga numeros y letras
			
			{
				
				if(arprop[i].numlet()==false)
				{
				
					System.out.println("Error, el id de la propiedad debe contener letras y numeros, ingrese nuevamente el id de la propiedad \n");
				
					arprop[i].id=teclado.readLine();
				}
				
				if(arprop[i].idrepetido(arprop,i)==true)
				{
					
					System.out.println("Error, el id de la propiedad que introdujo, corresponde con el de una propiedad previamente procesada, ingrese nuevamente el id ed la propiedad \n ");
						
					arprop[i].id=teclado.readLine();
				}
			}
			
			
			k++;			
			
		}
		
		System.out.println("Ingrese el numero de transacciones realizadas \n");
		
		ntrans=Integer.parseInt(teclado.readLine());
		
		while ((ntrans<=0)||(ntrans>totpro))//validando el numero de transacciones
		{
			
			System.out.println("La cantidad de transacciones debe ser mayor que 0 y menor o igual al total de propiedades.Ingrese nuevamente el numero de transacciones realizadas \n");
		
			ntrans=Integer.parseInt(teclado.readLine());
		}
		
		artrans=new transaccion[ntrans];
		
		for (int i=0; i<ntrans; i++)
		{
			
			System.out.println("-------------------------- Procesando transaccion ----------------------------- \n ");
			
			artrans[i]=new transaccion();
			
			artrans[i].llenar();
			
			System.out.println("Introduzca la cedula del promotor involucrado en la transaccion \n ");
			
			ced=Integer.parseInt(teclado.readLine());
			
			while (ced<=0)//validando la cedula del promotor de la transaccion
			{
			
				System.out.println("La cedula debe ser mayor que 0.Ingrese el numero de cedula del promotor \n");
		
				ced=Integer.parseInt(teclado.readLine());
			}
			
			prom=i;
			
			while(artrans[i].buscapromo(arprom,artrans,numprom,ced,prom)==false)//en caso de que la cedula emitida por el usuario no se encuentre
			{
				
				System.out.println("La cedula no se encuentra registrada.Ingrese nuevamente el numero de cedula del promotor \n");
		
				ced=Integer.parseInt(teclado.readLine());
			}
			
			System.out.println("Datos del cliente \n");
			
			artrans[i].cli=new cliente();//clase asociada de transaccion a cliente 
			
			artrans[i].cli.llenar();
			
			System.out.println("Ingrese el id de la propiedad \n");
			
			String id=teclado.readLine();
			
			prop=i;
			
			while(artrans[i].dispon(arprop,artrans,totpro,id,prop)==false)//en caso de que no se encuentra la propiedad o ya tiene comprador
			{
				
				System.out.println("El id no se encuentra registrado o no esta disponible.Ingrese nuevamente el id de la propiedad \n");
		
				id=teclado.readLine();
			}
			
			
			
			System.out.println("Monto de la transaccion \n ");
			
			artrans[i].monto=Integer.parseInt(teclado.readLine());
			
			while (artrans[i].monto<=0)//monto >=0
			{
			
				System.out.println("El nomto debe ser mayor que 0.Ingrese el numero de cedula del promotor \n");
		
				artrans[i].monto=Integer.parseInt(teclado.readLine());
			}
			
			artrans[i].prom.comision+=(artrans[i].monto * 0.01);//Se va acumulando elmonto de comision al promotor que esta interviniendo en la transaccion
			
		}
			
		String resp="n";
			
		while (resp.compareTo("n") == 0)//menu de opciones
		{
				
			opc=0;
			System.out.println("Menu de opciones \n ");
				
			System.out.println("Para verificar las transacciones realizadas en una fecha especifica, presione '1'\n");
				
			System.out.println("Mostrar el monto de comision que se le debe cancelar a un promotor en especifico, presione '2'\n");
				
			System.out.println("Datos de la(s) propiedad(es) involucrada(s) segun elel tipo de transaccion, presione '3'\n");
				
			System.out.println("Para verificar una transaccion de acuerdo a un id de propiedad, presione '4'\n");
				
			opc=Integer.parseInt(teclado.readLine());
				
			while((opc<0)||(opc>4))//validando la opcion
			{
					
				System.out.println("el valor debe oscilar entre 1 y 4, ingrese nuevamente la opcion \n ");
					
				System.out.println("Menu de opciones \n ");
			}
				
			switch(opc)
			{
					
				case 1:System.out.println("Introduzca la fecha \n ");
					   fecha fch=new fecha();
					   fch.llenar();
					   if(fch.iguales(artrans,ntrans)==false)//En este metodo se muestra las transacciones que coincidan con la fecha emitida po el usuario
					   {
					   		System.out.println("En la fecha insertada, no se produjo ninguna transaccion \n ");//si no cumple, se muestra por pantalla este mensaje
					   }
					   break;
					   
				case 2:System.out.println("Introduzca la cedula del promotor \n ");
					   ced=Integer.parseInt(teclado.readLine());
					   while(arprom[0].mostrar_comi(arprom,numprom,ced)==false)//este metodo muestra la comision total de un promotor dado por su numero de cedula
					   {
					   	
					   		System.out.println("Cedula no encontrada.Introduzca nuevamente la cedula del promotor \n ");//si la cedula emitida por el usuario no coincide cn ninguno de los promotores, se muestra por pantalla este mensaje de error
					   		ced=Integer.parseInt(teclado.readLine());
					   }
					   break;
					   
				case 3:System.out.println("Introduzca el tipo de transaccion \n ");
					   String trans=teclado.readLine();
					   trans.toLowerCase();
					   while((trans.compareTo("venta")!=0)&&(trans.compareTo("alquiler")!=0))//validando el tipo de transaccion(venta o alquiler)
					   {
					   	
					   		System.out.println("Tipo de transaccion invalida.Introduzca nuevamente el tipo de transaccion \n ");
					   		trans=teclado.readLine();
					   		trans.toLowerCase();
					   }
					   artrans[0].mostrar_prop(artrans,ntrans,trans);//metodo para mostrar las propiedades involucradas, de acuerdo al tipo de transaccion
					   break;
					   
				case 4:System.out.println("Introduzca el id de propiedad \n ");
					   String id=teclado.readLine();
					   while(arprop[0].registrado(arprop,totpro,id)==false)//si el id emitido por el usuario no se encuentra registrado
					   {
					   	
					   		System.out.println("Id de propiedad no registrado, introduzca nuevamente el id de propiedad \n ");
					   		id=teclado.readLine();
					   }
					   artrans[0].mostrar_trans(artrans,ntrans,id);//aqui se muestra si la propiedad esta vinculada con alguna transaccion
					   break;		   
					   
			}
			
			System.out.println("Desea salir del menu de opciones? (s/n) \n ");				
			resp=teclado.readLine();
			resp=resp.toLowerCase();
			while((resp.compareTo("s")!=0)&&(resp.compareTo("n")!=0))//validando la respuesta
			{
				
				System.out.println("Respuesta invalida, ingrese nuevamente la respuesta \n ");				
				resp=teclado.readLine();
				resp=resp.toLowerCase();
			}
				
				
		}
		
		artrans[0].persona_txt(artrans,arprom,ntrans,numprom);//aqui se llena el archivo de texto persona.txt
		arprop[0].propiedad_txt(arprop,totpro);//aqui se llena el archivo de texto propiedad.txt
		artrans[0].transaccion_txt(artrans,ntrans);//aqui se llena el archivo de texto transaccion.txt	
	 }
}