#include <iostream>
#include <string>
#include <iomanip>

#include "encabezados/Persona.h"
#include "encabezados/Paciente.h"
#include "encabezados/Doctor.h"
#include "encabezados/Turno.h"
#include "encabezados/Especialidad.h"
#include "encabezados/ListaDoble.h"
#include "encabezados/GestorArchivo.h"
#include "encabezados/Validaciones.h"

using namespace std;

// Listas Doblemente Enlazadas globales en memoria para la sesion activa
ListaDoble<Especialidad> listaEspecialidades;
ListaDoble<Paciente> listaPacientes;
ListaDoble<Doctor> listaDoctores;
ListaDoble<Turno> listaTurnos;

// Prototipos de funciones para resolver dependencias
void asignarTurnoConDniPaciente(double dniPaciente, bool confirmacionAutomatica = false);

// Funciones auxiliares para obtener el siguiente ID disponible
int obtenerSiguienteIdEspecialidad() {
    int maxId = 0;
    NodoDoble<Especialidad>* aux = listaEspecialidades.getCabeza();
    while (aux != nullptr) {
        if (aux->dato.getId() > maxId) maxId = aux->dato.getId();
        aux = aux->siguiente;
    }
    return maxId + 1;
}

int obtenerSiguienteIdPaciente() {
    int maxId = 0;
    NodoDoble<Paciente>* aux = listaPacientes.getCabeza();
    while (aux != nullptr) {
        if (aux->dato.getId() > maxId) maxId = aux->dato.getId();
        aux = aux->siguiente;
    }
    return maxId + 1;
}

int obtenerSiguienteIdDoctor() {
    int maxId = 0;
    NodoDoble<Doctor>* aux = listaDoctores.getCabeza();
    while (aux != nullptr) {
        if (aux->dato.getId() > maxId) maxId = aux->dato.getId();
        aux = aux->siguiente;
    }
    return maxId + 1;
}

int obtenerSiguienteIdTurno() {
    int maxId = 0;
    NodoDoble<Turno>* aux = listaTurnos.getCabeza();
    while (aux != nullptr) {
        if (aux->dato.getId() > maxId) maxId = aux->dato.getId();
        aux = aux->siguiente;
    }
    return maxId + 1;
}

// Carga inicial y creacion de especialidades por defecto si el archivo esta vacio
void inicializarEspecialidades() {
    GestorArchivo::cargarEspecialidades(listaEspecialidades);

    if (listaEspecialidades.estaVacia()) {
        listaEspecialidades.agregarNodoAlFinal(Especialidad(1, "Clinica Medica"));
        listaEspecialidades.agregarNodoAlFinal(Especialidad(2, "Cardiologia"));
        listaEspecialidades.agregarNodoAlFinal(Especialidad(3, "Pediatria"));
        listaEspecialidades.agregarNodoAlFinal(Especialidad(4, "Traumatologia"));
        listaEspecialidades.agregarNodoAlFinal(Especialidad(5, "Ginecologia"));

        GestorArchivo::guardarEspecialidades(listaEspecialidades);
    }
}

// ============================================================================
// MODULO DE PACIENTES (CRUD / ABML)
// ============================================================================

void altaPaciente() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("ALTA DE NUEVO PACIENTE");

    int id = obtenerSiguienteIdPaciente();
    cout << "ID asignado automaticamente: " << id << endl;

    string nombre = Validaciones::ingresarTexto("Ingrese Nombre: ");
    string apellido = Validaciones::ingresarTexto("Ingrese Apellido: ");
    double dni = Validaciones::ingresarDouble("Ingrese DNI: ");

    // Verificar si el DNI ya existe
    if (listaPacientes.buscarPorDNI(dni) != nullptr) {
        cout << "\n[!] ATENCION: Ya existe un paciente registrado con el DNI "
             << fixed << setprecision(0) << dni << ".\n";
        Validaciones::pausa();
        return;
    }

    string obraSocial = Validaciones::ingresarTexto("Ingrese Obra Social: ");

    Paciente p(id, nombre, apellido, dni, obraSocial);
    listaPacientes.agregarNodoAlFinal(p);
    GestorArchivo::guardarPacientes(listaPacientes);

    cout << "\n[SUCCESS] Paciente registrado exitosamente.\n\n";

    // Preguntar si desea asignarle un turno directo al paciente creado
    cout << "Desea asignarle un turno a este paciente ahora mismo?\n";
    cout << "1. Si\n";
    cout << "2. No\n";
    int opTurno = Validaciones::ingresarEntero("Seleccione una opcion: ");
    if (opTurno == 1) {
        // confirmacionAutomatica = true: omite la pregunta de confirmacion de paciente
        // ya que acabamos de crearlo y sabemos que es el correcto
        asignarTurnoConDniPaciente(dni, true);
    } else {
        Validaciones::pausa();
    }
}

void listarPacientes() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("LISTADO DE PACIENTES");

    if (listaPacientes.estaVacia()) {
        cout << "No hay pacientes registrados en el sistema.\n";
    } else {
        cout << left << setw(6) << "ID"
             << setw(20) << "Nombre Completo"
             << setw(15) << "DNI"
             << setw(20) << "Obra Social" << endl;
        cout << "------------------------------------------------------------\n";

        NodoDoble<Paciente>* aux = listaPacientes.getCabeza();
        while (aux != nullptr) {
            aux->dato.mostrarInfo();
            aux = aux->siguiente;
        }
        cout << "------------------------------------------------------------\n";
        cout << "Total de pacientes: " << listaPacientes.tamano() << endl;
    }
    Validaciones::pausa();
}

