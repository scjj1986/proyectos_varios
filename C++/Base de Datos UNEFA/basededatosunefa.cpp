#include <stdio.h>
#include <conio.h>
#include <string>
#include <stdlib.h>
#include <iostream>
#include <time.h>
#include <ctype.h>
#include <iomanip>
#include <dos.h>
using namespace std; 
typedef struct _nodo { //Registro en donde se guardar� los datos de cada estudiante
   int cedula,ano_ingreso;
   char apellido[50],nombre[50],carrera[60];
   struct _nodo *siguiente;
} tipoNodo;

typedef tipoNodo *pNodo;
typedef tipoNodo *Lista;
FILE *fpw, *fpr; //Variables para la los procesos de lectura y escritura del archivo de texto
bool numerico (char cad[] ){ //funci�n que pasa por par�metro una cadena de caracteres, dicha subrutina verifica si una cadena de caracteres es num�rica o no
int cont=0;
for (int i=0; i<=strlen(cad); i++)//Se recorre caracter por caracter a trav�s de un "for"
{
                
   if(isdigit(cad[i])) //Si el caracter es num�rico....
   {
                      
       cont++; //...incrementa en uno el contador de caracteres num�ricos
   }
}

if (strlen(cad)!=cont) return false; //Si la cantidad de caracteres num�ricos es distinta a la cantidad total de caracteres de la cadena, la funci�n retorna "false"
    return true;  //..De lo contrario, retorna "true"
        
}

void Ingresar()//Procedimiento para ingresar un nuevo estudiante en el archivo
{
    pNodo nuevo;
    nuevo = (pNodo)malloc(sizeof(tipoNodo));//Se declara y se crea una nueva instancia del registro que contendra los datos del estudiante
    char cadena[50];//variable usada para la captura de datos ingresada por el usuario
    printf("\nIngrese la cedula: \n");
    scanf(" %[^\n]",&cadena);//Se captura la c�dula, para ser evaluada si es nu�rica o no
    while (!numerico(cadena))//Mientras no sea num�rica...
    {
          printf("Error. El dato debe ser numerico. Ingrese nuevamente el valor: \n");
          scanf(" %[^\n]",&cadena);  //se norifica el mensaje de error y se pide nuevamente dicho valor    
          
    }
    nuevo->cedula=atoi(cadena);//Una vez validada la c�dula, se convierte a entero y se gusrda en el registro.
    printf("\nApellido: \n");
    scanf(" %[^\n]",&nuevo->apellido);//Se pide el apellido y se guarda en el registro
    printf("\nNombre: \n");
    scanf(" %[^\n]",&nuevo->nombre);//Se pide el nombre y se guarda en el registro
    printf("\nCarrera: \n");
    scanf(" %[^\n]",&nuevo->carrera);//Se pide la carrera y se guarda en el registro
    printf("\nA�o deIngreso: \n");
    scanf(" %[^\n]",&cadena);//Se pide el a�o de ingreso. Dado que este tipo de dato tabi�n es entero, se le aplica la misma evaluaci�n realizada a la c�dula
    system("cls");
    while (!numerico(cadena))
    {
          printf("Error. El dato debe ser numercio. Ingrese nuevamente el valor: \n");
          scanf(" %[^\n]",&cadena);      
          
    }
    nuevo->ano_ingreso=atoi(cadena);
    fpw = fopen("UNEFA.txt", "a+t");//Una vez recopilados todos los datos, se procede a la apertura del archivo "UNEFA.txt", si no existe, se crea, de existir, se escriben los datos al final de dicho archivo
    fprintf (fpw, "Cedula: %d %s %s %s %s %s %s %s %d\n",nuevo->cedula,"|| Apellido:",nuevo->apellido,"|| Nombre:",nuevo->nombre,"|| Carrera:",nuevo->carrera,"|| A�o de Ingreso:",nuevo->ano_ingreso);//Se procede escribir...
    fclose (fpw);//Se cierra el archivo
     
}

bool existearchivo(){//funci�n booleana que verifica si el archivo de texto existe o no
  bool aux;
  fpr= fopen("UNEFA.txt", "r");
  if (fpr){
     aux=true;
  }else {
     aux=false;
  }
  fclose(fpr);
  return aux;
}

