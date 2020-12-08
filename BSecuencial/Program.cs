using System;

namespace BSecuencial {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            // Vectores a usar
            string [] nombres1 = new string [15];
            string [] nombres2 = new string [15];
            string [] nombres3 = new string [15];

            // Declaración del menú
            bool operando = true;
            while (operando) {
                Console.Clear();
                Console.Title = "Busqueda Secuencial";
                Console.Write("[1] Captura de Nombres\n[2] Busqueda por M1\n[3] Busqueda por M2\n[4] Busqueda por M3\n[! Otro] Salir\nSelecciona un opción: ");

                switch (Console.ReadLine()) {
                    case "1":
                        Console.Title = "Captura de Nombre de Empleados";

                        for (int i = 0; i < nombres1.Length; i++) {
                            Console.Clear();
                            Console.Write($"Ingresa el nombre del Empleado #{ i + 1 }: ");
                            string name = Console.ReadLine();
                            Console.Write($"Ingresa el apellido del Empleado # { i + 1 }: ");
                            name += Console.ReadLine();
                            nombres1 [i] = nombres2 [i] = nombres3 [i] = name;
                        }
                        Console.Clear();
                        Desplegar(nombres1);
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Title = "Busqueda Secuencial por M1";

                        Console.Write("Ingresa el nombre a buscar: ");

                        M1(nombres1, Console.ReadLine());
                        Console.ReadKey();
                        Console.Clear();
                        Desplegar(nombres1);
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Title = "Busqueda Secuencial por M2";

                        Array.Sort(nombres2);
                        Console.Write("Ingresa el nombre a buscar: ");
                        M2(nombres2, Console.ReadLine());
                        Console.ReadKey();
                        Console.Clear();
                        Desplegar(nombres2);
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        Console.Title = "Busqueda Secuencial por M3";

                        Array.Sort(nombres3);
                        Array.Reverse(nombres3);

                        Console.Write("Ingresa el nombre a buscar: ");
                        M3(nombres3, Console.ReadLine());
                        Console.ReadKey();
                        Console.Clear();
                        Desplegar(nombres3);
                        Console.ReadKey();
                        break;

                    default:
                        operando = false;
                        break;
                }
            }
        }
        static void Desplegar(string [] nombres) {
            for (int i = 0; i < nombres.Length; i++) Console.WriteLine(nombres [i]);
        }
        static void M1(string [] nombres, string buscando) {
            bool encontrado = false;
            for (int i = 0; i < nombres.Length; i++){
                if(nombres [i].Contains(buscando)) encontrado = true;
                Console.Write( encontrado ? $"El Dato { buscando } ha sido encontrado en la posición #{ i + 1 } :)..." : $"Dato no encontrado Intentando de Nuevo. Intento # { i + 1 }...");
                if(encontrado) break;
            }
        }
        static void M2(string [] nombres, string buscando) {
            int pos = 0;
            bool encontrado = false;
            while (pos < nombres.Length && !encontrado) {
                if (nombres [pos].Contains(buscando)) encontrado = true;
                pos++;
                Console.WriteLine(encontrado ? $"El Dato { buscando } ha sido encontrado en la posición #{ pos + 1} :)..." : $"Dato no encontrado Intentando de Nuevo. Intento # { pos + 1 }...");
            }
        }
        static void M3(string [] nombres, string buscando) {
            int pos = 0;
            bool parar = false;
            bool bandera = false;
            while (pos < nombres.Length && bandera || parar) {
                if (nombres [pos].Contains(buscando)) bandera = true;
                if (pos < nombres.Length) pos++;
                else parar = true;
                Console.WriteLine(bandera ? $"El Dato { buscando } ha sido encontrado en la posicion #{ pos + 1 } :)..." : $"Dato no encontrado Intentando de Nuevo Intento # { pos + 1 }...");
            }
        }
    }
}