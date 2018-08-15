public class Evaluate {
    public static void main(String[] args) { 
        Pila<String>  ops  = new Pila<String>();
        Pila<Integer> vals = new Pila<Integer>();

        System.out.print("Calc> ");
        
        while (!StdIn.isEmpty()) {
            String s = StdIn.readString();
            if      (s.equals("("))               ;
            else if (s.equals("+"))    ops.Poner(s);
            else if (s.equals("-"))    ops.Poner(s);
            else if (s.equals("*"))    ops.Poner(s);
            else if (s.equals("/"))    ops.Poner(s);
            else if (s.equals("sqrt")) ops.Poner(s);
            else if (s.equals(")")) {
                
                String op = ops.Sacar();
               
                if      (op.equals("+"))    vals.Poner(vals.Sacar() + vals.Sacar());
                else if (op.equals("-"))    vals.Poner(- vals.Sacar() + vals.Sacar());
                else if (op.equals("*"))    vals.Poner (vals.Sacar() * vals.Sacar());
                else if (op.equals("/"))    vals.Poner(1 / vals.Sacar() * vals.Sacar());
                else if (op.equals("sqrt")) vals.Poner((1/vals.Sacar())* vals.Sacar());
                
            }
            else vals.Poner(Integer.parseInt(s));
        }
        System.out.print(vals.Sacar());
    }
}


     