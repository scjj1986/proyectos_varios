#include "Lista.h"

using namespace std;

//constructor por defecto
template<typename T>
Lista<T>::Lista()
{
  num_nodos = 0;
  head = NULL;
}

template<typename T>
void Lista<T>::print()
{
  Nodo<T> *temp = head;
  if(!head){
    cout << "La lista esta vacia " << endl;
  } else{
         printf ("\n");
    while(temp){
      temp->print();
      temp = temp->sgte;
    }
  }
  cout << endl << endl;
}

template<typename T>
void Lista<T>::add_end(T dato_)
{
  Nodo<T> *temp = head;
  Nodo<T> *nuevo = new Nodo<T> (dato_);

  if(!head){
      head = nuevo;
  } else{
    while(temp->sgte !=NULL){
      temp = temp->sgte;
    }
    temp->sgte = nuevo;
    nuevo->ant = temp;
  }
  printf("\n Nodo guardado exitosamente. La lista quedo de la siguiente manera: ");
  num_nodos++;
}

template<typename T>
void Lista<T>::add_head(T dato_)
{
  Nodo<T> *temp = head;
  Nodo<T> *nuevo = new Nodo<T> (dato_);

  if(!head){
    head = nuevo;
  } else{
    nuevo->sgte = head;
    head = nuevo;
    while(temp){
      temp = temp->sgte;
    }
  }
  printf("\n Nodo guardado exitosamente. La lista quedo de la siguiente manera: ");
  num_nodos++;
}

template<typename T>
void Lista<T>::search(T dato_)
{
  Nodo<T> *temp = head;
  int cont = 1;
  int cont2=0;
  printf("\n Resultado de la busqueda: \n");
  while(temp){
    if(temp->dato == dato_){
	  printf("\n El dato se encuentra en la posicion: '%d' de la lista.",cont);
	  cont2++;
    }
	temp = temp->sgte;
	cont++;
  }
  if(cont2 == 0){
    cout << "No existe el dato en la lista " << endl;
  }
  cout << endl << endl;
}

template<typename T>
void Lista<T>::edit_pos(int pos,int val)
{
  Nodo<T> *temp = head;

  
    for(int i=1;i<=pos;i++){
      if(i==pos){
        temp->dato=val;
      }
      temp = temp->sgte;
    }
    printf("\n Nodo editado exitosamente. La lista quedo de la siguiente manera: ");
    
}



template<typename T>
void Lista<T>::sort()
{
  T aux2;
  Nodo<T> *aux = head;
  Nodo<T> *temp = aux;

  while(aux){
    temp=aux;
    while(temp->sgte){
      temp=temp->sgte;

      if(aux->dato>temp->dato){
        aux2=aux->dato;
        aux->dato=temp->dato;
        temp->dato=aux2;
      }
    }
    aux=aux->sgte;
  }
}



template<typename T>
Lista<T>::~Lista(){}
