/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
import java.io.*;
import Clases.*;

public class ProyectoAVL {
    public static void main(String[] args) throws Exception {
        System.out.println("Bienvenidos a la aplicacion Arbol AVL\n");
        Arbol AVL = new Arbol();
        if (AVL.existe_archivo("entrada.in")){
        
            if (!AVL.analizarprimeralinea()){
            
               System.out.println("Formato de dato erroneo. En el archivo deben haber valores numericos mayores que 0\n"); 
            }
            else{
            
                AVL.insert();
                AVL.imprimirPorNiveles();
                System.out.println("\n");
            }
        
        
        }
        else{
        
            System.out.println("No se encuentra el archivo de entrada\n");
        
        
        }

        /*Integer elemento1 = new Integer("10");
        Integer elemento2 = new Integer("12");
        Integer elemento3 = new Integer("5");
        Integer elemento4 = new Integer("2");
        Integer elemento5 = new Integer("11");
        /*Integer elemento6 = new Integer("6");
        Integer elemento7 = new Integer("7");
        Integer elemento8 = new Integer("15");
        Integer elemento9 = new Integer("14");
        Integer elemento10 = new Integer("13");

        AVL.insert(elemento1);
        AVL.insert(elemento2);
        AVL.insert(elemento3);
        AVL.insert(elemento4);
        AVL.insert(elemento5);
        AVL.insert(elemento6);
        AVL.insert(elemento7);
        AVL.insert(elemento8);
        AVL.insert(elemento9);
        AVL.insert(elemento10);*/

        

    }
}



