#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>
#include <time.h>
#include <ctype.h>
#include <fstream>
#include <iomanip>
#include <dos.h>
#include <windows.h>

class nodo_lista
{
   public:
   char valor[50];
   nodo_lista *next;
   nodo_lista()
   {
     strcpy(valor," ");
     next=NULL;      
   }
      
};

typedef nodo_lista *nodo;

class listas
{
    public:
    nodo pila;
    nodo ini_cola;
    listas()
    {
      pila=NULL;
      ini_cola=NULL;        
    }
    void insertar_pila(listas *l)
    {
       nodo_lista *nuevo;
       int cont=0;
       nuevo=new nodo_lista();
       printf ("\n Ingrese el valor: ");
       gets(nuevo->valor);
      /* printf("hola");
       system("pause");*/
       if (l->pila)
       {
         nuevo->next=l->pila;    
       }
       l->pila=nuevo;
       printf("\nEl nuevo nodo ha sido guardado en la pila satisfactoriamente.\n");
    }
    void mostrar_pila(listas *l,int &cont)
    {
    
        nodo_lista *aux;
        aux=l->pila;
        if (l->pila){
        printf("\nListas de elementos de la pila: \n");
        while (aux)
        {
            cont++;
            printf("\n*Nodo Nº %d",cont);
            printf("\n Valor: %s\n",aux->valor);
            aux=aux->next;     
        }
        }
        else{
        printf("\nPila vacia.");
        } 
    }
    
    bool validar_num(char str[],int cont)
    {
    
        int cont2=0;
        for (int i=0; i<=strlen(str); i++)
        {
                    
                    if(isdigit(str[i]))
                    {
                          
                          cont2++;
                    }
        } 
                    
        if (strlen(str)!=cont2)return false;
        cont2=atoi(str);
        if ((cont2==0) || (cont<cont2)) return false;
        return true;
         
    }
    
    void modificar_nodo_pila (listas *l)
    {
    
        nodo_lista *aux;
        int cont=0;
        int num;
        char val[10];
        if (!l->pila){
        
            printf("\nNo se puede modificar nodo alguno debido a que la pila esta vacia.");          
        }
        else{
        
            aux=l->pila;
            mostrar_pila(l,cont);
            printf("\n Ingrese el numero correspondiente al nodo que desee modificar: ");
            gets (val);
            while (!validar_num(val,cont)){
                  printf("\n El dato debe ser numerico y correspondiente con el numero del nodo que desee editar. Ingrese nuevamente el valor: ");
                  gets (val);
            }
            num=atoi(val);
            cont=1;
            while (num>cont){
            
                  cont++;
                  aux=aux->next;
                        
            }
            printf("\nIngrese el nuevo valor: ");
            gets (aux->valor);
            printf("\nEl nuevo nodo ha sido modificado en la pila satisfactoriamente.\n");
            
             
        } 
    }
    
    void eliminar_nodo_pila (listas *l)
    {
    
        nodo_lista *aux;
        int cont=0;
        int cont2=1;
        int num;
        char val[10];
        if (!l->pila){
        
            printf("\nNo se puede eliminar nodo alguno debido a que la pila esta vacia.");          
        }
        else{
        
            aux=l->pila;
            mostrar_pila(l,cont);
            printf("\n Ingrese el numero correspondiente al nodo que desee eliminar: ");
            gets (val);
            while (!validar_num(val,cont)){
                  printf("\n El dato debe ser numerico y correspondiente con el numero del nodo que desee borrar. Ingrese nuevamente el valor: ");
                  gets (val);
            }
            num=atoi(val);
            
            if ((num==1) && (num==cont))
            {
                l->pila=NULL;
                printf("\nEl nodo elegido fue eliminado satisfactoriamente.\n");            
            }
            else if (num==1)
            {
            
                 l->pila=l->pila->next;
                 printf("\nEl nodo elegido fue eliminado satisfactoriamente.\n"); 
            }
            else //if (num!=cont)
            {
                    
                    while (num-1>cont2){
                    
                          cont2++;
                          aux=aux->next;
                                
                    }
                    aux->next=aux->next->next;
                    printf("\nEl nodo elegido fue eliminado satisfactoriamente.\n");
                      
            }
            
             
        } 
    }
    
    
    void insertar_cola(listas *l)
    {
       nodo_lista *nuevo,*aux;
       nuevo=new nodo_lista();
       printf ("\n Ingrese el valor: ");
       gets(nuevo->valor);
      /* printf("hola");
       system("pause");*/
       if (l->ini_cola)
       {
         aux=l->ini_cola;
         while(aux->next){
         
         aux=aux->next;          
         }
         
         aux->next=nuevo;    
       }
       else
       {
       
         l->ini_cola=nuevo;  
       }
       printf("\nEl nuevo nodo ha sido guardado en la cola satisfactoriamente.\n");
    }
    
