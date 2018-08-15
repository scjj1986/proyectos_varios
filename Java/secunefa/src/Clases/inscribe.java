/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;


public class inscribe implements java.io.Serializable {
   
    public String codigomateria,cedulaalumno,seccion;
    public int nota;
    public inscribe sig; 
    
    public inscribe (String codmat,String cedal, String sec){
    
        codigomateria=codmat;
        cedulaalumno=cedal;
        seccion=sec;
        nota=0;
        sig=null;
    }
    
    
    
    
}
