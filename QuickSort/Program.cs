using System;

namespace QuickSort {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            sortQ vector = new sortQ(60);
        }
    }
    class sortQ {
        int h;
        int [] vector;
        public sortQ(int tam) {
            h = tam;
            vector = new int [h];
            for (int i = 0; i < vector.Length; i++) vector [i] = new Random().Next(0, 1250);
            Console.Title = "Mostrando números aleatorios";
            Imprimir(vector);
            Sort(vector, 0, h - 1);
            Console.Title = "Mostrando números ordenados";
            Imprimir(vector);
        }
        static void Imprimir(int [] nums) {
            Console.Clear();
            for (int i = 0; i < nums.Length - 1; i++) Console.Write($"{ nums[i] } | ");
            Console.ReadKey();
        }
        static void Sort(int [] vector, int primero, int ultimo) {
            int i, j, central;
            int pivote, temp;
            central = (primero + ultimo) / 2;
            pivote = vector [central];
            i = primero;
            j = ultimo;
            do {
                while (vector [i] < pivote) i++;
                while (vector [j] > pivote) j--;
                if (i <= j) {
                    temp = vector [i];
                    vector [i] = vector [j];
                    vector [j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (primero < j) Sort(vector, primero, j);
            if (i < ultimo) Sort(vector, i, ultimo);
        }
    }
}