
package Clases;

import java.awt.*;
import javax.swing.*;


public class ImagenReportes extends javax.swing.JPanel  {
    
    public ImagenReportes(){ 
    this.setSize(39,39); 
} 
@ Override 
public void paint(Graphics g){
        Dimension tamanio = getSize();
        ImageIcon imagenFondo = new ImageIcon(getClass().getResource("/Imagenes/reportesgrande.jpg"));        
        g.drawImage(imagenFondo.getImage(),0,0,tamanio.width, tamanio.height, null);        
        setOpaque(false);
        super.paintComponent(g);
    }
    
}
