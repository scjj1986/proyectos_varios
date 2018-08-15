
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.*;



/**
 *
 * @autores: Jean Carlos Ramail
 *         Estefany Reyes
 *         Ana Tottesout
 */
public class bar {
    
    public static void main(String[] args) throws Exception /*principal*/
    {
        bar.l_ingr l_i;
        bar.l_coct l_c;
        bar.ingrediente nuevo_ingr;
        bar.coctel nuevo_coct;
        String opcion;
        l_i=new bar.l_ingr();
        l_c=new bar.l_coct();
        String valor;
        nuevo_ingr=new bar.ingrediente();
        BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
        System.out.println("Bienvenidos al programa Bar Ramail.");
        opcion="s";
        System.out.println("Seguidamente, debera llenar la lista de ingrediente.");
        while ((opcion.compareTo("s")==0) || (opcion.compareTo("S")==0)){
            nuevo_ingr=new bar.ingrediente();
            l_i.agregar_ingrediente(nuevo_ingr);
            System.out.println("Ingrediente guardado satisfactoriamente.");
            System.out.println("Desea agregar otro ingrediente? (s/n):");
            opcion=entrada.readLine();
            while ( (opcion.compareTo("s")!=0) && (opcion.compareTo("S")!=0) && (opcion.compareTo("n")!=0) && (opcion.compareTo("N")!=0))
            {
                
                System.out.println("Opcion incorrecta. Intente de nuevo:");
                opcion=entrada.readLine();
            }
        }
        System.out.println("A continuacion, debera ingresar los datos de los cocteles:");
        do{
            nuevo_coct=new bar.coctel();
            l_c.agregar_coctel(nuevo_coct,l_i);
            System.out.println("Desea agregar otro coctel? (s/n):");
            opcion=entrada.readLine();
            while ( (opcion.compareTo("s")!=0) && (opcion.compareTo("S")==0) && (opcion.compareTo("n")!=0) && (opcion.compareTo("N")!=0))
            {
                
                System.out.println("Opcion incorrecta. Intente de nuevo:");
                opcion=entrada.readLine();
            }
        
        }while ((opcion.compareTo("s")==0) || (opcion.compareTo("S")==0));
        System.out.println("A continuacion se mostrara el menu de opciones:");
        do
        {
            System.out.println("Presione 1, si desea preparar un trago.");
            System.out.println("Presione 2, para buscar un coctel.");
            System.out.println("Presione 3, para mostrar aquellos cocteles que contengan un grado de alcohol igual o mayor que el indicado por el usuario.");
            System.out.println("Presione 4, para mostrar la lista de ingredientes disponibles.");
            System.out.println("Presione 5, para mostrar el total vendido.");
            System.out.println("Presione 6, para eliminar un coctel.");
            System.out.println("Presione 7, para eliminar un ingrediente.");
            System.out.println("Presione 8, si desea salir del sistema.");
            opcion=entrada.readLine();
            while ( (opcion.compareTo("1")!=0) && (opcion.compareTo("2")!=0) && (opcion.compareTo("3")!=0) && (opcion.compareTo("4")!=0) && (opcion.compareTo("5")!=0) && (opcion.compareTo("6")!=0) && (opcion.compareTo("7")!=0) && (opcion.compareTo("8")!=0))
            {
            
                System.out.println("Opcion incorrecta. Intente de nuevo:");
                opcion=entrada.readLine();
            
            }
            if (opcion.compareTo("1")==0)
            {
            
                l_c.preparar_coctel(l_i);
            }
            else if (opcion.compareTo("2")==0)
            {
            
                l_c.buscar_coctel(l_i);
            }
            else if (opcion.compareTo("3")==0)
            {
            
                l_c.licoreros(l_i);
            }
            else if (opcion.compareTo("4")==0)
            {
            
                if (l_i.primero!=null)
                {
                    System.out.println("Lista de ingredientes disponibles:");
                    l_i.mostrar_lista();
                }
                else
                {
                    System.out.println("Lista vacia.");
                }
            }
            else if (opcion.compareTo("5")==0)
            {
            
                System.out.println("Total vendido: "+l_c.total+"Bs.");
            }
            else if (opcion.compareTo("6")==0)
            {
            
                l_c.eliminar_coctel(l_i);
            }
            else if (opcion.compareTo("7")==0)
            {
            
                l_i.eliminar_ingrediente(l_c);
            }
        
        
        }while (opcion.compareTo("8")!=0);
    
    
    }
    
    
    static class ingrediente{
        
    String codigo,nombre;
    ingrediente sig;
    
    public ingrediente ()
    {
        this.codigo="";
        this.nombre="";
        this.sig=null;
    
    }
    
    }
    
    static class l_ingr{
    
