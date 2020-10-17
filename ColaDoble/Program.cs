using System;

namespace ColaDoble {
    class Program {
        static void Main(string [] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Declaración de Cola Estatica a usar y variables auxiliares
            int tamano = 50;
            int Der = 0;
            int Izq = 0;
            int Centro = 0;
            string [] EmpresasMundiales = new string [tamano];

            // Inicio de ciclo del menú
            bool operando = true;
            while (operando) {
                // Se prepara la consola
                Console.Clear();
                Console.Title = "Menu operaciones de Colas Dobles ";

                // Despliegue 
                Console.Write("[1] Insertar\n[2] Eliminar\n[3] Recorrer\n[!] Otro para salir\nSelecciona una opción: ");
                string eleccion = Console.ReadLine();

                switch (eleccion) {
// Opcion de captura a la cola
                case "1":
                // Titulo de la consola
                    Console.Title = "Capturando en la cola doble";
                    // Inicio de ciclo de captura
                    bool capturando = true;
                    while (capturando) {
                        // Se limpia la consola
                        Console.Clear();

                        // Captura del nombre de la empresa
                        Console.Write("Ingresa el nombre de la empresa reconocida a nivel mundial: ");
                        string empresa = Console.ReadLine();

                        // Preguntar el lado de inserción
                        Console.Write("\n[1] Izquierda [! Otro] Derecha | ¿De que lado deseas insertar?: ");
                        bool lado = Console.ReadLine().Contains("1");

                        // Se presentan 3 casos, primero:
                        // Es el primer elemento a insertar
                        // Segundo : Insertar izquierda
                        // Tercero : Insertar derecha
                        if (Centro == 0) {
                            Centro = tamano / 2;
                            Izq = Centro - 1;
                            Der = Centro + 1;

                            EmpresasMundiales [Centro] = empresa;
                        }
                        else if (lado) capturando = InsertarIzquierda(ref Izq, EmpresasMundiales, empresa);
                        else capturando = InsertarDerecha(ref Der, tamano, EmpresasMundiales, empresa);

                        // Se muestra toda la cola
                        Console.Title = "Mostrando la cola doble";
                        Desplegar(EmpresasMundiales, tamano);

                        // Se comprueba si quiere seguir capturando
                        if (capturando) {
                            Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir capturando Empresas?: ");
                            capturando = Console.ReadLine().Contains("1");
                        }
                    }
                    break;

                // Opcion de eliminar de la cola doble
                case "2":
                // Se nombra a la consola
                    Console.Title = "Eliminando empresas de la Cola Doble";
                    // Declaracion de ciclo de eliminacion
                    bool eliminando = true;
                    while(eliminando){
                        // Se limpia la consola
                        Console.Clear();

                        // Se elige de que lado se va a eliminar
                        Console.Write("\n[1] Izquierda [! Otro] Derecha | ¿De que lado deseas eliminar?: ");
                        bool lado = Console.ReadLine().Contains("1");

                        // En caso que sea por la izquerda se revisa que la cola no esté vacia
                        if (lado) {
                            if(Izq == (tamano - 1)){
                                Console.Write("Cola vacia ");
                                Console.ReadKey();
                                eliminando = false;
                            }
                            // En caso contrario se elimina por la izquierda
                            else
                                EliminarIzquierda(ref Izq, tamano, EmpresasMundiales, Der);
                        }
                        // En caso contrario se checará que la cola no este vacia por derecha
                        else{
                            if(Der == 0){
                                
                                Console.Write("Cola vacia ");
                                Console.ReadKey();
                                eliminando = false;
                            }
                            // En caso de no ser asi se elimina por derecha
                            else{
                                EliminarDerecha(ref Der, tamano, EmpresasMundiales, Izq);
                            }
                        }

                        // Se muestra toda la cola 
                        Console.Title = "Mostrando la cola doble";
                        Desplegar(EmpresasMundiales, tamano);

                        // Se comprueba si el usuario desea seguir eliminando
                        if (eliminando) {
                            Console.Write("\n[1] Si\n[!]Cualquier otra para no\n¿Desea seguir eliminando Empresas?: ");
                            eliminando = Console.ReadLine().Contains("1");
                        }
                    }
                    break;

                // Opcion de mostrar la cola
                case "3":
                // Se muestra toda la cola 
                    Console.Clear();
                    Console.Title = "Mostrando la cola doble";
                    Desplegar(EmpresasMundiales, tamano);
                    break;

                // Opcion de salida
                default:
                    operando = false;
                    break;
                }
            }
        }
        // Metodo que inserta un elemento por la parte izq
        static bool InsertarIzquierda(ref int Izq, string [] Empresas, string empresa) {
            // En caso de que la cola se haya llenado por la izq se muestra y se regresa false indicando que la accion de insertar ha acabado
            if (Izq < 0) {
                Console.Write("Cola llenada por el lado izquierdo...");
                Console.ReadKey();
                return false;
            }
            // En caso contrario se inserta por izq y se regresa true indicando que aun se puede insertar
            else {
                Empresas [Izq] = empresa;
                Izq++;
                return true;
            }
        }
        // Metodo que inserta un elemento por la parte derecha
        static bool InsertarDerecha(ref int Der, int tamano, string [] Empresas, string empresa) {
            // En caso de que la cola se haya llenado por la derecha se muestra y se regresa false indicando que la accion de insertar ha acabado
            if (Der >= tamano) {
                Console.Write("Cola llenada por el lado derecho...");
                Console.ReadKey();
                return false;
            }
            // En caso contrario se inserta por derecha y se regresa true indicando que aun se puede insertar
            else {
                Empresas [Der] = empresa;
                Der++;
                return true;
            }
        }
        // Metodo que despliega la cola
        static void Desplegar(string [] Empresas, int tamano) {
            Console.WriteLine("Cola Actual");
            foreach (string empresa in Empresas) Console.Write($"{empresa} | ");
            Console.ReadKey();
        }
        // Metodo que elimina por izq de la cola
        static void EliminarIzquierda(ref int Izq, int tamano, string[] Empresas, int Derecha){
            Empresas[ Izq - 1] = null;
            Izq --;

            if(Izq == Derecha) Izq = tamano;
        }
        // Metodo que elimina por derecha
        static void EliminarDerecha(ref int Der, int tamano, string[] Empresas, int Izq){
            Empresas[ Der - 1] = null;
            Der --;

            if(Der == Izq) Der = tamano;
        }
    }
}