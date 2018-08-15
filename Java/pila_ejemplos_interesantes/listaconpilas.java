//PROJECT TITLE: lista con pilas
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

public class  listaconpilas {
    private int N;          // tamaño de la pila
    private Node first;     

    // helper Node class
    private class Node {
        private String item;
        private Node next;
    }

    // is the stack empty?
    public boolean isEmpty() { return first == null; }

    // number of elements on the stack
    public int size() { return N; }


    // agrega un elemento a la pila
    public void push(String item) {
        Node oldfirst = first;
        first = new Node();
        first.item = item;
        first.next = oldfirst;
        N++;
    }

    // borra el elemento
    public String pop() {
        if (isEmpty()) throw new RuntimeException("Stack underflow");
        String item = first.item;      // save item to return
        first = first.next;            // delete first node
        N--;
        return item;                   // return the saved item
    }
}
