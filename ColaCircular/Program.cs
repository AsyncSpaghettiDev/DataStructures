using System;

namespace ColaCircular {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Contadores
            int tamano = 100;
            int Inicio = -1;
            int Final = -1;

            // Declaración de las colas
            int [] sueldos = new int [tamano];
            string [] nombres = new string [tamano];

            // Se declara el ciclo del menu
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menu de Operaciones con Colas Circulares";

                // Despliegue de opciones del menú
                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Recorrer\n[! Otro] Salir\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion) {
                    // Opcion de inserción
                case "1":
                    // Se nombra a la consola
                    Console.Title = "Insertando en la cola";

                    // Se declara ciclo de captura
                    bool capturando = true;
                    while (capturando) {
                        // Se limpia la consola
                        Console.Clear();

                        // Captura de nombre del empleado
                        Console.Write("Ingresa el nombre del empleado #{0}: ", Final + 2);
                        string nombre = Console.ReadLine();

                        // Variables auxiliares
                        bool valido = false;
                        int sueldo;

                        // Captura de sueldo y validación
                        do {
                            Console.Write("Ingresa el sueldo de {0} Empleado #{1} : ", nombre, Final + 2);
                            valido = int.TryParse(Console.ReadLine(), out sueldo);
                        }
                        while (!valido);

                        // Se manda el nombre a insertar al metodo adecuado
                        capturando = Insertar(ref nombres, ref sueldos, ref Inicio, ref Final, tamano, nombre, sueldo);

                        // Se comprueba si seguir capturando elementos
                        if (capturando) {
                            Console.Write("[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro registro?: ");
                            capturando = Console.ReadLine().Contains("1");
                        }
                    }
                    Desplegar(nombres, sueldos);
                    Console.ReadKey();
                    break;

                    // Opcion de eliminación
                case "2":
                    // Se nombra a la consola
                    Console.Title = "Eliminando elementos";
                    // Se declara ciclo de eliminación
                    bool eliminando = true;
                    while (eliminando) {
                        // Se limpia la consola
                        Console.Clear();
                        // Se confirma la eliminación
                        Console.Write("[1] Si\n[! Otro] No\n¿Confirma eliminar el registro del empleado #{0} : ", Inicio + 1);
                        // En caso de no confirmarlo se cierra el ciclo de eliminacion
                        if (!Console.ReadLine().Contains("1")) eliminando = false;
                        // En caso de querer eliminarlo se elimina el elemento
                        else {
                            eliminando = Eliminar(ref nombres, ref sueldos, ref Inicio, ref Final, tamano);

                            // Se comprueba si quiere seguir eliminando elementos
                            if (eliminando) {
                                Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando nombres de mascota?: ");
                                eliminando = Console.ReadLine().Contains("1");
                            }
                        }
                    }
                    Desplegar(nombres, sueldos);
                    Console.ReadKey();
                    break;

                    // Opcion de recorrido
                case "3":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Mostrando la cola";
                    // Se llama al metodo desplegar
                    Desplegar(nombres, sueldos);
                    Console.ReadKey();
                    break;

                    // Opcion de salida
                default:
                    operando = false;
                    break;
                }
            }
        }
        // Se comprueba si la cola se ha vaciado
        static bool Vacia(int indiceInferior) => indiceInferior == -1;
        // Metodo encargado de insertar elementos a una cola
        static bool Insertar(ref string [] nombres, ref int [] sueldos, ref int limiteInferior, ref int limiteSuperior, int tamano, string nombre, int sueldo) {
            // Caso en el que el apuntador superior ha llegado hasta el tope de la cola y se debe ciclar
            if ((limiteSuperior + 1) == tamano) {
                limiteSuperior = 0;

                // Se comprueba si la cola se ha llenado, en caso de ser asi se devuelvo falso indicando que el proceso ha acabado
                if (limiteSuperior == limiteInferior) {
                    Console.Write("Colas Llenas...");
                    Console.ReadKey();
                    limiteSuperior = tamano - 1;
                    return false;
                }
                else {
                    nombres [limiteSuperior] = nombre;
                    sueldos [limiteSuperior] = sueldo;
                    return true;
                }
            }
            // Caso de inserción normal
            else {
                if ((limiteSuperior + 1) == limiteInferior) {
                    Console.Write("Colas Llenas...");
                    Console.ReadKey();
                    return false;
                }
                else {
                    // Se insertan en la cola
                    limiteSuperior++;
                    nombres [limiteSuperior] = nombre;
                    sueldos [limiteSuperior] = sueldo;

                    // En caso de no estar "inicializado" se inicializa el limiteInferior
                    if (limiteInferior == -1) limiteInferior = 0;
                    return true;
                }
            }
        }
        // Metodo encargado de eliminar elementos de la cola
        static bool Eliminar(ref string [] nombres, ref int [] sueldos, ref int limiteInferior, ref int limiteSuperior, int tamano) {
            // Se comprueba que la cola no esté vacia
            if (limiteInferior == -1) {
                Console.Write("Colas Vacias...");
                Console.ReadKey();
                return false;
            }
            // En caso contrario se elimina el valor
            else {
                nombres [limiteInferior] = null;
                sueldos [limiteInferior] = 0;

                // En caso que se elimine el ultimo elemento insertado se declara que la lista está vacia
                if (limiteInferior == limiteSuperior) {
                    limiteInferior = -1;
                    limiteSuperior = -1;
                    return false;
                }
                // En caso contrario se aumenta el contador inferior
                else {
                    if ((limiteInferior + 1) == tamano) limiteInferior = 0;
                    else limiteInferior++;

                    return true;
                }
            }
        }
        // Metodo encargado de desplegar los elementos de 
        static void Desplegar(string [] nombres, int [] sueldos) {
            for (int i = 0; i < nombres.Length; i++) Console.WriteLine(
                String.IsNullOrEmpty(nombres [i]) ? "Campo Vacío" : $"Empleado: { nombres [i] }| Sueldo: { sueldos [i] }"
            );
        }
    }
}