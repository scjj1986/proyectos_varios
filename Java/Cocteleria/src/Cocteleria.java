
import java.io.*;

class ingrediente{
    
        String codigo,nombre;
        
        ingrediente sig;
        
        void llenarnodo(ingredientes l) throws IOException
        {
                
                BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
                
		System.out.print("Ingrese el codigo del ingrediente: ");
                
                codigo=teclado.readLine();
                
                while (l.buscarcodigo(codigo,l.lista)==true)
                {
                    System.out.print("El codigo ingresado ya se encuentra en la lista. Intente con otro mas: ");
                    
                    codigo=teclado.readLine();
                }
                
                System.out.print("Ingrese el nombre del ingrediente: ");
                
                nombre=teclado.readLine();
                
                sig=null;
        }
    }
class ingredientes{

    ingrediente lista;
    
    public ingrediente insertaralista(ingrediente nuevo,ingrediente l)
    {
        
        ingrediente aux=l;
        
        if (l!=null)
        {
            
            while (aux.sig!=null)
            {
            
                aux=aux.sig;
                
            }
            
            aux.sig=nuevo;
        }
        else
        {
            
            l=nuevo;
            
        }
        
        return l;
    
    }
    boolean buscarcodigo(String codigo,ingrediente l)
    {
        
        ingrediente aux=l;
        
        while (aux!=null)
        {
            
            if (aux.codigo.compareTo(codigo)==0)
            {
                    
                return true;
                
            }
            
            aux=aux.sig;
        }
        
        return false;
    
    }
    void mostraringredientes()
    {
        ingrediente aux=lista;
        
        if (lista==null)
        {
            
            System.out.println("No hay ingredientes registrados.");
        
        }
        else
        {
        
            while (aux!=null)
            {
                
                System.out.println("->Codigo: "+aux.codigo);
                
                System.out.println("  Nombre: "+aux.nombre);
                
                System.out.println();
                
                aux=aux.sig;

            }
        }    
        
    }
    
    
    public ingrediente eliminaringrediente (ingrediente l, String codigo)
    {
        if (l!=null)
        {
            ingrediente aux=l;
            
            if (l.codigo.compareTo(codigo)==0)
            {
                l=l.sig;
                
            }
            else
            {
               boolean salir=false;
                    
               while ((aux!=null) && (salir==false))
               {
                   if  ((aux.sig!=null) && (aux.sig.codigo.compareTo(codigo)==0))
                   {
                      aux.sig=aux.sig.sig;
                           
                      salir=true;
                            
                    }
                   else
                   {
                       aux=aux.sig;
                        
                    }
                    
               }
                
            }
            
        }
        
        return l;
    
    }
}
class coctel{
    
    int codigo;
    
    String nombre;
    
    float grado_alcoholico, bs;
    
    coctel sig;
    
    ingrediente lista_ingredientes;
    
