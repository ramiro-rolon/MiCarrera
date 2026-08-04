# Guía Explicativa Técnica: Gestor de Archivos y Validaciones en C++

Documento preparado para la defensa del examen final del **Sistema de Turnos Médicos**.

---

## 1. Explicación de las Librerías Importadas en C++

En C++, una **librería** (o archivo de cabecera `#include`) incluye código preescrito del lenguaje que proporciona funciones y utilidades para no tener que reinventarlas desde cero.

| Librería | ¿Qué significa el nombre? | ¿Para qué sirve y qué hace en el programa? |
| :--- | :--- | :--- |
| `<iostream>` | Input / Output Stream | Permite la entrada y salida por consola. Nos da los objetos `std::cout` (imprimir en pantalla) y `std::cin` (leer del teclado). |
| `<fstream>` | File Stream | Librería para trabajar con **archivos en disco**. Proporciona las clases `ifstream` (leer archivos) y `ofstream` (escribir en archivos). |
| `<string>` | String | Proporciona el tipo de dato `std::string` para manipular texto dinámico (nombres, apellidos, especialidades). |
| `<sstream>` | String Stream | Trata cadenas de texto como si fueran flujos. Es fundamental para dividir texto separado por `;` usando `std::stringstream` y `std::getline`. |
| `<iomanip>` | Input / Output Manipulators | Brinda formateadores visuales para la consola: `std::setw()` (ancho de columnas de tablas), `std::left` (alineación) y `std::fixed` / `std::setprecision()` (formato de decimales). |
| `<limits>` | Limits | Permite consultar límites de capacidad de datos. Se usa para limpiar el buffer del teclado con `numeric_limits<streamsize>::max()`. |
| `<cstdlib>` | C Standard Library | Proporciona funciones de interacción con el sistema operativo, como `system("cls")` para limpiar la pantalla. |

---

## 2. Conceptos Fundamentales: `ifstream` vs `ofstream`

Un **Stream (Flujo)** es un canal de transporte por donde viajan los datos entre la memoria RAM de la computadora y un destino (la consola o un archivo del disco rígido).

### `ofstream` (Output File Stream)
- **¿Qué es?**: Un flujo de **salida** hacia un archivo en el disco.
- **¿Para qué sirve?**: Para **GUARDAR / ESCRIBIR** datos en un archivo `.txt`.
- **Funcionamiento**: Opera de forma análoga a `cout`. Mientras que `cout << "Hola";` manda el texto a la pantalla, `archivo << "Hola";` manda el texto al archivo de texto en el disco.

```cpp
// Ejemplo de escritura con ofstream
ofstream archivo("pacientes.txt"); // Abre o crea el archivo
if (archivo.is_open()) {
    archivo << "1;Juan;Perez;12345678;OSDE\n"; // Escribe la línea
    archivo.close(); // Cierra el archivo liberando el recurso
}
```

### `ifstream` (Input File Stream)
- **¿Qué es?**: Un flujo de **entrada** desde un archivo en el disco.
- **¿Para qué sirve?**: Para **CARGAR / LEER** datos desde un archivo `.txt` hacia la memoria RAM.
- **Funcionamiento**: Opera de forma análoga a `cin`. Mientras que `cin >> variable;` lee desde el teclado, `getline(archivo, linea);` lee una línea completa del archivo en el disco.

```cpp
// Ejemplo de lectura con ifstream
ifstream archivo("pacientes.txt"); // Abre el archivo en modo lectura
string linea;
if (archivo.is_open()) {
    while (getline(archivo, linea)) { // Lee línea por línea hasta el final (EOF)
        cout << "Línea leída: " << linea << endl;
    }
    archivo.close();
}
```

---

## 3. Funcionamiento de `GestorArchivo.h` Paso a Paso

El archivo `GestorArchivo.h` administra la persistencia de datos relacionando la **Lista Doblemente Enlazada** (memoria RAM) con los **archivos de texto** (`pacientes.txt`, `doctores.txt`, `turnos.txt`).

### A. Serialización y Deserialización
- **Serialización (`toFileString()`)**: Convierte un objeto en RAM (ej. `Paciente`) a una sola cadena delimitada por punto y coma `;`.
  * *Ejemplo*: `1;Juan;Perez;12345678;OSDE`.
- **Deserialización (`fromFileString()`)**: Proceso inverso. Toma una línea de texto del archivo y mediante `stringstream` y `getline(ss, token, ';')` extrae los atributos y reconstruye el objeto.

### B. Proceso de Guardado (RAM -> Disco)
1. Se abre el archivo con `ofstream archivo("pacientes.txt");`.
2. Se verifica que esté abierto con `is_open()`.
3. Se inicia un puntero en el primer nodo de la Lista Doble: `NodoDoble<Paciente>* aux = lista.getCabeza();`
4. Se recorre la lista mientras `aux != nullptr`:
   - Escribe el formato texto: `archivo << aux->dato.toFileString() << "\n";`
   - Avanza al siguiente nodo: `aux = aux->siguiente;`
5. Se cierra el archivo con `archivo.close();`.

### C. Proceso de Carga (Disco -> RAM)
1. Se vacía la lista en RAM antes de cargar con `lista.vaciar();`.
2. Se abre el archivo con `ifstream archivo("pacientes.txt");`.
3. Se lee cada línea en un bucle `while (getline(archivo, linea))`.
4. Cada línea se reconstruye en un objeto `Paciente p = Paciente::fromFileString(linea);`.
5. Se inserta en la Lista Doble con `lista.agregarNodoAlFinal(p);`.
6. Se cierra el archivo con `archivo.close();`.

---

## 4. Funcionamiento de `Validaciones.h` Paso a Paso

### El Problema de Entrada en C++
Cuando `cin >> opcion;` espera un número entero y el usuario ingresa texto por error (ej. `"hola"`):
1. `cin` falla y entra en estado de error (**failbit**).
2. El texto no válido (`"hola"`) queda atascado en la memoria buffer del teclado.
3. El programa entra en un **bucle infinito** imprimiendo errores continuamente.

### La Solución Implementada
```cpp
static int ingresarEntero(const string& mensaje) {
    int valor;
    while (true) {
        cout << mensaje;
        if (cin >> valor) {
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Entrada válida
            return valor;
        } else {
            cout << "[!] Entrada inválida. Por favor ingrese un número entero.\n";
            cin.clear(); // 1. Restablece los indicadores de error de cin
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // 2. Borra el texto corrupto del buffer
        }
    }
}
```

- `cin.clear()`: Resetea el estado de error de C++ para volver a habilitar `cin`.
- `cin.ignore(numeric_limits<streamsize>::max(), '\n')`: Descarta todo el texto sobrante atascado en el teclado hasta presionar Enter, dejando el buffer limpio para volver a solicitar el dato de forma segura.
