
package Clases;


public class carrera implements java.io.Serializable {
    
    public String nombre;
    public carrera sig;
    
    public carrera(String nombre)
    {
       this.nombre=nombre;
       this.sig=null;
    }
    
    
}