    void llenarnodo(ingredientes l1,cocteles l2) throws IOException
    {
                int i;
                
                ingrediente nuevo_ingrediente,aux;
                
                BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
                
		System.out.println("Ingrese el codigo del coctel: ");
                
                codigo=Integer.parseInt(teclado.readLine());
                
                while (l2.buscarcodigo(codigo)==true)
                {
                    System.out.println("El codigo ingresado ya se encuentra en la lista. Intente con otro mas: ");
                    
                    codigo=Integer.parseInt(teclado.readLine());
                    
                }
                System.out.println("Ingrese el nombre del coctel: ");
                
                nombre=teclado.readLine();
                
                System.out.println("Ingrese el costo del coctel (Bs.): ");
                
                bs=Float.parseFloat(teclado.readLine());
                
                while (bs==0)
                {
                    System.out.println("El costo del coctel debe ser mayor que 0. Ingrese de nuevo dicho valor: ");
                    bs=Float.parseFloat(teclado.readLine());
                
                }
                
                System.out.println("Ingrese el grado alcoholico del coctel: ");
                
                grado_alcoholico=Float.parseFloat(teclado.readLine());
                
                lista_ingredientes=null;
                
                boolean salir=false;
                
                System.out.println("A continuacion, debera ingresar los ingredientes que contendra el nuevo coctel: ");
                
                while (salir==false)
                {
                    System.out.println("Lista de ingredientes disponibles: ");
                    
                    l1.mostraringredientes();
                    
                    nuevo_ingrediente=new ingrediente();
                    
                    System.out.println("Ahora ingrese el codigo del ingrediente a elegir: ");
                    
                    nuevo_ingrediente.codigo=teclado.readLine();
                    
                    while ((l1.buscarcodigo(nuevo_ingrediente.codigo,l1.lista)==false) || (l1.buscarcodigo(nuevo_ingrediente.codigo,lista_ingredientes)==true))
                    {
                        System.out.println("El codigo no se encuentra en la lista de ingredientes o ya fue agregado. Ingrese de nuevo dicho valor: ");
                        
                        nuevo_ingrediente.codigo=teclado.readLine();
                        
                    }
                    aux=l1.lista;
                    
                    while (aux!=null)
                    {
                        if (aux.codigo.compareTo(nuevo_ingrediente.codigo)==0)
                        {
                            
                            nuevo_ingrediente.nombre=aux.nombre;
                            
                        }
                        
                        aux=aux.sig;
                    }
                    
                    lista_ingredientes=l1.insertaralista(nuevo_ingrediente,lista_ingredientes);
                    
                    char respuesta;
                    
                    System.out.println("Desea agregar otro ingrediente al coctel? (s/n):");
                    
                    respuesta=teclado.readLine().charAt(0);
                    
                    if (respuesta=='n')
                    {
                    
                        salir=true;
                    
                    }
                }
                
                sig=null;
     }
}
class cocteles
{
    public coctel lista;
    
    float venta;
    
    boolean buscarcodigo(int codigo)
    {
        coctel aux=lista;
        while (aux!=null)
        {
            if (aux.codigo==codigo)
            {
                    return true;
                
            }
            aux=aux.sig;
        }
        return false;
    
    }
    public coctel insertaralista (coctel nuevo)
    {
        coctel aux=lista;
        
        if (lista==null)
        {
            
            lista=nuevo;
            
        }
        else if ((lista!=null) && (nuevo.codigo<lista.codigo))
        {
            nuevo.sig=lista;
            
            lista=nuevo;
            
        }
        
        else
        {
            while (aux.sig!=null)
            {
                
                if ((nuevo.codigo>aux.codigo) && (nuevo.codigo<aux.sig.codigo))
                {
                    
                    nuevo.sig=aux.sig;
                    
                    aux.sig=nuevo;
                    
                }
                
                aux=aux.sig;
            
            }
            if (nuevo.codigo>aux.codigo)
            {
            
                   aux.sig=nuevo; 
                   
            }
            
        }
        return lista;
        
    }
    
    void mostrarcocteles() throws IOException
     {
        
        if (lista==null)
        {
            
            System.out.println("No hay ingredientes registrados.");
        
        }
        else
        {
            coctel aux=lista;
            
            ingrediente auxi;
            
            while (aux!=null)
            {
                
                System.out.println("->Codigo: "+aux.codigo);
                
                System.out.println("  Nombre: "+aux.nombre);
                
                System.out.println("  Costo(Bs): "+aux.bs);
                
                System.out.println("  Grado Alcoholico (G.L.): "+aux.grado_alcoholico);
                
                System.out.println("  Lista de ingredientes: ");
                
                auxi=aux.lista_ingredientes;
                
                while (auxi!=null)
                {
                
                    System.out.println("   "+auxi.nombre);
                    
                    auxi=auxi.sig;
                }
                
                System.out.println();
                
                aux=aux.sig;

            }
        }    
        
    }
    
    void servirtrago()throws IOException
    {
        
        if (lista==null)
        {
            System.out.print("No se pueden servir cocteles porque la lista esta vacia. ");
            
        }
        else
        {
        
            BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
            
            int codigo;
                
            System.out.println("Menu de cocteles: ");
            
            mostrarcocteles();
            
            System.out.print("Eliga un coctel, ingresando su codigo: ");
            
            codigo=Integer.parseInt(teclado.readLine());
            
            if (buscarcodigo(codigo)==true)
            {
            
                coctel aux=lista;
                
                while (aux!=null)
                {
                
                    if (codigo==aux.codigo)
                    {
                    
                        System.out.println("Coctel seleccionado: "+aux.nombre+". !!Que lo disfrute¡¡");
                        
                        venta=venta+aux.bs;
                    }
                    
                    aux=aux.sig;
                }
            }
            else
            {
                System.out.println("Codigo no encontrado: ");
            
            }
        }
        
        
    
    }
    
