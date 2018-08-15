#include "Nodo.h"

//constructor por defecto
template<typename T>
Nodo<T>::Nodo()
{
  //dato = NULL;
  sgte = NULL;
  ant =NULL;
}

//constructor por parametro
template<typename T>
Nodo<T>::Nodo(T dato_)
{
  dato = dato_;
  sgte = NULL;
  ant = NULL;
}

//imprimir un nodo
template<typename T>
void Nodo<T>::print()
{
  //cout << "Nodo-> " << "Dato: " << dato << " Direcion: " << this << " Siguiente: " << sgte << endl;
  cout << "-> ";
  cout << dato ;
}

template<typename T>
Nodo<T>::~Nodo(){}
