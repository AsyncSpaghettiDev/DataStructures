using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688
        Double divisor;
        bool valido;

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Captura de divisor";

        // Captura de un número válido
        do{
            Console.Write("Ingresa la tabla de división a buscar: ");
            valido = Double.TryParse(Console.ReadLine(),out divisor);
        }
        while(!valido);

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Despliegue de tablas de dividir";

        // Llamada al metodo recursivo indirecto.
        Division(divisor);

        // Salida del programa
        Console.Write("Presiona una tecla para salir");
        Console.Read();

    }
    // Metodo donde se calcula el cociente y se llama al metodo impresión
    static void Division(Double divisor,Double dividendo = 1){
        if(dividendo <= 12){
            double cociente = dividendo / divisor;
            Despliegue( divisor, dividendo, cociente );
        }
    }
    // Se capturan el dividendo, divisor y el cociente de la división para mostrarlos
    static void Despliegue( Double divisor, Double dividendo, Double cociente){
        Console.WriteLine("{0} / {1} = {2}",dividendo,divisor,cociente);
        Console.ReadKey();

        // Se llama de nuevo al metodo encargado de la division pasando el dividendo aumentado y el divisor
        Division(divisor , dividendo + 1 );
    }
}