    void buscarcoctel()throws IOException
    {
    
       if (lista==null)
        {
            System.out.print("No se puede realizar la busqueda porque la lista esta vacia. ");
            
        }
        else
        {
        
            BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
            
            int codigo;
                
            System.out.print("Ingrese el codigo de la bebida: ");
            
            codigo=Integer.parseInt(teclado.readLine());
            
            if (buscarcodigo(codigo)==true)
            {
            
                System.out.println("Codigo encontrado: ");
                
                coctel aux=lista;
                
                ingrediente auxi;
                
                while (aux!=null)
                {
                
                    if (codigo==aux.codigo)
                    {
                    
                        System.out.println("->Codigo: "+aux.codigo);
                
                        System.out.println("  Nombre: "+aux.nombre);

                        System.out.println("  Costo(Bs): "+aux.bs);

                        System.out.println("  Grado Alcoholico (G.L.): "+aux.grado_alcoholico);

                        System.out.println("  Lista de ingredientes: ");

                        auxi=aux.lista_ingredientes;

                        while (auxi!=null)
                        {

                            System.out.println("   "+auxi.nombre);

                            auxi=auxi.sig;
                        }

                        System.out.println();
                    }
                    
                    aux=aux.sig;
                }
            }
            else
            {
                System.out.println("Codigo no encontrado: ");
            
            }
        }
    
    }
    
