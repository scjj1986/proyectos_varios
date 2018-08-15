#include <stdlib.h>
#include <iostream>
#include <ctype.h>
#include <fstream>
#include <iomanip>
#include <dos.h>
#include <cstdio>
#include <cstdlib>
#include <conio.h>
#include "io.h"
#include "stdio.h"
#include "errno.h"
using namespace std;
//declaración de la estructura de datos de cada ingrediente que se va a guardar
typedef struct ingrediente{
    char nombre[50], codigo[50];
    struct ingrediente *sig;
} nodo_ingrediente;
//declaración de la estructura de datos de cada ingrediente que se va a guardar
typedef struct coctel{
   char codigo[20], nombre[20], grado[10], costo [15];
   struct ingrediente *ingr;
   struct coctel *sig;                   
} nodo_coctel;

nodo_coctel *nuevo_coctel,*lista_cocteles;//variables que almacenarán el nuevo nodo del coctel y la primera posición de la lista de cocteles respectivamente
nodo_ingrediente *nuevo_ingrediente,*lista_ingredientes;//variables que almacenarán el nuevo nodo del ingrediente y la primera posición de la lista de ingredientes respectivamente
float total_vendido;//variable real que acumula los costos de los tragos que se van preparando

bool numerico(char cadena[])//función booleana que verifica si la cadena de caracteres pasada por parámetro tiene formato numérico
{
  bool aux=true;//por defecto esta variable empieza verdadero
  for (int i=0; i<strlen(cadena); i++)//recorrido de la cadena de caracteres
  {
        if(!isdigit(cadena[i]))//Si algún caracter no es numérico....
        {
            aux=false;//a aux se le asigna falso                       
        }
             
  }
  return aux; //Una vez terminado el recorrido, la función retornará el valor que obtenga aux      
}

bool decimal(char cadena[])//función booleana que verifica si la cadena de caracteres pasada por parámetro tiene formato numérico o decimal
{
     bool aux=true;
     int n_puntos=0;//es necesario contar los puntos de la cadena
     for (int i=0; i<strlen(cadena); i++)//recorrido de la cadena
     {
        if (cadena[i]=='.')//si se encuentra un punto en la cadena...
        {
           n_puntos++;//..se incrementa en 1 el contador de puntos                   
        }
        if(((!isdigit(cadena[i]))&&(cadena[i]!='.')) || (n_puntos>1))//Si se encuentra un caracter que no sea numerico y que no sea un punto; o el contador de puntos sea mayor que 1...
        {
            aux=false; //a aux se le asigna falso                       
        }
             
     }
     return aux;//Una vez terminado el recorrido, la función retornará el valor que obtenga aux
   
}

bool codigo_ingrediente_repetido (nodo_ingrediente *l,char cadena[])//función booleana que verifica si la cadena pasada por parámetro, se encuentra en una lista de ingredientes específica, la cual también es pasada por parámetro
{
    nodo_ingrediente *aux=l;//se declara un apuntador auxiliar para recorrer la lista pasada por parámetro
    bool coinc=false;//antes de empezar la busqueda, a coinc se le asigna falso
    while (aux!=NULL)//recorrido de la lista
    {    
         if  (strcmp(aux->codigo,cadena)==0)//si el codigo de un nodo de la lista coincide con la cadena pasada por parametro 
         {
             coinc=true;// a la variable de coincidencia se le asigna verdadero                                        
         }
         aux=aux->sig;//nodo siguiente 
    }
        
    return coinc; //Una vez terminado el recorrido, la función retornará el valor que obtenga coinc  
}

bool codigo_coctel_repetido (char cadena[])//función booleana que verifica si la cadena pasada por parámetro, se encuentra en una lista de cocteles
{
    nodo_coctel *aux=lista_cocteles;//se declara un apuntador auxiliar para recorrer la lista
    bool coinc=false;//antes de empezar la busqueda, a coinc se le asigna falso
    while (aux!=NULL)//recorrido de la lista
    {    
         if  (strcmp(aux->codigo,cadena)==0) //si el codigo de un nodo de la lista coincide con la cadena pasada por parametro 
         {
             coinc=true;// a la variable de coincidencia se le asigna verdadero                                        
         }
         aux=aux->sig;//nodo siguiente 
    }
        
    return coinc; //Una vez terminado el recorrido, la función retornará el valor que obtenga coinc  
}
nodo_ingrediente *agregar_ingrediente_lista(nodo_ingrediente *l,nodo_ingrediente *nuevo)
/*funcion que retorna un apuntador al primer nodo de una lista de ingredientes especifica.
Se pasa por parámetro una lista de ingredientes dada y el nuevo nodo a insertar en dicha lista*/
{
     if (l==NULL)//si la lista pasada por parámetro es nula...
     {
        l=nuevo;//..al nuevo se le asigna el primer nodo de la lista                           
     }
     else//si no es nula la lista..
     {
         nodo_ingrediente *aux=l;//se usa un apuntador auxiliar para recorrer la lista
         while (aux->sig!=NULL)//se recorre hasta llegar al último nodo
         {
               aux=aux->sig;       
         }
         aux->sig=nuevo;//el nuevo nodo pasa a ser el último de la lista 
     }
     return l;//Una vez terminada la inserción, la función devuelve el primer elemento de la lista   
}

