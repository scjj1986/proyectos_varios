#include <stdio.h>
#include <conio.h> /*Hay que incluir las librerías donde se encuentran las funciones*/
#include <string.h>
#include <stdlib.h>
#include <iostream>
#include <time.h>
#include <ctype.h>
#include <fstream>
#include <iomanip>
#include <dos.h>
using namespace std;
FILE *fpw, *fpr;
void new_book();
void query_book();
int generar_cota();
int main () //Función principal
{
   //system("cls");
   char opcion[50];
   int opc;
   bool salir;
   cout << "Bienvenido a la aplicaci\242n que permite almacenar libros de biblioteca\n";//Bienvenida a la aplicación
   salir=false;
   while (salir==false){//estructura repetitiva hasta que el usuario quiera salir de la aplicación
   printf ("\n**************************** Men\243 Principal **********************************\n");
   printf ("\nIngrese una de las siguientes opciones:\n");
   printf ("\n");
   printf ("Presione '1' si desea agregar un nuevo libro.\n");
   printf ("Presione '2' si desea consultar los datos de alg\243n libro.\n");
   printf ("Presione '3' si desea salir de la aplicaci\242n.\n");
   scanf(" %[^\n]",&opcion);
   system("cls");
   while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) )//Validar la opción ingresada
  {
   
    printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
    scanf(" %[^\n]",&opcion);//Se recibe de nuevo la opción
    system("cls");
    }
    opc= atoi (opcion);//Se transforma a entero la opción y se guarda en la variable "opc"
    if (opc ==1)//Si el usuario presionó "1"....
    {
       new_book();//Se invoca la función "new_book()", la cual permite registrar los datos concernientes a los libros de la biblioteca, dicha data se guarda en un archivo de texto de nombre "Library.txt"     
    }
    else if(opc==2)//Si el usuario presionó 3...
    {
    
       query_book();//Se sale de la aplicación        
    }
    else//Si el usuario presionó 3...
    {
    
       getchar();
       return 0; //Se sale de la aplicación        
    }
    
}
}

