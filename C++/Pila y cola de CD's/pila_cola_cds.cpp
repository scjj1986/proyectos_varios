#include <stdio.h>
#include <iostream>
#include <conio.h>
typedef struct nodo{
    char nombre[50], album[50],canciones[10], anyo[10];
    int item;
    struct nodo *sig;
} elemento_lista;

elemento_lista *crear_artista (elemento_lista *nuevo, int i)
{
      nuevo=(struct nodo *) malloc (sizeof (elemento_lista));
      nuevo->sig=NULL;
      printf ("\nIngrese el nombre del artista: \n");
      gets (nuevo->nombre);
      system ("cls");
      printf ("Ingrese el \240lbum del artista: \n");
      gets (nuevo->album);
      system ("cls");
      printf ("Ingrese el n\243mero de canciones del \240lbum: \n");
      gets (nuevo->canciones);
      system ("cls");
      while (atoi(nuevo->canciones)<=0)
      {
           printf ("El n\243mero de canciones debe ser num\202rico y mayor que 0. Intente nuevamente: \n");
           gets (nuevo->canciones);
           system ("cls");       
      }
      printf ("Ingrese el a%co del \240lbum: \n",-92);
      gets (nuevo->anyo);
      system ("cls");
      while (atoi(nuevo->anyo)<=0)
      {
           printf ("El a%co del \240lbum debe ser num\202rico y mayor que 0. Intente nuevamente: \n",-92);
           gets (nuevo->anyo);
           system ("cls");       
      }
      nuevo->item=i;
      return nuevo;   
}

elemento_lista *apilar(elemento_lista *pila_cd,elemento_lista *nuevo)
{                 
      if (pila_cd!=NULL)
      {
          nuevo->sig=pila_cd;     
      }
      pila_cd=nuevo;
      return pila_cd;            
}

elemento_lista *sacar (elemento_lista *pila_cd) 
{
    elemento_lista *aux;
    if (pila_cd->sig==NULL)
    {aux=NULL;}
    else
    {aux=pila_cd->sig;}
    free (pila_cd);
    return aux;
}

void mostrar_nodos (elemento_lista *l)
{
     elemento_lista *aux=l;
     while (aux!=NULL)
     {
           printf ("\n");
           printf("*Nombre del artista: %s \n",aux->nombre);
           printf (" %clbum: %s \n",-75,aux->album);
           printf (" N\243mero de canciones: %s \n",aux->canciones);
           printf(" A%co: %s \n",-92,aux->anyo);
           printf (" Item: %d",aux->item);
           aux=aux->sig;
           printf ("\n");     
     }     
}
elemento_lista *crear_cola (elemento_lista *pila_cd, elemento_lista *cola_cd)
{
      elemento_lista *aux,*nuevo,*nuevo2;
      while (pila_cd!=NULL)
      {
            aux=NULL;
            nuevo=(struct nodo *) malloc (sizeof (elemento_lista));
            nuevo->sig=NULL;
            strcpy (nuevo->nombre,pila_cd->nombre);
            strcpy (nuevo->album,pila_cd->album);
            strcpy (nuevo->canciones,pila_cd->canciones);
            strcpy (nuevo->anyo,pila_cd->anyo);
            nuevo->item=pila_cd->item;
            while (pila_cd!=NULL)
            {
                  nuevo2=(struct nodo *) malloc (sizeof (elemento_lista));
                  nuevo2->sig=NULL;
                  strcpy (nuevo2->nombre,pila_cd->nombre);
                  strcpy (nuevo2->album,pila_cd->album);
                  strcpy (nuevo2->canciones,pila_cd->canciones);
                  strcpy (nuevo2->anyo,pila_cd->anyo);
                  nuevo2->item=pila_cd->item;
                  if (strcmp(pila_cd->nombre,nuevo->nombre)<0)
                  {
                        strcpy (nuevo->nombre,pila_cd->nombre);
                        strcpy (nuevo->album,pila_cd->album);
                        strcpy (nuevo->canciones,pila_cd->canciones);
                        strcpy (nuevo->anyo,pila_cd->anyo);
                        nuevo->item=pila_cd->item; 
                  }
                  aux=apilar(aux,nuevo2);
                  pila_cd=sacar(pila_cd);
              
            }
            while (aux!=NULL)
            {
                 nuevo2=(struct nodo *) malloc (sizeof (elemento_lista));
                 nuevo2->sig=NULL;
                 strcpy (nuevo2->nombre,aux->nombre);
                 strcpy (nuevo2->album,aux->album);
                 strcpy (nuevo2->canciones,aux->canciones);
                 strcpy (nuevo2->anyo,aux->anyo);
                 nuevo2->item=aux->item;
                 if (nuevo->item!=aux->item)
                 {
                      pila_cd=apilar(pila_cd,nuevo2);                        
                 }
                 aux=sacar(aux);     
            }
            if (cola_cd==NULL)
            {
               cola_cd=nuevo;               
            }
            else
            {
                aux=cola_cd;
                while (aux->sig!=NULL)
                {
                      aux=aux->sig;      
                }
                aux->sig=nuevo;    
            }           
      }
      return cola_cd;               
}

