#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>
#include <time.h>
#include <ctype.h>
#include <iomanip>
#include <dos.h>

#define ASCENDENTE 1
#define DESCENDENTE 0

typedef struct _nodo {
   int valor;
   struct _nodo *siguiente;
   struct _nodo *anterior;
} tipoNodo;

typedef tipoNodo *pNodo;
typedef tipoNodo *Lista;
void Insertar_ini(Lista *l);
void Insertar_fin(Lista *l);
void Buscar(Lista *l);
void Edit (Lista *l);
void Ordenar(Lista *l, Lista *l2);

int main() {
   Lista lista = NULL;
   Lista lista2=NULL;
   char opcion[50];
    int opc;
    bool salir;
    salir=false;
    printf ("Bienvenido a la aplicaci\242n que manipula listas doblemente enlazadas:\n");
    while(!salir){
    printf ("\nIngrese una de las siguientes opciones:\n");
    printf ("\n");
    printf ("Presione '1' si desea ingresar un nuevo elemento al inicio de la lista.\n");
    printf ("Presione '2' si desea ingresar un nuevo elemento al final de la lista.\n");
    printf ("Presione '3' si desea buscar alg\243n elemento de la lista.\n");
    printf ("Presione '4' si desea modificar alg\243n elemento de la lista.\n");
    printf ("Presione '5' si desea ordenar la lista.\n");
    scanf(" %[^\n]",&opcion);
    while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) )//Validar la opción ingresada
    {
   
     printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
     scanf(" %[^\n]",&opcion);
     system("cls");
    }
    opc= atoi (opcion);
    switch (opc)
    {
    
           case 1: Insertar_ini(&lista); 
           break;
           case 2: Insertar_fin(&lista);
           break;
           case 3: Buscar(&lista);
           break;
           case 4: Edit(&lista);
           break;
           case 5: Ordenar(&lista, &lista2);
           break;    
    }
    printf ("\nDesea salir de la aplicaci\242n s/n?: ");
    scanf (" %[^\n]",&opcion);
    system("cls");
    while ( (strcmp(opcion,"s")!=0) && (strcmp(opcion,"S")!=0) && (strcmp(opcion,"n")!=0) && (strcmp(opcion,"N")!=0) )//Validar la opción ingresada
    {
   
     printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
     scanf(" %[^\n]",&opcion);
     system("cls");
    }
      
    if ( (strcmp(opcion,"s")==0) || (strcmp(opcion,"S")==0) )
    {
           
        salir=true;
    }
    }
    return 1;
    
}

void Insertar_ini(Lista *lista) {
    system("cls");
    pNodo nuevo, actual;
    nuevo = (pNodo)malloc(sizeof(tipoNodo));
    char cadena[10];
    int num;
    bool valid;
    bool salir;
    int cont;
    char op[10];
	salir=false;
	while (!salir)
	{
          nuevo = (pNodo)malloc(sizeof(tipoNodo));
        printf ("\n Ingrese el valor numerico del nuevo nodo: ");
	scanf(" %[^\n]",&cadena);
    system("cls");
    valid=false;
    while (!valid)
    {
    
            cont=0;
            for (int i=0; i<=strlen(cadena); i++)
            {
            
                  if( (cadena[i]=='0') || (cadena[i]=='1') || (cadena[i]=='2') || (cadena[i]=='3') || (cadena[i]=='4') || (cadena[i]=='5') || (cadena[i]=='6') || (cadena[i]=='7') || (cadena[i]=='8') || (cadena[i]=='9') )
                  {
                  
                      cont++;
                  }
            }
            if ( cont!=strlen(cadena) )
            {
            
                 printf ("\n Valor invalido. Ingrese nuevamente el valor numerico del nuevo nodo: ",164);
                 scanf (" %[^\n]",&cadena);  
                 system("cls");                   
            }
            else
            {
            
                valid=true;    
            }     
    }
    num=atoi(cadena);
    nuevo->valor=num;
    nuevo->anterior=NULL;
    nuevo->siguiente=NULL;
    if(*lista) nuevo->siguiente=*lista;
     *lista = nuevo;
   printf("\n Desea agregar otro nodo s/n?: ");
    scanf (" %[^\n]",&op);
    system("cls");
    while ( (strcmp(op,"s")!=0) && (strcmp(op,"S")!=0) && (strcmp(op,"n")!=0) && (strcmp(op,"N")!=0) )
    {
   
       printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
       scanf(" %[^\n]",&op);
       system("cls");
    }
    if ( (strcmp(op,"n")==0) || (strcmp(op,"N")==0) )
    {
           
           salir=true;
    }      
    }
   
}

