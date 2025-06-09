using Microsoft.AspNetCore.Mvc;
using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.DTOs;
using FloodianGlobal.Entities;
using System.Collections.Generic;

namespace FloodianGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApplicationService _service;

        public UsuariosController(IUsuarioApplicationService service)
            => _service = service;

        // GET: api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = _service.ObterTodos();
            return Ok(usuarios);
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = _service.ObterPorId(id);
            if (usuario is null)
                return NotFound();
            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public IActionResult Create([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Criar(dto);
            return NoContent();
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = _service.ObterPorId(id);
            if (existente is null)
                return NotFound();

            _service.Atualizar(id, dto);
            return NoContent();
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existente = _service.ObterPorId(id);
            if (existente is null)
                return NotFound();

            _service.Deletar(id);
            return NoContent();
        }
    }
}
