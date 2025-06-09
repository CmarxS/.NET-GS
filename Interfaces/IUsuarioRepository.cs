using System.Collections.Generic;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        Usuario? ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
    }
}
