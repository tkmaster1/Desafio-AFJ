using AFJ.Empregos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Service
{
    public interface IDDDService : IDisposable
    {
        DDD ObterPorId(int id);

        IEnumerable<DDD> BuscarTodosAtivos();

        IEnumerable<DDD> Filtros(DDD obj);

        void Incluir(DDD obj);

        void Alterar(DDD obj);

        void Remover(int id);
    }
}
