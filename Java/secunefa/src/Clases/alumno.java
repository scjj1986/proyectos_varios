/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;


public class alumno implements java.io.Serializable {
    
    public String cedula,nombre,apellido,direccion;
    public alumno sig;
    
    public alumno(String ced,String nom,String ape,String dir){
    
        this.cedula=ced;
        this.nombre=nom;
        this.apellido=ape;
        this.direccion=dir;
        this.sig=null;
    } 
}
