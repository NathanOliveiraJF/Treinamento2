using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioAula04
{
    abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public abstract string Etiqueta { get;}

        public abstract string CartaCobranca { get; }

        public abstract string NotaPromissoria(double valor, DateTime data);
    }
}
