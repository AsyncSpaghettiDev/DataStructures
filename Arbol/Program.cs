using System;

namespace Arboles {
    // Definición de un nodo dentro de un arbol
    class Arbol {
        // Valor que tendrá el nodo
        public double sueldo;
        // Apuntador por derecha al nodo hijo
        public Arbol apuntadorDer = null;
        // Apuntador por izquierda al nodo hijo
        public Arbol apuntadorIzq = null;
        public Arbol(double sueldo) => this.sueldo = sueldo;

    }
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Declaración de nodos a usar para crear el árbol.
            Arbol raiz;
            Arbol temp;
            Arbol temp2;
            Arbol re;

            // Declaración de ciclo de menú
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menú de operaciones con Arboles";

                // Despliegue de opciones del menú
                Console.Write("[1] Insertar\n[2] Recorrer en Pre-Orden\n[! Otro] Salir");

                switch (Console.ReadLine()) {
                    // Opción de insertar
                    case "1":
                        // Se prepara la consola
                        Console.Title = "Insertar en el árbol";
                        Console.Clear();
                        // Llamada al método de inserción.
                        InsertarArbol(ref raiz);
                        goto case "2";
                        // Opcion de recorrido Pre-Orden
                    case "2":
                        // Se prepara la consola
                        Console.Title = "Recorrer el árbol en Pre-Orden";
                        Console.Clear();
                        // Llamada al metodo de recorrido
                        PreOrden(Raiz);
                        break;
                        // Opcion de salida
                    default:
                        operando = false;
                        break;
                }
            }
        }
        // Metodo encargado de insertar en el arbol.
        static void InsertarArbol(ref Arbol raiz) {
            // Inicio de ciclo de captura
            bool capturando = true;
            while (capturando) {
                // Variables auxiliares
                bool valido = false;
                double sueldo;
                // Validación de la entrada.
                while (!valido) {
                    Console.Write("Ingresar el sueldo a almacenar: ");
                    valido = double.TryParse(Console.ReadLine(), out sueldo);
                }
                // Llamada al método insercion en caso que el nodo raiz no esté inicializado
                if (raiz == null) raiz = new Arbol(sueldo);
                else Insercion(ref raiz, sueldo);

                // Comprobación de seguir el ciclo
                Console.Write("\n[1] Si\n[! Otro] No\n¿Desea capturar otro sueldo?");
                capturando = Console.ReadLine().Contains("1");
            }
        }
        // Metodo recursivo que recorre los subarboles hasta encontrar donde insertar
        static void Insercion(ref Arbol raiz, double sueldo) {
            // Variables auxiliares
            Arbol temporal = raiz;
            Arbol temporal2;
            // Comprobación lógica para determinar la ruta que seguirá el arbol
            if (string.Compare(sueldo, temporal.sueldo) >= 0)
                // En caso que en el ultimo nodo el apuntador derecho este sin asignar
                // ahi se coloca el nuevo dato, y el apuntador derecho del anterior se 
                // asigna al nuevo nodo.
                if (temporal.apuntadorDer == null) {
                    temporal2 = new Arbol(sueldo);
                    temporal.apuntadorDer = temporal2;
                }
            // En caso de no ser así se llama al metodo pero ahora se recorrerá el subarbol derecho
            else Insercion(ref temporal.apuntadorDer, sueldo);
            // En caso de que se deba insertar por izquierda se comprueba si el nodo tiene hijo por izq
            // En caso de ser null se inserta el nodo y el padre se le asocia al hijo con el apuntador izq
            else if (temporal.apuntadorIzq == null) {
                temporal2 = new Arbol(sueldo);
                temporal.apuntadorIzq = temporal2;
            }
            // En caso de no ser así se recorre el subarbol izquierda
            else Insercion(ref temporal.apuntadorDer, sueldo);

            // Se indica que se ha realizado la inserción correctamente
            Console.Write("Dato Ingresado correctamente...");
            Console.ReadKey();
        }
        // Metodo para recorrer por orden
        static void PreOrden(Arbol Raiz) {
            // Si el arbol tiene almenos un dato
            if (Raiz != null) {
                // Impresión de la raiz del arbol o subarbol a imprimir
                Console.Write($"{ Raiz.sueldo } | ");
                // Se recorre el subarbol izquierdo y el derecho
                PreOrden(Raiz.apuntadorIzq);
                PreOrden(Raiz.apuntadorDer);
            }
        }
    }
}