void mostrararchivo()//procedimiento que muestra el contenido del archivo de texto l�nea por l�nea
{

     char linea[200];//Cadena de caracteres que almac�nar� una l�nea del archivo de texto
     fpr= fopen("UNEFA.txt", "r");//se abre el archivo
     while (( fgets(linea,200,fpr)!= NULL ))//mientras queden l�neas por leer
     {
           printf("%s",linea);//se muestra la linea       
           
     }
     fclose(fpr); //Se cierra el archivo    
     
}

void Ordenar_Ced() //procedimiento que ordena las l�neas del archivo de texto por c�dula
{
     Lista lista = NULL;//variable que apunta al nodo inicial de la lista...
     pNodo nuevo,actual,actual2;//..variables para el recorrido de la lista
     char linea[200];//variable para leer cada l�nea del archivo de texto
     char aux[100]={' ','\0'};//variable que va extrayendo dato por dato para ser trasladado a cada nodo para proceder al proceso de ordenar
     int i,j;
     if (!existearchivo())//Si el archivo no existe...
     {
        printf("\nNo existen registros para ordenar en el archivo\n");                    
     }else{ //Si existe...
      
         fpr= fopen("UNEFA.txt", "r");
         while (( fgets(linea,200,fpr)!= NULL ))//Se abre el archivo y se eval�a l�nea por l�nea
         {
         
              i=8;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo = (pNodo)malloc(sizeof(tipoNodo)); //instancia del nuevo nodo en donde guardar� los datos del estudiante que contiene la l�nea actual
              nuevo->cedula=atoi(aux);//Aqu� se extrae la c�dula y se guarda el el nuevo nodo
              strcpy(aux,"");
              i+=14;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->apellido,aux);//Aqu� se extrae el apellido y se guarda el el nuevo nodo
              strcpy(aux,"");
              i+=12;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->nombre,aux);//Aqu� se extrae el nombre y se guarda en el nuevo nodo
              strcpy(aux,"");
              i+=13;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->carrera,aux);//Aqu� se extrae la carrera y se guarda el el nuevo nodo
              strcpy(aux,"");
              i+=20;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo->ano_ingreso=atoi(aux);//Aqu� se extrae el a�o de ingreso y se guarda el el nuevo nodo   
              if (!lista)//si la lista es nula...
              {
                 lista=nuevo;
                 nuevo->siguiente=NULL;//el nuevo nodo ser� el primero en la lista           
                         
              }else{//si hay nodo existente
                    
                   actual=lista;
                   while (actual->siguiente){//Nos vamos al final de la lista para la inserci�n del nuevo nodo
                         
                         actual=actual->siguiente;      
                         
                   }
                   actual->siguiente=nuevo;
                   nuevo->siguiente=NULL; //Se inserta el nodo al final
                          
              } 
              
         }
              // M�todo de ordenaci�n por burbuja
              /*Este m�todo consiste en que todos los elementos de menor valor, se van trasladando 
              a las primeras posiciones. Este proceso termina cuando ya todos los elementos de la lista est�n ordenados
              */
              int interruptor=1;//variable que gestiona los recorridos necesarios a la lista para la ordenaci�n..
              while (interruptor==1)//iteraci�n de los recorridos
              {
                    actual2=lista;//a la variable auxiliar, se le asigna lo que apunta el primer nodo de la lista para empezar el recorrido
                    interruptor=0;//asignaci�n por defecto de la variable "interruptor"
                    while (actual2->siguiente)//recorrido a la lista
                    {
                          if (actual2->cedula > actual2->siguiente->cedula)//si la cedula del nodo actual es mayor al del nodo siguiente...
                          {
                             
                             i = actual2->cedula;
                             actual2->cedula = actual2->siguiente->cedula;
                             actual2->siguiente->cedula = i;
                             i = actual2->ano_ingreso;
                             actual2->ano_ingreso = actual2->siguiente->ano_ingreso;
                             actual2->siguiente->ano_ingreso = i;
                             strcpy(aux,actual2->apellido);
                             strcpy(actual2->apellido,actual2->siguiente->apellido);
                             strcpy(actual2->siguiente->apellido,aux);
                             strcpy(aux,actual2->nombre);
                             strcpy(actual2->nombre,actual2->siguiente->nombre);
                             strcpy(actual2->siguiente->nombre,aux);
                             strcpy(aux,actual2->carrera);
                             strcpy(actual2->carrera,actual2->siguiente->carrera);
                             strcpy(actual2->siguiente->carrera,aux);
                             interruptor=1; //empieza el intercambio de valores y a interruptor se le asigna 1 para otra iteraci�n                         
                          }
                          actual2=actual2->siguiente; //siguiente nodo                             
                    }
                    /*es necesario acotar que esta iteraci�n culmina cuando interruptor es igual a 0, es decir, que todos los elementos est�n ordenados de menor a mayor*/             
              }
              /*
              Una vez ordenados todos los nodos, se procede a sobreescibir el archivo con el nuevo orden
              */
              fpw= fopen("UNEFA.txt", "w+");//Apertura del archivo para sobreescritura
              actual=lista;
              while (actual)//Se recorre la lista para la inserci�n de datos en el archivo
              {
                   fprintf (fpw, "Cedula: %d %s %s %s %s %s %s %s %d\n",actual->cedula,"|| Apellido:",actual->apellido,"|| Nombre:",actual->nombre,"|| Carrera:",actual->carrera,"|| A�o de Ingreso:",actual->ano_ingreso);//grabando datos en el archivo
                   actual=actual->siguiente; //siguiente nodo
              }
              fclose (fpw);//se cierra el archivo     
     
     }    
}


