#ifndef GESTOR_ARCHIVO_H
#define GESTOR_ARCHIVO_H

#include <fstream>
#include <iostream>
#include <string>
#include "Paciente.h"
#include "Doctor.h"
#include "Turno.h"
#include "Especialidad.h"
#include "ListaDoble.h"

using namespace std;

/*
 * ============================================================================
 * CLASE: GestorArchivo
 * ============================================================================
 * Esta clase se encarga de la persistencia de datos en disco (archivos .txt).
 * Utiliza los flujos estandar de C++ (std::ofstream para escribir y std::ifstream
 * para leer).
 * 
 * Logica general de guardado:
 * 1. Abre o crea el archivo especificado.
 * 2. Recorre el puntero de la Lista Doblemente Enlazada (desde la cabeza hasta NULL).
 * 3. En cada nodo, llama al metodo 'toFileString()' del objeto para formatear
 *    sus atributos separados por ';' y los escribe en una linea del archivo.
 * 4. Cierra el archivo liberando el recurso.
 * 
 * Logica general de lectura:
 * 1. Abre el archivo en modo lectura.
 * 2. Lee cada linea usando 'getline(archivo, linea)'.
 * 3. Reconstruye el objeto correspondiente usando 'fromFileString(linea)'.
 * 4. Inserta el objeto al final de la Lista Doblemente Enlazada.
 * 5. Cierra el archivo.
 * ============================================================================
 */
class GestorArchivo {
public:

    // ========================================================================
    // SECCION 1: GESTION DE ESPECIALIDADES EN ARCHIVO (especialidades.txt)
    // ========================================================================

    // Guardar lista de Especialidades en archivo
    static bool guardarEspecialidades(const ListaDoble<Especialidad>& lista, const string& ruta = "especialidades.txt") {
        ofstream archivo(ruta);
        if (!archivo.is_open()) {
            cerr << "[ERROR]: No se pudo abrir el archivo " << ruta << " para guardar." << endl;
            return false;
        }

        NodoDoble<Especialidad>* aux = lista.getCabeza();
        while (aux != nullptr) {
            archivo << aux->dato.toFileString() << "\n";
            aux = aux->siguiente;
        }

        archivo.close();
        return true;
    }

    // Cargar lista de Especialidades desde archivo
    static bool cargarEspecialidades(ListaDoble<Especialidad>& lista, const string& ruta = "especialidades.txt") {
        ifstream archivo(ruta);
        if (!archivo.is_open()) {
            return false;
        }

        lista.vaciar();

        string linea;
        while (getline(archivo, linea)) {
            if (!linea.empty()) {
                Especialidad esp = Especialidad::fromFileString(linea);
                lista.agregarNodoAlFinal(esp);
            }
        }

        archivo.close();
        return true;
    }

    // ========================================================================
    // SECCION 2: GESTION DE PACIENTES EN ARCHIVO (pacientes.txt)
    // ========================================================================

    // Guardar lista de Pacientes en archivo
    static bool guardarPacientes(const ListaDoble<Paciente>& lista, const string& ruta = "pacientes.txt") {
        ofstream archivo(ruta);
        if (!archivo.is_open()) {
            cerr << "[ERROR]: No se pudo abrir el archivo " << ruta << " para guardar." << endl;
            return false;
        }

        NodoDoble<Paciente>* aux = lista.getCabeza();
        while (aux != nullptr) {
            archivo << aux->dato.toFileString() << "\n";
            aux = aux->siguiente;
        }

        archivo.close();
        return true;
    }

    // Cargar lista de Pacientes desde archivo
    static bool cargarPacientes(ListaDoble<Paciente>& lista, const string& ruta = "pacientes.txt") {
        ifstream archivo(ruta);
        if (!archivo.is_open()) {
            return false;
        }

        lista.vaciar();

        string linea;
        while (getline(archivo, linea)) {
            if (!linea.empty()) {
                Paciente p = Paciente::fromFileString(linea);
                lista.agregarNodoAlFinal(p);
            }
        }

        archivo.close();
        return true;
    }

    // ========================================================================
    // SECCION 3: GESTION DE DOCTORES EN ARCHIVO (doctores.txt)
    // ========================================================================

    // Guardar lista de Doctores en archivo
    static bool guardarDoctores(const ListaDoble<Doctor>& lista, const string& ruta = "doctores.txt") {
        ofstream archivo(ruta);
        if (!archivo.is_open()) {
            cerr << "[ERROR]: No se pudo abrir el archivo " << ruta << " para guardar." << endl;
            return false;
        }

        NodoDoble<Doctor>* aux = lista.getCabeza();
        while (aux != nullptr) {
            archivo << aux->dato.toFileString() << "\n";
            aux = aux->siguiente;
        }

        archivo.close();
        return true;
    }

    // Cargar lista de Doctores desde archivo (resolviendo la relacion con Especialidad)
    static bool cargarDoctores(ListaDoble<Doctor>& lista, ListaDoble<Especialidad>& listaEspecialidades, const string& ruta = "doctores.txt") {
        ifstream archivo(ruta);
        if (!archivo.is_open()) {
            return false;
        }

        lista.vaciar();

        string linea;
        while (getline(archivo, linea)) {
            if (!linea.empty()) {
                Doctor d = Doctor::fromFileString(linea);
                // Relacionar el ID de especialidad guardado en el archivo con el objeto Especialidad real
                Especialidad* esp = listaEspecialidades.buscarPorId(d.getEspecialidad().getId());
                if (esp != nullptr) {
                    d.setEspecialidad(*esp);
                } else {
                    d.setEspecialidad(Especialidad(d.getEspecialidad().getId(), "Desconocida"));
                }
                lista.agregarNodoAlFinal(d);
            }
        }

        archivo.close();
        return true;
    }

    // ========================================================================
    // SECCION 4: GESTION DE TURNOS EN ARCHIVO (turnos.txt)
    // ========================================================================

    // Guardar lista de Turnos en archivo
    static bool guardarTurnos(const ListaDoble<Turno>& lista, const string& ruta = "turnos.txt") {
        ofstream archivo(ruta);
        if (!archivo.is_open()) {
            cerr << "[ERROR]: No se pudo abrir el archivo " << ruta << " para guardar." << endl;
            return false;
        }

        NodoDoble<Turno>* aux = lista.getCabeza();
        while (aux != nullptr) {
            archivo << aux->dato.toFileString() << "\n";
            aux = aux->siguiente;
        }

        archivo.close();
        return true;
    }

    // Cargar lista de Turnos desde archivo
    static bool cargarTurnos(ListaDoble<Turno>& lista, const string& ruta = "turnos.txt") {
        ifstream archivo(ruta);
        if (!archivo.is_open()) {
            return false;
        }

        lista.vaciar();

        string linea;
        while (getline(archivo, linea)) {
            if (!linea.empty()) {
                Turno t = Turno::fromFileString(linea);
                lista.agregarNodoAlFinal(t);
            }
        }

        archivo.close();
        return true;
    }
};

#endif // GESTOR_ARCHIVO_H
