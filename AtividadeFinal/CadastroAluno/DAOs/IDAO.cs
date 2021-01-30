using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.DAOs
{
    interface IDAO<T>
    {
        void Inserir(T obj);
        void Atualizar(T obj);
        void Deletar(T id);
        IList<T> RetornoPersonalizado(Func<T, bool> busca);
        IList<T> RetornaTodos();
        T RetornarPorId(string id);
    }
}
