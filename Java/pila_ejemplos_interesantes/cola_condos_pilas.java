//PROJECT TITLE: cola con dos pilas
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

public class cola_condos_pilas<Elemento>{
  private Pila<Elemento> s1=new Pila<Elemento>();
  private Pila<Elemento> s2=new Pila<Elemento>();

   public int tama�o() {return s1.tama�o()+ s2.tama�o();}

   public boolean esVacio(){return s1.esVacio()&& s2.esVacio();}

   public void Encolar(Elemento elemento){
    s1.Poner(elemento);
  }

   public Elemento decolar(){
     if(s1.esVacio() && s2.esVacio()) System.out.print("pila vacia");
    for(int i=1; i<=s1.tama�o() + s2.tama�o();i++){
      s2.Poner(s1.Sacar()); }
      Elemento elem= s2.Sacar(); 
     for(int i=1; i<=s1.tama�o()+s2.tama�o() ;i++){
     s1.Poner(s2.Sacar());}
     return elem;
       
  }
  
  public Elemento peek(){
     if(s1.esVacio() && s2.esVacio()) System.out.print("pila vacia");
    for(int i=1; i<=s1.tama�o() + s2.tama�o();i++){
      s2.Poner(s1.Sacar()); }
      Elemento elem = s2.Sacar(); 
      s2.Poner(elem);  
    for(int i=1; i<=s1.tama�o()+s2.tama�o() ;i++){
     s1.Poner(s2.Sacar());}
     return elem;
      
  }
  

}