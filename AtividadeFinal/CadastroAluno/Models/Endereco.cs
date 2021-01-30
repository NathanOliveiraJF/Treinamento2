using CadastroAluno.DAOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.Models
{
    class Endereco
    {
        public string EnderecoId { get; set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string AlunoId { get; set; }
    }
}
