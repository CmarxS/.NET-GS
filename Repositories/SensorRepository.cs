using System.Collections.Generic;
using System.Linq;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.Entities;
using FloodianGlobal.Data;

namespace FloodianGlobal.Infrastructure.Data.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly FloodianDbContext _context;

        public SensorRepository(FloodianDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            _context.SaveChanges();
        }

        public Sensor? ObterPorId(int id)
        {
            return _context.Sensors.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sensor> ObterTodos()
        {
            return _context.Sensors.ToList();
        }

        public void Atualizar(Sensor sensor)
        {
            _context.Sensors.Update(sensor);
            _context.SaveChanges();
        }

        public void Remover(Sensor sensor)
        {
            _context.Sensors.Remove(sensor);
            _context.SaveChanges();
        }
    }
}
