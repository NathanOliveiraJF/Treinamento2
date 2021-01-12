using System;
using System.Collections.Generic;

namespace ExercicioAula04
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaDePessoas = new List<Pessoa>();
            PreencherLista(listaDePessoas);
            while (true)
            {
                Menu();
                var opcao = Console.ReadLine();
                if (opcao.ToLower() == "1")
                    break;
                Opcoes(opcao, listaDePessoas);
            }
            Console.ReadKey();
        }

        private static void PreencherLista(List<Pessoa> pe)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPreenchimento de Lista");
                Console.WriteLine("Digite [ pj ] para Pessoa Jurídica \n ou [ pf ] para Pessoa Física");
                Console.Write("Deseja inserir Pessoa Jurídica ou Física? ");
                var opcao = Console.ReadLine().ToLower();
                if (opcao == "pj")
                {
                    var pj = new PessoaJuridica();
                    Console.Clear();
                    pe.Add(PrencherDados(pj));
                    Console.WriteLine("Pessoa Jurídica Inserida com Sucesso!");
                }
                else if (opcao == "pf")
                {
                    var pf = new PessoaFisica();
                    Console.Clear();
                    pe.Add(PrencherDados(pf));
                    Console.WriteLine("Pessoa Física Inserida com Sucesso!");
                }
                else
                    Console.Write("Opção inválida!");

                Console.Write("\nDeseja continuar preenchendo a lista ?\ndigite (s) para [sim] ou n para [não]): ");
                opcao = Console.ReadLine().ToLower();
                if (opcao == "n")
                    break;
            }
        }

        private static Pessoa PrencherDados(Pessoa p)
        {
            if (p is PessoaJuridica)
            {
                var pj = new PessoaJuridica();
                Console.Write("Nome da empresa: ");
                pj.Nome = Console.ReadLine();
                Console.Write("Email: ");
                pj.Email = Console.ReadLine();
                Console.Write("Endereço: ");
                pj.Endereco = Console.ReadLine();
                Console.Write("Cnpj: ");
                pj.Cnpj = Console.ReadLine();
                Console.Write("Contato: ");
                pj.Contato = Console.ReadLine();
                return pj;

            }

            var pf = new PessoaFisica();
            Console.Write("Nome da Pessoa: ");
            pf.Nome = Console.ReadLine();
            Console.Write("Email: ");
            pf.Email = Console.ReadLine();
            Console.Write("Endereço: ");
            pf.Endereco = Console.ReadLine();
            Console.Write("Cpf: ");
            pf.Cpf = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            try
            {
                pf.DataNascimento = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new Exception("Data informada inválida!");
            }
            return pf;

        }

        private static void Opcoes(string op, List<Pessoa> pe)
        {
            Console.Clear();
            switch (op.ToLower())
            {
                case "a":
                    //etiqueta
                    Etiqueta(pe);
                    break;
                case "b":
                    //carta
                    break;
                case "c":
                    //nota
                    break;
                case "d":
                    PreencherLista(pe);
                    break;
                default:
                    Console.Write("Opção não existe");
                    break;
            }
        }

        private static void Etiqueta(List<Pessoa> pe)
        {
            Console.WriteLine("Etiqueta de Correspondência");
            foreach (var item in pe)
            {
                if (item is PessoaFisica)
                {
                    Console.WriteLine("\nPessoa Física");
                    Console.WriteLine($"{item.Nome}\n{item.Endereco}");
                }
                else
                {
                    var pf = (PessoaJuridica)item;
                    Console.WriteLine("\nPessoa Juridica");
                    Console.WriteLine($"{pf.Nome}\nAos cuidados de {pf.Contato}\n{pf.Endereco}");
                }
            }
        }

        private static void Menu()
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Menu");
            Console.WriteLine("a) Imprimir etiqueta para correspondência" +
                "\nb) Imprimir carta de cobrança" +
                "\nc) Imprimir nota promissória" +
                "\nd) continuar preenchendo a lista" +
                "\n1) para sair" +
                "\nQual das opções você deseja? ");
        }
    }
}
