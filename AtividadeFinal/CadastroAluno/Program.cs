﻿using CadastroAluno.DAL;
using CadastroAluno.DAOs;
using CadastroAluno.Models;
using System;
using System.Collections.Generic;
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
                default:
                    Console.WriteLine("opção inválida!");
                    break;
            }
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
            InserirEndereco(aluno);
            context.Inserir(aluno);
            Console.WriteLine("Inserido!");
        }
        private static void InserirEndereco(Aluno aluno)
        {
            Console.Write("Há endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
            string isEndereco = Console.ReadLine();
            while (isEndereco.ToLower().Trim()[0] == 's')
            {
                var endereco = ColetaDadosEndereco();
                endereco.AlunoId = aluno.AlunoId;
                aluno.Enderecos.Add(endereco);
                Console.Write("Há mais endereço a ser informado: \n[ s ] para sim e [ n ] para não: ");
                isEndereco = Console.ReadLine();
            }
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