nodo_coctel *agregar_coctel_lista()//funcion que retorna un apuntador al primer nodo de la lista de cocteles.
{
     if (lista_cocteles==NULL)//si la lista de cocteles es nula...
     {
        lista_cocteles=nuevo_coctel; //..al nodo nuevo se le asigna el primer nodo de la lista                            
     }
     else//si no es nula la lista..
     {
         nodo_coctel *aux=lista_cocteles;//se usa un apuntador auxiliar para recorrer la lista
         while (aux->sig!=NULL)//se recorre hasta llegar al último nodo
         {
               aux=aux->sig;       
         }
         aux->sig=nuevo_coctel;//el nuevo nodo pasa a ser el último de la lista    
     }
     return lista_cocteles;//Una vez terminada la inserción, la función devuelve el primer elemento de la lista     
}

nodo_ingrediente *eliminar_ingrediente_lista(nodo_ingrediente *l,char codigo[])
/*funcion que retorna un apuntador al primer nodo de una lista de ingredientes especifica.
Se pasa por parámetro una lista de ingredientes dada y el codigo coincidente de un nodo a eliminar en dicha lista*/
{
    nodo_ingrediente *nodo,*aux;
    nodo=NULL;
    aux=l;//se recorre la lista
    if (strcmp(aux->codigo,codigo)==0)//si es el primer nodo
    {
       printf("El ingrediente de nombre %s, fue eliminado satisfactoriamente\n",aux->nombre);//mensaje referente al nodo a eliminar
       nodo=aux;
       l=aux->sig;//el primer nodo ahora es el siguiente
       free(nodo);//se libera el nodo a eliminar                                  
    }
    else//si no lo es...
    {
        while (aux->sig!=NULL)//se recorre la lista
        {
              if (strcmp(aux->sig->codigo,codigo)==0)//de haber coincidencia...
              {
                   printf("El coctel de nombre %s, fue eliminado satisfactoriamente\n",aux->sig->nombre);//mensaje referente al nodo a eliminar
                   //se elimina al medio y se libera el espacio en memoria del nodo eliminado
                   nodo=aux->sig;
                   aux->sig=aux->sig->sig;
                   free (nodo);                                   
              }
              else//si no hay coincidencia, se verifica el siguiente
              {
                  aux=aux->sig;
              }
        }
    }
    return l; //Una vez terminada la inserción, la función devuelve el primer elemento de la lista
    
}


nodo_coctel *eliminar_coctel_lista(char codigo[])
/*funcion que retorna un apuntador al primer nodo de la lista de cocteles.
Se pasa por parámetro el codigo coincidente de un nodo a eliminar en dicha lista*/
{
    nodo_coctel *nodo,*aux;
    aux=lista_cocteles;//apuntador auxiliar para recorrer la lista
    if (strcmp(aux->codigo,codigo)==0)//si es el primer nodo
    {
       printf("El coctel de nombre %s, fue eliminado satisfactoriamente\n",aux->nombre);//mensaje referente al nodo a eliminar
       nodo=aux;
       //se anula toda la lista de ingredientes de ese nodo
       while (aux->ingr!=NULL)
       {
       aux->ingr=aux->ingr->sig;      
       }
       lista_cocteles=aux->sig;//el primer nodo ahora es el siguiente
       free(nodo);//se libera el nodo a eliminar                                 
    }
    else//si no lo es...
    {
        while (aux->sig!=NULL)//se recorre la lista
        {
              if (strcmp(aux->sig->codigo,codigo)==0)//de haber coincidencia...
              {
                   printf("El coctel de nombre %s, fue eliminado satisfactoriamente\n",aux->sig->nombre);//mensaje referente al nodo a eliminar
                   //se elimina al medio y se libera el espacio en memoria del nodo eliminado
                   nodo=aux->sig;
                   aux->sig=aux->sig->sig;
                   free (nodo);                                   
              }
              else//si no hay coincidencia, se verifica el siguiente
              {
                  aux=aux->sig;
              }
        }
         
    }
    return lista_cocteles;//Una vez terminada la inserción, la función devuelve el primer elemento de la lista
    
}
void obtener_datos_ingredientes (string linea)
/*procedimiento para obtener los datos de una linea del archivo ingredientes.txt. La línea
es pasada por parámetro y los datos a copiar de dicha línea serán guardados en nuevo_ingrediente*/
{
     //se inicializa nuevo_ingrediente
     nuevo_ingrediente=(struct ingrediente *) malloc (sizeof (nodo_ingrediente));
     nuevo_ingrediente->sig=NULL;
     //empieza el recorrido de los caracteres de la línea
     int i=8;
     int j=0;
     while (linea[i]!=',')//copiado del código del ingrediente, cuyo dato se guarda en nuevo_ingrediente->codigo
     {
           nuevo_ingrediente->codigo[j]=linea[i];
           i++;
           j++;      
     }
     nuevo_ingrediente->codigo[j]='\0';
     i=i+10;
     j=0;
     while (i<linea.size())//copiado del nombre del ingrediente, cuyo dato se guarda en nuevo_ingrediente->nombre
     {
           nuevo_ingrediente->nombre[j]=linea[i];
           i++;
           j++;      
     }
     nuevo_ingrediente->nombre[j]='\0';
}

