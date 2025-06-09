using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.DTOs;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario? ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Criar(UsuarioCreateDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                TipoUsuario = dto.TipoUsuario,
                Senha = dto.Senha
            };
            _repository.Adicionar(usuario);
        }

        public void Atualizar(int id, UsuarioCreateDto dto)
        {
            var usuario = _repository.ObterPorId(id);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado.");

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            usuario.Telefone = dto.Telefone;
            usuario.TipoUsuario = dto.TipoUsuario;
            usuario.Senha = dto.Senha;

            _repository.Atualizar(usuario);
        }

        public void Deletar(int id)
        {
            var usuario = _repository.ObterPorId(id);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado.");

            _repository.Remover(usuario);
        }
    }
}
