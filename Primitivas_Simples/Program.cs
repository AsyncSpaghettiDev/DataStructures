using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Declaración de variables
        // Bool para definir el ciclo
        Boolean ciclo = true;
        // String que contendrá el valor original de la entrada
        String valor;
        // String que contendrá el valor invertido de la entrada
        String invertido= null;
        // Short que contendrá el valor de entrada como número.
        Int16 num;

        // Limpiar la consola y añadir el titulo a la consola.
        Console.Clear();
        Console.Title = "Manejo de estructuras primitivas y simples";

        // Bloque try catch para evitar excepciones
        try{
            // Ciclo do while para obligar que el usuario ingrese un número válido
            do{
                // Solicitud y conversión del númerp
                Console.Write("Ingresa un número de 2 o 3 dígitos: ");
                num = Int16.Parse(Console.ReadLine());

                // Conversión del número a cadena               
                valor = num.ToString();

                // En caso que el valor ingresado tenga un longitud de 2 o 3 dígitos se rompe el ciclo
                if (valor.Length == 2 || valor.Length == 3)
                    break;
                    
                Console.WriteLine("Error número inválido");
                }
            while(ciclo);

            // Se concatena el ultimo caractér de la entrada original en la cadena invertida
            for(int i = valor.Length-1 ; i>=0 ; i--)
                invertido = String.Concat(invertido,valor.Substring(i,1));

            Console.Clear();
            Console.Title = "Mostrando número invertido";

            // Se muestra la transformación
            Console.WriteLine("Número original: {0}\nNúmero invertido: {1}",valor,invertido);
        }
        // Se atrapan las posibles excepciones que pueden ocurrir al correr el programa
        catch(FormatException){
            Console.WriteLine("Ingresa solo valores numéricos, no texto");
        }
        catch(OverflowException){
            Console.WriteLine("Ingresa valores numéricos de solo 2 o 3 cifras =)");
        }
        catch(Exception ex){
            Console.WriteLine(ex.ToString());
        }

        // Se indica la salida del programa
        Console.Write("Presione cualquier tecla para salir...");
        Console.Read();
    }
}