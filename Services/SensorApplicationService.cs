using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.DTOs;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Application.Services
{
    public class SensorApplicationService : ISensorApplicationService
    {
        private readonly ISensorRepository _repository;

        public SensorApplicationService(ISensorRepository repository)
        {
            _repository = repository;
        }

        public Sensor? ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<Sensor> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Criar(SensorCreateDto dto)
        {
            var sensor = new Sensor
            {
                NumeroSerie = dto.NumeroSerie,
                LimiteAlerta = dto.LimiteAlerta,
                IntervaloHoras = dto.IntervaloHoras,
            };
            _repository.Adicionar(sensor);
        }

        public void Atualizar(int id, SensorCreateDto dto)
        {
            var sensor = _repository.ObterPorId(id);
            if (sensor == null)
                throw new ArgumentException("Sensor não encontrado.");

            sensor.NumeroSerie = dto.NumeroSerie;
            sensor.LimiteAlerta = dto.LimiteAlerta;
            sensor.IntervaloHoras = dto.IntervaloHoras;

            _repository.Atualizar(sensor);
        }

        public void Deletar(int id)
        {
            var sensor = _repository.ObterPorId(id);
            if (sensor == null)
                throw new ArgumentException("Sensor não encontrado.");

            _repository.Remover(sensor);
        }
    }
}
