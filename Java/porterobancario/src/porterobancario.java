import java.util.Scanner;

import java.io.*;

public class porterobancario {
    
    static class nodocliente{
    
        String nom;
        String trans;
        int hlle;
        int mlle;
        int hsal;
        int msal;
        
        public boolean num (String cd)
        {  
                 for(int i = 0; i<cd.length(); i++)  
                     if( !Character.isDigit(cd.charAt(i)) )  
                        return false;  
                     return true;  
        }
        
        public boolean validarhora (String cd)
        {
            
            if (!num(cd))
            {
                
                return false;
            
            }
            else
            {
            
                int val=Integer.parseInt(cd);
                
                if ((val<0) || (val>23))
                {
                    
                    return false;
                
                }
                else
                {
                    return true;
                
                }
            
            }
        
        }
        
        public boolean validarminutos (String cd)
        {
            
            if (!num(cd))
            {
                
                return false;
            
            }
            else
            {
            
                int val=Integer.parseInt(cd);
                
                if ((val<0) || (val>59))
                {
                    
                    return false;
                
                }
                else
                {
                    return true;
                
                }
            
            }
        
        }
        
        public boolean compararhoras (String cd)
        {
        
            if (!num(cd))
            {
                
                return false;
            
            }
            else
            {
            
                int val=Integer.parseInt(cd);
                
                if ((val<0) || (val>23) || (val<hlle))
                {
                    
                    return false;
                
                }
                else
                {
                    return true;
                
                }
            
            }
        
        }
        
        public boolean compararminutos (String cd)
        {
            
            if (!num(cd))
            {
                
                return false;
            
            }
            else
            {
            
                int val=Integer.parseInt(cd);
                
                if ((val<0) || (val>59))
                {
                    
                    return false;
                
                }
                else if ((hsal==hlle) && (val<=mlle))
                {
                    
                    return false;
                
                }
                else
                {
                    return true;
                
                }
            
            }
        
        }
        
        public int minutoscliente ()
        {
        
            return ((60*hsal)+msal)-((60*hlle)+mlle);
        
        
        }
        
        public void recopilardatos(){
            
            Scanner lector = new Scanner(System.in);
            
            String cd;
            
            System.out.print("\nNombre del cliente: ");
            
            nom=lector.nextLine();
            
            System.out.print("\nTransaccion: ");
            
            trans=lector.nextLine();
            
            System.out.print("\nHora de llegada. ");
            
            System.out.print("\n*Ingrese la hora (entre 0 y 23): ");
            
            cd=lector.nextLine();
            
            while (!validarhora(cd))
            {
                System.out.print("\n La hora debe ser numerica y oscilar entre 0 y 23. Intente de nuevo: ");
                
                cd=lector.nextLine();
            
            }
            
            hlle=Integer.parseInt(cd);
            
            System.out.print("\n*Ingrese los minutos (entre 0 y 59): ");
            
            cd=lector.nextLine();
            
            while (!validarminutos(cd))
            {
                System.out.print("\n Los minutos deben ser numericos y oscilar entre 0 y 59. Intente de nuevo: ");
                
                cd=lector.nextLine();
            
            }
            
            mlle=Integer.parseInt(cd);
            
            System.out.print("\nHora de salida. ");
            
            System.out.print("\n*Ingrese la hora (entre 0 y 23): ");
            
            cd=lector.nextLine();
            
            while ((!validarhora(cd)) || (!compararhoras(cd)))
            {
                System.out.print("\n La hora debe ser numerica, oscilar entre 0 y 23 y ser mayor que la de llegada. Intente de nuevo: ");
                
                cd=lector.nextLine();
            
            }
            
            hsal=Integer.parseInt(cd);
            
            System.out.print("\n*Ingrese los minutos (entre 0 y 59): ");
            
            cd=lector.nextLine();
            
            while ((!validarminutos(cd)) || (!compararminutos(cd)))
            {
                System.out.print("\n Los minutos deben ser numericos, oscilar entre 0 y 59 y ser mayor que los de llegada. Intente de nuevo: ");
                
                cd=lector.nextLine();
            
            }
            msal=Integer.parseInt(cd);
            
        }
        
        public static void main(String[] args) throws Exception
        {
        
            nodocliente arregloclientes [];
            
            arregloclientes = new nodocliente [500];
            
            int totalclientes=0;
            
            int i=0;
            
            int acum=0;
            
            int entrada=0;
            
            int salida=0;
            
            Scanner lector = new Scanner(System.in);
            
            System.out.println("\n Bienvenidos al programa bancario.");
            
            System.out.println("\n A continuacion debera ingresar los datos de cada cliente");
            
            String resp="s";
            
            while (resp.compareTo("s")==0)
            {
            
                arregloclientes [totalclientes]= new nodocliente ();
                
                arregloclientes[totalclientes].recopilardatos();
                
                System.out.print("\nDesea agregar otro cliente? (s/n): ");
            
                resp=lector.nextLine();
                
                totalclientes++;
            
            }
            
            resp="n";
            
            while (resp.compareTo("n")==0)
            {
            
                System.out.println("\nMenu de opciones:");
                
                System.out.println("\n 1) para verificar el tiempo promedio de clientes en el banco ");
                
                System.out.println("\n 2) para calcular las horas trabajadas por los empleados");
                
                resp=lector.nextLine();
                
                if (resp.compareTo("1")==0){
                
                    i=0;
                    
                    acum=0;
                    
                    while (i<totalclientes){
                    
                        acum+=arregloclientes[i].minutoscliente();
                    
                        i++;
                    }
                    System.out.println("\n El tiempo promedio de atencion al cliente es de "+acum/totalclientes+" min.");
                  
                }
                
                else if (resp.compareTo("2")==0){
                
                    i=0;
                    
                    entrada=(arregloclientes[i].hlle*60)+arregloclientes[i].mlle;
                    
                    salida=(arregloclientes[i].hsal*60)+arregloclientes[i].msal;
                    
                    while (i<totalclientes){
                    
                        if (entrada>(arregloclientes[i].hlle*60)+arregloclientes[i].mlle){
                        
                            entrada=(arregloclientes[i].hlle*60)+arregloclientes[i].mlle;
                            
                        }
                        
                        if (salida<(arregloclientes[i].hsal*60)+arregloclientes[i].msal){
                        
                            salida=(arregloclientes[i].hsal*60)+arregloclientes[i].msal;
                            
                        }
                    
                        i++;
                    }
                    
                    System.out.println("\n El total de horas trabajadas de los empleados es de "+(salida-entrada)/60+" hrs.");
                
                }
                
                System.out.print("\nDesea salir del programa? (s/n): ");
            
                resp=lector.nextLine();
                
            }
        
        
        }
    
    }
    
}
