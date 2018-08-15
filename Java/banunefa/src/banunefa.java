import java.io.*;
import java.util.Scanner;
public class banunefa {
    
    public static void main(String[] args) throws Exception
    {
        cliente clientes[];
        empleado empleados[];
        String cadena;
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("\n Aplicacion BANUNEFA\n");
        System.out.println("\nA continuacion debera ingresar la cantidad de empleados a procesar\n");
        cadena=teclado.readLine();
        boolean salir=false;
        while (salir==false)
        {
            try
            {
                Integer.parseInt(cadena);
                salir=true;
            }
            catch(NumberFormatException nfe)
            {
              System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
              cadena=teclado.readLine();
            }
            if (salir==true)
            {
                if (Integer.parseInt(cadena)<=0)
                {
                    System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                    cadena=teclado.readLine();
                    salir=false;
                }
            }
        }
        int i=Integer.parseInt(cadena);
        empleados = new empleado [i];
        for (int j=0; j<i; j++)
        {
            System.out.println("Empleado # "+(j+1));
            empleados[j] = new empleado();
            empleados[j].llenar();
        }
        
        System.out.println("\nA continuacion debera ingresar la cantidad de clientes a procesar\n");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            try
            {
                Integer.parseInt(cadena);
                salir=true;
            }
            catch(NumberFormatException nfe)
            {
              System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
              cadena=teclado.readLine();
            }
            if (salir==true)
            {
                if (Integer.parseInt(cadena)<=0)
                {
                    System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                    cadena=teclado.readLine();
                    salir=false;
                }
            }
        }
        int k=Integer.parseInt(cadena);
        clientes = new cliente [i];
        for (int j=0; j<k; j++)
        {
            System.out.println("Cliente # "+(j+1));
            clientes[j] = new cliente();
            clientes[j].llenar();
        }
        
        int enter;
        System.out.println("Presione ENTER para mostrar los reportes...");
        do{
            enter=System.in.read();
        }while(enter!=10);
        int cont=0;
        
        System.out.println("\n*Listado de empleados:");
        for (int j=0; j<i; j++)
        {
            System.out.println("\n -Empleado # "+(j+1)+":");
            System.out.println("\n  Nombre: "+empleados[j].nombre);
            System.out.println("\n  Cargo: "+empleados[j].cargo);
            System.out.println("\n  Hora de entrada: "+empleados[j].hh_llegada+" hrs. con "+empleados[j].mm_llegada+" min.");
            System.out.println("\n  Hora de salida: "+empleados[j].hh_salida+" hrs. con "+empleados[j].mm_salida+" min.");
            System.out.println("\n Tiempo de trabajo: "+empleados[j].min_trabajo/60+" hrs. con "+empleados[j].min_trabajo%60+" min.");
        }
        
        System.out.println("\n*Listado de clientes:");
        for (int j=0; j<k; j++)
        {
            cont=cont+clientes[j].min_duracion;
            System.out.println("\n -Cliente # "+(j+1)+":");
            System.out.println("\n  Nombre: "+clientes[j].nombre);
            System.out.println("\n  Transaccion: "+clientes[j].transaccion);
            System.out.println("\n  Hora de llegada: "+clientes[j].hh_llegada+" hrs. con "+clientes[j].mm_llegada+" min.");
            System.out.println("\n  Hora de salida: "+clientes[j].hh_salida+" hrs. con "+clientes[j].mm_salida+" min.");
            System.out.println("\n Tiempo de atencion: "+clientes[j].min_duracion/60+" hrs. con "+clientes[j].min_duracion%60+" min.");
        }
        cont=cont/i;
        System.out.println("\nPromedio de tiempo de los clientes: "+cont/60+" hrs. con "+cont%60+" min.");
        System.out.println("Presione ENTER para salir del programa...");
        do{
            enter=System.in.read();
        }while(enter!=10);
    } 
}

class empleado
{
    String nombre,cargo;
    int hh_llegada,mm_llegada,hh_salida,mm_salida,min_trabajo;
    
    public empleado()
    {
        this.nombre="";
        this.cargo="";
        this.hh_llegada=0;
        this.mm_llegada=0;
        this.hh_salida=0;
        this.mm_salida=0;
        this.min_trabajo=0;
    
    }
    
