using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.DAOs
{
    class AlunoDAO : IDAO<Aluno>
    {
        public void Atualizar(Aluno obj)
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Inserir(Aluno obj)
        {
            throw new NotImplementedException();
        }

        public Aluno RetornarPorId(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> RetornaTodos()
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> RetornoPersonalizado(Func<Aluno, bool> busca)
        {
            throw new NotImplementedException();
        }
    }
}
