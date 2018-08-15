#include<stdlib.h>
#include <stdio.h>
#include<conio.h>
#include <string.h>
#include <iostream>
#include <iomanip>
#include <dos.h>
#include <ctype.h>
#include <time.h>
#include <math.h>
using namespace std;
//Estructuras Doblemente enlazadas
typedef struct nododoble
{
int dato;
struct nododoble *sig;
struct nododoble *ant;

}tipoNodo;

typedef tipoNodo *list,*nod;

void creardoble();
int atoi(char string[]);
void presentar(list cab);
void insertar(list *cab,list *cola);
void insertarfinaldoble(nod *cab,nod *cola);
//void insertarordenadodoble();
void insertariniciodoble(list *cab,list *cola);
void modificar(list *cab);
/*void buscar();
void ordenar();
void ordenardoblesasc();
void ordenardoblesdesc();
void eliminar();
void eliminar_cabeza();*/



int  main()
{
list cab=NULL;
list cola=NULL;
char opc=' ';

do
{


printf("LISTAS ENLAZADAS DOBLES \n");
printf("MENU PRINCIPAL \n");
printf("[1]:  INSERTAR \n");
printf("[2]:  MODIFICAR\n");
printf("[3]:  BUSCAR\n");
printf("[4]:  ORDENAR\n");
printf("[5]:  SALIR DEL MENU\n");
scanf(" %[^\n]",&opc);

switch(opc)
{
case '1':
insertar(&cab,&cola); break;
case '2':
modificar(&cab); break;
/*case '3':
buscar(); break;
case '4':
ordenar(); break;*/

}

}while(opc!='5');

getch();

return 1;

}
/*
void creardoble()
{
clrscr();
int dat;
gotoxy(20,20);
cout<<”Ingrese Elemento:  “;
cin>>dat;
cab=nuevo_elemento();
cola=nuevo_elemento();
cab->dato=dat;
cab->sig=NULL;
cab->ant=NULL;
cola=cab;
getch();
}*/
int atoi(char string[])
{   //  By BlackZeroX ( http://Infrangelux.sytes.net/ )
    return (int)atof(string);
}
void insertar(list *cab,list *cola)
{

nod elem,prim,ult;
int res2;
float cnt;
int res;
char *car;
char valor[5];

char opc=' ';

do
{


printf("\n");
printf("[ INSERTAR ELEMENTOS A LA LISTA ENLAZADA ]\n");
printf("\n");
printf("[1]: INSERTAR CABEZA\n");
printf("[2]: INSERTAR AL FINAL\n");
printf("[3]: REGRESAR\n");
scanf(" %[^\n]",&opc);
switch(opc)
{
case '1':
prim= *cab;
ult= *cola;
elem =(nod)malloc(sizeof(tipoNodo));
printf("\n INGRESE VALOR ");
scanf(" %[^\n]",&valor);
res=atoi(valor);
elem->dato=res;
elem->ant=NULL;
elem->sig=NULL;
if (!*cab) {printf("vacia"); ult=elem;}
else {
elem->sig=prim;
prim->ant=elem;}
prim=elem;
*cab=prim;
*cola=ult;
printf("\n");
//presentar (prim);
 printf("LO hizo");
while(prim)
{
printf("=> %d ",prim->dato);
prim=prim->sig;
}break;



case '2':
prim= *cab;
ult= *cola;
elem =(nod)malloc(sizeof(tipoNodo));
printf("\n INGRESE VALOR ");
scanf(" %[^\n]",&valor);
res=atoi(valor);
elem->dato=res;
elem->sig=NULL;
elem->ant=NULL;
if (!*cola) prim=elem;
else {printf("se mete");ult->sig=elem;
elem->ant=ult;}
ult=elem;
*cab=prim;
*cola=ult;
//presentar(prim);


printf("LO hizo");
while(prim)
{
printf("=> %d ",prim->dato);
prim=prim->sig;
}break;


}
//system("pause");

}
while(opc!='3');


}

/*
void insertarordenadodoble()
{
int dat;
nododoble *aux;
nododoble *ant;
nododoble *post;
aux=nuevo_elemento();
ant=nuevo_elemento();
post=nuevo_elemento();
gotoxy(18,22);
cout<<”Ingrese un elemento: “;
cin>>dat;
aux->dato=dat;
if(aux->dato>cab->dato)
{

ant=cab;
post=cab->sig;

while((aux->dato>post->dato) && (post->sig!=NULL))
{
ant=post;
post=post->sig;
}
if (post->sig==NULL)
{

if (aux->dato<post->dato){
aux->sig=post;
post->ant=aux;
ant->sig=aux;
aux->ant=ant;
}else{
aux->sig=NULL;
post->sig=aux;
aux->ant=post;
}
}
else
{
aux->sig=post;
post->ant=aux;
ant->sig=aux;
aux->ant=ant;
}
}
else{
aux->dato=dat;
aux->sig=cab;
cab->ant=aux;
aux->ant=NULL;
cab=aux;
}
}*/

