using System;
using System.IO;
using System.Collections.Generic;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan
        // 19211688

        // Se declara una lista de contactos que será la agenda
        List<Contacto> agenda = new List<Contacto>();

        // Se declara un menú
        bool salida = false;
        do{
            // Se prepara la consola
            Console.Clear();
            Console.Title = "Menú";

            // Se despliegan las opciones
            Console.WriteLine(
                "Presiona una tecla para elegir\nC = Cargar agenda\nG = Guardar agenda\nR = Llenar agenda\nA = Agregar contacto en agenda\nM = Modificar un contacto\nS = Salir ");
            
            // Switch que representa las opciones
            switch(Console.ReadKey().Key){
                case ConsoleKey.C : 
                    agenda.Clear();
                    Flujo.Cargar(ref agenda);
                break;

                case ConsoleKey.G :
                    Flujo.Guardar(agenda);
                break;

                case ConsoleKey.R :
                    Console.Clear();
                    Console.Title = "Captura de registros";

                    // Se capturan los contactos
                    agenda.Clear();              
                    Console.Write("\nIngrese la cantidad de contactos a registrar: ");
                    int lim = Int32.Parse(Console.ReadLine());

                    for(int i = 0 ; i < lim ; i++)
                        agenda.Add(Registrar(i + 1));
                
                break;

                case ConsoleKey.A :
                    Console.Clear();
                    agenda.Add(Registrar(agenda.Count+1));
                break;

                case ConsoleKey.M :
                    Console.Write("\nIngresa el # de contacto a editar: ");
                    int indice = Int32.Parse(Console.ReadLine());

                    // En caso que el indice exceda la agenda se volverá a pedir al usuario
                    if(indice > agenda.Count)
                        goto case ConsoleKey.M;
                    else 
                        agenda[indice] = Registrar(indice);
                break;

                case ConsoleKey.S : 
                    if (agenda.Count < 5){
                        Console.WriteLine("Debes tener almenos 5 registros, presiona una tecla para continuar");
                        Console.ReadLine();
                    }
                    else
                        salida = true;
                break;

                default:
                    Console.WriteLine("\nTecla inválida");
                break;
            }
        }
        while(!salida);

        // Al salir se despliegan los datos de la agenda
        Console.Clear();
        foreach(Contacto registro in agenda)
            Console.WriteLine(registro);

        Console.Write("Presiona una tecla para salir...");
        Console.ReadLine();
    }
    static string noCelular(string lada, string celular) => String.Format(lada + "-" + celular).Replace(" ","");
    static Contacto Registrar(int indice){      
        Console.Title = "Capturando contacto #"+(indice);
        string name = captura(String.Format("Escribe el nombre del contacto #{0} : ", indice), 15);

        return new Contacto(
                name, 
                new DateTime(
                    DateTime.Now.Year, 
                    Int32.Parse(captura(String.Format("Ingresa el mes de cumpleaños de {0}: ", name), 2) ),
                    Int32.Parse(captura(String.Format("Ingresa el dia de cumpleaños de {0}: ", name), 2) )
                ),
                noCelular(
                captura(String.Format("Ingresa la lada del celular de {0}: " , name ) , 3 ) ,
                captura(String.Format("Ingresa el no de Telefono del celular de {0}: " , name ) , 7 )
                )
            );
    }
    static string captura(string text,int limite){
        string dat;
        do{
            Console.WriteLine("Ingrese un dato de maximo {0} caracteres",limite);
            Console.Write(text);
            dat = Console.ReadLine();
        }
        while(dat.Length > limite);
        return dat;
    }
}
struct Contacto{
    public string nombre{
        get;
        private set;
    }
    public string celular{
        get;
        private set;
    }
    public DateTime fechaNacimiento{
        get;
        private set;
    }
    public Contacto(string nombre, DateTime fechaNacimiento, string celular){
        this.nombre = nombre;
        this.fechaNacimiento = fechaNacimiento;
        this.celular = celular;
    }
    public static string Headers => String.Format("{0}|{1}|{2}","CONTACTO","TELÉFONO","CUMPLEAÑOS");
    public override string ToString() =>
        String.Format("{0}|{1}|{2}",this.nombre,this.celular,this.fechaNacimiento.ToString("dd~MM"));
    
}
class Flujo{
    public static void Cargar(ref List<Contacto> agenda){
        StreamReader textIn = null;
        try{
            string[] campos;
            string[] fecha;

            if(! File.Exists("./Agenda.txt") )
                File.Create("./Agenda.txt").Close();
                
            textIn = new StreamReader(new FileStream(
                "./Agenda.txt",
                FileMode.Open, FileAccess.Read
            ) );

            textIn.ReadLine();

            while(textIn.Peek() != -1){
                campos = textIn.ReadLine().Split('|');
                fecha = campos[2].Split('~');

                agenda.Add( new Contacto(
                    campos[0], 
                    new DateTime(DateTime.Now.Year, Int32.Parse(fecha[1]), Int32.Parse(fecha[0]) ) , 
                    campos[1] 
                    ) );
            }
        }
        catch(Exception ex){
            Console.WriteLine(ex.ToString());
        }
        finally{
            if(textIn != null)
                textIn.Close();
        }
    }
    public static void Guardar(List<Contacto> agenda){
        StreamWriter textOut = null;
        try{
            textOut = new StreamWriter(new FileStream(
                "./Agenda.txt",
                FileMode.Create,
                FileAccess.Write
            ) );
            textOut.WriteLine(Contacto.Headers);

            foreach(Contacto registro in agenda)
                textOut.WriteLine(registro);
        }
        catch(Exception ex){
            Console.WriteLine(ex.ToString());
        }
        finally{
            if (textOut != null)
                textOut.Close();
        }
    }
}