void obtener_datos_cocteles (string linea)
/*procedimiento para obtener los datos de una linea del archivo cocteles.txt. La línea
es pasada por parámetro y los datos a copiar de dicha línea serán guardados en nuevo_coctel
y nuevo_ingrediente*/
{
     //incializacion de nuevo_coctel
     nuevo_coctel=(struct coctel *) malloc (sizeof (nodo_coctel));
     nuevo_coctel->sig=NULL;
     nuevo_coctel->ingr=NULL;
     //empieza el recorrido de los caracteres de la línea
     int i=8;
     int j=0;
     while (linea[i]!=',')//copiado del código del coctel, cuyo dato se guarda en nuevo_coctel->codigo
     {
           nuevo_coctel->codigo[j]=linea[i];
           i++;
           j++;      
     }
     nuevo_coctel->codigo[j]='\0';
     i=i+10;
     j=0;
     while (linea[i]!=',')//copiado del nombre del coctel, cuyo dato se guarda en nuevo_coctel->nombre
     {
           nuevo_coctel->nombre[j]=linea[i];
           i++;
           j++;      
     }
     nuevo_coctel->nombre[j]='\0';
     i=i+20;
     j=0;
     while (linea[i]!=',')//copiado del grado alcoholico del coctel, cuyo dato se guarda en nuevo_coctel->grado
     {
           nuevo_coctel->grado[j]=linea[i];
           i++;
           j++;      
     }
     nuevo_coctel->grado[j]='\0';
     i=i+15;
     j=0;
     while (linea[i]!=',')//copiado del costo del coctel, cuyo dato se guarda en nuevo_coctel->costo
     {
           nuevo_coctel->costo[j]=linea[i];
           i++;
           j++;      
     }
     nuevo_coctel->costo[j]='\0';
     while (i<linea.size())//copiado para la lista de ingredientes del coctel
     {
         //inicializar el nuevo ingrediente
         nuevo_ingrediente=(struct ingrediente *) malloc (sizeof (nodo_ingrediente));
         nuevo_ingrediente->sig=NULL;
         while (linea[i]!=':')
         {
               i++;      
         }
         i=i+2;
         j=0;
         while (linea[i]!=',')//copiado del código del ingrediente, cuyo dato se guarda en nuevo_ingrediente->codigo
         {
           nuevo_ingrediente->codigo[j]=linea[i];
           i++;
           j++;      
         }
         nuevo_ingrediente->codigo[j]='\0';
         while (linea[i]!=':')
         {
               i++;      
         }
         i=i+2;
         j=0;
         while ((i<linea.size()) && (linea[i]!=','))//copiado del nombre del ingrediente, cuyo dato se guarda en nuevo_ingrediente->nombre
         {
           nuevo_ingrediente->nombre[j]=linea[i];
           i++;
           j++;      
         }
         nuevo_ingrediente->nombre[j]='\0';
         nuevo_coctel->ingr=agregar_ingrediente_lista(nuevo_coctel->ingr,nuevo_ingrediente);//el nuevo ingrediente se guarda en la lista de ingredientes del coctel   
     }
     
}

void mostrar_lista_ingredientes()//procedimiento para mostrar la lista de ingredientes disponibles
{
     nodo_ingrediente *aux=lista_ingredientes;//apuntador auxiliar para el recorrido
     if (aux==NULL)//si la lista es nula...
     {
         printf("No hay ingredientes registrados en la base de datos \n");//mensaje             
     }
     else//si no es nula
     {
         while (aux!=NULL)//se muestra los datos de cada nodo
         {
               cout<<"\n";
               printf("*Codigo: %s",aux->codigo);
               cout<<"\n";
               printf(" Nombre: %s",aux->nombre);
               cout<<"\n";
               cout<<"\n";
               aux=aux->sig;
         }         
     }     
}

void mostrar_lista_cocteles()//procedimiento para mostrar la lista de cocteles disponibles
{
     nodo_coctel *aux=lista_cocteles;//apuntador de cocteles auxiliar para el recorrido
     nodo_ingrediente *aux_ingrediente=NULL;//apuntador de ingredientes auxiliar para el recorrido de la lista de ingredientes de cada coctel registrado
     if (aux==NULL)//si la lista es nula...
     {
         printf("No hay cocteles registrados en la base de datos \n"); //mensaje            
     }
     else//si no es nula
     {
          while (aux!=NULL)//se muestra los datos de cada coctel
          {
                cout<<"\n";
                printf("*Codigo: %s",aux->codigo);
                cout<<"\n";
                printf(" Nombre: %s",aux->nombre);
                cout<<"\n";
                printf(" Grado Alcoholico: %s",aux->grado);
                cout<<"\n";
                printf(" Costo (Bs.): %s",aux->costo);
                cout<<"\n";
                printf(" Ingrediente(s):");
                cout<<"\n";
                aux_ingrediente=aux->ingr;
                while (aux_ingrediente!=NULL)//Aquí se muestra la lista de ingredientes del coctel
                {
                      printf(" -%s",aux_ingrediente->nombre);
                      aux_ingrediente=aux_ingrediente->sig;
                      cout<<"\n";       
                }
                cout<<"\n";
                cout<<"\n";
                aux=aux->sig;         
          }   
     }
          
}


