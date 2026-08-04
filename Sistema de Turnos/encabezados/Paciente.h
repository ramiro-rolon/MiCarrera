#ifndef PACIENTE_H
#define PACIENTE_H

#include "Persona.h"
#include <iostream>
#include <iomanip>
#include <sstream>

// Clase Paciente que hereda de Persona
class Paciente : public Persona {
private:
    int id;
    double dni;
    string obraSocial;

public:
    // Constructores
    Paciente() : Persona(), id(0), dni(0), obraSocial("") {}
    Paciente(int id, string nombre, string apellido, double dni, string obraSocial)
        : Persona(nombre, apellido), id(id), dni(dni), obraSocial(obraSocial) {}

    // Setters
    void setId(int id) { this->id = id; }
    void setDni(double dni) { this->dni = dni; }
    void setObraSocial(const string& os) { this->obraSocial = os; }

    // Getters
    int getId() const { return this->id; }
    double getDni() const { return this->dni; }
    string getObraSocial() const { return this->obraSocial; }

    // Imprimir los datos del Paciente en formato claro
    void mostrarInfo() const {
        cout << left << setw(6) << id 
             << setw(20) << getNombreCompleto() 
             << setw(15) << fixed << setprecision(0) << dni 
             << setw(20) << obraSocial << endl;
    }

    // Convierte el objeto a una cadena para guardar en el archivo (delimitado por ';')
    string toFileString() const {
        ostringstream oss;
        oss << id << ";" << nombre << ";" << apellido << ";" << fixed << setprecision(0) << dni << ";" << obraSocial;
        return oss.str();
    }

    // Reconstruye el objeto desde una línea del archivo
    static Paciente fromFileString(const string& linea) {
        stringstream ss(linea);
        string idStr, nom, ape, dniStr, os;
        
        getline(ss, idStr, ';');
        getline(ss, nom, ';');
        getline(ss, ape, ';');
        getline(ss, dniStr, ';');
        getline(ss, os, ';');

        int id = idStr.empty() ? 0 : stoi(idStr);
        double dni = dniStr.empty() ? 0 : stod(dniStr);

        return Paciente(id, nom, ape, dni, os);
    }
};

#endif // PACIENTE_H
