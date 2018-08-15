//PROJECT TITLE: sudoku
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

import java.io.*;

public class Sudoku
{
   private int r, c, s, soluctions;
   
   private int [] puzzle = new int[81];
   private int [][] mapa = new int[9][9];
    
   private Pila<Integer> sr = new Pila<Integer>();
   private Pila<Integer> sc = new Pila<Integer>();
   private Pila<Integer> ss = new Pila<Integer>();
   
   public Sudoku(int[][] puzzle, int[][] mapa)
   {
       r = 0; c = 0; s = 1; soluctions = 0;
        for(int i = 0; i < 9; i++)
          for(int j = 0; j < 9; j++)
             this.mapa[i][j] = mapa[i][j];
             
       for(int i = 0; i < 9; i++)
          for(int j = 0; j < 9; j++)
             this.puzzle[i * 9 + j] = puzzle[i][j];
             solve();
             System.out.printf("Encontre %d solucion%s \n" , soluctions, (soluctions == 1) ? "" : "es");
  }
  
        
   public boolean esValido() 
   {
       //reviso fila/columna
       for(int i = 0; i < 9; i++)
          if(puzzle[r * 9 + i] == s || puzzle[i * 9 + c] == s)
            return false;
       //reviso bloque
     int pos=mapa[r][c];           
       for(int i = 0; i < 9; i++)
            for(int j = 0; j < 9; j++)
                 if( pos == mapa[i][j] )
                      if(puzzle[i * 9 + j] == s)
                           return false;              
       return true;
    }
    
   public void solve()
   {
       push();
       while(puzzle[r * 9 + c] != 0)
       {
           if(c == 8) {r++; c = 0;}
           else c++;
           if (r == 9)
           {
               print();
               ++soluctions;
               pop();
               return;
            }
        }
        for(s = 1; s <= 9; s++)
        if(esValido())
        {
            puzzle[r * 9 + c] = s;
            solve();
            puzzle[r * 9 + c] = 0;
        }
        pop();          
    }
    
   
   private void push() {
       sr.Poner(r);
       sc.Poner(c);
       ss.Poner(s);
    }
    
   private void pop() {
       r = sr.Sacar();
       c = sc.Sacar();
       s = ss.Sacar();
    }
    
   private void print()
   {
       for(int i = 0; i< 9; i++)
       {
           if(i % 3 == 0) pl();           
             System.out.print("| ");
           for(int j = 0; j < 9; j++)
             System.out.printf("%d%s", puzzle[i * 9 + j], (j % 3 == 2) ? " | " : " ");
           System.out.println();
        }
        pl();  System.out.println();
    }
    
    private void pl()
    {
        System.out.print("+");
        for(int i = 0; i< 9; i++)
            System.out.printf("-%s", (i % 3 == 2) ? "+" : "--");
        System.out.println();
    }
       

        
    public static void main(String[] args)  throws FileNotFoundException,IOException 
   {
       int [][] mapa = new int[9][9];
       int [][] juego = new int[9][9];
       
        FileInputStream fptr;
        DataInputStream f;
        String linea = null;
        String c = null;
        
        //cargo el mapa
        int i=-1,j=0;
        fptr = new FileInputStream("Mapa.txt");
        f = new DataInputStream(fptr);
        do {
            linea = f.readLine();
            if (linea!=null){
                 i++;
                 for( j = 0; j <= 8; j++)
                     mapa[i][j]=Integer.valueOf(""+(char)linea.charAt(j));
            }//if            
        } while (linea != null);
        fptr.close();
        
        //cargo el juego
        i=-1;j=0;linea = null;
         fptr = new FileInputStream("Juego.txt");
        f = new DataInputStream(fptr);
        do {
            linea = f.readLine();
            if (linea!=null){
                 i++;
                 for( j = 0; j <= 8; j++)
                    juego[i][j]=Integer.valueOf(""+(char)linea.charAt(j));
            }//if            
        } while (linea != null);
        fptr.close();
    
        Sudoku sdk = new Sudoku(juego, mapa);
        
    }    
}
