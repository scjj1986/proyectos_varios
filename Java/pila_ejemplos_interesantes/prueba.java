 public class prueba{
     Pila<Character> p1= new Pila<Character>(); 
     Pila<Character> p2= new Pila<Character>(); 
 
public void insert(char c)  {
       p1.Poner(c); 
    } 
    
 public char delete()  {
       return p1.Sacar(); 
    } 
    
     public void left()  {
       p2.Poner(p1.Sacar()); 
    } 
    
     public void right()  {
       p1.Poner(p2.Sacar()); 
    } 
    
       public char get(int i)  {
       for(int j=0; j<p1.tamaño(); j--)
       p2.Poner(p1.Sacar());
       if(j==i)
       char elemento = p1.Sacar();
       p2.Poner(elemento);
       return elemento;
       
    } 
   

}