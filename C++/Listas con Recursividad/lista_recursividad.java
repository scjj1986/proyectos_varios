import java.io.*;
public class lista_recursividad {
	static class nodo{
		String info;
		nodo sig;
		public void llenar() throws Exception{
			
			BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
			System.out.println("Ingrese el dato (irrepetible): \n ");
    		info = teclado.readLine();
		}	
	}
    static class lista {
    	
    	public nodo primero,ultimo;
    	
    	public void ingresar_inicio (nodo nuevo) throws Exception{	
    		if (primero==null){
    			ultimo=nuevo;
    		}
    		else{
    			
    			nuevo.sig=primero;
    		}
    		primero=nuevo;
    	}
    	public void ingresar_fin (nodo nuevo) throws Exception{	
    		if (ultimo==null){
    			primero=nuevo;
    		}
    		else{
    			
    			ultimo.sig=nuevo;
    		}
    		ultimo=nuevo;
    	}
    	public boolean encontrar (nodo aux,String valor,int [] i){	
    		if (aux==null){
    			return false;
    		}
    		else if (valor.compareTo(aux.info)==0){
    			return true;
    		}
    		else{
    			i[0]++;
    			return encontrar (aux.sig,valor,i);
    		}
    	}
    	public void mostrar (nodo aux) throws Exception{
    		
    		if (aux!=null){
    			
    			System.out.println ("*"+aux.info);
    			mostrar(aux.sig);
    		}
    	}
    	public void eliminar (nodo aux, String valor) throws Exception{
    		
    		if (primero.info.compareTo(valor)==0){
    			if (primero==ultimo){
    				primero=null;
    				ultimo=null;
    			}
    			else{
    				primero=primero.sig;
    			}
    			
    		}
    		else if (aux.sig.info.compareTo(valor)==0){
    			if (aux.sig==ultimo){
    				aux.sig=null;
    				ultimo=aux;
    			}
    			else{
    				
    				aux.sig=aux.sig.sig;
    			}
    			
    		}
    		else{
    			eliminar(aux.sig,valor);
    		}
    	}	
    }
    public static void main(String[] args) throws Exception /*principal*/
    {
    	BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
    	lista l=new lista();
    	nodo nuevo,aux;
    	l.primero=null;
    	l.ultimo=null;
    	int[] i=new int[1];
    	String opc,valor;
    	System.out.println("\nPrograma que almacena nodos en lista de manera recursiva\n");
    	boolean salir=false;
    	while (salir==false){	
    		System.out.println("\nAbanico de Opciones:\n");
    		System.out.println("\n1) para ingresar un nodo como pila.");
    		System.out.println("\n2) para ingresar un nodo como cola.");
    		System.out.println("\n3) para recorrer la lista.");
    		System.out.println("\n4) para eliminar un nodo de la lista.");
    		System.out.println("\n5) para buscar un nodo en la lista:");
    		opc=teclado.readLine();
    		while ( (opc.compareTo("1")!=0) && (opc.compareTo("2")!=0) && (opc.compareTo("3")!=0) && (opc.compareTo("4")!=0) && (opc.compareTo("5")!=0) ){
    			System.out.println("\nOpcion incorrecta. Ingrese nuevamente dicho valor:");
    			opc=teclado.readLine();
    		}
    		if (opc.compareTo("1")==0){
    			nuevo=new nodo();
    			nuevo.llenar();
    			aux=l.primero;
    			i[0]=1;
    			while (l.encontrar(aux,nuevo.info,i)){
    				System.out.println("\nError. El valor del nodo debe ser irrepetible. Ingrese nuevamente dicho valor:");
    				nuevo.llenar();
    				aux=l.primero;
    			}
    			l.ingresar_inicio(nuevo);
    			System.out.println("\nAsi queda nuestra lista:");
    			aux=l.primero;
    			l.mostrar(aux);
    		} else if (opc.compareTo("2")==0){
    			nuevo=new nodo();
    			nuevo.llenar();
    			aux=l.primero;
    			i[0]=1;
    			while (l.encontrar(aux,nuevo.info,i)){
    				System.out.println("\nError. El valor del nodo debe ser irrepetible. Ingrese nuevamente dicho valor:");
    				nuevo.llenar();
    				aux=l.primero;
    			}
    			l.ingresar_fin(nuevo);
    			System.out.println("\nAsi queda nuestra lista:");
    			aux=l.primero;
    			l.mostrar(aux);
    		} else if (opc.compareTo("3")==0){
    			if (l.primero==null){
    				System.out.println("\nLista vacia.");
    			}
    			else{
    				aux=l.primero;
    				System.out.println("\nLista:");
    				l.mostrar(aux);		
    			}    			
    		} else if (opc.compareTo("4")==0){
    			
    			if (l.primero!=null){   				
    				System.out.println("\nA continuacion se mostrara la lista:");
    				aux=l.primero;
    				l.mostrar(aux);
    				System.out.println("\nIngrese el valor a eliminar:");
    				valor=teclado.readLine();
    				aux=l.primero;
    				i[0]=1;
    				while (l.encontrar(aux,valor,i)==false){
    					System.out.println("\nValor no encontrado.Ingrese nuevamente dicho valor:");
    					valor=teclado.readLine();
    					aux=l.primero;
    				}
    				l.eliminar(aux,valor);
    				if (l.primero!=null){
    					System.out.println("\nY asi queda la lista:");
    					aux=l.primero;
    					l.mostrar(aux);
    				}else{
    					
    					System.out.println("\nYa no quedan nodos por eliminar, debido a que la lista quedo vacia");
    				}		
    			} else{
    				
    				System.out.println("\nNo se puede realizar esta operacion, debido a que la lista esta vacia");	
    			}    			
    		} else if (opc.compareTo("5")==0){
    			
    			if (l.primero!=null){
    				System.out.println("\nIngrese el valor a buscar:");
    				valor=teclado.readLine();
    				aux=l.primero;
    				i[0]=1;
    				if (l.encontrar(aux,valor,i)==false){
    					System.out.println("\nValor no encontrado.");  					
    				}
    				else{
    					System.out.println("\nValor encontrado, se encuentra en la posicion "+i[0]+" de la lista");   					
    				}
    				
    			} else{
    				
    				System.out.println("\nNo se puede realizar esta operacion, debido a que la lista esta vacia");	
    			}
    		}
    		System.out.println("\nDesea salir de la aplicacion (s/n)?:");
    		opc=teclado.readLine();
    		while ((opc.compareTo("s")!=0) && (opc.compareTo("S")!=0) && (opc.compareTo("n")!=0) && (opc.compareTo("N")!=0)){
    			
    			System.out.println("\nDeOpcion incorrecta. Ingrese nuevamente el valor:");
    			opc=teclado.readLine();
    		}
    		if ((opc.compareTo("s")==0) || (opc.compareTo("S")==0)){
    			
    			salir=true;
    		}		  		
    	}  	
    }       
}