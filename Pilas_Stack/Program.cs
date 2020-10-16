using System;
using System.Collections;
using System.Collections.Generic;

namespace Pilas_Stack {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Declaración de stacks a usar
            Stack<string> nombres = new Stack<string>();
            Stack<double> calificaciones = new Stack<double>();

            // Variables auxiliares
            int indiceN = 0;
            int indiceC = 0;
            int tamano;
            bool operando = true;

            // Captura del tamaño de las pilas
            Console.Title = "Captura del tamaño de las pilas";
            Console.Clear();

            bool valido = false;
            do {
                Console.Write("Ingresa el tamaño del stack: ");
                valido = Int32.TryParse(Console.ReadLine(), out tamano) && tamano > 0;
            }
            while (!valido);

            // Menu de opciones
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Operaciones con pilas V2.0";

                Console.Write(
                    "[1] Insertar\n[2] Eliminar \n[3] Buscar\n[!] Cualquier otra para salir\nSelecciona una opcion: "
                );
                string seleccion = Console.ReadLine();

                switch (seleccion) {
                case "1":
                    // Se prepara la consola
                    Console.Title = "Capturando elementos";

                    // Variables auxiliares
                    bool captura = true;

                    // Se inicia el ciclo de captura
                    while (captura) {
                        Console.Clear();
                        if (Llena(tamano, indiceC)) { Console.Write("La pila se encuentra llena.\n"); Console.ReadKey(); break; }
                        // Captura de nombre
                        Console.Write("Ingresa el nombre del alumno #{0}: ", indiceN + 1);
                        // Insercion de string en pila
                        indiceN = Insertar(nombres, indiceN, tamano, Console.ReadLine());

                        // Captura de calificacion con validación
                        bool validar = false;
                        double calificacion;
                        do {
                            Console.Write("Ingresa la calificacion (entre 1-10) del alumno #{0}: ", indiceC + 1);
                            validar = Double.TryParse(Console.ReadLine(), out calificacion) && (calificacion > 0.0 && calificacion <= 10.0);
                        }
                        while (!validar);

                        // Insercion de int en pila
                        indiceC = Insertar(calificaciones, indiceC, tamano, calificacion);

                        // Pregunta para seguir capturando
                        Console.Write("\n[1] Si [!] Otro para no\n¿Desea Continuar?: ");
                        captura = Console.ReadLine().Equals("1");
                    }

                    break;

                case "2":
                    bool eliminando = true;
                    while (eliminando) {
                        Console.Clear();
                        Console.Title = "SubMenu de eliminación";

                        Console.Write("[1] Eliminar un alumno con su calificación\n[2] Vaciar pila\n[!] Cualquier otra para salir\nSelecciona una opcion: ");
                        string eliminar = Console.ReadLine();

                        switch (eliminar) {
                        case "1":
                            Console.Clear();
                            Console.Title = "Eliminar ultimo alumno";

                            if (Vacia(indiceN)) { Console.Write("Pila vacia\n"); Console.ReadKey(); break; }

                            Console.WriteLine("Campo a eliminar Alumno: {0}| Calificación: {1}", nombres.Peek(), calificaciones.Peek());

                            Console.Write("Presiona [1] para confirmar eliminar, otro para cancelar: ");
                            if (Console.ReadLine().Contains("1")) indiceC = indiceN = Eliminar(nombres, calificaciones, indiceN);
                            break;

                        case "2":
                            Console.Clear();
                            Console.Title = "Vaciar Pila";

                            Console.Write("Presiona [1] para confirmar vaciar la pila, otro para cancelar: ");
                            if (Console.ReadLine().Contains("1")) indiceC = indiceN = Vaciar(nombres, calificaciones);
                            break;

                        default:
                            eliminando = false;
                            break;
                        }
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Ingresa el nombre de la persona a buscar: ");
                    Buscar(nombres, Console.ReadLine());
                    Console.Write("Presione una tecla para continuar...");

                    Console.ReadKey();

                    break;

                default:
                    operando = false;
                    break;
                }
            }
            Console.Clear();
            Console.Title = "Despliegue de "
            for(int i = indiceN ; i > 0 ; i--) Console.WriteLine("{0} | {1}",nombres.Pop(),calificaciones.Pop());
            
        }
        // Comprobación que la pila no ha llegado a su tope
        static bool Llena(int top, int indice) => top <= indice;
        // Comprobación que la pila no se ha vaciado.
        static bool Vacia(int indice) => indice <= 0;
        static int Insertar(Stack<string> nombres, int indice, int tamano, string insercion) {
            nombres.Push(insercion);
            return indice + 1;
        }
        static int Insertar(Stack<double> calificaciones, int indice, int tamano, double insercion) {
            calificaciones.Push(insercion);
            return indice + 1;
        }
        static int Eliminar(Stack<string> nombres, Stack<double> calificaciones, int indice) {
            nombres.Pop();
            calificaciones.Pop();
            return indice - 1;
        }
        static int Vaciar(Stack<string> nombres, Stack<double> calificaciones) {
            nombres.Clear();
            calificaciones.Clear();
            return 0;
        }
        static void Buscar(Stack<string> nombres, string buscando) =>
            Console.WriteLine(nombres.Contains(buscando) ? $"Se encontró { buscando } en la lista" : "Nombre no encontrado");
    }
}