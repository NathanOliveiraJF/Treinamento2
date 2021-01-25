using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.Models
{
    class Endereco
    {
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }


        public override string ToString()
            => $"Tipo: {Tipo}\nLogradouro: {Logradouro}\nNumero: {Numero}\nComplemento: {Complemento}\nBairro: {Bairro}\nCidade: {Cidade}";
        
    }
}
