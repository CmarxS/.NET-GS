using Microsoft.AspNetCore.Mvc;
using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.DTOs;
using FloodianGlobal.Entities;
using System.Collections.Generic;

namespace FloodianGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorApplicationService _service;

        public SensorsController(ISensorApplicationService service)
            => _service = service;

        // GET: api/sensors
        [HttpGet]
        public ActionResult<IEnumerable<Sensor>> GetAll()
        {
            var lista = _service.ObterTodos();
            return Ok(lista);
        }

        // GET: api/sensors/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Sensor> GetById(int id)
        {
            var sensor = _service.ObterPorId(id);
            if (sensor is null)
                return NotFound();
            return Ok(sensor);
        }

        // POST: api/sensors
        [HttpPost]
        public IActionResult Create([FromBody] SensorCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Criar(dto);
            return NoContent();
        }

        // PUT: api/sensors/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] SensorCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = _service.ObterPorId(id);
            if (existente is null)
                return NotFound();

            _service.Atualizar(id, dto);
            return NoContent();
        }

        // DELETE: api/sensors/{id}
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
