#include <iostream>
#include <cassert>
#include <string>

#include "encabezados/Persona.h"
#include "encabezados/Paciente.h"
#include "encabezados/Doctor.h"
#include "encabezados/Turno.h"
#include "encabezados/Especialidad.h"
#include "encabezados/ListaDoble.h"
#include "encabezados/GestorArchivo.h"
#include "encabezados/Validaciones.h"

using namespace std;

void testValidacionesFecha() {
    cout << "[TEST] Validacion de fechas..." << endl;
    
    int d, m, a;
    // Formato valido
    assert(Validaciones::parsearFecha("15/08/2026", d, m, a) == true);
    assert(d == 15 && m == 8 && a == 2026);
    
    // Formato invalido
    assert(Validaciones::parsearFecha("31/02/2026", d, m, a) == false); // Feb 31 invalid
    assert(Validaciones::parsearFecha("15-08-2026", d, m, a) == false);
    assert(Validaciones::parsearFecha("invalid", d, m, a) == false);

    // Fecha en el pasado vs desde hoy
    assert(Validaciones::esFechaDesdeHoy("01/01/2020") == false);
    assert(Validaciones::esFechaDesdeHoy("15/12/2030") == true);
    
    cout << "  -> Validacion de fechas: OK" << endl;
}

void testPacientesYDoctores() {
    cout << "[TEST] Pacientes y Doctores en ListaDoble..." << endl;
    
    ListaDoble<Paciente> lPac;
    Paciente p1(1, "Carlos", "Perez", 12345678, "OSDE");
    Paciente p2(2, "Maria", "Gomez", 87654321, "Swiss Medical");
    
    lPac.agregarNodoAlFinal(p1);
    lPac.agregarNodoAlFinal(p2);
    
    assert(lPac.tamano() == 2);
    assert(lPac.buscarPorId(1)->getNombre() == "Carlos");
    assert(lPac.buscarPorDNI(87654321)->getApellido() == "Gomez");
    
    Especialidad esp(1, "Cardiologia");
    Doctor d1(10, "Juan", "Rodriguez", esp, "MN12345");
    Doctor d2(20, "Ana", "Martinez", esp, "MN67890");

    ListaDoble<Doctor> lDoc;
    lDoc.agregarNodoAlFinal(d1);
    lDoc.agregarNodoAlFinal(d2);

    assert(lDoc.tamano() == 2);
    assert(lDoc.buscarPorId(10)->getMatricula() == "MN12345");

    // Busqueda por apellido (case-insensitive substring)
    NodoDoble<Doctor>* aux = lDoc.getCabeza();
    bool encontradoApe = false;
    while (aux != nullptr) {
        if (Validaciones::aMinusculas(aux->dato.getApellido()).find("martinez") != string::npos) {
            encontradoApe = true;
            break;
        }
        aux = aux->siguiente;
    }
    assert(encontradoApe == true);

    cout << "  -> Pacientes y Doctores: OK" << endl;
}

void testBajaCascadaTurnos() {
    cout << "[TEST] Baja en cascada de turnos al eliminar Paciente o Doctor..." << endl;
    
    ListaDoble<Paciente> lPac;
    lPac.agregarNodoAlFinal(Paciente(100, "Pedro", "Alvarez", 11223344, "IOMA"));
    
    Especialidad esp(2, "Pediatria");
    ListaDoble<Doctor> lDoc;
    lDoc.agregarNodoAlFinal(Doctor(200, "Laura", "Sanchez", esp, "MN999"));

    ListaDoble<Turno> lTur;
    lTur.agregarNodoAlFinal(Turno(1, 100, 200, "20/10/2026", "10:00", "Pendiente"));
    lTur.agregarNodoAlFinal(Turno(2, 100, 200, "21/10/2026", "11:00", "Pendiente"));
    lTur.agregarNodoAlFinal(Turno(3, 999, 200, "22/10/2026", "12:00", "Pendiente"));

    assert(lTur.tamano() == 3);

    // Simular baja de paciente ID 100 (Baja en cascada)
    int pId = 100;
    lPac.eliminarPorId(pId);
    
    NodoDoble<Turno>* auxT = lTur.getCabeza();
    while (auxT != nullptr) {
        NodoDoble<Turno>* sig = auxT->siguiente;
        if (auxT->dato.getPacienteId() == pId) {
            lTur.eliminarPorId(auxT->dato.getId());
        }
        auxT = sig;
    }

    // Deben quedar 1 turno (el asignado al paciente 999)
    assert(lTur.tamano() == 1);
    assert(lTur.buscarPorId(3) != nullptr);
    assert(lTur.buscarPorId(1) == nullptr);

    // Simular baja de doctor ID 200 (Baja en cascada)
    int dId = 200;
    lDoc.eliminarPorId(dId);
    
    auxT = lTur.getCabeza();
    while (auxT != nullptr) {
        NodoDoble<Turno>* sig = auxT->siguiente;
        if (auxT->dato.getDoctorId() == dId) {
            lTur.eliminarPorId(auxT->dato.getId());
        }
        auxT = sig;
    }

    assert(lTur.tamano() == 0);

    cout << "  -> Baja en cascada de turnos: OK" << endl;
}

void testPersistencia() {
    cout << "[TEST] Persistencia en archivos..." << endl;

    ListaDoble<Especialidad> lEsp;
    lEsp.agregarNodoAlFinal(Especialidad(1, "Neurologia"));
    GestorArchivo::guardarEspecialidades(lEsp, "test_especialidades.txt");

    ListaDoble<Especialidad> lEspCargada;
    GestorArchivo::cargarEspecialidades(lEspCargada, "test_especialidades.txt");

    assert(lEspCargada.tamano() == 1);
    assert(lEspCargada.buscarPorId(1)->getNombre() == "Neurologia");

    // Limpieza de archivo de test
    remove("test_especialidades.txt");

    cout << "  -> Persistencia: OK" << endl;
}

int main() {
    cout << "========================================" << endl;
    cout << " RUNNING SYSTEM VERIFICATION SUITE      " << endl;
    cout << "========================================" << endl;
    
    testValidacionesFecha();
    testPacientesYDoctores();
    testBajaCascadaTurnos();
    testPersistencia();

    cout << "========================================" << endl;
    cout << " ALL TESTS PASSED SUCCESSFULLY!          " << endl;
    cout << "========================================" << endl;
    return 0;
}
