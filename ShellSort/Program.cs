using System;
namespace ShellSort {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            // Vector a utilizar
            double [] salarios = new double [15];
            insertarShell(ref salarios);
            Despliegue(salarios);
            ordenarShell(ref salarios);
            Despliegue(salarios);
        }
        static void insertarShell(ref double [] sal) {
            Console.Clear();
            Console.Title = "Inserción de sueldos";
            for (int i = 0; i < sal.Length; i++) {
                double cali = 0;
                do Console.Write($"Ingresa el sueldo del empleado #{ i + 1 }: "); while (!double.TryParse(Console.ReadLine(), out cali));
                sal [i] = cali;
            }
        }
        static void ordenarShell(ref double [] sal) {
            bool ordenado = false;
            double aux = 0;
            int contador = 0;
            int salto = sal.Length / 2;
            while (salto > 0) {
                ordenado = true;
                while (ordenado) {
                    ordenado = false;
                    contador = 1;
                    while (contador <= (sal.Length - salto)) {
                        if (sal [contador - 1] > sal [contador - 1 + salto]) {
                            aux = sal [contador - 1 + salto];
                            sal [contador - 1 + salto] = sal [contador - 1];
                            sal [contador - 1] = aux;
                            ordenado = true;
                        }
                        contador++;
                    }
                }
                salto = salto / 2;
            }
        }
        static void Despliegue(double [] sal) {
            Console.Clear();
            Console.Title = "Despliegue de Sueldos";
            for (int i = 0; i < sal.Length; i++) Console.Write($"{sal[i]} | ");
            Console.ReadKey();
        }
    }
}