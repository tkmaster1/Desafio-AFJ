using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.ViewModels;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Service;
using AutoMapper;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Services
{
    public class OperadoraAppService : IOperadoraAppService
    {
        #region Properties

        private readonly IOperadoraService _operadoraService;

        #endregion

        #region Constructor

        public OperadoraAppService(IOperadoraService operadoraService)
        {
            _operadoraService = operadoraService;
        }

        #endregion

        #region Methods

        public OperadoraViewModel ObterPorId(int id)
        {
            return Mapper.Map<OperadoraViewModel>(_operadoraService.ObterPorId(id));
        }

        public IEnumerable<OperadoraViewModel> BuscarTodosAtivos()
        {
            return Mapper.Map<IEnumerable<OperadoraViewModel>>(_operadoraService.BuscarTodosAtivos());
        }

        public IEnumerable<OperadoraViewModel> Filtros(OperadoraViewModel objViewModel)
        {
            return Mapper.Map<IEnumerable<OperadoraViewModel>>(_operadoraService.Filtros(Mapper.Map<Operadora>(objViewModel)));
        }

        public void Incluir(OperadoraViewModel objViewModel)
        {
            var usu = Mapper.Map<Operadora>(objViewModel);
            _operadoraService.Incluir(usu);
        }

        public void Alterar(OperadoraViewModel objViewModel)
        {
            _operadoraService.Alterar(Mapper.Map<Operadora>(objViewModel));
        }

        public void Remover(int id)
        {
            _operadoraService.Remover(id);
        }

        public void Dispose()
        {
            _operadoraService.Dispose();
        }

        #endregion
    }
}
