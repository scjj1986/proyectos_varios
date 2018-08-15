#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>


char palabra[80],aux[50];

bool palindrom()
{
     int i,j,cont;
     cont=0;
     printf("Ingrese la palabra: \n");
     gets (palabra);
     for (i=0;i<strlen(palabra);i++)
     {
        if (palabra[i]!=' ')
        {
        
            aux[cont]=palabra[i];
            cont++;                  
        } 
     }
     j=strlen(aux)-1;
     for (i=0;i<strlen(aux);i++)
     {
     
          if (aux[i]!=aux[j])
          {
             return false;               
          }
          else
          {
              j--;    
          }   
     }
     return true;
          
}




int main ()
{

   if (palindrom())
   {
      printf ("Es palindromo \n");                
   }
   else
   {
      printf ("No es palindromo \n"); 
   }
   system("pause");  
}
