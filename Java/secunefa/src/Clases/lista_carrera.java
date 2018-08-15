
package Clases;
import java.io.*;


public class lista_carrera {
    public carrera l;
    
    public  void guardarcarrera(carrera car)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (!existearchivo("carrera.obj"))
        {
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("carrera.obj"));
            salida.writeObject(car);
            salida.close();
        }
        else{
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("carrera.obj"));
            carrera aux=(carrera)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux.sig!=null)
            {
                aux=aux.sig;
            }
            aux.sig=car;
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("carrera.obj"));
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
    
    public boolean nombrerepetido(String nombre) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux2=false;
        if (existearchivo("carrera.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("carrera.obj"));
            carrera aux=(carrera)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if(nombre.equals(aux.nombre))
                {
                    aux2=true;
                }
                aux=aux.sig;
            }
        }
        return aux2;
    
    }
}
