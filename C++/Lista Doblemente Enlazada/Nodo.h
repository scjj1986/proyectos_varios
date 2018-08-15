#ifndef NODO_H
#define NODO_H
#include <iostream>

using namespace std;
template <class T>
class Nodo
{
  public:
    T dato;
    Nodo *sgte;
    Nodo *ant;
    Nodo();
    Nodo(T);
    ~Nodo();

    void print();
};

#endif // NODO_H