    void mostrar_cola(listas *l,int &cont)
    {
    
        nodo_lista *aux;
        aux=l->ini_cola;
        if (l->ini_cola){
        printf("\nListas de elementos de la cola: \n");
        while (aux)
        {
            cont++;
            printf("\n*Nodo Nº %d",cont);
            printf("\n Valor: %s\n",aux->valor);
            aux=aux->next;     
        }
        }
        else{
        printf("\nCola vacia.");
        } 
    }
    
    
    void modificar_nodo_cola (listas *l)
    {
    
        nodo_lista *aux;
        int cont=0;
        int num;
        char val[10];
        if (!l->ini_cola){
        
            printf("\nNo se puede modificar nodo alguno debido a que la cola esta vacia.");          
        }
        else{
        
            aux=ini_cola;
            mostrar_cola(l,cont);
            printf("\n Ingrese el numero correspondiente al nodo que desee modificar: ");
            gets (val);
            while (!validar_num(val,cont)){
                  printf("\n El dato debe ser numerico y correspondiente con el numero del nodo que desee editar. Ingrese nuevamente el valor: ");
                  gets (val);
            }
            num=atoi(val);
            cont=1;
            while (num>cont){
            
                  cont++;
                  aux=aux->next;
                        
            }
            printf("\nIngrese el nuevo valor: ");
            gets (aux->valor);
            printf("\nEl nuevo nodo ha sido modificado en la cola satisfactoriamente.\n");
            
             
        } 
    }
    
    void eliminar_nodo_cola (listas *l)
    {
    
        nodo_lista *aux;
        int cont=0;
        int cont2=1;
        int num;
        char val[10];
        if (!l->ini_cola){
        
            printf("\nNo se puede eliminar nodo alguno debido a que la cola esta vacia.");          
        }
        else{
        
            aux=l->ini_cola;
            mostrar_cola(l,cont);
            printf("\n Ingrese el numero correspondiente al nodo que desee eliminar: ");
            gets (val);
            while (!validar_num(val,cont)){
                  printf("\n El dato debe ser numerico y correspondiente con el numero del nodo que desee borrar. Ingrese nuevamente el valor: ");
                  gets (val);
            }
            num=atoi(val);
            
            if ((num==1) && (num==cont))
            {
                l->ini_cola=NULL;
                printf("\nEl nodo elegido fue eliminado satisfactoriamente.\n");            
            }
            else if (num==1)
            {
            
                 l->ini_cola=l->ini_cola->next;
                 printf("\nEl nodo elegido fue eliminado satisfactoriamente.\n"); 
            }
            else //if (num!=cont)
            {
                    
                    while (num-1>cont2){
                    
                          cont2++;
                          aux=aux->next;
                                
                    }
                    aux->next=aux->next->next;
                    printf("\nEl nodo elegido fue eliminado satisfactoriamente.\n");
                      
            }
            
            
             
        } 
    }
    
    
      
};

int main()
{

   listas l;
   char opcion[20];
   bool salir_apl=false;
   int cont;
   printf("\nPrograma que manipula Pilas y Colas.\n");
   while (!salir_apl){
       printf("\nOpciones: \n");
       printf("\n1- Agregar nodo en la pila. ");
       printf("\n2- Mostrar elementos de la pila. ");
       printf("\n3- Modificar el valor de algun nodo de la pila. ");
       printf("\n4- Eliminar algun elemento de la pila. ");
       printf("\n5- Agregar nodo en la cola. ");
       printf("\n6- Mostrar elementos de la cola. ");
       printf("\n7- Modificar el valor de algun nodo de la cola. ");
       printf("\n8- Eliminar algun elemento de la cola.: ");
       gets (opcion);
       while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) && (strcmp(opcion,"6")!=0) && (strcmp(opcion,"7")!=0) && (strcmp(opcion,"8")!=0) )//Validar la opción ingresada
        {
       
         printf ("\n Opcion invalida. Ingrese la opcion correcta: ");
         gets(opcion);
        }
        system("cls");
        cont=0;
        switch (opcion[0])
        {
           case '1': l.insertar_pila(&l);
                     break;
           case '2': l.mostrar_pila(&l,cont);
                     break;
           case '3': l.modificar_nodo_pila(&l);
                     break;
           case '4': l.eliminar_nodo_pila(&l);
                     break;
           case '5': l.insertar_cola(&l);
                     break;
           case '6': l.mostrar_cola(&l,cont);
                     break;
           case '7': l.modificar_nodo_cola(&l);
                     break;
           case '8': l.eliminar_nodo_cola(&l);
                     break;                                 
        }
        printf ("\nDesea salir de la aplicacion s/n?: ");
        gets(opcion);
        while ( (strcmp(opcion,"s")!=0) && (strcmp(opcion,"S")!=0) && (strcmp(opcion,"n")!=0) && (strcmp(opcion,"N")!=0) )//Validar la opción ingresada
        {
       
         printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
         gets(opcion);
         system("cls");
        }
          
        if ( (strcmp(opcion,"s")==0) || (strcmp(opcion,"S")==0) )
        {
               
            salir_apl=true;
        }
        system("cls");
   }
   system("pause");
   return 1;
}
