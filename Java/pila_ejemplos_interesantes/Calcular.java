//PROJECT TITLE: calcular con parentesis 
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

public class Calcular {
    public static void main(String[]args){
       Pila<Double> valores=new Pila<Double>();
       Pila<String> operador=new Pila<String>();
       int i=0;

     while (!StdIn.isEmpty()) {
     String s = StdIn.readString();


      if(s.equals("(")) ;//no hace nada;
      else if(s.equals("+")) operador.Poner(s); 
      else if(s.equals("-")) operador.Poner(s);
      else if(s.equals("*")) operador.Poner(s);
      else if(s.equals("/")) operador.Poner(s);

      else if(s.equals(")")){
         String op= operador.Sacar();
            if(op.equals("+")) valores.Poner(valores.Sacar()+ valores.Sacar());
            else if(op.equals("-")) valores.Poner(-valores.Sacar()+ valores.Sacar());
            else if(op.equals("*")) valores.Poner(valores.Sacar() * valores.Sacar());
            else if(op.equals("/")) valores.Poner((1/valores.Sacar()) / valores.Sacar());
       }
   
     else valores.Poner(Double.parseDouble(s));
    }
          System.out.println(valores.Sacar());
    }
  }