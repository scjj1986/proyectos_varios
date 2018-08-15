/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;


public class seccion implements java.io.Serializable  {
    
    public String codigomateria,numero,cedulaprofesor;
    public int alumnos;
    public seccion sig;
    
    
    
    public seccion(String codmat, String num, String cedprof)
    {
    this.codigomateria=codmat;
    this.numero=num;
    this.alumnos=0;
    this.cedulaprofesor=cedprof;
    this.sig=null;
    
    }
    
}
