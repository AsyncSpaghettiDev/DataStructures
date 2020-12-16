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

                Console.Write("\t\t[1] Generar matriculas aleatorias\n\t\t[2] Despliegue de las matriculas generadas\n\t\t[3] Asignar direcciones a las matriculas\n\t\t[4] Busqueda por Hash\n\t\t[! Otro] Salir\n\t\tSelecciona una opción: ");
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
            Console.Write("\t\tMatriculas Generadas Correctamente...");
            Console.ReadKey();
        }
        public void Mostrar() {
            Console.Clear();
            Console.Title = "Mostrando las matriculas en desOrden";
            Console.WriteLine("\tMatriculas registradas");
            for (int i = 0; i < inOrden.Length; i++) Console.WriteLine("\t{0}-. {1}", i, desOrden [i]);
            Console.Write("\t\tDatos Desplegados Correctamente...");
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
            Console.WriteLine("\n\t\t\t\t\tValores Capturados \t\t\t Direcciones asignadas");
            for (int i = 0; i < inOrden.Length; i++) Console.WriteLine("\t \t\t\t {0}.- {1} \t\t\t\t{0}-. {2}", i, desOrden [i], inOrden [i]);
            Console.Write("\t\t\t \tDatos Ordenados Correctamente...");
            Console.ReadKey();
        }
        public void Buscar() {
            int PosI, Conflicto, busqueda;
            int tamano = inOrden.Length - 1;

            Console.WriteLine("Matriculas y su clave de hash");
            for (int i = 0; i < inOrden.Length; i++) Console.WriteLine("\t\t\t\t {0}-.{1}", i + 1, inOrden [i]);

            do Console.Write("\t\t\t\t\n¿Qué matricula deseas buscar?: "); while (!int.TryParse(Console.ReadLine(), out busqueda));
            PosI = (busqueda % tamano) + 1;

            if (inOrden [PosI] == busqueda) Console.Write("\t\t\t\tLa matricula {0} está en la posición #{1}", busqueda, PosI + 1);
            else {
                Conflicto = PosI + 1;
                while (Conflicto <= tamano && inOrden [Conflicto] != busqueda && inOrden [Conflicto] != 0 && Conflicto != PosI) {
                    Conflicto++;
                    if (Conflicto > tamano) Conflicto = 0;
                }
                Console.Write(inOrden [Conflicto] == busqueda ?
                    String.Format("\t\t\t\t El elemento {0} está en la posición #{1}", busqueda, Conflicto + 1) :
                    String.Format("\t\t\t\t El elemento {0} no está en el arreglo", busqueda));
                Console.ReadKey();
            }
        }
    }
}