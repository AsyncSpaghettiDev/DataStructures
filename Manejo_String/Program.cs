using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Decalaración de variables a usar
        String nombreOriginal,nombreAlterado;
        Char nuevo = ' ',viejo = ' ';

        // Preparación de la consola
        Console.Clear();
        Console.Title = "Captura del nombre";

        // Solicitud del nombre al usuario
        Console.Write("Ingresa tu nombre Completo: ");
        nombreOriginal = Console.ReadLine();

        // Preparacion de consola
        Console.Clear();
        Console.Title = "Captura de vocales";

        // Se define una variable tipo bool para el ciclo que obligará al usuario ingresar datos validos
        Boolean valido = true;
        do{
            try{
                // Captura de vocales a cambiar
                Console.Write("Selecciona que vocal quieres cambiar: ");
                viejo = Char.Parse(Console.ReadLine());

                Console.Write("Ingresa la nueva vocal que sustituirá a la anterior: ");
                nuevo = Char.Parse(Console.ReadLine());

                // Se comprueba que las vocales capturadas sean vocales, en caso de no ser asi se muestra un error
                if (
                (Char.ToUpper(viejo)=='A' || Char.ToUpper(viejo)=='E' || Char.ToUpper(viejo)=='I' || Char.ToUpper(viejo)=='O' || Char.ToUpper(viejo)=='U') && 
                (Char.ToUpper(nuevo)=='A' || Char.ToUpper(nuevo)=='E' || Char.ToUpper(nuevo)=='I' || Char.ToUpper(nuevo)=='O' || Char.ToUpper(nuevo)=='U')
                )
                valido = false;
                else 
                    Console.WriteLine("Ingresa solo vocales =)");
            }
            // Se capturan errores al momento de convertir a char
            catch(FormatException){
                Console.WriteLine("Ingresa solo un caracter");
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }
        }
        while(valido);

        // Se le asigna valor al nombre alterado sustituyendo las vocales.
        nombreAlterado = nombreOriginal.Replace(viejo,Char.ToUpper(nuevo));

        // Se despliega en pantalla los resultados
        Console.Clear();
        Console .Title = "Mostrando nombre alterado.";

        Console.WriteLine("Nombre original: {0}\nNombre modificado: {1}",nombreOriginal,nombreAlterado);

        // Se cierra el programa
        Console.Write("Presiona una tecla para salir... ");
        Console.ReadLine();
    }
}