void Ordenar_Ape()//Similar al procedimiento Ordenar_Ced(), s�lo con la diferencia al comparar los valores en el m�todo burbuja que se comparan de este modo:"(strcmp(actual2->apellido,actual2->siguiente->apellido)>0)"
{
     Lista lista = NULL;
     pNodo nuevo,actual,actual2;
     char linea[200];
     char aux[100]={' ','\0'};
     int i,j;
     if (!existearchivo())
     {
        printf("\nNo existen registros para ordenar en el archivo\n");
                             
                          
     }else{
      
         fpr= fopen("UNEFA.txt", "r");
         while (( fgets(linea,200,fpr)!= NULL ))
         {
         
              i=8;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo = (pNodo)malloc(sizeof(tipoNodo));
              nuevo->cedula=atoi(aux);
              strcpy(aux,"");
              i+=14;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->apellido,aux);
              strcpy(aux,"");
              i+=12;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->nombre,aux);
              strcpy(aux,"");
              i+=13;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->carrera,aux);
              strcpy(aux,"");
              i+=20;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo->ano_ingreso=atoi(aux);  
              if (!lista)
              {
                 lista=nuevo;
                 nuevo->siguiente=NULL;           
                         
              }else{
                    
                   actual=lista;
                   while (actual->siguiente){
                         
                         actual=actual->siguiente;      
                         
                   }
                   actual->siguiente=nuevo;
                   nuevo->siguiente=NULL; 
                          
              }
              
         }
              int interruptor=1;
              while (interruptor==1)
              {
                    actual2=lista;
                    interruptor=0;
                    while (actual2->siguiente)
                    {
                          if (strcmp(actual2->apellido,actual2->siguiente->apellido)>0)
                          {
                             
                             i = actual2->cedula;
                             actual2->cedula = actual2->siguiente->cedula;
                             actual2->siguiente->cedula = i;
                             i = actual2->ano_ingreso;
                             actual2->ano_ingreso = actual2->siguiente->ano_ingreso;
                             actual2->siguiente->ano_ingreso = i;
                             strcpy(aux,actual2->apellido);
                             strcpy(actual2->apellido,actual2->siguiente->apellido);
                             strcpy(actual2->siguiente->apellido,aux);
                             strcpy(aux,actual2->nombre);
                             strcpy(actual2->nombre,actual2->siguiente->nombre);
                             strcpy(actual2->siguiente->nombre,aux);
                             strcpy(aux,actual2->carrera);
                             strcpy(actual2->carrera,actual2->siguiente->carrera);
                             strcpy(actual2->siguiente->carrera,aux);
                             interruptor=1;
                                                       
                          }
                          actual2=actual2->siguiente;                               
                    }             
              }
              fpw= fopen("UNEFA.txt", "w+");
              actual=lista;
              while (actual)
              {
                   fprintf (fpw, "Cedula: %d %s %s %s %s %s %s %s %d\n",actual->cedula,"|| Apellido:",actual->apellido,"|| Nombre:",actual->nombre,"|| Carrera:",actual->carrera,"|| A�o de Ingreso:",actual->ano_ingreso);
                   actual=actual->siguiente; 
              }
              fclose (fpw);     
     
     }    
}