void buscarPacientePorId() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR PACIENTE POR ID");

    int id = Validaciones::ingresarEntero("Ingrese el ID del paciente a buscar: ");
    Paciente* p = listaPacientes.buscarPorId(id);

    if (p != nullptr) {
        cout << "\n[PACIENTE ENCONTRADO]:\n";
        cout << left << setw(6) << "ID"
             << setw(20) << "Nombre Completo"
             << setw(15) << "DNI"
             << setw(20) << "Obra Social" << endl;
        cout << "------------------------------------------------------------\n";
        p->mostrarInfo();
    } else {
        cout << "\n[!] No se encontro ningun paciente con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void buscarPacientePorDni() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR PACIENTE POR DNI");

    double dni = Validaciones::ingresarDouble("Ingrese el DNI del paciente a buscar: ");
    Paciente* p = listaPacientes.buscarPorDNI(dni);

    if (p != nullptr) {
        cout << "\n[PACIENTE ENCONTRADO POR DNI]:\n";
        cout << left << setw(6) << "ID"
             << setw(20) << "Nombre Completo"
             << setw(15) << "DNI"
             << setw(20) << "Obra Social" << endl;
        cout << "------------------------------------------------------------\n";
        p->mostrarInfo();
    } else {
        cout << "\n[!] No se encontro ningun paciente con el DNI "
             << fixed << setprecision(0) << dni << ".\n";
    }
    Validaciones::pausa();
}

void modificacionPaciente() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("MODIFICAR PACIENTE");

    int id = Validaciones::ingresarEntero("Ingrese el ID del paciente a modificar: ");
    Paciente* p = listaPacientes.buscarPorId(id);

    if (p != nullptr) {
        cout << "\nDatos actuales del paciente:\n";
        p->mostrarInfo();
        cout << "\nIngrese los nuevos datos:\n";

        string nombre = Validaciones::ingresarTexto("Nuevo Nombre: ");
        string apellido = Validaciones::ingresarTexto("Nuevo Apellido: ");
        double dni = Validaciones::ingresarDouble("Nuevo DNI: ");
        string obraSocial = Validaciones::ingresarTexto("Nueva Obra Social: ");

        p->setNombre(nombre);
        p->setApellido(apellido);
        p->setDni(dni);
        p->setObraSocial(obraSocial);

        GestorArchivo::guardarPacientes(listaPacientes);
        cout << "\n[SUCCESS] Paciente actualizado correctamente.\n";
    } else {
        cout << "\n[!] No se encontro ningun paciente con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void bajaPaciente() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BAJA DE PACIENTE");

    int id = Validaciones::ingresarEntero("Ingrese el ID del paciente a eliminar: ");
    Paciente* p = listaPacientes.buscarPorId(id);
    if (p != nullptr) {
        string nombrePaciente = p->getNombreCompleto();
        if (listaPacientes.eliminarPorId(id)) {
            // Dar de baja cascada a los turnos asignados a este paciente
            int turnosBaja = 0;
            NodoDoble<Turno>* aux = listaTurnos.getCabeza();
            while (aux != nullptr) {
                NodoDoble<Turno>* sig = aux->siguiente;
                if (aux->dato.getPacienteId() == id) {
                    listaTurnos.eliminarPorId(aux->dato.getId());
                    turnosBaja++;
                }
                aux = sig;
            }

            GestorArchivo::guardarPacientes(listaPacientes);
            GestorArchivo::guardarTurnos(listaTurnos);

            cout << "\n[SUCCESS] Paciente " << nombrePaciente << " (ID: " << id << ") eliminado exitosamente.\n";
            if (turnosBaja > 0) {
                cout << "[INFO] Se dieron de baja cascada " << turnosBaja << " turno(s) asociado(s) a este paciente.\n";
            }
        }
    } else {
        cout << "\n[!] No se encontro ningun paciente con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void menuPacientes() {
    int opcion;
    do {
        Validaciones::limpiarPantalla();
        Validaciones::dibujarTitulo("GESTION DE PACIENTES");
        cout << "1. Alta de Paciente\n";
        cout << "2. Listar Pacientes\n";
        cout << "3. Buscar Paciente por ID\n";
        cout << "4. Buscar Paciente por DNI\n";
        cout << "5. Modificar Paciente\n";
        cout << "6. Baja de Paciente\n";
        cout << "0. Volver al Menu Principal\n";
        cout << "------------------------------------------------------------\n";
        opcion = Validaciones::ingresarEntero("Seleccione una opcion: ");

        switch (opcion) {
            case 1: altaPaciente(); break;
            case 2: listarPacientes(); break;
            case 3: buscarPacientePorId(); break;
            case 4: buscarPacientePorDni(); break;
            case 5: modificacionPaciente(); break;
            case 6: bajaPaciente(); break;
            case 0: break;
            default:
                cout << "\n[!] Opcion no valida.\n";
                Validaciones::pausa();
                break;
        }
    } while (opcion != 0);
}

// ============================================================================
// MODULO DE DOCTORES (CRUD / ABML)
// ============================================================================

void altaDoctor() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("ALTA DE NUEVO DOCTOR");

    int id = obtenerSiguienteIdDoctor();
    cout << "ID asignado automaticamente: " << id << endl;

    string nombre = Validaciones::ingresarTexto("Ingrese Nombre: ");
    string apellido = Validaciones::ingresarTexto("Ingrese Apellido: ");

    // Mostrar lista de Especialidades disponibles
    cout << "\nEspecialidades disponibles:\n";
    cout << left << setw(6) << "ID" << setw(30) << "Especialidad" << endl;
    cout << "-------------------------------------\n";
    NodoDoble<Especialidad>* auxEsp = listaEspecialidades.getCabeza();
    while (auxEsp != nullptr) {
        auxEsp->dato.mostrarInfo();
        auxEsp = auxEsp->siguiente;
    }
    cout << "-------------------------------------\n";

    int espId;
    Especialidad* espSeleccionada = nullptr;
    while (espSeleccionada == nullptr) {
        espId = Validaciones::ingresarEntero("Seleccione el ID de la Especialidad para el Doctor: ");
        espSeleccionada = listaEspecialidades.buscarPorId(espId);
        if (espSeleccionada == nullptr) {
            cout << "[!] ID de Especialidad no valido. Intente de nuevo.\n";
        }
    }

    string matricula = Validaciones::ingresarTexto("Ingrese N° de Matricula: ");

    Doctor d(id, nombre, apellido, *espSeleccionada, matricula);
    listaDoctores.agregarNodoAlFinal(d);
    GestorArchivo::guardarDoctores(listaDoctores);

    cout << "\n[SUCCESS] Doctor registrado exitosamente.\n";
    Validaciones::pausa();
}

