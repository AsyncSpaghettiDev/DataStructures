using System;

namespace ColaMetodos {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Se declara cola a usar
            string [] animales = new string [50];
            int limiteInferior = -1;
            int limiteSuperior = -1;

            // Se declara el menu de opciones
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menu de operaciones con Colas V2.0";

                // Despliegue de opciones
                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Buscar\n[4] Mostrar la cola\n[!] Cualquier otra para salir\nSelecciona una opción: ");
                // Captura de la opcion elegida
                string eleccion = Console.ReadLine();

                // Switch de seleccion de menú
                switch (eleccion) {
                    // Opcion de para insertar en la cola
                case "1":
                    // Se nombra a la consola
                    Console.Title = "Insertando en la cola";
                    // Se declara ciclo de captura
                    bool capturando = true;
                    while (capturando) {
                        // Se limpia la consola
                        Console.Clear();

                        // Captura de nombre de la mascota
                        Console.Write("Ingresa el nombre de tu mascota #{0}: ", limiteSuperior + 2);
                        string insertado = Console.ReadLine();

                        // Se manda el nombre a insertar al metodo adecuado
                        capturando = Insertar(ref animales, ref limiteInferior, ref limiteSuperior, insertado);

                        // Se comprueba si seguir capturando elementos
                        if (capturando) {
                            Console.Write("[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro nombre de tu mascota?: ");
                            capturando = Console.ReadLine().Contains("1");
                        }

                    }
                    // Se pasa al caso 2 para dar la opción a eliminar
                    goto case "2";

                    // Opcion de eliminar elementos de la cola
                case "2":
                    // Se nombra a la consola
                    Console.Title = "Eliminando elementos";
                    // Se declara ciclo de eliminación
                    bool eliminando = true;
                    while (eliminando) {
                        // Se limpia la consola
                        Console.Clear();
                        // Se confirma la eliminación
                        Console.Write("[1] Si\n[!] Cualquier otro para no\n¿Confirma eliminar el nombre #{0} de sus mascota?: ", limiteInferior + 1);
                        // En caso de no confirmarlo se cierra el ciclo de eliminacion
                        if (!Console.ReadLine().Contains("1")) eliminando = false;
                        // En caso de querer eliminarlo se elimina el elemento
                        else {
                            eliminando = Eliminar(ref animales, ref limiteInferior, ref limiteSuperior);

                            // Se comprueba si quiere seguir eliminando elementos
                            if (eliminando) {
                                Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando nombres de mascota?: ");
                                eliminando = Console.ReadLine().Contains("1");
                            }
                        }

                    }
                    break;

                    // Opcion de buscar un nombre en la cola
                case "3":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Buscando nombre en la Cola";
                    // Se captura el nombre a buscar
                    Console.Write("Escribe el nombre de una mascota a buscar: ");
                    Buscar(animales, limiteInferior, limiteSuperior, Console.ReadLine());
                    break;
                    // Opcion de mostrar la cola
                case "4":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Mostrando la cola";
                    // Se llama al metodo desplegar
                    Desplegar(animales);
                    break;

                    // Salida del menú
                default:
                    operando = false;
                    break;
                }
            }
        }
        // Se comprueba si la pila se ha llenado
        static bool Llena(int tope, int indiceSuperior) => tope <= indiceSuperior;
        // Se comprueba si la pila se ha vaciado
        static bool Vacia(int indiceInferior) => indiceInferior == -1;
        // Metodo encargado de insertar elementos a una cola
        static bool Insertar(ref string [] animales, ref int limiteInferior, ref int limiteSuperior, string insertado) {
            // Se comprueba si la cola se ha llenado, en caso de ser asi se devuelvo falso indicando que el proceso ha acabado
            if (Llena(animales.Length, limiteSuperior)) {
                Console.Write("Cola Llena...");
                Console.ReadKey();
                return false;
            }
            // En caso contrario se inserta
            else {
                // Se inserta el nombre en la cola
                limiteSuperior++;
                animales [limiteSuperior] = insertado;

                // En caso de no estar "inicializado" se inicializa el limiteInferior
                if (limiteInferior == -1) limiteInferior = 0;
                return true;
            }

        }
        // Metodo encargado de eliminar un elemento de la cola
        static bool Eliminar(ref string [] animales, ref int limiteInferior, ref int limiteSuperior) {
            // Se comprueba si la cola se encuentra vacia y regresa false indicando que el metodo se ha vaciado
            if (Vacia(limiteInferior)) {
                Console.Write("Cola Vacia... ");
                Console.ReadKey();
                return false;
            }
            // En caso que intentes eliminar el ultimo elemento ingresado te dejará y regresará false indicando que el metodo ha concluido
            if (limiteInferior == limiteSuperior) {
                animales [limiteInferior] = null;
                limiteInferior = limiteSuperior = -1;

                // Tras eliminar el dato se indica que la cola ha sido vaciada
                Console.Write("Cola Vaciada... ");
                Console.ReadKey();
                return false;
            }
            // En caso que no esté llena se elimina el elemento y se aumenta en 1, y regresas true indicando que el metodo sigue vigente
            else {
                animales [limiteInferior] = null;
                limiteInferior++;
                return true;
            }
        }
        // Metodo encargado de buscar un elemento en una cola
        static void Buscar(string [] animales, int Inferior, int Superior, string buscando) {
            // Se asigna un bool en el que se registrará si se ha encontrado
            bool encontrado = false;
            if (Vacia(Inferior)) {
                Console.Write("Cola Vacia... ");
                Console.ReadKey();
            }
            else {
                for (int i = Inferior; i <= Superior; i++)
                    // En caso que un elemento contenga el nombre indicado se establece el bool encontrado, y se rompe el ciclo
                    if (animales [i].Replace(" ", "").ToLower().Equals( buscando.Replace(" ", "").ToLower() ) ) {
                        Console.Write($"Se encontró { buscando } en la posición { i + 1 } de la cola");
                        encontrado = true;
                        break;
                    }
                // En caso de no haber encontrado nada se indica con consola
                if (!encontrado) Console.Write($"No se encontró { buscando } en la cola: ");
                // Se deja que el usuario vea el mensaje desplegado anteriormente
                Console.ReadKey();
            }
        }
        // Metodo encargado de desplegar la cola
        static void Desplegar(string [] animales) {
            foreach (string animal in animales) Console.Write(animal + " | ");
            // Se deja que el usuario pueda ver el desplegado.
            Console.ReadKey();
        }
    }
}