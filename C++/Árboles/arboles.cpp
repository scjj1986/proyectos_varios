#include <stdio.h>
#include <conio.h> 
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

typedef struct _nodo {
   int valor,nivel;
   struct _nodo *ramaderecha;
   struct _nodo *ramaizquierda;
} tipoNodo;

typedef tipoNodo *Nodo;
typedef tipoNodo *Arbol;

bool numerico (char cad[] ){ 
int cont=0;
for (int i=0; i<=strlen(cad); i++)
{
                
   if(isdigit(cad[i]))
   {
                      
       cont++; 
   }
}

if (strlen(cad)!=cont) return false; 
    return true;

}
void Insertar(Arbol *ptrarb,int valor,int nivel)
{  
     if (!*ptrarb)
     {
        Nodo nuevo;
        nuevo = (Nodo)malloc(sizeof(tipoNodo));
        nuevo->ramaderecha=NULL;
        nuevo->ramaizquierda=NULL;
        nuevo->valor=valor;
        nuevo->nivel=nivel;
        *ptrarb=nuevo;
                               
     }
     else{
     
          if (valor<=(*ptrarb)->valor){
          
             Insertar (&(*ptrarb)->ramaizquierda,valor,nivel+1);                           
          }
          else{
          
             Insertar (&(*ptrarb)->ramaderecha,valor,nivel+1); 
          }
     }
}

void eliminar_nodo (Arbol *ptrarb,int valor)
{
     if (*ptrarb)
     {
         
         if ((*ptrarb)->valor==valor)
         {
              (*ptrarb)->ramaizquierda=NULL;
              (*ptrarb)->ramaderecha=NULL;
              (*ptrarb)=NULL;
              free (ptrarb);                       
         }
         else if ((*ptrarb)->valor>valor)
         {
              eliminar_nodo(&(*ptrarb)->ramaizquierda,valor);
         }
         else
         {
             eliminar_nodo(&(*ptrarb)->ramaderecha,valor);
         }        
     }     
}
void Preorden(Arbol ptrarb)
{
  if (ptrarb) {       
      printf( "->%d", ptrarb->valor );
      Preorden(ptrarb->ramaizquierda );
      Preorden(ptrarb->ramaderecha );
   }   
}

void Inorden(Arbol ptrarb)
{
  if (ptrarb) {       
      Preorden(ptrarb->ramaizquierda );
      printf( "->%d", ptrarb->valor );
      Preorden(ptrarb->ramaderecha );
   }   
}

void Postorden(Arbol ptrarb)
{
  if (ptrarb) {       
      Preorden(ptrarb->ramaizquierda );
      Preorden(ptrarb->ramaderecha );
      printf( "->%d", ptrarb->valor );
   }   
}

bool Buscar_nodo(Arbol ptrarb, int elem)
{
  if (!ptrarb){
     return false;
  }
  else if (ptrarb->valor < elem){
     return Buscar_nodo(ptrarb->ramaderecha, elem);
  }   
  else if (ptrarb->valor > elem){
     return Buscar_nodo(ptrarb->ramaizquierda, elem);
  }
  else{
       
       return true;}
}

bool Buscar_nivel(Arbol ptrarb, int elem)
{
  if (!ptrarb){
     printf("El elemento no se encuentra en el arbol");
     return false;
  }
  else if (ptrarb->valor < elem){
     return Buscar_nivel(ptrarb->ramaderecha, elem);
  }   
  else if (ptrarb->valor > elem){
     return Buscar_nivel(ptrarb->ramaizquierda, elem);
  }
  else{
        printf("Nodo encontrado, se encuentra en el nivel %d del arbol",ptrarb->nivel);
       
       return true;}
}

int nodos_nivel(Arbol ptrarb, int nivel)
{
    if (ptrarb)
    {
       if (ptrarb->nivel==nivel)
       {
          return 1;                         
       }
       else
       {
         return nodos_nivel(ptrarb->ramaizquierda,nivel)+ nodos_nivel(ptrarb->ramaderecha,nivel);    
       }        
    }
    else
    {
       return 0; 
    }    
}

int nodos_especiales_nivel(Arbol ptrarb, int nivel,int i)

{ 
    nivel++;
    if (!ptrarb)
    {
       if (nivel==i)
       {
          return 1;            
       }
       else
       {
           return 0;    
       }            
    }
    else
    {
       return nodos_especiales_nivel(ptrarb->ramaizquierda,nivel,i)+nodos_especiales_nivel(ptrarb->ramaderecha,nivel,i);
    }
}

void Camino_nodo(Arbol ptrarb, int elem)
{
  if (ptrarb->valor < elem){
     printf("->%d",ptrarb->valor);
     Camino_nodo(ptrarb->ramaderecha, elem);
  }   
  else if (ptrarb->valor > elem){
     printf("->%d",ptrarb->valor);
     Camino_nodo(ptrarb->ramaizquierda, elem);
  }
  else{
       printf("->%d",ptrarb->valor);
     }
}