void Ordenar_Nom()//Similar al procedimiento Ordenar_Ced(), s�lo con la diferencia al comparar los valores en el m�todo burbuja que se comparan de este modo:"(strcmp(actual2->nombre,actual2->siguiente->nombre)>0)"
{
     Lista lista = NULL;
     pNodo nuevo,actual,actual2;
     char linea[200];
     char aux[100]={' ','\0'};
     int i,j;
     if (!existearchivo())
     {
        printf("\nNo existen registros para ordenar en el archivo\n");                     
     }else{
      
         fpr= fopen("UNEFA.txt", "r");
         while (( fgets(linea,200,fpr)!= NULL ))
         {
         
              i=8;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo = (pNodo)malloc(sizeof(tipoNodo));
              nuevo->cedula=atoi(aux);
              strcpy(aux,"");
              i+=14;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->apellido,aux);
              strcpy(aux,"");
              i+=12;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->nombre,aux);
              strcpy(aux,"");
              i+=13;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->carrera,aux);
              strcpy(aux,"");
              i+=20;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo->ano_ingreso=atoi(aux);   
              if (!lista)
              {
                 lista=nuevo;
                 nuevo->siguiente=NULL;           
                         
              }else{
                    
                   actual=lista;
                   while (actual->siguiente){
                         
                         actual=actual->siguiente;      
                         
                   }
                   actual->siguiente=nuevo;
                   nuevo->siguiente=NULL; 
                          
              } 
              
         }
              int interruptor=1;
              while (interruptor==1)
              {
                    actual2=lista;
                    interruptor=0;
                    while (actual2->siguiente)
                    {
                          if (strcmp(actual2->nombre,actual2->siguiente->nombre)>0)
                          {
                             
                             i = actual2->cedula;
                             actual2->cedula = actual2->siguiente->cedula;
                             actual2->siguiente->cedula = i;
                             i = actual2->ano_ingreso;
                             actual2->ano_ingreso = actual2->siguiente->ano_ingreso;
                             actual2->siguiente->ano_ingreso = i;
                             strcpy(aux,actual2->apellido);
                             strcpy(actual2->apellido,actual2->siguiente->apellido);
                             strcpy(actual2->siguiente->apellido,aux);
                             strcpy(aux,actual2->nombre);
                             strcpy(actual2->nombre,actual2->siguiente->nombre);
                             strcpy(actual2->siguiente->nombre,aux);
                             strcpy(aux,actual2->carrera);
                             strcpy(actual2->carrera,actual2->siguiente->carrera);
                             strcpy(actual2->siguiente->carrera,aux);
                             interruptor=1;
                                                       
                          }
                          actual2=actual2->siguiente;                               
                    }             
              }
              fpw= fopen("UNEFA.txt", "w+");
              actual=lista;
              while (actual)
              {
                   fprintf (fpw, "Cedula: %d %s %s %s %s %s %s %s %d\n",actual->cedula,"|| Apellido:",actual->apellido,"|| Nombre:",actual->nombre,"|| Carrera:",actual->carrera,"|| A�o de Ingreso:",actual->ano_ingreso);
                   actual=actual->siguiente; 
              }
              fclose (fpw);     
     
     }    
}

