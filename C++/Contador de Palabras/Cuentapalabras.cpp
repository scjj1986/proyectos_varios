#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>

//
char frase[100],aux[25];
int i,j,k,cont_pal,cont_let;
void cuentapal()
{
     
     printf ("Ingrese la frase \n");
     gets (frase);
     printf("\n");
     j=0;
     k=0;
     cont_pal=0;
     cont_let=0;
     strcpy(aux," ");
     for (i=0;i<strlen(frase);i++)
     {
         if (frase[i]!=' ')
         {
         
            aux[j]=frase[i];
            cont_let++;
            j++;                
         }
         if ((strcmp(aux," ")!=0) &&  ((i+1==strlen(frase)) || (frase[i]==' ')))
         {
              printf("*Palabra: ");
              for (k=0;k<j;k++)
              {
                  printf ("%c",aux[k]);    
              }
              printf("\n");
              
              printf(" Numero de letras: %d",cont_let);
              printf("\n");
              printf("\n");
                   
         }
         if ((i+1==strlen(frase)) || (frase[i]==' '))
         {
         
            cont_let=0;
            cont_pal++;
            strcpy(aux," ");
            j=0;                
         }
     }
     printf("\n");
     printf ("Total de palabras en la frase: %d\n",cont_pal);          
}
int main()
{
     cuentapal();
     system("pause");
     return 0;     
}
