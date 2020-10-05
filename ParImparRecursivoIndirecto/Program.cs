using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688
        // Se prepara la Consola
        Console.Clear();
        Console.Title = "Captura de entrada";

        // Captura de un número válido
        bool valido;
        int entrada;
        do{
            Console.Write("Ingresa el numero de inicio: ");
            valido = Int32.TryParse(Console.ReadLine(),out entrada);
        }
        while(!valido);

        // Despliegue de resultados
        Console.Clear();
        Console.Title = "Despliegue de resultados";

        Par(entrada);

        // Salida del programa
        Console.Write("Pulsa una tecla para salir...");
        Console.ReadKey();
    }
    // Se comprueba que el residuo de dividir entre 2 en numero proporcionado sea 0, en caso de ser verdad
    // se imprime que es par, en caso contrario se indica que no lo es y se llama al metodo impar con el numero - 1
    static void Par(int n){
        if (n > 0){
            if ( n % 2 == 0) Console.WriteLine("{0} es par",n);
            else Console.WriteLine("{0} no es par",n);
            
            Impar(n - 1);
        }
    }
    // Se comprueba que el residuo de dividir entre 2 en numero proporcionado sea diferente de 0, en caso de ser verdad
    // se imprime que es impar, en caso contrario se indica que no lo es y se llama al metodo par con el numero - 1
    static void Impar(int n){
        if (n > 0){
            if ( n % 2 != 0) Console.WriteLine("{0} es impar",n);
            else Console.WriteLine("{0} no es impar",n);
            
            Par(n - 1);
        }
    }
}