void busq_ced()//procedimiento para realizar b�squeda binaria en el archivo
{
     char cadena[50];
     Lista lista= NULL;
     pNodo nuevo, actual;
     char linea[200];
     char aux[100]={' ','\0'};
     int i,j;
     printf("\n Ingrese la cedula a buscar: \n");
     scanf(" %[^\n]",&cadena); //ccomo trabajamos con datos num�ricos, se procede a evaluar el dato para saber si es num�rico o no    
     while (!numerico(cadena))
     {
          printf("Error. El dato debe ser numerico. Ingrese nuevamente el valor: \n");
          scanf(" %[^\n]",&cadena);      
          
     }
     int num=atoi(cadena);
     fpr= fopen("UNEFA.txt", "r");
         while (( fgets(linea,200,fpr)!= NULL ))//Se lee l�nea por l�nea para la extracci�n de datos
         {
         
              i=8;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo = (pNodo)malloc(sizeof(tipoNodo));
              nuevo->cedula=atoi(aux);
              strcpy(aux,"");
              i+=14;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->apellido,aux);
              strcpy(aux,"");
              i+=12;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->nombre,aux);
              strcpy(aux,"");
              i+=13;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->carrera,aux);
              strcpy(aux,"");
              i+=20;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo->ano_ingreso=atoi(aux);
              //una vez extra�dos los datos, se procede a guardar en la lista    
              if (!lista)
              {
                 lista=nuevo;
                 nuevo->siguiente=NULL;           
                         
              }else{
                    
                   actual=lista;
                   while (actual->siguiente){
                         
                         actual=actual->siguiente;      
                         
                   }
                   actual->siguiente=nuevo;
                   nuevo->siguiente=NULL; 
                          
              } 
              
         }
         int n=0;
         actual=lista;
         while (actual)//iteraci�n para determinar la cantidad de nodos de la lista
         {
         
               n++;
               actual=actual->siguiente;      
         }
         int inicio=0;
         int fin=n;
         int medio=(fin+inicio)/2; 
         pNodo Apuntadores[n];//arreglo de registros, se le asigna como dimiensi�n el n�mero de nodos de la lista
         actual=lista;
         for(i=0;i<n;++i){
         Apuntadores[i]=actual;// a cada posici�n se le asigna el nodo actual del recorrido, se usar� el arreglo apuntadores, para que sea m�s f�cil la b�suqeda binaria 
         actual=actual->siguiente;
         }
         bool salir=false;
         while(inicio < fin && medio != inicio && !salir){//iteraci�n que gestiona la b�squeda binaria, esta iteraci�n culmina cuando inicio sea igual que final o medio, o salir sea verdadero(en caso de encontrarse la coincidencia)

         if(num < Apuntadores[medio]->cedula){//si la c�dula ingresada por el usuario, es menor a la posici�n que apunta al medio de la b�suqeda en el arreglo
         fin=medio;//el valor que tiene medio pasa a ser fin en la b�squeda
         medio=(fin+inicio)/2;//f�rmula para determinar el medio
         }
         else if(num > Apuntadores[medio]->cedula){//si es mayor
         inicio=medio;//el valor que tiene medio pasa a ser inicio en la b�squeda
         medio=(fin+inicio)/2;
         }
         else{//si se consigui�
         
         salir=true;//Se muestra, y a salir se le asigna "false" para romper con el ciclo iterativo de la b�squeda
         }
         }
         medio=(inicio+fin)/2;
         if(Apuntadores[medio]->cedula != num){printf("El valor no se encuentra en la lista\n");
         }else{
               
             printf("\nRegistro coincidente: \n");
             printf ("Cedula: %d %s %s %s %s %s %s %s %d\n",Apuntadores[medio]->cedula,"|| Apellido:",Apuntadores[medio]->apellido,"|| Nombre:",Apuntadores[medio]->nombre,"|| Carrera:",Apuntadores[medio]->carrera,"|| A�o de Ingreso:",Apuntadores[medio]->ano_ingreso);   
         }//si no se consigui�, se manda un mensaje por pantalla
}


