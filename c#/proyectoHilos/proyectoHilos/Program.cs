using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
namespace EjemploHilos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estudiante: Jhennyfer Zarate Villar ");
            Console.WriteLine();

            Console.WriteLine("---------------------------------------");
            Conteo prueba = new Conteo();
            Console.WriteLine("# PARES en el Conteo principal: ");
            Console.WriteLine();
            prueba.ContarNumerosPares();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("# IMPARES en el Conteo principal: ");
            Console.WriteLine();
            prueba.ContarNumerosImpares();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("# PRIMOS en el Conteo principal: ");
            Console.WriteLine();
            prueba.ContarNumerosPrimos();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("# PARES desde un hilo: ");
            Console.WriteLine();
            Thread HiloPar = new Thread(prueba.ContarNumerosPares);
            HiloPar.IsBackground = true;
            HiloPar.Start();
            HiloPar.Join();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("# IMPARES desde un hilo: ");
            Console.WriteLine();
            Thread HiloImpar = new Thread(prueba.ContarNumerosImpares);
            HiloImpar.IsBackground = true;
            HiloImpar.Start();
            HiloImpar.Join();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("# PRIMOS desde un hilo: ");
            Console.WriteLine();
            Thread HiloPrimo = new Thread(prueba.ContarNumerosPrimos);
            HiloPrimo.IsBackground = true;
            HiloPrimo.Start();
            HiloPrimo.Join();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Lanzando los tres hilos al mismo tiempo: ");
            Console.WriteLine();
            Thread nuevoHiloPar = new Thread(prueba.ContarNumerosPares);
            Thread nuevoHiloImpar = new Thread(prueba.ContarNumerosImpares);
            Thread nuevoHiloPrimo = new Thread(prueba.ContarNumerosPrimos);
            nuevoHiloPar.Start();
            nuevoHiloImpar.Start();
            nuevoHiloPrimo.Start();
            Console.ReadLine();
        }
    }
    class Conteo
    {
        public void ContarNumerosPares()
        {
            for (int numero = 0; numero <= 100; numero = numero + 2)
            {
                Console.Write(numero + " ");
                for (int GranContador = 0; GranContador <= 20000000; GranContador++) ;
            }

        }
        public void ContarNumerosImpares()
        {
            for (int numero = 1; numero <= 100; numero = numero + 2)
            {
                Console.Write(numero + " ");
                for (int GranContador = 0; GranContador <= 20000000; GranContador++) ;
            }

        }

        public void ContarNumerosPrimos()
        {
            int n = 2;

            int total = 1;

            while (total <= 50)
            {

                bool esPrimo = true;

                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        esPrimo = false;
                        break;
                    }
                }

                if (esPrimo)
                {
                    Console.Write(n + " ");
                    for (int GranContador = 0; GranContador <= 20000000; GranContador++) ;
                    total++;
                }

                n++;
            }
        }
    }
}
