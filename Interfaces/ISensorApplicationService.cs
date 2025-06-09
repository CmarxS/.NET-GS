using System.Collections.Generic;
using FloodianGlobal.DTOs;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Application.Interfaces
{
    public interface ISensorApplicationService
    {
        Sensor? ObterPorId(int id);
        IEnumerable<Sensor> ObterTodos();
        void Criar(SensorCreateDto dto);
        void Atualizar(int id, SensorCreateDto dto);
        void Deletar(int id);
    }
}