void new_book()//función new_book()
    {
         
      char nombre[100];//Arreglo de caracteres para guardar el nombre del nuevo libro que será ingresado por teclado
      char autor[100];//Arreglo de caracteres para guardar el autor del nuevo libro que será ingresado por teclado
      char edit[100];//Arreglo de caracteres para guardar la editorial del nuevo libro que será ingresado por teclado
      char year[100];
      char linea[200]="";;//Arreglo de caracteres para guardar el año del nuevo libro que será ingresado por teclado
      int yr;//Variable de tipo entero que será útil para validar el año del nuevo libro que será ingresado por teclado 
      char op[20];//Arreglo de caracteres que permite guardar la opción 
      int cont;//Variable de tipo entero, útil para validar el nombre del autor(que no lleve números) y el año de publicación (que no lleve letras o símbolos) del nuevo libro que será ingresado por teclado
      int cota;//Variable numérica que almacenará el número de cota generada por la aplicación
      bool valid;//Variable booleana útil para validar el nombre del autor y el año de publicación del nuevo libro a ingresar
      valid=false;//Se inicializa para que pueda ingresar a la iteración de validación del nombre del autor
      bool salir;//Variable booleana útil para determinar si el usuario desea ingresar otros datos de un libro o desea regresar al menú principal
      salir=false;//Se inicializa para que pueda ingresar a la iteración de inserción de datos
      while (salir==false){//Inicio de iteración de inserción de datos
      printf ("Ingrese el nombre del nuevo libro: ");
      scanf (" %[^\n]",&nombre);//Se recibe el nombre del nuevo libro a almacenar
      system("cls");
      for (int i=0;i<=strlen(nombre);i++)
      {
      
          nombre[i]=toupper(nombre[i]);
      }
      system("cls");
      printf ("\nIngrese el autor del nuevo libro: ");
      scanf (" %[^\n]",&autor);//Se recibe el autor del nuevo libro a almacenar
      system("cls");
      while (valid==false)//Inicio de iteración para validar si el nombre del autor no contenga caracteres numéricos
     {
            cont=0;//Esta variable contendrá la cantidad de caracteres numéricos que tenga el arreglo "autor"
            for(int i=0; i<=strlen(autor); i++)//Se recorre casilla por casilla, el arreglo previamente mencionado. De haber una coincidencia en cada casilla, se autoincrementa la variable  entera "cont"
            {
                    if (autor[i]== '1'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '2'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '3'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '4'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '5'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '6'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '7'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '8'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '9'){
                    
                       cont ++;               
                    }
                    else if (autor[i]== '0'){
                    
                       cont ++;               
                    }
            }//Fin de la iteración del recorrido de casillas del arreglo "autor"
            if (cont>0){//Si hay uno o más caracteres numéricos en el arreglo.....
                        
                     printf ("Error, el nombre del autor no lleva n\243meros. Ingrese nuevamente el nombre del autor.\n");//Mensaje de error
                     printf ("\nIngrese el autor del nuevo libro: ");//Se pide nuevamente el autor
                     scanf (" %[^\n]",&autor);//Se recibe y se guarda para ser nuevamente evaluada
                     system("cls");
            }
            else//Si no tiene caracteres numéricos....
            {
            
                valid=true;//Sale de la iteración 
            }
     }//fin de la iteración para validar el autor
     for (int i=0;i<=strlen(autor);i++)
      {
      
          autor[i]=toupper(autor[i]);
      }
      system("cls");
      printf ("\nIngrese la editorial del nuevo libro: ");//Se solicita la editorial del nuevo libro
      scanf (" %[^\n]",&edit);//Se recibe y se guarda en el arreglo "edit"
      system("cls");
      for (int i=0;i<=strlen(edit);i++)
      {
      
          edit[i]=toupper(edit[i]);
      }
      system("cls");
      printf ("\nIngrese el a%co del libro: ",164);//Se pide el año del libro
       scanf (" %[^\n]",&year);//Se guarda en el arreglo "year"
       system("cls");
      time_t t; struct tm *ahora; time(&t); ahora = localtime(&t); int yr_act= ahora->tm_year + 1900;//Código para generar el año actual que será útil para validar el año
      valid=false;//A la variable lógica "valid" se le asigna "false" para que pueda ingresar a la iteración de validación del año
      while (valid==false)//Inicio de la iteración de la vaidación del año
      {
            cont=0;//Esta variable contendrá la cantidad de caracteres numéricos que tenga el arreglo "year"
            for (int i=0; i<=strlen(year); i++)//Se recorre el arreglo
            {
            
                  if( (year[i]=='0') || (year[i]=='1') || (year[i]=='2') || (year[i]=='3') || (year[i]=='4') || (year[i]=='5') || (year[i]=='6') || (year[i]=='7') || (year[i]=='8') || (year[i]=='9') )
                  {
                  
                      cont++;//Por cada caracter numérico que se encuentre en cada casilla del arreglo, se autoincrementa la variable "cont"
                  }
            }
            if ( cont!=strlen(year) )//Si la cantidad de caracteres numéricos, no coincide con la cantidad de caracteres del arreglo "year"
            {
            
                 printf ("\n A%co invalido. Ingrese nuevamente el a%co del libro: ",164);//se envía un mensaje de error y se solicita nuevamente el año
                 scanf (" %[^\n]",&year);//Se guarda en el arreglo "year" para ser nuevamente evaluada la cadena de caracteres  
                 system("cls");                   
            }
            else//Si son iguales, es decir, si la cadena de caracteres tiene un formato numérico
            {
            
                yr= atoi(year);//Se transforma la cadena de caracteres a entero, dicha conversión se guarda en la variable entera "yr"
                if( (yr>yr_act) || (yr<1000))//Si no se encuentra en el intervalo, es decir, el año menor q 0 ó mayor que año actual (2011, por ejemplo)...
                {
                
                      printf ("\n A%co invalida. Ingrese nuevamente el a%co del libro: ",164);//Se envía el mensaje de error y se pide de nuevo el año
                      scanf (" %[^\n]",&year);//Se guarda en el arreglo "year" para ser nuevamente evaluada la cadena de caracteres
                      system("cls");
                }
                else//si se encuentra en el intervalo
                {
                
                    valid=true;//A la variable "valid" se le asigna "false" para que pueda salir de la iteración
                }    
            }    
      }//Fin de la iteración para validar el año
         int i=0;
         int j;
         int k;
         int l=0;
         char lin [200];
         bool rep =false;
         fpr=fopen("Library.txt", "r"); //Abrir archivo para lectura
         if (fpr)
         {  
              
              //l=0;
              while (( fgets(linea,200,fpr)!= NULL ) && (rep==false))
              {
                    //printf("%s\n",linea);
                    cont=0;
                    i=0;
                    l=0;
                    j=0;
                    k=0;
                    while (i<=strlen(linea))
                    {
                    
                            if(linea[i]=='|')
                            {
                            
                                 cont++;               
                            }
                            if (cont==2)
                            {
                                        
                                 i=i+20;
                                 j=0;
                                 k=0;
                                 while(linea[i+1]!='|')
                                 {
                                          
                                          //printf ("%c",linea[i]);
                                          if(linea[i]==nombre[j])
                                          {
                                          
                                                k++;
                                                                
                                          } 
                                          i++;
                                          j++;            
                                 }
                                 if (   (k==j) && (k==strlen(nombre))    )
                                 {
                                     l++;
                                     //printf("si \n");
                                 }   
                            }
                            else if (cont==4)
                            {
                                        
                                 i=i+9;
                                 j=0;
                                 k=0;
                                 while(linea[i+1]!='|')
                                 {
                                 
                                         // printf ("%c",linea[i]);
                                          if(linea[i]==autor[j])
                                          {
                                          
                                                k++;                       
                                          } 
                                          i++;
                                          j++;            
                                 }
                                 if (   (k==j) && (k==strlen(autor) )   )
                                 {
                                     l++;
                                     //printf("si \n");
                                 }   
                            }
                            else if (cont==6)
                            {
                                        
                                 i=i+13;
                                 j=0;
                                 k=0;
                                 while(linea[i+1]!='|')
                                 {
                                 
                                          //printf ("%c",linea[i]);
                                          if(linea[i]==edit[j])
                                          {
                                          
                                                k++;                       
                                          } 
                                          i++;
                                          j++;            
                                 }
                                 if (   (k==j) && (k==strlen(edit)  )  )
                                 {
                                     l++;
                                     //printf("si \n");
                                 }   
                            }
                            else if (cont==8)
                            {
                                        
                                 i=i+7;
                                 j=0;
                                 k=0;
                                 while(i<=strlen(linea))
                                 {
                                 
                                          
                                          if(linea[i]==year[j])
                                          {
                                          
                                                k++; 
                                                //printf ("%c",linea[i]);                      
                                          } 
                                          i++;
                                          j++;            
                                 }
                                 //printf("%d",k);
                                 //printf ("%s",year);
                                 k--;
                                 j-=2;
                                 if (   (k==j) && (k==strlen(year)   ) )
                                 {
                                     l++;
                                     //printf("si \n");
                                 }  
                            }
                            
                            i++;
                    }
                    if (l==4)
                    {
                    
                       rep=true;
                       strcpy(lin,linea);        
                    }
                    
    
              }
         }
         fclose(fpr);
      //printf("%d\n",cont);
      //printf("%d",l);
      if (rep==true)
      {
              //printf("%s",lin);
              printf ("\nLos datos introducidos corresponden a un libro previamente registrado. Desea registrar el nuevo libro de todas maneras s/n?: ");
              scanf (" %[^\n]",&op);
              system("cls");
              while ( (strcmp(op,"s")!=0) && (strcmp(op,"S")!=0) && (strcmp(op,"n")!=0) && (strcmp(op,"N")!=0) )//Validar la opción ingresada
              {
   
               printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
               scanf(" %[^\n]",&op);//Se pide de nuevo la opción
               system("cls");
               }
               if ( (strcmp(op,"s")==0) || (strcmp(op,"S")==0) )
               {
           
                  fpw = fopen("Library.txt", "a+t");
                  fprintf (fpw, "%s",lin);
                  fclose (fpw);
               }                                            
      }
      else
      {
      
          cota=generar_cota();//Función para generar el número aleatorio e irrepetible de la cota del nuevo libro
          fpw = fopen("Library.txt", "a+t");
          printf ("\nDatos almacenados satisfactoriamente. El n\243mero de cota del nuevo libro es '%d' ",cota);
          fprintf (fpw, "Numero de Cota: %d %s %s %s %s %s %s %s %d\n",cota,"|| Nombre del Libro:",nombre,"|| Autor:",autor,"|| Editorial:",edit,"|| Ano:",yr);
          fclose (fpw);    
      }
      
      printf ("\nDesea registrar un nuevo libro s/n?: ");
      scanf (" %[^\n]",&op);
      system("cls");
      while ( (strcmp(op,"s")!=0) && (strcmp(op,"S")!=0) && (strcmp(op,"n")!=0) && (strcmp(op,"N")!=0) )//Validar la opción ingresada
      {
   
       printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
       scanf(" %[^\n]",&op);//Se pide de nuevo la opción
       system("cls");
      }
      
      if ( (strcmp(op,"n")==0) || (strcmp(op,"N")==0) )
      {
           
           salir=true;
      }
      }
      
    }
    int generar_cota(){//
      int cot;
      int n;
      char num[3];
      int j;
      int nr;
      bool rep;
      bool exit;
      char linea[200];
      srand(time(NULL));
      cot= rand() % 1000; 
      fpr = fopen("Library.txt", "r"); /*Abrir archivo para lectura*/
      if (fpr == NULL)
      { return cot; 
      }else{
            exit=false;
            while (exit==false)
            {
                  rep=false;
                  while ((fgets(linea,200,fpr)!= NULL) && (rep==false)){
                        n=16;
                        j=0;
                        while (linea[n]!=' ')
                        {
                         num[j]=linea[n];
                         j++;n++;
                         
                         }
                         nr=atoi(num);
                         if (cot==nr){
                               rep=true;                  
                         }
                  }
                  if(rep==false){
                  
                                 exit=true;
                                 fclose(fpr);
                  }
                  else{
                       
                       srand(time(NULL));
                       cot= rand() % 1000;
                       fclose(fpr);
                       fpr = fopen("Library.txt", "r"); /*Abrir archivo para lectura*/
                  }                
            }          
      }
      return cot;
    }
    
    void query_book()
    {
    
         char opcion [50];
         char opc [50];
         char cota[50];
         char autor [200];
         char linea [200];
         char lin [200];
         bool rep;
         bool enc;
         int i;
         int coinc;
         //int i;
         bool salir=false;
         while (salir==false)
         {
             printf("\nA continuacion, elija la opcion de consulta:\n");
             printf("\nSi desea consultar por cota, presione '1'. ");
             printf("\nSi desea consultar por autor, presione '2'. ");
             printf("\nSi desea volver al menu principal, presione '3'.\n");
             scanf(" %[^\n]",&opcion);
             system("cls");
             while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) )//Validar la opción ingresada
             {
       
              printf ("\nError al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
              scanf(" %[^\n]",&opcion);//Se recibe de nuevo la opción
              system("cls");
              
              }
              if ( strcmp(opcion,"1")==0 )
              {
              
                    printf ("Ingrese el n\243mero de cota a consultar: ");//Mensaje de error
                    scanf(" %[^\n]",&cota);
                    system("cls");
                    bool valid=false;
                    int cont=0;
                    
                    while (valid==false)
                    {
                        cont=0;//Esta variable contendrá la cantidad de caracteres numéricos que tenga el arreglo "year"
                        for (int i=0; i<=strlen(cota); i++)//Se recorre el arreglo
                        {
                        
                              if( (cota[i]=='0') || (cota[i]=='1') || (cota[i]=='2') || (cota[i]=='3') || (cota[i]=='4') || (cota[i]=='5') || (cota[i]=='6') || (cota[i]=='7') || (cota[i]=='8') || (cota[i]=='9') )
                              {
                              
                                  cont++;//Por cada caracter numérico que se encuentre en cada casilla del arreglo, se autoincrementa la variable "cont"
                              }
                        }
                        if ( cont!=strlen(cota) )//Si la cantidad de caracteres numéricos, no coincide con la cantidad de caracteres del arreglo "year"
                        {
                        
                             printf ("\n Cota invalida. Ingrese nuevamente el n\243mero de cota a consultar: ");//se envía un mensaje de error y se solicita nuevamente el año
                             scanf (" %[^\n]",&cota);//Se guarda en el arreglo "year" para ser nuevamente evaluada la cadena de caracteres
                             system("cls");                     
                        }
                        else//Si son iguales, es decir, si la cadena de caracteres tiene un formato numérico
                        {
                            valid=true;        
                        }
                    }
                    fpr=fopen("library.txt","r");
                    
                    if(!fpr)
                    {
                    
                          printf("\nNo se encontraron coincidencias. ");
                                    
                    }else
                    {
                         
                         coinc=0;
                         int j;
                         while( (fgets(linea,200,fpr)!= NULL) )
                         {
                            cont=0;
                            i=16;
                            j=0;
                            
                            while(linea[i]!=' ')
                            {
                                 if(cota[j]==linea[i])
                                 {
                                 
                                     cont++;                   
                                 }
                                 i++;
                                 j++;
                                             
                            }
                            if(   (cont==j) && (cont==strlen(cota) )   )
                            {
                            
                                  coinc++;
                                  strcpy(lin,linea);
                                                        
                            }   
                                
                         }
                    }
                    fclose(fpr);
                    if (coinc==0)
                    {
                    
                          printf("\nNo se encontraron coincidencias. ");           
                    }
                    else
                    {
                    
                            printf("\nSe encontro(aron) %d coincidencia(s). ",coinc);
                            cont=0;
                            i=0;
                            while (i<=strlen(lin))
                            {
                            
                                    if(lin[i]=='|')
                                    {
                                    
                                         cont++;               
                                    }
                                    if (cont==2)
                                    {
                                                
                                         i=i+20;
                                        /* j=0;
                                         k=0;*/
                                         printf("\nNombre del Libro: ");
                                         while(lin[i+1]!='|')
                                         {
                                                  
                                                  printf ("%c",lin[i]);
                                                  i++;
                                                              
                                         }  
                                    }
                                    else if (cont==4)
                                    {
                                                
                                         i=i+9;
                                         printf("\nAutor del Libro: ");
                                         while(lin[i+1]!='|')
                                         {
                                                  
                                                  printf ("%c",lin[i]);
                                                  i++;
                                                              
                                         }  
                                    
                                    }else if (cont==6)
                                    {
                                                
                                         i=i+13;
                                         printf("\nEditorial del Libro: ");
                                         while(lin[i+1]!='|')
                                         {
                                                  
                                                  printf ("%c",lin[i]);
                                                  i++;
                                                              
                                         }  
                                    
                                    }else if (cont==8)
                                    {
                                                
                                         i=i+7;
                                         printf("\nA%co del Libro: ",164);
                                         while(i<=strlen(lin))
                                         {
                                         
                                                  
                                                  printf ("%c",lin[i]);                      
                                                  i++;           
                                         }
                                    
                                    }
                                    i++;
                                    
                                    
                            }
                           
                           
                           
                           
                    }
                    
                  printf ("\nDesea consultar otro libro s/n?: ");
                  scanf (" %[^\n]",&opc);
                  system("cls");
                  while ( (strcmp(opc,"s")!=0) && (strcmp(opc,"S")!=0) && (strcmp(opc,"n")!=0) && (strcmp(opc,"N")!=0) )//Validar la opción ingresada
                  {
               
                   printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
                   scanf(" %[^\n]",&opc);//Se pide de nuevo la opción
                   system("cls");
                  }
                  
                  if ( (strcmp(opc,"n")==0) || (strcmp(opc,"N")==0) )
                  {
                       
                       salir=true;
                  }
                    
                     
              }
              if ( strcmp(opcion,"2")==0 )
              {
                  printf ("Ingrese el nombre del autor a consultar: ");
                   scanf(" %[^\n]",&autor);
                   system("cls");
                   bool valid=false;
                   int cont;
                   while (valid==false)//Inicio de iteración para validar si el nombre del autor no contenga caracteres numéricos
                     {
                            cont=0;
                            i=0;//Esta variable contendrá la cantidad de caracteres numéricos que tenga el arreglo "autor"
                            for(int i=0; i<=strlen(autor); i++)//Se recorre casilla por casilla, el arreglo previamente mencionado. De haber una coincidencia en cada casilla, se autoincrementa la variable  entera "cont"
                            {
                                    if (autor[i]== '1'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '2'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '3'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '4'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '5'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '6'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '7'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '8'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '9'){
                                    
                                       cont ++;               
                                    }
                                    else if (autor[i]== '0'){
                                    
                                       cont ++;               
                                    }
                            }//Fin de la iteración del recorrido de casillas del arreglo "autor"
                            if (cont>0){//Si hay uno o más caracteres numéricos en el arreglo.....
                                        
                                     printf ("Error, el nombre del autor no lleva n\243meros. Ingrese nuevamente el nombre del autor.\n");//Mensaje de error
                                     printf ("\nIngrese el autor del nuevo libro: ");//Se pide nuevamente el autor
                                     scanf (" %[^\n]",&autor);//Se recibe y se guarda para ser nuevamente evaluada
                                     system("cls");
                            }
                            else//Si no tiene caracteres numéricos....
                            {
                            
                                valid=true;//Sale de la iteración 
                            }
                     }//fin de la iteración para validar el autor
                     for (int i=0;i<=strlen(autor);i++)
                      {
                      
                          autor[i]=toupper(autor[i]);
                      }
                      fpr=fopen("library.txt","r");
                    
                    if(!fpr)
                    {
                    
                          printf("\nNo se encontraron coincidencias. ");
                                    
                    }else
                    {
                    
                         coinc=0;
                         int j;
                         int i;
                         int k;
                         printf("\nListado de libros coincidentes con %s :",&autor);
                         while( (fgets(linea,200,fpr)!= NULL) ) 
                         {
                             i=0;
                             cont=0;   
                             while (i<=strlen(linea))
                             {
                                   
                                   if(linea[i]=='|')
                                   {
                            
                                    cont++;               
                                    }
                                    if (cont==4)//Quedé por aquí
                                    {
                                        
                                        i=i+9;
                                        j=0;
                                        k=0;
                                        while(linea[i+1]!='|')
                                        {
                                          
                                              //printf ("%c",linea[i]);
                                              if(linea[i]==autor[j])
                                              {
                                          
                                                k++;
                                                
                                                                
                                                } 
                                          i++;
                                          j++;            
                                          }
                                          //printf("%d",k);
                                          if (   (k==j) && (k==strlen(autor)  )  )
                                          {
                                            
                                               
                                                strcpy(lin,linea);
                                                coinc++;
                                                int cont2=0;
                                                int m=0;
                                               
                                                while (m<=strlen(lin))
                                                {
                            
                                                     if(lin[m]=='|')
                                                     {
                                    
                                                        cont2++;               
                                                      }
                                                      if (cont2==0)
                                                      {
                                                         m=16;
                                                         printf("\nCota del Libro: ");
                                                         while(lin[m+1]!='|')
                                                         {
                                                  
                                                            printf ("%c",lin[m]);
                                                            m++;
                                                              
                                                          }
                                                              
                                                       }
                                                       else if (cont2==2)
                                                       {
                                                
                                                          m=m+20;
                                                          /* j=0;
                                                          k=0;*/
                                                          printf("\nNombre del Libro: ");
                                                          while(lin[m+1]!='|')
                                                          {
                                                  
                                                             printf ("%c",lin[m]);
                                                             m++;
                                                              
                                                           }  
                                                        }
                                                        else if (cont2==6)
                                                        {
                                                
                                                            m=m+13;
                                                            printf("\nEditorial del Libro: ");
                                                            while(lin[m+1]!='|')
                                                            {
                                                  
                                                               printf ("%c",lin[m]);
                                                               m++;
                                                              
                                                             }  
                                    
                                                         }else if (cont2==8)
                                                         {
                                                
                                                             m=m+7;
                                                             printf("\nA%co del Libro: ",164);
                                                             while(m<=strlen(lin))
                                                             {
                                         
                                                  
                                                                printf ("%c",lin[m]);                      
                                                                m++;           
                                                             }
                                    
                                                          }
                                                          m++;
                                            
                                                   }
                                            
                                        }
                                        
                                    
                                  } 
                                  i++;     
                         }
                            
                                
                                
                         }
                         if (coinc==0)
                         {
                         
                               printf ("\nNo se encontraron coincidencias ");             
                         }
                  printf ("\nDesea consultar otro libro s/n?: ");
                  scanf (" %[^\n]",&opc);
                  system("cls");
                  while ( (strcmp(opc,"s")!=0) && (strcmp(opc,"S")!=0) && (strcmp(opc,"n")!=0) && (strcmp(opc,"N")!=0) )//Validar la opción ingresada
                  {
               
                   printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
                   scanf(" %[^\n]",&opc);//Se pide de nuevo la opción
                   system("cls");
                  }
                  
                  if ( (strcmp(opc,"n")==0) || (strcmp(opc,"N")==0) )
                  {
                       
                       salir=true;
                  } 
                   
              }
              
              
              
           }
           if ( strcmp(opcion,"3")==0 )
              {
                   //printf("hola");
                   salir=true;
              }
           
           }     
    }
