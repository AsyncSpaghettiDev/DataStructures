using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688
        // Algoritmo que cumple con SRP y abstraccion del usuario.

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Captura de limites de la serie a sumar";

        // Captura de límites
        int n1,n2;
        bool valido1, valido2;
        do{
            Console.WriteLine("Ingresa valores válidos");

            Console.Write("Ingresa el primer límite : ");
            valido1 = Int32.TryParse(Console.ReadLine(), out n1);  

            Console.Write("Ingresa el segundo límite : ");
            valido2 = Int32.TryParse(Console.ReadLine(), out n2); 
            
            Console.Clear();
        }
        while(!valido1 || !valido2);

        // Despliegue de sumas
        Console.Title = "Despliegue de sumas";

        _serie(n1,n2);

        // Salida del programa
        Console.Write("Pulsa una tecla para salir...");
        Console.ReadKey();
    }
    // Metodo que compara los 2 números dados acomodandolos de menor a mayor y generando el sucesor del menor
    // En este caso el cálculo del sucesor del menor está abstraido del usuario.
    // En caso de dar 2 números iguales se indica que no hay suma.
    static void _serie(int n1 , int n2){
        if(n1 > n2) Serie(n2 , n1 , n2 + 1);
        else if(n2 > n1) Serie(n1 , n2 , n1 + 1);
        else Console.WriteLine("No hay suma, los límites son iguales.");
    }
    // Metodo para llevar a cabo las sumas, siempre y cuando el siguiente número -1 sea menor al limite superior
    static void Serie(int inicio, int limite, int siguiente){
        if((siguiente - 1) < limite ){
            int suma = inicio + siguiente;
            // Se mandan los parametros para ser impresos
            Despliegue(inicio , limite , siguiente , suma);
        }
    }
    // Se imprimen los parámetros recibidos excepto el limite superior
    static void Despliegue(int inicio , int limite , int siguiente , int suma){
        Console.WriteLine("{0} + {1} = {2}", inicio , siguiente , suma);
        // Se llama al método serie para sumar pero ahora el limite inferior es la suma calculada.
        // Y se actualiza el número sucesor.
        Serie(suma, limite, siguiente + 1);
    }
}