void Insertar_fin(Lista *lista) {
   pNodo nuevo, actual;
   nuevo = (pNodo)malloc(sizeof(tipoNodo));
   
    char cadena[10];
    int num;
    bool valid;
    bool salir;
    int cont;
    char op[10];
	salir=false;
	while (!salir)
	{
          nuevo = (pNodo)malloc(sizeof(tipoNodo));
        printf ("\n Ingrese el valor numerico del nuevo nodo: ");
	scanf(" %[^\n]",&cadena);
    system("cls");
    valid=false;
    while (!valid)
    {
    
            cont=0;
            for (int i=0; i<=strlen(cadena); i++)
            {
            
                  if( (cadena[i]=='0') || (cadena[i]=='1') || (cadena[i]=='2') || (cadena[i]=='3') || (cadena[i]=='4') || (cadena[i]=='5') || (cadena[i]=='6') || (cadena[i]=='7') || (cadena[i]=='8') || (cadena[i]=='9') )
                  {
                  
                      cont++;
                  }
            }
            if ( cont!=strlen(cadena) )
            {
            
                 printf ("\n Valor invalido. Ingrese nuevamente el valor numerico del nuevo nodo: ");
                 scanf (" %[^\n]",&cadena); 
                 system("cls");                   
            }
            else
            {
            
                valid=true;    
            }     
    }
    num=atoi(cadena);
    nuevo->valor=num;
    nuevo->anterior=NULL;
    nuevo->siguiente=NULL;
    actual=*lista;
    
    if(*lista)
    {
     while(actual->siguiente) actual = actual->siguiente;
     nuevo->anterior=actual;
     actual->siguiente=nuevo;
    }
    else
    {
    
     *lista=nuevo;    
    }
     
   printf("\n Desea agregar otro nodo s/n?: ");
    scanf (" %[^\n]",&op);
    system("cls");
    while ( (strcmp(op,"s")!=0) && (strcmp(op,"S")!=0) && (strcmp(op,"n")!=0) && (strcmp(op,"N")!=0) )
    {
   
       printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
       scanf(" %[^\n]",&op);
       system("cls");
    }
    if ( (strcmp(op,"n")==0) || (strcmp(op,"N")==0) )
    {
           
           salir=true;
    }      
    }
   
}

void Buscar(Lista *lista)
{
    pNodo actual;
    char cadena[10];
    int num;
    bool valid;
    bool salir;
    int cont;
    char op[10];
	salir=false;
	while (!salir)
	{
    printf ("\n Ingrese el valor numerico a buscar en la lista: ");    
	scanf(" %[^\n]",&cadena);
    system("cls");
    valid=false;
    while (!valid)
    {
    
            cont=0;
            for (int i=0; i<=strlen(cadena); i++)
            {
            
                  if( (cadena[i]=='0') || (cadena[i]=='1') || (cadena[i]=='2') || (cadena[i]=='3') || (cadena[i]=='4') || (cadena[i]=='5') || (cadena[i]=='6') || (cadena[i]=='7') || (cadena[i]=='8') || (cadena[i]=='9') )
                  {
                  
                      cont++;
                  }
            }
            if ( cont!=strlen(cadena) )
            {
            
                 printf ("\n Valor invalido. Ingrese nuevamente el valor numerico del nuevo nodo: ");
                 scanf (" %[^\n]",&cadena); 
                 system("cls");                   
            }
            else
            {
            
                valid=true;    
            }     
    }
    num=atoi(cadena);
    actual=*lista;
    cont=0;
    int cont2=0;
    if(*lista)
    {
     printf("\n Listado de coincidencias:");
     while(actual) 
     {
        cont++;
        if (actual->valor==num) { cont2++; printf("\n Nodo nr. %d",cont); printf("\n  *Valor= %d \n",num); }         
        actual = actual->siguiente;
     
     }
     if(cont2==0) printf("\n No se encontraron coincidencias.");
           
    }
    else
    {
    
        printf("\n No se encontraron coincidencias.");    
    }
    
    printf("\n Desea agregar otra busqueda s/n?: ");
    scanf (" %[^\n]",&op);
    system("cls");
    while ( (strcmp(op,"s")!=0) && (strcmp(op,"S")!=0) && (strcmp(op,"n")!=0) && (strcmp(op,"N")!=0) )
    {
   
       printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
       scanf(" %[^\n]",&op);
       system("cls");
    }
    if ( (strcmp(op,"n")==0) || (strcmp(op,"N")==0) )
    {
           
           salir=true;
    }
    
    
    }
}

