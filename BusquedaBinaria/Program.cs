using System;

namespace BusquedaBinaria {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            int [] numeros = new int [20];
            bool operando = true;
            while (operando) {
                Console.Clear();
                Console.Title = "Menu de opciones Busqueda Binaria";
                Console.Write("[1] Capturar numeros de control\n[2] Busqueda Binaria de elementos\n[3] Despliegue de valores\n[! Otro] Salir\nSelecciona una opción: ");

                switch (Console.ReadLine()) {
                    case "1":
                        Console.Clear();
                        Console.Title = "Capturando números de trabajador.";
                        Capturar(ref numeros);
                        Console.Write("Datos Capturados Correctamente...");
                        Console.ReadKey();
                        goto case "3";

                    case "2":
                        Console.Clear();
                        Console.Title = "Busqueda Binaria de Datos";
                        Array.Sort(numeros);
                        Array.Reverse(numeros);
                        int buscar = 0;
                        do Console.Write("Ingresa el número de empleado a buscar: "); while (!int.TryParse(Console.ReadLine(), out buscar));
                        Binaria(numeros, buscar);
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Title = "Despliegue de Datos";
                        foreach (int c in numeros) Console.WriteLine(c);
                        Console.Write("Datos Desplegados Correctamente...");
                        Console.ReadKey();
                        break;

                    default:
                        operando = false;
                        break;
                }
            }
        }
        static void Capturar(ref int [] numeros) {
            for (int i = 0; i < numeros.Length; i++)
                do Console.Write($"Ingresa el número de control del empleado #{ i + 1 }: "); while (!int.TryParse(Console.ReadLine(), out numeros [i]) || numeros [i] < 10 || numeros [i] > 30);
        }
        static void Binaria(int [] numeros, int buscando) {
            int mitad = 0;
            int inferior = 0;
            int superior = numeros.Length - 1;
            bool encontrado = false;

            while (inferior <= superior && !encontrado) {
                mitad = (inferior + superior) / 2;
                if (numeros [mitad] == buscando) encontrado = true;
                else if (numeros [mitad] > buscando) inferior = mitad + 1;
                else superior = mitad - 1;
            }
            Console.Write(encontrado ? $"El dato { buscando } fue encontrado en la posición #{ mitad }..." : $"El dato { buscando } no fue encontrado...");
        }
    }
}