void listarDoctores() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("LISTADO DE DOCTORES");

    if (listaDoctores.estaVacia()) {
        cout << "No hay doctores registrados en el sistema.\n";
    } else {
        cout << left << setw(6) << "ID"
             << setw(20) << "Nombre Completo"
             << setw(20) << "Especialidad"
             << setw(15) << "Matricula" << endl;
        cout << "------------------------------------------------------------\n";

        NodoDoble<Doctor>* aux = listaDoctores.getCabeza();
        while (aux != nullptr) {
            aux->dato.mostrarInfo();
            aux = aux->siguiente;
        }
        cout << "------------------------------------------------------------\n";
        cout << "Total de doctores: " << listaDoctores.tamano() << endl;
    }
    Validaciones::pausa();
}

void buscarDoctorPorId() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR DOCTOR POR ID");

    int id = Validaciones::ingresarEntero("Ingrese el ID del doctor a buscar: ");
    Doctor* d = listaDoctores.buscarPorId(id);

    if (d != nullptr) {
        cout << "\n[DOCTOR ENCONTRADO]:\n";
        cout << left << setw(6) << "ID"
             << setw(20) << "Nombre Completo"
             << setw(20) << "Especialidad"
             << setw(15) << "Matricula" << endl;
        cout << "------------------------------------------------------------\n";
        d->mostrarInfo();
    } else {
        cout << "\n[!] No se encontro ningun doctor con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void buscarDoctorPorMatricula() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR DOCTOR POR MATRICULA");

    string mat = Validaciones::ingresarTexto("Ingrese N° de Matricula del doctor a buscar: ");
    string matLower = Validaciones::aMinusculas(mat);

    NodoDoble<Doctor>* aux = listaDoctores.getCabeza();
    Doctor* dEncontrado = nullptr;
    while (aux != nullptr) {
        if (Validaciones::aMinusculas(aux->dato.getMatricula()) == matLower) {
            dEncontrado = &(aux->dato);
            break;
        }
        aux = aux->siguiente;
    }

    if (dEncontrado != nullptr) {
        cout << "\n[DOCTOR ENCONTRADO]:\n";
        cout << left << setw(6) << "ID"
             << setw(20) << "Nombre Completo"
             << setw(20) << "Especialidad"
             << setw(15) << "Matricula" << endl;
        cout << "------------------------------------------------------------\n";
        dEncontrado->mostrarInfo();
    } else {
        cout << "\n[!] No se encontro ningun doctor con la matricula '" << mat << "'.\n";
    }
    Validaciones::pausa();
}

void buscarDoctorPorApellido() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR DOCTOR POR APELLIDO");

    string ape = Validaciones::ingresarTexto("Ingrese Apellido (o parte del apellido): ");
    string apeLower = Validaciones::aMinusculas(ape);

    int encontrados = 0;
    NodoDoble<Doctor>* aux = listaDoctores.getCabeza();
    while (aux != nullptr) {
        if (Validaciones::aMinusculas(aux->dato.getApellido()).find(apeLower) != string::npos) {
            if (encontrados == 0) {
                cout << "\n[DOCTOR(ES) ENCONTRADO(S)]:\n";
                cout << left << setw(6) << "ID"
                     << setw(20) << "Nombre Completo"
                     << setw(20) << "Especialidad"
                     << setw(15) << "Matricula" << endl;
                cout << "------------------------------------------------------------\n";
            }
            aux->dato.mostrarInfo();
            encontrados++;
        }
        aux = aux->siguiente;
    }

    if (encontrados == 0) {
        cout << "\n[!] No se encontraron doctores con el apellido '" << ape << "'.\n";
    } else {
        cout << "------------------------------------------------------------\n";
        cout << "Total encontrados: " << encontrados << endl;
    }
    Validaciones::pausa();
}

void buscarDoctorPorEspecialidad() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR DOCTORES POR ESPECIALIDAD");

    cout << "Especialidades disponibles:\n";
    cout << left << setw(6) << "ID" << setw(30) << "Especialidad" << endl;
    cout << "-------------------------------------\n";
    NodoDoble<Especialidad>* auxEsp = listaEspecialidades.getCabeza();
    while (auxEsp != nullptr) {
        auxEsp->dato.mostrarInfo();
        auxEsp = auxEsp->siguiente;
    }
    cout << "-------------------------------------\n";

    int espId = Validaciones::ingresarEntero("Seleccione ID de la Especialidad: ");
    Especialidad* esp = listaEspecialidades.buscarPorId(espId);

    if (esp == nullptr) {
        cout << "\n[!] Especialidad invalida.\n";
        Validaciones::pausa();
        return;
    }

    int encontrados = 0;
    NodoDoble<Doctor>* aux = listaDoctores.getCabeza();
    while (aux != nullptr) {
        if (aux->dato.getEspecialidad().getId() == espId) {
            if (encontrados == 0) {
                cout << "\n[DOCTORES DE LA ESPECIALIDAD " << esp->getNombre() << "]:\n";
                cout << left << setw(6) << "ID"
                     << setw(20) << "Nombre Completo"
                     << setw(20) << "Especialidad"
                     << setw(15) << "Matricula" << endl;
                cout << "------------------------------------------------------------\n";
            }
            aux->dato.mostrarInfo();
            encontrados++;
        }
        aux = aux->siguiente;
    }

    if (encontrados == 0) {
        cout << "\n[!] No hay doctores registrados para la especialidad '" << esp->getNombre() << "'.\n";
    } else {
        cout << "------------------------------------------------------------\n";
        cout << "Total encontrados: " << encontrados << endl;
    }
    Validaciones::pausa();
}