void Edit (Lista *lista)
{

     pNodo actual;
     char cadena[10];
     char op [10];
     bool valid;
     int num;
     bool salir=false;
     while (!salir){
     actual=*lista;
     int cont=0;
     if (!*lista) {printf("\n No se puede implementar este modulo porque la lista esta vacia."); salir=true;}
     else{ printf("\n A continuacion se mostrara la lista:");
     while (actual)
     {
     
          cont++; printf ("\n Nodo nr. %d",cont); printf("\n *Valor:%d",actual->valor);
          actual=actual->siguiente;       
     }
     printf("\n \n Ingrese el item del nodo que desee modificar: ");
     scanf(" %[^\n]",&cadena);
    system("cls");
    valid=false;
    while (!valid)
    {
    
            cont=0;
            for (int i=0; i<=strlen(cadena); i++)
            {
            
                  if( (cadena[i]=='0') || (cadena[i]=='1') || (cadena[i]=='2') || (cadena[i]=='3') || (cadena[i]=='4') || (cadena[i]=='5') || (cadena[i]=='6') || (cadena[i]=='7') || (cadena[i]=='8') || (cadena[i]=='9') )
                  {
                  
                      cont++;
                  }
            }
            if ( cont!=strlen(cadena) )
            {
            
                 printf ("\n Valor invalido. Ingrese nuevamente el valor numerico del nuevo nodo: ");
                 scanf (" %[^\n]",&cadena);  
                 system("cls");                   
            }
            else
            {
            
                valid=true;    
            }     
    }
    num=atoi(cadena);
    actual=*lista;
    if( ((num<=0) || (num>cont)) && (*lista)) printf("\n Item no encontrado.");
    cont=0;
    int val;
    while (actual)
     {
     
          cont++;
          if(cont==num)
          {
          
           printf("\n Ingrese el nuevo valor: ");
           scanf (" %[^\n]",&cadena);
           valid=false;
            while (!valid)
            {
            
                    cont=0;
                    for (int i=0; i<=strlen(cadena); i++)
                    {
                    
                          if( (cadena[i]=='0') || (cadena[i]=='1') || (cadena[i]=='2') || (cadena[i]=='3') || (cadena[i]=='4') || (cadena[i]=='5') || (cadena[i]=='6') || (cadena[i]=='7') || (cadena[i]=='8') || (cadena[i]=='9') )
                          {
                          
                              cont++;
                          }
                    }
                    if ( cont!=strlen(cadena) )
                    {
                    
                         printf ("\n Valor invalido. Ingrese nuevamente el valor numerico del nuevo nodo: ");
                         scanf (" %[^\n]",&cadena);
                         system("cls");                   
                    }
                    else
                    {
                    
                        valid=true;    
                    }     
            }
           val=atoi(cadena);
           actual->valor=val;
                        
          }
          actual=actual->siguiente;       
     }
     
    printf("\n Desea modificar otro nodo s/n?: ");
    scanf (" %[^\n]",&op);
    system("cls");
    while ( (strcmp(op,"s")!=0) && (strcmp(op,"S")!=0) && (strcmp(op,"n")!=0) && (strcmp(op,"N")!=0) )
    {
   
       printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
       scanf(" %[^\n]",&op);
       system("cls");
    }
    if ( (strcmp(op,"n")==0) || (strcmp(op,"N")==0) )
    {
           
           salir=true;
    }}
     
   } 
        
}

void Ordenar(Lista *lista,Lista *lista2)
{

 pNodo nuevo, actual,actual2;
          actual=*lista;
          *lista2=NULL;
          if(!*lista)
          {
          
              printf("\n No se puede implementar este modulo porque la lista esta vacia.");           
          }
          else
          {
              
              while(actual)
              {
                   nuevo = (pNodo)malloc(sizeof(tipoNodo));
                   nuevo->valor=actual->valor;
                   nuevo->anterior=NULL;
                   nuevo->siguiente=NULL;
                   actual2=*lista2;
                   if(!actual2 || actual2->valor > nuevo->valor) {
                      nuevo->siguiente = actual2; 
                      nuevo->anterior = NULL;
                      if(actual2) actual2->anterior = nuevo;
                      if((!*lista2) || (*lista2==actual2)) *lista2 = nuevo;
                   }
                   else {
                      while(actual2->siguiente &&actual2->siguiente->valor <= nuevo->valor) 
                         actual2 = actual2->siguiente;
                      nuevo->siguiente = actual2->siguiente;
                      actual2->siguiente = nuevo;
                      nuevo->anterior = actual2;
                      if(nuevo->siguiente) nuevo->siguiente->anterior = nuevo;
                   }
                   actual=actual->siguiente;
                                
              }
              
              *lista=*lista2;
              actual=*lista;
              printf("\n Lista ordenada en orden ascendente: \n");
              int cont=0;
              while (actual)
              {
              
                   cont++; printf ("\n Nodo nr. %d",cont); printf("\n *Valor:%d",actual->valor);
                   actual=actual->siguiente;        
              }
                  
          }        
}
