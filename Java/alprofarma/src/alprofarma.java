import java.io.*;
public class alprofarma {
    public static void main(String[] args) throws Exception
    {
        
       almacen alm=new almacen();
       producto nuevo,nuevo2;
       boolean salir=false;
       String respuesta;
       BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
       System.out.println("Aplicacion ALPROFARMA (Almacen de Productos Farmaceuticos)\n");
       
       while (!salir)
       {
       
           System.out.println("Menu de opciones:");
           System.out.println("\n1) Para ingresar un producto:");
           System.out.println("2) Para consultar el reporte de existencias:");
           System.out.println("3) Para vender productos:");
           System.out.println("4) Para salir de la aplicacion:");
           respuesta=teclado.readLine();
           while ( (respuesta.compareTo("1")!=0) && (respuesta.compareTo("2")!=0) && (respuesta.compareTo("3")!=0) && (respuesta.compareTo("4")!=0) )
           {

                    System.out.println("Error. Ingrese la opcion correcta:");
                    respuesta=teclado.readLine();
           }
           if (respuesta.compareTo("1")==0){
           
               nuevo=new producto();
               nuevo2=new producto();
               nuevo.llenar();
               if (nuevo.tipo.compareTo("MEDICAMENTO")==0){
        
                    alm.medicamentos=alm.encolar_medicamento(nuevo,alm.medicamentos);
                    nuevo2.copiar(nuevo);
                    alm.existencia_medicamentos=alm.agregar_existencia(alm.existencia_medicamentos,nuevo2);

                }else{
                    alm.miscelaneos=alm.apilar_miscelaneo(nuevo,alm.miscelaneos);
                    alm.existencia_miscelaneos=alm.agregar_existencia(alm.existencia_miscelaneos, nuevo);
                }
           
           
           }else if (respuesta.compareTo("2")==0){
               
               alm.reportes();
           
           }else if (respuesta.compareTo("3")==0){
               
               alm.vender_productos();
           
           }else{
           
                salir=true;
           
           }
           
           
           
           
           
           
       }
        
    }
    
}

class producto
{
    String descripcion,tipo;
    int lote,cantidad;
    double costo;
    producto siguiente;
    
    public producto(){
        
        this.descripcion="";
        this.tipo="";
        this.lote=0;
        this.cantidad=0;
        this.costo=0.00;
        this.siguiente=null;
        
    }
    
    public boolean esDecimal(String cad)
    {
            try
            {
              Double.parseDouble(cad);
              return true;
            }
            catch(NumberFormatException nfe)
            {
              return false;
            }
    }
    public boolean numerico (String cad)
    {  
	    try
            {
              Integer.parseInt(cad);
              return true;
            }
            catch(NumberFormatException nfe)
            {
              return false;
            }
    }
    public void llenar()throws IOException{
        String respuesta,cadena;
        boolean salir=false;
        producto auxiliar;
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Ingrese el tipo de producto ('1' si es medicamento ó '2' si es miscelaneo): ");
        respuesta=teclado.readLine();
        while ( (respuesta.compareTo("1")!=0) && (respuesta.compareTo("2")!=0) )
        {
            
    		System.out.println("Error. Ingrese la opcion correcta:");
    		respuesta=teclado.readLine();
        }
        System.out.println("Ingrese nombre o descripcion: ");
        descripcion=teclado.readLine();
        System.out.println("Costo del producto (Bs.): ");
        cadena=teclado.readLine();
        while (!esDecimal(cadena)){
            System.out.println("El costo debe ser numerico. Intente de nuevo: ");
            cadena=teclado.readLine();
        }
        costo=Double.parseDouble(cadena);
        System.out.println("Numero de lote: ");
        cadena=teclado.readLine();
        while (!numerico(cadena)){
            System.out.println("El costo debe ser numerico. Intente de nuevo: ");
            cadena=teclado.readLine();
        }
        lote=Integer.parseInt(cadena);
        cantidad=1;
        if (respuesta.compareTo("1")==0){
        
            tipo="MEDICAMENTO";
            
        }else{
        
            tipo="MISCELANEO";
        }
        int enter;
        System.out.println("Datos guardados satisfactoriamente. Pulse ENTER para continuar...");
        do{
            enter=System.in.read();
        }while(enter!=10);
        
    }
    public void copiar (producto nodo)
    {
        cantidad=nodo.cantidad;
        costo=nodo.costo;
        descripcion=nodo.descripcion;
        lote=nodo.lote;
        tipo=nodo.tipo;
    
    }

}
class almacen{
    producto medicamentos,existencia_medicamentos,miscelaneos,existencia_miscelaneos;
    public almacen(){

    this.medicamentos=null;
    this.miscelaneos=null;
    this.existencia_medicamentos=null;
    this.existencia_miscelaneos=null;

    }
    public producto encolar_medicamento(producto nuevo, producto cima)
    {
    
        if (cima==null)
        {
        
            cima=nuevo;
        }
        else{
            producto auxiliar=cima;
            while (auxiliar.siguiente!=null){
                auxiliar=auxiliar.siguiente;
            }
            auxiliar.siguiente=nuevo;
        }
        return cima;
            
    }
    public producto apilar_miscelaneo(producto nuevo, producto cima)
    {
        if (cima!=null){
            nuevo.siguiente=cima;
        }
        cima=nuevo;
        return cima;
    }
    
