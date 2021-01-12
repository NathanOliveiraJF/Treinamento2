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
        public override string CartaCobranca => $"\nPessoa Física\nCaro(a){ this.Nome},Você me deve!";

        public override string NotaPromissoria(double valor, DateTime data)
        {
           return $"\nPessoa Física\nEu {this.Nome} prometo que vou pagar {valor:C2} na data {data.ToShortDateString()}.";
        }
    }
}
