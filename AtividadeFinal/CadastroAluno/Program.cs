using CadastroAluno.DAL;
using CadastroAluno.DAOs;
using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace CadastroAluno
{
    class Program
    {
        private static void Opcao()
        {
            Menu();
            Console.Write("Informe uma opção: ");
            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    InserirAluno();
                    break;
                case 2:
                    AlterarAluno();
                    break;
                case 3:
                    ExcluirAluno();
                    break;
                default:
                    Console.WriteLine("opção inválida!");
                    break;
            }
        }

        private static void ExcluirAluno()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());

            Console.Write("Informe a matrícula do Aluno: ");
            int matricula = Convert.ToInt32(Console.ReadLine());
            var aluno = context.RetornoPersonalizado((aluno) => aluno.Matricula == matricula)[0];
            if (aluno != null)
                context.Deletar(aluno);
            else
                Console.WriteLine("Matrícula inválida!");
        }

        private static void AlterarAluno()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            Console.Write("Informe a matrícula do Aluno: ");
            int matricula = Convert.ToInt32(Console.ReadLine());
            var aluno = context.RetornoPersonalizado((aluno) => aluno.Matricula == matricula)[0];
            if (aluno != null)
            {
                NovosDadosAluno(aluno);
                Console.WriteLine("Deseja Inserir ou Atualizar um endereço: \n[ 2 ] para inserir\n[ 3 ] para atualizar");
                var opc = Console.ReadLine();
                if (opc == "2")
                    InserirEndereco(aluno);
                else if (opc == "3")
                    AtualizaEndereco(aluno);
                else
                    return;

                context.Atualizar(aluno);
                Console.WriteLine("Atualizado");

            }
            else
                Console.WriteLine("Matrícula inválida!!");
        }

        private static void AtualizaEndereco(Aluno aluno)
        {
            Console.WriteLine("Informe o tipo de endereço a ser alterado");
            var tipo = Console.ReadLine();
            var end = aluno.Enderecos.Where(x => x.Tipo == tipo).FirstOrDefault();
            if(end != null)
            {
                Console.WriteLine("Informe uma nova Cidade");
                end.Cidade = Console.ReadLine();
            }
        }

        private static void NovosDadosAluno(Aluno aluno)
        {
            Console.WriteLine("Informe um novo nome");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Informe um novo e-mail");
            aluno.Email = Console.ReadLine();

        }

        private static void Menu()
        {
            Console.Write(
                           "1) Inserir Aluno\n"
                           + "2) Alterar Aluno\n"
                           + "3) Excluir Aluno\n"
                           + "4) Consultar aluno pela Matrícula\n"
                           + "5) Consultar aluno por parte do nome\n");
        }

        private static void InserirAluno()
        {
            Aluno aluno = ColetaDadosAluno();
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            Console.WriteLine("Há endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
            string resp = Console.ReadLine();
            while (resp.ToLower().Trim()[0] == 's')
            {
                InserirEndereco(aluno);
                Console.Write("Há mais endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
                resp = Console.ReadLine();
            }
            context.Inserir(aluno);
            Console.WriteLine($"{aluno.Nome} cadastrado com sucesso!");
        }
        private static void InserirEndereco(Aluno aluno)
        {
            //Console.WriteLine(msg);
            //string isEndereco = Console.ReadLine();
            var endereco = ColetaDadosEndereco();
            endereco.AlunoId = aluno.AlunoId;
            aluno.Enderecos.Add(endereco);
            //Console.Write("Há mais endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
            //isEndereco = Console.ReadLine();
            //while (isEndereco.ToLower().Trim()[0] == 's')
            //{
            //    var endereco = ColetaDadosEndereco();
            //    endereco.AlunoId = aluno.AlunoId;
            //    aluno.Enderecos.Add(endereco);
            //    Console.Write("Há mais endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
            //    isEndereco = Console.ReadLine();
            //}
        }

        private static Endereco ColetaDadosEndereco()
        {
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
            return endereco;
        }

        private static Aluno ColetaDadosAluno()
        {
            var aluno = new Aluno();
            Console.Write("Nome do Aluno: ");
            aluno.Nome = Console.ReadLine();
            Console.Write("Matricula: ");
            aluno.Matricula = Convert.ToInt32(Console.ReadLine());
            Console.Write("Email: ");
            aluno.Email = Console.ReadLine();
            return aluno;
        }

        static void Main(string[] args)
        {
            Opcao();
        }
    }
}
