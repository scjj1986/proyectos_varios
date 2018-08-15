/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Clases;


public class AVLNodo {
    
    // Instancias 
 
 protected AVLNodo izq;     // hijo izquierdo
 protected AVLNodo der;     // hijo derecho
 protected int  altura;      // altura
 public Comparable datos;    // los datos como elementos del arbol avl
 
 // Constructores
 public AVLNodo(Comparable datElem)
 {
  this(datElem, null, null );
 }

 public AVLNodo( Comparable datElem, AVLNodo ib, AVLNodo db )
 {
    datos  = datElem;
    izq  = ib;
    der = db;
    altura  = 0;
 }

    
}
