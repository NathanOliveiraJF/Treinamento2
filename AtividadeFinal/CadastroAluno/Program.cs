using CadastroAluno.Models;
using System;
using System.Reflection;


namespace CadastroAluno
{
    class Program
    {
        static void Main(string[] args)
        {
            Opcao();
        }

      
        private static void Opcao()
        {
            Menu();
            Console.Write("Informe uma opção: ");
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                  //  InserirAluno();
                    InserirEndereco();
                    break;
                default:
                    Console.WriteLine("opção inválida!");
                    break;
            }
        }

        private static void InserirAluno()
        {
            var aluno = new Aluno();
            Console.Write("Nome do Aluno: ");
            aluno.Nome = Console.ReadLine();
            Console.Write("Matricula: ");
            aluno.Matricula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Email");
            aluno.Email = Console.ReadLine();
            //TODO: criar AlunoDAO e método inserir.
        }

        private static void InserirEndereco()
        {
            Console.WriteLine("Há endereço a ser informado: \n[ s ] para sim e [ n ] para não");
            var isEndereco = Console.ReadLine();

            if (isEndereco.ToLower().Trim()[0] == 'n')
                return;

            var endereco = new Endereco();
            Console.Write("Tipo de Endereço: ");
            endereco.Tipo = Console.ReadLine();
            Console.Write("Logradouro: ");
            endereco.Logradouro = Console.ReadLine();
            Console.Write("Numero: ");
            endereco.Numero = Console.ReadLine();
            Console.Write("Complemento: ");
            endereco.Complemento = Console.ReadLine();
            Console.Write("Bairro: ");
            endereco.Bairro = Console.ReadLine();
            Console.Write("Cidade: ");
            endereco.Cidade = Console.ReadLine();
            //TODO: criar EnderecoDAO e método inserir
        }

        private static void Menu()
        {
            Console.WriteLine(
                "1) Inserir Aluno\n"
                + "2) Alterar Aluno\n"
                + "3) Excluir Aluno\n"
                + "4) Consultar aluno pela Matrícula\n"
                + "5) Consultar aluno por parte do nome");
        }
    }
}
