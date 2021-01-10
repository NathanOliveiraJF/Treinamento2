using System;
using System.Collections.Generic;

namespace ExercicioAula04
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }

        private static void Opcoes(string op)
        {
            switch (op.ToLower())
            {
                case "a":
                    //etiqueta
                    break;
                case "b":
                    //carta
                    break;
                case "c":
                    //nota
                    break;
                default:
                    Console.Write("Opção não existe");
                    break;
            }
        }

        private static void Menu()
        {

            Console.WriteLine("a) Imprimir etiqueta para correspondência");
            Console.WriteLine("b) Imprimir carta de cobrança");
            Console.WriteLine("c) Imprimir nota promissória");
            Console.WriteLine("Qual das opções você deseja? ");

            var op = Console.ReadLine();
            Opcoes(op);

        }
    }
}
