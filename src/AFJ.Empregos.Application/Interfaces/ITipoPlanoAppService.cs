using AFJ.Empregos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Interfaces
{
    public interface ITipoPlanoAppService : IDisposable
    {
        TipoPlanoViewModel ObterPorId(int id);

        IEnumerable<TipoPlanoViewModel> BuscarTodosAtivos();

        IEnumerable<TipoPlanoViewModel> Filtros(TipoPlanoViewModel objViewModel);

        void Incluir(TipoPlanoViewModel objViewModel);

        void Alterar(TipoPlanoViewModel objViewModel);

        void Remover(int id);
    }
}
