
import java.io.*;
import Clases.*;

public class Principal {
    public static void main(String[] args) throws Exception {
        System.out.println("Bienvenidos a la aplicacion Arbol AVL\n");
        AVLArbol AVL = new AVLArbol();
        File archivo = new File ("salida.out");
        FileWriter fw = new FileWriter (archivo);
        fw.close();
        int enter;
        if (AVL.existe_archivo("entrada.in")){
        
            if (!AVL.analizarprimeralinea()){
            
               System.out.println("Formato de dato erroneo. En el archivo deben haber valores numericos\n"); 
            }
            else{
            
                AVL.insertar();
                System.out.println("El archivo de entrada fue procesado satisfactoriamente. Pulse ENTER para generar el archivo de salida...");
                do{
                    enter=System.in.read();
                }while(enter!=10);
                AVL.RecopilarPorNiveles(AVL.raiz);
                System.out.println("El archivo de salida fue generado satisfactoriamente. Pulse ENTER para mostrar como quedo el arbol...");
                do{
                    enter=System.in.read();
                }while(enter!=10);
                AVL.imprimirPorNiveles(AVL.raiz);
                System.out.println("\n Pulse ENTER para finalizar la aplicacion...");
                do{
                    enter=System.in.read();
                }while(enter!=10);
            }
        }
        else{
        
            System.out.println("No se encuentra el archivo de entrada\n");
        }
    }
}
