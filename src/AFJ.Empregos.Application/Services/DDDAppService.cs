using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.ViewModels;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Service;
using AutoMapper;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Services
{
    public class DDDAppService : IDDDAppService
    {
        #region Properties

        private readonly IDDDService _dddService;

        #endregion

        #region Constructor

        public DDDAppService(IDDDService dddService)
        {
            _dddService = dddService;
        }

        #endregion

        #region Methods

        public DDDViewModel ObterPorId(int id)
        {
            return Mapper.Map<DDDViewModel>(_dddService.ObterPorId(id));
        }

        public IEnumerable<DDDViewModel> BuscarTodosAtivos()
        {
            return Mapper.Map<IEnumerable<DDDViewModel>>(_dddService.BuscarTodosAtivos());
        }

        public IEnumerable<DDDViewModel> Filtros(DDDViewModel objViewModel)
        {
            return Mapper.Map<IEnumerable<DDDViewModel>>(_dddService.Filtros(Mapper.Map<DDD>(objViewModel)));
        }

        public void Incluir(DDDViewModel objViewModel)
        {
            var usu = Mapper.Map<DDD>(objViewModel);
            _dddService.Incluir(usu);
        }

        public void Alterar(DDDViewModel objViewModel)
        {
            _dddService.Alterar(Mapper.Map<DDD>(objViewModel));
        }

        public void Remover(int id)
        {
            _dddService.Remover(id);
        }

        public void Dispose()
        {
            _dddService.Dispose();
        }

        #endregion
    }
}
