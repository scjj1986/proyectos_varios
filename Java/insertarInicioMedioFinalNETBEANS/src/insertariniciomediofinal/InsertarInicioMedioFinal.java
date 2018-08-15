package insertariniciomediofinal;
import java.util.Scanner; 
import java.util.Vector;

/**
 * @author tutorias.co
 */

public class InsertarInicioMedioFinal {

    /**
     * se crea el canal de entrada de datos con scanner
     */
    static Scanner entrada = new Scanner(System.in);
    static int valor, posicion;
    static Lista solucion = new Lista();
            
    public static void main(String[] args){
        // se instancia la clase Lista y se invocan los metodos
        
        do{
            System.out.print("Favor ingresar valor entero: ");
            valor = entrada.nextInt(); 
            System.out.print("Favor ingresar posicion a insertar valor:  1:Inicio   2:Medio   3:Final ");
            posicion = entrada.nextInt(); 
            solucion.agregar(valor, posicion);
            solucion.mostrarResultado();
            
            System.out.print("\n\n¿Desea continuar?  si/no: ");
        }while(entrada.next().equalsIgnoreCase("si"));
    }
}

// clase lista
class Lista{
    int val, pos;
    Vector vec = new Vector();
    
    Lista(){
    }
    public void agregar(int valor, int posicion){
        val = valor;
        pos = posicion;
        switch(posicion){
            case 3:
                vec.add(val);
                break;
                
            case 2:
                if(vec.size() > 0){
                    vec.add(vec.lastElement());
                    int medio = vec.size()/2;

                    for(int x = vec.size()-1; x > medio ; x--)
                    vec.setElementAt(vec.elementAt(x-1), x);                
                    vec.setElementAt(val, medio);  
                }else
                  vec.add(val);
                break;
              
            case 1:
                if(vec.size() > 0){ 
                    vec.add(vec.lastElement());
                    for(int x = vec.size()-1; x > 0 ; x--)
                    vec.setElementAt(vec.elementAt(x-1), x);
                    vec.setElementAt(val, 0); 
                }else
                  vec.add(val);  
                break;
                
            default: System.out.println("Solo opciones 1, 2, 3");                
        }        
    }
    public void mostrarResultado(){
        for(int x = 0; x < vec.size(); x++)
            System.out.print(vec.elementAt(x)+"\t");
    }
    public void mostrarResultadoGrafico(){
        javax.swing.JOptionPane.showMessageDialog(null,vector());
    }
    public String vector(){
        String cadena = "";
        for(int x = 0; x < vec.size(); x++)
            cadena = cadena + String.valueOf(vec.elementAt(x)+"  ");
        return cadena;
    }
}
// clase lista
