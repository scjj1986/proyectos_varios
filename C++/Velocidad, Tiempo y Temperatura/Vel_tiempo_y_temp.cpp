#include <stdio.h>
#include <math.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>
#include <ctype.h>
#include <iomanip>
#include <dos.h>

double velocid[9][9],tiempo[11],dia_year[2],sem_year[2];

void llenar_tabla_vel(){
     
     velocid[0][0]=1;velocid[0][1]=0.000278;velocid[0][2]=1000;velocid[0][3]=16.666667;velocid[0][4]=0.277778;velocid[0][5]=1666.666667;velocid[0][6]=27.777778;velocid[0][7]=0.000816;velocid[0][8]=0.621426;
     velocid[1][0]=3600;velocid[1][1]=1;velocid[1][2]=3600000;velocid[1][3]=60000;velocid[1][4]=1000;velocid[1][5]=6000000;velocid[1][6]=100000;velocid[1][7]=2.938641;velocid[1][8]=3600*0.621426;
     velocid[2][0]=0.001;velocid[2][1]=1/3600000;velocid[2][2]=1;velocid[2][3]=0.016667;velocid[2][4]=0.000278;velocid[2][5]=1.666667;velocid[2][6]=0.027778;velocid[2][7]=0.000001;velocid[2][8]=0.000621426;
     velocid[3][0]=0.06;
     velocid[3][1]=0.000017;
     velocid[3][2]=60;
     velocid[3][3]=1;
     velocid[3][4]=0.016667;
     velocid[3][5]=100;velocid[3][6]=1.666667;velocid[3][7]=0.000049;velocid[3][8]=0.040197;
     velocid[4][0]=3.6;velocid[4][1]=0.001;velocid[4][2]=3600;velocid[4][3]=60;velocid[4][4]=1;velocid[4][5]=6000;velocid[4][6]=100;velocid[4][7]=0.002939;velocid[4][8]=3.6*0.621426;
     velocid[5][0]=0.0006;velocid[5][1]=1/6000000;velocid[5][2]=0.6;velocid[5][3]=0.01;velocid[5][4]=0.000167;velocid[5][5]=1;velocid[5][6]=0.016667;velocid[5][7]=340.2933/6000;velocid[5][8]=0.000414;
     velocid[6][0]=0.036;velocid[6][1]=0.00001;velocid[6][2]=36;velocid[6][3]=0.6;velocid[6][4]=0.01;velocid[6][5]=60;velocid[6][6]=1;velocid[6][7]=0.000029;velocid[6][8]=0.025438;
     velocid[7][0]=1225.05588;velocid[7][1]=0.340293;velocid[7][2]=1225055.88;velocid[7][3]=20417.598;velocid[7][4]=340.2933;velocid[7][5]=2041759.8;velocid[7][6]=34029.33 ;velocid[7][7]=1;velocid[7][8]=661.477257;
     velocid[8][0]=1.6092;
     velocid[8][1]=0.000514;
     velocid[8][2]=1609.2;
     velocid[8][3]=30.866667;
     velocid[8][4]=0.514444;
     velocid[8][5]=3086.666667;
     velocid[8][6]=51.444444;
     velocid[8][7]=0.001512;
     velocid[8][8]=1;
         
}

void llenar_tablas_tiempo(){
     tiempo[0]=60;
     tiempo[1]=60;
     tiempo[2]=24;
     tiempo[3]=7;
     tiempo[4]=4.28571428;
     tiempo[5]=12.000000;
     tiempo[6]=10;
     tiempo[7]=2;
     tiempo[8]=5;
     tiempo[9]=10;
     tiempo[10]=1;
     dia_year[0]=365;
     dia_year[1]=1;
     sem_year[0]=52;
     sem_year[1]=1;
     
     
}

