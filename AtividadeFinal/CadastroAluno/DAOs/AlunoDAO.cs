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
                if (end.EnderecoId != null)
                {
                    //se existe endereço então atualiza.
                    var endContext = enderecos.Where(x => x.EnderecoId == end.EnderecoId).FirstOrDefault();

                    if (endContext != null)
                        _DbContext.Entry(end).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                //else
                //{
                //    _DbContext.Entry(end).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                //}
            }
            _DbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _DbContext.SaveChanges();
        }

        public void Inserir(Aluno obj)
        {
            //Se aluno é Nulo então manda inserir juntamente com o endereço.
            if (obj.AlunoId == null)
            {
                var enderecos = obj.Enderecos;
                foreach (var item in enderecos)
                {
                    item.EnderecoId = Guid.NewGuid().ToString();
                    _DbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                obj.AlunoId = Guid.NewGuid().ToString();
                _DbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                //Se o aluno não é nulo, más contém endereços nulos manda inserir os endereços apenas. 
                var enderecosContext = _DbContext.Enderecos.Where(x => x.AlunoId == obj.AlunoId).ToList();
                foreach (var end in obj.Enderecos)
                {
                    if (end.EnderecoId == null)
                    {
                        end.EnderecoId = Guid.NewGuid().ToString();
                        _DbContext.Entry(end).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }
            }
            _DbContext.SaveChanges();
        }

        public IList<Aluno> RetornoPersonalizado(Func<Aluno, bool> busca)
        {
            return _DbContext.Alunos
                 .Include(e => e.Enderecos)
                 .Where(busca).ToList();
        }

        public IList<Aluno> RetonarTodos() => _DbContext.Alunos.ToList();

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