void cargar_lista_ingredientes()//procedimiento para copiar todos los datos contenidos en ingredientes.txt a lista_ingredientes
{
     lista_ingredientes=NULL;//inicialización de la lista
     int i= access ("ingredientes.txt",0);//línea de código para acceder al archivo ingredientes.txt
     fstream lectura;//variable para leer el archivo
     string linea;//contendrá cada línea del archivo
     if (i==0)//si se pudo acceder al archivo...
     {
        lectura.open ("ingredientes.txt");//..Se procede a abrirlo
        if (lectura.is_open())//Si se pudo abrir
        {
              
              while (getline(lectura,linea))//se va leyendo línea a línea
              {    
                   obtener_datos_ingredientes(linea);//se obtienen los datos de la linea
                   lista_ingredientes=agregar_ingrediente_lista(lista_ingredientes,nuevo_ingrediente);//Los datos obtenidos se guardan en nuevo_ingrediente, cuyo nodo es insertado a la lista_ingredientes
              }
              lectura.close(); //una vez finalizada toda la lectura del archivo, se procede a cerrarlo                                           
        }
     }     
}

void cargar_lista_cocteles()//procedimiento para copiar todos los datos contenidos en cocteles.txt a lista_cocteles
{
     lista_cocteles=NULL;//inicialización de la lista
     int i= access ("cocteles.txt",0);//línea de código para acceder al archivo ingredientes.txt
     fstream lectura;//variable para leer el archivo
     string linea;//contendrá cada línea del archivo
     if (i==0)//si se pudo acceder al archivo...
     {
        lectura.open ("cocteles.txt");//..Se procede a abrirlo
        if (lectura.is_open())//Si se pudo abrir
        {
              
              while (getline(lectura,linea))//se va leyendo línea a línea
              {    
                   obtener_datos_cocteles(linea);//se obtienen los datos de la linea
                   lista_cocteles=agregar_coctel_lista(); //Los datos obtenidos se guardan en nuevo_ingrediente, cuyo nodo es insertado a la lista de cocteles 
              }
              lectura.close(); //una vez finalizada toda la lectura del archivo, se procede a cerrarlo                                            
        }
    }    
}

void agregar_ingrediente_archivo()//procedimiento para almacenar los datos de un nuevo ingrediente en nuevo_ingrediente y posteriormente copiarlo en el archivo ingredientes.txt
{
    ofstream escritura;//variable para escribir en el archivo
    //incialización de nuevo_ingrediente
    nuevo_ingrediente=(struct ingrediente *) malloc (sizeof (nodo_ingrediente));
    nuevo_ingrediente->sig=NULL;
    printf ("\nIngrese el codigo del ingrediente: \n");
    gets (nuevo_ingrediente->codigo);//solicitud y lectura del codigo
    while (codigo_ingrediente_repetido(lista_ingredientes,nuevo_ingrediente->codigo)==true)//mientras que el código ingresado, coincida con alguno registrado
    {
         printf ("\nEl codigo debe ser irrepetible. Ingrese de nuevo dicho valor: \n");
         gets (nuevo_ingrediente->codigo); //Se solicita y se lee de nuevo el código      
    }
    printf ("\nIngrese el nombre del ingrediente: \n");
    gets (nuevo_ingrediente->nombre);//solicitud y lectura del nombre
    escritura.open("ingredientes.txt",ofstream::app);//Se abre el archivo para escribir al final del mismo
    if (escritura.is_open())//Si se pudo abrir..
    {
           escritura <<"Codigo: "   <<nuevo_ingrediente->codigo  <<", Nombre: "<<nuevo_ingrediente->nombre<<"\n";
           escritura.close(); //Se escribe la información y se cierra                 
    }                               
}

