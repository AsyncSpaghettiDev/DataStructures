using System;
using System.IO;

namespace IntercalacionSimple1 {
    // Clase Principal
    class Program {
        static void Main(string[] args) {
            // Mojica Vidal Jonathan Jafet
            // 19211688

            // Se llama al método estático para que se inicie el programa
            Archivos.Sort();
            // Se indica que se han ordenado los datos.
            Console.Write("Ordenamiento Terminado...");
            // Se espera la confirmacion del usuario.
            Console.ReadKey();
        }
    }
    // Clase encargada de cargar archivos y ordenarlos
    class Archivos {
        // Metodo abstraido del usuario para que ordene 1 archivo llamado Datos.
        public static void Sort() {
            // Se crea un flujo para leer datos.
            StreamReader DatosEntrada = new StreamReader(new FileStream("./Datos.txt", FileMode.Open, FileAccess.Read));
            // Se indica un contador para saber la longitud del archivo.
            int contador = 0;
            // Mientras haya archivos se contarán.
            // Si se detecta una linea vacia o sin datos no se contabilizará.
            while (DatosEntrada.Peek() != -1) {
                string a = DatosEntrada.ReadLine();
                if (string.IsNullOrWhiteSpace(a)) continue;
                else contador++;
            }
            // Se cierra el flujo de trabajo.
            // Se crean archivos llamados cache, en caso que existan se sobreescribirán.
            DatosEntrada.Close();
            File.Create("./Cache1.txt").Close();
            File.Create("./Cache2.txt").Close();
            // Se llama al método intercalar para llenar los archivos cache.
            Intercalar(1, contador);
        }
        // Metodo encargado de administrar datos y escribirlos en un archivo u otro en intervalos.
        public static void Intercalar(int intercalacion, int contador) {
            // Se crea un flujo de datos para leer el archivo principal y otros 2 flujos para escribir en las cache
            StreamReader DatosIntercalados = new StreamReader(new FileStream("./Datos.txt", FileMode.OpenOrCreate));
            StreamWriter cache1 = new StreamWriter(new FileStream("./Cache1.txt", FileMode.Truncate, FileAccess.ReadWrite));
            StreamWriter cache2 = new StreamWriter(new FileStream("./Cache2.txt", FileMode.Truncate, FileAccess.ReadWrite));
            // Se indica que el contador inciará en el valor contrario del valor de intercalación
            int cont = -intercalacion;
            // Se define que mientras haya datos en el archivo principal se leeran sus datos.
            while (DatosIntercalados.Peek() != -1) {
                // Se almacena la linea leida y si no tiene datos se salta al siguiente.
                string aux = DatosIntercalados.ReadLine();
                if (string.IsNullOrWhiteSpace(aux)) continue;
                // En caso que el contador sea menor a 0 significa que estamos en la parte de la intercalación de la cache 1
                // asi que ese dato se imprime en la cache 1, en caso contrario nos encontramos en el siguiente intervalo y se guarda en cache 2.
                if (cont < 0)
                    cache1.WriteLine(aux);
                else
                    cache2.WriteLine(aux);
                // Si llegamos al tope "reiniciamos" el contador; en caso contrario se aumenta contador.
                if (cont == intercalacion - 1) cont = -intercalacion;
                else cont++;

            }
            // Se cierran los flujos de datos. Se llama al metodo para ordenar los datos en las caches.
            DatosIntercalados.Close();
            cache1.Close();
            cache2.Close();
            Ordenar(intercalacion, contador);
        }
        // Metodo encargado de ordenar datos de 2 caches y los exporta en un archivo.
        private static void Ordenar(int intercalacion, int contador) {
            // Flujo de datos para escribir en el archivo final, se trunca en caso de que tenga algun dato.
            // Se crean 2 flujos de datos para leer las caches.
            StreamWriter DatosIntercalados = new StreamWriter(new FileStream("./Datos.txt", FileMode.Truncate));
            StreamReader cache1 = new StreamReader(new FileStream("./Cache1.txt", FileMode.OpenOrCreate));
            StreamReader cache2 = new StreamReader(new FileStream("./Cache2.txt", FileMode.OpenOrCreate));
            // Mientras haya datos para leer en alguna de las caches se ejecutará el programa.
            while (cache2.Peek() != -1 || cache1.Peek() != -1) {
                // Variables auxiliares
                int? aux1 = null;
                int? aux2 = null;
                // Contadores de datos tomados
                int c1 = 0;
                int c2 = 0;
                // Posicion del ultimo elemento de la cache 2 evaluada
                int postB = 0;
                // Se leeran los datos de la cache 1 hasta que se llegue al tope de la intercalacion
                for (int i = 0; i < intercalacion; i++) {
                    // Si aux1 es nulo y se puede tomar un dato de la cache 1, se guarda la linea en la variable aux1 y se indica que se guardo un dato
                    if (aux1 == null && cache1.Peek() != -1) {
                        aux1 = int.Parse(cache1.ReadLine());
                        c1++;
                    }
                    // Se leeran los datos de la cache 2 hasta que se llegue al tope de la intercalacion
                    for (int j = postB; j < intercalacion; j++) {
                        // Si aux2 es nulo y se puede tomar un dato de la cache 2, se guarda la linea en la variable aux2 y se indica que se guardo un dato
                        if (aux2 == null && cache2.Peek() != -1) {
                            aux2 = int.Parse(cache2.ReadLine());
                            c2++;
                        }
                        // Si aux1 es menor que aux2 se imprime en el archivo final y se declara como nulo.
                        // Como ya usamos aux1 tenemos que tomar otro valor asi que se rompe este bucle.
                        if (aux1 < aux2) {
                            DatosIntercalados.WriteLine(aux1);
                            aux1 = null;
                            break;
                        }
                        // En caso que aux2 sea mayor se imprime en el archivo final y se guarda la posicion que sigue en postB
                        // No se rompe el ciclo porque se seguirá evaluando con el valor de aux1.
                        else if (aux2 < aux1) {
                            DatosIntercalados.WriteLine(aux2);
                            postB = j + 1;
                            aux2 = null;
                        }
                    }
                }
                // Si se llegó al tope en alguna de las cache y se quedo un dato en alguna variable aux se imprime en el archivo final.
                // Se limpia el valor de la variable aux impresa.
                if (c1 <= intercalacion && aux1 != null) {
                    DatosIntercalados.WriteLine(aux1);
                    aux1 = null;
                }
                if (c2 <= intercalacion && aux2 != null) {
                    DatosIntercalados.WriteLine(aux2);
                    aux2 = null;
                }
                // En caso que aun haya datos y la variable es nula se recorre todos los datos que falten, siempre y cuando haya datos que leer en la cache.
                if (c1 < intercalacion && aux1 == null) for (int i = c1; i < intercalacion; i++) if (cache1.Peek() == -1) break; else DatosIntercalados.WriteLine(cache1.ReadLine());
                if (c2 < intercalacion && aux2 == null) for (int i = c2; i < intercalacion; i++) if (cache2.Peek() == -1) break; else DatosIntercalados.WriteLine(cache2.ReadLine());
            }
            // Se cierran los flujos de archivos
            DatosIntercalados.Close();
            cache1.Close();
            cache2.Close();
            // Si el nivel de intercalacion es menor que la cantidad total de datos se intercalará con el valor doble.
            if (intercalacion < (contador + 1) / 2) Intercalar(intercalacion * 2, contador);
        }
    }
}