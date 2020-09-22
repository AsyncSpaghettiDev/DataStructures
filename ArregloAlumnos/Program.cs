using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19216688

        // Variables a utilizar
        Double promedio,subtotal = 0;
        String[] nombres = new String[6];
        Int32[] calificaciones = new Int32[6];
        Int32 identificadorMax = 0, identificadorMin = 0;

        // Captura de nombre y calificación
        for(int i = 0 ; i < calificaciones.Length ; i++){
            // Se prepara la consola
            Console.Clear();
            Console.Title = "Registro de Alumnos";

            Console.Write("Ingresa el nombre del alumno #{0}: ",i+1);
            nombres[i] = Console.ReadLine();

            // Se pone el nombre del sujeto en cuestion en el título
            Console.Title = "Capturando calificación de " + nombres[i];

            // Se añade un bloque try-catch para evitar errores al convertir
            try{
                Console.Write("Ingresa la calificación de {0}: ", nombres[i]);
                calificaciones[i] = Int32.Parse(Console.ReadLine());
            }
            catch(FormatException){
                i--;
            }
            catch(OverflowException){
                i--;
            }
        }

        // Calcular promedio más bajo y más alto
        for(int i = 1 ; i < calificaciones.Length ; i++)
            if(calificaciones[i] > calificaciones[identificadorMax])
                identificadorMax = i;
            else
                if(calificaciones[i] < calificaciones[identificadorMin])
                    identificadorMin = i;

        // Calcular promedio grupal, usando la clase math se redondea a 2 decimales
        for(int i = 0 ; i < calificaciones.Length ; i++)
            subtotal += calificaciones[i];

        promedio = Math.Round(subtotal / calificaciones.Length,2) ;

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Mostrando promedios";

        // Se despliegan los resultados
        Console.WriteLine("El mayor promedio fue {0} de {1}\nEl menor promedio fue {2} de {3}\nPromedio General del grupo {4}",
        calificaciones[identificadorMax],
        nombres[identificadorMax],
        calificaciones[identificadorMin],
        nombres[identificadorMin],
        promedio
        );

        // Salida del programa
        Console.Write("Presiona una tecla para salir...");
        Console.ReadLine();
    }
}
