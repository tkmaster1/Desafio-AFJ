using AFJ.Empregos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Interfaces
{
    public interface IPlanoAppService : IDisposable
    {
        PlanoViewModel ObterPorId(int id);

        IEnumerable<PlanoViewModel> BuscarTodosAtivos();

        IEnumerable<PlanoViewModel> Filtros(PlanoViewModel objViewModel);

        ICollection<PlanoTelefoniaVOViewModel> FiltrosEspecificos(PlanoTelefoniaVOViewModel objViewModel);

        void Incluir(PlanoViewModel objViewModel);

        void Alterar(PlanoViewModel objViewModel);

        void Remover(int id);
    }
}
