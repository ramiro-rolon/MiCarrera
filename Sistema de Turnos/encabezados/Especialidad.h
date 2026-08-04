#ifndef ESPECIALIDAD_H
#define ESPECIALIDAD_H

#include <iostream>
#include <iomanip>
#include <sstream>
#include <string>

using namespace std;

// Clase Especialidad para doctores y turnos
class Especialidad {
private:
    int id;
    string nombre;

public:
    // Constructores
    Especialidad() : id(0), nombre("") {}
    Especialidad(int id, string nombre) : id(id), nombre(nombre) {}

    // Getters y Setters
    int getId() const { return id; }
    void setId(int id) { this->id = id; }

    string getNombre() const { return nombre; }
    void setNombre(const string& nombre) { this->nombre = nombre; }

    // Imprimir info por pantalla (sin acentos)
    void mostrarInfo() const {
        cout << left << setw(6) << id 
             << setw(30) << nombre << endl;
    }

    // Serialización para archivo
    string toFileString() const {
        return to_string(id) + ";" + nombre;
    }

    // Deserialización
    static Especialidad fromFileString(const string& linea) {
        stringstream ss(linea);
        string idStr, nom;
        
        getline(ss, idStr, ';');
        getline(ss, nom, ';');

        int id = idStr.empty() ? 0 : stoi(idStr);
        return Especialidad(id, nom);
    }
};

#endif // ESPECIALIDAD_H