void Altura(Arbol ptrarb, int elem,int alt[])
{
  if (ptrarb)
  {
          elem++;
          if (elem>alt[0]){
             alt[0]=elem;           
          }
          Altura(ptrarb->ramaizquierda,elem,alt);
          Altura(ptrarb->ramaderecha,elem,alt);        
  }
  else{
       elem--;     
  }  
}

void peso (Arbol ptrarb,int num[])
{

     if (ptrarb)
     {
        num[0]++;
        peso(ptrarb->ramaizquierda,num);
        peso(ptrarb->ramaderecha,num);      
     }     
}
void hojas (Arbol ptrarb,int num[])
{

     if (ptrarb)
     {
        if ((!ptrarb->ramaizquierda) && (!ptrarb->ramaderecha))
        {
           num[0]++;
        }
        hojas(ptrarb->ramaizquierda,num);
        hojas(ptrarb->ramaderecha,num);        
     }     
}

int grado (Arbol ptrarb,int numero)
{

    if (ptrarb){
                
    
        if ((ptrarb->ramaderecha) && (ptrarb->ramaizquierda))
        {
            return 2;                          
        }
        else if (ptrarb->ramaizquierda)
        {
             numero=1;
             return grado (ptrarb->ramaizquierda, numero);
                  
        }
        else if (ptrarb->ramaderecha)
        {
             numero=1;
             return grado (ptrarb->ramaderecha, numero);
                  
        }
        else
        {
             return grado (ptrarb->ramaizquierda, numero);
             return grado (ptrarb->ramaderecha, numero);
                  
        }
                     
    }
    else
    {
    
        return numero;   
    }    
}