void menuBuscarDoctores() {
    int op;
    do {
        Validaciones::limpiarPantalla();
        Validaciones::dibujarTitulo("BUSQUEDA DE DOCTORES");
        cout << "1. Buscar Doctor por ID\n";
        cout << "2. Buscar Doctor por Matricula\n";
        cout << "3. Buscar Doctor por Apellido\n";
        cout << "4. Buscar Doctores por Especialidad\n";
        cout << "0. Volver a Gestion de Doctores\n";
        cout << "------------------------------------------------------------\n";
        op = Validaciones::ingresarEntero("Seleccione una opcion: ");

        switch (op) {
            case 1: buscarDoctorPorId(); break;
            case 2: buscarDoctorPorMatricula(); break;
            case 3: buscarDoctorPorApellido(); break;
            case 4: buscarDoctorPorEspecialidad(); break;
            case 0: break;
            default:
                cout << "\n[!] Opcion no valida.\n";
                Validaciones::pausa();
                break;
        }
    } while (op != 0);
}

void modificacionDoctor() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("MODIFICAR DOCTOR");

    int id = Validaciones::ingresarEntero("Ingrese el ID del doctor a modificar: ");
    Doctor* d = listaDoctores.buscarPorId(id);

    if (d != nullptr) {
        cout << "\nDatos actuales del doctor:\n";
        d->mostrarInfo();
        cout << "\nIngrese los nuevos datos:\n";

        string nombre = Validaciones::ingresarTexto("Nuevo Nombre: ");
        string apellido = Validaciones::ingresarTexto("Nuevo Apellido: ");

        // Mostrar lista de especialidades
        cout << "\nEspecialidades disponibles:\n";
        NodoDoble<Especialidad>* auxEsp = listaEspecialidades.getCabeza();
        while (auxEsp != nullptr) {
            auxEsp->dato.mostrarInfo();
            auxEsp = auxEsp->siguiente;
        }

        int espId;
        Especialidad* espSeleccionada = nullptr;
        while (espSeleccionada == nullptr) {
            espId = Validaciones::ingresarEntero("Seleccione el nuevo ID de la Especialidad: ");
            espSeleccionada = listaEspecialidades.buscarPorId(espId);
            if (espSeleccionada == nullptr) {
                cout << "[!] ID no valido. Intente de nuevo.\n";
            }
        }

        string matricula = Validaciones::ingresarTexto("Nueva Matricula: ");

        d->setNombre(nombre);
        d->setApellido(apellido);
        d->setEspecialidad(*espSeleccionada);
        d->setMatricula(matricula);

        GestorArchivo::guardarDoctores(listaDoctores);
        cout << "\n[SUCCESS] Doctor actualizado correctamente.\n";
    } else {
        cout << "\n[!] No se encontro ningun doctor con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void bajaDoctor() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BAJA DE DOCTOR");

    int id = Validaciones::ingresarEntero("Ingrese el ID del doctor a eliminar: ");
    Doctor* d = listaDoctores.buscarPorId(id);
    if (d != nullptr) {
        string nombreDoctor = d->getNombreCompleto();
        if (listaDoctores.eliminarPorId(id)) {
            // Dar de baja cascada a los turnos asignados a este doctor
            int turnosBaja = 0;
            NodoDoble<Turno>* aux = listaTurnos.getCabeza();
            while (aux != nullptr) {
                NodoDoble<Turno>* sig = aux->siguiente;
                if (aux->dato.getDoctorId() == id) {
                    listaTurnos.eliminarPorId(aux->dato.getId());
                    turnosBaja++;
                }
                aux = sig;
            }

            GestorArchivo::guardarDoctores(listaDoctores);
            GestorArchivo::guardarTurnos(listaTurnos);

            cout << "\n[SUCCESS] Doctor " << nombreDoctor << " (ID: " << id << ") eliminado exitosamente.\n";
            if (turnosBaja > 0) {
                cout << "[INFO] Se dieron de baja cascada " << turnosBaja << " turno(s) asociado(s) a este doctor.\n";
            }
        }
    } else {
        cout << "\n[!] No se encontro ningun doctor con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void menuDoctores() {
    int opcion;
    do {
        Validaciones::limpiarPantalla();
        Validaciones::dibujarTitulo("GESTION DE DOCTORES");
        cout << "1. Alta de Doctor\n";
        cout << "2. Listar Doctores\n";
        cout << "3. Buscar Doctor (ID, Matricula, Apellido, Especialidad)\n";
        cout << "4. Modificar Doctor\n";
        cout << "5. Baja de Doctor\n";
        cout << "0. Volver al Menu Principal\n";
        cout << "------------------------------------------------------------\n";
        opcion = Validaciones::ingresarEntero("Seleccione una opcion: ");

        switch (opcion) {
            case 1: altaDoctor(); break;
            case 2: listarDoctores(); break;
            case 3: menuBuscarDoctores(); break;
            case 4: modificacionDoctor(); break;
            case 5: bajaDoctor(); break;
            case 0: break;
            default:
                cout << "\n[!] Opcion no valida.\n";
                Validaciones::pausa();
                break;
        }
    } while (opcion != 0);
}

// ============================================================================
// MODULO DE TURNOS (ASIGNACION Y GESTION)
// ============================================================================

