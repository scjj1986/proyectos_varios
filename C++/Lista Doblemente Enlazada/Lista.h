#ifndef LISTA_H
#define LISTA_H

#include <iostream>
#include "time.h"
#include <fstream>
#include <string>
#include "Nodo.h"
#include "Nodo.cpp"

using namespace std;

template <class T>
class Lista
{

  public:
    T ele;
    int num_nodos;
    Nodo<T> *head;
    Lista();
    ~Lista();

    void print();
    void add_end(T);
    void add_head(T);
    void search(T);
    void edit_pos(int,int);
    void sort();
};

#endif // LISTA_H
