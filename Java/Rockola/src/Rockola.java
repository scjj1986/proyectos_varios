import java.io.*;
import Clases.*;
public class Rockola {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception {
        Listas lrep= new Listas();//Instancia de la lista de reproduccion
        Cancion nuevo;//Nodo nuevo
        boolean salir=false;//variable booleana para gestionar la salida de la aplicación
        boolean prior=false;//variable boleana para verificar la prioridad de una lista de canciones ingresadas por el ususario
        int ncanciones;//variable entera que guarda el número de canciones
        int monto,monto2;//variables enteras que calcula el valor a cancelar y el valor a depositar en la rockola respectivamente
        int enter;//Variable para "Presione ENTER para continuar..."
        String cad,cad2;//variable útiles para grabar en los archivos "rockola.in" y "REPORTE.out"
        String respuesta,resp="";//variable para los menus y preguntas al ausuario
        //Inicialización de los archivos "rockola.in" y "REPORTE.out"
        File archivo;
        archivo = new File ("rockola.in");
        FileWriter fw = new FileWriter (archivo);
        fw.close();
        archivo = new File ("REPORTE.out");
        fw = new FileWriter (archivo);
        fw.close();
        String codigo="";//variable que contendrá un código de una canción específica
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));//Para leer por cónsola
        System.out.println("Bienvenidos a la aplicacion ROCKOL-UDO\n");
        while (!salir){//Iteración del menú principal
            System.out.println("\n<------------------ABANICO DE OPCIONES--------------------->:\n");
            System.out.println(" 1) Para verificar la lista de reproduccion de la rockola\n");
            System.out.println(" 2) Para agregar canciones a la lista de reproduccion de la rockola\n");
            System.out.println(" 3) Si desea salir de la aplicacion\n");
            respuesta=teclado.readLine();//leer respuesta del menú
            while (  (respuesta.compareTo("1")!=0) && (respuesta.compareTo("2")!=0) && (respuesta.compareTo("3")!=0)){//validación
            
                System.out.println(" Opcion invalida. intente de nuevo:\n");
                respuesta=teclado.readLine();
            
            }
            if (respuesta.compareTo("1")==0){//Si eligió la lista de reproducción...
            
                if ((lrep.priori==null) && (lrep.sinpriori==null)){//...Si las listas con y sin prioridad están vacías...
                
                    System.out.println("Lista de reproduccion vacia\n");//...Mensaje
                
                }
                else if ((lrep.priori!=null)){//De haber canciones con prioridad...
                
                    System.out.println("<------------------ REPRODUCCION EN CURSO... --------------->\n");//Mostrar reproducción en curso (1ero de la lista)
                    System.out.println("*"+lrep.priori.codigo);
                    System.out.println(" "+lrep.priori.nombre);
                    System.out.println(" Artista: "+lrep.priori.artista);
                    System.out.println(" Album: "+lrep.priori.album);
                    System.out.println(" Track: "+lrep.priori.track);
                    System.out.println("\n<--------------- LISTA COMPLETA ----------------------------\n");//Mostrar lista completa
                    lrep.mostrar_lista(lrep.priori);//Lista con prioridad
                    lrep.mostrar_lista(lrep.sinpriori);//Lista sin prioridad
                    System.out.println("\n<--------------------------------------------------------->\n");
                }
                else{//De nada más haber canciones sin prioridad...
                    System.out.println("<------------------ REPRODUCCION EN CURSO... --------------->\n");//Mostrar reproducción en curso y lista completa
                    System.out.println("*"+lrep.sinpriori.codigo);
                    System.out.println(" "+lrep.sinpriori.nombre);
                    System.out.println(" Artista: "+lrep.sinpriori.artista);
                    System.out.println(" Album: "+lrep.sinpriori.album);
                    System.out.println(" Track: "+lrep.sinpriori.track);
                    System.out.println("\n<--------------- LISTA COMPLETA ----------------------------\n");
                    lrep.mostrar_lista(lrep.sinpriori);
                    System.out.println("\n<--------------------------------------------------------->\n");
                
                }
                System.out.println("Pulse ENTER para continuar...");
                do{
                    enter=System.in.read();
                }while(enter!=10);
            }
            else if(respuesta.compareTo("2")==0){//Si eligió agregar canciones a la rockola
                
                ncanciones=0;
                lrep.mostrar_canciones_in();//Se muestra las canciones disponibles
                
                do{
                    prior=false;//sin prioridad por defecto
                    System.out.println("\nIngrese el codigo de la cancion:");
                    codigo=teclado.readLine();//leer codigo
                    while (!lrep.buscar_cancion_archivo(codigo)){//Mientras el código no se encuentre en "canciones.in"
                        System.out.println("Codigo no encontrado. intente de nuevo");
                        codigo=teclado.readLine();
                    }
                    nuevo= new Cancion();//se instancia el nuevo nodo que contendrá la cancion a agregar a la lista temporal
                    nuevo.codigo=codigo;// Copia código
                    nuevo.nombre=lrep.obtener_nombre_cancion(codigo);//Por el códigode la canción elegida, se obtiene el resto de los datos
                    nuevo.artista=lrep.obtener_nombre_artista(codigo);
                    nuevo.album=lrep.obtener_nombre_album(codigo);
                    nuevo.track=codigo.substring(codigo.length()-2,codigo.length());
                    System.out.println("\n<----------------- DATOS DE LA CANCION SELECCIONADA ----------------->");//mostrar cancion seleccionada
                    System.out.println("\n*Codigo: "+nuevo.codigo);
                    System.out.println(" Nombre: "+nuevo.nombre);
                    System.out.println(" Artista: "+nuevo.artista);
                    System.out.println(" Album: "+nuevo.album);
                    System.out.println(" Track: "+nuevo.track);
                    System.out.println("\n<-------------------------------------------------------------------->");
                    lrep.temp=lrep.agregar_a_lista(lrep.temp, nuevo);//Se agrega la nueva cancion a la lista temporal
                    System.out.println("\n Desea elegir otra cancion (s/n)?:");//Pregunta
                    resp=teclado.readLine();
                    while (  (resp.compareTo("s")!=0) && (resp.compareTo("S")!=0) && (resp.compareTo("n")!=0) && (resp.compareTo("N")!=0)  ){

                        System.out.println(" Opcion invalida. intente de nuevo:\n");//validacion
                        resp=teclado.readLine();
                    }
                    ncanciones++;//autonicrementar el contador de canciones
                
                }while ((resp.equals("S")) || (resp.equals("s")) );//Mientras quiera seguir seleccionando canciones
                System.out.println("\nModo de reproduccion de la(s) cancion(es) seleccionada(s): \n");//Modo de reproduccion
                System.out.println("1) Secuencial.");
                System.out.println("2) Aleatorio:");
                resp=teclado.readLine();//Leer entrada
                while (  (resp.compareTo("1")!=0) && (resp.compareTo("2")!=0)  ){//validación

                    System.out.println(" Opcion invalida. intente de nuevo:\n");
                    resp=teclado.readLine();
                }
                if(resp.compareTo("1")==0){//Si es secuencial
                
                    cad2="SECUENCIAL ";//concatenar en cad2, detalles de la seleccion del usuario
                }
                else{//Si es aleatorio
                    lrep.temp=lrep.generar_lista_aleatoria(ncanciones);//generar lista aleatoria
                    cad2="ALEATORIO ";//concatenar en cad2, detalles de la seleccion del usuario
                }
                System.out.println("\nDesea establecer prioridad en la(s) cancion(es) seleccionada(s)?: (s/n)");
                resp=teclado.readLine();//leer entrada de prioridad
                while (  (resp.compareTo("s")!=0) && (resp.compareTo("S")!=0) && (resp.compareTo("n")!=0) && (resp.compareTo("N")!=0)  ){

                    System.out.println(" Opcion invalida. intente de nuevo:\n");//validacion
                    resp=teclado.readLine();
                }
                    System.out.println("\n<----------------- LISTA DE CANCIONES SELECCIONADAS ----------------->");//Mostrar canciones seleccionadas
                    lrep.mostrar_lista(lrep.temp);
                    System.out.println("\n<-------------------------------------------------------------------->");
                    if (resp.equals("n") || resp.equals("N")){//Si no hubo prioridad, se calcula el monto y a cad2 se le concatena los detalles de la seleccion
                    
                        if (ncanciones<4){
                            monto=10*ncanciones;
                        }
                        else{
                            monto=5*(3+ncanciones);
                        }
                        cad2 = cad2 + "FINALIZAR";
                    
                    }else{//Del mismo modo con prioridad
                        if (ncanciones<4){
                        
                            monto=(10*ncanciones)+ ((10*ncanciones)/2);
                        }
                        else{
                        
                            monto=(5*(3+ncanciones))+((5*(3+ncanciones))/2);
                        }
                        cad2 = cad2 + "PRIORIDAD FINALIZAR";
                        prior=true;
                    }
                    monto2=0;
                    if (ncanciones>5){//Si la cantidad de canciones excede de 5...
                        
                        System.out.println("\nTransaccion Cancelada: Limite de canciones excedido.");//Se muestra por pantalla
                        cad="Transaccion Cancelada, Motivo: Limite de canciones excedido.";//Se guarda en cad el detalle de la transaccion fallida para agregarse en "REPORTE.out"
                    }
                    else{//Si no..
                    
                        System.out.println("\nMonto a cancelar: "+monto+" Bs.");//Se notifica el monto a cancelar...
                        System.out.println("Ingrese el monto a insertar en la rockola (Bs.):");//Y se le pide el monto a ingresar a la rockola
                        cad=teclado.readLine();//se lee
                        while (!lrep.numerico(cad)){//Validación en caso de no ser numerico

                            System.out.println("Monto no numerico. Intente de nuevo:");
                            cad=teclado.readLine();
                        }
                        monto2=Integer.parseInt(cad);
                        if(monto2<monto){//Si el monto a insertar en la rockola es menor a cancelar...

                            System.out.println("\nTransaccion Cancelada: Pago insuficiente.");//Se muestra por pantalla
                            cad="Transaccion Cancelada, Motivo: Pago insuficiente";//Se guarda en cad el detalle de la transaccion fallida para agregarse en "REPORTE.out"
                        }
                        else{//Si es mayor
                            lrep.totalbs=lrep.totalbs+monto;//Se va sumando al monto total
                            System.out.println("\nTransaccion exitosa, Vuelto: "+Integer.toString(monto2-monto)+" Bs.");//Se muestra por pantalla y el vuelto
                            cad="Transaccion exitosa, Vuelto: "+Integer.toString(monto2-monto)+" Bs.";//Se guarda en cad el detalle de la transaccion para agregarse en "REPORTE.out"
                            if (prior){//Si las canciones tienen prioridad
                                lrep.priori=lrep.agregar_a_lista(lrep.priori,lrep.temp);//Se agregan a la lista de prioridad
                            }
                            else{//De lo contrario, se agregan a la lista sin prioridad
                                lrep.sinpriori=lrep.agregar_a_lista(lrep.sinpriori,lrep.temp);
                            }
                        }
                    }
                    lrep.grabar_archivo_reporte(cad);//Se guarda en "REPORTE.out", los detalles de la transacción que está contenida en cad
                    cad="ACEPTAR " + cad2;//Se completa cad para grabarse en "rockola.in"
                    lrep.grabar_archivo_rockola(Integer.toString(monto2), cad);//Aquí se graba en "rockola.in", la información de la variable cad
                    lrep.temp=null;
                    System.out.println("\nPulse ENTER para continuar...");
                    do{
                        enter=System.in.read();
                    }while(enter!=10);
            }
            else//Si desea salir de la aplicació
            {
                //Se agrega al archivo "REPORTE.out", la cantidad de canciones sin y con prioridad, total de canciones y el total de ingreso
                cad="Numero de Canciones Sin Prioridad: "+Integer.toString(lrep.n_canciones_lista(lrep.sinpriori));
                lrep.grabar_archivo_reporte(cad);
                cad="Numero de Canciones Con Prioridad: "+Integer.toString(lrep.n_canciones_lista(lrep.priori));
                lrep.grabar_archivo_reporte(cad);
                cad="Total de Canciones: "+Integer.toString(lrep.n_canciones_lista(lrep.priori)+lrep.n_canciones_lista(lrep.sinpriori));
                lrep.grabar_archivo_reporte(cad);
                cad="total Bs. "+Integer.toString(lrep.totalbs);
                lrep.grabar_archivo_reporte(cad);
                salir=true;//para salir de la aplicación
            }
        }
    }
}