        ingrediente primero;
        public l_ingr ()
        {
            this.primero=null;

        }
        boolean codigo_repetido (String cadena)
        {
            ingrediente aux=primero;
            boolean encontrado=false;
            while (aux!=null)
            {
                if (aux.codigo.compareTo(cadena)==0)
                {
                    encontrado=true;
                
                
                }
                aux=aux.sig;
            }
            return encontrado;
        
        }
                
        public void agregar_ingrediente(ingrediente nuevo) throws IOException
        {
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            System.out.println("Ingrese el codigo del nuevo ingrediente");
            nuevo.codigo=entrada.readLine();
            while (codigo_repetido(nuevo.codigo))
            {
                
                System.out.println("Codigo repetido. Intente nuevamente");
                nuevo.codigo=entrada.readLine();
            
            }
            System.out.println("Ingrese el nombre del nuevo ingrediente");
            nuevo.nombre=entrada.readLine();
           ingrediente aux=primero;
            if (primero==null){
                primero=nuevo;
            
            }
            else
            {
                while (aux.sig!=null)
                {
                    aux=aux.sig;
                
                }
                aux.sig=nuevo;
            
            }
                
        
        }
        
        public void mostrar_lista ()
        {
            ingrediente aux=primero;
            while (aux!=null)
            {
                System.out.println();
                System.out.println("*Codigo: "+aux.codigo);
                System.out.println(" Nombre: "+aux.nombre);
                System.out.println();
                aux=aux.sig;
                
            
            }
        
        
        }
        public void eliminar_ingrediente(l_coct l_c) throws IOException
        {
            if (primero!=null)
            {
                String cod;
                int i;
                BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
                System.out.println("Listado de ingredientes disponibles: ");
                mostrar_lista();
                System.out.println("Ingrese el codigo del ingrediente a eliminar:");
                cod=entrada.readLine();
                while (!codigo_repetido(cod))
                {
                    System.out.println("El codigo no se encuentra en la lista. Intente de nuevo:");
                    cod=entrada.readLine();
                }
                ingrediente aux=primero;
                coctel aux2=l_c.primero;
                if (primero.codigo.compareTo(cod)==0)
                {
                    primero=primero.sig;
                }
                else
                {
                    while ((aux!=null) && (aux.sig!=null))
                    {
                    
                        if (aux.sig.codigo.compareTo(cod)==0)
                        {
                            aux.sig=aux.sig.sig;
                        }
                        else
                        {
                            aux=aux.sig;
                        }
                    }
                }
                while (aux2!=null)
                {
                    for (i=0; i<5; i++)
                    {
                        if ((aux2.ingr[i]!=null) && (aux2.ingr[i].compareTo(cod)==0))
                        {
                            aux2.ingr[i]=null;
                        }
                    }
                    aux2=aux2.sig;
                }
                System.out.println("Ingrediente eliminado satisfactoriamente.");
                
            
            }
            else
            {
                System.out.println("Lista vacia.");
            }
        }
    
    }
    
    static class coctel{
        String codigo,nombre;
        double grado,costo;
        String ingr[];
        coctel sig;
        public coctel()
        {
            this.codigo="";
            this.nombre="";
            this.costo=0.0;
            this.grado=0.0;
            this.sig=null;
            this.ingr=new String[5];
        }
    
    }
    static class l_coct{
        coctel primero;
        double total;
        public l_coct()
        {
            this.primero=null;
            this.total=0;
        }
        