bool numerico (char cad[] ){ //metodo para verificar si una cadena de caracteres es numerica
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

void velocidad(){
     char opcion[20],opcion2[20],valor[15];
     int opc,opc2;
     double val,res;
     llenar_tabla_vel();
     printf ("\n Opciones para el ingreso de datos:\n");
     printf("1) En Km/h.\n");
     printf("2) En Km/seg.\n");
     printf("3) En m/h.\n");
     printf("4) En m/nim.\n");
     printf("5) En m/seg.\n");
     printf("6) En cm/min.\n");
     printf("7) En cm/seg.\n");
     printf("8) En mach.\n");
     printf("9) En mill/h.\n");
     gets (opcion);
     system("cls");
     while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) && (strcmp(opcion,"6")!=0) && (strcmp(opcion,"7")!=0) && (strcmp(opcion,"8")!=0) && (strcmp(opcion,"9")!=0))//Validar la opción ingresada
     {
   
           printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
           gets (opcion);//Se recibe de nuevo la opción
           system("cls");
      }
      opc= atoi (opcion);
      printf("A continuacion, ingrese el valor: \n");
      gets(valor);
      while (!numerico(valor))
      {
          printf("El dato debe ser numerico, ingrese nuevamente el valor: \n");
          gets(valor);  
      }
      val = atof(valor);
      printf ("\n Ahora, ingrese una de las opciones en que desea la conversion:\n");
     printf("1) En Km/h.\n");
     printf("2) En Km/seg.\n");
     printf("3) En m/h.\n");
     printf("4) En m/nim.\n");
     printf("5) En m/seg.\n");
     printf("6) En cm/min.\n");
     printf("7) En cm/seg.\n");
     printf("8) En mach.\n");
     printf("9) En mill/h.\n");
     gets (opcion2);
     system("cls");
     while ( (strcmp(opcion2,"1")!=0) && (strcmp(opcion2,"2")!=0) && (strcmp(opcion2,"3")!=0) && (strcmp(opcion2,"4")!=0) && (strcmp(opcion2,"4")!=0) && (strcmp(opcion2,"5")!=0) && (strcmp(opcion2,"6")!=0) && (strcmp(opcion2,"7")!=0) && (strcmp(opcion2,"8")!=0) && (strcmp(opcion2,"9")!=0))//Validar la opción ingresada
     {
   
           printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
           gets (opcion2);//Se recibe de nuevo la opción
           system("cls");
      }
      opc2= atoi (opcion2);
      opc--;opc2--;
      res=val*velocid[opc][opc2];
      printf("\n El resultado de la conversion es: %f",res);
     
     
}

void temperatura(){
     
     char opcion[20],valor[15];
     double val,res;
     printf ("\n Opciones para la conversion:\n");
     printf("1) De C. a F.\n");
     printf("2) De C. a K.\n");
     printf("3) De F. a C.\n");
     printf("4) De F. a K.\n");
     printf("5) De K. a C.\n");
     printf("6) De K. a F.\n");
     gets (opcion);
     system("cls");
     while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) && (strcmp(opcion,"6")!=0))//Validar la opción ingresada
     {
   
           printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
           gets (opcion);//Se recibe de nuevo la opción
           system("cls");
      }
      printf("A continuacion, ingrese el valor: \n");
      gets(valor);
      while (!numerico(valor))
      {
          printf("El dato debe ser numerico, ingrese nuevamente el valor: \n");
          gets(valor);  
      }
      val = atof(valor);
      if (strcmp(opcion,"1")==0){
            
            res=(val*1.8)+32;
            printf("\n El resultado de la conversion es: %f F.",res);
            
      }else if (strcmp(opcion,"2")==0){
            
            res=val+273.14;
            printf("\n El resultado de la conversion es: %f K.",res);     
            
      }
      else if(strcmp(opcion,"3")==0){
           
         res=(val-32)/1.8;
         printf("\n El resultado de la conversion es: %f C.",res);  
      }
      else if (strcmp(opcion,"4")==0){
           
         res=(val+459.67)/1.8;
         printf("\n El resultado de la conversion es: %f K.",res);       
           
      }
      else if (strcmp(opcion,"5")==0){
           
      
           res=val-273.14;
           printf("\n El resultado de la conversion es: %f C.",res);     
      }
      else{
           
          res=(val*1.8)-459.67;
          printf("\n El resultado de la conversion es: %f F.",res); 
      }
        
}

