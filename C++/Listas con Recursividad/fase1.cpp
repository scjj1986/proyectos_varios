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
using namespace std;
class nodo{
        public:
		char info[40];
		nodo *sig;
		nodo(){
        
        strcpy(info," ");
        sig = NULL;       
        }
		void llenar() {
			
			printf("Ingrese el dato (irrepetible): \n ");
    		gets(info);
		}	
	};
typedef nodo *pnodo;

class lista{
      
      public:
      pnodo primero,ultimo;
      nodo *temp;
      int i;
      lista(){
      primero=NULL;
      ultimo=NULL;
      temp=NULL;
      i=0;        
      }
      void ingresar_inicio (pnodo nuevo) {	
    		if (!primero){
    			ultimo=nuevo;
    		}
    		else{
    			
    			nuevo->sig=primero;
    		}
    		primero=nuevo;
    	}
    	void ingresar_fin (pnodo nuevo) {	
    		if (!ultimo){
    			primero=nuevo;
    		}
    		else{
    			
    			ultimo->sig=nuevo;
    		}
    		ultimo=nuevo;
    	}
    	void mostrar (pnodo aux){
    		
    		if (aux){
    			
    			printf ("\n*%s",aux->info);
    			mostrar(aux->sig);
    		}
    	}
    	bool encontrar (pnodo aux,char valor[]){	
    		if (!aux){
    			return false;
    		}
    		else if (strcmp(aux->info,valor)==0){
    			return true;
    		}
    		else{
    			i++;
    			return encontrar (aux->sig,valor);
    		}
    	}
    	
    	bool eliminar (char valor[]){
    		if (strcmp(ultimo->info,valor)==0){
                                             
                                             printf("iguales");
                                             }
    		if (temp!=NULL){
    		if (strcmp(primero->info,valor)==0){
    			if (primero==ultimo){
    				primero=NULL;
    				ultimo=NULL;
    			}
    			else{
    				primero=primero->sig;
    			}
    			return true;
    			
    		}
    		else if (temp->sig!=NULL) {
                    
                     if ((strcmp(temp->sig->info,valor)==0)){
                          temp->sig=temp->sig->sig;
                          if (strcmp(ultimo->info,valor)==0){
  				             ultimo=temp; 
                                              
                          }
                          return true;                  
                   }
                   else{
                        
                        temp=temp->sig;
    			        return eliminar(valor);     
                   }
            
   			}
    			
    		else if(strcmp(temp->info,valor)!=0){
                 temp=temp->sig;
    			return eliminar(valor);
    		}}
    	}      
};

int main() /*principal*/
    {
    	lista l;
    	nodo *nuevo;
        pnodo aux;
    	int i=1;
    	char opc[10],valor[20];
    	printf("\nPrograma que almacena nodos en lista de manera recursiva\n");
    	bool salir=false;
    	while (salir==false){	
    		printf("\nAbanico de Opciones:\n");
    		printf("\n1) para ingresar un nodo como pila.");
    		printf("\n2) para ingresar un nodo como cola.");
    		printf("\n3) para recorrer la lista.");
    		printf("\n4) para eliminar un nodo de la lista.");
    		printf("\n5) para buscar un nodo en la lista:");
    		gets(opc);
    		while ( (strcmp(opc,"1")!=0) && (strcmp(opc,"2")!=0) && (strcmp(opc,"3")!=0) && (strcmp(opc,"4")!=0) && (strcmp(opc,"5")!=0) ){
    			printf("\nOpcion incorrecta. Ingrese nuevamente dicho valor:");
    			gets(opc);
    		}
    		system("cls");
    		if (strcmp(opc,"1")==0){
    			nuevo=new nodo();
    			nuevo->llenar();
    			aux=l.primero;
    			i=1;
    			while (l.encontrar(aux,nuevo->info)){
    				printf("\nError. El valor del nodo debe ser irrepetible. Ingrese nuevamente dicho valor:");
    				nuevo->llenar();
    				aux=l.primero;
    			}
    			system("cls");
    			l.ingresar_inicio(nuevo);
    			printf("\nAsi queda nuestra lista:");
    			aux=l.primero;
    			l.mostrar(aux);
    		} else if (strcmp(opc,"2")==0){
    			nuevo=new nodo();
    			nuevo->llenar();
    			aux=l.primero;
    			i=1;
    			while (l.encontrar(aux,nuevo->info)){
    				printf("\nError. El valor del nodo debe ser irrepetible. Ingrese nuevamente dicho valor:");
    				nuevo->llenar();
    				aux=l.primero;
    			}
    			system("cls");
    			l.ingresar_fin(nuevo);
    			printf("\nAsi queda nuestra lista:");
    			aux=l.primero;
    			l.mostrar(aux);
    		} else if (strcmp(opc,"3")==0){
    			if (l.primero==NULL){
    				printf("\nLista vacia.");
    			}
    			else{
    				aux=l.primero;
    				printf("\nLista:");
    				l.mostrar(aux);		
    			}    			
    		} else if (strcmp(opc,"4")==0){
    			
    			if (l.primero){   				
    				printf("\nA continuacion se mostrara la lista:");
    				aux=l.primero;
    				l.mostrar(aux);
    				printf("\nIngrese el valor a eliminar:");
    				gets(valor);
    				aux=l.primero;
    				i=1;
    				while (l.encontrar(aux,valor)==false){
    					printf("\nValor no encontrado.Ingrese nuevamente dicho valor:");
    					gets(valor);
    					aux=l.primero;
    				}
    				system("cls");
    				l.temp=l.primero;
    				bool ax=l.eliminar(valor);
    				if (l.primero){
    					printf("\nY asi queda la lista:");
    					aux=l.primero;
    					l.mostrar(aux);
    				}else{
    					
    					printf("\nYa no quedan nodos por eliminar, debido a que la lista quedo vacia");
    				}		
    			} else{
    				
    				printf("\nNo se puede realizar esta operacion, debido a que la lista esta vacia");	
    			}    			
    		} else if (strcmp(opc,"5")==0){
    			
    			if (l.primero){
    				printf("\nIngrese el valor a buscar:");
    				gets(valor);
    				aux=l.primero;
    				l.i=1;
    				if (!l.encontrar(aux,valor)){
    					printf("\nValor no encontrado.");  					
    				}
    				else{
    					printf("\nValor encontrado, se encuentra en la posicion %d de la lista",l.i);   					
    				}
    				
    			} else{
    				
    				printf("\nNo se puede realizar esta operacion, debido a que la lista esta vacia");	
    			}
    		}
    		printf("\nDesea salir de la aplicacion (s/n)?:");
    		gets(opc);
    		while ((strcmp(opc,"s")!=0) && (strcmp(opc,"S")!=0) && (strcmp(opc,"n")!=0) && (strcmp(opc,"N")!=0)){
    			
    			printf("\nOpcion incorrecta. Ingrese nuevamente el valor:");
    			gets(opc);
    		}
    		if ((strcmp(opc,"s")==0) || (strcmp(opc,"S")==0)){
    			
    			salir=true;
    		}		  		
    	}
        return 1; 	

    }	
	
