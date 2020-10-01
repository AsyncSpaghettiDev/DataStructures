using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Captura número a sumar";

        // Captura de numero a sumar recursivamente
        int sumar;
        bool valido;
        do{
            Console.Write("Ingresa un número natural (pst mayor que 0): ");
            valido = Int32.TryParse(Console.ReadLine(), out sumar) && sumar > 0;  
        }
        while(!valido);

        // Despliegue de resultados
        Console.Clear();
        Console.Title = "Despliegue de suma Recursiva";

        // Impresión de las operaciones a realizar.
        for(int i = sumar ; i >= 0 ; i--)
            if(i != 0) 
                Console.Write(i + " + "); 
            else 
                Console.Write(i + " = ");
        
        // Impresion del resultado.
        Console.WriteLine(suma(sumar));

        // Salida del programa
        Console.Write("Presiona una tecla para salir...");
        Console.ReadLine();
    }
    // Calculo de la suma, en caso de ser 0 se regresa 0 en caso contrario se suma el parametro con el numero predecesor
    static int suma(int Natural) => Natural == 0 ? 0 : Natural + suma(Natural - 1);
}