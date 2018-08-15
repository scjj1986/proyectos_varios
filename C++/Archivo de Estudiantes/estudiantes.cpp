#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <iostream>
#include <ctype.h>
#include <fstream>
#include <iomanip>
#include <dos.h>
#include <cstdio>
#include <cstdlib>
using namespace std;
char cedula[20],nombre[100],apellido[100],edad[10],sexo[10],promedio[10];
int item_cedula(char cadena[])
{
     string linea;
     int item=0;
     int i=0;
     fstream leer,leer2;
     leer.open("estudiantes.txt");
     if (leer.is_open())
     {
        while (getline(leer,linea))
        {    
              i++;
              if  (cadena==linea.substr(8,strlen(cadena))) 
              {
                 item=i;                                          
              }   
        }          
     }
     leer.close();
     return item;         
}
void mayusculizar(char cadena[])
{
   for (int i=0; i<strlen(cadena); i++)
   {
      cadena[i]=toupper(cadena[i]);
   }             
}

void obtener_datos(string linea)
{
     int i=8;
     int j=0;
     while (linea[i]!=' ')
     {
           cedula[j]=linea[i];
           i++;
           j++;      
     }
     cedula[j]='\0';
     i=i+12;
     j=0;
     while (linea[i+1]!='|')
     {
           nombre[j]=linea[i];
           i++;
           j++;      
     }
     nombre[j]='\0'; 
     i=i+14;
     j=0;
     while (linea[i+1]!='|')
     {
           apellido[j]=linea[i];
           i++;
           j++;      
     }
     apellido[j]='\0';
     i=i+10;
     j=0;
     while (linea[i+1]!='|')
     {
           edad[j]=linea[i];
           i++;
           j++;     
     }
     edad[j]='\0';
     i=i+10;
     j=0;
     while (linea[i+1]!='|')
     {
           sexo[j]=linea[i];
           i++;
           j++;      
     }
     sexo[j]='\0';    
     i=linea.size()-1;
     j=1;
     strcpy(promedio,"00");
     while (linea[i]!=' ')
     {
           promedio[j]=linea[i];
           i--;
           j--;     
     }
}

void generar_mujeresyhombres()
{
     remove("mujeres.txt");     
     remove("hombres.txt");
     fstream leer;
     string linea;
     ofstream escribir,escribir2;
     leer.open ("estudiantes.txt");
     if (leer.is_open())
     {
         escribir.open("mujeres.txt",ofstream::app);
         escribir2.open("hombres.txt",ofstream::app);               
         while (getline(leer,linea))
         {
             obtener_datos(linea);
             if (strcmp(sexo,"F")==0)
             {
                escribir <<linea<<endl;
             }
             else{
                escribir2 <<linea<<endl;
             }                
         }                                    
     }  
}

void agregar_estudiante()
{
     ofstream escribir;
     cout <<"Ingrese la c\202dula: \n";
     scanf(" %[^\n]",&cedula);
     system("cls");
     while ( (atoi(cedula)<=0) || (item_cedula(cedula)>0) )
     {
         cout <<"La c\202dula debe ser num\202rica e irrepetible. Ingrese nuevamente dicho valor: \n";        
         scanf(" %[^\n]",&cedula);
         system("cls");  
     }
     cout <<"Ingrese el nombre: \n";
     scanf(" %[^\n]",&nombre);
     mayusculizar(nombre);
     system("cls");
     cout <<"Ingrese el apellido: \n";
     scanf(" %[^\n]",&apellido);
     mayusculizar(apellido);
     system("cls");
     cout <<"Ingrese la edad:\n";
     scanf(" %[^\n]",&edad);
     while (atoi(edad)<=0)
     {
          cout <<"La edad debe ser num\202rica que mayor que 0. Ingrese nuevamente el valor correcto.\n";
          scanf(" %[^\n]",&edad);
          system("cls"); 
           
     }
     system("cls");
     cout <<"Ingrese el sexo(F/M): \n";
     scanf(" %[^\n]",&sexo);
     while (   (strcmp(sexo,"F")!=0) && (strcmp(sexo,"f")!=0) && (strcmp(sexo,"M")!=0) && (strcmp(sexo,"m")!=0) )
     {
           cout <<"Error al leer el dato de entrada. Ingrese nuevamente el valor correcto.\n";
           scanf(" %[^\n]",&sexo);
           system("cls");
           
     }
     mayusculizar(sexo);
     system("cls");
     cout <<"Ingrese el promedio (0-20):\n";
     scanf(" %[^\n]",&promedio);
     while ((atoi(promedio)<=0) || (atoi(promedio)>20))
     {
          cout <<"Error.El promedio debe ser num\202rico y oscilar entre 0 y 20. Ingrese nuevamente dicho valor.\n";
          scanf(" %[^\n]",&promedio);
          system("cls"); 
           
     }
     escribir.open("estudiantes.txt",ofstream::app);
     if (escribir.is_open())
     {
                            
        escribir <<"Cedula: "<<cedula<<" || Nombre: "<<nombre<<" || Apellido: "<<apellido<<" || Edad: "<<edad<<" || Sexo: "<<sexo<<" || Promedio: "<<promedio<<"\n";                       
     }
     escribir.close();
     generar_mujeresyhombres();
     system("cls");
     cout <<"Los datos fueron guardados exitosamente.\n";
     system("pause");
     system("cls");
}

