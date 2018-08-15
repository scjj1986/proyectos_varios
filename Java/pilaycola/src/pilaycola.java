import java.io.*;
import java.util.NoSuchElementException;
public class pilaycola {  
    public static void main(String[] args) throws Exception /*principal*/
    {
        BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
        Nodo nuevo;
        Pila p=new Pila();
        Cola c=new Cola();
        System.out.println("Bienvenidos al programa de pila y cola.");
    	String opcion="n";
    	while ( (opcion.compareTo("n")==0) || (opcion.compareTo("N")==0))
    	{ 
            System.out.println("Opciones:");
            System.out.println("1) Si desea agregar un nodo a la pila :");
            System.out.println("2) Si desea calcular el total de nodos de la pila :");
    	    System.out.println("3) Si desea verificar el primer nodo de la pila:");
            System.out.println("4) Si desea sacar un nodo de la pila:");
            System.out.println("5) Si desea agregar un nodo a la cola:");
            System.out.println("6) Si desea calcular el total de nodos de la cola :");
    	    System.out.println("7) Si desea verificar el primer nodo de la cola:");
            System.out.println("8) Si desea verificar el ultimo nodo de la cola:");
            System.out.println("9) Si desea sacar un nodo de la cola:");
            opcion=entrada.readLine();
            while ( (opcion.compareTo("1")!=0) && (opcion.compareTo("2")!=0) && (opcion.compareTo("3")!=0) && (opcion.compareTo("4")!=0) && (opcion.compareTo("5")!=0) && (opcion.compareTo("6")!=0) && (opcion.compareTo("7")!=0) && (opcion.compareTo("8")!=0) && (opcion.compareTo("9")!=0))
            {
            
    		System.out.println("Error. Ingrese la opcion correcta:");
    		opcion=entrada.readLine();
            }
            if (opcion.compareTo("1")==0)
            {
                nuevo=new Nodo();
                p.apilar(nuevo);
            }
            else if (opcion.compareTo("2")==0)
            {
                System.out.println("Total de nodos de la pila: "+p.tamanho());
            }
            else if (opcion.compareTo("3")==0)
            {
                p.MostrarPrimerNodo();
            }
            else if (opcion.compareTo("4")==0)
            {
                p.Desapilar();
            }
            else if (opcion.compareTo("5")==0)
            {
                nuevo=new Nodo();
                c.encolar(nuevo);
            }
            else if (opcion.compareTo("6")==0)
            {
                System.out.println("Total de nodos de la cola: "+c.tamanho());
            }
            else if (opcion.compareTo("7")==0)
            {
                c.MostrarPrimerNodo();
            }
            else if (opcion.compareTo("8")==0)
            {
                c.MostrarUltimoNodo();
            }
            else
            {
                c.decolar();
            }
            System.out.println("Desea salir de la aplicacion? s/n :");
            opcion=entrada.readLine();
            while ( (opcion.compareTo("s")!=0) && (opcion.compareTo("S")!=0) && (opcion.compareTo("n")!=0) && (opcion.compareTo("N")!=0) )
            {
    		
    		System.out.println("Error. Ingrese la opcion correcta:");
    		opcion=entrada.readLine();
            }       
        }
    } 
    static class Nodo
    {
        String info;
        Nodo sig;
        public Nodo()
        {
            this.info="";
            this.sig=null;
        }
    }
    static class Pila
    {
        int num_nodos;
        Nodo punta;
        //constructor
        public Pila()
        {
            this.num_nodos=0;
            this.punta=null;
        }
        // ingreso un elemento a la pila (el ultimo en ingresar es el primero en la pila)
        public void apilar(Nodo nuevo) throws IOException
        {
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            System.out.println("Ingrese el contenido del nuevo nodo");
            nuevo.info=entrada.readLine();
            if (punta!=null)
            {
            
                 nuevo.sig=punta;
            }
            punta=nuevo;
            num_nodos++;
            System.out.println("Nodo agregado satisfactoriamente.");
        }
        //me dice el tamaño de la pila
        public int tamanho()
        {
            return num_nodos;
        }
        //me devuelve verdadero si la pila esta vacia de lo contrario false
        public boolean esVacio() 
        {
            return punta==null;
        }
        //me muestra el ultimo elemento ingresado de lo contrario el mensaje de error 
        public void MostrarPrimerNodo(){
            if(esVacio())
            {
                System.out.println("la pila esta vacia.");
            }
            else
            {
                System.out.println("El primer elemento es: "+punta.info);
            }
        }
        //quita el primer elemento de la pila (osea el ultimo en ingresar)
        public void Desapilar()
        {
            if(esVacio())
            {
                System.out.println("la pila esta vacia");
            }
            else
            {
                punta=punta.sig;
                num_nodos--;
                System.out.println("Nodo desapilado satisfactoriamente.");
            }
        }     
}
    static class Cola
    {
       int num_nodos;
       Nodo primero,ultimo;
       //constructor
       public Cola()
       {
           num_nodos=0;
           primero=null;
           ultimo=null;
       }
       public boolean esVacio(){return primero==null&&ultimo==null;}
       public int tamanho(){return num_nodos;}
       // ingreso elemento (el primero en entrar es el primero en salir)
       public void encolar(Nodo nuevo) throws IOException{
           BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
           System.out.println("Ingrese el contenido del nuevo nodo");
           nuevo.info=entrada.readLine();
           if (esVacio())
            {
                primero=nuevo;
                ultimo=nuevo;
            }
            else
            {
                ultimo.sig=nuevo;
                ultimo=nuevo; 
            }
            num_nodos++;
            System.out.println("Nodo agregado satisfactoriamente.");
        }
        //me quita el primer elemento
       public void decolar(){
            if(esVacio())
            {
                System.out.println("la cola esta vacia.");
            }
            else
            {
                primero=primero.sig;
                if (primero==null)
                {
                
                    ultimo=null;
                }
                num_nodos--;
                System.out.println("Nodo desencolado satisfactoriamente.");
            }
        }
       //me muestra el primer elemento ingresado de lo contrario el mensaje de error 
        public void MostrarPrimerNodo(){
            if(esVacio())
            {
                System.out.println("la cola esta vacia");
            }
            else
            {
                System.out.println("El primer elemento es: "+primero.info);
            }
        }
        //me muestra el ultimo elemento ingresado de lo contrario el mensaje de error 
        public void MostrarUltimoNodo(){
            if(esVacio())
            {
                System.out.println("la cola esta vacia");
            }
            else
            {
                System.out.println("El ultimo elemento es: "+ultimo.info);
            }
        }      
    }
}