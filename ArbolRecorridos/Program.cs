using System;

namespace ArbolRecorridos {
    class Arbol {
        public string dato;
        public Arbol ramaDer = null;
        public Arbol ramaIzq = null;
    }
    class Program {
        static Arbol raiz;
        static Arbol t;
        static Arbol t2;
        static Arbol re;
        static bool fin = false;
        static string x;
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            raiz = null;

            // Declaración del menu
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menu de recorridos con arboles";
                // Despliegue de opciones
                Console.Write("[1] Insertar nombres\n[2] Recorrer en PreOrden\n[3] Recorrer en InOrden\n[4] Recorren en PostOrden\n[! Otro] Salir\nSelecciona una opción: ");

                switch (Console.ReadLine()) {
                    case "1":
                        // Se nombra la consola
                        Console.Title = "Insertando nombres en el Arbol";
                        InsertarArbol();
                        break;

                    case "2":
                        // Se prepara la consola
                        Console.Title = "Mostrando el arbol en PreOrden";
                        Console.Clear();

                        // Despliegue por PreOrden
                        re = raiz;
                        PreOrden(re);

                        // Notificación de despliegue terminado
                        Console.Write("\nRecorrido Completado...");
                        Console.ReadKey();
                        break;

                    case "3":
                        // Se prepara la consola
                        Console.Title = "Mostrando el arbol en InOrden";
                        Console.Clear();

                        // Despliegue por InOrden
                        re = raiz;
                        InOrden(re);

                        // Notificación de despliegue terminado
                        Console.Write("\nRecorrido Completado...");
                        Console.ReadKey();
                        break;

                    case "4":
                        // Se prepara la consola
                        Console.Title = "Mostrando el arbol en PostOrden";
                        Console.Clear();

                        // Despliegue por PostOrden
                        re = raiz;
                        PostOrden(re);

                        // Notificación de despliegue terminado
                        Console.Write("\nRecorrido Completado...");
                        Console.ReadKey();
                        break;

                    default:
                        operando = false;
                        break;
                }
            }
        }
        static void InsertarArbol() {
            try {
                bool capturando = true;
                while (capturando) {
                    Console.Clear();
                    Console.Write("Ingresa el nombre del familiar: ");
                    x = Console.ReadLine();

                    Insertar();

                    re = raiz;

                    Console.Write("\n\n[1] Si\n[! Otro] No\n¿Desea Insertar otro nombre?: ");
                    capturando = Console.ReadLine().Contains("1");
                }
            }
            catch (Exception) {
                Console.WriteLine("Solo se Pueden Ingresar nombres de personas, intente de nuevo...");
            }
        }
        static void Insertar() {
            // Se inicializa la raiz en caso de no tenerlo inicializado
            if (raiz == null)
                raiz = new Arbol {
                    dato = x
                };
            // En caso contrario se recorre hasta encontrar la posición vacia indicada
            else {
                // Variables auxiliares
                fin = false;
                t = raiz;
                // Se recorre todo el arbol hasta que se indique que se insertó
                while (fin != true) {
                    // Se comprueba que sea mayor y se intenta insertar por derecha en caso que no esté inicializado
                    if (string.Compare(x, t.dato) >= 0) {
                    if (t.ramaDer == null) {
                    t2 = new Arbol {
                    dato = x
                            };
                            t.ramaDer = t2;
                            fin = true;
                        }
                        // En caso contrario se indicia que se continuará por la rama derecha
                        else t = t.ramaDer;

                    }
                    // En caso de ser menor se intenta insertar por izq si esta sin inicializar
                    else {
                        if (t.ramaIzq == null) {
                            t2 = new Arbol {
                            dato = x
                            };
                            t.ramaIzq = t2;
                            fin = true;
                        }
                        // En caso contrario se continuará por izquierda
                        else t = t.ramaIzq;

                    }
                }
            }
            // Se indica que se ha insertado el dato
            Console.Write("Dato Ingresado con Exito...");
            Console.ReadKey();
        }
        static void PreOrden(Arbol temp) {
            // Se comprueba que el arbol esté inicializado para recorrer
            if (temp != null) {
                // Impresión de la raiz del arbol o subarbol a imprimir
                Console.Write($"{ temp.dato } | ");
                // Se recorre el subarbol izquierdo y el derecho
                if (temp.ramaIzq != null) PreOrden(temp.ramaIzq);
                if (temp.ramaDer != null) PreOrden(temp.ramaDer);
            }
            else Console.Write("El Arbol Binario está vacio...");
        }
        static void InOrden(Arbol temp) {
            // Se comprueba que el arbol esté inicializado para recorrer
            if (temp != null) {
                // Se recorre por rama izquierdo
                if (temp.ramaIzq != null) InOrden(temp.ramaIzq);

                // Se imprime el nodo actual
                Console.Write($" { temp.dato } | ");

                // Se recorre por rama derecha
                if (temp.ramaDer != null) InOrden(temp.ramaDer);
            }
            else Console.Write("El Arbol Binario está vacio...");
        }
        static void PostOrden(Arbol temp){
            // Se comprueba que el arbol esté inicializado para recorrer
            if(temp != null){
                // Se recorre el subarbol izquierdo y el derecho
                if (temp.ramaIzq != null) PreOrden(temp.ramaIzq);
                if (temp.ramaDer != null) PreOrden(temp.ramaDer);
                // Impresión de la raiz del arbol o subarbol a imprimir
                Console.Write($"{ temp.dato } | ");
            }
            else Console.Write("El Arbol Binario está vacio...");
        }
    }
}