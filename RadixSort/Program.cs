using System;
using System.Collections.Generic;
namespace RadixSort {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688
            new Radix(true).Sort();
        }
    }
    class Radix {
        // Vector con los digitos
        private int [] controles;
        // Lista de digitos con lista de c/u
        private IList<IList<int>> digitos = new List<IList<int>>();
        // Número de digitos que tendrá el número más grande capturado.
        private int tamax = 0;
        public Radix() {
            Inicializar();
            Insertar();
        }
        public Radix(bool a) {
            Inicializar();
            Insertar(a);
        }
        private void Insertar(bool a) {
            this.controles = new int [] {
                19211639,
                19211631,
                19210528,
                19211600,
                19211718,
                19211633,
                19211650,
                19211614,
                19211598,
                19211680,
                19211648,
                19211652,
                19211647,
                19211744,
                19211603,
                19211712,
                19211605,
                19211618,
                19211638,
                19211688,
                15211343,
                19211750,
                19211626,
                19211741,
                19211671,
                19211645,
                19211599,
                19211698,
                19211723,
                20211122,
                19211640,
                17210562,
                19211591,
                19211651,
                19211602,
                19211687,
                19211732
            };
            this.tamax = 8;
            Console.Write("Datos Capturados... Presione una tecla para Despelgar...");
            Desplegar();
        }
        private void Inicializar() {
            // Definir consola
            Console.Clear();
            Console.Title = "Captura del tamaño del vector.";
            // Llenado de la lista con los digitos del 0 - 9.
            for (int i = 0; i < 10; i++) this.digitos.Add(new List<int>());
            int capacidad = 0;
            // Captura del tamaño del vector.
            do Console.Write("¿Cuántos números de control vas a capturar?: ");
            while (!int.TryParse(Console.ReadLine(), out capacidad) || capacidad <= 0);
            // Inicializacion del vector.
            this.controles = new int [capacidad];
        }
        private void Insertar() {
            // Definir consola
            Console.Clear();
            Console.Title = "Captura del números de control.";
            // Captura de números de control
            for (int i = 0; i < this.controles.Length; i++) {
                // Comprobación de dato de entrada.
                do Console.Write($"Ingresa el no. de Control # { i + 1 }: ");
                while (!int.TryParse(Console.ReadLine(), out this.controles [i]) || this.controles [i] <= 0);
                // Actualización del dato más grande.
                int max = this.controles [i].ToString().Length;
                this.tamax = tamax < max ? max : tamax;
            }
            Console.Write("Datos Capturados... Presione una tecla para Desplegar...");
            Desplegar();
        }
        public void Sort() {
            // Se recorre el arreglo la cantidad de veces que indica la variable que guarda la longitud del número más grande
            for (int i = 0; i < this.tamax; i++) {
                for (int j = 0; j < this.controles.Length; j++) {
                    // Se saca el modulo de un número base 10 a una potencia y se divide entre un multiplo de 10
                    // Ejemplo: 135; i = 1; 10 ^ (1 + 1) = 100 ; 135 % 100 = 35; 35 / 10 = 3; 3 será el digito "clave"
                    // Y se agrega en la lista correspondiente
                    int digito = (int) ((controles [j] % Math.Pow(10, i + 1)) / Math.Pow(10, i));
                    this.digitos [digito].Add(controles [j]);
                }
                // Se crea una variable contador independiente de un for
                int indice = 0;
                // Se recorre la lista enlazada con los datos ordenados
                for (int j = 0; j < digitos.Count; j++) {
                    IList<int> seldigito = digitos [j];
                    // Se copian los datos al arreglo original.
                    for (int k = 0; k < seldigito.Count; k++) controles [indice++] = seldigito [k];
                }
                LimpiarDigitos();
            }
            Console.Clear();
            Console.Write("Datos Ordenados... Presione una tecla para desplegar...");
            Console.ReadKey();
            Desplegar();
        }
        private void LimpiarDigitos() {
            // Recorrer toda la lista de digitos y limpiar cada sublista
            for (int i = 0; i < this.digitos.Count; i++) this.digitos [i].Clear();
        }
        public void Desplegar() {
            // Definir la consola
            Console.Clear();
            Console.Title = "Desplegando Datos...";
            // Recorrer todo el vector controles e impirmir cada dato
            foreach (int ctr in this.controles) Console.WriteLine(ctr);
            Console.Write("Presiona una tecla para continuar...");
            // Esperar confirmación del usuario
            Console.ReadKey();
        }
    }
}