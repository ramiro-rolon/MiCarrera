#ifndef DOCTOR_H
#define DOCTOR_H

#include "Persona.h"
#include "Especialidad.h"
#include <iostream>
#include <iomanip>
#include <sstream>

// Clase Doctor que hereda de Persona
class Doctor : public Persona {
private:
    int id;
    Especialidad especialidad;
    string matricula;

public:
    // Constructores
    Doctor() : Persona(), id(0), especialidad(), matricula("") {}
    Doctor(int id, string nombre, string apellido, Especialidad especialidad, string matricula)
        : Persona(nombre, apellido), id(id), especialidad(especialidad), matricula(matricula) {}

    // Setters
    void setId(int id) { this->id = id; }
    void setEspecialidad(const Especialidad& esp) { this->especialidad = esp; }
    void setMatricula(const string& mat) { this->matricula = mat; }

    // Getters
    int getId() const { return this->id; }
    Especialidad getEspecialidad() const { return this->especialidad; }
    string getMatricula() const { return this->matricula; }

    // Imprimir los datos del Doctor en formato de tabla por consola
    void mostrarInfo() const {
        cout << left << setw(6) << id 
             << setw(20) << getNombreCompleto() 
             << setw(20) << especialidad.getNombre() 
             << setw(15) << matricula << endl;
    }

    // Serializacion para archivo de texto (delimitado por ';')
    // Guardamos el ID de la especialidad
    string toFileString() const {
        ostringstream oss;
        oss << id << ";" << nombre << ";" << apellido << ";" << especialidad.getId() << ";" << matricula;
        return oss.str();
    }

    // Deserializacion desde archivo
    // Creamos una especialidad temporal con solo el ID, que sera resuelta al cargar el archivo
    static Doctor fromFileString(const string& linea) {
        stringstream ss(linea);
        string idStr, nom, ape, espIdStr, mat;
        
        getline(ss, idStr, ';');
        getline(ss, nom, ';');
        getline(ss, ape, ';');
        getline(ss, espIdStr, ';');
        getline(ss, mat, ';');

        int id = idStr.empty() ? 0 : stoi(idStr);
        int espId = espIdStr.empty() ? 0 : stoi(espIdStr);

        return Doctor(id, nom, ape, Especialidad(espId, ""), mat);
    }
};

#endif // DOCTOR_H