// Algoritmo centralizado para dar de alta un turno con DNI del paciente ya resuelto o a solicitar
void asignarTurnoConDniPaciente(double dniPaciente, bool confirmacionAutomatica) {
    if (listaPacientes.estaVacia()) {
        cout << "[!] No hay pacientes registrados. Primero debe dar de alta un paciente.\n";
        Validaciones::pausa();
        return;
    }

    if (listaDoctores.estaVacia()) {
        cout << "[!] No hay doctores registrados. Primero debe dar de alta un doctor.\n";
        Validaciones::pausa();
        return;
    }

    // 1. Validacion del Paciente por DNI
    Paciente* p = listaPacientes.buscarPorDNI(dniPaciente);
    if (p == nullptr) {
        cout << "\n[!] ERROR: No existe un paciente registrado con el DNI "
             << fixed << setprecision(0) << dniPaciente << ".\n";
        Validaciones::pausa();
        return;
    }

    cout << "\nPaciente seleccionado: " << p->getNombreCompleto() << " (DNI: "
         << fixed << setprecision(0) << p->getDni() << ")\n";

    // Si la confirmacion NO es automatica, pedimos al usuario que confirme la identidad
    if (!confirmacionAutomatica) {
        cout << "Es este el paciente que desea registrar para el turno?\n";
        cout << "1. Si\n";
        cout << "2. No\n";
        int confirmacion = Validaciones::ingresarEntero("Seleccione opcion: ");
        if (confirmacion != 1) {
            cout << "\n[!] Operacion cancelada. Volviendo al menu.\n";
            Validaciones::pausa();
            return;
        }
    }

    // 2. Seleccion de la Especialidad Medica
    cout << "\nSeleccione la Especialidad medica para el turno:\n";
    NodoDoble<Especialidad>* auxEsp = listaEspecialidades.getCabeza();
    while (auxEsp != nullptr) {
        auxEsp->dato.mostrarInfo();
        auxEsp = auxEsp->siguiente;
    }
    int espId = Validaciones::ingresarEntero("Seleccione ID de la especialidad: ");
    Especialidad* esp = listaEspecialidades.buscarPorId(espId);
    if (esp == nullptr) {
        cout << "\n[!] Especialidad no valida. Operacion cancelada.\n";
        Validaciones::pausa();
        return;
    }

    // 3. Filtrar y mostrar los doctores de esa Especialidad
    cout << "\nDoctores disponibles de la especialidad: " << esp->getNombre() << "\n";

    int totalFiltrados = 0;
    Doctor* doctoresFiltrados[100];

    NodoDoble<Doctor>* auxDoc = listaDoctores.getCabeza();
    while (auxDoc != nullptr) {
        if (auxDoc->dato.getEspecialidad().getId() == espId) {
            doctoresFiltrados[totalFiltrados] = &(auxDoc->dato);
            totalFiltrados++;
            cout << totalFiltrados << ". Dr/Dra. " << auxDoc->dato.getNombreCompleto()
                 << " (Matricula: " << auxDoc->dato.getMatricula() << ")\n";
        }
        auxDoc = auxDoc->siguiente;
    }

    if (totalFiltrados == 0) {
        cout << "[!] No hay doctores disponibles para esta especialidad medica.\n";
        Validaciones::pausa();
        return;
    }

    int seleccionDoc = Validaciones::ingresarEntero("\nSeleccione el numero de Doctor de la lista: ");
    if (seleccionDoc < 1 || seleccionDoc > totalFiltrados) {
        cout << "[!] Seleccion invalida. Operacion cancelada.\n";
        Validaciones::pausa();
        return;
    }

    Doctor* d = doctoresFiltrados[seleccionDoc - 1];
    cout << "Doctor seleccionado: " << d->getNombreCompleto() << "\n\n";

    // 4. Ingreso de Fecha (futura/hoy), Hora y asignacion del Turno
    string fecha = Validaciones::ingresarFechaFutura("Ingrese Fecha (DD/MM/AAAA): ");
    string hora = Validaciones::ingresarTexto("Ingrese Hora (Ej: HH:MM): ");

    int idTurno = obtenerSiguienteIdTurno();

    // El turno se asigna por defecto con estado "Pendiente"
    Turno t(idTurno, p->getId(), d->getId(), fecha, hora, "Pendiente");
    listaTurnos.agregarNodoAlFinal(t);
    GestorArchivo::guardarTurnos(listaTurnos);

    cout << "\n[SUCCESS] Turno asignado exitosamente (Estado: Pendiente).\n";
    Validaciones::pausa();
}

// Alta de turno estandar pidiendo DNI
void altaTurno() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("ASIGNACION DE NUEVO TURNO");

    double dni = Validaciones::ingresarDouble("Ingrese el DNI del Paciente: ");
    asignarTurnoConDniPaciente(dni);
}

void listarTurnos() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("LISTADO DE TURNOS ASIGNADOS");

    if (listaTurnos.estaVacia()) {
        cout << "No hay turnos registrados en el sistema.\n";
    } else {
        cout << left << setw(6) << "ID"
             << setw(12) << "ID Paciente"
             << setw(20) << "Nombre Paciente"
             << setw(10) << "ID Doctor"
             << setw(20) << "Nombre Doctor"
             << setw(12) << "Fecha"
             << setw(8) << "Hora"
             << setw(12) << "Estado" << endl;
        cout << "------------------------------------------------------------------------------------------------------\n";

        NodoDoble<Turno>* aux = listaTurnos.getCabeza();
        while (aux != nullptr) {
            Paciente* p = listaPacientes.buscarPorId(aux->dato.getPacienteId());
            Doctor* d = listaDoctores.buscarPorId(aux->dato.getDoctorId());

            string nomPac = (p != nullptr) ? p->getNombreCompleto() : "No encontrado";
            string nomDoc = (d != nullptr) ? d->getNombreCompleto() : "No encontrado";

            aux->dato.mostrarInfo(nomPac, nomDoc);
            aux = aux->siguiente;
        }
        cout << "------------------------------------------------------------------------------------------------------\n";
        cout << "Total de turnos registrados: " << listaTurnos.tamano() << endl;
    }
    Validaciones::pausa();
}

