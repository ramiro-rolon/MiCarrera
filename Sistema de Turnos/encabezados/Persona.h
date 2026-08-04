#ifndef PERSONA_H
#define PERSONA_H

#include <string>

using namespace std;

// Clase Base Persona (Demuestra Programación Orientada a Objetos - Herencia)
class Persona {
protected:
    string nombre;
    string apellido;

public:
    // Constructor por defecto y parametrizado
    Persona() : nombre(""), apellido("") {}
    Persona(string n, string a) : nombre(n), apellido(a) {}

    // Destructor virtual para asegurar limpieza de memoria en clases derivadas
    virtual ~Persona() {}

    // Setters
    void setNombre(const string& n) { this->nombre = n; }
    void setApellido(const string& a) { this->apellido = a; }

    // Getters
    string getNombre() const { return this->nombre; }
    string getApellido() const { return this->apellido; }
    string getNombreCompleto() const { return this->nombre + " " + this->apellido; }
};

#endif // PERSONA_H