void agregar_coctel_archivo()//procedimiento para almacenar los datos de un nuevo coctel en nuevo_coctel y sus ingredientes en nuevo_ingrediente; y posteriormente copiarlo en el archivo cocteles.txt
{
    ofstream escritura;
    char resp[50];
    float valor;
    int i=0;
    nodo_ingrediente *aux_ingrediente;//variable para escribir en el archivo
    //incialización de nuevo_ingrediente
    nuevo_coctel=(struct coctel *) malloc (sizeof (nodo_coctel));
    nuevo_coctel->ingr=NULL;
    printf ("\nIngrese el codigo del coctel: \n");
    gets (nuevo_coctel->codigo);//solicitud y lectura del codigo
    while (    (codigo_coctel_repetido(nuevo_coctel->codigo) ) || (!numerico(nuevo_coctel->codigo)))//mientras que el código ingresado, coincida con alguno registrado o no tenga formato numerico...
    {
         printf ("\nEl codigo debe ser numerico e irrepetible. Ingrese de nuevo dicho valor: \n");
         gets (nuevo_coctel->codigo); //Se solicita y se lee de nuevo el código       
    }
    printf ("\nIngrese el nombre del coctel: \n");
    gets (nuevo_coctel->nombre);//solicitud y lectura del nombre
    printf ("\nIngrese el grado alcoholico del coctel: \n");
    gets (nuevo_coctel->grado);//solicitud y lectura del grado alcoholico
    while (!decimal(nuevo_coctel->grado))//mientras el grado ingresado no sea decimal
    {
          printf ("\nEl valor debe ser numerico o decimal. Intente nuevamente: \n");
          gets (nuevo_coctel->grado); //Se solicita y se lee de nuevo el grado     
    }
    printf ("\nIngrese el costo del coctel (Bs.): \n");
    gets (nuevo_coctel->costo);//solicitud y lectura del costo
    while ((!decimal(nuevo_coctel->costo)) || (atof(nuevo_coctel->costo)<=0))//mientras el grado ingresado no sea decimal o sea 0
    {
          printf ("\nEl valor debe ser numerico y mayor que 0. Intente nuevamente: \n");
          gets (nuevo_coctel->costo);//Se solicita y se lee de nuevo el grado      
    }
    printf ("\nA continuaci\242n se mostrara la lista de los ingredientes:.\n");
    system("pause");
    do{
         //inserción de ingredientes: primero se muestra la lista para que el usuario ingrese el código del ingrediente a elegir
         mostrar_lista_ingredientes();
         nuevo_ingrediente=(struct ingrediente *) malloc (sizeof (nodo_ingrediente));
         nuevo_ingrediente->sig=NULL;//inicialización de nuevo_ingrediente
         printf ("\nIngrese el codigo del ingrediente que contendra el coctel:\n");
         gets (nuevo_ingrediente->codigo);//solicitud y lectura del codigo del ingrediente
         while ((codigo_ingrediente_repetido(lista_ingredientes,nuevo_ingrediente->codigo)==false) || (codigo_ingrediente_repetido(nuevo_coctel->ingr,nuevo_ingrediente->codigo)==true))//Mientras el codigo no se encuentre en la lista de ingredientes o ya fue ingresado el la lista de ingredientes del coctel...
         {
              printf ("\nEl codigo no se encuentra en la base de datos o ya fue ingresado en el coctel. Ingrese de nuevo dicho valor: \n");
              gets (nuevo_ingrediente->codigo); //Se solicita y se lee de nuevo el codigo      
         }
         aux_ingrediente=lista_ingredientes;
         while (aux_ingrediente!=NULL)//Se recorre la lista de ingredientes para copiar el nombre coincidente con el codigo recién ingresado
         {
               if (strcmp(aux_ingrediente->codigo,nuevo_ingrediente->codigo)==0)
               {
               
                  strcpy (nuevo_ingrediente->nombre,aux_ingrediente->nombre);//aquí se copia el nombre
                  printf ("\nUsted eligio: %s\n",nuevo_ingrediente->nombre); //mensaje del nombre del ingrediente que se eligio                                                              
               }
               
               aux_ingrediente=aux_ingrediente->sig;   
         }
         nuevo_coctel->ingr=agregar_ingrediente_lista (nuevo_coctel->ingr,nuevo_ingrediente);//Se agrega el ingrediente a la lista de ingredientes del nuevo coctel
         printf ("Desea agregar otro ingrediente (s/n)?:\n");
         gets (resp);//Se pregunta si desea agregar otro ingrediente
         while ((strcmp("n",resp)!=0) && (strcmp("N",resp)!=0) && (strcmp("s",resp)!=0) && (strcmp("S",resp)!=0))//validar opcion
         {
            printf ("Respuesta incorrecta. Intente de nuevo:\n");
            gets (resp);
            system ("cls"); 
         }
         system ("cls"); 
    }while ((strcmp("s",resp)==0) || (strcmp("S",resp)==0));
    escritura.open("cocteles.txt",ofstream::app);//Se procede a abrir el archivo cocteles.txt para su escritura al final
    if (escritura.is_open())
    {
           escritura <<"Codigo: "   <<nuevo_coctel->codigo  <<", Nombre: "<<nuevo_coctel->nombre<<", Grado Alcoholico: "<<nuevo_coctel->grado<<", Costo (Bs.): "<<nuevo_coctel->costo;
           aux_ingrediente=nuevo_coctel->ingr;
           while (aux_ingrediente!=NULL)
           {
                 i++;
                 escritura <<", Codigo ingrediente Nr. "<<i<<": "<<aux_ingrediente->codigo<<", Nombre ingrediente Nr. "<<i<<": "<<aux_ingrediente->nombre;
                 aux_ingrediente=aux_ingrediente->sig;     
           }
           escritura<<endl;
           escritura.close();//Se escribe la información y se cierra                  
    }                               
}

