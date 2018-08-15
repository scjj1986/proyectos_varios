
package Clases;

import java.io.*;
import java.util.*;

public class Listas {//clase en donde están adjuntos los apuntadores a las listas: priori (canciones con prioridad), sinpriori (canciones sin prioridad) y temp (canciones que está seleccionando el usuario de turno)
    
    public Cancion priori,sinpriori,temp;
    public int totalbs;//almacenará el ingreso total de la rockola
    public Listas(){//constructor
        this.priori=null;
        this.priori=null;
        this.temp=null;
        this.totalbs=0;
    }
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
    
    public Cancion agregar_a_lista(Cancion l, Cancion nodo){//metodo que agrega un nodo (cancion) a una lista especifica pasada por parámetro. Devuelve el apuntador al primer nodo de la lista actualizada
        if (l==null){//si la lista esta vacia...
        
            l=nodo;//...Se agrega el nuevo de primero
        }
        else{//De no ser nula la lista...
            Cancion aux=l;//...Se usa un apuntador auxiliar para recorrer la lista
            while (aux.sig!=null){//ciclo para llegar al ultimo nodo (cancion)
            
                aux=aux.sig;
            }
            aux.sig=nodo;//se agrega al final el nodo nuevo
        }
        return l;//Una vez actualizada la lista, se devuelve el valor del apuntador al primer nodo de dicha lista
    }
    
    public void mostrar_canciones_in()throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {//Método para mostrar el contenido del archivo "canciones.in"
    
        if (existe_archivo("canciones.in")){//si el archivo está...

                        String linea;
                        File archivo = new File ("canciones.in");
                        FileReader fr = new FileReader (archivo);
                        BufferedReader br = new BufferedReader(fr);//...Se abre para lectura
                        System.out.println("\n<----------------- GRILLA DE CANCIONES DISPONIBLES ----------------->");
                        System.out.println("\nCODIGO          NOMBRE\n");
                        while((linea=br.readLine())!=null){//se va leyendo línea por línea
                            System.out.println (linea);//cada línea se va mostrando por pantalla

                        }
                        System.out.println("\n<------------------------------------------------------------------->");          
        }
    
    }
     public boolean buscar_cancion_archivo(String cod) throws Exception,IOException,ClassNotFoundException,FileNotFoundException
     {//Método booleano que busca el código de una canción en el archivo "canciones.in"
         boolean aux=false;//valor por defecto para empezar la búsqueda
         if (existe_archivo("canciones.in")){//Si existe el archivo...
        
            File archivo = new File ("canciones.in");
            FileReader fr = new FileReader (archivo);
            BufferedReader br = new BufferedReader(fr);//Se abre para lectura
            String linea,codigo="";
            StringTokenizer st;//Variable útil para desglosar cada línea de archivo y obtener el código de cada canción
            boolean salir;
            while((linea=br.readLine())!=null){//Recorrido línea por línea
                
                /*Aquí se desglosa cada línea obtenida; como el código y el nombre de 
                cada canción están separados por tabulaciones, la variable "st" obtiene
                simultáneamente ambos valores por separado como si fuera una lista*/
                st= new StringTokenizer (linea,"\t");
                salir=false;
                while((st.hasMoreTokens()) && (!salir)) {//se verifica el desglose de la línea..

                    codigo= st.nextToken();//Se accede al código y se guarda en otra variable

                    salir=true;//El nombre de la canción no es necesario. Línea de código para salir del ciclo

                }
                if (codigo.equals(cod)){//Si el código obtenido de la línea coincide con el pasado por parámetro...
                    aux=true;//variable aux se le asigna verdadero
                } 
            }
            fr.close();
            br.close();//se cierran los gestores para la lectura del archivo
        }
         return aux;//El método devuelve el valor de la variable aux
     }
     
