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
   int val;
   struct _nodo *sg;
   struct _nodo *an;
} tipoNodo;

typedef tipoNodo *Node;
typedef tipoNodo *List;

void mostrar (List *l1);
int main ()
{

List lis;
mostrar(&lis);   
return 1;  
}

void mostrar (List *l1)//función para mostrar
{
     
    Node aux;
    aux=*l1;
    if(*l1){
    while (aux->sg)//de alante pa atrás
    {
          aux=aux->sg;
          printf("%d",aux->val);
          }
    while (aux->an)//de atrás pa alante
    {
    
          aux=aux->an;
          printf("%d",aux->val);      
    }      
}
else printf("Lista vacia");
           
     
}