void actualizar_archivo_cocteles()//procedimiento para copiar la información de la lista de cocteles a cocteles.txt
{
  ofstream escritura;
  nodo_coctel *aux=lista_cocteles;//apuntador auxiliar de coctel para el recorrido de la lista 
  nodo_ingrediente *aux2=NULL;//apuntador auxiliar de ingredientes para el recorrido de la lista de ingredientes de cada coctel
  int i=0;
  if (lista_cocteles!=NULL)//si la lista de cocteles no es nula...
  {
       escritura.open("cocteles.txt");//se abre el archivo
       if (escritura.is_open())//si se pudo abrir
       {
          while (aux!=NULL)//se recorre la lista de cocteles
          {
            
            escritura <<"Codigo: "   <<aux->codigo  <<", Nombre: "<<aux->nombre<<", Grado Alcoholico: "<<aux->grado<<", Costo (Bs.): "<<aux->costo;//se copia el dato de cada coctel
            aux2=nuevo_coctel->ingr;
            while (aux2!=NULL)//se recorre la lista de ingredientes
            {
                 i++;
                 escritura <<", Codigo ingrediente Nr. "<<i<<": "<<aux2->codigo<<", Nombre ingrediente Nr. "<<i<<": "<<aux2->nombre;//aquí se copia sus respectivos ingredientes
                 aux2=aux2->sig;     
            }
            escritura<<endl;
            aux=aux->sig;    
          }
          escritura.close();//Una vez recorrida la lista se cierra el archivo
       }                     
  }
  else//si la lista es nula
  {
      
      remove ("cocteles.txt"); //se elimina el archivo   
  }        
}

void actualizar_archivo_ingredientes()//procedimiento para copiar la información de la lista de ingredientes a ingredientes.txt
{
  ofstream escritura;
  nodo_ingrediente *aux=lista_ingredientes;//apuntador auxiliar de coctel para el recorrido de la lista 
  if (lista_ingredientes!=NULL)//si la lista no es nula...
  {
       escritura.open("ingredientes.txt");//se abre el archivo
       if (escritura.is_open())//si se pudo abrir
       {
          while (aux!=NULL)//se recorre la lista
          {
            
            escritura <<"Codigo: "   <<aux->codigo  <<", Nombre: "<<aux->nombre;//se copia el dato de cada ingrediente
            escritura<<endl;
            aux=aux->sig;    
          }
          escritura.close();//Una vez recorrida la lista se cierra el archivo
       }                     
  }
  else//si la lista es nula
  {
      
      remove ("cocteles.txt");//se elimina el archivo    
  }        
}






void preparar_trago()//procedimiento para preparar un trago elegido por el usuario
{
        printf ("Listado de cocteles disponibles: \n");
        mostrar_lista_cocteles();//Primero se muestra la lista de los cocteles disponibles
        nodo_coctel *aux=lista_cocteles;//apuntador auxiliar para el recorrido de la lista de cocteles
        char codigo[20];
        if (lista_cocteles!=NULL)//si la lista no es nula... 
        {
        
            printf ("Ingrese el codigo del coctel de su preferencia: \n");
            gets(codigo);//solicitud y lectura del codigo del coctel
            while (codigo_coctel_repetido(codigo)==false)//si el codigo no es encuentra en la lista de cocteles...
            {
                  
                  printf ("El codigo no se encuentra en la base de datos. Intente nuevamente: \n");
                  gets(codigo); //solicitud y lectura del codigo del coctel nuevamente     
            }
            while (aux!=NULL)//Se recorre la lista para ver la coincidencia el código
            {
            
                  if (strcmp (aux->codigo,codigo)==0)//Cuando haya coincidencia...
                  {
                  
                        printf("Usted eligio: %s. !!Gracias por su compra¡¡\n",aux->nombre);//Mensaje referente al coctel que eligio
                        total_vendido=total_vendido+atof(aux->costo);//Se le suma el costo del coctel al tottal vendido              
                  }
                  aux=aux->sig;    
            }                           
        }   
}

void buscar_coctel ()//procedimiento para buscar un coctel a partir de su código
{
     nodo_coctel *aux=lista_cocteles;//apuntador auxiliar para el recorrido de la lista de cocteles
     nodo_ingrediente *aux_ingrediente=NULL;//apuntador auxiliar para el recorrido de la lista de ingredientes de cada coctel
     char codigo[20];
     if (lista_cocteles==NULL)//si la lista de cocteles es nula
     {
        printf("\nNo hay cocteles registrados en la base de datos");//...mensaje                         
     }
     else//de no ser nula...
     {
         printf ("\nIngrese el codigo del coctel a buscar: \n");
         gets (codigo);//Solicitud y lectura del código a buscar
         if (codigo_coctel_repetido(codigo)==true)//Si el codigo ingresado coincide con el de algún nodo de la lista de cocteles
         {
             while (aux!=NULL)//se procede al recorrido de la lista de cocteles
             {
                   if (strcmp(aux->codigo,codigo)==0)//De haber coincidencia en un nodo específico
                   {
                                                     
                        printf ("\nResultado de la busqueda: \n");//Se Muestra los datos del coctel coincidente..
                        cout<<"\n";
                        printf("*Codigo: %s",aux->codigo);
                        cout<<"\n";
                        printf(" Nombre: %s",aux->nombre);
                        cout<<"\n";
                        printf(" Grado Alcoholico: %s",aux->grado);
                        cout<<"\n";
                        printf(" Costo (Bs.): %s",aux->costo);
                        cout<<"\n";
                        printf(" Ingrediente(s):");
                        cout<<"\n";
                        aux_ingrediente=aux->ingr;
                        while (aux_ingrediente!=NULL)//...y sus ingredientes
                        {
                              printf(" -%s",aux_ingrediente->nombre);
                              aux_ingrediente=aux_ingrediente->sig;
                              cout<<"\n";       
                        }                                  
                   }
                   aux=aux->sig;     
             }        
         }
         else//de no haber coincidencia
         {
             printf ("\nNo hubo coincidencias.\n");//mensaje    
         }
     }      
}

