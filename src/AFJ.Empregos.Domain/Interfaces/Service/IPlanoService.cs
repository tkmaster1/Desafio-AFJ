using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Interfaces.Service
{
    public interface IPlanoService : IDisposable
    {
        Plano ObterPorId(int id);

        IEnumerable<Plano> BuscarTodosAtivos();

        IEnumerable<Plano> Filtros(Plano obj);

        ICollection<PlanoTelefoniaVO> FiltrosEspecificos(PlanoTelefoniaVO objModel);

        void Incluir(Plano obj);

        void Alterar(Plano obj);

        void Remover(int id);
    }
}