    public boolean descripcion_repetida(String cad, producto lista)throws IOException
    {
        producto auxiliar=lista;
        boolean encontrado=false;
        while (auxiliar!=null)
        {
            if (cad.compareTo(auxiliar.descripcion)==0)
            {
                encontrado=true;
            }
            auxiliar=auxiliar.siguiente;
        
        }
        return encontrado;
    }
    public producto agregar_existencia (producto lista,producto nuevo) throws IOException
    {
        producto auxiliar;
        if (lista==null)
        {
            lista=encolar_medicamento(nuevo,lista);
        }
        else
        {
        
            if (nuevo.tipo.compareTo("MEDICAMENTO")==0){
                
                if (!descripcion_repetida(nuevo.descripcion,lista))
                {
                    
                    lista=encolar_medicamento(nuevo,lista);
                
                }
                else
                {
                    auxiliar=lista;
                    while (auxiliar!=null)
                    {
                        if (nuevo.descripcion.compareTo(auxiliar.descripcion)==0)
                        {
                            auxiliar.cantidad++;
                            auxiliar.costo=nuevo.costo;
                        }
                        auxiliar=auxiliar.siguiente;
                    }
                }
            }else{

                if (!descripcion_repetida(nuevo.descripcion,lista))
                {
                    lista=apilar_miscelaneo(nuevo,lista);
                
                }
                else
                {
                    auxiliar=lista;
                    while (auxiliar!=null)
                    {
                        if (nuevo.descripcion.compareTo(auxiliar.descripcion)==0)
                        {
                            auxiliar.cantidad++;
                        }
                        auxiliar=auxiliar.siguiente;
                    }
                }
            } 
        }
        return lista;
        
    }
    public void mostrar_productos(producto lista)throws IOException
    {
        producto auxiliar=lista;
        while (auxiliar!=null)
        {
            System.out.println("*Nombre o descripcion: "+auxiliar.descripcion);
            System.out.println(" Existencia: "+auxiliar.cantidad+"\n");
            auxiliar=auxiliar.siguiente;
        }
    
    
    }
    
    public void reportes()throws IOException{
        producto auxiliar,nuevo;
        boolean salir;
       System.out.println("\nListado de medicamentos existentes: "); 
       if (medicamentos==null)
       {
       
           System.out.println("\n*No hay medicamentos registrados"); 
       
       }else{
           
           mostrar_productos(existencia_medicamentos);
           
       
       }
       System.out.println("\nListado de miscelaneos existentes: "); 
       if (miscelaneos==null)
       {
       
           System.out.println("\n*No hay miscelaneos registrados"); 
       
       }else{
           
           mostrar_productos(existencia_miscelaneos);
       }
       int enter;
        System.out.println("Pulse ENTER para continuar...");
        do{
            enter=System.in.read();
        }while(enter!=10);
    
    }
    
