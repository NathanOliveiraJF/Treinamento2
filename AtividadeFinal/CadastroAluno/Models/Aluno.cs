using CadastroAluno.DAOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.Models
{
    class Aluno
    {
        public string AlunoId { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IList<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
