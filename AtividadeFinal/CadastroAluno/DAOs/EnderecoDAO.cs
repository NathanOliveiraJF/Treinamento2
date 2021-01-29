using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.DAOs
{
    class EnderecoDAO : IDAO<Endereco>
    {
        private readonly DbContext _dbContext;
        public EnderecoDAO(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Atualizar(Endereco obj)
        {
            throw new NotImplementedException();
        }

        public void Deletar(string id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Endereco obj)
        {

            if (obj.Id == null)
                obj.Id = Guid.NewGuid().ToString();

            _dbContext.Add(obj);
            _dbContext.SaveChanges();
        }

        public Endereco RetornarPorId(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Endereco> RetornaTodos()
        {
            throw new NotImplementedException();
        }

        public IList<Endereco> RetornoPersonalizado(Func<Endereco, bool> busca)
        {
            throw new NotImplementedException();
        }
    }
}
