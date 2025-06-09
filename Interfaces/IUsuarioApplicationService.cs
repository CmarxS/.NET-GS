using System.Collections.Generic;
using FloodianGlobal.DTOs;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Usuario? ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        void Criar(UsuarioCreateDto dto);
        void Atualizar(int id, UsuarioCreateDto dto);
        void Deletar(int id);
    }
}
