using System;

namespace Merge {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Vector con todos los sueldos
            double [] sueldos = new double [20];

            // Menu de operaciones
            bool operando = true;
            while (operando) {
                Console.Clear();
                Console.Title = "Menu de opciones Ordenamiento Merge";

                Console.Write("[1] Capturar sueldos\n[2] Ordenar datos con método Merge\n[3] Desplegar todos los datos\n[! Otro] Salir\nSelecciona una opción: ");

                switch (Console.ReadLine()) {
                    case "1":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Capturando sueldos.";
                        // Se captura y se valida que la entrada sea correcta.
                        for (int i = 0; i < sueldos.Length; i++)
                            do Console.Write($"Ingresa el sueldo #{ i + 1 }: "); while (!double.TryParse(Console.ReadLine(), out sueldos [i]));
                        // Se manda a desplegar los datos capturados con confirmacion del usuario.
                        Console.Write("Datos Capturados Correctamente. Presiona una tecla para verlos desplegados");
                        Console.ReadKey();
                        goto case "3";

                    case "2":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Ordenando datos con Merge.";
                        // Se ordenan los datos
                        Sort.Merge(sueldos);
                        // Se indica que se han ordenado los datos y se despliegan estos
                        Console.Write("Datos Ordenados, Presione una tecla para desplegar los datos: ");
                        Console.ReadKey();
                        goto case "3";

                    case "3":
                        // Se prepara la consola
                        Console.Clear();
                        Console.Title = "Desplegando datos Alamacenados.";
                        // Con un foreach se recorre todo el arreglo.
                        foreach (double s in sueldos) Console.Write($"{ s } | ");
                        Console.ReadKey();
                        break;

                    default:
                        // Se rompe el ciclo del menú.
                        operando = false;
                        break;
                }
            }
        }
    }
    class Sort {
        // Metodo tipo interfaz para facilitar las cosas al usuario
        public static void Merge(double [] sueldos) => Merge(sueldos, 0, sueldos.Length - 1);
        // Metodo encargado de dividir el arreglo en varios más pequeños
        private static void Merge(double [] sueldos, int inicio, int final) {
            // En caso que se haya llegado a la "unidad" más pequeña se rompe la division
            if (inicio == final) return;
            // Se calcula la mitad del arreglo
            int mitad = (inicio + final) / 2;
            // Se divide el arreglo en 2 mitades
            Merge(sueldos, inicio, mitad);
            Merge(sueldos, mitad + 1, final);
            // Se crea una arreglo que tendrá los datos ordenados
            double [] aux = MergeSort(sueldos, inicio, mitad, mitad + 1, final);
            // Se copia el nuevo arreglo en el vector dado.
            Array.Copy(aux, 0, sueldos, inicio, aux.Length);
        }
        // Metodo principal de ordenamiento de datos
        private static double [] MergeSort(double [] sueldos, int inicio1, int final1, int inicio2, int final2) {
            // Se guarda en variables auxiliares los contadores de inicios
            int a = inicio1;
            int b = inicio2;
            // Arreglo que tendrá los datos ya ordenados, de define su tamaño sumando los tamaños del vector
            double [] sueldosMezcla = new double [final1 - inicio1 + final2 - inicio2 + 2];
            // Se recorrerá todo el arreglo
            for (int i = 0; i <= sueldosMezcla.Length; i++) {
                // Mientras la segunda mitad no llegue al final se ordenará esta parte
                if (b != sueldosMezcla.Length) {
                    // Si el apuntador de la primera mitad llega más lejos, y el apuntador de la segunda mitad aun no llega al final, no habrá cambios en el orden
                    if (a > final1 && b <= final2) {
                        sueldosMezcla [i] = sueldos [b];
                        b++;
                    }
                    // Si el apuntador de la segunda mitad sobrepasa el límite y aun quedan elementos de la mitad 1 solo se imprimirán, no habrá grandes cambios.
                    if (b > final2 && a <= final1) {
                        sueldosMezcla [i] = sueldos [a];
                        a++;
                    }
                    // Si los apuntadores aun no llegan al final, habrá operaciones de comparaciones
                    if (a <= final1 && b <= final2)
                        // Si el valor de la segunda mitad es menor igual al valor de la primera mitad se pondrá en el arreglo ordenado y se pasará al siguiente valor de la segunda mitad
                        if (sueldos [b] <= sueldos [a]) {
                            sueldosMezcla [i] = sueldos [b];
                            b++;
                        }
                    // En caso contrario el valor de la primera mitad se pondrá en el arreglo ordenado.
                    else {
                        sueldosMezcla [i] = sueldos [a];
                        a++;
                    }
                }
                // Si aun la segunda mitad no llega a su fin se comprueba si la primera mitad ya ha terminado, en caso de ser así se imprimen los valores que queden.
                else
                if (a <= final1) {
                    sueldosMezcla [i] = sueldos [a];
                    a++;
                }
            }
            // Se regresa el vector ya ordenado.
            return sueldosMezcla;
        }
    }
}