void buscarTurnoPorId() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR TURNO POR ID");

    int id = Validaciones::ingresarEntero("Ingrese el ID del turno a buscar: ");
    Turno* t = listaTurnos.buscarPorId(id);

    if (t != nullptr) {
        Paciente* p = listaPacientes.buscarPorId(t->getPacienteId());
        Doctor* d = listaDoctores.buscarPorId(t->getDoctorId());

        string nomPac = (p != nullptr) ? p->getNombreCompleto() : "No encontrado";
        string nomDoc = (d != nullptr) ? d->getNombreCompleto() : "No encontrado";

        cout << "\n[TURNO ENCONTRADO]:\n";
        cout << left << setw(6) << "ID"
             << setw(12) << "ID Paciente"
             << setw(20) << "Nombre Paciente"
             << setw(10) << "ID Doctor"
             << setw(20) << "Nombre Doctor"
             << setw(12) << "Fecha"
             << setw(8) << "Hora"
             << setw(12) << "Estado" << endl;
        cout << "------------------------------------------------------------------------------------------------------\n";
        t->mostrarInfo(nomPac, nomDoc);
    } else {
        cout << "\n[!] No se encontro ningun turno con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void buscarTurnosPorDoctor() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR TURNOS POR DOCTOR");

    cout << "1. Buscar por ID de Doctor\n";
    cout << "2. Buscar por Apellido de Doctor\n";
    cout << "3. Buscar por Matricula de Doctor\n";
    cout << "0. Cancelar\n";
    cout << "------------------------------------------------------------\n";
    int op = Validaciones::ingresarEntero("Seleccione una opcion: ");

    if (op == 0) return;

    ListaDoble<Doctor> doctoresCoincidentes;
    if (op == 1) {
        int idDoc = Validaciones::ingresarEntero("Ingrese ID del Doctor: ");
        Doctor* d = listaDoctores.buscarPorId(idDoc);
        if (d != nullptr) doctoresCoincidentes.agregarNodoAlFinal(*d);
    } else if (op == 2) {
        string ape = Validaciones::ingresarTexto("Ingrese Apellido del Doctor (o parte): ");
        string apeLower = Validaciones::aMinusculas(ape);
        NodoDoble<Doctor>* auxD = listaDoctores.getCabeza();
        while (auxD != nullptr) {
            if (Validaciones::aMinusculas(auxD->dato.getApellido()).find(apeLower) != string::npos) {
                doctoresCoincidentes.agregarNodoAlFinal(auxD->dato);
            }
            auxD = auxD->siguiente;
        }
    } else if (op == 3) {
        string mat = Validaciones::ingresarTexto("Ingrese Matricula del Doctor: ");
        string matLower = Validaciones::aMinusculas(mat);
        NodoDoble<Doctor>* auxD = listaDoctores.getCabeza();
        while (auxD != nullptr) {
            if (Validaciones::aMinusculas(auxD->dato.getMatricula()) == matLower) {
                doctoresCoincidentes.agregarNodoAlFinal(auxD->dato);
            }
            auxD = auxD->siguiente;
        }
    } else {
        cout << "[!] Opcion invalida.\n";
        Validaciones::pausa();
        return;
    }

    if (doctoresCoincidentes.estaVacia()) {
        cout << "\n[!] No se encontro ningun doctor con el criterio ingresado.\n";
        Validaciones::pausa();
        return;
    }

    int totalTurnos = 0;
    NodoDoble<Turno>* auxT = listaTurnos.getCabeza();
    while (auxT != nullptr) {
        if (doctoresCoincidentes.buscarPorId(auxT->dato.getDoctorId()) != nullptr) {
            if (totalTurnos == 0) {
                cout << "\n[TURNOS ENCONTRADOS PARA EL/LOS DOCTOR(ES)]:\n";
                cout << left << setw(6) << "ID"
                     << setw(12) << "ID Paciente"
                     << setw(20) << "Nombre Paciente"
                     << setw(10) << "ID Doctor"
                     << setw(20) << "Nombre Doctor"
                     << setw(12) << "Fecha"
                     << setw(8) << "Hora"
                     << setw(12) << "Estado" << endl;
                cout << "------------------------------------------------------------------------------------------------------\n";
            }
            Paciente* p = listaPacientes.buscarPorId(auxT->dato.getPacienteId());
            Doctor* d = listaDoctores.buscarPorId(auxT->dato.getDoctorId());
            string nomPac = (p != nullptr) ? p->getNombreCompleto() : "No encontrado";
            string nomDoc = (d != nullptr) ? d->getNombreCompleto() : "No encontrado";
            auxT->dato.mostrarInfo(nomPac, nomDoc);
            totalTurnos++;
        }
        auxT = auxT->siguiente;
    }

    if (totalTurnos == 0) {
        cout << "\n[!] No se encontraron turnos asignados para el/los doctor(es) seleccionado(s).\n";
    } else {
        cout << "------------------------------------------------------------------------------------------------------\n";
        cout << "Total de turnos encontrados: " << totalTurnos << endl;
    }
    Validaciones::pausa();
}

