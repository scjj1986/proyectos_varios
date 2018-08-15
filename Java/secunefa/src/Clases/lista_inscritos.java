/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;

import java.io.*;


public class lista_inscritos {
    public inscribe l;
    
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
    
    public boolean inscritorepetido(String codmat,String cedal) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        boolean aux2=false;
        if (existearchivo("inscritos.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("inscritos.obj"));
            inscribe aux=(inscribe)entrada.readObject();
            entrada.close();
            while (aux!=null)
            {
                if((codmat.equals(aux.codigomateria)) && (cedal.equals(aux.cedulaalumno)))
                {
                    aux2=true;
                }
                aux=aux.sig;
            }
        }
        return aux2;
    }
    
    public void asignanota(String codmat,String cedal,String not) throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (existearchivo("inscritos.obj"))
        {
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("inscritos.obj"));
            inscribe aux=(inscribe)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux!=null)
            {
                if(   (codmat.equals(aux.codigomateria)) && (cedal.equals(aux.cedulaalumno)))
                {
                    System.out.println(aux.cedulaalumno);
                    aux.nota=Integer.parseInt(not);
                }
                aux=aux.sig;
            }
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("inscritos.obj"));
            salida.writeObject(l);
            salida.close();
        }
    }
    
    public  void guardarinscrito(inscribe ins)throws IOException,ClassNotFoundException,FileNotFoundException
    {
        if (!existearchivo("inscritos.obj"))
        {
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("inscritos.obj"));
            salida.writeObject(ins);
            salida.close();
        }
        else{
        
            ObjectInputStream entrada=new ObjectInputStream(new FileInputStream("inscritos.obj"));
            inscribe aux=(inscribe)entrada.readObject();
            l=aux;
            entrada.close();
            while (aux.sig!=null)
            {
                aux=aux.sig;
            }
            aux.sig=ins;
            ObjectOutputStream salida=new ObjectOutputStream(new FileOutputStream("inscritos.obj"));
            salida.writeObject(l);
            salida.close();
        }
       
    }
    
}
