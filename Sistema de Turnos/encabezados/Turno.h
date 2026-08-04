#ifndef TURNO_H
#define TURNO_H

#include <iostream>
#include <iomanip>
#include <sstream>
#include <string>

using namespace std;

// Clase Turno que representa la cita medica entre un Paciente y un Doctor
class Turno {
private:
    int id;
    int pacienteId;
    int doctorId;
    string fecha; // Formato DD/MM/AAAA
    string hora;  // Formato HH:MM
    string estado; // "Pendiente" o "Pasado"

public:
    // Constructores
    Turno() : id(0), pacienteId(0), doctorId(0), fecha(""), hora(""), estado("Pendiente") {}
    Turno(int id, int pacienteId, int doctorId, string fecha, string hora, string estado = "Pendiente")
        : id(id), pacienteId(pacienteId), doctorId(doctorId), fecha(fecha), hora(hora), estado(estado) {}

    // Setters
    void setId(int id) { this->id = id; }
    void setPacienteId(int pId) { this->pacienteId = pId; }
    void setDoctorId(int dId) { this->doctorId = dId; }
    void setFecha(const string& f) { this->fecha = f; }
    void setHora(const string& h) { this->hora = h; }
    void setEstado(const string& est) { this->estado = est; }

    // Getters
    int getId() const { return this->id; }
    int getPacienteId() const { return this->pacienteId; }
    int getDoctorId() const { return this->doctorId; }
    string getFecha() const { return this->fecha; }
    string getHora() const { return this->hora; }
    string getEstado() const { return this->estado; }

    // Imprimir informacion en tabla simple (sin acentos)
    void mostrarInfo(const string& nombrePaciente = "", const string& nombreDoctor = "") const {
        cout << left << setw(6) << id 
             << setw(12) << pacienteId 
             << setw(20) << (nombrePaciente.empty() ? "-" : nombrePaciente)
             << setw(10) << doctorId 
             << setw(20) << (nombreDoctor.empty() ? "-" : nombreDoctor)
             << setw(12) << fecha 
             << setw(8) << hora 
             << setw(12) << estado << endl;
    }

    // Serializacion para guardar en el archivo de texto
    string toFileString() const {
        ostringstream oss;
        oss << id << ";" << pacienteId << ";" << doctorId << ";" << fecha << ";" << hora << ";" << estado;
        return oss.str();
    }

    // Deserializacion desde archivo
    static Turno fromFileString(const string& linea) {
        stringstream ss(linea);
        string idStr, pIdStr, dIdStr, fec, hor, est;

        getline(ss, idStr, ';');
        getline(ss, pIdStr, ';');
        getline(ss, dIdStr, ';');
        getline(ss, fec, ';');
        getline(ss, hor, ';');
        getline(ss, est, ';');

        int id = idStr.empty() ? 0 : stoi(idStr);
        int pId = pIdStr.empty() ? 0 : stoi(pIdStr);
        int dId = dIdStr.empty() ? 0 : stoi(dIdStr);
        if (est.empty()) {
            est = "Pendiente";
        }

        return Turno(id, pId, dId, fec, hor, est);
    }
};

#endif // TURNO_H