void buscarTurnosPorPaciente() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR TURNOS POR PACIENTE");

    cout << "1. Buscar por DNI de Paciente\n";
    cout << "2. Buscar por ID de Paciente\n";
    cout << "3. Buscar por Apellido de Paciente\n";
    cout << "0. Cancelar\n";
    cout << "------------------------------------------------------------\n";
    int op = Validaciones::ingresarEntero("Seleccione una opcion: ");

    if (op == 0) return;

    ListaDoble<Paciente> pacientesCoincidentes;
    if (op == 1) {
        double dni = Validaciones::ingresarDouble("Ingrese DNI de Paciente: ");
        Paciente* p = listaPacientes.buscarPorDNI(dni);
        if (p != nullptr) pacientesCoincidentes.agregarNodoAlFinal(*p);
    } else if (op == 2) {
        int idPac = Validaciones::ingresarEntero("Ingrese ID de Paciente: ");
        Paciente* p = listaPacientes.buscarPorId(idPac);
        if (p != nullptr) pacientesCoincidentes.agregarNodoAlFinal(*p);
    } else if (op == 3) {
        string ape = Validaciones::ingresarTexto("Ingrese Apellido de Paciente (o parte): ");
        string apeLower = Validaciones::aMinusculas(ape);
        NodoDoble<Paciente>* auxP = listaPacientes.getCabeza();
        while (auxP != nullptr) {
            if (Validaciones::aMinusculas(auxP->dato.getApellido()).find(apeLower) != string::npos) {
                pacientesCoincidentes.agregarNodoAlFinal(auxP->dato);
            }
            auxP = auxP->siguiente;
        }
    } else {
        cout << "[!] Opcion invalida.\n";
        Validaciones::pausa();
        return;
    }

    if (pacientesCoincidentes.estaVacia()) {
        cout << "\n[!] No se encontro ningun paciente con el criterio ingresado.\n";
        Validaciones::pausa();
        return;
    }

    int totalTurnos = 0;
    NodoDoble<Turno>* auxT = listaTurnos.getCabeza();
    while (auxT != nullptr) {
        if (pacientesCoincidentes.buscarPorId(auxT->dato.getPacienteId()) != nullptr) {
            if (totalTurnos == 0) {
                cout << "\n[TURNOS ENCONTRADOS PARA EL/LOS PACIENTE(S)]:\n";
                cout << left << setw(6) << "ID"
                     << setw(12) << "ID Paciente"
                     << setw(20) << "Nombre Paciente"
                     << setw(10) << "ID Doctor"
                     << setw(20) << "Nombre Doctor"
                     << setw(12) << "Fecha"
                     << setw(8) << "Hora"
                     << setw(12) << "Estado" << endl;
                cout << "------------------------------------------------------------------------------------------------------\n";
            }
            Paciente* p = listaPacientes.buscarPorId(auxT->dato.getPacienteId());
            Doctor* d = listaDoctores.buscarPorId(auxT->dato.getDoctorId());
            string nomPac = (p != nullptr) ? p->getNombreCompleto() : "No encontrado";
            string nomDoc = (d != nullptr) ? d->getNombreCompleto() : "No encontrado";
            auxT->dato.mostrarInfo(nomPac, nomDoc);
            totalTurnos++;
        }
        auxT = auxT->siguiente;
    }

    if (totalTurnos == 0) {
        cout << "\n[!] No se encontraron turnos asignados para el/los paciente(s) seleccionado(s).\n";
    } else {
        cout << "------------------------------------------------------------------------------------------------------\n";
        cout << "Total de turnos encontrados: " << totalTurnos << endl;
    }
    Validaciones::pausa();
}

void buscarTurnosPorFecha() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("BUSCAR TURNOS POR FECHA");

    string fecha = Validaciones::ingresarTexto("Ingrese Fecha a buscar (DD/MM/AAAA): ");
    int d, m, a;
    if (!Validaciones::parsearFecha(fecha, d, m, a)) {
        cout << "\n[!] Formato de fecha invalido. Use DD/MM/AAAA.\n";
        Validaciones::pausa();
        return;
    }

    int totalTurnos = 0;
    NodoDoble<Turno>* auxT = listaTurnos.getCabeza();
    while (auxT != nullptr) {
        if (auxT->dato.getFecha() == fecha) {
            if (totalTurnos == 0) {
                cout << "\n[TURNOS PROGRAMADOS PARA LA FECHA " << fecha << "]:\n";
                cout << left << setw(6) << "ID"
                     << setw(12) << "ID Paciente"
                     << setw(20) << "Nombre Paciente"
                     << setw(10) << "ID Doctor"
                     << setw(20) << "Nombre Doctor"
                     << setw(12) << "Fecha"
                     << setw(8) << "Hora"
                     << setw(12) << "Estado" << endl;
                cout << "------------------------------------------------------------------------------------------------------\n";
            }
            Paciente* p = listaPacientes.buscarPorId(auxT->dato.getPacienteId());
            Doctor* doc = listaDoctores.buscarPorId(auxT->dato.getDoctorId());
            string nomPac = (p != nullptr) ? p->getNombreCompleto() : "No encontrado";
            string nomDoc = (doc != nullptr) ? doc->getNombreCompleto() : "No encontrado";
            auxT->dato.mostrarInfo(nomPac, nomDoc);
            totalTurnos++;
        }
        auxT = auxT->siguiente;
    }

    if (totalTurnos == 0) {
        cout << "\n[!] No se encontraron turnos registrados para la fecha " << fecha << ".\n";
    } else {
        cout << "------------------------------------------------------------------------------------------------------\n";
        cout << "Total de turnos en esta fecha: " << totalTurnos << endl;
    }
    Validaciones::pausa();
}

void menuBuscarTurnos() {
    int op;
    do {
        Validaciones::limpiarPantalla();
        Validaciones::dibujarTitulo("BUSQUEDA DE TURNOS");
        cout << "1. Buscar Turno por ID\n";
        cout << "2. Buscar Turnos por Doctor\n";
        cout << "3. Buscar Turnos por Paciente\n";
        cout << "4. Buscar Turnos por Fecha\n";
        cout << "0. Volver a Gestion de Turnos\n";
        cout << "------------------------------------------------------------\n";
        op = Validaciones::ingresarEntero("Seleccione una opcion: ");

        switch (op) {
            case 1: buscarTurnoPorId(); break;
            case 2: buscarTurnosPorDoctor(); break;
            case 3: buscarTurnosPorPaciente(); break;
            case 4: buscarTurnosPorFecha(); break;
            case 0: break;
            default:
                cout << "\n[!] Opcion no valida.\n";
                Validaciones::pausa();
                break;
        }
    } while (op != 0);
}