    public boolean hora_numerica (String cadena)
 {  
     try
     {
         Integer.parseInt(cadena);
         return true;
     }
     catch(NumberFormatException nfe)
     {
       return false;
     }
   }
    public void llenar ()throws IOException
    {
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Ingrese el nombre del empleado: ");
        String cadena;
        nombre=teclado.readLine();
        System.out.println("Cargo: ");
        cargo=teclado.readLine();
        System.out.println("Seguidamente, debera ingresar la hora de entrada del empleado");
        System.out.println("Ingrese hora (de 0 a 23): ");
        cadena=teclado.readLine();
        boolean salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>23))
            {
            
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        hh_llegada=Integer.parseInt(cadena);
        System.out.println("Ingrese minutos (de 0 a 59): ");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.print("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>59))
            {
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        mm_llegada=Integer.parseInt(cadena);
        System.out.println("Seguidamente, debera ingresar la hora de salida del empleado");
        System.out.println("Ingrese hora (de 0 a 23): ");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>23))
            {
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if (Integer.parseInt(cadena)<hh_llegada)
            {
                System.out.println("Error al leer dato de entrada. La hora de salida debe ser mayor que la de llegada. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        hh_salida=Integer.parseInt(cadena);
        System.out.println("Ingrese minutos (de 0 a 59): ");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>59))
            {
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<=mm_llegada) && (hh_llegada==hh_salida))
            {
            
                System.out.println("Error al leer dato de entrada. La hora de salida debe ser mayor que la de llegada. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        mm_salida=Integer.parseInt(cadena);
        if (mm_llegada<mm_salida)
        {
            min_trabajo=(60*(hh_salida-hh_llegada))+(mm_salida-mm_llegada);
        }
        else
        {
            min_trabajo=(60*(hh_salida-hh_llegada-1))+60-(mm_llegada-mm_salida);
        }
        int enter;
        System.out.println("Datos guardados satisfactoriamente. Pulse ENTER para continuar...");
        do{
            enter=System.in.read();
        }while(enter!=10);
    }

}
class cliente
{
 String nombre, transaccion;
 int hh_llegada,mm_llegada,hh_salida,mm_salida,min_duracion;
 public cliente()
 {
     this.nombre="";
     this.transaccion="";
     this.hh_llegada=0;
     this.mm_llegada=0;
     this.hh_salida=0;
     this.mm_salida=0;
     this.min_duracion=0;
 }
 public boolean hora_numerica (String cadena)
 {  
     try
     {
         Integer.parseInt(cadena);
         return true;
     }
     catch(NumberFormatException nfe)
     {
       return false;
     }
   }
    public void llenar ()throws IOException
    {
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Ingrese el nombre del cliente: ");
        String cadena;
        nombre=teclado.readLine();
        System.out.println("Tipo de transaccion: ");
        transaccion=teclado.readLine();
        System.out.println("Seguidamente, debera ingresar la hora de entrada del cliente");
        System.out.println("Ingrese hora (de 0 a 23): ");
        cadena=teclado.readLine();
        boolean salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>23))
            {
            
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        hh_llegada=Integer.parseInt(cadena);
        System.out.println("Ingrese minutos (de 0 a 59): ");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.print("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>59))
            {
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        mm_llegada=Integer.parseInt(cadena);
        System.out.println("Seguidamente, debera ingresar la hora de salida del cliente");
        System.out.println("Ingrese hora (de 0 a 23): ");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>23))
            {
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if (Integer.parseInt(cadena)<hh_llegada)
            {
                System.out.println("Error al leer dato de entrada. La hora de salida debe ser mayor que la de llegada. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        hh_salida=Integer.parseInt(cadena);
        System.out.println("Ingrese minutos (de 0 a 59): ");
        cadena=teclado.readLine();
        salir=false;
        while (salir==false)
        {
            if (hora_numerica(cadena)==false){
            
                System.out.println("Error al leer dato de entrada. Valor no numerico. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<0) || (Integer.parseInt(cadena)>59))
            {
                System.out.println("Error al leer dato de entrada. Valor fuera de rango. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else if ((Integer.parseInt(cadena)<=mm_llegada) && (hh_llegada==hh_salida))
            {
            
                System.out.println("Error al leer dato de entrada. La hora de salida debe ser mayor que la de llegada. Ingrese de nuevo dicho valor:");
                cadena=teclado.readLine();
            }
            else
            {
                salir=true;
            }
        }
        mm_salida=Integer.parseInt(cadena);
        if (mm_llegada<mm_salida)
        {
            min_duracion=(60*(hh_salida-hh_llegada))+(mm_salida-mm_llegada);
        }
        else
        {
            min_duracion=(60*(hh_salida-hh_llegada-1))+60-(mm_llegada-mm_salida);
        }
        int enter;
        System.out.println("Datos guardados satisfactoriamente. Pulse ENTER para continuar...");
        do{
            enter=System.in.read();
        }while(enter!=10);
    }
}