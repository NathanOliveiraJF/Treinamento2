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
            Console.Write("\nInforme uma opção: ");
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
                case 4:
                    ConsultarAlunoPelaMatricula();
                    break;
                case 5:
                    ConsultarAlunoPorParteDoNome();
                    break;
                default:
                    Console.WriteLine("opção inválida!");
                    break;
            }
        }

        private static void ConsultarAlunoPorParteDoNome()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            Console.Write("Informe uma parte do nome do Aluno: ");
            string parteDoNome = Console.ReadLine().ToLower();
            var aluno = context.RetornoPersonalizado((x) => x.Nome.ToLower().Contains(parteDoNome)).ToList();
            DadosAlunos(aluno);
        }

        private static void DadosAlunos(List<Aluno> aluno)
        {
            foreach (var item in aluno)
                Console.WriteLine($"    Matrícula: {item.Matricula} - Nome: {item.Nome} - Email: {item.Email}");
        }

        private static void ConsultarAlunoPelaMatricula()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            Console.Write("Informe a matrícula do Aluno: ");
            int matricula = Convert.ToInt32(Console.ReadLine());
            var aluno = context.RetornoPersonalizado((x) => x.Matricula == matricula).FirstOrDefault();
            if (aluno != null)
            {
                DadosAluno(aluno);
            }
        }

        private static void DadosAluno(Aluno aluno)
        {
            var propsInfoAluno = aluno.GetType().GetProperties();
            Console.WriteLine("Dados Aluno");
            foreach (var prop in propsInfoAluno)
            {
                Console.WriteLine($"    {prop.Name}: {prop.GetValue(aluno)}");
                Console.WriteLine();
            }
            DadosEnderecoAluno(aluno.Enderecos);
        }

        private static void DadosEnderecoAluno(IList<Endereco> enderecos)
        {
            Console.WriteLine("\nDados endereço Aluno");
            foreach (var end in enderecos)
            {
                var propsInfoEndereco = end.GetType().GetProperties();
                foreach (var prop in propsInfoEndereco)
                    Console.WriteLine($"    {prop.Name}: {prop.GetValue(end)}");
                Console.WriteLine();
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
                Console.WriteLine("Deseja Inserir ou Atualizar um endereço: \n[ 1 ] para inserir\n[ 2 ] para atualizar");
                var opc = Console.ReadLine();
                if (opc == "1")
                    InserirEndereco(aluno);
                else if (opc == "2")
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
            if (end != null)
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
                           "\n1) Inserir Aluno\n"
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
            var endereco = ColetaDadosEndereco();
            endereco.AlunoId = aluno.AlunoId;
            aluno.Enderecos.Add(endereco);
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
            string sair = "";
            while (sair != "0")
            {
                Opcao();
                Console.Write("Deseja continuar no Menu: \n[ 1 ] para continuar [ 0 ] para sair:  ");
                sair = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Saindo...");
            Console.ReadKey();
        }
    }
}
