﻿using CadastroAluno.DAL;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Deletar(string id)
        {
            throw new NotImplementedException();
        }


    }
}
