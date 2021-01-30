using CadastroAluno.DAL;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadastroAluno.DAOs
{
    class EnderecoDAO : IDAO<Endereco>
    {
        private readonly CadastroAlunoDbContext _DbContext;
        public EnderecoDAO(CadastroAlunoDbContext DbContext)
        {
            _DbContext = DbContext;
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

            if (obj.EnderecoId == null)
                obj.EnderecoId = Guid.NewGuid().ToString();

            _DbContext.Add(obj);
            _DbContext.SaveChanges();
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
