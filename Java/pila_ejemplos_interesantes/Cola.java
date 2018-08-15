//PROJECT TITLE: Cola
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

import java.util.NoSuchElementException;

public class Cola<Elemento>
{
 private int N=0;
 private Node first;
 private Node last;
 
 //constructor
 private class Node{
     private Elemento elemento;
     private Node next;
    
     public Node(Elemento elemento, Node next){
         this.elemento=elemento;
         this.next=next;
      }
  }
    
    public boolean esVacio(){return first==null&&last==null;}
    
    public int tamaño(){return N;}
    
    // ingreso elemento (el primero en entrar es el primero en salir)
    public void encolar(Elemento elemento){
        Node x= new Node(elemento,null);
         if (esVacio()) { first = x;     last = x; }
         else           { last.next = x; last = x; }

        N++;
    }
    //me quita el primer elemento
    public Elemento decolar(){
      if(esVacio()) throw new NoSuchElementException("la cola esta vacia");
        Elemento elemento=first.elemento;
        first=first.next;
        N--;
     return elemento;
    }
// me muestra el primer elemento 
   public Elemento peek(){
     if(esVacio()) throw new NoSuchElementException("la cola esta vacia");
     return first.elemento;
   }

}
