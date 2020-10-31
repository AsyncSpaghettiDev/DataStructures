using System;

namespace ListaEnlazadaDoble {
    // Clase nodo que contiene un apuntador a la derecha y la izquierda
    // Ademas del dato a contener
    class Nodo {
        public double sueldo;
        public Nodo dirD = null;
        public Nodo dirI = null;
    }
    class Program {
        static Nodo Inicio;
        static Nodo Final;
        static Nodo Temporal;
        static Nodo a;
        static Nodo s;
        static double datoTemporal;
        static double SueldoLocal;
        static Int32 Tamano;
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            Inicio = Final = null;

            // Declaración del menú
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menú de operaciones con Listas Enlazadas Dobles";

                // Se despleigan las opciones del menú
                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Mostrar por Izquierda\n[4] Mostrar por Derecha\n[! Otro] Salir\nSelecciona una opción: ");
                string eleccion = Console.ReadLine();

                // Seleccion de opciones
                switch (eleccion) {
                    // Insertar elementos a la lista
                    case "1":
                        // Se nombra a la consola
                        Console.Title = "Insercion de elementos en la lista";
                        // Declaracion del ciclo de captura
                        bool capturando = true;
                        while (capturando) {
                            // Se limpia la consola
                            Console.Clear();

                            // Variables auxiliares
                            bool valido = false;

                            // Captura de sueldo y validación de sueldo
                            do {
                                Console.Write("Ingresa el sueldo #{0} a registrar: ", Tamano + 1);
                                valido = double.TryParse(Console.ReadLine(), out SueldoLocal) && SueldoLocal >= 0;
                            }
                            while (!valido);

                            // Se manda llamar al metodo
                            Insertar();

                            // Comprobación de la inserción
                            Console.WriteLine();
                            ImprimirIzq();

                            // Se comprueba si seguir capturando elementos
                            Console.Write("\n\n[1] Si\n[!] Cualquier otra para no\n¿Deseas capturar otro sueldo?: ");
                            capturando = Console.ReadLine().Contains("1");

                        }
                        break;

                        // Eliminar elementos a la lista
                    case "2":
                        // Se nombra a la consola
                        Console.Title = "Eliminar elementos de la lista";
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
                                ImprimirIzq();

                                // Variables auxiliares
                                bool valido = false;

                                // Captura de sueldo a eliminar, como no se va a insertar no importa si el sueldo llega a ser
                                // negativo, no lo encontrará, solo se comprueba que reciba un entero
                                do {
                                    Console.Write("¿Que sueldo deseas eliminar?: ");
                                    valido = double.TryParse(Console.ReadLine(), out SueldoLocal);
                                }
                                while (!valido);

                                // Se llama al método de eliminar
                                Eliminar();

                                // Se comprueba si quiere seguir eliminando paises
                                if (eliminando) {
                                    Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando sueldos?: ");
                                    eliminando = Console.ReadLine().Contains("1");
                                }
                            }
                        }

                        break;

                        // Mostrar elementos de Izq-Derecha
                    case "3":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Mostrando la lista de Izquierda a Derecha";

                        // Se llama al metodo de imprimir de izq a der
                        ImprimirIzq();

                        // Se espera a que el usuario "confirme" la lectura de los datos
                        Console.ReadKey();
                        break;

                        // Mostrar elementos de Der-Izquierda
                    case "4":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Mostrando la lista de Derecha a Izquierda";

                        // Se llama al metodo de imprimir de der a izq
                        ImprimirDer();

                        // Se espera a que el usuario "confirme" la lectura de los datos
                        Console.ReadKey();
                        break;