void modificar(list *cab)
{

nod aux;
nododoble *ele;
modificar=nuevo_elemento();
aux= *cab;
if (!*cab) printf()
while(aux)
{
printf("=> %d ",prim->dato);
prim=prim->sig;
}break;
int db,encontrado=0;
modificar=cab;
gotoxy(10,20);
cout<<”\t”<<”INGRESE EL VALOR A MODIFICAR :\t”;
cin>> db;
while(modificar!=NULL)
{
if(db==modificar->dato)
{
gotoxy(10,22);cout<<”Elemento existente en la lista”;
encontrado=1;
gotoxy(10,25);
cout<<”\t\t”<<”INGRESE VALOR  :\t”;
cin>>ele->dato;
modificar->dato=ele->dato;

}
modificar=modificar->sig;

}
if(encontrado==0)
{
gotoxy(10,22);cout<<”Elemento no existente en la lista”;
}

getch();
}
/*
void buscar()
{
clrscr();
nododoble *buscar;
buscar=nuevo_elemento();
int db,encontrado=0;
buscar=cab;
gotoxy(18,15);
cout<<”Ingrese el numero a buscar: “;
cin>> db;
while(buscar!=NULL)
{
if(db==buscar->dato)
{
gotoxy(18,18);cout<<”Elemento existente en la lista”;
encontrado=1;
}
buscar=buscar->sig;
}
if(encontrado==0)
{
gotoxy(18,18);cout<<”Elemento no existente en la lista”;
}
getch();
}

void ordenar()
{
clrscr();
char opc=’ ‘;

do
{

clrscr();
cuadro(1,10,25,56,’’);
gotoxy(13,3);cout<<”->[ ORDENAR  LAS LISTAS ENLAZADAS ]<-\n”;
gotoxy(12,6);cout<<”    MENU PRINCIPAL\n”;
gotoxy(12,9); cout<<” [1]:  ORDENAR ASCENDENTE\n”;
gotoxy(12,12);cout<<” [2]:  ORDENAR DESCENDENTE\n”;
gotoxy(12,15);cout<<” [3]:  REGRESAR\n”;

gotoxy(12,17);cout<<” Elegir una Opci¢n [ ]“;
gotoxy(32,17);cin>>opc;
switch(opc)
{
case’1':
clrscr();
ordenardoblesasc();break;
case’2':
clrscr();
ordenardoblesdesc();break;

}

}
while(opc!=’3');

getch();

}
void ordenardoblesasc()
{
nododoble *aux;
nododoble *temp;
int vaux;
aux=nuevo_elemento();
temp=nuevo_elemento();
aux=cab;
while (aux!=NULL)
{
temp=aux;
while(temp->sig!=NULL)
{
temp=temp->sig;
if(aux->dato>temp->dato)
{
vaux=aux->dato;
aux->dato=temp->dato;
temp->dato=vaux;
}
}
aux=aux->sig;
}
}
void ordenardoblesdesc()
{
nododoble *aux;
nododoble *temp;
int vaux;
aux=nuevo_elemento();
temp=nuevo_elemento();
aux=cab;
while (aux!=NULL)
{
temp=aux;
while(temp->sig!=NULL)
{
temp=temp->sig;
if(aux->dato<temp->dato)
{
vaux=aux->dato;
aux->dato=temp->dato;
temp->dato=vaux;
}
}
aux=aux->sig;
}
}

void presentar(list cab)
{

list  aux;
aux=nuevo_elemento();
aux=cab;
if(!cab) printf("\n Lista vacia");
else {printf("\n  ELEMENTOS INSERTADOS: \n");
while(aux)
{
printf("- %d ",&aux->dato);
aux=aux->sig;
}
}
}

void eliminar()
{
presentar();
nododoble *eliminar;
nododoble *asigna;
gotoxy(10,25);cout<<”ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»\n”;
gotoxy(10,26);cout<<”º                          º\n”;
gotoxy(10,27);cout<<”ºINSERTAR NUMERO A ELIMINARº\n”;
gotoxy(10,28);cout<<”º                          º\n”;
gotoxy(10,29);cout<<”ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼\n”;
gotoxy(10,31);cout<<”Ingrese el n—mero a eliminar\t”;
cin>>eliminar->dato;
if (eliminar->dato==cab->dato)
{

eliminar_cabeza();
}

else
{
nododoble *anterior=cab;
nododoble * aux=cab->sig;

while((aux!=NULL)&&(aux->dato!=eliminar->dato))
{
anterior=aux;
aux=aux->sig;
}
if(aux!=NULL)
{
asigna=aux->sig;
anterior->sig=asigna;
aux->ant=anterior;
aux->ant=NULL;
aux->sig=NULL;
free(aux);
}
else
{
gotoxy(10,33);
cout<<”NO SE ENCUENTRA”;
}
}

}

void eliminar_cabeza()
{
nododoble *aux;
aux=cab;
cab=cab->sig;
aux->sig=NULL;
aux->ant=NULL;
free(aux);
}

void cuadro(int x1,int y1, int x2, int y2, char simb)
{
for (int i1=y1;i1<=y2;i1++)
{
gotoxy(i1,x1);cout<<simb;
gotoxy(i1,x2);cout<<simb;
}
for (int i2=x1;i2<=x2;i2++)
{
gotoxy(y1,i2);cout<<simb;
gotoxy(y2,i2);cout<<simb;
}
}

*/
