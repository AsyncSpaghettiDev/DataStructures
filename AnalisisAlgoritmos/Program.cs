using System;
using System.Diagnostics;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Declaración de variables a usar
        TimeSpan t;
        Stopwatch stp = new Stopwatch();

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Captura de datos";

        // Captura de datos
        Console.Write("Ingresa el primer número: ");
        int n1 = Int32.Parse(Console.ReadLine());

        Console.Write("Ingresa el segundo número: ");
        int n2 = Int32.Parse(Console.ReadLine());

        //Se prepara la consola
        Console.Clear();
        Console.Title = "Despliegue de resultados";

        // Ejecución y evaluación de algoritmo
        stp.Start();
        Console.WriteLine(Compara(n1,n2));
        stp.Stop();
        t = new TimeSpan(stp.ElapsedTicks);

        // Despliegue de resultados
        Console.WriteLine("\nEl método de comparación tardó: {0}\n",
        t.TotalMilliseconds
        );

        // Salida del programa
        Console.Write("Presiona una tecla para salir...");
        Console.ReadLine();
    }

    // Metodo que comparara la entrada de 2 números
    // En caso que la comparación de menor a con b o igualdad
    // sea correcta se indicará como el mejor de los casos

    static string Compara(int a, int b){
        // if (a > b)
        //     return "\nSe ejecutó el mejor de los casos\n"+ b + " es mayor que " + a;
        if(a > b)
            return "\nSe ejecutó el mejor de los casos\n"+ b + " es menor que " + a;
        if (a == b)
            return "\nSe ejecutó el mejor de los casos\n"+ a + " son el mismo numero " + b;
        return "\nSe ejecutó el peor de los casos";

    }
}