void mostrar_datos()
{
    cout<<"\n";
    cout<<"*C\202dula: "<<cedula;
    cout<<"\n";
    cout<<"*Nombre: "<<nombre;
    cout<<"\n";
    cout<<"*Apellido: "<<apellido;
    cout<<"\n";
    cout<<"*Edad: "<<edad;
    cout<<"\n";
    cout<<"*Sexo: "<<sexo;
    cout<<"\n";
    cout<<"*Promedio: "<<promedio;
    cout<<"\n";
    cout<<"\n";      
}

void sobresalientes()
{
     fstream leer,leer2;
     string linea;
     leer.open("hombres.txt");
     int itm,i,j,mayor,aux;
     mayor=0;
     if (leer.is_open())
     {
         itm=0;
         while (getline(leer,linea))
         {     
              itm++;
              i=linea.size();
              i--;
              j=1;
              strcpy(promedio,"00");
              while (linea[i]!=' ')
              {
                    promedio[j]=linea[i];
                    i--;
                    j--;     
              }
              aux=atoi(promedio);
              if (aux>mayor)
              {
                  mayor=aux;
                  obtener_datos(linea);           
              }                   
         }
         if (itm!=0){  
            cout <<"Datos de la persona de sexo masculino con mayor promedio:\n";
            itoa(mayor,promedio,10);
            mostrar_datos();
         }
         else{         
           cout<< "\n \nNo se encuentran registrados datos de personas de sexo masculino.\n";  
         }
     } 
     leer.close();
     leer2.open("mujeres.txt");
     mayor=0;
     if (leer2.is_open())
     {
         itm=0;
         while (getline(leer2,linea))
         {     
              itm++;
              i=linea.size();
              i--;
              j=1;
              strcpy(promedio,"00");
              while (linea[i]!=' ')
              {
                    promedio[j]=linea[i];
                    i--;
                    j--;     
              }
              aux=atoi(promedio);
              if (aux>mayor)
              {
                  mayor=aux;
                  obtener_datos(linea);           
              }                   
         }  
         if (itm!=0){  
            cout <<"\n\nDatos de la persona de sexo masculino con mayor promedio:\n";
            itoa(mayor,promedio,10);
            mostrar_datos();
         }
         else{         
           cout<< "\n \nNo se encuentran registrados datos de personas de sexo femenino.\n";  
         }
     }    
     leer2.close();
     system("pause");
     system("cls");
}

void editar(int i)
{
  string linea;
  fstream entrada( "estudiantes.txt" );
  ofstream salida("estudiantes2.txt");
  int j=0;
  if (salida.is_open())
  {      
       if (entrada.is_open())
       {       
            while (getline(entrada,linea))
            {
                     j++;
                     if (j==i)
                     {
                                        
                         salida <<"Cedula: "<<cedula<<" || Nombre: "<<nombre<<" || Apellido: "<<apellido<<" || Edad: "<<edad<<" || Sexo: "<<sexo<<" || Promedio: "<<promedio<<"\n";                          
                     }
                     else
                     {
                         salida <<linea <<"\n";    
                     }                           
              }
              entrada.close();     
         }
         salida.close();
   }
   remove ("estudiantes.txt");
   rename("estudiantes2.txt","estudiantes.txt"); 
}

void editar_estudiante()
{
    char ced[20];
    string linea;
    system("cls");
    cout <<"Ingrese la c\202dula del estudiante a modificar:\n";
    scanf(" %[^\n]",&ced);
    fstream leer;
    system ("cls");
    int i=0;
    int itm=0;
    if (item_cedula(ced)>0)
    {
       cout <<"Datos del estudiante:\n\n";
       leer.open("estudiantes.txt");
       if (leer.is_open())
       {
       
            while (getline(leer,linea))
            {
            
                    itm++;
                    if (item_cedula(ced)==itm)
                    {
                          obtener_datos(linea);
                          mostrar_datos();                                              
                    }    
            }                 
       }
       leer.close();
       cout<<"\nIngrese la nueva c\202dula:\n";
       scanf(" %[^\n]",&cedula);
       system("cls");
       while ( (atoi(cedula)<=0) || ((item_cedula(cedula)!=0) && (item_cedula(cedula)!=item_cedula(ced))))
       {
       
              cout <<"La c\202dula debe ser num\202rica e irrepetible. Ingrese nuevamente dicho valor: \n";        
              scanf(" %[^\n]",&cedula);
              system("cls");          
       }
       system("cls");
       cout <<"Ingrese el nombre: \n";
       scanf(" %[^\n]",&nombre); 
       mayusculizar(nombre);
       system("cls");
       cout <<"Ingrese el apellido: \n";
       scanf(" %[^\n]",&apellido);
       mayusculizar(apellido);
       system("cls");
       cout <<"Ingrese la edad:\n";
       scanf(" %[^\n]",&edad);
       system("cls");
       while (atoi(edad)==0)
       {
          cout <<"La edad debe ser num\202rica que mayor que 0. Ingrese nuevamente el valor correcto.\n";
          scanf(" %[^\n]",&edad);
          system("cls");       
       }
       system("cls");
       cout <<"Ingrese el sexo(F/M): \n";
       scanf(" %[^\n]",&sexo);
       while (   (strcmp(sexo,"F")!=0) && (strcmp(sexo,"f")!=0) && (strcmp(sexo,"M")!=0) && (strcmp(sexo,"m")!=0) )
       {
           cout <<"Error al leer el dato de entrada. Ingrese nuevamente el valor correcto.\n";
           scanf(" %[^\n]",&sexo);
           system("cls");       
       }
       mayusculizar(sexo);
       system("cls");
       cout <<"Ingrese el promedio (0-20):\n";
       scanf(" %[^\n]",&promedio);
       while ((atoi(promedio)<=0) || (atoi(promedio)>20))
       {
          cout <<"Error.El promedio debe ser num\202rico y oscilar entre 0 y 20. Ingrese nuevamente dicho valor.\n";
          scanf(" %[^\n]",&promedio);
          system("cls"); 
           
       }
       i=item_cedula(ced);
       editar(i);
       generar_mujeresyhombres();
       cout <<"Los datos fueron modificados exitosamente.\n";                       
    }
    else
    {
       cout <<"La c\202dula no se encuentra en la base de datos\n"; 
    }
    system("pause");
    system("cls");        
}