void cocteles_alcoholicos()//procedimiento para determinar cuáles son los cocteles con mayor o igual grado alcoholico ingresado por el usuario
{
     nodo_coctel *aux=lista_cocteles;//apuntador auxiliar para el recorrido de la lista de cocteles
     nodo_ingrediente *aux_ingrediente;//apuntador auxiliar para el recorrido de la lista de ingredientes de cada coctel
     char grado[20];
     bool coinc=false;//variable booleana para las coincidencias
     if (lista_cocteles!=NULL)//si la lista no está vacía
     {
            printf ("\nIngrese el grado a evaluar:\n");
            gets(grado);//solicitud y lectura del grado
            while ((!numerico(grado)) || (!decimal(grado))) //mientras que no sea numérico
            {
                  printf ("\nEl valor debe ser numerico o decimal. Intente nuevamente:\n");
                  gets(grado);//solicitud y lectura del grado nuevamente      
            }
            printf ("\nListado de bebidas cuyo grado de alcohol es igual o mayor a %sº:\n",grado);
            while (aux!=NULL)//se recorre la lista para verficar los cocteles alcoholicos
            {
                  if (atof(aux->grado)>=atof(grado))//Si es mayor o igual que el indicado por el usuario... 
                  {
                  
                        coinc=true;//la variable de coincidencia se le asigna verdadero y se muestra el coctel..
                        cout<<"\n";
                        printf("*Codigo: %s",aux->codigo);
                        cout<<"\n";
                        printf(" Nombre: %s",aux->nombre);
                        cout<<"\n";
                        printf(" Grado Alcoholico: %s",aux->grado);
                        cout<<"\n";
                        printf(" Costo (Bs.): %s",aux->costo);
                        cout<<"\n";
                        printf(" Ingrediente(s):");
                        cout<<"\n";
                        aux_ingrediente=aux->ingr;
                        while (aux_ingrediente!=NULL)//...y la lista de ingredientes
                        {
                              printf(" -%s",aux_ingrediente->nombre);
                              aux_ingrediente=aux_ingrediente->sig;
                              cout<<"\n";       
                        }
                        cout<<"\n";
                        cout<<"\n";                                    
                  }
                  aux=aux->sig;      
            }
            if (coinc==false)//si la variable de coincidencia es falso
            {
                 printf("\nNo hubo coincidencias\n"); //mensaje           
            }                 
     }
     else//si la lista es nula
     {
         printf("\nNo hay cocteles registrados\n");//mensaje    
     }     
     
}

