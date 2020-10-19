using AFJ.Empregos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Interfaces
{
    public interface IOperadoraAppService : IDisposable
    {
        OperadoraViewModel ObterPorId(int id);

        IEnumerable<OperadoraViewModel> BuscarTodosAtivos();

        IEnumerable<OperadoraViewModel> Filtros(OperadoraViewModel objViewModel);

        void Incluir(OperadoraViewModel objViewModel);

        void Alterar(OperadoraViewModel objViewModel);

        void Remover(int id);
    }
}
