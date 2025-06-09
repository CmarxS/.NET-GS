using System.Collections.Generic;
using System.Linq;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.Entities;
using FloodianGlobal.Data;

namespace FloodianGlobal.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FloodianDbContext _context;

        public UsuarioRepository(FloodianDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? ObterPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _context.Usuarios.ToList();
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
