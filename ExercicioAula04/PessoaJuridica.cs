using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioAula04
{
    class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string Contato { get; set; }
        public override string Etiqueta => $"\nPessoa Jurídica\n{this.Nome}\nAos cuidados de {this.Contato}\n{this.Endereco}";
        public override string CartaCobranca => $"\nPessoa Jurídica\nCaro(a){ this.Contato}, A {this.Nome} me deve!";
    }
}
