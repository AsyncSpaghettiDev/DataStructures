using System;

namespace PilasRecursivas {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Pilas a usar
            int limite = 50;
            int [] edades = new int [limite];

            // Variables auxiliares
            bool operando = true;
            int indice = 0;

            while (operando) {
                //Se prepara la consola
                Console.Clear();
                Console.Title = "Menu Operaciones Recursivas con Pilas";

                // Despliegue de opciones
                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Mostrar recurriendo\n[!] Cualquier otra para salir\nSelecciona una opción: ");
                string seleccion = Console.ReadLine();

                switch (seleccion) {

                    // Opcion para agregar un nuevo elemento a la pila y se actualiza el indice
                case "1":
                    // Se prepara la consola.
                    Console.Title = "Capturando Edades";

                    // Llamada al metodo para ingresar datos en la pila
                    indice = IngresarElemento(ref edades, indice, limite);
                    break;

                    // Opcion para eliminar un elemento de la pila y actualizar el indice
                case "2":
                    Console.Title = "Eliminando Edades";
                    indice = EliminarElemento(ref edades, indice);
                    break;

                    // Opcion para recorrer la pila desde la posicion actual
                case "3":
                    Console.Title = "Recorrer elementos de la pila";
                    RecorrerElementos(edades, indice);
                    break;

                    // Opcion para salir del menu 
                default:
                    operando = false;
                    break;
                }
            }
        }
        // Comprobación que la pila no ha llegado a su tope
        static bool Llena(int limite, int indice) => limite <= indice;
        // Comprobación que la pila no está vacia.
        static bool Vacia(int indice) => indice <= 0;
        // Metodo de inserción de una edad en una pila
        static int IngresarElemento(ref int [] edades, int indice, int limite) {
            // Se limpia la consola
            Console.Clear();

            // Se comprueba que la pila no esta llena, en caso de estarlo se termina el metodo
            if (Llena(limite, indice)) { Console.Write("Pila Llena..."); Console.ReadKey(); return indice; }

            // Variables auxiliares
            bool valido = false;
            int edad;

            // Captura de edad y validación de edad
            do {
                Console.Write("Ingresa la edad #{0} (recuerda que debe ser mayor de 18 años): ", indice + 1);
                valido = int.TryParse(Console.ReadLine(), out edad) && edad >= 18;
            }
            while (!valido);

            edades[indice] = edad;

            // Comprobación de seguir capturando
            Console.Write("[1] Si\n[!] Otro para no\n¿Deseas seguir ingresando edades en la pila? ");

            // Llamada recursiva
            if (Console.ReadLine().Contains("1")) return IngresarElemento(ref edades, indice + 1, limite);
            else return indice + 1;
        }
        static int EliminarElemento(ref int [] edades, int indice) {
            // Se limpia la consola
            Console.Clear();

            // Se comprueba que la pila no esté vacia, en caso de estarlo se termina el metodo
            if (Vacia(indice)) { Console.Write("Pila Vacia..."); Console.ReadKey(); return indice; }

            // Comprobación de eliminar la edad
            Console.Write("[1] Si\n[!] No\n¿Seguro que deseas eliminar la edad #{0}?: ", indice);
            if (Console.ReadLine().Contains("1")) edades [indice - 1] = 0;
            else return indice;

            // Comprobación de seguir eliminando
            Console.Write("\n[1] Si\n[!] Otro para no\n¿Deseas seguir eliminando edades en la pila? ");

            // Llamada recursiva
            if (Console.ReadLine().Contains("1")) return EliminarElemento(ref edades, indice - 1);
            else return indice - 1;
        }
        static void RecorrerElementos(int [] edades, int indice) {
            // limpiar consola
            Console.Clear();

            // Se comprueba que la pila no esté vacia, en caso de estarlo se termina el metodo
            if (Vacia(indice)) {
                Console.Write("Pila Vacia...");
                Console.ReadKey();
            }
            else {
                // Se muestra la edad
                Console.WriteLine("Calificación #{0} = {1}", indice, edades [indice - 1]);

                // Comprobación de seguir recurriendo
                Console.Write("\n[1] Si\n[!] Otro para no\n¿Deseas seguir recurriendo edades en la pila? ");

                // Llamada recursiva
                if (Console.ReadLine().Contains("1")) RecorrerElementos(edades, indice - 1);
            }
        }
    }
}