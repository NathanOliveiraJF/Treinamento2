using CadastroAluno.DAL;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.DAOs
{
    class AlunoDAO : IDAO<Aluno>
    {
        private readonly DbContext _DbContext;
        public AlunoDAO(DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public void Atualizar(Aluno obj)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Aluno obj)
        {
            if (obj.Id == null)
                obj.Id = Guid.NewGuid().ToString();

            _DbContext.Add(obj);
            _DbContext.SaveChanges();
           
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

        public void Deletar(string id)
        {
            throw new NotImplementedException();
        }

        
    }
}
