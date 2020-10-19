using AFJ.Empregos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Service
{
    public interface ITipoPlanoService : IDisposable
    {
        TipoPlano ObterPorId(int id);

        IEnumerable<TipoPlano> BuscarTodosAtivos();

        IEnumerable<TipoPlano> Filtros(TipoPlano obj);

        void Incluir(TipoPlano obj);

        void Alterar(TipoPlano obj);

        void Remover(int id);
    }
}
