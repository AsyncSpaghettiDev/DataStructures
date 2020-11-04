using System;
using System.Collections.Generic;

namespace ListaEnlazadaList {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Lista a utilizar
            List<string> Mascotas = new List<string>(50);

            // Declaración de menú
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menú de Operaciones con Listas Enlazadas usando List<T>";

                // Despliegue de opciones
                Console.Write("[1] Insertar el nombre de una mascota\n[2] Eliminar el nombre de una mascota\n[3] Vaciar la lista\n" +
                    "[4] Buscar un nombre de mascota en la lista\n[5] Mostrar espacio disponible\n[! Otro] Salir\nSelecciona una opción: ");

                switch (Console.ReadLine()) {
                    // Opcion de insertar elementos
                    case "1":
                        // Se nombra a la consola
                        Console.Title = "Insertando Nombres de mascota";

                        // Se llama al método insertar
                        Insertar(ref Mascotas);

                        break;

                        // Opcion de Eliminar el nombre de una mascota
                    case "2":
                        Console.Title = "Eliminando Nombres de Mascota";

                        // Llamada al método eliminar
                        Eliminar(ref Mascotas);

                        break;

                        // Vaciar la lista
                    case "3":
                        // Se para la consola
                        Console.Clear();
                        Console.Title = "Vaciar la Lista";

                        // Llamada al método mascotas
                        Vaciar(ref Mascotas);

                        break;

                        // Opcion de buscar en la lista
                    case "4":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Buscando un nombre de mascota en la lista";

                        // Llamada al metodo busqueda
                        Busqueda(Mascotas);

                        break;

                        // Mostrar espacios disponibles
                    case "5":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Mostrar espacios diponibles";

                        // Llamada al metodo Disponibles
                        Disponibles(Mascotas);

                        break;

                        // Opcion de salida del menú
                    default:
                        operando = false;
                        break;
                }
            }
        }
        static void Insertar(ref List<string> Mascotas) {
            // Declaración ciclo de captura
            bool capturando = true;
            while (capturando) {
                // Se limpia la consola
                Console.Clear();

                // Se comprueba que la lista no esté llena
                if (Mascotas.Count == Mascotas.Capacity) {
                    Console.Write("Lista Llena");
                    capturando = false;
                    Console.ReadKey();
                }
                else {
                    // Se solicita al usuario ingresa el nombre de la mascota a almacenar
                    Console.Write("Ingresa el nombre de la mascota a registrar: ");
                    String Captura = Console.ReadLine();

                    // Se llama al método de insertar
                    Mascotas.Add(Captura);
                    Mascotas.Sort();

                    // Se despliega toda la lista
                    Console.WriteLine($"\nHaz Ingresado { Mascotas.Count } nombres de mascota en la lista");
                    Desplegar(Mascotas);

                    // Se comprueba si se quiere seguir capturando
                    Console.Write("\n\n[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro nombre de mascota?: ");
                    capturando = Console.ReadLine().Contains("1");
                }
            }
        }
        static void Eliminar(ref List<string> Mascotas) {
            // Se Declara ciclo de eliminación
            bool eliminando = true;
            while (eliminando) {
                // Se limpia la consola
                Console.Clear();

                // Se despliega toda la lista
                Console.WriteLine($"Tienes { Mascotas.Count } nombres de mascota registrados en la lista");
                Desplegar(Mascotas);

                // Se solicita el nombre de mascota a eliminar
                Console.Write("\nIngresa el nombre de mascota a eliminar: ");
                String Elimina = Console.ReadLine();
                // Se muestra que se ha eliminado siempre y cuando el nombre exista en la lista
                Console.WriteLine();
                Console.Write(Mascotas.Remove(Elimina) ? $"{Elimina} se ha borrado correctamente." : $"{Elimina} no se encontró en la lista");

                // En caso que la lista no se encuentre vacia se pregunta si desea seguir eliminando
                if (Mascotas.Count > 0) {
                    Console.Write("\n\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando nombres de mascotas?: ");
                    eliminando = Console.ReadLine().Contains("1");
                }
                // En caso contrario se indica que la lista está vacia y se cierra el ciclo
                else {
                    Console.Write("Lista Vacia...");
                    Console.ReadKey();
                    eliminando = false;
                }
            }
        }
        static void Vaciar(ref List<string> Mascotas) {
            // Se solicita confirmación para vaciar la lista la usuario
            Console.Write("[1] Si\n[! Otro] No\n¿Desea eliminar todos los elementos de la lista?: ");
            if (Console.ReadLine().Contains("1")) {
                Mascotas.Clear();
                Console.Write("Lista Vaciada...");
            }
            Console.ReadKey();
        }
        static void Busqueda(List<string> Mascotas) {
            // Se muestra la lista
            Console.WriteLine($"Tienes { Mascotas.Count } nombres de mascota registrados en la lista");
            Desplegar(Mascotas);

            // Se solicita al usuario ingresar el animal a buscar
            Console.Write("\nIngresa el nombre de la mascota a buscar: ");
            String Buscar = Console.ReadLine();

            // Se imprime si se encontró o no al animal
            Console.Write(Mascotas.Contains(Buscar) ? $"{Buscar} se encuentra en la Lista..." : $"{Buscar} no se encuentra en la lista...");
            Console.ReadKey();
        }
        static void Disponibles(List<string> Mascotas) {

            // Se muestra la lista
            Console.WriteLine($"Tienes { Mascotas.Count } nombres de mascota registrados en la lista");
            Desplegar(Mascotas);

            // Con una resta se muestran los espacions diponibles
            Console.Write($"\nTe quedan { Mascotas.Capacity - Mascotas.Count } espacios de { Mascotas.Capacity } totales...");
            Console.ReadKey();
        }
        static void Desplegar(List<string> Mascotas) {
            foreach (string Mascota in Mascotas)
                Console.Write($"{Mascota} | ");
        }
    }
}