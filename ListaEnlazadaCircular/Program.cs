using System;

namespace ListaEnlazadaCircular {

    class Program {
        class Nodo {
            public string Pais;
            public Nodo dir;
        }
        static Nodo Inicio;
        static Nodo Final;
        static Nodo Temporal;
        static Nodo a;
        static Nodo s;
        static String DatoTemp;
        static String PaisLocal;
        static int Tamano = 0;
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            Inicio = null;
            Final = null;

            // Declaración del menú
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menu de operaciones con Listas Enlazadas Circulares";

                // Despliegue de opciones
                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Mostrar\n[! Otro] Salir\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                // Opciones del menu
                switch (opcion) {
                case "1":
                    // Se prepara la consola
                    Console.Title = "Insertar elementos en la lista";

                    // Declaracion del ciclo de captura
                    bool capturando = true;
                    while (capturando) {
                        // Se limpia la consola
                        Console.Clear();
                        // Captura del pais a registrar
                        Console.Write("Ingresa el pais a registrar: ");
                        PaisLocal = Console.ReadLine();

                        // Se manda llamar al metodo
                        Insertar();

                        // Comprobación de la inserción
                        Console.WriteLine();
                        Imprimir();

                        // Se comprueba si seguir capturando elementos
                        Console.Write("\n\n[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro pais?: ");
                        capturando = Console.ReadLine().Contains("1");

                    }
                    break;

                case "2":
                    // Se nombra la consola
                    Console.Title = "Eliminando elementos en la lista";

                    // Declaración del ciclo de eliminación
                    bool eliminando = true;
                    while (eliminando) {
                        // Se limpia la consola
                        Console.Clear();

                        // En caso de no estar inicializado el nodo principal significa que la lista está vacia.
                        if (Inicio == null) {
                            Console.Write("Lista Vacia...");
                            Console.ReadKey();
                            eliminando = false;
                        }
                        else {
                            // Se limpia la consola
                            Console.Clear();
                            Imprimir();

                            // Se solicita que ingrese el dato a eliminar y se almacena en la variable pais local
                            Console.Write("\n¿Que país deseas eliminar?: ");
                            PaisLocal = Console.ReadLine();

                            // Se llama al método de eliminar
                            Eliminar();

                            // Se comprueba si quiere seguir eliminando paises
                            if (eliminando) {
                                Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando paises?: ");
                                eliminando = Console.ReadLine().Contains("1");
                            }
                        }
                    }
                    break;

                case "3":
                    // Se prepara la consola
                    Console.Clear();
                    Console.Title = "Mostrando la lista";
                    // Se llama al metodo desplegar
                    Imprimir();
                    Console.ReadKey();
                    break;

                default:
                    operando = false;
                    break;
                }
            }
        }
        // Metodo encargado de insertar datos en la lista
        static void Insertar() {
            // En caso de no estar inicializada la lista se inicializa los 2 primeros apuntadores
            // El apuntador final se apunta al inicial 
            if (Inicio == null) {
                Inicio = new Nodo();
                Inicio.Pais = PaisLocal;
                Final = Inicio;
                Final.dir = Inicio;
            }
            // Se comparan los datos con los apuntadores anteriores para que la lista se encuentre ordenada de manera alfabetica
            else {
                // En caso que sea menor significa que el valor a ingresar es anterior al que está en la primer posición
                if (string.Compare(PaisLocal, Inicio.Pais) < 0) {
                    // Se inicializa un nodo temporal que contendrá el pais ingresado y que apunta al inicio
                    Temporal = new Nodo() {
                        Pais = PaisLocal,
                        dir = Inicio
                    };
                    // Se establece que el nodo inicial ahora es el Temporal y se redirecciona el apuntador del final.
                    Inicio = Temporal;
                    Final.dir = Inicio;
                }
                else if (string.Compare(PaisLocal, Final.Pais) > 0) {
                    // Se inicializa un nodo temporal que contendrá el pais ingresado y apunta al primer nodo
                    Temporal = new Nodo() {
                        Pais = PaisLocal,
                        dir = Inicio
                    };
                    // Se establece que el nodo Final anterior apuntará al nuevo y el final ahora es el Temporal.
                    Final.dir = Temporal;
                    Final = Temporal;

                }
                else {
                    // En caso de no ser mayor a los nodos de las esquinas se ciclará hasta encontrar
                    // uno en el que el dato ingresado sea menor al capturado.
                    // En cada iteracion se recorrerá un nodo
                    a = Inicio;
                    s = Inicio.dir;
                    while (string.Compare(PaisLocal, s.Pais) > 0) {
                        a = s;
                        s = s.dir;
                    }
                    // Se crea un nodo temporal con el dato ingresado y que apuntará al que es mayor que el
                    Temporal = new Nodo() {
                        Pais = PaisLocal,
                        dir = s
                    };
                    // Al redirecciona el apuntador del nodo anterior
                    a.dir = Temporal;
                }
            }
            // Se aumenta el tamaño
            Tamano++;
        }
        // Metodo que muestra todos los datos de la lista
        static void Imprimir() {
            // Se indica el tamaño de la lista y en caso de no estar vacia se inicializan
            // 2 puntadores auxiliares con el inicio y el siguiente del inicio.
            Console.WriteLine($"Lista con { Tamano } elementos");
            if (Inicio != null) {
                a = Inicio;
                s = Inicio.dir;

                // Se imprime el valor del nodo inicial y se imprime el valor del nodo siguiente del inicial.
                // Al final de cada iteración el segundo apuntador cambiará por el siguiente nodo del nodo actual
                // hasta que el siguiente nodo sea el primer nodo
                Console.Write("{0} | ", a.Pais);
                while (s != a) {
                    Console.Write("{0} | ", s.Pais);
                    s = s.dir;
                }
            }
            // En caso contrario se marcan como null, por si se han llegado a utilizar anteriormente
            // y se indica que la lista se encuentra vacia
            else {
                a = s = null;
                Console.Write("Lista Vacia...");
            }

        }
        // Metodo encargado de eliminar
        static void Eliminar() {
            // Si solo se tiene el primer elemento se comprueba que el dato que se quiere eliminar exista
            if (Inicio == Final) {
                if (PaisLocal == Inicio.Pais) {
                    // Se muestra que se ha eliminado el dato
                    Console.WriteLine("\nDato Eliminado: {0} ...", Inicio.Pais);

                    // Al ser el primero y el ultimo lo mismo se declaran como null y se decrementa el tamaño
                    Inicio = Final = null;
                    Tamano--;
                }
                // En caso contrario se indica que el dato no existe
                else Console.WriteLine("\nEl dato {0} no existe en la lista...", PaisLocal);

            }
            // En caso de que la lista tenga mas de un elemento se comprueba que el dato ingresado no sea el del primer nodo
            else if (PaisLocal == Inicio.Pais) {
                // En caso de ser cierto se muestra que se ha eliminado el dato
                Console.WriteLine("\nDato Eliminado: {0} ...", Inicio.Pais);
                // Se guarda el nodo inicial en uno temporal
                Temporal = Inicio;
                // Ahora inicio será el nodo que le sigue
                Inicio = Inicio.dir;
                // Se elimina el nodo temporal
                Temporal = null;
                // Se redirecciona el apuntador del final
                Final.dir = Inicio;
                // Se decrementa el tamaño
                Tamano--;
            }
            // Se revisa si el dato a eliminar es el ultimo en caso de ser asi se eliminará
            else if (PaisLocal == Final.Pais) {
                // Se guarda en una variable temporal el dato a borrar
                DatoTemp = Final.Pais;

                // Se establecen nodos auxiliares inicializados en el primer nodo
                a = Inicio;
                s = Inicio.dir;

                // Se recorren los datos de la lista hasta llegar al tope
                while (s != Final) {
                    a = s;
                    s = s.dir;
                }
                // Se establece que el ultimo dato será el anterior al final
                Final = a;
                // Se limpia el nodo auxiliar que era el final
                s = null;
                // Se redirige el apuntador del final al nodo del inicio
                Final.dir = Inicio;
                // Se indica que se ha eliminado el dato
                Console.WriteLine("\nDato Eliminado: {0} ...", DatoTemp);
                // Se decrementa el tamaño de la lista
                Tamano--;
            }
            // En caso que no se encuentre el dato a eliminar en los extremos se recorre la lista buscando el dato
            else {
                // Se inicializan los nodos auxiliares en el nodo principal
                a = Inicio;
                s = Inicio.dir;
                // Se recorre la lista hasta que se encuentre el dato en la lista
                while (PaisLocal != s.Pais && s != Final) {
                    a = s;
                    s = s.dir;
                }
                // Si el nodo llega al final significa que no coincidió ningun dato
                if (s == Final) Console.WriteLine("\nEl dato {0} no existe en la lista...", PaisLocal);
                // En caso de no haber llegado al final procedemos eliminar el dato
                else {
                    // Se muestra el dato eliminado
                    Console.WriteLine("\nDato Eliminado: {0} ...", DatoTemp);
                    // Se restablece el nodo temporal como el siguiente del nodo a eliminar
                    Temporal = s.dir;
                    // En nodo anterior ahora apuntará al nodo temporal
                    a.dir = Temporal;
                    // Se establece s al inicio
                    s = Inicio;

                }
            }
            Console.ReadKey();
        }
    }
}