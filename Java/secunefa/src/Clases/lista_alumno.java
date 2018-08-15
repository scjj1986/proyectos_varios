
package Clases;

import java.io.*;


public class lista_alumno {
    
    
    public alumno l;
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
        if (existearchivo("alumno.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("alumno.obj"));
            alumno aux=(alumno)entrada.readObject();
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
    
    public  void guardaralumno(alumno alu)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (!existearchivo("alumno.obj"))
        {
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("alumno.obj"));
            salida.writeObject(alu);
            salida.close();
        }
        else{
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("alumno.obj"));
            alumno aux=(alumno)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux.sig!=null)
            {
                aux=aux.sig;
            }
            aux.sig=alu;
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("alumno.obj"));
            salida.writeObject(l);
            salida.close();
        }
       
    }
    
    public  void actualizaralumno(String ced,String nom,String ape,String dir)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (existearchivo("alumno.obj"))
        {
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("alumno.obj"));
            alumno aux=(alumno)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if (aux.cedula.equals(ced))
                {
                
                    aux.nombre=nom;
                    aux.apellido=ape;
                    aux.direccion=dir;
                }
                
                aux=aux.sig;
            }
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("alumno.obj"));
            salida.writeObject(l);
            salida.close();
        }
       
    }
    
}