        boolean codigo_repetido (String cadena)
        {
            coctel aux=primero;
            boolean encontrado=false;
            while (aux!=null)
            {
                if (aux.codigo.compareTo(cadena)==0)
                {
                    encontrado=true;
                }
                aux=aux.sig;
            }
            return encontrado;
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
        
        void insertar_inicio(coctel nuevo) throws IOException{ //permite insertar un nodo al inicio de la lista
	
		nuevo.sig=primero;
		primero=nuevo;
	}
	
	void insertar_final(coctel nuevo) throws IOException { //permite insertar un nodo al final de la lista
	
		coctel aux=primero;
		while (aux.sig!=null){
			
                    aux=aux.sig;
		}
		aux.sig=nuevo;	
	}
        
        void insertar_medio (coctel nuevo) throws IOException
        {
           coctel aux=primero;
            while (aux.sig!=null)
            {
                if (   (nuevo.codigo.compareTo(aux.codigo)>0)  && (nuevo.codigo.compareTo(aux.sig.codigo)<0))
                {
                    nuevo.sig=aux.sig;
                    aux.sig=nuevo;
                }
                aux=aux.sig;
            }
        }
        public void mostrar_lista(ingrediente l_ing) throws IOException{
            
            coctel aux=primero;
            ingrediente aux2=l_ing;
            int i;
            if (primero!=null)
            {
                System.out.println("Listado de cocteles:");
                while (aux!=null)
                {
                    System.out.println("+Codigo: "+aux.codigo);
                    System.out.println(" Nombre: "+aux.nombre);
                    System.out.println(" Costo: "+aux.costo);
                    System.out.println(" Grado Alcoholico: "+aux.grado);
                    System.out.println(" Ingredientes: ");
                    for (i=0; i<5; i++)
                    {
                        aux2=l_ing;
                        while (aux2!=null)
                        {
                            if ((aux.ingr[i]!=null) && (aux2.codigo.compareTo(aux.ingr[i])==0))
                            {
                            
                                System.out.println("  -"+aux2.nombre);
                            }
                            aux2=aux2.sig;
                        }
                    }
                    aux=aux.sig;
                }
            }
        }
        public void agregar_coctel(coctel nuevo,l_ingr l_i) throws IOException{
        
            String valor;
            int i,j;
            coctel aux;
            ingrediente aux_ing;
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            System.out.println("Ingrese el codigo del nuevo coctel");
            nuevo.codigo=entrada.readLine();
            while ((codigo_repetido(nuevo.codigo)) || (!numerico (nuevo.codigo)))
            {
                System.out.println("El codigo debe ser numerico e irrepetible. Intente nuevamente");
                nuevo.codigo=entrada.readLine();
            }
            System.out.println("Ingrese el nombre del nuevo coctel");
            nuevo.nombre=entrada.readLine();
            System.out.println("Ingrese el grado alcoholico del nuevo coctel");
            valor=entrada.readLine();
            while (!esDecimal(valor) || !(numerico(valor)))
            {
                System.out.println("El dato debe ser numerico o decimal. Intente nuevamente");
                valor=entrada.readLine();
            }
            nuevo.grado=Double.parseDouble(valor);
            System.out.println("Ingrese el costo del nuevo coctel");
            valor=entrada.readLine();
            while (!esDecimal(valor) || !(numerico(valor)))
            {
                System.out.println("El dato debe ser numerico o decimal. Intente nuevamente");
                valor=entrada.readLine();
            }
            nuevo.costo=Double.parseDouble(valor);
            valor="s";
            i=0;
            while ((valor.compareTo("s")==0) || (valor.compareTo("S")==0))
            {
                if (i<5)
                {
                    System.out.println("Lista de ingredientes disponibles:");
                    l_i.mostrar_lista();
                    System.out.println("Ingrese el codigo del ingrediente a seleccionar:");
                    nuevo.ingr[i]=entrada.readLine();
                    j=i-1;
                    while ((j>=0) || (!l_i.codigo_repetido(nuevo.ingr[i])))
                    {
                        if (!l_i.codigo_repetido(nuevo.ingr[i]))
                        {
                            System.out.println("Codigo no se encuentra registrado en la lista. Intente nuevamente:");
                            nuevo.ingr[i]=entrada.readLine();
                            j=i-1;
                        }    
                        else if (nuevo.ingr[i].compareTo(nuevo.ingr[j])==0)
                        {
                            System.out.println("Codigo repetido. Intente nuevamente:");
                            nuevo.ingr[i]=entrada.readLine();
                            j=i-1;
                        }
                        else
                        {
                            j--;
                        }
                    }
                    System.out.println("Desea agregar otro ingrediente? (s/n):");
                    valor=entrada.readLine();
                    while ( (valor.compareTo("s")!=0) && (valor.compareTo("S")==0) && (valor.compareTo("n")!=0) && (valor.compareTo("N")!=0))
                    {

                        System.out.println("Opcion incorrecta. Intente de nuevo:");
                        valor=entrada.readLine();
                    }
                    aux=primero;
                    if (primero==null)
                    {
                        primero=nuevo;
                    }
                    else
                    {
                        if (Integer.parseInt(nuevo.codigo)<Integer.parseInt(primero.codigo))
                        {
                            insertar_inicio(nuevo);
                        }
                        else
                        {
                            while (aux.sig!=null)
                            {
                                if (Integer.parseInt(nuevo.codigo)<Integer.parseInt(aux.sig.codigo))
                                {
                                    insertar_medio(nuevo);
                                }
                                aux=aux.sig;
                            }
                            if (Integer.parseInt(nuevo.codigo)>Integer.parseInt(aux.codigo))
                            {
                                insertar_final(nuevo);
                            }
                        }
                    }
                    i++;
                }
                else
                {
                    System.out.println("Ya se llego al maximo de ingredientes del coctel");
                    valor="n";
                }
            }
        }
        public void preparar_coctel(l_ingr l_i) throws IOException
        {
            String valor;
            coctel aux=primero;
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            if (primero!=null)
            {
                System.out.println("Lista de cocteles disponibles:");
                mostrar_lista(l_i.primero);
                System.out.println("Ingrese el codigo del coctel de su preferencia:");
                valor=entrada.readLine();
                while (!(codigo_repetido(valor)) || (!numerico (valor)))
                {
                    System.out.println("El codigo no se encuentra en la lista. Intente nuevamente");
                    valor=entrada.readLine();
                }
                while (aux!=null)
                {
                    if (aux.codigo.compareTo(valor)==0)
                    {
                        System.out.println("Usted selecciono el coctel "+aux.nombre+". Gracias por su compra");
                        total+=aux.costo;
                    }
                    aux=aux.sig;
                }
            }
            else
            {
                System.out.println("Lista vacia.");
            }
        }
        
        public void buscar_coctel(l_ingr l_i)throws IOException
        {
            String valor;
            coctel aux=primero;
            ingrediente aux2=l_i.primero;
            int i;
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            if (primero!=null)
            {
                System.out.println("Ingrese el codigo del coctel:");
                valor=entrada.readLine();
                while (!(codigo_repetido(valor)) || (!numerico (valor)))
                {
                    System.out.println("El codigo no se encuentra en la lista. Intente nuevamente");
                    valor=entrada.readLine();
                }
                while (aux!=null)
                {
                    if (aux.codigo.compareTo(valor)==0)
                    {
                        System.out.println("Coincidencia: ");
                        System.out.println();
                        System.out.println("*Codigo: "+aux.codigo);
                        System.out.println(" Nombre: "+aux.nombre);
                        System.out.println(" Grado de Alcohol: "+aux.grado);
                        System.out.println(" Costo: "+aux.costo+" Bs.");
                        System.out.println(" Lista de Ingredientes: "+aux.codigo);
                        for (i=0; i<5; i++)
                        {
                            while (aux2!=null)
                            {
                                if ((aux.ingr[i]!=null) && (aux2.codigo.compareTo(aux.ingr[i])==0))
                                {
                                    System.out.println("  -"+aux2.nombre);
                                }
                                aux2=aux2.sig;
                            }
                        }
                    }
                    aux=aux.sig;
                }
            }
            else
            {
                System.out.println("Lista vacia.");
            }
        }
        
        public void licoreros (l_ingr l_i) throws IOException
        {
            String grad;
            coctel aux=primero;
            boolean encontrado=false;
            ingrediente aux2=l_i.primero;
            int i;
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            if (primero!=null)
            {
                System.out.println("Ingrese el grado alcoholico:");
                grad=entrada.readLine();
                while ((!esDecimal(grad)) || (!numerico(grad)))
                {
                    System.out.println("El grado debe ser numerico o decimal. Intente nuevamente:");
                    grad=entrada.readLine();
                }
                System.out.println("Listado:");
                while (aux!=null)
                {
                    if (Double.parseDouble(grad)<=aux.grado)
                    {
                        encontrado=true;
                        System.out.println();
                        System.out.println("*Codigo: "+aux.codigo);
                        System.out.println(" Nombre: "+aux.nombre);
                        System.out.println(" Grado de Alcohol: "+aux.grado);
                        System.out.println(" Costo: "+aux.costo+" Bs.");
                        System.out.println(" Lista de Ingredientes: ");
                        for (i=0; i<5; i++)
                        {
                            while (aux2!=null)
                            {
                                if ((aux.ingr[i]!=null) && (aux2.codigo.compareTo(aux.ingr[i])==0))
                                {
                                    System.out.println("  -"+aux2.nombre);
                                }
                                aux2=aux2.sig;
                            }
                        }
                    }
                    aux=aux.sig;
                }
                if (!encontrado)
                {
                    System.out.println("No existen cocteles con grado de alconol mayor o igual que "+grad+".");
                }
            }
            else
            {
                System.out.println("Lista vacia.");
            
            }
        }
        
        public void eliminar_coctel(l_ingr l_i)throws IOException
        {
            String cod;
            BufferedReader entrada = new BufferedReader(new InputStreamReader(System.in));
            if (primero!=null)
            {
                System.out.println("Lista de cocteles:");
                mostrar_lista(l_i.primero);
                System.out.println("Ingrese el codigo del coctel a eliminar:");
                cod=entrada.readLine();
                while (!codigo_repetido(cod))
                {
                    System.out.println("El codigo no se encuentra. Intente nuevamente:");
                    cod=entrada.readLine();
                }
                coctel aux=primero;
                if (primero.codigo.compareTo(cod)==0)
                {
                    primero=primero.sig;
                }
                else
                {
                    while ((aux!=null) && (aux.sig!=null))
                    {
                        if (aux.sig.codigo.compareTo(cod)==0)
                        {
                            aux.sig=aux.sig.sig;
                        }
                        else
                        {
                            aux=aux.sig;
                        }
                    }
                }
                System.out.println("Coctel eliminado satisfactoriamente.");
            }
            else
            {
                System.out.println("Lista vacia.");
            }
        }
    }
}
