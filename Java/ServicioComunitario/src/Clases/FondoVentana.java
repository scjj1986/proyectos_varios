/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;

import java.awt.*;
import javax.swing.*;
//import Imagenes.*;

public class FondoVentana extends javax.swing.JPanel { 
public FondoVentana(){ 
    this.setSize(620,700); 
} 
@ Override 
public void paint(Graphics g){
        Dimension tamanio = getSize();
        ImageIcon imagenFondo = new ImageIcon(getClass().getResource("/Imagenes/fondogris.jpg"));        
        g.drawImage(imagenFondo.getImage(),0,0,tamanio.width, tamanio.height, null);        
        setOpaque(false);
        super.paintComponent(g);
    }    
 

}
