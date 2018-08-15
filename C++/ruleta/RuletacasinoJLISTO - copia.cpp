#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>
#include <time.h>
#include <ctype.h>
#include <fstream>
#include <iomanip>
#include <dos.h>
#include <windows.h>
using namespace std;
 
class nodo_rul {//Clase que contendra cada nodo de la ruleta
   public:
   int num;
   char col[10];
   nodo_rul *sig;
   nodo_rul()
   {
       num = 0;
       strcpy(col," ");
       sig = NULL;
    }
   
};

typedef nodo_rul *pnodo_rul;

class nodo_apu{//Clase que contendra cada nodo de la apuesta
      
      public: 
      char apu[150];//cadena de caracteres que almacena la apuesta
      int monto;//monto de la apuesta
      int mon_gan;//monto ganado
      char tipo[30];//tipo de apuesta
      bool ganado;//atributo booleano que verifica si gano la apuesta
      nodo_apu *sig;
      int nr_apu;
      nodo_apu()
      {
           strcpy(apu," ");
           monto=0;
           mon_gan=0;
           ganado=false;
           strcpy(tipo," ");
           sig=NULL;
           nr_apu=0;
                  
      }
      
      friend class nodo_res; 
      
            
};

class nodo_res{//Clase que contendra cada mano que se juegue
   public:
   int num;//Numero del resultado aleatorio
   char col[10];//color del resultado aleatorio
   nodo_res *sig;
   nodo_apu *punta_ap;//Puntero que contendra la lista de las apuestas que se realizan en esta mano
   int tot_apos;//Monto total apostado en esta mano
   int tot_gan;//Monto total ganado en las apuestas en esta mano
   int tot_nr_apos;//Numeros apostados en esta mano
   int nr_apu;//Cantidad de apuestas en esta mano
   int nr_acierts;//Cantidad de apuestas acertadas en esta mano
   nodo_res()
   {
       num = 0;
       strcpy(col," ");
       sig = NULL;
       punta_ap = NULL;
       tot_apos=0;
       tot_gan=0;
       tot_nr_apos=0;
       nr_apu=0;
       nr_acierts=0;
    }   
      
    
};

typedef nodo_res *pnodo_res;


class lista_ap//Lista principal
{

   public:
   pnodo_rul primero_rul;//Primer nodo de la lista circular ruleta
   pnodo_rul ultimo_rul;//Ultimo nodo de la lista circular ruleta
   pnodo_res punta_res;//Primer nodo de la lista de las manos realizadas 
   int monto_ini;//Monto inicial con que empieza el jugador
   int monto_rec;//Monto total en recargas (la recarga se da cuando el apostador no tiene dinero suficiente para realizar apuestas, entonces puede agregar m�s dinero a su monto actual para que pueda jugar)
   int monto;//monto actual del apostador
   int manos_gan;//Cantidad de rondas ganadas
   int tot_man;//Total de rondas jugadas
   int recargas;//Numero de recargas
   int tot_apos;//Monto total apostado en todas las manos
   int tot_gan;//Total ganado en apuestas en etodas las manos
   lista_ap()
   {

         primero_rul= NULL;
         ultimo_rul=NULL;
         punta_res=NULL;
         monto=0;
         monto_ini=0;
         monto_rec=0;
         recargas=0;
         tot_man=0;
         manos_gan=0;
         tot_apos=0;
         tot_gan=0;           
   }  
   void llenar_rul()
   { //Metodo para llenar la ruleta
       pnodo_rul nuevo;
       int num;
       for(int i=0; i<37; i++ )//"para" agregar cada nodo a la ruleta
       {
              nuevo= new nodo_rul ();
              /*Para asignar un color a cada nodo se basa en regla sig:
              
                     *El numero 0 es verde.
                     
                     *Los n�meros de color negro son aquellos que la suma de sus d�gitos es par.
                     Ej: el 11 es negro porque 1+1=2. La excepcion es el numero 19.
                     
                     *Los n�meros de color rojo son aquellos que la suma de sus d�gitos es impar.
                     Ej: el 12 es rojo porque 1+2=3. La excepcion es el numero 29.       
              */
              if (i==0)
              {
              
                 strcpy(nuevo->col,"Verde");      
              }
              else if(i==19)
              {
                 strcpy(nuevo->col,"Rojo");     
              }
              else if ((i==10) || (i==29) || (i==28))
              {
                 strcpy(nuevo->col,"Negro");     
              }
              else
              {
                  num=i;
                  while (num>9)
                  {
                  
                      num=num-9;      
                  }
                  num=num % 2;
                  if (num==0)
                  {
                      strcpy(nuevo->col,"Negro");          
                  }
                  else
                  {
                     strcpy(nuevo->col,"Rojo"); 
                  } 
              }
              nuevo->num=i;
              if (!primero_rul)
              {
              
                 nuevo->sig=nuevo;
                 primero_rul=nuevo;             
              }
              else
              {
              
                  nuevo->sig=primero_rul;
                  ultimo_rul->sig=nuevo;   
              }
              ultimo_rul=nuevo;
                      
       }
       
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

      void primer_saldo ()
      {//Metodo usado cuando el apostador juega su primera partida
           char mon_cad[3];
           int mon;
           system("cls");
           //system("color 74");
           system("color 20");
{
HANDLE hConsoleOutput;
COORD coord;
hConsoleOutput = GetStdHandle (STD_OUTPUT_HANDLE);

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 11; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("3");


SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 11; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("3");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 11; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("3");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 2;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 49; coord.Y = 2;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 49; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 49; coord.Y = 4;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 49; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 49; coord.Y = 6;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 6;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("������������������������������������������ͼ");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 4;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 6; coord.Y = 0;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 7; coord.Y = 0;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�����������������������������������������ͻ");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 49; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");


SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),46);
coord.X = 7; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("0");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 11; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("2");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 11; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("1");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 13; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("6");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 13; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("5");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 13; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("4");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 15; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("9");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 15; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("8");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 15; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("7");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 17; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("12");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 17; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("11");

coord.X = 17; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("10");

coord.X = 20; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("15");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 20; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("14");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 20; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("13");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 23; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("18");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 23; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("17");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 23; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("16");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 26; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("21");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 26; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("20");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 26; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("19");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 29; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("24");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 29; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("23");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 29; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("22");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 32; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("27");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 32; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("26");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 32; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("25");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 35; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("30");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 35; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("29");


coord.X = 35; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("28");


coord.X = 38; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("33");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 38; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("32");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 38; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("31");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 41; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("36");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),32);
coord.X = 41; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("35");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),36);
coord.X = 41; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("34");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 45; coord.Y = 1;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("3rd");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 45; coord.Y = 3;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("2nd");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 45; coord.Y = 5;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("1st");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 7; coord.Y = 8;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("����������������������������������������ͻ");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 7; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 9; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("marque");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 19; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("|");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 18; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("PAR");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 23; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("|");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),68);
coord.X = 26; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("I");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 29; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("|");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),0);
coord.X = 31; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("I");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 34; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("|");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 36; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("IMPAR |");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 43; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf(" PASE");

SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 48; coord.Y = 9;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("�");
SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),39);
coord.X = 7; coord.Y = 10;
SetConsoleCursorPosition (hConsoleOutput, coord);
printf("����������������������������������������ͼ");

printf("\n");

