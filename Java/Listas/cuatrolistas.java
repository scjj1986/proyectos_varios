
import java.io.*;
import java.lang.NoSuchMethodError;
import java.lang.NullPointerException;
public class cuatrolistas {
    public static void main(String[] args) throws Exception /*principal*/
    {
    	BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
    	Listas l=new Listas();
    	Nodo nuevo;
    	l.aux=null;
    	l.backup=null;
    	l.ordenada=null;
    	l.desordenada=null;
    	l.combinada=null;
    	l.repetida=null;
    	System.out.println("Bienvenidos al programa de listas.");
    	String opcion="n";
    	while ( (opcion.compareTo("n")==0) || (opcion.compareTo("N")==0))
    	{
    		System.out.println("Opciones:");
    		System.out.println("1) Si desea agregar un nodo a la lista ordenada :");
    		System.out.println("2) Si desea agregar un nodo a la lista desordenada :");
    		System.out.println("3) Si desea buscar un nodo:");
    		System.out.println("4) Si desea eliminar un nodo:");
    		System.out.println("5) Si desea mostrar las 4 listas :");
    		opcion=entrada.readLine();
    		while ( (opcion.compareTo("1")!=0) && (opcion.compareTo("2")!=0) && (opcion.compareTo("3")!=0) && (opcion.compareTo("4")!=0) && (opcion.compareTo("5")!=0) ){
    		
    			System.out.println("Error. Ingrese la opcion correcta:");
    			opcion=entrada.readLine();
    		}
    		if (opcion.compareTo("1")==0)
    		{
    			nuevo= new Nodo();
    			nuevo.sig=null;
    			l.backup=l.ordenada;
    			System.out.println("Ingrese la cedula: \n ");
    			nuevo.cedula = entrada.readLine();
    			while ( (!nuevo.numerico()) || (l.nodo_repetido(nuevo)) ) 
    			{
    		
    				System.out.println("Error. La cedula debe ser numeria e irrepetible en la lista. Ingresela nuevamente.\n ");
    				nuevo.cedula = entrada.readLine();
    			}
    			System.out.println("Ingrese el nombre: \n ");
    			nuevo.nombre = entrada.readLine();
    			System.out.println("Ingrese el apellido: \n ");
    			nuevo.apellido = entrada.readLine();
    			l.agregar(nuevo);
    			l.ordenar_nodos();
    			l.ordenada=l.backup;
    			System.out.println("Nodo guardado satisfactoriamente. \n ");
    		}
    		else if (opcion.compareTo("2")==0)
    		{
    			
    			nuevo= new Nodo();
    			nuevo.sig=null;
    			l.backup=l.desordenada;
    			System.out.println("Ingrese la cedula: \n ");
    			nuevo.cedula = entrada.readLine();
    			while ( (!nuevo.numerico()) || (l.nodo_repetido(nuevo)) ) 
    			{
    		
    				System.out.println("Error. La cedula debe ser numeria e irrepetible en la lista. Ingresela nuevamente.\n ");
    				nuevo.cedula = entrada.readLine();
    			}
    			l.backup=l.ordenada;
    		
    			if (l.nodo_repetido(nuevo))
    			{
    				System.out.println("El numero de cédula coincide con : \n "+nuevo.nombre+" "+nuevo.apellido+", que esta en la otra lista. De igual manera se guardara en la lista.");
    			}
    			else
    			{
    				System.out.println("Ingrese el nombre: \n ");
    				nuevo.nombre = entrada.readLine();
    				System.out.println("Ingrese el apellido: \n ");
    				nuevo.apellido = entrada.readLine();
    			}
    			l.backup=l.desordenada;
    			l.agregar(nuevo);
    			l.desordenada=l.backup;
    			System.out.println("Nodo guardado satisfactoriamente. \n ");
    		}
    		else if (opcion.compareTo("3")==0)
    		{
    			nuevo=new Nodo();
    			l.backup=null;
    			l.crear_combinada();
    			System.out.println("Ingrese la cedula: \n ");
    			nuevo.cedula = entrada.readLine();
    			while ( (!nuevo.numerico())) 
    			{
    		
    				System.out.println("Error. La cedula debe ser numerica. Ingresela nuevamente.\n ");
    				nuevo.cedula = entrada.readLine();
    			}
    			if (l.nodo_repetido(nuevo))
    			{
    				
    				System.out.println("La cedula nr. "+nuevo.cedula+" coincide con el nombre de "+nuevo.nombre+" "+nuevo.apellido);
    			}
    			else
    			{
    				
    				System.out.println("Cedula no encontrada\n");
    			}
    			
    		}
    		else if (opcion.compareTo("5")==0)
    		{
    			
    			l.backup=l.ordenada;
    			System.out.println("*Lista ordenada\n");
    			l.mostrar();
    			l.backup=l.desordenada;
    			System.out.println("\n*Lista desordenada\n");
    			l.mostrar();
    			l.backup=null;
    			l.crear_combinada();
    			System.out.println("\n*Lista combinada\n");
    			l.mostrar();
    			l.combinada=l.backup;
    			l.backup=null;
    			l.crear_repetida();
    			System.out.println("\n*Lista de elementos repetidos\n");
    			l.mostrar();
    			l.repetida=l.backup;
    		}
    		else if (opcion.compareTo("4")==0)
    		{
    			nuevo=new Nodo();
    			System.out.println("Ingrese la cedula del nodo a eliminar:");
    			nuevo.cedula=entrada.readLine();
    			l.backup=null;
    			l.crear_combinada();
    			if (!l.nodo_repetido(nuevo)){
    				
    				System.out.println("El nodo no se encuentra en ninguna de las listas:");
    			}
    			else{
    				
    				System.out.println("Nodo encontrado:");
    				System.out.println("\nNombre: "+nuevo.nombre);
    				System.out.println("Apellido: "+nuevo.apellido);
    				System.out.println("Desea eliminar el nodo? s/n :");
    				opcion=entrada.readLine();
    				while ( (opcion.compareTo("s")!=0) && (opcion.compareTo("S")!=0) && (opcion.compareTo("n")!=0) && (opcion.compareTo("N")!=0) ){
    		
    					System.out.println("Error. Ingrese la opcion correcta:");
    					opcion=entrada.readLine();
		    		}
		    		if ((opcion.compareTo("s")==0) || (opcion.compareTo("S")==0)){
		    		
		    		l.eliminar(nuevo);
		    		System.out.println("Nodo eliminado satisfactoriamente. \n ");
		    		}
		    	}
    		}
    		System.out.println("Desea salir de la aplicacion? s/n :");
    		opcion=entrada.readLine();
    		while ( (opcion.compareTo("s")!=0) && (opcion.compareTo("S")!=0) && (opcion.compareTo("n")!=0) && (opcion.compareTo("N")!=0) ){
    		
    			System.out.println("Error. Ingrese la opcion correcta:");
    			opcion=entrada.readLine();
    		}
    	
    }
    
 
}
}
class Nodo
{
	String cedula,nombre,apellido;
	Nodo sig;
	public boolean numerico() throws Exception 
	{
		
		for (int i=0; i<cedula.length(); i++)
		{
			if( !Character.isDigit(cedula.charAt(i)) ){				
				return false;
			}
		}
		return true;
	}
	
	
}
class Listas
{
	public Nodo aux,backup,ordenada,desordenada,combinada,repetida;
	public void agregar(Nodo nuevo) throws Exception
	{
		
		if (backup==null)
		{
			
			backup=nuevo;
		}
		else{
			
		aux=backup;
		while(aux.sig!=null){
			
			aux=aux.sig;
		}
		aux.sig=nuevo;	
		}
	}
	public void mostrar () throws Exception{
		
		aux=backup;
		if (aux==null)
		{
			System.out.println("Lista vacia");
		}
		else
		{
			
			while (aux!=null){
			
				System.out.println("Cedula: "+aux.cedula);
				System.out.println("Nombre: "+aux.nombre);
				System.out.println("Apellido: "+aux.apellido);
				System.out.println("\n");
				aux=aux.sig;
			}
		}
		
	}
	public boolean nodo_repetido (Nodo nuevo) throws Exception
	{
		
		aux=backup;
		while (aux!=null)
		{
			
			if (aux.cedula.compareTo(nuevo.cedula)==0)
			{
				
				nuevo.nombre=aux.nombre;
				nuevo.apellido=aux.apellido;
				return true;
			}
			aux=aux.sig;
		}
		return false;
	}
	public void ordenar_nodos () throws Exception
	{
		
		boolean bandera=false;
		int ced=0;
		int ced2=0;
		String cedula="";
		String nombre="";
		String apellido="";
		if (backup!=null){
			
		aux=backup;
		while (aux.sig!=null)
		{
			ced=Integer.parseInt(aux.cedula);
			ced2=Integer.parseInt(aux.sig.cedula);
			if (ced>ced2)
			{
				cedula=aux.cedula;
				nombre=aux.nombre;
				apellido=aux.apellido;
				aux.cedula=aux.sig.cedula;
				aux.nombre=aux.sig.nombre;
				aux.apellido=aux.sig.apellido;
				aux.sig.cedula=cedula;
				aux.sig.nombre=nombre;
				aux.sig.apellido=apellido;
				bandera=true;
				
			}
			aux=aux.sig;
			if ( (aux.sig==null) && (bandera==true)){
				bandera=false;
				aux=backup;
				
			}
		}
		}
		
	}
	public void crear_combinada () throws Exception
	{
		Nodo aux2=ordenada;
		Nodo nuevo;
		while(aux2!=null)
		{
			nuevo=new Nodo();
			nuevo.cedula=aux2.cedula;
			nuevo.nombre=aux2.nombre;
			nuevo.apellido=aux2.apellido;
			agregar(nuevo);
			aux2=aux2.sig;
		}
		aux2=desordenada;
		while(aux2!=null)
		{
			nuevo=new Nodo();
			nuevo.cedula=aux2.cedula;
			nuevo.nombre=aux2.nombre;
			nuevo.apellido=aux2.apellido;
			agregar(nuevo);
			aux2=aux2.sig;
		}
	}
	public void crear_repetida () throws Exception
	{
		
		Nodo nuevo,aux2,aux3;
		aux2=ordenada;
		while (aux2!=null)
		{
			aux3=desordenada;
			while (aux3!=null)
			{
				
				if (aux3.cedula.compareTo(aux2.cedula)==0)
				{
					
					nuevo=new Nodo();
					nuevo.cedula=aux2.cedula;
					nuevo.nombre=aux2.nombre;
					nuevo.apellido=aux2.apellido;
					agregar(nuevo);
				}
				aux3=aux3.sig;
			}
			aux2=aux2.sig;
			
		}
		
	}
	public void eliminar (Nodo nuevo) throws Exception
	{	
		aux=ordenada;
		while (aux!=null){
			
			if (aux.cedula.compareTo(nuevo.cedula)==0){
				
				if (aux==ordenada){
					if (aux.sig==null){
						
						ordenada=null;	
					}
					else if (aux.sig!=null){
					
					ordenada=aux.sig;
					}
				}
				else if(aux!=ordenada){
					
					if (aux.sig==null){
					
					aux=null;
					}
				}
				
			}
			else if (aux.sig!=null)
			{
				
				if (aux.sig.cedula.compareTo(nuevo.cedula)==0){
					
					if (aux.sig.sig==null){
						
						aux.sig=null;
					}
					else if (aux.sig.sig!=null){
						
						aux.sig=aux.sig.sig;
					}
				
				}
			} 
			aux=aux.sig;
		}
		
		aux=desordenada;
		while (aux!=null){
			
			if (aux.cedula.compareTo(nuevo.cedula)==0){
				if (aux==desordenada){
					if (aux.sig==null){
						
						desordenada=null;	
					}
					else if (aux.sig!=null){
					
					desordenada=aux.sig;
					}
				}
				else if(aux!=desordenada){
					
					if (aux.sig==null){
					
					aux=null;
					}
				}
				
			}
			else if (aux.sig!=null)
			{
				
				if (aux.sig.cedula.compareTo(nuevo.cedula)==0){
					
					if (aux.sig.sig==null){
						
						aux.sig=null;
					}
					else if (aux.sig.sig!=null){
						
						aux.sig=aux.sig.sig;
					}
				
				}
			} 
			aux=aux.sig;
		}
	}
}