void busq_ape()//similar al procedimiento busq_ced(), con la diferencia que se pide el apellido y la funci�n para comparar los apellidos se realiza con strcmp()
{
     char cadena[50];
     Lista lista= NULL;
     pNodo nuevo, actual;
     char linea[200];
     char aux[100]={' ','\0'};
     int i,j;
     printf("\n Ingrese el apellido a buscar: \n");
     scanf(" %[^\n]",&cadena);     
     fpr= fopen("UNEFA.txt", "r");
         while (( fgets(linea,200,fpr)!= NULL ))
         {
         
              i=8;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo = (pNodo)malloc(sizeof(tipoNodo));
              nuevo->cedula=atoi(aux);
              strcpy(aux,"");
              i+=14;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->apellido,aux);
              strcpy(aux,"");
              i+=12;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->nombre,aux);
              strcpy(aux,"");
              i+=13;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->carrera,aux);
              strcpy(aux,"");
              i+=20;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo->ano_ingreso=atoi(aux);    
              if (!lista)
              {
                 lista=nuevo;
                 nuevo->siguiente=NULL;           
                         
              }else{
                    
                   actual=lista;
                   while (actual->siguiente){
                         
                         actual=actual->siguiente;      
                         
                   }
                   actual->siguiente=nuevo;
                   nuevo->siguiente=NULL; 
                          
              } 
              
         }
         int n=0;
         actual=lista;
         while (actual)
         {
         
               n++;
               actual=actual->siguiente;      
         }
         int inicio=0;
         int fin=n;
         int medio=(fin+inicio)/2;
         pNodo Apuntadores[n];
         actual=lista;
         for(i=0;i<n;++i){
         Apuntadores[i]=actual;
         actual=actual->siguiente;
         }
         bool salir=false;
         while(inicio < fin && medio != inicio && !salir){

         if (strcmp(cadena,Apuntadores[medio]->apellido)<0){
         fin=medio;
         medio=(fin+inicio)/2;
         }
         else if(strcmp(cadena,Apuntadores[medio]->apellido)>0){
         inicio=medio;
         medio=(fin+inicio)/2;
         }
         else{
        
         salir=true;
         }
         }
         medio=(inicio+fin)/2;
         if(strcmp(cadena,Apuntadores[medio]->apellido)!=0){printf("El valor no se encuentra en la lista\n");
         }else{
               
             printf("\nRegistro coincidente: \n");
             printf ("Cedula: %d %s %s %s %s %s %s %s %d\n",Apuntadores[medio]->cedula,"|| Apellido:",Apuntadores[medio]->apellido,"|| Nombre:",Apuntadores[medio]->nombre,"|| Carrera:",Apuntadores[medio]->carrera,"|| A�o de Ingreso:",Apuntadores[medio]->ano_ingreso);   
         }
}

