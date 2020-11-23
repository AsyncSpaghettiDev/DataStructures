using System;
namespace BurbujaVariantes {
    class Program {
        static string [] bSimple = new string [10];
        static double [] bMejorada = new double [18];
        static string [] bOptimizada = new string [12];
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Declaración del menú
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Metodos de Ordenamientos V.Burbuja";
                // Despliegue de Opciones
                Console.Write("[1] Sorteo Burbuja Simple\n[2] Sorteo Burbuja Mejorada\n[3] Sorteo Burbuja Optimizada\n[4] Mostrar Ordenamiento\n[! Otro] Salida\nSelecciona una opción: ");
                // Opciones de menú
                switch (Console.ReadLine()) {
                    case "1":
                        // Se nombra la consola
                        Console.Title = "Insertar en metodo Burbuja Simple";
                        // Ciclo de Captura
                        for (int i = 0; i < bSimple.Length; i++) {
                            Console.Clear();
                            Console.Write($"Ingresa el nombre de la persona #{ i + 1 } a registrar: ");
                            bSimple [i] = Console.ReadLine();
                        }
                        burbujaSimple();
                        break;

                    case "2":
                        // Se nombra la consola
                        Console.Title = "Insertar en metodo Burbuja Mejorada";
                        // Ciclo de Captura
                        for (int i = 0; i < bMejorada.Length; i++) {
                            Console.Clear();
                            double cali = 0;
                            bool valido = false;
                            while (!valido) {
                                Console.Write($"Ingresa la calificación #{ i + 1 } válida para guardar: ");
                                valido = double.TryParse(Console.ReadLine(), out cali) && (cali > 0 && cali <= 10);
                            }
                            bMejorada [i] = cali;
                        }
                        burbujaMejorada();
                        break;

                    case "3":
                        // Se nombra la consola
                        Console.Title = "Insertar en metodo Burbuja Optimizada";
                        // Ciclo de Captura
                        for (int i = 0; i < bOptimizada.Length; i++) {
                            Console.Clear();
                            Console.Write($"Ingresa el nombre de la mascota #{ i + 1 } a registrar: ");
                            bOptimizada [i] = Console.ReadLine();
                        }
                        burbujaOptimizada();
                        break;

                    case "4":
                        // subMenu para desplegar opciones.
                        Console.Title = "SubMenu de opciones de despliegue";
                        subMenu();
                        break;

                    default:
                        operando = false;
                        break;
                }
            }
        }
        static void burbujaSimple() {
            for (int i = 1; i < bSimple.Length; i++)
                for (int j = bSimple.Length - 1; j >= i; j--)
                    if (string.Compare(bSimple [j - 1], bSimple [j]) > 0) {
                        string n = bSimple [j - 1];
                        bSimple [j - 1] = bSimple [j];
                        bSimple [j] = n;
                    }
        }
        static void burbujaMejorada() {
            bool bandera = true;

            for (int i = 0; i < bMejorada.Length - 1 && bandera; i++) {
                bandera = false;
                for (int j = 0; j < bMejorada.Length - i - 1; j++)
                    if (bMejorada [j] < bMejorada [j + 1]) {
                        bandera = true;
                        double cal = bMejorada [j];
                        bMejorada [j] = bMejorada [j + 1];
                        bMejorada [j + 1] = cal;
                    }
            }
        }
        static void burbujaOptimizada() {
            int i = 1;
            bool ordenado = true;
            string aux;
            do {
                i++;
                ordenado = true;
                for (int j = 0; j < bOptimizada.Length - 1; j++) {
                    if (string.Compare(bOptimizada [j], bOptimizada [j + 1]) < 0) {
                        ordenado = false;
                        aux = bOptimizada [j];
                        bOptimizada [j] = bOptimizada [j + 1];
                        bOptimizada [j + 1] = aux;
                    }
                }
            } while (i < bOptimizada.Length && !ordenado);
        }
        static void subMenu() {
            bool desplegando = true;
            while (desplegando) {
                Console.Clear();
                Console.Write("[1] Desplegar Burbuja Simple\n[2] Desplegar Burbuja Mejorada\n[3] Desplegar Burbuja Optimizada\n[! Otro]\nSelecciona una opción: ");
                switch (Console.ReadLine()) {
                    case "1":
                        Console.Clear();
                        Console.Title = "Desplegar datos ordenados con el metodo Burbuja Simple de forma ascendente";
                        Despliegue(bSimple);
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Title = "Desplegar datos ordenados con el metodo Burbuja Mejorada de forma descendente";
                        Despliegue(bMejorada);
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Title = "Desplegar datos ordenados con el metodo Burbuja Optimizada de forma descendente";
                        Despliegue(bOptimizada);
                        Console.ReadKey();
                        break;

                    default:
                        desplegando = false;
                        break;
                }
            }
        }
        static void Despliegue(string [] vector) {
            for (int i = 0; i < bSimple.Length; i++)
                Console.Write(vector [i] + " | ");
        }
        static void Despliegue(double [] vector) {
            for (int i = 0; i < bSimple.Length; i++)
                Console.Write(vector [i] + " | ");
        }
    }
}