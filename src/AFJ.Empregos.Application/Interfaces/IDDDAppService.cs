using AFJ.Empregos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Interfaces
{
    public interface IDDDAppService : IDisposable
    {
        DDDViewModel ObterPorId(int id);

        IEnumerable<DDDViewModel> BuscarTodosAtivos();

        IEnumerable<DDDViewModel> Filtros(DDDViewModel objViewModel);

        void Incluir(DDDViewModel objViewModel);

        void Alterar(DDDViewModel objViewModel);

        void Remover(int id);
    }
}
