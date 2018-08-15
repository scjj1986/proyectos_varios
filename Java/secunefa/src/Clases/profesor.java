/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;

/**
 *
 * @author salazar
 */
public class profesor implements java.io.Serializable{
    
    public String cedula,nombre,apellido,direccion,telefono;
    public profesor sig;
    
    public profesor (String cedula,String nombre,String apellido, String direccion, String telefono)
    {
        this.cedula=cedula;
        this.nombre=nombre;
        this.apellido=apellido;
        this.direccion=direccion;
        this.telefono=telefono;
        this.sig=null;
    }
    
}