    public boolean numerico (String cad)
    {  
	    try
            {
              Integer.parseInt(cad);
              return true;
            }
            catch(NumberFormatException nfe)
            {
              return false;
            }
    }
    
    public producto sacar_producto(producto cima)
    {
        producto nodo=cima;
        cima=cima.siguiente;
        return cima;
    }
    
    public void vender_productos() throws IOException
    {
        
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
        String respuesta,cadena,cadena2;
        int i;
        boolean salir;
        producto auxiliar,nuevo;
        auxiliar=new producto();
        System.out.println("Ingrese el tipo de producto a vender('1' si es medicamento ó '2' si es miscelaneo): ");
        respuesta=teclado.readLine();
        while ( (respuesta.compareTo("1")!=0) && (respuesta.compareTo("2")!=0) )
        {
            
    		System.out.println("Error. Ingrese la opcion correcta:");
    		respuesta=teclado.readLine();
        }
        if ((respuesta.compareTo("1")==0) && (existencia_medicamentos==null))
        {
            System.out.println("No existen medicamentos en el almacen:");
        
        }
        else if ((respuesta.compareTo("1")==0) && (existencia_medicamentos!=null))
        {
            System.out.println("Listado de medicamentos disponibles en el almacen:");
            mostrar_productos(existencia_medicamentos);
            System.out.println("Ingrese el nombre del medicamento a elegir:");
            cadena=teclado.readLine();
            while (!descripcion_repetida(cadena,existencia_medicamentos))
            {
                System.out.println("Medicamento no encontrado. Intente de nuevo:");
                cadena=teclado.readLine();

            }
            salir=false;
            System.out.println("Ingrese la cantidad a elegir:");
            cadena2=teclado.readLine();
            while (!salir)
            {
                salir=true;
                while (!numerico(cadena2) || (cadena2.compareTo("0")==0) )
                {
                    
                    System.out.println("La cantidad a elegir debe ser numerica y mayor que 0. Intente de nuevo:");
                    cadena2=teclado.readLine();
                }
                while (existencia_medicamentos!=null)
                {
                    if ( (cadena.compareTo(existencia_medicamentos.descripcion)==0) && (Integer.parseInt(cadena2)>existencia_medicamentos.cantidad))
                    {
                        System.out.println("La cantidad debe ser menor o igual que la disponible en el almacen. Intente de nuevo:");
                        cadena2=teclado.readLine();
                        salir=false;
                    }
                    else if ( (cadena.compareTo(existencia_medicamentos.descripcion)==0) && (Integer.parseInt(cadena2)<=existencia_medicamentos.cantidad))
                    {
                        System.out.println("Compra reailzada:");
                        System.out.println("*Producto: "+existencia_medicamentos.descripcion);
                        System.out.println("*Cantidad: "+Integer.parseInt(cadena2));
                        System.out.println("<------ GRACIAS POR SU COMPRA --------->");
                        existencia_medicamentos.cantidad-=Integer.parseInt(cadena2);
                    
                    }
                    nuevo=new producto();
                    nuevo.copiar(existencia_medicamentos);
                    existencia_medicamentos=sacar_producto(existencia_medicamentos);
                    auxiliar=encolar_medicamento(nuevo,auxiliar);
                }
                while (auxiliar!=null)
                {
                    nuevo=new producto();
                    nuevo.copiar(auxiliar);
                    if (nuevo.cantidad>0)
                    {
                        existencia_medicamentos=encolar_medicamento(nuevo,existencia_medicamentos);
                    }
                    
                    auxiliar=sacar_producto(auxiliar);
                }
            }
            while (medicamentos!=null)
            {
                nuevo=new producto();
                nuevo.copiar(medicamentos);
                medicamentos=sacar_producto(medicamentos);
                auxiliar=encolar_medicamento(nuevo,auxiliar);
            }
            i=1;
            while (auxiliar!=null)
            {
                nuevo=new producto();
                nuevo.copiar(auxiliar);
                if ((cadena.compareTo(auxiliar.descripcion)==0) && (i<=Integer.parseInt(cadena2)))
                {
                    i++;
                }
                
                else{
                    medicamentos=encolar_medicamento(nuevo,medicamentos);
                }
                auxiliar=sacar_producto(auxiliar);
            
            } 
        
        }
        
        
        if ((respuesta.compareTo("2")==0) && (existencia_miscelaneos==null))
        {
            System.out.println("No existen miscelaneos en el almacen:");
        
        }
        else if ((respuesta.compareTo("2")==0) && (existencia_miscelaneos!=null))
        {
            System.out.println("Listado de miscelaneos disponibles en el almacen:");
            mostrar_productos(existencia_miscelaneos);
            System.out.println("Ingrese el nombre del miscelaneo a elegir:");
            cadena=teclado.readLine();
            while (!descripcion_repetida(cadena,existencia_miscelaneos))
            {
                System.out.println("Miscelaneo no encontrado. Intente de nuevo:");
                cadena=teclado.readLine();

            }
            salir=false;
            System.out.println("Ingrese la cantidad a elegir:");
            cadena2=teclado.readLine();
            while (!salir)
            {
                salir=true;
                while (!numerico(cadena2) || (cadena2.compareTo("0")==0) )
                {
                    
                    System.out.println("La cantidad a elegir debe ser numerica y mayor que 0. Intente de nuevo:");
                    cadena2=teclado.readLine();
                }
                while (existencia_miscelaneos!=null)
                {
                    if ( (cadena.compareTo(existencia_miscelaneos.descripcion)==0) && (Integer.parseInt(cadena2)>existencia_miscelaneos.cantidad))
                    {
                        System.out.println("La cantidad debe ser menor o igual que la disponible en el almacen. Intente de nuevo:");
                        cadena2=teclado.readLine();
                        salir=false;
                    }
                    else if ( (cadena.compareTo(existencia_miscelaneos.descripcion)==0) && (Integer.parseInt(cadena2)<=existencia_miscelaneos.cantidad))
                    {
                        System.out.println("Compra reailzada:");
                        System.out.println("*Producto: "+existencia_miscelaneos.descripcion);
                        System.out.println("*Cantidad: "+Integer.parseInt(cadena2));
                        System.out.println("<------ GRACIAS POR SU COMPRA --------->");
                        existencia_miscelaneos.cantidad-=Integer.parseInt(cadena2);
                    
                    }
                    nuevo=new producto();
                    nuevo.copiar(existencia_miscelaneos);
                    existencia_miscelaneos=sacar_producto(existencia_miscelaneos);
                    auxiliar=apilar_miscelaneo(nuevo,auxiliar);
                }
                while (auxiliar!=null)
                {
                    nuevo=new producto();
                    nuevo.copiar(auxiliar);
                    if (nuevo.cantidad>0)
                    {
                        existencia_miscelaneos=apilar_miscelaneo(nuevo,existencia_miscelaneos);
                    }
                    
                    auxiliar=sacar_producto(auxiliar);
                }
            }
            while (miscelaneos!=null)
            {
                nuevo=new producto();
                nuevo.copiar(miscelaneos);
                miscelaneos=sacar_producto(miscelaneos);
                auxiliar=apilar_miscelaneo(nuevo,auxiliar);
            }
            i=1;
            while (auxiliar!=null)
            {
                nuevo=new producto();
                nuevo.copiar(auxiliar);
                if ((cadena.compareTo(auxiliar.descripcion)==0) && (i<=Integer.parseInt(cadena2)))
                {
                    i++;
                }
                
                else{
                    miscelaneos=apilar_miscelaneo(nuevo,miscelaneos);
                }
                auxiliar=sacar_producto(auxiliar);
            
            } 
        }
        int enter;
        System.out.println("Pulse ENTER para continuar...");
        do{
            enter=System.in.read();
        }while(enter!=10);
    }
}