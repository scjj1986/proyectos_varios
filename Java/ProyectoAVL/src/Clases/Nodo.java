package Clases;


public class Nodo {
    public Comparable dato;      	
    public Nodo izquierdo;            
    public Nodo derecho;              
    public int altura;                   

    // Constructors
    public Nodo(Comparable dato ){
        this( dato, null, null );
    }

    public Nodo(Comparable dato, Nodo izq, Nodo der ){
        this.dato = dato;
        this.izquierdo = izq;
        this.derecho = der;
        altura   = 0;               
    }
}