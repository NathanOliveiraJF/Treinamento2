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
                    Console.WriteLine("\n#####Cadastro de Aluno#####");
                    InserirAluno();
                    break;
                case 2:
                    Console.WriteLine("\n#####Alterar Aluno Cadastrado#####");
                    AlterarAluno();
                    break;
                case 3:
                    Console.WriteLine("\n#####Excluir Aluno Cadastrado#####");
                    ExcluirAluno();
                    break;
                case 4:
                    Console.WriteLine("\n#####Consulta Aluno Cadastrado pela Matricula#####");
                    ConsultarAlunoPelaMatricula();
                    break;
                case 5:
                    Console.WriteLine("\n#####Consulta Aluno Cadastrado por parte do Nome#####");
                    ConsultarAlunoPorParteDoNome();
                    break;
                default:
                    Console.WriteLine("opção inválida!");
                    break;
            }
        }
        private static void InserirAluno()
        {
            Aluno aluno = LerDadosAluno();
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            Insere(aluno);
            try
            {
                context.Inserir(aluno);
                Console.WriteLine($"\n{aluno.Nome} cadastrado com sucesso!\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Ops.. ocorreu algum erro ou matrícula já utilizada");
                AlunosMatriculados();
            }
        }

        private static void AlterarAluno()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            AlunosMatriculados();
            var matricula = LerMatriculaAluno();
            var aluno = context.RetornoPersonalizado((aluno) => aluno.Matricula == matricula).FirstOrDefault();
            if (aluno != null)
            {
                LerNovosDadosAluno(aluno);
                if (AlteraEndereco(aluno, context))
                    Console.WriteLine("\n[ aluno Atualizado ]");
            }
            else
                Console.WriteLine("Matrícula inválida!!");
        }

        private static void ExcluirAluno()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            AlunosMatriculados();
            var matricula = LerMatriculaAluno();
            var aluno = context.RetornoPersonalizado((aluno) => aluno.Matricula == matricula).FirstOrDefault();

            if (aluno != null)
                context.Deletar(aluno);
            else
                Console.WriteLine("Matrícula inválida!");
        }

        private static void ConsultarAlunoPelaMatricula()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            AlunosMatriculados();
            var matricula = LerMatriculaAluno();
            var aluno = context.RetornoPersonalizado((x) => x.Matricula == matricula).FirstOrDefault();
            if (aluno != null)
            {
                Console.WriteLine("\n####Aluno####");
                Console.WriteLine(aluno);
                Console.WriteLine("\n####Endereços####");
                ImprimeDadosEnderecoAluno(aluno.Enderecos);
            }
            else
                Console.WriteLine("\nMatrícula inválida!\n");
        }

        private static void AlunosMatriculados()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            var alunos = context.RetonarTodos();
            Console.WriteLine("\nalunos matriculados\n");
            foreach (var item in alunos)
                Console.WriteLine($"[ Matricula: {item.Matricula} ] - Nome: {item.Nome}");
        }

        private static void ConsultarAlunoPorParteDoNome()
        {
            var context = new AlunoDAO(new CadastroAlunoDbContext());
            Console.Write("Informe uma parte do nome do Aluno: ");
            string parteDoNome = Console.ReadLine().ToLower();
            var aluno = context.RetornoPersonalizado((x) => x.Nome.ToLower().Contains(parteDoNome)).ToList();
            Console.WriteLine("\nAlunos:\n");
            ImprimeDadosDeAlunos(aluno);
        }
        private static void Insere(Aluno aluno)
        {
            Console.Write("\nHá endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
            string resp = Console.ReadLine();
            while (resp.ToLower().Trim()[0] == 's')
            {
                InserirEndereco(aluno);
                Console.Write("Há mais endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
                resp = Console.ReadLine();
            }
        }

        private static bool AlteraEndereco(Aluno aluno, AlunoDAO context)
        {
            Console.WriteLine("\n[1] para inserir\n[2] para atualizar\n[3] para nenhuma opção");
            Console.Write("Deseja Inserir ou Atualizar um endereço: ");
            var opc = Console.ReadLine();
            bool att = true;
            switch (opc)
            {
                case "1":
                    Console.Write("\nInserir novo endereço\n");
                    InserirEndereco(aluno);
                    context.Inserir(aluno);
                    break;
                case "2":
                    Console.Write("\nAtualização de endereço\n");
                    AtualizaEndereco(aluno);
                    context.Atualizar(aluno);
                    break;
                case "3":
                    Console.WriteLine("Atualização de [ Endereço ] cancelada!");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    att = false;
                    break;
            }
            return att;
        }

        private static void InserirEndereco(Aluno aluno)
        {
            var endereco = LerDadosEndereco();
            endereco.AlunoId = aluno.AlunoId;
            aluno.Enderecos.Add(endereco);

        }
        private static void AtualizaEndereco(Aluno aluno)
        {
            Console.Write("Informe o tipo de endereço a ser alterado: ");
            var tipo = Console.ReadLine().ToLower();
            var end = aluno.Enderecos.Where(x => x.Tipo.ToLower() == tipo).FirstOrDefault();
            if (end != null)
            {
                Console.Write("Informe uma nova Cidade: ");
                end.Cidade = Console.ReadLine();
            }
            else
                Console.WriteLine("Endereço inválido");
        }
        private static int LerMatriculaAluno()
        {
            Console.Write("\nInforme a matrícula do Aluno: ");
            int matricula = Convert.ToInt32(Console.ReadLine());
            return matricula;
        }

        private static void LerNovosDadosAluno(Aluno aluno)
        {
            Console.Write($"\nAluno selecionado: {aluno.Nome}");

            Console.Write("\nInforme um novo nome: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Informe um novo e-mail: ");
            aluno.Email = Console.ReadLine();

        }

        private static Endereco LerDadosEndereco()
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

        private static Aluno LerDadosAluno()
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
        private static void ImprimeDadosDeAlunos(IList<Aluno> aluno)
        {
            foreach (var item in aluno)
                Console.WriteLine($"{item}\n");
        }

        private static void ImprimeDadosEnderecoAluno(IList<Endereco> enderecos)
        {
            foreach (var end in enderecos)
                Console.WriteLine($"{end}\n");
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

        static void Main(string[] args)
        {
            string sair = "";
            while (sair != "0")
            {
                Opcao();
                Console.Write("\nDeseja continuar no Menu: \n[ 1 ] para continuar [ 0 ] para sair:  ");
                sair = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Saindo...");
            Console.ReadKey();
        }
    }
}