void modificarTurno() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("MODIFICAR TURNO");

    int id = Validaciones::ingresarEntero("Ingrese el ID del turno a modificar: ");
    Turno* t = listaTurnos.buscarPorId(id);

    if (t != nullptr) {
        Paciente* p = listaPacientes.buscarPorId(t->getPacienteId());
        Doctor* d = listaDoctores.buscarPorId(t->getDoctorId());
        string nomPac = (p != nullptr) ? p->getNombreCompleto() : "No encontrado";
        string nomDoc = (d != nullptr) ? d->getNombreCompleto() : "No encontrado";

        cout << "\nDatos actuales del turno:\n";
        t->mostrarInfo(nomPac, nomDoc);

        cout << "\nQue campo desea modificar?\n";
        cout << "1. Modificar Fecha\n";
        cout << "2. Modificar Hora\n";
        cout << "3. Modificar Estado (Pendiente / Pasado)\n";
        cout << "0. Volver\n";
        int op = Validaciones::ingresarEntero("Seleccione una opcion: ");

        if (op == 1) {
            string nuevaFecha = Validaciones::ingresarFechaFutura("Nueva Fecha (DD/MM/AAAA): ");
            t->setFecha(nuevaFecha);
            GestorArchivo::guardarTurnos(listaTurnos);
            cout << "\n[SUCCESS] Fecha de Turno modificada.\n";
        } else if (op == 2) {
            string nuevaHora = Validaciones::ingresarTexto("Nueva Hora (HH:MM): ");
            t->setHora(nuevaHora);
            GestorArchivo::guardarTurnos(listaTurnos);
            cout << "\n[SUCCESS] Hora de Turno modificada.\n";
        } else if (op == 3) {
            cout << "\nSeleccione el nuevo Estado:\n";
            cout << "1. Pendiente\n";
            cout << "2. Pasado\n";
            int opEst = Validaciones::ingresarEntero("Opcion: ");
            if (opEst == 1) {
                t->setEstado("Pendiente");
            } else if (opEst == 2) {
                t->setEstado("Pasado");
            } else {
                cout << "[!] Opcion invalida. No se realizaron cambios.\n";
            }
            GestorArchivo::guardarTurnos(listaTurnos);
            cout << "\n[SUCCESS] Estado de Turno modificado.\n";
        }

    } else {
        cout << "\n[!] No se encontro ningun turno con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void cancelarTurno() {
    Validaciones::limpiarPantalla();
    Validaciones::dibujarTitulo("CANCELAR / BAJA DE TURNO");

    int id = Validaciones::ingresarEntero("Ingrese el ID del turno a cancelar: ");
    if (listaTurnos.buscarPorId(id) != nullptr) {
        if (listaTurnos.eliminarPorId(id)) {
            GestorArchivo::guardarTurnos(listaTurnos);
            cout << "\n[SUCCESS] Turno cancelado y eliminado de la lista y del archivo.\n";
        }
    } else {
        cout << "\n[!] No se encontro ningun turno con el ID " << id << ".\n";
    }
    Validaciones::pausa();
}

void menuTurnos() {
    int opcion;
    do {
        Validaciones::limpiarPantalla();
        Validaciones::dibujarTitulo("GESTION DE TURNOS");
        cout << "1. Asignar nuevo Turno (Busqueda por DNI)\n";
        cout << "2. Listar todos los Turnos\n";
        cout << "3. Buscar Turnos (por ID, Doctor, Paciente o Fecha)\n";
        cout << "4. Modificar Turno (Fecha/Hora/Estado)\n";
        cout << "5. Cancelar / Baja de Turno\n";
        cout << "0. Volver al Menu Principal\n";
        cout << "------------------------------------------------------------\n";
        opcion = Validaciones::ingresarEntero("Seleccione una opcion: ");

        switch (opcion) {
            case 1: altaTurno(); break;
            case 2: listarTurnos(); break;
            case 3: menuBuscarTurnos(); break;
            case 4: modificarTurno(); break;
            case 5: cancelarTurno(); break;
            case 0: break;
            default:
                cout << "\n[!] Opcion no valida.\n";
                Validaciones::pausa();
                break;
        }
    } while (opcion != 0);
}

// ============================================================================
// MENU PRINCIPAL
// ============================================================================

int main() {
    // Inicializar primero la lista de especialidades de forma local y persistente
    inicializarEspecialidades();

    // Carga inicial de datos guardados en archivos de texto
    GestorArchivo::cargarPacientes(listaPacientes);
    GestorArchivo::cargarDoctores(listaDoctores, listaEspecialidades);
    GestorArchivo::cargarTurnos(listaTurnos);

    int opcion;
    do {
        Validaciones::limpiarPantalla();
        Validaciones::dibujarTitulo("SISTEMA DE GESTION DE TURNOS MEDICOS");
        cout << "1. Gestion de Pacientes\n";
        cout << "2. Gestion de Doctores\n";
        cout << "3. Gestion de Turnos\n";
        cout << "0. Guardar y Salir\n";
        cout << "------------------------------------------------------------\n";
        opcion = Validaciones::ingresarEntero("Seleccione una opcion: ");

        switch (opcion) {
            case 1: menuPacientes(); break;
            case 2: menuDoctores(); break;
            case 3: menuTurnos(); break;
            case 0:
                // Guardar los datos en los archivos antes de salir
                GestorArchivo::guardarPacientes(listaPacientes);
                GestorArchivo::guardarDoctores(listaDoctores);
                GestorArchivo::guardarTurnos(listaTurnos);
                cout << "\n[!] Datos guardados correctamente. Hasta luego!\n";
                break;
            default:
                cout << "\n[!] Opcion no valida.\n";
                Validaciones::pausa();
                break;
        }
    } while (opcion != 0);

    return 0;
}
