/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;
import java.io.*;

/**
 *
 * @author salazar
 */
public class lista_seccion {
    
    public seccion l;
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
    
    public  void guardarseccion(seccion sec)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (!existearchivo("seccion.obj"))
        {
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("seccion.obj"));
            salida.writeObject(sec);
            salida.close();
        }
        else{
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("seccion.obj"));
            seccion aux=(seccion)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux.sig!=null)
            {
                aux=aux.sig;
            }
            aux.sig=sec;
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("seccion.obj"));
            salida.writeObject(l);
            salida.close();
        }
       
    }
    
    public boolean seccionrepetida(String cod,String secc) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux2=false;
        if (existearchivo("seccion.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("seccion.obj"));
            seccion aux=(seccion)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if((cod.equals(aux.codigomateria)) && (secc.equals(aux.numero)))
                {
                    aux2=true;
                }
                aux=aux.sig;
            }
        }
        return aux2;
    }
    
    
    public void incrementaralumno(String cod,String secc) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (existearchivo("seccion.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("seccion.obj"));
            seccion aux=(seccion)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if((cod.equals(aux.codigomateria)) && (secc.equals(aux.numero)))
                {
                    aux.alumnos++;
                }
                aux=aux.sig;
            }
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("seccion.obj"));
            salida.writeObject(l);
            salida.close();
        }
    }
    
}
