#include <stdlib.h>
#include <iostream>
#include <conio.h>
#include <stdio.h>
#include <math.h>
int numeros[5];//Arreglo de enteros
bool numerico (char cad[] ){ //metodo para verificar si una cadena de caracteres es numerica
int cont=0;
for (int i=0; i<=strlen(cad); i++)//Se recorre cada caracter del arreglo por medio de un para
{                
   if(isdigit(cad[i]))//Si el caracter de la posici�n actual, es num�rica....
   {                     
       cont++;//...Se incrementa en 1, el contador de caracteres numericos
   }
}
if (strlen(cad)!=cont) return false;//Si la cantidad de carateres numericos es distinta a la cantidad de caracteres del arreglo, devuelve falso la funci�n...
    return true;//...De lo contrario devuelve verdadero          
}
void mostrar ()//Funci�n para mostrar el arreglo de n�meros
{     
    for (int i=0; i<4; i++)//estructura iterativa para recorrer el arreglo
    { 
       printf("[ %d ] ",numeros[i]); //Se muestra por pantalla le valor de la posici�n actual del arreglo        
    }          
}
void intercambio()//Funci�n que implementa el m�todo de ordenaci�n por intercambio
{
    int j,k; //Variables enteras: "j" para guardar otra posici�n del arreglo, y "k" es un auxiliar para implementar el intercambio
     for (int i=0; i<3; i++)//Se recorre el arreglo hasta la pen�ltima posici�n del mismo, por medio de un para
    {        
          j=i+1;//A la variable "j", se le asigna el valor de "i" m�s 1, para preparar el subrecorrido
          while (j<4)// Aqu� se empieza el subrecorrido del arreglo, que empieza desde la posici�n que marca la variable "j", hasta la �ltima posici�n de dicho arreglo.
          {             
             if (numeros[j]<numeros[i])//Si el valor de la posici�n que marca la variable "j" es menor al que marca la variable "i" de la iteraci�n...
             {                                      
                  k=numeros[i];
                  numeros[i]=numeros[j];
                  numeros[j]=k;
                  printf("\n Se intercambian los valores de las posiciones %d y %d, ya que %d es menor que %d.\n",i+1,j+1,numeros[i],numeros[j]);
                  printf("\nAhora el arreglo queda de la sigiuente manera: ");
                  mostrar();//Se genera el intercambio de valores y se muestra por pantalla el arreglo para observar la diferencia
                  printf("\n");                                                                
             }
             j++;//Se incrementa en 1 la variable "j" para continuar el subrecorrido               
          }            
    }   
}
void llenar_arreglo()//Funci�n para que el usuario ingrese los valores que contendr� el arreglo de enteros
{
     char valor [10];//Arreglo de caracteres que capturar� valor por valor, que ingrese el usuario    
     for (int i=0; i<4; i++)//Para cada valor que ingrese el usuario, es fundamental gestionarlo por medio de un para
     {         
        printf("\nIngrese el valor numero %d del arreglo: \n",i+1);
        gets (valor);//Se pide el valor
        while (!numerico(valor))//Mientras que el valor ingresado no sea num�rico...
        {
          printf("El dato debe ser numerico, ingrese nuevamente el valor: \n");
          gets(valor);//Se notifica el error, y se pide nuevamente dicho valor 
        }
        numeros[i]=atoi(valor);//Una vez validado el valor, se transforma a entero y se guarda en la posici�n de turno que indica la variable "i" en el arreglo de n�meros         
     }   
}
int main()//Algoritmo principal
{
    bool salir=false;
    char opcion [10];
    printf("\nBienvenidos a la aplicacion que emplea el metodo de intercambio. A continuacion se procedera a llenar el arreglo\n");
    while (!salir){//Iteraci�n para gestionar si el usuario desea salir de la aplicaci�n
          llenar_arreglo();
          system("cls");
          printf("\nArreglo Inicial: ");
          mostrar();//Se muestra el arreglo antes de invocar la funci�n para ordenar
          printf("\n");
          intercambio();//Se invoca la funci�n para ordenar
          printf("\nArreglo Final: ");
          mostrar();//Se muestra c�mo qued� el arreglo
          printf("\n");
          printf ("\nDesea salir de la aplicaci\242n s/n?: ");
          gets(opcion);//se pregunta al usuario si desea salir del pregrama, se captura la opci�n
          system("cls");
          while ( (strcmp(opcion,"s")!=0) && (strcmp(opcion,"S")!=0) && (strcmp(opcion,"n")!=0) && (strcmp(opcion,"N")!=0) )//Validar la opci�n ingresada
          {
             printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
             gets(opcion);
             system("cls");
           }     
           if ( (strcmp(opcion,"s")==0) || (strcmp(opcion,"S")==0) )//si el usuario desea salir...
           {           
                salir=true;//a la variable "salir", se le asigna verdadero, para salir de la iteraci�n 
           }    
    }
    return 0;   
}
