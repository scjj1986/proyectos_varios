#include <stdio.h>
#include <iostream>

typedef struct nodo {
    int     dato;
    struct nodo *sig;
} elemento_lista;



elemento_lista *Apilar (elemento_lista *apuntlista, int dato,int i) 
{
    elemento_lista * lp = apuntlista;

    if (apuntlista != NULL) {
        apuntlista= (struct nodo *) malloc (sizeof (elemento_lista));
        apuntlista -> sig = lp;
        apuntlista -> dato = dato;
    }
    else 
    {
        apuntlista =  (struct nodo *) malloc (sizeof (elemento_lista));
        apuntlista -> sig = NULL;
        apuntlista -> dato = dato;
    }
    if (i==1){
       printf("\n Nodo agregado");
       system("PAUSE");}
    return apuntlista;
    
}

elemento_lista *Desapilar (elemento_lista *apuntlista, int i) 
{
    elemento_lista *aux;
    if (i==1){
       printf ("El elemento borrado es %d\n", apuntlista -> dato);
        system("PAUSE");}
    aux =  apuntlista -> sig;
    free (apuntlista);
    return aux;
}

void ImprPila (elemento_lista *apuntlista) 
{
    elemento_lista *aux=apuntlista;
    if (aux == NULL)
        printf ("La lista esta vacia !!\n");
    else
        while (aux != NULL) {
            printf ("%d\t", aux -> dato);
            system("PAUSE");
            aux =  aux -> sig;
        }
    printf ("\n");
    system("PAUSE");
}
elemento_lista *VerPila (elemento_lista *apuntlista) 
{
    elemento_lista *aux=NULL;
    if (apuntlista == NULL)
        printf ("La lista esta vacia !!\n");
    else{
        while (apuntlista != NULL) {
            printf ("%d\t", apuntlista -> dato);
            aux=Apilar(aux,apuntlista->dato,0);
            apuntlista= Desapilar(apuntlista,0);
        }
        while (aux != NULL) {
            apuntlista=Apilar(apuntlista,aux->dato,0);
            aux= Desapilar(aux,0);
        }
    }
    printf ("\n");
    system("PAUSE");
    return apuntlista;
}


elemento_lista *LimpPila (elemento_lista *apuntlista) 
{
    while (apuntlista != NULL) {
        apuntlista = Desapilar (apuntlista,1);
    }
    printf("\n Cola borrada");
    apuntlista=NULL;
    system("PAUSE");
    return apuntlista;
}

int main () 
{
    int opc, dato;
      elemento_lista listmember, *apuntlista;
         apuntlista = NULL;
         do
        {
			system("cls");
                printf("\nMenu:");
                printf("\n\t1. Apilar");
                printf("\n\t2. Desapilar");
                printf("\n\t3. Ver contenido de pila");
                printf("\n\t4. Ver pila");
                printf("\n\t5. Eliminar pila");
                printf("\n\t6. Salir");
                printf("\nOpcion: ");
                scanf("%d", &opc);
                switch (opc) {
            case 1: 
                printf ("Ingresa un dato que sera agregado  ");
                scanf ("%d", &dato);
                apuntlista = Apilar (apuntlista, dato,1);
                break;
            case 2: 
                if (apuntlista == NULL)
                    printf ("¡Cola vacia!\n");
                else
                    apuntlista = Desapilar (apuntlista,1);
                break;
            case 3: 
                ImprPila (apuntlista);
                    break;
            case 4: 
                apuntlista= VerPila (apuntlista);
                    break;

            case 5: 
                     apuntlista=LimpPila (apuntlista);
                break;
                case 6:
                     break;

            default: 
                printf ("Opcion no valida - intentar nuevamente\n");
                break;
        }
        }while (opc!=6);


        system("PAUSE");
        return EXIT_SUCCESS;
  
}                          