int main()
{
    char resp[10],codigo[20];
    total_vendido=0; 
    nodo_coctel *auxc;
    printf ("Bienvenidos al programa de cocteles.\n");
    printf ("\nA continuaci\242n deber\240 ingresar los datos de los ingredientes.\n");
    do{
         cargar_lista_ingredientes();//se cargan los datos del archivo ingredientes.txt a lista_ingredientes
         agregar_ingrediente_archivo();//Se agrega el nuevo ingrediente al archivo
         lista_ingredientes=agregar_ingrediente_lista(lista_ingredientes,nuevo_ingrediente); //se agrega el nuevo nodo a la lista de ingredientes              
         printf ("Desea agregar otro ingrediente? (s/n):\n");
         gets (resp);//solicitud y lectura si desea agregar otro ingrediente
         while ((strcmp("n",resp)==0) && (strcmp("N",resp)==0) && (strcmp("s",resp)==0) && (strcmp("S",resp)==0))//validacion de respuesta
         {
            printf ("Respuesta incorrecta. Intente de nuevo:\n");
            gets (resp);
            system ("cls"); 
         }
         system ("cls");                        
                                
                                
    }while ((strcmp("s",resp)==0) || (strcmp("S",resp)==0));
    printf ("\nSeguidamente deber\240 ingresar los datos de los cocteles.\n");
    do{
           
           cargar_lista_cocteles();//se cargan los datos del archivo cocteles.txt a lista_cocteles
          agregar_coctel_archivo();//Se agrega el nuevo coctel al archivo
          lista_cocteles=agregar_coctel_lista();//se agrega el nuevo nodo a la lista de cocteles 
           printf ("Desea agregar otro coctel (s/n)?:\n");
           gets (resp);//solicitud y lectura si desea agregar otro coctel
           while ((strcmp("n",resp)==0) && (strcmp("N",resp)==0) && (strcmp("s",resp)==0) && (strcmp("S",resp)==0))//validacion de respuesta
           {
             printf ("Respuesta incorrecta. Intente de nuevo:\n");
             gets (resp);
             system ("cls"); 
           }
           system ("cls"); 
           
           
    }while ((strcmp("s",resp)==0) || (strcmp("S",resp)==0));
    printf ("\nSeguidamente se muestra el menu de opciones:.\n");
    system ("pause");
    do{
          printf ("\nMen\243 de opciones:\n");//menu de opciones
          printf ("\n 1)Preparar trago:");
          printf ("\n 2)Buscar coctel por codigo:");
          printf ("\n 3)Listado de cocteles que tengan un grado de alcohol igual o mayor indicado por usted:");
          printf ("\n 4)Listado de ingredientes disponibles:");
          printf ("\n 5)Mostrar el total generado en el bar, procedente de la venta de los cocteles:\n");
          printf ("\n 6)Eliminar un coctel de la lista:\n");
          printf ("\n 7)Eliminar un ingrediente de la lista:\n");
          printf ("\n 8)Salir del programa:\n");
          gets (resp);//lectura de opción
          system ("cls");
          while ( (strcmp(resp,"1")!=0) && (strcmp(resp,"2")!=0) && (strcmp(resp,"3")!=0) && (strcmp(resp,"4")!=0) &&  (strcmp(resp,"5")!=0) &&  (strcmp(resp,"6")!=0) &&  (strcmp(resp,"7")!=0) &&  (strcmp(resp,"8")!=0))//validación
          {
               printf ("\n Opci\242n fuera de rango. Intente nuevamente:");
               gets (resp);
               system ("cls"); 
          }
          if (strcmp(resp,"1")==0)//si es 1, preparar trago
          {
              preparar_trago();
              strcpy (resp,"n"); 
              system("pause");
          }
          else if (strcmp(resp,"2")==0)//si es 2, buscar coctel
          {
              buscar_coctel();
              strcpy (resp,"n"); 
              system("pause");
          }
          else if (strcmp(resp,"3")==0)//si es 3, cocteles alcoholicos
          {
              cocteles_alcoholicos();
              strcpy (resp,"n"); 
              system("pause");
          }
          else if (strcmp(resp,"4")==0)//si es 4, se muestra la lista de los ingredientes
          {
              mostrar_lista_ingredientes();
              strcpy (resp,"n"); 
              system("pause");
          }
          else if (strcmp(resp,"5")==0)//si es 5, se muestra el total vendido en el día
          {
              printf("Total vendido en el dia: %.2f Bs.\n",total_vendido);
              strcpy (resp,"n"); 
              system("pause");                       
          }
          else if (strcmp(resp,"6")==0)//si es 6...
          {
              
              if (lista_cocteles!=NULL)//si la lista de cocteles no está vacía...
              {
              
                 printf("\n Se mostrara el listado de cocteles:\n");
                 system("pause");
                 mostrar_lista_cocteles();//se muestra la lista de cocteles
                 printf("Ahora ingrese el codigo del coctel a eliminar:\n");
                 gets(codigo);//solicitud y lectura del código del coctel a eliminar
                 while (!codigo_coctel_repetido(codigo))//mientras que el código no se encuentre en la lista...
                 {
                       printf("Codigo no encontrado. Intente nuevamente:\n");
                       gets(codigo);  //solicitud y lectura del código del coctel a eliminar nuevamente    
                 }
                 lista_cocteles=eliminar_coctel_lista(codigo);//se elimina el nodo que contenga el código del coctel coincidente
                 actualizar_archivo_cocteles();//y se actualiza el archivo cocteles.txt
                                          
              }
              else//si es vacía...
              {
                  printf("\nNo hay cocteles registrados\n"); //mensaje   
              }
              
              strcpy (resp,"n"); 
              system("pause");                      
          }
          else if (strcmp(resp,"7")==0)//si es 7...
          {
              
              if (lista_ingredientes!=NULL)//si la lista de ingredientes no está vacía...
              {
              
                 printf("\n Se mostrara el listado de ingredientes:\n");
                 system("pause");
                 mostrar_lista_ingredientes();//se muestra la lista de ingredientes
                 printf("Ahora ingrese el codigo del ingrediente a eliminar:\n");
                 gets(codigo);//solicitud y lectura del código del ingrediente a eliminar
                 while (!codigo_ingrediente_repetido(lista_ingredientes,codigo))//mientras que el código no se encuentre en la lista...
                 {
                       printf("Codigo no encontrado. Intente nuevamente:\n");
                       gets(codigo);//solicitud y lectura del código del ingrediente a eliminar nuevamente      
                 }
                 lista_ingredientes=eliminar_ingrediente_lista(lista_ingredientes,codigo);//se elimina el nodo que contenga el código del ingrediente coincidente
                 actualizar_archivo_ingredientes();//y se actualiza el archivo cocteles.txt
                 auxc=lista_cocteles;//Ahora se recorre la lista de cocteles
                 while (auxc!=NULL)
                 {
                       if (codigo_ingrediente_repetido(auxc->ingr,codigo)==true)//de haber coincidencia en la lista de ingredientes de un nodo específico
                       {
                             auxc->ingr=eliminar_ingrediente_lista(auxc->ingr,codigo);//se elimina de esa el nodo que contenga el código del ingrediente coincidente
                       }
                       auxc=auxc->sig;      
                       
                 }
                 actualizar_archivo_cocteles();//Se actualiza el archivo cocteles.txt
                                          
              }
              else//si esta vacia...
              {
                  printf("\nNo hay ingredientes registrados\n");  //mensaje  
              }
              
              strcpy (resp,"n"); 
              system("pause");                      
          }
          else if (strcmp(resp,"8")==0)//se sale de la aplicación
          {
             strcpy (resp,"s"); 
          }
          system ("cls");      
           
    }while ((strcmp("n",resp)==0) || (strcmp("N",resp)==0));
    system ("pause");   
    
}
