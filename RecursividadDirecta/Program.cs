using System;

class Program{
    static int [] serie;
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Captura de Fibonacci";

        // Captura de posicion
        Console.Write("Ingresa la posición de Fibonacci deseada: ");
        int ser = Int16.Parse( Console.ReadLine() );

        // Creacion del vector 
        serie = new int [ser + 1];

        // Se calcula fibonacci
        Fibonacci(ser);
    
        // Se prepara la consola
        Console.Clear();
        Console.Title = "Serie de Fibonacci";

        // Despliegue de resultados
        foreach(int item in serie)
            Console.Write(item + " | ");

        // Salida del programa
        Console.Write("\nPresiona una tecla para salir...");
        Console.ReadLine();
    }
    // Se calcula la serie fibonacci y se almacena su valor en la variable global
    static int Fibonacci(int fib) => fib == 0 || fib == 1 ? serie[fib] = 1 : serie[fib] = Fibonacci(fib - 1) + Fibonacci(fib - 2);
}