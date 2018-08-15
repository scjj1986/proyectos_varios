/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;

import java.io.*;
import java.util.*;


public class AVLArbol {
    
    public AVLNodo raiz;
  /*
   * Constructor por defecto
  */
  public AVLArbol( )
  {
    raiz = null;
  }
  /*
   * Insertar: Duplicados son ignorados.
   * x es el dato a ser insertado.
  */
  public boolean existe_archivo(String nombre)throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {//metodo de tipo booleano que verifica de los archivos de entrada y salida, pasando por parámetro el nombre de un archivo específico
        boolean aux=true;
        try{//inntenta buscarlo
            File entrada=new File(nombre);
            FileReader fr = new FileReader (entrada);
            BufferedReader br = new BufferedReader(fr);
        }
            catch (FileNotFoundException e) {//si no lo encuentra
            aux=false;
         }
        return aux;
    }
  
  public boolean analizarprimeralinea()throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {
    
        boolean aux=true;
        if (existe_archivo("entrada.in")){
            File archivo = new File ("entrada.in");
            FileReader fr = new FileReader (archivo);
            BufferedReader br = new BufferedReader(fr);
            String linea=br.readLine();
            String cadena="";
            StringTokenizer st= new StringTokenizer(linea," ");
            while(st.hasMoreTokens()) {

                    cadena=st.nextToken();
                    if (!numerico(cadena)){
                    
                        aux=false;
                    }
                
            }
        
        }
    
        return aux;
    
    }
  public boolean numerico (String cadena)//Metodo booleano para verificar si una cadena (pasada por parámetro) es numerica, 
    {  
        try//Intenta
        {
            Integer.parseInt(cadena);
            return true;
        }
        catch(NumberFormatException nfe)//si no tiene formato numerico...
        {
          return false;//devuelve falso
        }
    }
  
  public void insertar()throws Exception,IOException,ClassNotFoundException,FileNotFoundException
  {
    
      if (existe_archivo("entrada.in")){
            File archivo = new File ("entrada.in");
            FileReader fr = new FileReader (archivo);
            BufferedReader br = new BufferedReader(fr);
            String linea=br.readLine();
            Integer elemento;
            StringTokenizer st= new StringTokenizer(linea," ");
            while(st.hasMoreTokens()) {

                elemento= new Integer(st.nextToken());   
                raiz= insertar(elemento,raiz);
                
            }
        
        }
  }
  
   
  /*
   * Test, si el arbol esta vacio o no.
   * devuelve true, caso de vacio; sino false.
  */
  
  public boolean esVacio( )
  {
   return raiz==null;
  }
          
  /*
   * Metodo interno para tomar un nodo del arbol.
   * Parametro b referencia al nodo del arbol.
   * Devuelve los elementos o null,
   * caso de b sea null.
  */
  private Comparable elementAt(AVLNodo b )
  {
    return b == null ? null : b.datos;
  }
  /*
   * Metodo Interno para agregar o insertar un nodo en un subarbol.
   * x es el elemento a agregar.
   * b es el correspondiente nodo raiz.
   * Devuelve la nueva raiz del respectivo subarbol.
  */
  private AVLNodo insertar(Comparable x, AVLNodo b)
  {
   if( b == null ){
    b = new AVLNodo(x, null, null);
   }else if (x.compareTo( b.datos) < 0 )
        {
         b.izq = insertar(x, b.izq );
         if (altura( b.izq ) - altura( b.der ) == 2 )
         if (x.compareTo( b.izq.datos ) < 0 )
          b = RotacionSimpleIzq(b); 
         else
          b = RotacionDobleIzq_Der(b); 
        }
        else if (x.compareTo( b.datos ) > 0 )
             {
              b.der = insertar(x, b.der);
              if( altura(b.der) - altura(b.izq) == 2)
               if( x.compareTo(b.der.datos) > 0 )
                 b = RotacionSimpleDer(b); 
               else
                 b = RotacionDobleDer_Izq(b);
             }
             else
                ;  // Duplicados; no hace nada
   b.altura = max( altura( b.izq ), altura( b.der ) ) + 1;
   return b;
  }
  
  
  public int calcularAltura(){
        return calcularAltura(raiz);
    }
  
  private int calcularAltura(AVLNodo actual ){
       if (actual == null){
            return -1;
       }else{
            return 1 + Math.max(calcularAltura(actual.izq), calcularAltura(actual.der));}
    }
  
  public void imprimirPorNiveles(){
        imprimirPorNiveles(raiz);
    }

    // Imprime el arbol por niveles.
    public void imprimirPorNiveles(AVLNodo nodo){
        // Mediante la altura calcula el total de nodos posibles del árbol
        // Y crea una array cola con ese tamaño
        int max = 0;
        int nivel = calcularAltura();

        for ( ; nivel >= 0; nivel--)
            max += Math.pow(2, nivel);
        max++;      // Suma 1 para no utilizar la posicion 0 del array

        AVLNodo cola[] = new AVLNodo[ max ];

        // Carga en la pos 1 el nodo raiz
        cola[1] = nodo;
        int x = 1;

        // Carga los demas elementos del arbol,
        // Carga null en izq y der si el nodo es null
        // i aumenta de a 2 por q carga en izq y der los hijos
        // x aumenta 1, que son los nodos raiz - padre
        for (int i = 2; i < max; i += 2, x++){
            if (cola[x] == null){
                cola[i] = null;
                cola[i + 1] = null;
            }
            else{
                cola[i]   = cola[x].izq;
                cola[i + 1] = cola[x].der;
            }
        }
        nivel = 0;
        int cont = 0;                       // contador para cada nivel
        int cantidad = 1;                   // cantidad de nodos por nivel
        int ultimaPosicion = 1;             // ultimaPosicion del nodo en la cola de cada nivel

        // Cuando i es = a 2^nivel hay cambio de nivel
        // 2 ^ 0 = 1 que es el nodo raiz
        for (int i = 1; i < max; i++){
            if(i == Math.pow(2, nivel)){
            	// Nodo raiz tiene nivel 1, por eso (nivel + 1)
            	System.out.print("\n Nivel " + (nivel) + ": ");
                nivel++;
            }
            if( cola[i] != null ){
                System.out.print("[" + cola[i].datos + "]");
                cont++;
            }
            if(ultimaPosicion == i  && cantidad == Math.pow(2, --nivel)){
                if(cantidad == 1){
                    System.out.print(" Cantidad de nodos: " + cont + " (raiz)");
                }else{
                    System.out.print(" Cantidad de nodos: " +  cont);}
                cont = 0;
                cantidad *= 2;
                ultimaPosicion += (int)Math.pow(2, ++nivel);
            }
        }
    }
  
