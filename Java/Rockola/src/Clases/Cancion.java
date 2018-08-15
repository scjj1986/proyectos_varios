
package Clases;
import java.io.*;


public class Cancion {//Clase para manipular la información concerniente a las canciones de la rockola
    
    public String codigo,nombre,artista,album,track;
    public Cancion sig;//atributos de la cancion y su apuntador siguiente

    public Cancion(){//constructor
    	this.codigo="";
	this.nombre="";
	this.artista="";
	this.album="";
	this.track="";
        this.sig=null;
    }
    
    public void Copiar (String cd, String nm,String ar,String al, String tr ){//método para duplicar la información de un nodo (canción) a otro
    
        this.codigo=cd;
        this.nombre=nm;
        this.artista=ar;
        this.album=al;
        this.track=tr;
    
    } 
}