int main()
{
  Arbol raiz,aux;
  raiz=NULL;
  char opcion[10];
  char cadena[10];
  int numero;
  int opc,valor,alt[1],num[1],i;
  bool salir=false;
  bool validar;
  int nivel;
  printf("Aplicaci\242n para arboles\n");
  while (!salir){
      printf("\nOpciones\n");
      printf("\n1) Si desea insertar un nodo\n");
      printf("2) Si desea realizar un recorrido 'pre-orden\n"); 
      printf("3) Si desea realizar un recorrido 'in-orden\n");
      printf("4) Si desea realizar un recorrido 'post-orden\n");
      printf("5) Si desea determinar el nivel de un nodo\n");
      printf("6) Si desea determinar el nivel del arbol\n");
      printf("7) Si desea calcular el grado del arbol\n");
      printf("8) Si desea calcular el camino de un nodo\n");
      printf("9) Si desea calcular la altura o profundidad de un arbol\n");
      printf("10) Si desea calcular la longitud de trayectoria interna de un arbol\n");
      printf("11) Si desea calcular la longitud de trayectoria externa de un arbol\n");
      printf("12) Si desea calcular el peso del arbol\n");
      printf("13) Si desea calcular el numero de hojas del arbol\n");
      printf("14) Si desea eliminar un nodo del arbol\n");
      gets(opcion);
      
      while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) && (strcmp(opcion,"6")!=0) && (strcmp(opcion,"7")!=0) && (strcmp(opcion,"8")!=0) && (strcmp(opcion,"9")!=0) && (strcmp(opcion,"10")!=0) && (strcmp(opcion,"11")!=0) && (strcmp(opcion,"12")!=0) && (strcmp(opcion,"13")!=0) && (strcmp(opcion,"14")!=0) )//Validar la opción ingresada
    {
   
     printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
     gets(opcion);
     system("cls");
    }
    opc= atoi (opcion);
    aux=raiz;
    numero=0;
    switch (opc)
    {
    
           case 1:
                
                printf("Ingrese el valor:\n");         
                gets (cadena);
                validar=false;
                while (!validar)
                {
                   validar=true;
                   while (!numerico(cadena))
                   {
                      printf("El dato debe ser numerico, Ingrese nuevamente dicho valor:\n");     
                      gets (cadena);
                      validar=false;      
                   }
                   validar=true;
                   valor=atoi(cadena);
                   if (Buscar_nodo(aux,valor))
                   {
                      printf("El valor del nodo debe ser irrepetible:\n");     
                      gets (cadena);
                      validar=false;    
                   }
                     
                }
                valor=atoi(cadena);
                nivel=0;
                if (!raiz){
                   Insertar(&raiz,valor,nivel); }
                else{
                     Insertar(&aux,valor,nivel); 
                     }
           break;
           case 2:printf("Recorrido en Pre-orden:\n");
                  Preorden(aux);
                  printf("\n");
           break;
           case 3:printf("Recorrido en In-orden:\n");
                  Inorden(aux);
                  printf("\n");
           break;
           case 4:printf("Recorrido en Post-orden:\n");
                  Postorden(aux);
                  printf("\n");
           break;
           case 5: 
                printf("Ingrese el valor:\n");         
                gets (cadena);
                while (!numerico(cadena))
                {
                      printf("El dato debe ser numerico, Ingrese nuevamente dicho valor:\n");     
                      gets (cadena);      
                }
                valor=atoi(cadena);
                nivel=0;
                Buscar_nivel(aux,valor);
           break;
           case 6: alt[0]=0;
                   valor=0;
                   Altura(aux,valor,alt);
                   if (raiz){
                      printf ("El Nivel del arbol es igual a %d\n",alt[0]-1);
                   }
                   else
                   {
                      printf ("Arbol vacio\n");    
                   }
           break;
           case 7: printf("El grado del arbol es: %d\n",grado(aux,numero));
           break;
           
           case 8:
                printf("Ingrese el valor:\n");         
                gets (cadena);
                while (!numerico(cadena))
                {
                      printf("El dato debe ser numerico, Ingrese nuevamente dicho valor:\n");     
                      gets (cadena);      
                }
                valor=atoi(cadena);
                if (!Buscar_nodo(aux,valor))
                {
                
                   printf("El elemento no se encuentra en el arbol\n");                            
                }
                else
                {
                
                     printf("Camino:\n");
                     Camino_nodo(aux,valor);
                     printf("\n");   
                }
                   
           break;
           case 9:
                   alt[0]=0;
                   valor=0;
                   Altura(aux,valor,alt);
                   if (raiz){
                      printf ("La Altura o profundidad del arbol es igual a %d\n",alt[0]);
                   }
                   else
                   {
                      printf ("Arbol vacio\n");    
                   }
           break;
           case 10:alt[0]=0;
                   valor=0;
                   Altura(aux,valor,alt);
                   if (raiz){
                      nivel=alt[0]-1;
                      valor=0;
                      for (i=0; i<=nivel; i++){
                      
                          valor+=nodos_nivel(aux,i)*i;}
                      printf("La longitud de trayectoria interna es equivalente a %d",valor);//una vez calculada la trayectoria, se imprime por pantalla
                      
                   }
                   else
                   {
                      printf ("Arbol vacio\n");    
                   } 
           
           break;
           case 11:alt[0]=0;
                   valor=0;
                   Altura(aux,valor,alt);
                   if (raiz){
                      valor=0;
                      for (i=0; i<=alt[0]; i++)
                      {
                          nivel=-1;
                          valor+=nodos_especiales_nivel(aux,nivel,i)*i;    
                      }
                      printf("La longitud de trayectoria externa es equivalente a %d",valor);
                      
                   }
                   else
                   {
                      printf ("Arbol vacio\n");    
                   }
                   
           break;
           case 12: num[0]=0;
                   peso(aux,num);
                   printf ("El peso del arbol es equivalente a %d",num[0]);
           break;
           case 13:
                   num[0]=0;
                   peso(aux,num);
                   if (num[0]<=1)
                   {
                       printf("No existe hojas en el arbol");             
                   }
                   else
                   {
                        num[0]=0;
                        hojas(aux,num);
                        printf ("El numero de hojas es equivalente a %d",num[0]);   
                   }
           break;
           default:
                   printf("Recuerde que si el valor a ingresar, corresponde a un subarbol o es la raiz misma, se procedera a eliminar incluyendo a sus descendientes.\n");
                   printf("Ingrese el valor:\n");         
                   gets (cadena);
                   while (!numerico(cadena))
                   {
                      printf("El dato debe ser numerico, Ingrese nuevamente dicho valor:\n");     
                      gets (cadena);     
                   }
                   valor=atoi(cadena);
                   if (!Buscar_nodo(aux,valor)){
                   
                      printf("El valor a eliminar no se encuentra en el arbol");
                   }
                   else
                   {
                        if (raiz->valor==valor)
                        {
                           
                           raiz->ramaizquierda=NULL;
                           raiz->ramaderecha=NULL;
                           raiz=NULL;                      
                        }
                        else
                        {
                        
                           eliminar_nodo(&aux,valor);
                           printf("Proceso de eliminacion exitoso.\n");    
                        }  
                   }
           break;
                       
    }
    printf ("\nDesea salir de la aplicaci\242n s/n?: ");
    gets(opcion);
    system("cls");
    while ( (strcmp(opcion,"s")!=0) && (strcmp(opcion,"S")!=0) && (strcmp(opcion,"n")!=0) && (strcmp(opcion,"N")!=0) )//Validar la opción ingresada
    {
   
     printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
     gets(opcion);
     system("cls");
    }
      
    if ( (strcmp(opcion,"s")==0) || (strcmp(opcion,"S")==0) )
    {
           
        salir=true;
    }         
  }   
}