  public void RecopilarPorNiveles(AVLNodo nodo)throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {
        // Mediante la altura calcula el total de nodos posibles del árbol
        // Y crea una array cola con ese tamaño
        int max = 0;
        String linea="";
        int nivel = calcularAltura();

        for ( ; nivel >= 0; nivel--)
            max += Math.pow(2, nivel);
        max++;      // Suma 1 para no utilizar la posicion 0 del array

        AVLNodo cola[] = new AVLNodo[ max ];

        // Carga en la pos 1 el nodo raiz
        cola[1] = nodo;
        int x = 1;

        // Carga los demas elementos del arbol,
        // Carga null en izq y der si el nodo es null
        // i aumenta de a 2 por q carga en izq y der los hijos
        // x aumenta 1, que son los nodos raiz - padre
        for (int i = 2; i < max; i += 2, x++){
            if (cola[x] == null){
                cola[i] = null;
                cola[i + 1] = null;
            }
            else{
                cola[i]   = cola[x].izq;
                cola[i + 1] = cola[x].der;
            }
        }
        nivel = 0;
        int cont = 0;                       // contador para cada nivel
        int cantidad = 1;                   // cantidad de nodos por nivel
        int ultimaPosicion = 1;             // ultimaPosicion del nodo en la cola de cada nivel

        // Cuando i es = a 2^nivel hay cambio de nivel
        // 2 ^ 0 = 1 que es el nodo raiz
        for (int i = 1; i < max; i++){
            if(i == Math.pow(2, nivel)){
            	// Nodo raiz tiene nivel 1, por eso (nivel + 1)
                grabar_archivo_salida(linea);
                linea="";
                nivel++;
            }
            if( cola[i] != null ){
                linea=linea+"[" +cola[i].datos+"]";
                cont++;
            }
            
        }
    }
  public void grabar_archivo_salida(String cadena)throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {//Método para guardar en el archivo "REPORTE.out", una cadena de caracteres pasada por parámetro
        if (existe_archivo("salida.out")){//De existir el archivo...
        
            File archivo = new File ("salida.out");
            FileWriter fw = new FileWriter (archivo,true);
            PrintWriter pw = new PrintWriter (fw);
            pw.println(cadena);//...Se abre el archivo y se escribe al final
            fw.close();
            pw.close();//Se cierran los gestores para escritura del archivo
        }
    }
  
  private static int altura(AVLNodo b)
  {
   return b == null ? -1 : b.altura;
  }
  /*
   * Salida: Maximum entre lhs y rhs.
  */
  private static int max( int lhs, int rhs )
  {
   return lhs > rhs ? lhs : rhs;
  }
  /*
   * Rotacion Simple Izquierda(simetrica a Rotacion Simple Derecha).
   * Para los arboles AVL, esta es una de las simples rotaciones.
   * Actualiza la altura, devuelve la nueva raiz.
  */
  private static AVLNodo RotacionSimpleIzq(AVLNodo k2)
  {
   AVLNodo k1 = k2.izq;
       k2.izq = k1.der;
      k1.der = k2;
       k2.altura = max( altura( k2.izq ), altura( k2.der ) ) + 1;
       k1.altura = max( altura( k1.izq ), k2.altura ) + 1;
   return k1;
  }
  /*
  * Rotación Simple Derecha.
  */
  private static AVLNodo RotacionSimpleDer(AVLNodo k1)
  {
   AVLNodo k2 = k1.der;
      k1.der = k2.izq;
      k2.izq = k1;
      k1.altura = max( altura( k1.izq ), altura( k1.der ) ) + 1;
      k2.altura = max( altura( k2.der ), k1.altura ) + 1;
   return k2;
  }
  /*
         * Rotacion doble: primero hijo izquierdo con su hijo derecho
         * entonces nodo k3 con el nuevo hijo izquierdo.
         * para los arboles AVL, esta es una doble rotación
         * actualiza alturas, entrega nueva raiz.
  */
  private static AVLNodo RotacionDobleIzq_Der(AVLNodo k3)
  {
   k3.izq = RotacionSimpleDer( k3.izq );
   return RotacionSimpleIzq( k3 );
  }
  /*
         * rotacion doble: primero hijo derecho
         * con su hijo izquierdo; luego nodo k1 con nuevo hijo derecho.
         * Para los AVL, esta es una doble rotación.
         * actualiza alturas, entrega nueva raiz.
  */
  private static AVLNodo RotacionDobleDer_Izq(AVLNodo k1)
  {
   k1.der = RotacionSimpleIzq(k1.der);
   return RotacionSimpleDer(k1);
  }

    
}
