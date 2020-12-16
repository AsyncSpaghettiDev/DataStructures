using System;

namespace BusquedaHash {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Objeto que tendrá la busqueda
            HashB matriculas = null;

            // Declaracion del menu
            bool operando = true;
            while (operando) {
                Console.Clear();
                Console.Title = "Menu de Operaciones Busqueda Hash";

                Console.Write("\t\t\t\t[1] Generar matriculas aleatorias\n\t\t\t\t[2] Despliegue de las matriculas generadas\n\t\t\t\t[3] Asignar direcciones a las matriculas\n\t\t\t\t[4] Busqueda por Hash\n\t\t\t\t[! Otro] Salir\n\t\t\t\tSelecciona una opción: ");
                switch (Console.ReadLine()) {
                    case "1":
                        matriculas = new HashB();
                        break;

                    case "2":
                        matriculas.Mostrar();
                        break;

                    case "3":
                        matriculas.Direccionar();
                        break;

                    case "4":
                        matriculas.Buscar();
                        break;

                    default:
                        operando = false;
                        break;
                }
            }
        }
    }
    class HashB {
        public HashB() => Llenar();

        int [] desOrden = new int [100];
        int [] inOrden = new int [100];
        public void Llenar() {
            Console.Clear();
            Console.Title = "Llenando arreglo con numeros aleatorios";
            for (int i = 0; i < desOrden.Length; i++) {
                desOrden [i] = new Random().Next(100, 2000);
                inOrden [i] = -1;
            }
            Console.Write("\t\t\t\tMatriculas Generadas Correctamente...");
            Console.ReadKey();
        }
        public void Mostrar() {
            Console.Clear();
            Console.Title = "Mostrando las matriculas en desOrden";
            Console.WriteLine("\t\t\t\t\t\tMatriculas registradas");
            for (int i = 0; i < inOrden.Length; i++) {
                if (i % 4 == 0) Console.WriteLine();
                Console.Write("\t\t{0:D3}-. {1:D4}", i + 1, desOrden [i]);
            }
            Console.Write("\n\n\t\t\t\t\tDatos Desplegados Correctamente...");
            Console.ReadKey();
        }
        public void Direccionar() {
            Console.Clear();
            Console.Title = "Asignar Direcciones a Matriculas";
            int PosI, Conflicto;
            int pivote = desOrden.Length - 1;
            for (int i = 0; i < pivote + 1; i++) {
                PosI = (desOrden [i] % pivote) + 1;
                while (inOrden [PosI] != -1) {
                    Conflicto = PosI + 1;
                    PosI = Conflicto > pivote ? 0 : Conflicto;
                }
                inOrden [PosI] = desOrden [i];
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t   Valores Capturados ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\tDirecciones asignadas");

            for (int i = 0; i < inOrden.Length; i++) {
                if (i % 2 == 0) Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t {0:D3}.- {1:D4}", i + 1, desOrden [i]);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" \t\t{0:D3}-. {1:D4}", i + 1, inOrden [i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\t\t\t\t\tDirecciones Asignadas Correctamente...");
            Console.ReadKey();
        }
        public void Buscar() {
            Console.Clear();
            Console.Title = "Busqueda Hash";
            int PosI, Conflicto, busqueda;
            int tamano = inOrden.Length - 1;

            Console.WriteLine("\t\t\t\t\t    Matriculas y su clave de hash");
            for (int i = 0; i < inOrden.Length; i++) {
                if (i % 4 == 0) Console.WriteLine();
                Console.Write("\t\t{0:D3}-. {1:D4}", i + 1, inOrden [i]);
            }

            do Console.Write("\n\n\t\t\t\t\t    ¿Qué matricula deseas buscar?: "); while (!int.TryParse(Console.ReadLine(), out busqueda));
            PosI = (busqueda % tamano) + 1;

            if (inOrden [PosI] == busqueda) Console.Write("\t\t\t\t\t La matricula {0} está en la posición #{1}.", busqueda, PosI + 1);
            else {
                Conflicto = PosI + 1;
                while (Conflicto <= tamano && inOrden [Conflicto] != busqueda && inOrden [Conflicto] != 0 && Conflicto != PosI) {
                    Conflicto++;
                    if (Conflicto > tamano) Conflicto = 0;
                }
                Console.Write(inOrden [Conflicto] == busqueda ?
                    String.Format("\t\t\t\t\t La matricula {0} está en la posición #{1}.", busqueda, Conflicto + 1) :
                    String.Format("\t\t\t\t\t La matricula {0} no está en el arreglo.", busqueda));
            }
            Console.ReadKey();
        }
    }
}