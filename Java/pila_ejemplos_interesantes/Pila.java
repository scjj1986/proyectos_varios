//PROJECT TITLE: pila
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

import java.util.NoSuchElementException;

public class Pila<Elemento>
{
   private int N=0;
   private Node first=null;
   
   private class Node{
   private Elemento elemento;
   private Node next;
   
   //este es un constructor para volver a utilizar variables
   public Node(Elemento elemento, Node next){
       this.elemento=elemento;
       this.next=next;
    }
}

//me dice el tamaño de la pila
public int tamaño() {return N;}
//me devuelve verdadero si la pila esta vacia de lo contrario false
public boolean esVacio() {return first==null;}


// ingreso un elemento a la pila (el ultimo en ingresar es el primero en la pila)
public void Poner(Elemento elemento){
first= new Node(elemento,first);
N++;
}
//me muestra el ultimo elemto ingresado de lo contrario el mensaje de error 
public Elemento MostrarPrimeroElemento(){
if(esVacio()) throw new NoSuchElementException("la pila esta vacia");
return first.elemento;
}
//quita el primer elemento de la pila (osea el ultimo en ingresar)
public Elemento Sacar(){
if(esVacio())throw new NoSuchElementException("la pila esta vacia");
Elemento elemento=first.elemento;
first=first.next;
N--;
return elemento;

}
}
