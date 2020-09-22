using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Arreglos a usar
        int[,] mOriginal = new int[3,2];
        int[,] mTraspuesta = new int[2,3];

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Matriz Traspuesta";

        // Se rellena la matriz
        for(int i = 0 ; i < 3 ; i++)
            for(int j = 0 ; j < 2 ; j++){
                Console.Write("Ingresa el valor del renglón {0} de la columna {1}: ",i+1,j+1);
                int dato = Int32.Parse(Console.ReadLine());

                // Se almacena el dato obtenido de teclado en las matrices
                mOriginal[i,j] = dato;
                mTraspuesta[j,i] = dato;
            }
        
        // Se prepara la consola
        Console.Clear();
        Console.Title = "Despliegue de matrices";

        // Imprime la matriz original
        Console.WriteLine("Matriz Original");
        for(int i = 0 ; i < 3 ; i++){
            for(int j = 0 ; j < 2 ; j++)
                Console.Write(mOriginal[i,j] + "\t");
            Console.WriteLine();
        }

        // Imprime la matriz traspuesta
        Console.WriteLine("\nMatriz traspuesta");
        for(int i = 0 ; i < 2 ; i++){
            for(int j = 0 ; j < 3 ; j++)
                Console.Write(mTraspuesta[i,j] + "\t");
            Console.WriteLine();
        }

        // Salida del programa
        Console.Write("\nPresiona una tecla para salir ...");
        Console.ReadLine();
    }
}