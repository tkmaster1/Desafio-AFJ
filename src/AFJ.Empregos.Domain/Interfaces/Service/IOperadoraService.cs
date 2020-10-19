using AFJ.Empregos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Service
{
    public interface IOperadoraService : IDisposable
    {
        Operadora ObterPorId(int id);

        IEnumerable<Operadora> BuscarTodosAtivos();

        IEnumerable<Operadora> Filtros(Operadora obj);

        void Incluir(Operadora obj);

        void Alterar(Operadora obj);

        void Remover(int id);
    }
}