void busq_nom()//similar al procedimiento busq_ced(), con la diferencia que se pide el nombre y la funci�n para comparar los nombres, se realiza con strcmp()
{
     char cadena[50];
     Lista lista= NULL;
     pNodo nuevo, actual;
     char linea[200];
     char aux[100]={' ','\0'};
     int i,j;
     printf("\n Ingrese el nombre a buscar: \n");
     scanf(" %[^\n]",&cadena);     
     fpr= fopen("UNEFA.txt", "r");
         while (( fgets(linea,200,fpr)!= NULL ))
         {
         
              i=8;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo = (pNodo)malloc(sizeof(tipoNodo));
              nuevo->cedula=atoi(aux);
              strcpy(aux,"");
              i+=14;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->apellido,aux);
              strcpy(aux,"");
              i+=12;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->nombre,aux);
              strcpy(aux,"");
              i+=13;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              aux[j]='\0';
              strcpy(nuevo->carrera,aux);
              strcpy(aux,"");
              i+=20;
              j=0;
              while (linea[i]!=' ')
              {
                  aux[j]=linea[i];
                  i++;
                  j++;       
                    
              }
              nuevo->ano_ingreso=atoi(aux);    
              if (!lista)
              {
                 lista=nuevo;
                 nuevo->siguiente=NULL;           
                         
              }else{
                    
                   actual=lista;
                   while (actual->siguiente){
                         
                         actual=actual->siguiente;      
                         
                   }
                   actual->siguiente=nuevo;
                   nuevo->siguiente=NULL; 
                          
              } 
              
         }
         int n=0;
         actual=lista;
         while (actual)
         {
         
               n++;
               actual=actual->siguiente;      
         }
         int inicio=0;
         int fin=n;
         int medio=(fin+inicio)/2;
         pNodo Apuntadores[n];
         actual=lista;
         for(i=0;i<n;++i){
         Apuntadores[i]=actual;
         actual=actual->siguiente;
         }
         bool salir=false;
         while(inicio < fin && medio != inicio && !salir){

         if (strcmp(cadena,Apuntadores[medio]->nombre)<0){
         fin=medio;
         medio=(fin+inicio)/2;
         }
         else if(strcmp(cadena,Apuntadores[medio]->nombre)>0){
         inicio=medio;
         medio=(fin+inicio)/2;
         }
         else{
         salir=true;
         }
         }
         medio=(inicio+fin)/2;
         if(strcmp(cadena,Apuntadores[medio]->nombre)!=0){printf("El valor no se encuentra en la lista\n");
         }else{
               
             printf("\nRegistro coincidente: \n");
             printf ("Cedula: %d %s %s %s %s %s %s %s %d\n",Apuntadores[medio]->cedula,"|| Apellido:",Apuntadores[medio]->apellido,"|| Nombre:",Apuntadores[medio]->nombre,"|| Carrera:",Apuntadores[medio]->carrera,"|| A�o de Ingreso:",Apuntadores[medio]->ano_ingreso);   
         }
}
int main ()
{
    char opcion[50];
    int opc;
    bool salir;
    salir=false;
    printf ("Bienvenido a la aplicaci\242n que alamacena los datos de los estudiantes de la UNEFA:\n");
    while(!salir){
    printf ("\nIngrese una de las siguientes opciones:\n");
    printf ("\n");
    printf ("Presione '1' si desea ingresar un nuevo estudiante.\n");
    printf ("Presione '2' si desea ordenar los registros por cedula.\n");
    printf ("Presione '3' si desea ordenar los registros por apellido.\n");
    printf ("Presione '4' si desea ordenar los registros por nombre.\n");
    printf ("Presione '5' si desea buscar un registro por cedula.\n");
    printf ("Presione '6' si desea buscar un registro por apellido.\n");
    printf ("Presione '7' si desea buscar un registro por nombre.\n");//opciones
    scanf(" %[^\n]",&opcion);
    while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) && (strcmp(opcion,"6")!=0) && (strcmp(opcion,"7")!=0) )//Validar la opci�n ingresada
    {//validando la opcion ingresada
   
     printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
     scanf(" %[^\n]",&opcion);
     system("cls");
    }
    opc= atoi (opcion);//la opci�n num�rica se transforma a entero
    switch (opc)
    {
    
           case 1: Ingresar(); 
           break;
          case 2: Ordenar_Ced();
                  printf("\nY asi queda nuestra base de datos ordenada por cedula:\n");
                  mostrararchivo();
           break;
           case 3: Ordenar_Ape();
                   printf("\nY asi queda nuestra base de datos ordenada por apellido:\n");
                   mostrararchivo();
           break;
           case 4: Ordenar_Nom();
                   printf("\nY asi queda nuestra base de datos ordenada por nombre:\n");
                   mostrararchivo();
           break;
           case 5: printf("\n Seguidamente se mostrara la lista ordenada por cedula: \n");
                   Ordenar_Ced(); 
                   mostrararchivo();
                   busq_ced();
           break;
           case 6: printf("\n Seguidamente se mostrara la lista ordenada por apellido: \n");
                   Ordenar_Ape(); 
                   mostrararchivo();
                   busq_ape();
           break;
           case 7: printf("\n Seguidamente se mostrara la lista ordenada por nombre: \n");
                   Ordenar_Nom(); 
                   mostrararchivo();
                   busq_nom();
           break;  
    }
    printf ("\nDesea salir de la aplicaci\242n s/n?: ");
    scanf (" %[^\n]",&opcion);
    system("cls");
    while ( (strcmp(opcion,"s")!=0) && (strcmp(opcion,"S")!=0) && (strcmp(opcion,"n")!=0) && (strcmp(opcion,"N")!=0) )//Validar la opci�n ingresada
    {
   
     printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");
     scanf(" %[^\n]",&opcion);
     system("cls");
    }
      
    if ( (strcmp(opcion,"s")==0) || (strcmp(opcion,"S")==0) )
    {
           
        salir=true;
    }
    }
    return 1;    
}
