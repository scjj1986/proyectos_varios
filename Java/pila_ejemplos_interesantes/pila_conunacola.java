//PROJECT TITLE: pila con una cola
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

public class pila_conunacola<Elemento>{
    private Cola<Elemento> q= new Cola<Elemento>();
 
     public void Poner(Elemento elemento){
        q.encolar(elemento);
     }

     public int tama�o(){return q.tama�o();}

     public boolean esVacio(){return q.esVacio();}

     public Elemento Pop(){
        if(esVacio())  System.out.print("vacio");
          for (int i=1; i<q.tama�o(); i++)
              q.encolar(q.decolar());
        return q.decolar();
    }

    public Elemento top(){
        if(esVacio())  System.out.print("vacio");
          for (int i=1; i<q.tama�o(); i++)
            q.encolar(q.decolar());
            Elemento elem = q.decolar();
            q.encolar(elem);
        return elem;
    }
}
   