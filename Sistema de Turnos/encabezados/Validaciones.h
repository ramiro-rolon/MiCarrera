#ifndef VALIDACIONES_H
#define VALIDACIONES_H

#include <iostream>
#include <string>
#include <limits>
#include <ctime>
#include <cstdlib>

using namespace std;

// Libreria de utilidades para validacion de entrada por consola y formato de la UI
class Validaciones {
public:

    // Limpia la consola segun el sistema operativo
    static void limpiarPantalla() {
#ifdef _WIN32
        system("cls");
#else
        system("clear");
#endif
    }

    // Esperar a que el usuario presione ENTER antes de continuar
    static void pausa() {
        cout << "\nPresione ENTER para continuar...";
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        cin.get();
    }

    // Solicitar e ingresar un numero entero validado (sin entrar en bucle infinito si el usuario escribe letras)
    static int ingresarEntero(const string& mensaje) {
        int valor;
        while (true) {
            cout << mensaje;
            if (cin >> valor) {
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                return valor;
            } else {
                if (cin.eof()) return 0;
                cout << "[!] Entrada invalida. Por favor ingrese un numero entero.\n";
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
            }
        }
    }

    // Solicitar e ingresar un numero tipo double (ej. DNI) validado
    static double ingresarDouble(const string& mensaje) {
        double valor;
        while (true) {
            cout << mensaje;
            if (cin >> valor) {
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                return valor;
            } else {
                if (cin.eof()) return 0;
                cout << "[!] Entrada invalida. Por favor ingrese un numero valido.\n";
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
            }
        }
    }

    // Solicitar una cadena de texto no vacia
    static string ingresarTexto(const string& mensaje) {
        string texto;
        while (true) {
            cout << mensaje;
            getline(cin, texto);
            if (!texto.empty() || cin.eof()) {
                return texto;
            }
            cout << "[!] El campo no puede estar vacio. Intente nuevamente.\n";
        }
    }

    // Convierte una cadena a minusculas para busquedas case-insensitive
    static string aMinusculas(string str) {
        for (char &c : str) {
            c = tolower(static_cast<unsigned char>(c));
        }
        return str;
    }

    // Intenta parsear una fecha en formato DD/MM/AAAA, retorna true si el formato es valido
    static bool parsearFecha(const string& fecha, int& dia, int& mes, int& anio) {
        if (fecha.size() != 10) return false;
        if (fecha[2] != '/' || fecha[5] != '/') return false;
        try {
            dia  = stoi(fecha.substr(0, 2));
            mes  = stoi(fecha.substr(3, 2));
            anio = stoi(fecha.substr(6, 4));
        } catch (...) {
            return false;
        }
        if (mes < 1 || mes > 12) return false;
        if (dia < 1 || dia > 31) return false;

        int diasPorMes[] = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        bool esBisiesto = (anio % 4 == 0 && (anio % 100 != 0 || anio % 400 == 0));
        if (esBisiesto) diasPorMes[2] = 29;

        if (dia > diasPorMes[mes]) return false;
        if (anio < 2024)         return false;
        return true;
    }

    // Retorna true si la fecha ingresada es igual o posterior a la fecha de hoy
    static bool esFechaDesdeHoy(const string& fecha) {
        int dia, mes, anio;
        if (!parsearFecha(fecha, dia, mes, anio)) return false;

        time_t t = time(nullptr);
        struct tm* hoy = localtime(&t);

        int hoyAnio = hoy->tm_year + 1900;
        int hoyMes  = hoy->tm_mon + 1;
        int hoyDia  = hoy->tm_mday;

        if (anio > hoyAnio) return true;
        if (anio == hoyAnio && mes > hoyMes) return true;
        if (anio == hoyAnio && mes == hoyMes && dia >= hoyDia) return true;
        return false;
    }

    // Solicita una fecha y valida que sea: formato correcto Y no sea una fecha pasada
    static string ingresarFechaFutura(const string& mensaje) {
        while (true) {
            string fecha = ingresarTexto(mensaje);
            int d, m, a;
            if (!parsearFecha(fecha, d, m, a)) {
                cout << "[!] Formato invalido. Use DD/MM/AAAA (ej: 15/08/2026).\n";
                continue;
            }
            if (!esFechaDesdeHoy(fecha)) {
                cout << "[!] No se pueden agendar turnos con fecha pasada. Ingrese una fecha desde hoy.\n";
                continue;
            }
            return fecha;
        }
    }

    // Dibujar un titulo formateado para la consola
    static void dibujarTitulo(const string& titulo) {
        cout << "============================================================\n";
        cout << "  " << titulo << "\n";
        cout << "============================================================\n";
    }
};

#endif // VALIDACIONES_H