//system("PAUSE");
}
           SetConsoleTextAttribute (GetStdHandle (STD_OUTPUT_HANDLE),46);
           printf("\n Ingrese el monto incial del apostador (Minimo 10 Bs. y Maximo 1000 Bs.): ");
           gets (mon_cad);//solicitar el monto
           bool valid=false;
           while(!valid){//estrucura iteritativa para validar que el  monto inicial ingresado sea numerico y que ocsile entre entre 10 y 1000
           while (!numerico(mon_cad))
           {
               printf("\nEste valor no es un numero. Ingrese nuevamente el monto");
               gets (mon_cad);  
           } 
           mon= atoi (mon_cad);
           if ((mon+monto<10) || (mon+monto>1000))
           {
                    
              printf("\n Valor fuera de rango, ingrese nuevamente el monto");
              gets (mon_cad);          
           }
           else
           {
                    
              valid=true; 
           }}
           monto=mon;
           monto_ini=monto;    
           
      }
      void agregar_ap(lista_ap *Lap)
      {//Metodo para jugar a la ruleta y para consultar las estadisticas de las manos jugadas
      
           bool salir=false;
           char opci[2];
           int opcion=0;
           char num[2];
           char num2[2];
           char temp[2];
           int cont;
           char num3[3];
           char chr[2];
           strcpy(num," ");
           strcpy(num2," ");
           strcpy(num3," ");
           char mon_cad[3];
           int mon;
           int nr,x,y,nr2;
           bool valid,encontrado,salir_juego,salir_apu,gan;
           int aleat;
           char entrada[2];
           pnodo_rul aux_rul;//auxiliar para recorrer la ruleta
           nodo_res *nuevo_res;//nuevo nodo para resultado
           nodo_apu *nuevo_ap;//nuevo nodo para la apuesta
           nodo_apu *aux_apu;
           nodo_res *aux_res;
           salir_juego=false;
           char opc2[2];
           char opc3[2];
           char opc4[2];
           while (!salir_juego){
                       
               printf("\nIngrese la opcion 'A' para jugar una partida o 'B' para ver las estadisticas: ");
               gets (entrada);
               while ( (strcmp(entrada,"a")!=0) && (strcmp(entrada,"b")!=0) && (strcmp(entrada,"A")!=0) && (strcmp(entrada,"B")!=0) )
               {
                   
                   printf ("\nError al leer el dato de entrada. Ingrese la opcion correcta: ");
                   gets(entrada);
               }
               if ( (strcmp(entrada,"a")==0) || (strcmp(entrada,"A")==0) ) //Si el usuario eligio jugar
               {
                       if (!punta_res){//Si la lista de resultado es nula (no ha jugado manos)
                          Lap->primer_saldo();//Se invoca el metodo primer_saldo
                       }
                       else if(monto<10) {//Si su monto no es suficiente....
                           printf("\n Monto restante: %d Bs. Como su monto restante, no es suficiente para realizar apuestas, ingrese el monto a recargar del apostador (Minimo 10 Bs. y Maximo 1000 Bs.): ",monto);
                           gets (mon_cad);//solicitar el monto
                           valid=false;
                           while(!valid){//estrucura iteritativa para validar que el  monto inicial ingresado sea numerico y que ocsile entre entre 10 
                               while (!numerico(mon_cad))
                               {
                                   printf("\nEste valor no es un numero. Ingrese nuevamente el monto: ");
                                   gets (mon_cad);  
                               } 
                               mon= atoi (mon_cad);
                               if ((mon+monto<10) || (mon+monto>1000))
                               {
                                        
                                  printf("\n Valor fuera de rango, ingrese nuevamente el monto: ");
                                  gets (mon_cad);          
                               }
                               else
                               {
                                        
                                  valid=true; 
                               }
                           }
                           Lap->monto=Lap->monto+mon;//Se le suma el monto de recarga al monto actual
                           Lap->recargas++;//Se autoincrementa la recarga
                           Lap->monto_rec=Lap->monto_rec+mon;//Se le suma tambi�n al monto en recargas
                       }               
                       
                           srand(time(NULL));
                           aleat= rand() % 37;//numero aleatorio
                           salir_apu=false;
                           printf("\n Monto actual del apostador: %d Bs",monto);//Se le muestra al apostador su monto actual
                           nuevo_res=new nodo_res();//instancia del nuevo nodo que contendr� la nueva ronda
                           gan=false;
                           while (!salir_apu){
                                 if((Lap->monto>=10) && (nuevo_res->tot_nr_apos<18)){
                                 printf("\n Cantidad maxima de numeros para apostar: 18.");//Se le indica al usuario que la cantidad de numeros que puede apostar es 18 (medio tapete)
                                 printf("\n Cantidad de numeros disponibles para apostar: %d.\n",18-nuevo_res->tot_nr_apos);//Por cada apuesta que se  vaya a realizar, se mostrara la cantidad de numeros disponibles que tiene para apostar
                                 printf("\n ELIJA UN TIPO DE APUESTA:\n");//Se muestra el abanico de opciones para que el usuario elija el tipo de apuesta
                                 printf("\n 1.- Apuesta sencilla \n");
                                 printf(" 2.- Apuesta de dos numeros \n");
                                 printf(" 3.- Apuesta de tres numeros \n");
                                 printf(" 4.- Cuadrado \n");
                                 printf(" 5.- Sexteto \n");
                                 printf(" 6.- Docena \n");
                                 printf(" 7.- Columna \n");
                                 printf(" 8.- COLOR: Rojo y Negro \n");
                                 printf(" 9.- Par o Impar \n");
                                 printf(" 10.-Numero bajo y numero alto\n");
                                 printf("\n Opcion:");
                                 gets(opci);
                                 while ( (strcmp(opci,"1")!=0) && (strcmp(opci,"2")!=0) && (strcmp(opci,"3")!=0) && (strcmp(opci,"4")!=0) && (strcmp(opci,"5")!=0) && (strcmp(opci,"6")!=0) && (strcmp(opci,"7")!=0) && (strcmp(opci,"8")!=0) && (strcmp(opci,"9")!=0) && (strcmp(opci,"10")!=0))
                                {
                               
                                 printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
                                 gets(opci);
                                }//para validar la opcion
                                system("cls");
                                opcion= atoi (opci);
                                if (opcion==1)//apuesta sencilla
                                {
                                    
                                    nuevo_ap= new nodo_apu();//instancia del nuevo nodo de la apuesta
                                    printf("\n Costo de la apuesta: 10 Bs.");
                                    printf("\n Premio: 370 Bs.");
                                    printf("\n Ingrese el numero a apostar: ");
                                    gets(num);
                                    system("cls");
                                    valid=false;
                                    while(!valid){//validar de que numero a apostar sea entero y que oscile entre 1 y 36
                                    while (!numerico(num))
                                    {
                                        printf("\n Este valor no es un numero. Ingrese nuevamente el primer numero a apostar: ");
                                        gets (num);  
                                    } 
                                    nr= atoi (num);
                                    if ((nr==0) || (nr>36))
                                    {
                                    
                                       printf("\n Valor fuera de rango, ingrese nuevamente el valor: ");
                                       gets (num);          
                                    }
                                    else
                                    {
                                    
                                       valid=true; 
                                    }}
                                    Lap->monto=Lap->monto-10;// se descuenta el valor de la apuesta
                                    strcpy (nuevo_ap->tipo,"Simple");//Se guarda en el nuevo nodo de la apuesta, el tipo
                                    nuevo_ap->nr_apu=1;
                                    nuevo_res->tot_nr_apos++;
                                    strcpy(nuevo_ap->apu,num);//se guarda el valor apostado en el nuevo nodo
                                    nuevo_ap->monto=10;//se coloca el valor de la apuesta al nuevo nodo
                                    nr=atoi(num);
                                    nuevo_res->tot_apos=nuevo_res->tot_apos+10;
                                    if (nr==aleat)//Si el nuemero apostado coincide con el aleatorio
                                    {
                                         
                                         
                                         nuevo_ap->ganado=true;
                                         nuevo_ap->mon_gan=370;
                                         nuevo_res->tot_gan=nuevo_res->tot_gan+370;
                                                          
                                    }
                                    else//si no
                                    {
                                         
                                         
                                         nuevo_ap->ganado=false;
                                    }
                                    if (nuevo_res->punta_ap)
                                    {
                                    
                                        nuevo_ap->sig=nuevo_res->punta_ap;          
                                    }
                                    nuevo_res->punta_ap=nuevo_ap;
                                    
                                system("cls");              
                                }//si eligio opcion simple
                                
                                else if (opcion==2)//si eligio apostar dos numeros
                                {
                                    if ((Lap->monto>=20) && (nuevo_res->tot_nr_apos+2<=18)){
                                    nuevo_ap= new nodo_apu();//instancia de la apuesta
                                    printf("\n Costo de la apuesta: 20 Bs.");
                                    printf("\n Premio: 360 Bs.");
                                    printf("\n Ingrese el primer numero a apostar: ");
                                    gets(num);
                                    valid=false;
                                    while(!valid){//validar de que numero a apostar sea entero y que oscile entre 1 y 36
                                    while (!numerico(num))
                                    {
                                        printf("\n Este valor no es un numero. Ingrese nuevamente el primer numero a apostar: ");
                                        gets (num);  
                                    } 
                                    nr= atoi (num);
                                    if (nr>36)
                                    {
                                    
                                       printf("\n Valor fuera de rango, ingrese nuevamente el valor: ");
                                       gets (num);          
                                    }
                                    else
                                    {
                                    
                                       valid=true; 
                                    }}
                                    x=1;
                                    y=nr;
                                    while (y>3)//estructura iterativa para saber en que columna (variable 'y') del tapete se encuentra el primer numero apostado
                                    {
                                    
                                       y=y-3;
                                       x++;    
                                    }
                                    if (nr==1)//Si el numero ingresado es 1 (borde del tapete)
                                    {
                                    
                                       printf("\n Ingrese el segundo numero: '2' o '4': ");
                                       gets (num2);
                                       while ( (strcmp(num2,"2")!=0) && (strcmp(num2,"4")!=0) )//validar entrada
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       }
                                       strcpy (num3,num2);
                                               
                                    }
                                    else if (nr==2)//Si el numero ingresado es 2 (borde del tapete)
                                    {
                                       printf("\n Ingrese el segundo numero: '1' , '3' o '5': ");
                                       gets (num2);
                                       while ( (strcmp(num2,"1")!=0) && (strcmp(num2,"3")!=0) && (strcmp(num2,"5")!=0))//validar entrada
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       }
                                       strcpy (num3,num2);   
                                    }
                                    else if (nr==3)//Si el numero ingresado es 3 (borde del tapete)
                                    {
                                       printf("\n Ingrese el segundo numero: '2' o '6': ");
                                       gets (num2);
                                       while ( (strcmp(num2,"2")!=0) && (strcmp(num2,"6")!=0) )
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       } 
                                       strcpy (num3,num2); 
                                    }
                                    else if (nr==34)//Si el numero ingresado es 34 (borde del tapete)
                                    {
                                       printf("\n Ingrese el segundo numero: '28' o '35': ");
                                       gets (num2);
                                       while ( (strcmp(num2,"28")!=0) && (strcmp(num2,"35")!=0) )
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       }  
                                       strcpy (num3,num2);
                                    }
                                    else if (nr==35)//Si el numero ingresado es 35 (borde del tapete)
                                    {
                                       printf("\n Ingrese el segundo numero: '34' , '32' o '36': "); 
                                       gets (num2);
                                       while ( (strcmp(num2,"34")!=0) && (strcmp(num2,"32")!=0) && (strcmp(num2,"36")!=0 ))
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       } 
                                       strcpy (num3,num2); 
                                    }
                                    else if (nr==36)//Si el numero ingresado es 36 (borde del tapete)
                                    {
                                       printf("\n Ingrese el segundo numero: '35' o '33' :");
                                       gets (num2);
                                       while ( (strcmp(num2,"35")!=0) && (strcmp(num2,"33")!=0) )
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       }
                                       strcpy (num3,num2);
                                        
                                    }
                                    else if (y==1)//si el numero se encuentra en la columna 1, se le pide al usuarios que seleccione una de las combinaciones partiendo del numero que ingres�
                                    {
                                    
                                       printf("\n Ingrese el segundo numero: %d %s %d %s %d: ",nr-3,",",nr+1,"o",nr+3);
                                       gets (num2);
                                       while ( (strcmp(num2,itoa(nr-3,num3,10))!=0) && (strcmp(num2,itoa(nr+1,num3,10))!=0) && (strcmp(num2,itoa(nr+3,num3,10))!=0) )
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       }      
                                    }
                                    else if (y==2)//si el numero se encuentra en la columna 2, se le pide al usuarios que seleccione una de las combinaciones partiendo del numero que ingres�
                                    {
                                    
                                       printf("\n Ingrese el segundo numero: %d %s %d %s %d %s %d: ",nr-3,",",nr-1,",",nr+1,"o",nr+3); 
                                       gets (num2);
                                       while ( (strcmp(num2,itoa(nr-3,num3,10))!=0) && (strcmp(num2,itoa(nr-1,num3,10))!=0) && (strcmp(num2,itoa(nr+1,num3,10))!=0) && (strcmp(num2,itoa(nr+3,num3,10))!=0) )
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                       }    
                                    }
                                    else//si el numero se encuentra en la 3, se le pide al usuarios que seleccione una de las combinaciones partiendo del numero que ingres�
                                    {
                                    
                                       printf("\n Ingrese el segundo numero: %d %s %d %s %d: ",nr-3,",",nr-1,"o",nr+3);
                                       gets (num2);
                                       system("cls");
                                       while ( (strcmp(num2,itoa(nr-3,num3,10))!=0) && (strcmp(num2,itoa(nr-1,num3,10))!=0) && (strcmp(num2,itoa(nr+3,num3,10))!=0) )
                                       {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese nuevamente el segundo numero a apostar: ");
                                         gets(num2);
                                         
                                       }
                                            
                                    }
                                    
                                    itoa (nr,num,10);
                                    strcpy (nuevo_ap->apu,num);
                                    strcat (nuevo_ap->apu,"-");
                                    strcat (nuevo_ap->apu,num3);//se guarda los datos de la apuesta
                                    printf("\n Apuesta realizada: %s", nuevo_ap->apu);
                                    printf("\n");
                                    nuevo_ap->nr_apu=2;
                                    nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+2;
                                    Lap->monto=Lap->monto-20;
                                    nuevo_ap->monto=20;
                                    strcpy (nuevo_ap->tipo,"Dos Numeros");//se guarda el tipo de apuesta
                                    //printf ("\n %d",aleat);
                                    nr2=atoi(num3);
                                    nuevo_res->tot_apos=nuevo_res->tot_apos+20;
                                    if ((nr==aleat) || (nr2==aleat))//si alguno de los numeros coincide con el aleatorio
                                    {
                                         
                                         nuevo_ap->ganado=true;
                                         nuevo_ap->mon_gan=360;
                                         nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                          
                                    }
                                    else
                                    {
                                         nuevo_ap->ganado=false;
                           
                                    }
                                    if (nuevo_res->punta_ap)
                                    {
                                    
                                        nuevo_ap->sig=nuevo_res->punta_ap;          
                                    }
                                    nuevo_res->punta_ap=nuevo_ap;//Se agrega el nuevo nodo en el de la mano
                   
                                    }
                                    else if(Lap->monto<20)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos+2>18)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");     
                                    }
                                     
                                }//opcion 2
                                
                                
                                else if (opcion==3)//Si desea hacer apuesta de tres numeros
                                {
                                     
                                    if ((Lap->monto>=30) && (nuevo_res->tot_nr_apos+3<=18)){
                                    printf("\n Costo de la apuesta: 30 Bs.");
                                    printf("\n Premio: 360 Bs.");
                                    printf ("\n Ingrese el valor correspondiente a la fila que desee apostar. Ejemplo: si teclea '5', apostara los numeros '4','5' y '6': ");
                                    gets(num);
                                    nuevo_ap= new nodo_apu();
                                    valid=false;
                                    while(!valid){//validar de que numero a apostar sea entero y que oscile entre 1 y 36
                                    while (!numerico(num))
                                    {
                                        printf("\n Este valor no es un numero. Ingrese nuevamente el primer numero a apostar: ");
                                        gets (num);  
                                    } 
                                    nr= atoi (num);
                                    if ((nr>36) || (nr==0))
                                    {
                                    
                                       printf("\n Valor fuera de rango, ingrese nuevamente el valor: ");
                                       gets (num);          
                                    }
                                    else
                                    {
                                    
                                       valid=true; 
                                    }}
                                    y=nr;
                                    x=0;
                                    while (y>3)//iteracion para asignar como apuesta, la fila y la columna correspondiente al numero ingresado
                                    {
                                    
                                       y=y-3;
                                       x++;   
                                    }
                                    
                                    if (y==1)//Si cayo en la 1era columna
                                    {
                                    
                                      strcpy(nuevo_ap->apu,num);
                                      strcat(nuevo_ap->apu,"-");
                                      itoa (nr+1,num2,10);
                                      strcat(nuevo_ap->apu,num2);
                                      strcat(nuevo_ap->apu,"-");
                                      itoa (nr+2,num3,10);
                                      strcat(nuevo_ap->apu,num3);         
                                    }
                                    else if (y==2)//Si cayo en la 2da columna
                                    {
                                    
                                      itoa (nr-1,num,10);
                                      strcpy(nuevo_ap->apu,num);
                                      strcat(nuevo_ap->apu,"-");
                                      itoa (nr,num2,10);
                                      strcat(nuevo_ap->apu,num2);
                                      strcat(nuevo_ap->apu,"-");
                                      itoa (nr+1,num3,10);
                                      strcat(nuevo_ap->apu,num3);         
                                    }
                                    else//Si cayo en la 3era columna
                                    {
                                    
                                      itoa (nr-2,num,10);
                                      strcpy(nuevo_ap->apu,num);
                                      strcat(nuevo_ap->apu,"-");
                                      itoa (nr-1,num2,10);
                                      strcat(nuevo_ap->apu,num2);
                                      strcat(nuevo_ap->apu,"-");
                                      itoa (nr,num3,10);
                                      strcat(nuevo_ap->apu,num3);         
                                    }//DEpendiendo de la columna, se guarda los datos de la apuesta
                                    printf("\n Apuesta realizada: %s", nuevo_ap->apu);
                                    printf("\n");
                                    Lap->monto=Lap->monto-30;
                                    nuevo_ap->monto=30;
                                    strcpy(nuevo_ap->tipo,"Tres Numeros");
                                    nuevo_ap->nr_apu=3;
                                    nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+3;
                                    nuevo_res->tot_apos=nuevo_res->tot_apos+30;
                                    if ( ((3*x)+1<=aleat) && (3*(x+1)>=aleat)  )//si el numero aleatorio coincide con la fila q se apost�
                                    {
                                       nuevo_ap->ganado=true;
                                       nuevo_ap->mon_gan=360;
                                       nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                         
                                    }
                                    else
                                    {
                                         
                                         nuevo_ap->ganado=false;
                                    }
                                    if (nuevo_res->punta_ap)
                                    {
                                    
                                        nuevo_ap->sig=nuevo_res->punta_ap;          
                                    }
                                    nuevo_res->punta_ap=nuevo_ap;
                   
                                    }
                                    else if(Lap->monto<30)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos+3>18)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta.");
                                            
                                    }
                                    
                                }//opcion 3
                                
                                
                                else if (opcion==4)//opcion 4
                                {
                                
                                    if ((Lap->monto>=40) && (nuevo_res->tot_nr_apos+4<=18)){
                                    printf("\n Costo de la apuesta: 40 Bs.");
                                    printf("\n Premio: 320 Bs.");
                                    printf("\n Ingrese el primer numero a apostar: ");
                                    gets(num);
                                    nuevo_ap= new nodo_apu();
                                    valid=false;
                                    while(!valid){//validar de que numero a apostar sea entero y que oscile entre 1 y 36
                                    while (!numerico(num))
                                    {
                                        printf("\n Este valor no es un numero. Ingrese nuevamente el primer numero a apostar: ");
                                        gets (num);  
                                    } 
                                    nr= atoi (num);
                                    if ((nr>36) || (nr==0))
                                    {
                                    
                                       printf("\n Valor fuera de rango, ingrese nuevamente el valor: ");
                                       gets (num);          
                                    }
                                    else
                                    {
                                    
                                       valid=true; 
                                    }}
                                    y=nr;
                                    x=0;
                                    while (y>3)//iteracion para saber la columna correspondiente del primer numero ingresado
                                    {
                                    
                                       y=y-3;
                                       x++;   
                                    }
                                    encontrado=false;
                                    if (nr==1)//cuadrado unico
                                    {
                                       strcpy(nuevo_ap->apu,"1-2-4-5");//guardar apuesta
                                       if ( (aleat==1) || (aleat==2) || (aleat==4) || (aleat==5) ) encontrado=true;//si coincide con la apuesta, se encontr�
                                               
                                    }
                                    else if (nr==3)// si el numero ingresado es 3
                                    {
                                       strcpy(nuevo_ap->apu,"2-3-5-6");//guardar apuesta
                                       if ( (aleat==2) || (aleat==3) || (aleat==5) || (aleat==6) ) encontrado=true;     
                                    }
                                    else if (nr==34)// si el numero ingresado es 34
                                    {
                                       strcpy(nuevo_ap->apu,"31-32-34-35"); //guardar apuesta
                                       if ( (aleat==31) || (aleat==32) || (aleat==34) || (aleat==35) ) encontrado=true;    
                                    }
                                    else if (nr==36)// si el numero ingresado es 36
                                    {
                                       strcpy(nuevo_ap->apu,"32-33-35-36");//guardar apuesta
                                       if ( (aleat==32) || (aleat==33) || (aleat==35) || (aleat==36) ) encontrado=true;     
                                    }
                                    else if (nr==2)// si el numero ingresado es 2
                                    {
                                    
                                        printf("\n Presione la tecla 'a' si desea elegir los numeros 3,4 y 6 para completar el cuadrado: ");
                                        gets(chr);
                                        while ( (strcmp(chr,"a")!=0) && (strcmp(chr,"A")!=0) && (strcmp(chr,"b")!=0) && (strcmp(chr,"B")!=0) )
                                        {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
                                         gets(chr);
                                        }
                                        if ( (strcmp(chr,"a")==0) && (strcmp(chr,"A")==0) )
                                        {
                                        
                                           strcpy(nuevo_ap->apu,"2-3-5-6");
                                           if ( (aleat==2) || (aleat==3) || (aleat==5) || (aleat==6) ) encontrado=true;  
                                        }
                                        else
                                        {
                                           strcpy(nuevo_ap->apu,"1-2-4-5");
                                           if ( (aleat==1) || (aleat==2) || (aleat==4) || (aleat==5) ) encontrado=true; 
                                        }
                                         
                                    }
                                    else if (nr==35)// si el numero ingresado es 35
                                    {
                                    
                                        printf("\n Presione la tecla 'a' si desea elegir los numeros 32,33 y 36 para completar el cuadrado: ");
                                        printf("\n Presione la tecla 'b' si desea elegir los numeros 31,32 y 34 para completar el cuadrado: ");
                                        gets(chr);
                                        while ( (strcmp(chr,"a")!=0) && (strcmp(chr,"A")!=0) && (strcmp(chr,"b")!=0) && (strcmp(chr,"B")!=0) )
                                        {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
                                         gets(chr);
                                        }
                                        if ( (strcmp(chr,"a")==0) && (strcmp(chr,"A")==0) )
                                        {
                                        
                                           strcpy(nuevo_ap->apu,"32-33-35-36");
                                           if ( (aleat==32) || (aleat==33) || (aleat==35) || (aleat==36) ) encontrado=true;  
                                        }
                                        else
                                        {
                                           strcpy(nuevo_ap->apu,"31-32-34-35"); 
                                        }
                                         
                                    }
                                    else if (y==1)//si pertenece a la primera columna, se muestra las combinaciones para que el usuario eliga una de ellas
                                    {
                                    
                                        printf("\n Presione la tecla 'a' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr+1,nr+3,nr+4);
                                        printf("\n Presione la tecla 'b' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr-3,nr-2,nr+1);
                                        gets(chr);
                                        while ( (strcmp(chr,"a")!=0) && (strcmp(chr,"A")!=0) && (strcmp(chr,"b")!=0) && (strcmp(chr,"B")!=0) )
                                        {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
                                         gets(chr);
                                        }
                                        if ( (strcmp(chr,"a")==0) || (strcmp(chr,"A")==0) )
                                        {
                                        
                                           itoa (nr,num,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+1,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+3,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+4,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           if ( (aleat==nr) || (aleat==nr+1) || (aleat==nr+3) || (aleat==nr+4) ) encontrado=true;
                                           
                                             
                                        }
                                        else
                                        {
                                           itoa (nr-3,num2,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr-2,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr,num,10);
                                           strcat(nuevo_ap->apu,num);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+1,num2,10);
                                           strcat(nuevo_ap->apu,num2); 
                                           if ( (aleat==nr-3) || (aleat==nr-2) || (aleat==nr) || (aleat==nr+1) ) encontrado=true;
                                        } 
                                    }
                                    else if (y==3)//si pertenece a la 3era columna, se muestra las combinaciones para que el usuario eliga una de ellas
                                    {
                                    
                                        printf("\n Presione la tecla 'a' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr-1,nr+2,nr+3);
                                        printf("\n Presione la tecla 'b' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr-4,nr-3,nr-1);
                                        gets(chr);
                                        while ( (strcmp(chr,"a")!=0) && (strcmp(chr,"A")!=0) && (strcmp(chr,"b")!=0) && (strcmp(chr,"B")!=0) )
                                        {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
                                         gets(chr);
                                        }
                                        if ( (strcmp(chr,"a")==0) || (strcmp(chr,"A")==0) )
                                        {
                                        
                                           itoa (nr-1,num2,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr,num,10);
                                           strcat(nuevo_ap->apu,num);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+2,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+3,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           if ( (aleat==nr-1) || (aleat==nr) || (aleat==nr+2) || (aleat==nr+3) ) encontrado=true;
                                           
                                             
                                        }
                                        else
                                        {
                                           itoa (nr-4,num2,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr-3,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr-1,num2,10);
                                           strcat(nuevo_ap->apu,num2); 
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr,num,10);
                                           strcat(nuevo_ap->apu,num);
                                           if ( (aleat==nr-4) || (aleat==nr-3) || (aleat==nr-1) || (aleat==nr) ) encontrado=true;
                                           
                                        } 
                                    }
                                    else if (y==2)//si pertenece a la 2da columna, se muestra las combinaciones para que el usuario eliga una de ellas
                                    {
                                    
                                        printf("\n Presione la tecla 'a' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr+1,nr+3,nr+4);
                                        printf("\n Presione la tecla 'b' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr-1,nr+2,nr+3);
                                        printf("\n Presione la tecla 'c' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr-3,nr-2,nr+1);
                                        printf("\n Presione la tecla 'd' si desea elegir los numeros %d,%d y %d para completar el cuadrado: ",nr-4,nr-3,nr-1);
                                        gets(chr);
                                        while ( (strcmp(chr,"a")!=0) && (strcmp(chr,"A")!=0) && (strcmp(chr,"b")!=0) && (strcmp(chr,"B")!=0) && (strcmp(chr,"c")!=0) && (strcmp(chr,"C")!=0) && (strcmp(chr,"d")!=0) && (strcmp(chr,"D")!=0) )
                                        {
                                       
                                         printf ("\n Error al leer el dato de entrada. Ingrese la opci\242n correcta: ");
                                         gets(chr);
                                        }
                                        if ( (strcmp(chr,"a")==0) || (strcmp(chr,"A")==0) )
                                        {
                                        
                                           strcpy(nuevo_ap->apu,num);//guardar apuesta
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+1,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+3,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+4,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           if ( (aleat==nr) || (aleat==nr+1) || (aleat==nr+3) || (aleat==nr+4) ) encontrado=true;
                                           
                                             
                                        }
                                        else if ( (strcmp(chr,"b")==0) || (strcmp(chr,"B")==0) )
                                        {
                                             
                                           itoa (nr-1,num2,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr,num,10);
                                           strcat(nuevo_ap->apu,num);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+2,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+3,num2,10);
                                           strcat(nuevo_ap->apu,num2); 
                                           if ( (aleat==nr-1) || (aleat==nr) || (aleat==nr+2) || (aleat==nr+3) ) encontrado=true; 
                                        }
                                        else if ( (strcmp(chr,"c")==0) || (strcmp(chr,"C")==0) )
                                        {
                                             
                                           itoa (nr-3,num2,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr-2,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr,num,10);
                                           strcat(nuevo_ap->apu,num);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr+1,num2,10);
                                           strcat(nuevo_ap->apu,num2); 
                                           if ( (aleat==nr-3) || (aleat==nr-2) || (aleat==nr) || (aleat==nr+1) ) encontrado=true;
                                        }
                                        else{
                                           itoa (nr-4,num2,10);//guardar apuesta
                                           strcpy(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr-3,num2,10);
                                           strcat(nuevo_ap->apu,num2);
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr-1,num2,10);
                                           strcat(nuevo_ap->apu,num2); 
                                           strcat (nuevo_ap->apu,"-");
                                           itoa (nr,num,10);
                                           strcat(nuevo_ap->apu,num);
                                           if ( (aleat==nr-4) || (aleat==nr-3) || (aleat==nr-1) || (aleat==nr) ) encontrado=true;
                                           
                                        }
                                    }
                                    printf("\n Numeros apostados: %s",nuevo_ap->apu);
                                    printf("\n");
                                    Lap->monto=Lap->monto-40;//se descuenta el monto de la apuesta
                                    nuevo_ap->monto=40;
                                    strcpy (nuevo_ap->tipo,"Cuatro Numeros");
                                    nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+4;
                                    nuevo_res->tot_apos=nuevo_res->tot_apos+40;
                                    if (encontrado){//si coinicidio el numero
                                         nuevo_ap->ganado=true;
                                         nuevo_ap->mon_gan=360;
                                         nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                          
                                    }
                                    else
                                    {
                                         
                                         nuevo_ap->ganado=false;
                                    }
                                    if (nuevo_res->punta_ap)
                                    {
                                    
                                        nuevo_ap->sig=nuevo_res->punta_ap;          
                                    }
                                    nuevo_res->punta_ap=nuevo_ap;
                                   
                                   }
                                   else if(Lap->monto<40)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos+4>18)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");
                                            
                                    }
                                    
                                    
                                }
                                else if (opcion==5)//si eligio sexteto
                                {
                                    if((Lap->monto>=60) && (nuevo_res->tot_nr_apos+6<=18))
                                    {
                                        nuevo_ap=new nodo_apu();
                                        printf("\n Presione 'a' si desea apostar del 1 al 6");
                                        printf("\n Presione 'b' si desea apostar del 7 al 12");
                                        printf("\n Presione 'c' si desea apostar del 13 al 18");
                                        printf("\n Presione 'd' si desea apostar del 19 al 24");
                                        printf("\n Presione 'e' si desea apostar del 25 al 30");
                                        printf("\n Presione 'f' si desea apostar del 31 al 36: ");
                                        gets(opc3);
                                        while ( (strcmp(opc3,"a")!=0) && (strcmp(opc3,"A")!=0) && (strcmp(opc3,"b")!=0) && (strcmp(opc3,"B")!=0) && (strcmp(opc3,"c")!=0) && (strcmp(opc3,"C")!=0) && (strcmp(opc3,"d")!=0) && (strcmp(opc3,"D")!=0) && (strcmp(opc3,"e")!=0) && (strcmp(opc3,"E")!=0) && (strcmp(opc3,"f")!=0) && (strcmp(opc3,"F")!=0) )
                                        {
                                             printf("\n Error a leer dato de entrada. Ingrese nuevamente la opcion correcta: ");
                                             gets(opc3); 
                                        }
                                        if ((strcmp(opc3,"a")==0) || (strcmp(opc3,"A")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"1-2-3-4-5-6");
                                             if((aleat>=1) && (aleat<=6))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else if ((strcmp(opc3,"b")==0) || (strcmp(opc3,"B")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"7-8-9-10-11-12");
                                             if((aleat>=7) && (aleat<=12))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else if ((strcmp(opc3,"c")==0) || (strcmp(opc3,"C")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"13-14-15-16-17-18");
                                             if((aleat>=13) && (aleat<=18))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else if ((strcmp(opc3,"d")==0) || (strcmp(opc3,"D")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"19-20-21-22-23-24");
                                             if((aleat>=19) && (aleat<=24))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else if ((strcmp(opc3,"e")==0) || (strcmp(opc3,"E")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"25-26-27-28-29-30");
                                             if((aleat>=25) && (aleat<=30))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else
                                        {
                                             strcpy(nuevo_ap->apu,"31-32-33-34-35-36");
                                             if((aleat>=31) && (aleat<=36))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        printf("\n Numeros apostados: %s",nuevo_ap->apu);
                                        printf("\n");
                                        Lap->monto=Lap->monto-60;//se descuenta el monto de la apuesta
                                        nuevo_ap->monto=60;
                                        strcpy (nuevo_ap->tipo,"Sexteto");
                                        nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+6;
                                        nuevo_res->tot_apos=nuevo_res->tot_apos+60;
                                        if (encontrado){//si coinicidio el numero
                                             nuevo_ap->ganado=true;
                                             nuevo_ap->mon_gan=360;
                                             nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                              
                                        }
                                        else
                                        {
                                             
                                             nuevo_ap->ganado=false;
                                        }
                                        if (nuevo_res->punta_ap)
                                        {
                                        
                                            nuevo_ap->sig=nuevo_res->punta_ap;          
                                        }
                                        nuevo_res->punta_ap=nuevo_ap;
                                             
                                    }
                                    else if(Lap->monto<60)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos+6>18)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");
                                            
                                    } 
                                }
                                
                                
                                else if (opcion==6)//si eligio docena
                                {
                                    if((Lap->monto>=120) && (nuevo_res->tot_nr_apos+12<=18))
                                    {
                                        nuevo_ap=new nodo_apu();
                                        printf("\n Presione 'a' si desea apostar del 1 al 12");
                                        printf("\n Presione 'b' si desea apostar del 13 al 24");
                                        printf("\n Presione 'c' si desea apostar del 25 al 36: ");
                                        gets(opc3);
                                        while ( (strcmp(opc3,"a")!=0) && (strcmp(opc3,"A")!=0) && (strcmp(opc3,"b")!=0) && (strcmp(opc3,"B")!=0) && (strcmp(opc3,"c")!=0) && (strcmp(opc3,"C")!=0) )
                                        {
                                             printf("\n Error a leer dato de entrada. Ingrese nuevamente la opcion correcta: ");
                                             gets(opc3); 
                                        }
                                        if ((strcmp(opc3,"a")==0) || (strcmp(opc3,"A")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"1-2-3-4-5-6-7-8-9-10-11-12");
                                             if((aleat>=1) && (aleat<=12))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else if ((strcmp(opc3,"b")==0) || (strcmp(opc3,"B")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"13-14-15-16-17-18-19-20-21-22-23-24");
                                             if((aleat>=13) && (aleat<=24))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else
                                        {
                                             strcpy(nuevo_ap->apu,"25-26-27-28-29-30-31-32-33-34-35-36");
                                             if((aleat>=25) && (aleat<=36))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        printf("\n Numeros apostados: %s",nuevo_ap->apu);
                                        printf("\n");
                                        Lap->monto=Lap->monto-120;//se descuenta el monto de la apuesta
                                        nuevo_ap->monto=120;
                                        strcpy (nuevo_ap->tipo,"Docena");
                                        nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+12;
                                        nuevo_res->tot_apos=nuevo_res->tot_apos+120;
                                        if (encontrado){//si coinicidio el numero
                                             nuevo_ap->ganado=true;
                                             nuevo_ap->mon_gan=360;
                                             nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                              
                                        }
                                        else
                                        {
                                             
                                             nuevo_ap->ganado=false;
                                        }
                                        if (nuevo_res->punta_ap)
                                        {
                                        
                                            nuevo_ap->sig=nuevo_res->punta_ap;          
                                        }
                                        nuevo_res->punta_ap=nuevo_ap;
                                             
                                    }
                                    else if(Lap->monto<120)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta.");
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos+12>18)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta.");    
                                    } 
                                }
                                else if (opcion==7)//si desea columna
                                {
                                    if((Lap->monto>=120) && (nuevo_res->tot_nr_apos+12<=18))
                                    {
                                        nuevo_ap=new nodo_apu();
                                        nr= aleat % 3;
                                        printf("\n Presione 'a' si desea apostar la columna que contiene los siguientes numeros:");
                                        printf("\n 1-4-7-10-13-16-19-22-25-28-31-34\n");
                                        printf("\n Presione 'b' si desea apostar la columna que contiene los siguientes numeros:");
                                        printf("\n 2-5-8-11-14-17-20-23-26-29-32-35\n");
                                        printf("\n Presione 'c' si desea apostar la columna que contiene los siguientes numeros:");
                                        printf("\n 3-6-9-12-15-18-21-24-27-30-33-36: ");
                                        gets(opc3);
                                        while ( (strcmp(opc3,"a")!=0) && (strcmp(opc3,"A")!=0) && (strcmp(opc3,"b")!=0) && (strcmp(opc3,"B")!=0) && (strcmp(opc3,"c")!=0) && (strcmp(opc3,"C")!=0) )
                                        {
                                             printf("\n Error a leer dato de entrada. Ingrese nuevamente la opcion correcta");
                                             gets(opc3); 
                                        }
                                        if ((strcmp(opc3,"a")==0) || (strcmp(opc3,"A")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"1-4-7-10-13-16-19-22-25-28-31-34");
                                             if(nr=1)
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else if ((strcmp(opc3,"b")==0) || (strcmp(opc3,"B")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"2-5-8-11-14-17-20-23-26-29-32-35");
                                             if(nr=2)
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        else
                                        {
                                             strcpy(nuevo_ap->apu,"3-6-9-12-15-18-21-24-27-30-33-36");
                                             if((nr==0) && (aleat!=0))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }                     
                                        }
                                        printf("\n Numeros apostados: %s",nuevo_ap->apu);
                                        printf("\n");
                                        Lap->monto=Lap->monto-120;//se descuenta el monto de la apuesta
                                        nuevo_ap->monto=120;
                                        strcpy (nuevo_ap->tipo,"Columna");
                                        nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+12;
                                        nuevo_res->tot_apos=nuevo_res->tot_apos+120;
                                        if (encontrado){//si coinicidio el numero
                                             nuevo_ap->ganado=true;
                                             nuevo_ap->mon_gan=360;
                                             nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                              
                                        }
                                        else
                                        {
                                             
                                             nuevo_ap->ganado=false;
                                        }
                                        if (nuevo_res->punta_ap)
                                        {
                                        
                                            nuevo_ap->sig=nuevo_res->punta_ap;          
                                        }
                                        nuevo_res->punta_ap=nuevo_ap;
                                             
                                    }
                                    else if(Lap->monto<120)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos+12>18)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");
                                           
                                    } 
                                }
                                
                                else if (opcion==8)
                                {
                                    if((Lap->monto>=180) &&(nuevo_res->tot_nr_apos==0))
                                    {
                                        nuevo_ap=new nodo_apu();
                                        aux_rul=primero_rul;
                                        while (aux_rul->sig!=primero_rul)//Se recorre la ruleta para encontrar el resultado coincidente con el numero aleatorio
                                        {
                                          if (aux_rul->num==aleat)
                                          {
                                                     
                                              nuevo_res->num=aux_rul->num;
                                              strcpy(nuevo_res->col,aux_rul->col);  //Se copia el numero y el color del resultado                     
                                          }
                                                     
                                                     
                                          aux_rul=aux_rul->sig;
                                                            
                                        }
                                        printf("\n Presione 'a' si desea apostar los numeros de color negro");
                                        printf("\n Presione 'b' si desea apostar los numeros de color rojo: ");
                                        gets(opc3);
                                        while ( (strcmp(opc3,"a")!=0) && (strcmp(opc3,"A")!=0) && (strcmp(opc3,"b")!=0) && (strcmp(opc3,"B")!=0) )
                                        {
                                             printf("\n Error a leer dato de entrada. Ingrese nuevamente la opcion correcta: ");
                                             gets(opc3); 
                                        }
                                        if ((strcmp(opc3,"a")==0) || (strcmp(opc3,"A")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"2-4-6-8-10-11-13-15-17-20-22-24-26-28-29-31-33-35");
                                             if((strcmp(nuevo_res->col,"Negro")==0))//Si el color coincide con el elegido por el usuario
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }
                                             strcpy(nuevo_ap->tipo,"Negro");                     
                                        }
                                        else
                                        {
                                             strcpy(nuevo_ap->apu,"1-3-5-7-9-12-14-16-18-19-21-23-25-27-30-32-34-36");
                                             if((strcmp(nuevo_res->col,"Rojo")==0))//Si el color coincide con el elegido por el usuario
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }
                                             strcpy(nuevo_ap->tipo,"Rojo");                      
                                        }
                                        printf("\n");
                                        Lap->monto=Lap->monto-180;//se descuenta el monto de la apuesta
                                        nuevo_ap->monto=180;
                                        nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+18;
                                        nuevo_res->tot_apos=nuevo_res->tot_apos+180;
                                        if (encontrado){//si coinicidio el color
                                             nuevo_ap->ganado=true;
                                             nuevo_ap->mon_gan=360;
                                             nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                              
                                        }
                                        else
                                        {
                                             
                                             nuevo_ap->ganado=false;
                                        }
                                        if (nuevo_res->punta_ap)
                                        {
                                        
                                            nuevo_ap->sig=nuevo_res->punta_ap;          
                                        }
                                        nuevo_res->punta_ap=nuevo_ap;
                                             
                                    }
                                    else if(Lap->monto<180)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos!=0)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");
                                         
                                    } 
                                }
                                
                                else if (opcion==9)//Apostar par o impar
                                {
                                    if((Lap->monto>=180) && (nuevo_res->tot_nr_apos==0))
                                    {
                                        nuevo_ap=new nodo_apu();
                                        aux_rul=primero_rul;
                                        printf("\n Presione 'a' si desea apostar par");
                                        printf("\n Presione 'b' si desea apostar impar: ");
                                        gets(opc3);
                                        while ( (strcmp(opc3,"a")!=0) && (strcmp(opc3,"A")!=0) && (strcmp(opc3,"b")!=0) && (strcmp(opc3,"B")!=0) )
                                        {
                                             printf("\n Error a leer dato de entrada. Ingrese nuevamente la opcion correcta: ");
                                             gets(opc3); 
                                        }
                                        if ((strcmp(opc3,"a")==0) || (strcmp(opc3,"A")==0))//si eligio par
                                        {
                                             strcpy(nuevo_ap->apu,"2-6-8-10-12-14-16-18-20-22-24-26-28-30-32-34-36");
                                             if((aleat%2==0) && (aleat!=0))//si es par el aleatorio
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }
                                             strcpy(nuevo_ap->tipo,"Par");                     
                                        }
                                        else //si eligio impar
                                        {
                                             strcpy(nuevo_ap->apu,"1-3-5-7-9-11-13-15-17-19-21-23-25-27-39-31-33-35");
                                             if(aleat%2==1)//si el aleatorio es impar
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }
                                             strcpy(nuevo_ap->tipo,"Impar");                     
                                        }
                                        printf("\n");
                                        Lap->monto=Lap->monto-180;//se descuenta el monto de la apuesta
                                        nuevo_ap->monto=180;
                                        nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+18;
                                        nuevo_res->tot_apos=nuevo_res->tot_apos+180;
                                        if (encontrado){//si coinicidio el numero
                                             nuevo_ap->ganado=true;
                                             nuevo_ap->mon_gan=360;
                                             nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                              
                                        }
                                        else
                                        {
                                             
                                             nuevo_ap->ganado=false;
                                        }
                                        if (nuevo_res->punta_ap)
                                        {
                                        
                                            nuevo_ap->sig=nuevo_res->punta_ap;          
                                        }
                                        nuevo_res->punta_ap=nuevo_ap;
                                             
                                    }
                                    else if(Lap->monto<180)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos!=0)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");
                                            
                                    }  
                                }
                                
                                else if (opcion==10)
                                {
                                    if( (Lap->monto>=180) && (nuevo_res->tot_nr_apos==0))
                                    {
                                        nuevo_ap=new nodo_apu();
                                        printf("\n Presione 'a' si desea apostar del 1 al 18");
                                        printf("\n Presione 'b' si desea apostar del 19 al 36: ");
                                        gets(opc3);
                                        while ( (strcmp(opc3,"a")!=0) && (strcmp(opc3,"A")!=0) && (strcmp(opc3,"b")!=0) && (strcmp(opc3,"B")!=0) )
                                        {
                                             printf("\n Error a leer dato de entrada. Ingrese nuevamente la opcion correcta: ");
                                             gets(opc3); 
                                        }
                                        if ((strcmp(opc3,"a")==0) || (strcmp(opc3,"A")==0))
                                        {
                                             strcpy(nuevo_ap->apu,"1-2-3-4-5-6-7-8-9-10-11-12-13-14-15-16-17-18");
                                             if((aleat>=1) && (aleat<=18))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }
                                             strcpy(nuevo_ap->tipo,"Numero Bajo");                     
                                        }
                                        else
                                        {
                                             strcpy(nuevo_ap->apu,"19-20-21-22-23-24-25-26-27-28-29-30-31-32-33-34-35-36");
                                             if((aleat>=19) && (aleat<=36))
                                             {
                                                encontrado=true;             
                                             }
                                             else
                                             {
                                                encontrado=false;    
                                             }
                                             strcpy(nuevo_ap->tipo,"Numero Alto");                     
                                        }
                                        printf("\n Numeros apostados: %s",nuevo_ap->apu);
                                        printf("\n");
                                        Lap->monto=Lap->monto-180;//se descuenta el monto de la apuesta
                                        nuevo_ap->monto=180;
                                        nuevo_res->tot_nr_apos=nuevo_res->tot_nr_apos+18;
                                        nuevo_res->tot_apos=nuevo_res->tot_apos+180;
                                        if (encontrado){//si coinicidio el numero
                                             nuevo_ap->ganado=true;
                                             nuevo_ap->mon_gan=360;
                                             nuevo_res->tot_gan=nuevo_res->tot_gan+360;
                                                              
                                        }
                                        else
                                        {
                                             
                                             nuevo_ap->ganado=false;
                                        }
                                        if (nuevo_res->punta_ap)
                                        {
                                        
                                            nuevo_ap->sig=nuevo_res->punta_ap;          
                                        }
                                        nuevo_res->punta_ap=nuevo_ap;
                                             
                                    }
                                    else if(Lap->monto<180)//si su monto restante es menor que el requerido para hacer esta apuesta
                                    {
                                        
                                       printf("\n El monto q ud tiene no es suficiente para hacer esta apuesta. ");
                                       
                                       
                                    }
                                    else if (nuevo_res->tot_nr_apos!=0)
                                    {
                                       printf("\n Los numeros restantes para apostar no son suficientes para realizar esta apuesta. ");
                                           
                                    }
                                     
                                }
                                
                                
                                printf("\n Desea realizar otra apuesta en esta mano? s/n: ");
                                gets(opc2);
                                system("cls");
                                while ( (strcmp(opc2,"s")!=0) && (strcmp(opc2,"S")!=0) && (strcmp(opc2,"n")!=0) && (strcmp(opc2,"N")!=0))
                                
                                {
                               
                                 printf ("\n Error al leer el dato de entrada. Ingrese la opcion correcta: ");
                                 gets(opc2);
                                }
                                if ( (strcmp(opc2,"n")==0) || (strcmp(opc2,"N")==0) )
                                {
                                   salir_apu=true;  
                                }
                                
                                
                                 
                              }//Si el monto es mayor q 10 (si se puede realizar apuestas)
                              else if(!nuevo_res->punta_ap)
                              {
                                 printf("\n Disculpe, su monto restante no es suficiente para realizar apuestas.");
                                 salir_apu=true;
                              }
                              
                              else if ((Lap->monto<10) && (nuevo_res->tot_nr_apos<=18))
                              {
                                 printf ("\n Disculpe, su monto restante no es suficiente para realizar apuestas. A continuacion se procedera a jugar con las apuestas previamente hechas en esta mano.");
                                 system("pause");
                                 salir_apu=true;     
                              }
                              
                              else if ((nuevo_res->punta_ap) && (nuevo_res->tot_nr_apos==18))
                              {
                                 printf ("\n Ya no se puede realizar mas apuestas, debido a que se llego al maximo de numeros apostados. A continuacion se procedera a jugar con las apuestas previamente hechas en esta mano.");
                                 system("pause");
                                 salir_apu=true;     
                              }   
                           }//Mientras salir_apu
                           if (nuevo_res->punta_ap){
                           aux_rul=primero_rul;
                           while (aux_rul->sig!=primero_rul)//Se recorre la ruleta para encontrar el resultado coincidente con el numero aleatorio
                           {
                              if (aux_rul->num==aleat)
                              {
                                         
                                  printf ("\n\t\t\tResultado de la ruleta: %d%s%s",aux_rul->num," ",aux_rul->col);
                                  nuevo_res->num=aux_rul->num;
                                  strcpy(nuevo_res->col,aux_rul->col);                       
                              }
                                         
                                         
                              aux_rul=aux_rul->sig;
                                                
                           }
                           Lap->tot_apos=Lap->tot_apos+nuevo_res->tot_apos;
                           Lap->tot_gan=Lap->tot_gan+nuevo_res->tot_gan;
                           if (Lap->punta_res)//agregar el nuevo resultado en la lista
                           {
                                    
                               nuevo_res->sig=Lap->punta_res;          
                           }
                           //codigo para guardar la mano jugada en la lista
                           Lap->punta_res=nuevo_res;
                           Lap->tot_man++;
                           aux_apu=Lap->punta_res->punta_ap;
                           printf("\n");
                           printf("\nApuestas realizadas en esta ronda:");
                           printf("\n");
                           while(aux_apu){
                           
                               printf("\n");
                               printf("\n*Tipo de apuesta: %s",aux_apu->tipo);
                               printf("\n Numero(s) apostado(s): %s",aux_apu->apu);
                               if(aux_apu->ganado){
                                  
                                  printf("\n Felicidades ha ganado %d Bs. al apostar al numero %d %s.",aux_apu->mon_gan,aleat,aux_rul->col);
                                  gan=true;
                                  Lap->punta_res->nr_acierts++;
                                  
                               }
                               Lap->punta_res->nr_apu++;
                               aux_apu=aux_apu->sig;
                                 
                           }
                           if(Lap->punta_res->nr_acierts>0) Lap->manos_gan++;
                           Lap->monto=Lap->monto+Lap->punta_res->tot_gan;
                           printf("\n");
                           printf("\nTotal de numeros apostados: %d",Lap->punta_res->tot_nr_apos);
                           printf("\nTotal apostado: %d Bs.",Lap->punta_res->tot_apos);
                           printf("\nTotal de apuestas: %d",Lap->punta_res->nr_apu);
                           printf("\nTotal de apuestas acertadas: %d",Lap->punta_res->nr_acierts);
                           printf("\nTotal ganado: %d Bs.",Lap->punta_res->tot_gan);
                           if (!gan) printf("\nLo sentimos, ha perdido la partida.");
                           printf("\n");
                           printf("Monto actual: %d Bs.",Lap->monto);
                           printf("\n");
                           }
                           //aqui culmina el codigo para guardar la mano en la lista
                        
               }
               
               else{ // estadisticas de las manos jugadas
                    
                      aux_res=Lap->punta_res;
                      if (!Lap->punta_res)
                      {
                      
                         printf("\n No se han realizado apuestas");            
                      }
                      else
                      {
                         system("cls");
                         printf("\n\t\t\tEstadisticas generales del juego:\n");
                         printf("\nMonto Inicial: %d Bs.",Lap->monto_ini);
                         printf("\nRondas Jugadas: %d ",Lap->tot_man);
                         printf("\nTotal Apostado: %d Bs.",Lap->tot_apos);
                         printf("\nRondas Ganadas: %d ",Lap->manos_gan);
                         printf("\nTotal Ganado: %d Bs.",Lap->tot_gan);
                         printf("\nRondas perdidas: %d ",Lap->tot_man-Lap->manos_gan);
                         printf("\nCantidad de Recargas: %d",Lap->recargas);
                         printf("\nMonto Total en Recargas: %d Bs.",Lap->monto_rec);
                         printf("\nMonto Final: %d Bs.\n",Lap->monto);
                         printf("\nUltimas 10 rondas:\n");
                         int cont=0;
                         int gan=0;
                         int perd=0;
                         while ( (aux_res) && (cont<10) )
                          {
                              printf("\n*Resultado de la ruleta: %d%s%s",aux_res->num," ",aux_res->col);
                              printf("\n Apuestas Realizadas: %d",aux_res->nr_apu);
                              printf("\n Monto Apostado: %d",aux_res->tot_apos);
                              printf("\n Apuestas Acertadas: %d",aux_res->nr_acierts);
                              printf("\n Monto en Apuestas Ganadas: %d Bs.\n",aux_res->tot_gan);
                              printf("\n Listado de Apuestas Realizadas:");
                              aux_apu=aux_res->punta_ap;
                              while (aux_apu){
                              printf("\n *Tipo de apuesta: %s",aux_apu->tipo);
                              printf("\n  Numero(s) apostado(s): %s",aux_apu->apu);
                              printf("\n  Monto de la apuesta (Bs.): %d",aux_apu->monto);
                              if (aux_apu->ganado){
                              printf("\n  Monto ganado: %d",aux_apu->mon_gan);
                              
                              }
                              aux_apu=aux_apu->sig;}
                              
                              aux_res=aux_res->sig;
                              cont++;
                              printf ("\n");
                                
                          } 
                      }
                         
               }//opcion 'b' (estad�sticas)
               system("pause");
               system("cls");
               printf("\n Desea salir de la aplicacion? s/n: ");
               gets(opc2);
               while ( (strcmp(opc2,"s")!=0) && (strcmp(opc2,"S")!=0) && (strcmp(opc2,"n")!=0) && (strcmp(opc2,"N")!=0))
               {
                               
                  printf ("\n Error al leer el dato de entrada. Ingrese la opcion correcta: ");
                  gets(opc2);
               }
               if ( (strcmp(opc2,"s")==0) || (strcmp(opc2,"S")==0) )
               {
                  system("cls");
                  printf("\n\n\n\t\tGRACIAS POR HABER UTILIZADO NUESTRAS INSTALACIONES!\n");
                  printf("\t\t\t\tVUELVA PRONTO!\n\n\n\n\n\n\n");
                  system("pause");
                  salir_juego=true;  
               }
               
               
               
           }//Mientras salir_juego
           
        }          
};
 
