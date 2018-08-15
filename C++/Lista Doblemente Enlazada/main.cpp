#include <iostream>
#include "Lista.h"
#include "Lista.cpp"
#include <ctype.h>
#include <stdio.h>

#include <conio.h>

#include <string.h>

using namespace std;
bool numerico (char cad[]);
int main()
{
  Lista<int> l1;
  Lista<int> l2;

  string archivo;
  char opt[3];
  char cad[11];
  int pos,val;
  printf ("\n Menu principal:\n");
  bool exit=false;
  while (!exit){
  printf ("\nSi desea ingresar un nodo al principio de la lista, pulse 'a'.");
  printf ("\nSi desea ingresar un nodo al final de la lista, presione 'b'.");
  printf ("\nSi desea editar algun nodo de la lista, ingrese 'c'.");
  printf ("\nSi desea implementar una busqueda en la lista, introduzca 'd'.");
  printf ("\nSi desea ordenar la lista, pulse 'e'.\n");
  scanf(" %[^\n]",&opt);
  for (int i=0;i<=strlen(opt);i++)
      {
      
          opt[i]=tolower(opt[i]);
      }
  
  while ( (strcmp(opt,"a")!=0) && (strcmp(opt,"b")!=0) && (strcmp(opt,"c")!=0) && (strcmp(opt,"d")!=0) && (strcmp(opt,"e")!=0) )
    {
   
     printf ("Opcion incorrecta. Introduzca la opci\242n correcta.\n");
     scanf(" %[^\n]",&opt);
      for (int i=0;i<=strlen(opt);i++)
          {
          
              opt[i]=tolower(opt[i]);
          }
    }
     char opt2=opt[0];
    
    switch(opt2)
    {
    
         case 'a':     printf ("\n");
                      cout << "Ingrese el numero del nuevo nodo" << endl;
                      scanf(" %[^\n]",&cad);
                      while (!numerico(cad))
                      {
                           printf ("Numero invalido. Ingrese nuevamente el valor.\n");
                           scanf(" %[^\n]",&cad); 
                            }
                            
                      l1.ele=atoi(cad);
                      l1.add_head(l1.ele);
                      l1.print(); break;
                      
         case 'b':    printf ("\n");
                      cout << "Ingrese el numero del nuevo nodo" << endl;
                      scanf(" %[^\n]",&cad);
                      while (!numerico(cad))
                      {
                           printf ("Numero invalido. Ingrese nuevamente el valor.\n");
                           scanf(" %[^\n]",&cad); 
                            }
                            
                      l1.ele=atoi(cad);
                      l1.add_end(l1.ele);
                      l1.print(); break;
                      
         case 'c':    printf ("\n");
                      if (l1.num_nodos==0) printf("\n Lista vacia.");
                      else {
                           
                           cout << "Seguidamente, se mostrara por pantalla la lista:" << endl;
                           l1.print();
                           printf("introduzca la posicion del nodo que desea modificar:\n");
                           scanf(" %[^\n]",&cad);
                           while (!numerico(cad))
                          {
                               printf ("Numero invalido. Ingrese nuevamente el valor.\n");
                               scanf(" %[^\n]",&cad); 
                                }
                                
                          pos=atoi(cad);
                          if (pos<1 || pos>l1.num_nodos) printf("\n Valor fuera de rango.");
                          else{
                          printf("introduzca el nuevo valor del nodo:\n");
                          scanf(" %[^\n]",&cad);
                           while (!numerico(cad))
                          {
                               printf ("Numero invalido. Ingrese nuevamente el valor.\n");
                               scanf(" %[^\n]",&cad); 
                                }
                                
                          val=atoi(cad);
                          l1.edit_pos(pos,val);
                          l1.print();
                          }
                          }
                          break;
                          
                           
                      
         case 'd':    printf ("\n");
                      if(l1.num_nodos==0)printf("\n lista vacia.");
                      else{
                      cout << "Ingrese el numero a buscar" << endl;
                      scanf(" %[^\n]",&cad);
                      while (!numerico(cad))
                      {
                           printf ("Numero invalido. Ingrese nuevamente el valor.\n");
                           scanf(" %[^\n]",&cad); 
                            }
                            
                      l1.ele=atoi(cad);
                      l1.search(l1.ele);}
                      break;
                      
         case 'e':    if(l1.num_nodos==0)printf("\n lista vacia.");
                      else {printf ("\n");
                      printf ("\n Lista antes de ordenar:");
                      printf ("\n");
                      l1.print();
                      printf ("\n Lista ordenada:");
                      printf ("\n");
                      l1.sort();
                      l1.print();}
                      break;
    }
  printf ("\nDesea salir del programa s/n?: ");
    scanf (" %[^\n]",&opt);
    while ( (strcmp(opt,"s")!=0) && (strcmp(opt,"S")!=0) && (strcmp(opt,"n")!=0) && (strcmp(opt,"N")!=0) )
    {
   
     printf ("Opcion invalida. Ingrese de nuevo la opcion correcta.\n");
     scanf(" %[^\n]",&opt);
    }
      
    if ( (strcmp(opt,"s")==0) || (strcmp(opt,"S")==0) )
    {
           
        exit=true;
    }
    }
    
  return 1;
}
bool numerico (char cad[] ){
   int cont=0;
  for (int i=0; i<=strlen(cad); i++)
            {
            
                  if( isdigit(cad[i]) )
                  {
                  
                      cont++;
                  }
            } 
            
            if (strlen(cad)!=cont) return false;
            return true;  
    
    }
