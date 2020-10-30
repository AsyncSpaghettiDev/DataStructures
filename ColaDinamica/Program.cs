using System;
using System.Collections;
using System.Collections.Generic;

namespace ColaDinamica {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Cola Dinamica de nombres
            int Inicio = -1;
            int Final = -1;
            int tamano = 100;
            Queue<string> Nombres = new Queue<string>();

            // Declaración del menú
            bool operando = true;

            while (operando) {
                Console.Clear();
                Console.Title = "Menú de operaciones de Colas Dinamicas";

                Console.Write("[1] Insertar\n[2] Eliminar un elemento\n[3] Eliminar todos los elementos\n[4] Recorrer la cola\n[5] Buscar en la cola\n[! Otro] Salir\nSelecciona una opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion) {
                case "1":
                    // Se nombra a la consola
                    Console.Title = "Insertando en la cola";
                    // Se declara ciclo de captura
                    bool capturando = true;
                    while (capturando) {
                        // Se limpia la consola
                        Console.Clear();

                        // Captura de nombre de la mascota
                        Console.Write("Ingresa el nombre de la persona #{0}: ", Final + 2);
                        string nombre = Console.ReadLine();

                        // Se manda el nombre a insertar al metodo adecuado
                        capturando = Insertar(ref Nombres, ref Inicio, ref Final, tamano, nombre);

                        // Se comprueba si seguir capturando elementos
                        if (capturando) {
                            Console.Write("[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro nombre?: ");
                            capturando = Console.ReadLine().Contains("1");
                        }

                    }
                    // Se pasa al caso 2 para dar la opción a recorrer
                    break;

                case "2":
                    // Se nombra a la consola
                    Console.Title = "Eliminando elementos";
                    // Se declara ciclo de eliminación
                    bool eliminando = true;
                    while (eliminando) {
                        // Se limpia la consola
                        Console.Clear();
                        // Se confirma la eliminación
                        Console.Write("[1] Si\n[!] Cualquier otro para no\n¿Confirma eliminar el nombre #{0}?: ", Inicio + 1);
                        // En caso de no confirmarlo se cierra el ciclo de eliminacion
                        if (!Console.ReadLine().Contains("1")) eliminando = false;
                        // En caso de querer eliminarlo se elimina el elemento
                        else {
                            eliminando = Eliminar(ref Nombres, ref Inicio, ref Final, tamano);

                            // Se comprueba si quiere seguir eliminando elementos
                            if (eliminando) {
                                Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando nombres?: ");
                                eliminando = Console.ReadLine().Contains("1");
                            }
                        }
                    }
                    break;

                case "3":
                    // Se limpia la consola
                    Console.Clear();
                    Console.Title = "Vaciar la cola";
                    Console.Write("[1] Si\n[!] Cualquier otro para no\n¿Confirma vaciar la cola?: ", Inicio + 1);
                    // En caso de no confirmarlo se cancela limpiar la cola
                    if (!Console.ReadLine().Contains("1")) break;
                    else Vaciar(ref Nombres, ref Inicio, ref Final);
                    break;

                case "4":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Mostrando la cola";
                    // Se llama al metodo desplegar
                    Desplegar(Nombres);
                    break;

                case "5":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Buscando nombre en la Cola";
                    // Se captura el nombre a buscar
                    Console.Write("Escribe el nombre de una mascota a buscar: ");
                    Buscar(Nombres, Inicio, Final, Console.ReadLine());
                    break;

                default:
                    operando = false;
                    break;
                }
            }
        }
        // Se comprueba si la pila se ha llenado
        static bool Llena(int tope, int Final) => tope <= Final;
        // Se comprueba si la pila se ha vaciado
        static bool Vacia(int Inicio) => Inicio == -1;
        // Metodo encargado de insertar elementos a una cola
        static bool Insertar(ref Queue<string> nombres, ref int Inicio, ref int Final, int tope, string nombre) {
            // Se comprueba si la cola se ha llenado, en caso de ser asi se devuelvo falso indicando que el proceso ha acabado
            if (Llena(tope, Final)) {
                Console.Write("Cola Llena...");
                Console.ReadKey();
                return false;
            }
            // En caso contrario se inserta
            else {
                // Se inserta el nombre en la cola
                Final++;
                nombres.Enqueue(nombre);

                // En caso de no estar "inicializado" se inicializa el limiteInferior
                if (Inicio == -1) Inicio = 0;
                return true;
            }

        }
        // Metodo encargado de eliminar un elemento de la cola
        static bool Eliminar(ref Queue<string> nombres, ref int Inicio, ref int Final, int tope) {
            // Se comprueba si la cola se encuentra vacia y regresa false indicando que el metodo se ha vaciado
            if (Vacia(Inicio)) {
                Console.Write("Cola Vacia... ");
                Console.ReadKey();
                return false;
            }
            // En caso que intentes eliminar el ultimo elemento ingresado te dejará y regresará false indicando que el metodo ha concluido
            if (Inicio == Final) {
                Console.WriteLine("Elemento Eliminado " + nombres.Dequeue() + ".");
                Inicio = Final = -1;

                // Tras eliminar el dato se indica que la cola ha sido vaciada
                Console.Write("Cola Vaciada... ");
                Console.ReadKey();
                return false;
            }
            // En caso que no esté llena se elimina el elemento y se aumenta en 1, y regresas true indicando que el metodo sigue vigente
            else {
                Console.WriteLine("Elemento Eliminado " + nombres.Dequeue() + ".");
                Inicio++;
                return true;
            }
        }
        static void Vaciar(ref Queue<string> nombres, ref int Inicio, ref int Final) {
            // Se comprueba si la cola se encuentra vacia
            if (Vacia(Inicio)) {
                Console.Write("Cola Vacia... ");
                Console.ReadKey();
            }
            else {
                nombres.Clear();
                Inicio = Final = -1;
            }
        }
        // Metodo encargado de buscar un elemento en una cola
        static void Buscar(Queue<string> nombres, int Inicio, int Final, string buscando) {
            // Se comprueba que la cola no esté vacia
            if (Vacia(Inicio)) {
                Console.Write("Cola Vacia... ");
                Console.ReadKey();
            }
            else {

                Console.Write(
                    nombres.Contains(buscando) ?
                    $"Se encontró { buscando } en la cola. " :
                    $"No se encontró { buscando } en la cola. "
                );

                // Se deja que el usuario vea el mensaje desplegado anteriormente
                Console.ReadKey();
            }
        }
        // Metodo encargado de desplegar la cola
        static void Desplegar(Queue<string> nombres) {
            foreach (string nombre in nombres) Console.Write(nombre + " | ");
            // Se deja que el usuario pueda ver el desplegado.
            Console.ReadKey();
        }
    }
}