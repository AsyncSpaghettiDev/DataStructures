using System;

namespace ArbolBuscarEliminar {
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
                Console.Title = "Menu de operaciones con arbol V2.0";
                // Despliegue de opciones
                Console.Write("[1] Insertar ciudades\n[2] Recorrer en InOrden las ciudades\n[3] Buscar un ciudad\n[4] Eliminar una ciudad\n[! Otro] Salir\nSelecciona una opción: ");

                switch (Console.ReadLine()) {
                    case "1":
                        // Se nombra la consola
                        Console.Title = "Insertando ciudades en el Arbol";
                        InsertarArbol();
                        goto case "2";

                    case "2":
                        Console.Title = "Mostrando el arbol en InOrden";
                        Console.Clear();

                        re = raiz;
                        InOrden(re);
                        break;

                    case "3":
                        Console.Title = "Busqueda de una ciudad visitada";
                        Console.Clear();

                        Console.Write("Nombre de la ciudad a buscar: ");
                        x = Console.ReadLine();

                        re = raiz;
                        Busqueda(re);
                        Console.ReadKey();
                        Console.Write("\n\n[1] Si\n[! Otro] No\n¿Desea Buscar otra ciudad?: ");
                        if(Console.ReadLine().Contains("1")) goto case "3";
                        else break;

                    case "4":
                        Console.Title = "Eliminar ciudades visitadas";
                        Console.Clear();

                        EliminarNodo();
                        Console.Write("\n\n[1] Si\n[! Otro] No\n¿Desea Buscar otra ciudad?: ");
                        if(Console.ReadLine().Contains("1")) goto case "4";
                        goto case "2";

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
                    Console.Write("Ingresa el nombre de la ciudad visitada: ");
                    x = Console.ReadLine();

                    Insertar();

                    re = raiz;

                    Console.Write("\n\n[1] Si\n[! Otro] No\n¿Desea Insertar otra ciudad?: ");
                    capturando = Console.ReadLine().Contains("1");
                }
            }
            catch (Exception) {
                Console.WriteLine("Solo se Pueden Ingresar nombre de ciudades, intente de nuevo...");
            }
        }
        static void Insertar() {
            if (raiz == null)
                raiz = new Arbol {
                    dato = x
                };

            else {
                fin = false;
                t = raiz;
                while (fin != true) {
                    if (string.Compare(x, t.dato) >= 0) {
                    if (t.ramaDer == null) {
                    t2 = new Arbol {
                    dato = x
                            };
                            t.ramaDer = t2;
                            fin = true;
                        }
                        else t = t.ramaDer;

                    }
                    else {
                        if (t.ramaIzq == null) {
                            t2 = new Arbol {
                            dato = x
                            };
                            t.ramaIzq = t2;
                            fin = true;
                        }
                        else {
                            t = t.ramaIzq;
                        }
                    }
                }
            }
            Console.Write("Dato Ingresado con Exito...");
            Console.ReadKey();
        }
        static void InOrden(Arbol temp) {
            if (temp != null) {
                if (temp.ramaIzq != null) InOrden(temp.ramaIzq);

                Console.WriteLine(temp.dato);
                Console.ReadKey();

                if (temp.ramaDer != null) InOrden(temp.ramaDer);
            }
            else
                Console.Write("El Arbol Binario está vacio...");

        }
        static void Busqueda(Arbol temp) {
            if (temp != null) {
                if (temp.dato == x) {
                    Console.Write($"La ciudad { x } está en el árbol...");
                }
                else {
                    if (temp.ramaIzq != null) Busqueda(temp.ramaIzq);

                    if (temp.ramaDer != null) Busqueda(temp.ramaDer);
                }
            }
            else
                Console.Write($"La ciudad { x } no está en el árbol...");
        }
        static void EliminarNodo() {
            Arbol p, q, v, s, te;
            bool encontrado = false;
            p = raiz;
            q = null;

            if (p != null) {
                Console.Write("Nodo a eliminar: ");
                x = Console.ReadLine();
                while (p != null && !encontrado) {
                    if (p.dato == x) {
                        encontrado = true;
                        Console.Write($"El nodo { p.dato } será eliminado...");
                    }
                    else {
                        if (string.Compare(x, p.dato) >= 0)
                            p = p.ramaDer;
                        else p = p.ramaIzq;
                    }
                    if (encontrado) {
                        if (p.ramaIzq == null) v = p.ramaDer;
                        else {
                            if (p.ramaDer == null) v = p.ramaIzq;
                            else {
                                te = p;
                                v = p.ramaDer;
                                s = v.ramaIzq;
                                while (s != null) {
                                    te = v;
                                    v = s;
                                    s = v.ramaIzq;
                                }
                                if (te != p) {
                                    te.ramaIzq = v.ramaDer;
                                    v.ramaDer = p.ramaDer;
                                }
                            }
                            v.ramaIzq = p.ramaIzq;

                        }
                        if (q == null) raiz = v;
                        else q.ramaDer = v;
                    }
                    else Console.Write($"La ciudad { x } no está en el árbol...");
                }
            }
            else Console.Write("El Arbol Binario está vacio...");
            Console.ReadKey();
        }
    }
}