void eliminar(int i)
{
  string linea;
  fstream entrada( "estudiantes.txt" );
  ofstream salida("estudiantes2.txt");
  int j=0;
  if (salida.is_open())
  {      
       if (entrada.is_open())
       {       
            while (getline(entrada,linea))
            {
                     j++;
                     if (j!=i)
                     {
                         salida <<linea <<"\n";    
                     }
                                                               
              }
              entrada.close(); 
                  
         }
         salida.close();
   }
   remove ("estudiantes.txt");
   rename("estudiantes2.txt","estudiantes.txt");   
}

void eliminar_estudiante()
{
     system("cls");
     char ced[20];
     cout <<"Ingrese la c\202dula del estudiante a eliminar:\n";
     scanf(" %[^\n]",&ced);
     fstream leer;
     string linea;
     system ("cls");
    int i=0;
    int itm=0;
    if (item_cedula(ced)>0)
    {
       cout <<"Datos del estudiante:\n\n";
       leer.open("estudiantes.txt");
       if (leer.is_open())
       {
       
            while (getline(leer,linea))
            {
            
                    itm++;
                    if (item_cedula(ced)==itm)
                    {
                          obtener_datos(linea);
                          mostrar_datos();                                              
                    }    
            }                 
       }
       leer.close();
       string opcion;
       cout <<"Desea eliminar este registro(s/n)?:\n";
       cin >>opcion;
       system("cls");
       while ((opcion!="s") && (opcion!="S") && (opcion!="n") && (opcion!="N") )
       {
   
           cout <<"Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n";
           cin >>opcion;
           system("cls");
        }
        system("cls");
        if ((opcion=="s") || (opcion=="S"))
        {
             i=item_cedula(ced);                      
             eliminar(i);
             generar_mujeresyhombres();
             cout <<"El registro fue eliminado satisfactoriamente.\n";                                               
        }
    }
    else
    {
     cout <<"La c\202dula no se encuentra en la base de datos.\n";   
    }
    system("pause");
    system("cls");     
}

int main()
{
    string opcion;
    bool salir;
    cout << "Bienvenidos al programa que almacena datos de los estudiantes de la UNEFA.\n";
    salir=false;
    while (!salir)
    {
         cout <<"\n***************************** Men\243 Principal ***********************************\n";
         cout <<"\n";
         cout <<"Presione '1' si desea agregar un nuevo estudiante.\n";
         cout <<"Presione '2' si desea modificar alg\243n estudiante.\n";
         cout <<"Presione '3' si desea eliminar alg\243n estudiante.\n";
         cout <<"Presione '4' para indicar la persona con mayor promedio del sexo femenino y la persona con mayor promedio del sexo masculino.\n";
         cout <<"Presione '5' para salir del programa.\n";
         cin >>opcion;
         system("cls");
         while ((opcion!="1") && (opcion!="2") && (opcion!="3") && (opcion!="4") && (opcion!="5") )//Validar la opción ingresada
         {
   
               cout <<"Error al leer el dato de entrada. Ingrese la opci\242n correcta.\n";
               cin >>opcion;
               system("cls");
         }
         system("cls");
         if (opcion=="1")
         {
                                   
             agregar_estudiante();                                               
         }
         else if (opcion=="2")
         {
                                   
             editar_estudiante();                                               
         }
         else if (opcion=="3")
         {
                                   
             eliminar_estudiante();                                               
         }
         else if (opcion=="4")
         {
                                   
             sobresalientes();                                               
         }
         else
         {
             salir=true;    
         }          
    }
    return 1;    
}