                        // Salida del menú
                    default:
                        // Cambio de condición para salida del menú.
                        operando = false;
                        break;
                }
            }
        }
        // Metodo encargado de insertar elementos en la lista enlazada doble
        static void Insertar() {
            // En caso que el nodo inicio esté sin inicializar se inicializa solo con el valor ingresado sin apuntar a ningun lado
            // El nodo final ante la falta de nodos será el mismo que el inicial
            // pdst: en caso de no funcionar probar pegar este código despues de la declaración de final = inicio
            /*
             * Final.dirD = Inicio.dirI = null;
             */
            if (Inicio == null) {
                Inicio = new Nodo() {
                sueldo = SueldoLocal
                };
                Final = Inicio;
            }
            // En caso de no ser el primer dato en la lista se procederá a insertar los elementos acomodados de manera ascendente.
            else if (SueldoLocal < Inicio.sueldo) {
                // Se crea un nodo que apunta hacia adelante al nodo principal y tiene el dato ingresado
                Temporal = new Nodo() {
                    sueldo = SueldoLocal,
                    dirD = Inicio
                };
                // El nodo inicio apunta por la izq al nodo temporal
                // El nodo inicio ahora será el nodo temporal.
                Inicio.dirI = Temporal;
                Inicio = Temporal;
            }
            // En caso de ser mayor que el ultimo dato en la lista se insertará el nodo al final
            else if (SueldoLocal > Final.sueldo) {
                // Se crea un nodo temporal con el sueldo ingresado y apunta a la izquierda al nodo final
                Temporal = new Nodo() {
                    sueldo = SueldoLocal,
                    dirI = Final
                };
                // El nodo final apunta por la derecha al nodo temporal
                // El nodo final ahora será el nodo temporal.
                Final.dirD = Temporal;
                Final = Temporal;
            }
            // En caso que el valor ingresado no sea mayor que el ultimo o menor que el primero se colocará en medio de la lista
            // Se comparará con cada nodo y en caso de el valor a ingresar ser mayor que el dato del nodo se procederá a comparar
            // con el nodo al que apunta el nodo actual.
            else {
                a = Inicio;
                s = Inicio.dirD;

                while (SueldoLocal > s.sueldo) {
                    a = s;
                    s = s.dirD;
                }
                // Se crea un nodo temporal que tendrá el dato ingresado
                // Apuntará por izq al nodo predecesor y por derecha al sucesor
                Temporal = new Nodo() {
                    sueldo = SueldoLocal,
                    dirI = a,
                    dirD = s
                };
                // El nodo predecesor por derecha y el nodo sucesor por izquierda apuntarán al nodo que se acaba de crear.
                a.dirD = s.dirI = Temporal;
            }
            Tamano++;
        }
        static void ImprimirIzq() {
            // Se indica el tamaño de la lista y en caso de no estar vacia se inicializan
            // 2 puntadores auxiliares con el inicio y el siguiente del inicio.
            Console.WriteLine($"Lista con { Tamano } elementos");
            if (Inicio != null) {
                a = Inicio;

                // Se imprime el valor del nodo inicial y se imprime el valor del nodo siguiente del inicial.
                // Al final de cada iteración el segundo apuntador cambiará por el siguiente nodo del nodo actual
                // hasta que el siguiente nodo sea el ultimo nodo
                while (a != null) {
                    Console.Write("$ {0} | ", a.sueldo);
                    a = a.dirD;
                }
            }
            // En caso contrario se definen los nodos auxiliares en null
            else {
                a = s = null;
                Console.Write("Lista Vacia...");
            }
        }
        static void ImprimirDer() {
            // Se indica el tamaño de la lista y en caso de no estar vacia se inicializan
            // 2 puntadores auxiliares con el inicio y el siguiente del inicio.
            Console.WriteLine($"Lista con { Tamano } elementos");
            if (Inicio != null) {
                a = Final;

                // Se imprime el valor del nodo inicial y se imprime el valor del nodo siguiente del inicial.
                // Al final de cada iteración el segundo apuntador cambiará por el siguiente nodo del nodo actual
                // hasta que el siguiente nodo sea el ultimo nodo
                while (a != null) {
                    Console.Write("$ {0} | ", a.sueldo);
                    a = a.dirI;
                }
            }
            // En caso contrario se definen los nodos auxiliares en null
            else {
                a = s = null;
                Console.Write("Lista Vacia...");
            }
        }
        static void Eliminar() {
            // Se plantea la posibilidad que la lista tenga un solo dato, esto es asi cuando el inicio y el final
            // de la lista son el "mismo" nodo
            if (Inicio == Final) {
                // Se comprueba que el dato ingresado sea igual al dato almacenado en el nodo inicial
                if (SueldoLocal == Inicio.sueldo) {
                    // Se almacena el dato a eliminar en una variable temporal para luego indicar que se ha eliminado
                    datoTemporal = Inicio.sueldo;
                    // Al ser la lista de solo 1 elemento tanto el nodo inicial como el final se declaran como nulos
                    Inicio = Final = null;
                    Console.WriteLine("\nSueldo Eliminado ${0} ...", datoTemporal);
                    // Se disminuye la lista
                    Tamano--;
                }
                // En caso contrario no se encontró el dato en la unica posición posible y se manda un mensaje
                else Console.WriteLine("\nEl dato no se encontró en la lista para ser eliminado");
            }
            // En caso de que la lista contenga mas de 1 nodo se vuelve a comprobar que el primer nodo no contenga el dato a eliminar
            else if (SueldoLocal == Inicio.sueldo) {
                // Se almacena el dato a eliminar en una variable temporal para luego indicar que se ha eliminado
                datoTemporal = Inicio.sueldo;
                // Se recorre el nodo inicial al nodo que le sigue y el nodo que le sigue
                // que ahora es el inicial perderá el vinculo con el nodo que era antes inicial por la izquierda
                Inicio = Inicio.dirD;
                Inicio.dirI = null;
                // Se indica que se ha eliminado un elemento y se descrementa el contador de elementos de la lista
                Console.WriteLine("\nSueldo Eliminado ${0} ...", datoTemporal);
                Tamano--;
            }
            else if (SueldoLocal == Final.sueldo) {
                // Se almacena el dato a eliminar en una variable temporal para luego indicar que se ha eliminado
                datoTemporal = Final.sueldo;
                // El nodo Final se recorre para abajo y el nuevo nodo final perderá el vinculo con el anterior nodo final
                // dado que este ya no existirá
                Final = Final.dirI;
                Final.dirD = null;
                // Se indica que se ha eliminado un elemento y se descrementa el contador de elementos de la lista
                Console.WriteLine("\nSueldo Eliminado ${0} ...", datoTemporal);
                Tamano--;
            }
            // En caso de que el valor a eliminar no sea el de los extremos se procederá a recorrer la lista de izq a derecha buscando
            // el sueldo que el usuario intenta borrar
            else {
                a = Inicio;
                s = Inicio.dirD;

                while (SueldoLocal != s.sueldo && s.dirD != Final) {
                    a = s;
                    s = s.dirD;
                }
                if (s == Final) Console.WriteLine("\nEl dato no se encontró en la lista para ser eliminado");
                else {
                    // Se almacena el dato a eliminar en una variable temporal para luego indicar que se ha eliminado
                    datoTemporal = s.sueldo;
                    // Se usa un nodo temporal donde guardaremos el nodo que sigue del que vamos a eliminar
                    // A ese nodo que sigue hacemos que apunte al nodo a que es el anterior al nodo que vamos a eliminar
                    // Y al nodo a que es el que va antes del que vamos a eliminar hacemos que apunte por la derecha al nodo temporal
                    // Se limpia el nodo temporal
                    Temporal = s.dirD;
                    Temporal.dirI = a;
                    a.dirD = Temporal;
                    Temporal = null;

                    // Se indica que se ha eliminado un elemento y se descrementa el contador de elementos de la lista
                    Console.WriteLine("\nSueldo Eliminado ${0} ...", datoTemporal);
                    Tamano--;
                }
            }
        }
    }
}