package secunefa;

import java.awt.*;
import javax.swing.*;
//import Imagenes.*;

public class FondoVentanas extends javax.swing.JPanel { 
public FondoVentanas(){ 
    this.setSize(644,567); 
} 
@ Override 
public void paint(Graphics g){
        Dimension tamanio = getSize();
        ImageIcon imagenFondo = new ImageIcon(getClass().getResource("/Imagenes/azuldeg.jpg"));        
        g.drawImage(imagenFondo.getImage(),0,0,tamanio.width, tamanio.height, null);        
        setOpaque(false);
        super.paintComponent(g);
    }    
 

}