elemento_lista *reiniciar (elemento_lista *pila_cd)
{             
    while (pila_cd!=NULL)
    {
          pila_cd=sacar(pila_cd);      
    }
    return pila_cd;
}

int total_canciones (elemento_lista *cola_cd)
{
    elemento_lista *aux=cola_cd;
    int i=0;
    while (aux!=NULL)
    {
       i=i+atoi(aux->canciones);
       aux=aux->sig;   
    }
    return i;    
}

void buscar_artista (elemento_lista *cola_cd)
{

    elemento_lista *aux=cola_cd;
    bool encontrado=false;
    char caracter;
    printf ("Ingrese la letra del artista a buscar: \n");
    caracter=getch();
    printf ("Coincidencia(s) de artistas por la letra %c: \n",caracter);
    while (aux!=NULL)
    {
         if (caracter==aux->nombre[0])
         {
            encontrado=true;
            printf ("\n");
            printf("*Nombre del artista: %s \n",aux->nombre);
            printf (" %clbum: %s \n",-75,aux->album);
            printf (" N\243mero de canciones: %s \n",aux->canciones);
            printf(" A%co: %s \n",-92,aux->anyo);
            printf (" Item: %d",aux->item);
            printf ("\n");                           
         }
         aux=aux->sig;
    }
    if (encontrado==false)
    {
       printf ("\n*No hubo coincidencia(s).\n");                     
    }   
}
int main()
{
    elemento_lista *pila_cd, *nuevo,*cola_cd;
    pila_cd=NULL;
    cola_cd=NULL;
    char resp[10],opc[10];
    int i;
    printf ("Bienvenidos al programa de pila y cola.\n");
    bool salir=false;
    while (salir==false)
    {
       i=0;
       printf ("\nA continuaci\242n deber\240 ingresar los datos de los cd's.\n");
       do{
          i++;
          nuevo=crear_artista(nuevo,i);
          pila_cd=apilar(pila_cd,nuevo);
          system ("cls");
          printf ("Desea agregar otro cd (s/n)?:\n");
          gets (resp);
          while ((strcmp("n",resp)==0) && (strcmp("N",resp)==0) && (strcmp("s",resp)==0) && (strcmp("S",resp)==0))
          {
            printf ("Respuesta incorrecta. Intente nuevamente:\n");
            gets (resp);
            system ("cls"); 
          }
          system ("cls");       
       }while ((strcmp("s",resp)==0) || (strcmp("S",resp)==0));
       printf ("Seguidamente se mostrar\240 los datos apilados de los cd's: \n");
       system ("pause");
       system ("cls");
       printf ("---------------------------- Pila de CD's -----------------------------\n");
       mostrar_nodos(pila_cd);
       printf ("\n-----------------------------------------------------------------------\n");
       printf ("Ahora se mostrar\240 los datos de los cd's ordenados alfab\202ticamente por el nombre del artista: \n");
       system ("pause");
       system ("cls");
       printf ("\n----------- Cola de CD's ordenados por nombre del artista -----------\n");
       cola_cd=crear_cola(pila_cd,cola_cd);
       mostrar_nodos(cola_cd);
       printf ("\n---------------------------------------------------------------------\n");
       system ("pause");
       system ("cls");
       strcpy (resp,"n");
       while ((strcmp("n",resp)==0) || (strcmp("N",resp)==0))
       {
          system ("cls");
          printf ("\nMen\243 de opciones:\n");
          printf ("\n 1)Total de CD's:");
          printf ("\n 2)Total de canciones:");
          printf ("\n 3)Buscar CD por artista:");
          printf ("\n 4)Reiniciar programa:");
          printf ("\n 5)Salir del programa:\n");
          gets (opc);
          system ("cls");
          while ( (strcmp(opc,"1")!=0) && (strcmp(opc,"2")!=0) && (strcmp(opc,"3")!=0) && (strcmp(opc,"4")!=0) &&  (strcmp(opc,"5")!=0))
          {
               printf ("\n Opci\242n fuera de rango. Intente nuevamente:");
               gets (opc);
               system ("cls"); 
          }
          if (strcmp(opc,"1")==0)
          {
              printf ("\n Total de CD's procesados: %d\n",pila_cd->item);
              system("pause");                       
          }
          else if (strcmp(opc,"2")==0)
          {
              printf ("\n Total de canciones de todos los CD's : %d\n",total_canciones(cola_cd));
              system("pause"); 
          }
          else if (strcmp(opc,"3")==0)
          {
               buscar_artista(cola_cd);
               system("pause");
          }
          else if (strcmp(opc,"4")==0)
          {
          
              strcpy (resp,"s");
              pila_cd=reiniciar(pila_cd);
              cola_cd=reiniciar(cola_cd);      
          }
          else{
             strcpy (resp,"s");
             salir=true;  
          }  
       }
    }    
}
