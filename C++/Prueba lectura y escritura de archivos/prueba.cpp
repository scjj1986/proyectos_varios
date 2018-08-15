#include <iostream>
#include <fstream>
#include <string>
 
using namespace std;
 
int main() {
    string linea;
    fstream entrada ( "hombres.txt" );
    ofstream salida ("salida.txt");
 
    if (salida.is_open()) {
        if (entrada.is_open()){
            while (getline (entrada,linea)) {
                salida << linea << endl;
            }
            entrada.close(); // No necesario, se cerrara al salir del bloque
        }
        else {
            cout << "No se ha podido abrir entrada.txt!";
        }
        salida.close(); // No necesario, se cerrara al salir del bloque
    }
    else {
        cout << "No se ha podido crear salida.txt!";
    }
    return 0;
}
