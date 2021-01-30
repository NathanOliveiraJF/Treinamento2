using CadastroAluno.DAL;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadastroAluno.DAOs
{
    class AlunoDAO : IDAO<Aluno>
    {
        private readonly CadastroAlunoDbContext _DbContext;
        public AlunoDAO(CadastroAlunoDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public void Atualizar(Aluno obj)
        {
            var enderecos = _DbContext.Enderecos.Where(x => x.AlunoId == obj.AlunoId).ToList();

            foreach (var end in obj.Enderecos)
            {
                var endContext = enderecos.Where(x => x.EnderecoId == end.EnderecoId).FirstOrDefault();
                
                if(endContext != null)
                {
                    _DbContext.Entry(endContext).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    
                    _DbContext.Entry(end).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    enderecos.Remove(endContext);
                }
                else
                {
                    _DbContext.Entry(end).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }

            foreach (var item in enderecos)
            {
                _DbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }

            _DbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _DbContext.SaveChanges();
        }

        public void Inserir(Aluno obj)
        {
            if (obj.AlunoId == null)
                obj.AlunoId = Guid.NewGuid().ToString();

            _DbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            foreach (var item in obj.Enderecos)
            {
                item.EnderecoId = Guid.NewGuid().ToString();
                _DbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
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
           return _DbContext.Alunos
                .Include(e => e.Enderecos)
                .Where(busca).ToList();
        }

        public void Deletar(Aluno obj)
        {
            var enderecos = _DbContext.Enderecos.Where(x => x.AlunoId == obj.AlunoId).ToList();

            foreach (var item in enderecos)
                _DbContext.Entry(item).State = EntityState.Deleted;

            _DbContext.Entry(obj).State = EntityState.Deleted;
            _DbContext.SaveChanges();
        }


    }
}
