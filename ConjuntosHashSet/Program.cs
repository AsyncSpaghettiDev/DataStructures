using System;
using System.Collections.Generic;
class Program{
    static void Main(string[] args){
        // Mojica Vidal Jonathan Jafet
        // 19211688

        // Declaración Conjutos principales
        HashSet<int> ConjuntoA = new HashSet<int>();
        HashSet<int> ConjuntoB = new HashSet<int>();
        
        // Captura de datos en los conjuntos pasados por referencia
        Captura(
            ref ConjuntoA, 
            6 ,
            "A");
        Captura(
            ref ConjuntoB, 
            8, 
            "B");

        // Se realizan operaciones usando los conjuntos A y B
        // Los conjuntos de unido, int, dif se usan como paso de parametro de salida
        Operaciones(
            ConjuntoA,
            ConjuntoB,
            out HashSet<int> Unido,
            out HashSet<int> Inter,
            out HashSet<int> Dif
        );

        // Se mandan todos los conjuntos para ser desplegados
        Despliegue(
            ConjuntoA,
            ConjuntoB,
            Unido,
            Inter,
            Dif
        );

    }
    // Se recibe un dato tipo HashSet, se obtiene su longitud y el nombre
    // Con esos datos se declara el for y el mensaje que se mostrará al usuario
    static void Captura(ref HashSet<int> Conjunto, int Longitud, string nombre){
        // Se prepara la consola
        Console.Clear();
        Console.Title = "Capturando Conjunto "+ nombre ;

        // Se repite la captura para la cantidad de datos
        for(int i = 0 ; i < Longitud ; i++){
            Console.Write("Ingresa el dato #{0} del Conjunto {1}: ",i+1, nombre);
            Conjunto.Add(Int32.Parse(Console.ReadLine()));
        }
    }
    // Se realizan 3 operaciones basicas con los 2 conjuntos dados
    static void Operaciones(
        HashSet<int> A,
        HashSet<int> B,
        out HashSet<int> Unido, 
        out HashSet<int> Intersectado, 
        out HashSet<int> Diferenciado){
            // Todas las operaciones están basadas en A
            Unido = new HashSet<int>(A);
            Unido.UnionWith(B);

            Intersectado = new HashSet<int>(A);
            Intersectado.IntersectWith(B);

            Diferenciado = new HashSet<int>(A); 
            Diferenciado.ExceptWith(B);
    }
    // Se reciben los conjuntos que se usaron para ser desplegados con un simple foreach
    static void Despliegue(HashSet<int> CA, HashSet<int> CB, HashSet<int> CU, HashSet<int> CI, HashSet<int> CD ){
        // Se prepara la consola
        Console.Clear();
        Console.Title = "Despliegue de Conjuntos";

        Console.Write("Conjunto A:");
        foreach(int A in CA){
            Console.Write("\t {0}",A);
        }

        Console.Write("\nConjunto B:");
        foreach(int B in CB){
            Console.Write("\t {0}",B);
        }

        Console.Write("\nConjunto Unión AB:");
        foreach(int U in CU){
            Console.Write("\t {0}",U);
        }

        Console.Write("\nConjunto Intersección AB:");
        foreach(int I in CI){
            Console.Write("\t {0}",I);
        }

        Console.Write("\nConjunto Diferencia AB:");
        foreach(int D in CD){
            Console.Write("\t {0}",D);
        }

        // Salida del programa
        Console.Write("\nPresiona una tecla para salir...");
        Console.ReadLine();
    }
}