int main() {
   lista_ap Lap;//lista
   Lap.llenar_rul();//Se invoca el metodo llenar ruleta
   char opcion[50];
    int opc;
    bool salir;
    salir=false;
    system("color 4E");
cout<<("");
cout<<("\t\t\t**==================================**\n");
cout<<("\t\t    ***||          CASINO LAS VEGAS         ||***\n");
cout<<("\t\t****============================================****\n\n\n\n\n\n\n");

cout<<("\t\t\t  ==================================\n");
cout<<("\t\t\t  ||         LA  RULETA           ||\n");
cout<<("\t\t\t  ==================================\n\n\n\n\n\n\n");

cout<<("\t\t\t\t   //////////////////\n");
cout<<("\t\t\t\t   //    SUERTE    //\n");
cout<<("\t\t\t\t   //////////////////\n\n\n");
system("pause");
system("cls");
cout<<("\n\t\tBIENVENIDO AL AREA DE ENTRETENIMIENDO Y APUESTAS\n");
//while(!salir){
cout<<("\t\t************************************************\n");
system("color 4E");
cout<<("\t\t\t\t      *\n");
cout<<("\t\t\t\t   **   **\n");
cout<<("\t\t\t\t **       **\n");
cout<<("\t\t\t       **           **\n");
cout<<("\t\t\t     **               **\n");
cout<<("\t\t\t   **                   **\n");
cout<<("\t\t\t **                       **\n");
cout<<("\t\t       **        I N I C I A R      **\n");
cout<<("\t\t     **          P A R T I D A        **\n");
cout<<("\t\t     **                               **\n");
cout<<("\t\t       **                           **\n");
cout<<("\t\t\t **                       **\n");
cout<<("\t\t\t   **                   **\n");
cout<<("\t\t\t     **               **\n");
cout<<("\t\t\t       **           **\n");
cout<<("\t\t\t\t **       **\n");
cout<<("\t\t\t\t   **   **\n");
cout<<("\t\t\t\t      *\n");
cout<<("\t\t************************************************\n");
//system("pause");
//system("cls");


    Lap.agregar_ap(&Lap);//Se invoca el metodo de jugar
    return 1;

   cin.get();
   
}
