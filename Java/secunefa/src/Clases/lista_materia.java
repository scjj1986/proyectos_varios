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
public class lista_materia {
    
    public materia l;
    
    public  void guardarmateria(materia mat)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (!existearchivo("materia.obj"))
        {
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("materia.obj"));
            salida.writeObject(mat);
            salida.close();
        }
        else{
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("materia.obj"));
            materia aux=(materia)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux.sig!=null)
            {
                aux=aux.sig;
            }
            aux.sig=mat;
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("materia.obj"));
            salida.writeObject(l);
            salida.close();
        }
       
    }
    
    public  void incrementarseccion(String codmat)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (existearchivo("materia.obj"))
        {
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("materia.obj"));
            materia aux=(materia)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if(codmat.equals(aux.codigo))
                {
                    aux.secciones++;
                }
                aux=aux.sig;
            }
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("materia.obj"));
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
    
    public boolean nombrerepetido(String nombre,String carrera) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux2=false;
        if (existearchivo("materia.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("materia.obj"));
            materia aux=(materia)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if((nombre.equals(aux.nombre)) && (carrera.equals(aux.carrera)))
                {
                    aux2=true;
                }
                aux=aux.sig;
            }
        }
        return aux2;
    }
    
    public boolean codigorepetido(String codigo) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux2=false;
        if (existearchivo("materia.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("materia.obj"));
            materia aux=(materia)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if(codigo.equals(aux.codigo))
                {
                    aux2=true;
                }
                aux=aux.sig;
            }
        }
        return aux2;
    }
    
}
