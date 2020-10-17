using System;

namespace ColaSimple {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Se solicita al usuario el tamaño de la cola
            Console.Clear();
            Console.Title = "Capturando tamaño de la cola";

            // Variables auxiliares 
            int tamano;
            bool valido = false;

            // Nos aseguramos de recibir un dato válido
            do {
                Console.Write("Ingresa el tamaño de la cola: ");
                valido = Int32.TryParse(Console.ReadLine(), out tamano) && tamano > 0;
            }
            while (!valido);

            // Se declara la cola a usar
            int [] edades = new int [tamano];
            int limiteInferior = -1;
            int limiteSuperior = -1;

            // Se declara el menú a usar
            bool operando = true;

            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menu de Operaciones con Colas";

                // Despliegue de opciones
                Console.Write("[1] Insertar\n[2] Eliminar\n[!] Cualquier otra para salir\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                // Seleccionador de opciones
                switch (opcion) {
                    // Opcion de insertar a la cola
                case "1":
                // Se nombra a la consola
                    Console.Title = "Insertando edades a la cola";
                    // Se declara ciclo de captura
                    bool capturando = true;
                    do {
                        // Se limpia comsola
                        Console.Clear();

                        // Se comprueba que la cola no esté llena
                        if ((limiteSuperior + 1) >= edades.Length) {
                            Console.Write("Cola Llena...");
                            Console.ReadKey();
                            capturando = false;
                        }
                        else {
                            // Variables auxiliares
                            int edad;
                            bool validando = false;

                            // Nos aseguramos de recibir una edad válida
                            do {
                                Console.Write("Ingresa la edad #{0} a registrar: ", limiteSuperior + 2);
                                validando = Int32.TryParse(Console.ReadLine(), out edad) && edad > 0;
                            }
                            while (!validando);

                            // Se inserta la edad en la cola
                            limiteSuperior++;
                            edades [limiteSuperior] = edad;

                            // En caso de no estar "inicializado" se inicializa el limiteInferior
                            if (limiteInferior == -1) limiteInferior = 0;

                            // Se comprueba si el usuario quiere seguir ingresando edades
                            
                            Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir capturando edades?: ");
                            capturando = Console.ReadLine().Contains("1");
                        }
                    }
                    while (capturando);
                    // Despliegue de la cola
                    Console.Title = "Mostrando la cola";
                    foreach (int edad in edades) Console.Write("Edad: {0}| ", edad);
                    Console.ReadKey();

                    break;

                // Opcion de eliminar de la cola
                case "2":
// Se nombra a la consola
                    Console.Title = "Eliminando edades de la cola";

                    // Declaracion de ciclo de eliminación
                    bool eliminando = true;
                    do {
                        // Se limpia la consola
                        Console.Clear();
                        
                        // Se recibe confirmación de eliminar edad
                        Console.Write("[1] Si\n[!] Cualquier otro para no\n¿Confirma eliminar la edad {0}?: ", edades [limiteInferior] + 1);
                        // En caso de no confirmarlo se cierra el ciclo de eliminacion
                        if (!Console.ReadLine().Contains("1")) eliminando = false;
                        // En caso de querer eliminarlo se comprueba
                        else if (limiteInferior == -1) {
                            Console.Write("Cola Vacia...");
                            eliminando = false;
                            Console.ReadKey();
                        }
                        // En caso que no esté vacia la cola se comprueba que el elemento que se eliminará no sea el ultimo agregado
                        // en caso de serlo, se elimina el elemento de la cola y se reestablecen los contadores en -1
                        else if (limiteInferior == limiteSuperior) {
                            edades [limiteInferior] = 0;
                            limiteInferior = limiteSuperior = -1;

                            Console.Write("Cola Vaciada...");
                            eliminando = false;
                            Console.ReadKey();
                        }
                        // En caso que no sean el mismo solo se elimina el elemento y se aumenta en 1 el limiteInferior
                        else {
                            edades [limiteInferior] = 0;
                            limiteInferior++;

                            // Se comprueba si quiere seguir eliminando elementos
                            Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando edades?: ");
                            eliminando = Console.ReadLine().Contains("1");
                        }

                    }
                    while (eliminando);
                    // Despliegue de la cola
                    Console.Title = "Mostrando la cola";
                    foreach (int edad in edades) Console.Write("Edad: {0}| ", edad);
                    Console.ReadKey();
                    break;

                // Opción de salida del ciclo.
                default:
                    operando = false;
                    break;
                }
            }
        }
    }
}