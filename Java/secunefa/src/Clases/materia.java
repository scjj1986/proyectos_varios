/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;


public class materia implements java.io.Serializable {
    
    public String codigo,nombre,carrera;
    public int secciones;
    public materia sig;
    
    public materia(String codigo,String nombre,String carrera)
    {
       this.codigo=codigo;
       this.nombre=nombre;
       this.carrera=carrera;
       this.secciones=0;
       this.sig=null;
    }
    
    
    
}
