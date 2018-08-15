package archivo4;

import java.io.*;
import java.util.*;

public class Archivoapp4 {
    public static void main(String[] args) throws IOException,ClassNotFoundException,FileNotFoundException {
            /*lista lista1= new lista("a");
            lista1.sig= new lista("b");
        
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("media.obj"));
            salida.writeObject(lista1);
            salida.close();
            */
        try{
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("media.obj"));
            lista obj1=(lista)entrada.readObject();
            entrada.close();
        }
            catch (FileNotFoundException ex) {
            System.out.println("cero neke");
         }
            
                    
            /*while (obj1!=null)
            {
                System.out.println(obj1.info);
                obj1=obj1.sig;
            }
            
            */
//se puede fundir en una catch Exception
        

        try  {
//espera la pulsación de una tecla y luego RETORNO
            System.in.read();
        }catch (Exception e) {  }
   }
}