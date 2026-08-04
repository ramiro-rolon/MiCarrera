#ifndef LISTA_DOBLE_H
#define LISTA_DOBLE_H

#include <iostream>

using namespace std;

/*
 * ESTRUCTURA DE DATA: LISTA DOBLEMENTE ENLAZADA
 * Basada en las pautas y diapositivas de la materia:
 * Cada nodo contiene un dato y dos punteros: 'siguiente' y 'anterior'.
 */

// Estructura del Nodo para la Lista Doblemente Enlazada (Template para reutilizar en Paciente, Doctor y Turno)
template <typename T>
struct NodoDoble {
    T dato;
    NodoDoble<T>* siguiente;
    NodoDoble<T>* anterior;

    // Constructor de nodo equivalente a 'crearNodoDoble'
    NodoDoble(T val) {
        dato = val;
        siguiente = nullptr;
        anterior = nullptr;
    }
};

// Clase que administra la Lista Doblemente Enlazada
template <typename T>
class ListaDoble {
private:
    NodoDoble<T>* cabeza;
    NodoDoble<T>* cola;
    int cantidad;

public:
    // Constructor: Inicializa la lista vacía
    ListaDoble() {
        cabeza = nullptr;
        cola = nullptr;
        cantidad = 0;
    }

    // Destructor: Libera de memoria dinámica todos los nodos
    ~ListaDoble() {
        vaciar();
    }

    // Retorna si la lista está vacía
    bool estaVacia() const {
        return cabeza == nullptr;
    }

    // Retorna la cantidad de elementos en la lista
    int tamano() const {
        return cantidad;
    }

    // Retorna el primer nodo
    NodoDoble<T>* getCabeza() const {
        return cabeza;
    }

    // Función 'agregarNodoAlFinal' tal como se explica en las filminas
    void agregarNodoAlFinal(T dato) {
        NodoDoble<T>* nuevo = new NodoDoble<T>(dato);
        if (cabeza == nullptr) {
            cabeza = nuevo;
            cola = nuevo;
        } else {
            cola->siguiente = nuevo;
            nuevo->anterior = cola;
            cola = nuevo;
        }
        cantidad++;
    }

    // Buscar un elemento por su ID (todas las entidades Paciente, Doctor y Turno tienen getId())
    T* buscarPorId(int id) {
        NodoDoble<T>* aux = cabeza;
        while (aux != nullptr) {
            if (aux->dato.getId() == id) {
                return &(aux->dato); // Retorna puntero al objeto encontrado
            }
            aux = aux->siguiente;
        }
        return nullptr; // No se encontró
    }

    // Buscar Paciente por DNI (Requerimiento especial solicitado por el usuario)
    T* buscarPorDNI(double dni) {
        NodoDoble<T>* aux = cabeza;
        while (aux != nullptr) {
            if (aux->dato.getDni() == dni) {
                return &(aux->dato);
            }
            aux = aux->siguiente;
        }
        return nullptr;
    }

    // Eliminar un nodo de la lista doblemente enlazada por su ID
    bool eliminarPorId(int id) {
        NodoDoble<T>* aux = cabeza;

        while (aux != nullptr) {
            if (aux->dato.getId() == id) {
                // Caso 1: El nodo a eliminar es el primero (cabeza)
                if (aux == cabeza) {
                    cabeza = aux->siguiente;
                    if (cabeza != nullptr) {
                        cabeza->anterior = nullptr;
                    } else {
                        cola = nullptr; // La lista quedó vacía
                    }
                }
                // Caso 2: El nodo a eliminar es el último (cola)
                else if (aux == cola) {
                    cola = aux->anterior;
                    if (cola != nullptr) {
                        cola->siguiente = nullptr;
                    } else {
                        cabeza = nullptr;
                    }
                }
                // Caso 3: El nodo está en el medio
                else {
                    aux->anterior->siguiente = aux->siguiente;
                    aux->siguiente->anterior = aux->anterior;
                }

                delete aux; // Liberar memoria dinámica
                cantidad--;
                return true; // Eliminado exitosamente
            }
            aux = aux->siguiente;
        }

        return false; // No se encontró el ID
    }

    // Vaciar toda la lista y liberar memoria
    void vaciar() {
        NodoDoble<T>* aux = cabeza;
        while (aux != nullptr) {
            NodoDoble<T>* sig = aux->siguiente;
            delete aux;
            aux = sig;
        }
        cabeza = nullptr;
        cola = nullptr;
        cantidad = 0;
    }
};

#endif // LISTA_DOBLE_H