void time(){
     
     char opcion[20],opcion2[20],valor[15];
     int opc,opc2;
     double val,res;
     llenar_tablas_tiempo();
     printf ("\n Opciones para el ingreso de datos:\n");
     printf("1) En seg.\n");
     printf("2) En min.\n");
     printf("3) En hr.\n");
     printf("4) En dias.\n");
     printf("5) En semanas.\n");
     printf("6) En meses.\n");
     printf("7) En años.\n");
     printf("8) En decadas.\n");
     printf("9) En veintena.\n");
     printf("10) En siglo.\n");
     printf("11) En milenio.\n");
     gets (opcion);
     system("cls");
     while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"4")!=0) && (strcmp(opcion,"5")!=0) && (strcmp(opcion,"6")!=0) && (strcmp(opcion,"7")!=0) && (strcmp(opcion,"8")!=0) && (strcmp(opcion,"9")!=0) && (strcmp(opcion,"10")!=0) && (strcmp(opcion,"11")!=0))//Validar la opción ingresada
     {
   
           printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
           gets (opcion);//Se recibe de nuevo la opción
           system("cls");
      }
      opc= atoi (opcion);
      printf("A continuacion, ingrese el valor: \n");
      gets(valor);
      while (!numerico(valor))
      {
          printf("El dato debe ser numerico, ingrese nuevamente el valor: \n");
          gets(valor);  
      }
      val = atof(valor);
      printf ("\n Ahora, ingrese una de las opciones en que desea la conversion:\n");
     printf("1) En seg.\n");
     printf("2) En min.\n");
     printf("3) En hr.\n");
     printf("4) En dias.\n");
     printf("5) En semanas.\n");
     printf("6) En meses.\n");
     printf("7) En años.\n");
     printf("8) En decadas.\n");
     printf("9) En veintena.\n");
     printf("10) En siglo.\n");
     printf("11) En milenio.\n");
     gets (opcion2);
     system("cls");
     while ( (strcmp(opcion2,"1")!=0) && (strcmp(opcion2,"2")!=0) && (strcmp(opcion2,"3")!=0) && (strcmp(opcion2,"4")!=0) && (strcmp(opcion2,"4")!=0) && (strcmp(opcion2,"5")!=0) && (strcmp(opcion2,"6")!=0) && (strcmp(opcion2,"7")!=0) && (strcmp(opcion2,"8")!=0) && (strcmp(opcion2,"9")!=0) && (strcmp(opcion2,"10")!=0) && (strcmp(opcion2,"11")!=0))//Validar la opción ingresada
     {
   
           printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
           gets (opcion2);//Se recibe de nuevo la opción
           system("cls");
      }
      opc2= atoi (opcion2);
      opc--;opc2--;
      int i;
      res=1;
      if (opc>opc2){
                    
           i=opc;
           while (i>opc2){
                 
                if ((i==6) && (opc2==4)){
                           
                    res=res* (val*52);
                    i=3;
                              
                }
                else if ((i==6) && (opc2<=3)){
                     
                     res=res*(val*365);
                     i=3;
                         
                     
                }
                else{
                     
                     i--;
                     res=res*(val*tiempo[i]);    
                } 
                 
           }              
                    
      }
      else if(opc<opc2){
           i=opc;
           res=val;
           while (i<opc2){
                 
                if ((i==4) && (opc2==6)){
                           
                    res=res/52;
                    i=6;
                              
                }
                else if ((i==3) && (opc2>=6)){
                     
                     res=res/365;
                     i=6;
                         
                     
                }
                else{
                     
                     res=res/tiempo[i]; 
                     i++;   
                } 
                 
           }
           
           
      }
      
      printf("\n El resultado de la conversion es: %f",res);
       
}

int main(){
    
     bool salir;
     salir=false;
     char opcion[20];
     int opc;
     printf("\nBienvenidos a la aplicacion Velocidad-Temperatura-Tiempo\n");
     while (!salir){
     
           
           printf("\nMenu de Opciones:\n");
           printf("1) Velocidad.\n");
           printf("2) Tiempo.\n");
           printf("3) Temperatura.\n");
           gets (opcion);
           system("cls");
           while ( (strcmp(opcion,"1")!=0) && (strcmp(opcion,"2")!=0) && (strcmp(opcion,"3")!=0) )//Validar la opción ingresada
           {
   
                 printf ("Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n");//Mensaje de error
                 gets (opcion);//Se recibe de nuevo la opción
                 system("cls");
           }
           opc= atoi (opcion);
           switch (opc)
           {
    
                  case 1: velocidad(); 
                  break;
                  case 2: time();
                  break;
                  case 3: temperatura();
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
