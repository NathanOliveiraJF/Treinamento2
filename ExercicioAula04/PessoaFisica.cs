using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioAula04
{
    class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public override string Etiqueta => $"\nPessoa Física\n{ this.Nome}\n{ this.Endereco}";
        
    }
}
