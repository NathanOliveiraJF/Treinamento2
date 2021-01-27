using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.DAOs
{
    class EnderecoDAO : IDAO<Endereco>
    {
        public void Atualizar(Endereco obj)
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Inserir(Endereco obj)
        {
            throw new NotImplementedException();
        }

        public Endereco RetornarPorId(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Endereco> RetornarTodos()
        {
            throw new NotImplementedException();
        }

        public IList<Endereco> RetornoPersonalizado(Func<Endereco, bool> busca)
        {
            throw new NotImplementedException();
        }
    }
}
