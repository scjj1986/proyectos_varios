#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>

int a[3][4];
int b[3][4];
int v;

void llenado()
{
  int c,d;
  for(c=0; c<3; c++)
  {
     for (d=0;d<4;d++)
     {
         a[c][d]=1;
         b[c][d]=1;    
     }         
  }   
}

void comparar ()
{
  int c,d;
  v=0;
  for(c=0; c<3; c++)
  {
     for (d=0;d<4;d++)
     {
         if(a[c][d]==b[c][d])
         {
            v++;                    
         }    
     }         
  }   
}

int main()
{
  llenado();
  comparar();
  if (v==12)
  {
    printf("Son iguales las matrices \n");        
  }
  else
  {
    printf("Son distintos ");  
  }
  system("pause");
  printf("Se modifica el valor de la matriz 'a'...\n");
  a[2][2]=2;
  comparar();
  if (v==12)
  {
    printf("Son iguales ");        
  }
  else
  {
    printf("Ahora son distintas \n");  
  }
  system("pause");  
}
