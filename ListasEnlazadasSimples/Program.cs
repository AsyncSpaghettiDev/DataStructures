using System;

namespace ListasEnlazadasSimples {
    class Nodo {
        public int dato;
        public Nodo dir;
    }
    class Program {
        static Nodo Inicio;
        static Nodo Final;
        static Nodo Temp;

        static int Temporal;
        static int Edad;
        static int Tamano = 0;
        static int Capacidad = 30;
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            Final = null;
            Inicio = null;

            // Declaración de menú
            bool operando = true;
            while (operando) {
                Console.Clear();
                Console.Title = "Menu de operaciones con Listas Enlazadas Simples";

                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Recorrer\n[! Otro] Salir\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion) {
                case "1":
                    Console.Title = "Insertando elementos en la lista";

                    bool capturando = true;
                    while (capturando) {
                        // Se limpia la consola
                        Console.Clear();

                        bool validando = false;

                        // Nos aseguramos de recibir una edad válida
                        do {
                            Console.Write("Ingresa la edad a registrar: ");
                            validando = Int32.TryParse(Console.ReadLine(), out Edad) && Edad > 0;
                        }
                        while (!validando);

                        // Se manda llamar al metodo
                        capturando = Insertar();

                        // Se comprueba si seguir capturando elementos
                        if (capturando) {
                            Console.Write("[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro nombre?: ");
                            capturando = Console.ReadLine().Contains("1");
                        }

                    }
                    goto case "3";

                case "2":
                    // Se nombra a la consola
                    Console.Title = "Eliminando elementos";
                    // Se declara ciclo de eliminación
                    bool eliminando = true;
                    while (eliminando) {
                        // Se limpia la consola
                        Console.Clear();
                        // Se confirma la eliminación
                        Console.Write("[1] Si\n[!] Cualquier otro para no\n¿Confirma eliminar la edad?: ");
                        // En caso de no confirmarlo se cierra el ciclo de eliminacion
                        if (!Console.ReadLine().Contains("1")) eliminando = false;
                        // En caso de querer eliminarlo se elimina el elemento
                        else {
                            eliminando = Eliminar();

                            // Se comprueba si quiere seguir eliminando elementos
                            if (eliminando) {
                                Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando nombres?: ");
                                eliminando = Console.ReadLine().Contains("1");
                            }
                        }
                    }
                    goto case "3";

                case "3":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Mostrando la lista";
                    // Se llama al metodo desplegar
                    Imprimir();
                    break;

                default:
                    operando = false;
                    break;
                }
            }
        }
        static bool Insertar() {
            if (Tamano == Capacidad - 1) {
                Console.Write("Lista Llena...");
                Console.ReadKey();
                return false;
            }
            else {
                if (Inicio == null) {
                    Inicio = new Nodo();
                    Inicio.dato = Edad;
                    Final = Inicio;
                    Final.dir = null;

                    Tamano++;
                }
                else {
                    Temp = new Nodo();
                    Temp.dato = Edad;
                    Final.dir = Temp;
                    Final = Temp;
                    Final.dir = null;

                    Tamano++;
                }
                return true;
            }
        }
        static bool Eliminar() {
            if (Inicio == null) {
                Console.Write("Lista Vacia...");
                Console.ReadKey();
                return false;
            }
            else {
                if (Inicio == Final) {
                    Temporal = Inicio.dato;
                    Inicio = null;
                    Final = null;
                    Tamano--;
                }
                else {
                    Temporal = Inicio.dato;

                    Temp = Inicio;
                    Inicio = Inicio.dir;

                    Tamano--;
                }
                return true;
            }
        }
        static void Imprimir() {
            Console.WriteLine($"Lista con { Tamano } elementos");
            Temp = Inicio;
            while (Temp != null) {
                Console.Write($"{ Temp.dato } | ");
                Temp = Temp.dir;
            }
            Console.ReadKey();
        }
    }
}