    void gl()throws IOException
    {
        if (lista==null)
        {
            System.out.print("No se puede realizar la busqueda porque la lista esta vacia. ");
            
        }
        else
        {
            
            BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
            
            float grado;
                
            System.out.print("Introduzca el grado: ");
            
            grado=Float.parseFloat(teclado.readLine());
            
            coctel aux=lista;
            
            ingrediente auxi;
            
            int i=0;
            
            System.out.println("Listado: ");
            
            while (aux!=null)
            {
            
                if (aux.grado_alcoholico>=grado){
                    
                    System.out.println("->Codigo: "+aux.codigo);
                
                    System.out.println("  Nombre: "+aux.nombre);

                    System.out.println("  Costo(Bs): "+aux.bs);

                    System.out.println("  Grado Alcoholico (G.L.): "+aux.grado_alcoholico);

                    System.out.println("  Lista de ingredientes: ");

                    auxi=aux.lista_ingredientes;

                    while (auxi!=null)
                    {

                       System.out.println("   "+auxi.nombre);

                       auxi=auxi.sig;
                     }

                     System.out.println();
                     
                     i++;
                     
                }
                
                aux=aux.sig;
                
            }
            
            if (i==0)
            {
            
                System.out.println("Todos los cocteles registrados contienen el grado de alcohol inferior a "+grado);
                
            }
            
            
        }
    
    }
    
    
    public coctel eliminarcoctel ()throws IOException
    {
        if (lista==null)
        {
            System.out.print("No se puede realizar la busqueda porque la lista esta vacia. ");
            
        }
        else
        {
            
            BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
            
            int codigo;
            
            System.out.println("Lista de cocteles: ");
            
            mostrarcocteles();
                
            System.out.print("Introduzca el codigo del coctel: ");
            
            codigo=Integer.parseInt(teclado.readLine());
            
            if (buscarcodigo(codigo)==true)
            {
                coctel aux=lista;
                
                if (lista.codigo==codigo)
                {
                    lista=lista.sig;
                
                }
                else
                {
                    boolean salir=false;
                    
                    while ((aux!=null) && (salir==false))
                    {
                        if ((aux.sig!=null) && (aux.sig.codigo==codigo))
                        {
                           aux.sig=aux.sig.sig;
                           
                           salir=true;
                            
                        }
                        else
                        {
                            aux=aux.sig;
                        
                        }
                    
                    }
                
                }
                System.out.println("Coctel eliminado de manera exitosa.");
                
            
            }
            else
            {
                System.out.println("El codigo ingresado no se encuentra en la lista.");
            
            }
            
            
            
        }
    
        return lista;
    }


}
public class Cocteleria {
    
 
    public static void main(String[] args) throws Exception /*principal*/
    {
    
        BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
        
        ingrediente nodo_ingrediente;
        
        ingredientes l1=new ingredientes();
        
        l1.lista=null;
        
        coctel nodo_coctel;
        
        cocteles l2=new cocteles();
        
        l2.lista=null;
        
        boolean salir;
        
        char respuesta;
        
	System.out.println("Programa que alamacena datos de cocteles. ");
        
        salir=false;
        
        while (salir==false)
        {
            System.out.println("Menu de opciones:");
            
            System.out.println("a) si desea agregar un ingrediente.");
            
            System.out.println("b) si desea agregar un coctel.");
            
            System.out.println("c) para preparar un coctel.");
            
            System.out.println("d) para buscar un coctel.");
            
            System.out.println("e) para verificar aquellos tragos que posean un grado de alcohol superior o igual que el ingresado por usted.");
            
            System.out.println("f) para mostrar el listado de ingredientes con que cuenta el bar.");
            
            System.out.println("g) para calcular el total en ventas de coteles.");
            
            System.out.println("h) para eliminar un coctel de la lista.");
            
            System.out.println("i) para eliminar un ingrediente de la lista:");
            
            respuesta=teclado.readLine().charAt(0);
            
            switch (respuesta)
            {
                case 'a':nodo_ingrediente=new ingrediente();
                
                         nodo_ingrediente.llenarnodo(l1);
                         
                         l1.lista=l1.insertaralista(nodo_ingrediente,l1.lista);
                         
                         System.out.println("La insercion del nuevo ingrediente fue exitosa.");
                         
                         break;
               
                case 'b':if (l1.lista!=null)
                         {
                         
                            nodo_coctel=new coctel();
                
                            nodo_coctel.llenarnodo(l1, l2);

                            l2.insertaralista(nodo_coctel);

                            System.out.println("La insercion del nuevo coctel fue exitosa.");
                            
                         }
                         else
                         {
                        
                            System.out.println("No se puede registrar cocteles debido a que no hay ingredientes en la lista.");
                        
                         }
                         break;
                    
                case 'c':l2.servirtrago();
                
                        break;
                    
                case 'd':l2.buscarcoctel();
                    
                        break;
                    
                case 'e':l2.gl();
                    
                        break;
                case 'f':l1.mostraringredientes();
                    
                        break;
                case 'g':System.out.println("Total en ventas de bebidas (Bs): "+l2.venta);
                    
                        break;
                    
                case 'h': l2.lista=l2.eliminarcoctel();
                        break;
                    
                case 'i': if (l1.lista!=null)
                          {
                              String codigo;
                              
                              System.out.println("Listado de ingredientes: ");
                              
                              l1.mostraringredientes();
                              
                              System.out.print("Ingrese el codigo: ");
                              
                              codigo=teclado.readLine();
                              
                              if (l1.buscarcodigo(codigo, l1.lista)==true)
                              {
                                  l1.lista=l1.eliminaringrediente(l1.lista, codigo);
                                  
                                  coctel auxc=l2.lista;
                                  
                                  while (auxc!=null)
                                  {
                                  
                                      auxc.lista_ingredientes=l1.eliminaringrediente(auxc.lista_ingredientes, codigo);
                                      auxc=auxc.sig;
                                      
                                  }
                                  System.out.println("Ingrediente eliminado con exito.");
                                
                              }
                              else
                              {
                                  System.out.println("IEl codigo ingresado no se encuentra en la lista.");
                              
                              }
                              
                          }
                          else
                          {
                          
                              System.out.println("Esta operacion no se puede efectuar, debido a que la lista esta vacia.");
                          
                          }
            
            
            }
            
            System.out.println("Desea salir de la aplicacion? (s/n):");
                    
            respuesta=teclado.readLine().charAt(0);
                    
            if (respuesta=='s')
            {
                    
                salir=true;
                    
            }
        
        }
        
        
       
    
    }
    
    
}
