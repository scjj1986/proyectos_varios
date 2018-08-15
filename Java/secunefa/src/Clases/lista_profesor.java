/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;
import java.io.*;



public class lista_profesor {
    
    public profesor l;
    
    public  void guardarprofesor(profesor prof)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (!existearchivo("profesor.obj"))
        {
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("profesor.obj"));
            salida.writeObject(prof);
            salida.close();
        }
        else{
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("profesor.obj"));
            profesor aux=(profesor)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux.sig!=null)
            {
                aux=aux.sig;
            }
            aux.sig=prof;
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("profesor.obj"));
            salida.writeObject(l);
            salida.close();
        }
       
    }
    
    public boolean existearchivo(String nombre)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux=true;
        try{
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream(nombre));
            entrada.close();
        }
            catch (FileNotFoundException ex) {
            aux=false;
         }
        return aux;
    }
    
    public boolean cedularepetida(String cedula) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux2=false;
        if (existearchivo("profesor.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("profesor.obj"));
            profesor aux=(profesor)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if(cedula.equals(aux.cedula))
                {
                    aux2=true;
                }
                aux=aux.sig;
            }
        }
        return aux2;
    
    }
    
}
