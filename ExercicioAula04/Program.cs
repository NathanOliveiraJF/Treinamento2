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
                {
                    Console.WriteLine("saindo...");
                    break;
                }
                Opcoes(opcao, listaDePessoas);
            }
        }

        private static void PreencherLista(List<Pessoa> pe)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPreenchimento de Lista");
                Console.WriteLine("Digite [ pj ] para Pessoa Jurídica\nOu [ pf ] para Pessoa Física");
                Console.Write("Deseja inserir Pessoa Jurídica ou Física? ");
                var opcao = Console.ReadLine().ToLower();
                if (opcao == "pj")
                {
                    Console.Clear();
                    pe.Add(DadosPessoaJuridica());
                    Console.WriteLine("Pessoa Jurídica Inserida com Sucesso!");
                }
                else if (opcao == "pf")
                {
                    Console.Clear();
                    var pes = DadosPessoaFisica();
                    if (pes != null)
                    {
                        pe.Add(pes);
                        Console.WriteLine("Pessoa Física Inserida com Sucesso!");
                    }
                }
                else
                    Console.Write("Opção inválida!");

                Console.Write("\nDeseja continuar preenchendo a lista ?\ndigite (s) para [sim] ou n para [não]): ");
                opcao = Console.ReadLine().ToLower();
                if (opcao == "n")
                    break;
            }
        }

        private static PessoaFisica DadosPessoaFisica()
        {
            Console.WriteLine("\nPreenchendo Dados Pessoa Física");
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
                Console.WriteLine("Data informada inválida!");
                return null;
            }

            return pf;
        }

        private static PessoaJuridica DadosPessoaJuridica()
        {

            Console.WriteLine("\nPreenchendo Dados Pessoa Jurídica");
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

        private static void Opcoes(string op, List<Pessoa> pe)
        {
            Console.Clear();
            switch (op.ToLower())
            {
                case "a":
                    //etiqueta
                    ImprimeEtiqueta(pe);
                    break;
                case "b":
                    //carta
                    ImprimeCartaDeCobranca(pe);
                    break;
                case "c":
                    //nota
                    ImprimeNotaPromissoria(pe);
                    break;
                case "d":
                    PreencherLista(pe);
                    break;
                default:
                    Console.Write("Opção não existe");
                    break;
            }
        }

        private static void ImprimeNotaPromissoria(List<Pessoa> pe)
        {

            Console.WriteLine("Nota Promissória");
            foreach (var item in pe)
            {
                try
                {
                    Console.Write($"\nInforme a data da Nota Promissoria de {item.Nome}: ");
                    DateTime data = DateTime.Parse(Console.ReadLine());

                    Console.Write($"Informe o valor da Nota Promissoria de {item.Nome}: ");
                    var valor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(item.NotaPromissoria(valor, data));

                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Data inválida ou valor! preencha novamente\n");
                    ImprimeNotaPromissoria(pe);
                }
            }
        }

        private static void ImprimeCartaDeCobranca(List<Pessoa> pe)
        {
            Console.WriteLine("Carta de Cobrança");
            foreach (var item in pe)
                Console.WriteLine(item.CartaCobranca);
        }

        private static void ImprimeEtiqueta(List<Pessoa> pe)
        {
            Console.WriteLine("Etiqueta de Correspondência");
            foreach (var item in pe)
                Console.WriteLine(item.Etiqueta);
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
