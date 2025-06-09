using System.Collections.Generic;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Domain.Interfaces
{
    public interface ISensorRepository
    {
        void Adicionar(Sensor sensor);
        Sensor? ObterPorId(int id);
        IEnumerable<Sensor> ObterTodos();
        void Atualizar(Sensor sensor);
        void Remover(Sensor sensor);
    }
}
