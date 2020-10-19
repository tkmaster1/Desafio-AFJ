using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.ViewModels;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Service;
using AutoMapper;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Services
{
    public class TipoPlanoAppService : ITipoPlanoAppService
    {
        #region Properties

        private readonly ITipoPlanoService _tipoPlanoService;

        #endregion

        #region Constructor

        public TipoPlanoAppService(ITipoPlanoService tipoPlanoService)
        {
            _tipoPlanoService = tipoPlanoService;
        }

        #endregion

        #region Methods

        public TipoPlanoViewModel ObterPorId(int id)
        {
            return Mapper.Map<TipoPlanoViewModel>(_tipoPlanoService.ObterPorId(id));
        }

        public IEnumerable<TipoPlanoViewModel> BuscarTodosAtivos()
        {
            return Mapper.Map<IEnumerable<TipoPlanoViewModel>>(_tipoPlanoService.BuscarTodosAtivos());
        }

        public IEnumerable<TipoPlanoViewModel> Filtros(TipoPlanoViewModel objViewModel)
        {
            return Mapper.Map<IEnumerable<TipoPlanoViewModel>>(_tipoPlanoService.Filtros(Mapper.Map<TipoPlano>(objViewModel)));
        }

        public void Incluir(TipoPlanoViewModel objViewModel)
        {
            var usu = Mapper.Map<TipoPlano>(objViewModel);
            _tipoPlanoService.Incluir(usu);
        }

        public void Alterar(TipoPlanoViewModel objViewModel)
        {
            _tipoPlanoService.Alterar(Mapper.Map<TipoPlano>(objViewModel));
        }

        public void Remover(int id)
        {
            _tipoPlanoService.Remover(id);
        }

        public void Dispose()
        {
            _tipoPlanoService.Dispose();
        }

        #endregion
    }
}
