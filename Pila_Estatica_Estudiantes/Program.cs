using System;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Pilas estaticas declaradas
        int top = 100;
        string[] nombres = new string[top];
        double[] calificaciones = new double[top];

        // Variables auxiliares
        int indiceN = 0;
        int indiceC = 0;
        bool operando = true;

        // Menú operaciones con pilas
        do{
            // Variable que controlará al menú
            string seleccion;

            // Se prepara la consola.
            Console.Clear();
            Console.Title = "Operaciones con Pilas";

            Console.Write("[1] Insertar elementos en la pila\n[2] Eliminar elementos de la pila\n[!] Cualquier otra para salir\nSelecciona una opcion: ");
            seleccion = Console.ReadLine();

            // Switch para la toma de decisiones
            switch(seleccion){
                // Opcion para insertar elementos
                case "1":
                    // Se prepara la consola
                    Console.Title = "Capturando elementos";

                    // Variables auxiliares
                    bool captura = true;

                    // Se inicia el ciclo de captura
                    do{
                        Console.Clear();

                        // Captura de nombre
                        Console.Write("Ingresa el nombre del alumno #{0}: ",indiceN + 1);
                        // Insercion de string en pila
                        indiceN = Insertar(nombres,indiceN,top,Console.ReadLine());

                        // Captura de calificacion con validación
                        bool valido = false;
                        double calificacion;
                        do{
                            Console.Write("Ingresa la calificacion (entre 1-10) del alumno #{0}: ",indiceC + 1);
                            valido = Double.TryParse(Console.ReadLine(), out calificacion) && (calificacion > 0.0 && calificacion <=10.0 );
                        }
                        while(!valido);

                        // Insercion de int en pila
                        indiceC = Insertar(calificaciones, indiceC, top, calificacion);

                        // Pregunta para seguir capturando
                        Console.Write("\n[1] Si [!] Otro para no\n¿Desea Continuar?: ");
                        captura = Console.ReadLine().Equals("1");
                    }
                    while(captura);
                break;

                // Opcion de eliminar elementos
                case "2":
                    // Se prepara la consola
                    Console.Title = "Eliminando elementos";

                    // Variable auxiliar
                    bool eliminar = true;

                    // Se inicia el ciclo de eliminación de posiciones
                    do{
                        // Se limpia la consola
                        Console.Clear();

                        // Se eliminan los 2 datos
                        indiceN = Eliminar(nombres,indiceN);
                        indiceC = Eliminar(calificaciones,indiceC);

                        // Se muestra un mensaje confirmando la eliminación
                        Console.WriteLine("Elementos en la posición #{0} eliminados",indiceN);

                        // Se pregunta si se quiere repetir la acción
                        Console.Write("\n[1] Si [!] Otro para no\n¿Desea eliminar otro elemento?: ");
                        eliminar = Console.ReadLine().Equals("1");
                    }
                    while(eliminar);
                break;

                // Opción de salida
                default:
                    operando = false;
                break;
            }
        }
        while(operando);

        // Se prepara la consola
        Console.Clear();
        Console.Title = "Despliegue de Resultados";

        // Se imprimen las 2 pilas
        Despliegue(nombres,calificaciones,indiceN);

        // Salida del programa
        Console.Write("Presione cualquier tecla para salir");
        Console.ReadKey();
    }
    // Regresa un bool que establece si se ha llegado al tope de la lista
    static bool OverFlow(int indice, int top) => top <= indice;
    // Regresa un bool que establece si se ha llegado al vacio de la lista
    static bool UnderFlow(int indice) => indice <= 0;
    // Inserta un string en una pila de strings
    static int Insertar(string[] nombres , int indice, int top, string insercion){
        if( OverFlow(indice,top) ) Console.WriteLine("Pila llenada a su maxima capacidad");
        else { nombres[indice] = insercion; indice = indice + 1; }
        return indice;
    }
    // Inserta un int en una pila de ints
    static int Insertar(double[] calificaciones , int indice, int top, double insercion){
        if( OverFlow(indice,top) ) Console.WriteLine("Pila llenada a su maxima capacidad");
        else { calificaciones[indice] = insercion; indice = indice + 1; }
        return indice;
    }
    // Eliminar un elemento de una pila de strings
    static int Eliminar(string[] nombres, int indice){
        if( UnderFlow(indice) ) Console.WriteLine("Pila vacia\n");
        else { nombres[indice - 1] = null; indice = indice - 1; }
        return indice;
    }
    static int Eliminar(double[] calificaciones, int indice){
        if( UnderFlow(indice) ) Console.WriteLine("Pila vacia");
        else { calificaciones[indice - 1] = 0; indice = indice - 1; }
        return indice;
    }
    static void Despliegue(string[] nombres,double[] calificaciones, int indice){
        for(int i = 0 ; i < indice ; i++)
            if(String.IsNullOrEmpty( nombres[i] ) ) break;
            else Console.WriteLine("Nombre: {0} | Calificación: {1:f1}",nombres[i],calificaciones[i]);

    }
}