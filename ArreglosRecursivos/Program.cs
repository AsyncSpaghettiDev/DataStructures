using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Se prepara la consola
        Console.Title = "Captura de resultados";

        // Se declara la variable vectorEdad y se asigna al resultado de llenado
        int [] vectorEdad = rellenado(new int[20]);

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Despliegue de edades";

        // Despliegue de resultados
        foreach (var edad in vectorEdad)
            Console.Write(edad+ " | ");

        // Salida del programa
        Console.Write("\nPresiona una tecla para salir...");
        Console.ReadKey();
    }
    // Metodo recursivo para llenar el arreglo, se declara el parametro capacidad como 0 por defecto.
    static int [] rellenado(int [] arreglo, int capacidad = 0){
        // Cada 10 números se limpia la consola.
        if (capacidad % 10 == 0) Console.Clear();

        do{
            // Se indica la posición a capturar
            Console.Write("Ingresa una edad en la posición #{0}: ",capacidad + 1 );

            // En caso que el valor que se ingrese sea un valor numerico se asignara en caso contrario se asignara un 0
            arreglo[capacidad] = Int32.TryParse(Console.ReadLine(), out int valor) ? valor : 0;
        }
        // Mientras el valor de la posicion actual sea menor a 18 no se podrá seguir el programa
        while(arreglo[capacidad] < 18);

        // En caso que la posición del vector sea la longitud del mismo -1 se regresará el vector, en caso contrario
        // se llamará al metodo recursivo aumentando la posición del vector.
        return capacidad == arreglo.Length - 1? arreglo : rellenado(arreglo, capacidad + 1 );
    }
}