     public String obtener_nombre_cancion(String cod) throws Exception,IOException,ClassNotFoundException,FileNotFoundException
     {//Metodo que devuelve el nombre de una canción del archivo "canciones.in", a partir del código pasado por parámetro
        String aux="";
        if (existe_archivo("canciones.in")){//si existe..
            File archivo = new File ("canciones.in");
            FileReader fr = new FileReader (archivo);
            BufferedReader br = new BufferedReader(fr);//se abre para leer
            String nombre="";
            String codigo="";
            String linea;
            StringTokenizer st;
            boolean salir=false;
            while((linea=br.readLine())!=null){//recorrer cada línea del archivo
                st= new StringTokenizer (linea,"\t");//obtener codigo y nombre de cada cancion por separado
                
                while(st.hasMoreTokens() || !salir) {//recorrido de la linea desglosada

                    codigo = st.nextToken();//guardar codigo

                    nombre = st.nextToken();//guardar nombre
                    salir = true;//salir del ciclo
                
                }
                if (codigo.equals(cod)){//Si el código obtenido de la línea coincide con el pasado por parámetro...
                    aux=nombre;//a aux le asigno el nombre de la linea coincidente
                }
            }
            fr.close();
            br.close();//cerrar gestores de archivo
        }
        return aux;//Devuelve el nombre
    
    }
    public String obtener_nombre_artista(String cod) throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {/*Metodo que devuelve el nombre del artista de una canción del archivo 
       "artistas.in", a partir del código de una cancion pasado por parámetro. (Muy parecido al método "obtener_nombre_cancion")*/
        String aux="";
        if (existe_archivo("artistas.in")){
            File archivo = new File ("artistas.in");
            FileReader fr = new FileReader (archivo);
            BufferedReader br = new BufferedReader(fr);
            String codigo="";
            String nombre="";
            String linea;
            StringTokenizer st;
            while((linea=br.readLine())!=null){
                st= new StringTokenizer (linea,"\t");
                
                while(st.hasMoreTokens()) {

                    codigo = st.nextToken();

                    nombre = st.nextToken();
                
                }
                if (cod.indexOf(codigo)==0){//Los 3 primeros dígitos de una canción, son los de un artista específico; Si el código del artista, coincide con los 3 dígitos del de la canción...
                
                    aux=nombre;
                }
            }
            fr.close();
            br.close();//Cierre de los gestores para escritura de archivo
        }
        return aux;//Acá devuelve el nombre del artista coincidente
    
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
    public void grabar_archivo_reporte(String cadena)throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {//Método para guardar en el archivo "REPORTE.out", una cadena de caracteres pasada por parámetro
        if (existe_archivo("REPORTE.out")){//De existir el archivo...
        
            File archivo = new File ("REPORTE.out");
            FileWriter fw = new FileWriter (archivo,true);
            PrintWriter pw = new PrintWriter (fw);
            pw.println(cadena);//...Se abre el archivo y se escribe al final
            fw.close();
            pw.close();//Se cierran los gestores para escritura del archivo
        }
    }
    
    public void grabar_archivo_rockola(String monto,String cadena)throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {//Método para guardar en el archivo "rockola.in", una cadena de caracteres
        if (existe_archivo("rockola.in")){//De existir el archivo...
        
            File archivo = new File ("rockola.in");
            FileWriter fw = new FileWriter (archivo,true);
            PrintWriter pw = new PrintWriter (fw);//...Se abre el archivo para escribir al final
            Cancion aux=temp;//Apuntador aux para recorrer la lista de musicas que serán agregadas a la rockola
            String cad=monto;//Se va preparando la variable cad, asignándole la variable monto pasada por parámetro
            while (aux!=null){//Recorrido de la lista
            
                cad= cad+ " "+aux.codigo;//Concatenando el código de cada cancion
                aux=aux.sig;//siguiente nodo
            
            }
            cad=cad+" ";//Se le concatena el espacio
            cad=cad+cadena;//Aquí se le concatena ahora detalles de la lista de música recién seleccionadas: el tipo de reproducción,prioridad, entre otros.
            pw.println(cad);//Completada la cadena de caracteres se graba en el archivo
            pw.close();
            fw.close();//Cierre de los gestores de escritura de archivo
        }
    
    }
    public String obtener_nombre_album(String cod) throws Exception,IOException,ClassNotFoundException,FileNotFoundException
    {/*Metodo que devuelve el nombre del album de una canción del archivo 
       "albumes.in", a partir del código de una cancion pasado por parámetro. (Muy parecido al método "obtener_nombre_artista")*/
        String aux="";
        if (existe_archivo("albumes.in")){
            File archivo = new File ("albumes.in");
            FileReader fr = new FileReader (archivo);
            BufferedReader br = new BufferedReader(fr);
            String codigo="";
            String nombre="";
            String linea;
            StringTokenizer st;
            while((linea=br.readLine())!=null){
                st= new StringTokenizer (linea,"\t");
                
                while(st.hasMoreTokens()) {

                    codigo = st.nextToken();

                    nombre = st.nextToken();
                }
                if (cod.indexOf(codigo)==0){//Los 6 primeros dígitos de una canción, son los de un album específico; Si el código del album, coincide con los 6 dígitos del de la canción...
                
                    aux=nombre;
                }
            }
            fr.close();
            br.close();//Cierre de los gestores para escritura de archivo
        }
        return aux;//retorna el nombre del album coincidente
    }
    
    public Cancion generar_lista_aleatoria(int canciones){ 
        int[] ndigitos = new int[canciones]; // arreglo para guardar numeros distintos al azar
        int total = 0; // variable para saber cuantos numeros se han agregado
        int nuevo = 0; // numero al azar 
        int aux = 0;// auxiliar para comparar el numero antes de guardarlo 
        int i=0;
        Random r = new Random();// construir random  
        do 
        { 
            nuevo = r.nextInt(canciones)+1;
            i=0;
            aux=0;
            while (i <total) // recorrer la lista de los valores ya guardados 
            { 
                
                if(nuevo == ndigitos[i]) // si el nuevo numero existe en la posicion actual 
                {   
                    aux = 1; 
                } 
                
                i++;
            }
            if(aux == 0)// si al terminar de recorrer la lista no se encontro otro igual  
            { 
                
                ndigitos[total] = nuevo; // agregar en la siguiente posicion el nuevo numero 
                total++; 
            }  
        } while(total < canciones);// agregar numeros mientras el total sea menor a numero de canciones 
        int j=0;
        Cancion aux2,nuevo2,aleat;//variable aux2 para recorrer la lista temporal de canciones, variable nuevo2 para gestionar la creacion de la lista aleatoria y aleat que en ella estará la lista aleatoria
        aleat=null;
        for(i = 0; i < canciones; i++) //Iteracion que va de cancion en cancion
        {
            aux2=temp;
            j=0;
            while (aux2!=null){//recorrido de la lista temporal
              j++;
              if (j==ndigitos[i]){//si el numero aleatorio de turno coincide con la posicion del auxiliar de la lista temporal
              
                  nuevo2=new Cancion();
                  nuevo2.Copiar(aux2.codigo, aux2.nombre, aux2.artista, aux2.album, aux2.track);//Se copia en nuevo2, la información de aux2
                  aleat=agregar_a_lista(aleat,nuevo2);// y se va agregando el nodo nuevo en temp2;
              }
              aux2=aux2.sig;//nodo siguiente de temp
            }
        }
        return aleat;//Acá devuelve el valor de la lista actualizada
    }
    
    public void mostrar_lista(Cancion l){//Método para mostrar los nodos de una lista específica pasada por parámetros
        if (l!=null){
            Cancion aux=l;
            while (aux!=null){//recorrido de la lista
            
                System.out.println("\n*Codigo: "+aux.codigo);
                System.out.println(" Nombre: "+aux.nombre);
                System.out.println(" Artista: "+aux.artista);
                System.out.println(" Album: "+aux.album);
                System.out.println(" Track: "+aux.track);
                aux=aux.sig;//siguiente
            }
        }
    }
    public int n_canciones_lista(Cancion l){//Metodo que calcula la cantidad de nodos de una lista específica pasada por parámetro
        int contador=0;//valor por defecto
        Cancion aux=l;
        while (aux!=null){//se recorre la lista
            
             aux=aux.sig;//siguiente
             contador++;//autoincrementa en 1 el contador de nodos
        }
        return contador;//Aca retorna el valor
    }
}
