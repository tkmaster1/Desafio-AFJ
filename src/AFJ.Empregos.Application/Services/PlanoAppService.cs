using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.ViewModels;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Service;
using AFJ.Empregos.Domain.ValueObjects;
using AutoMapper;
using System.Collections.Generic;

namespace AFJ.Empregos.Application.Services
{
    public class PlanoAppService : IPlanoAppService
    {
        #region Properties

        private readonly IPlanoService _planoService;

        #endregion

        #region Constructor

        public PlanoAppService(IPlanoService planoService)
        {
            _planoService = planoService;
        }

        #endregion

        #region Methods

        public PlanoViewModel ObterPorId(int id)
        {
            return Mapper.Map<PlanoViewModel>(_planoService.ObterPorId(id));
        }

        public IEnumerable<PlanoViewModel> BuscarTodosAtivos()
        {
            return Mapper.Map<IEnumerable<PlanoViewModel>>(_planoService.BuscarTodosAtivos());
        }

        public IEnumerable<PlanoViewModel> Filtros(PlanoViewModel objViewModel)
        {
            return Mapper.Map<IEnumerable<PlanoViewModel>>(_planoService.Filtros(Mapper.Map<Plano>(objViewModel)));
        }

        public ICollection<PlanoTelefoniaVOViewModel> FiltrosEspecificos(PlanoTelefoniaVOViewModel objViewModel)
        {
            return Mapper.Map<ICollection<PlanoTelefoniaVOViewModel>>(_planoService.FiltrosEspecificos(Mapper.Map<PlanoTelefoniaVO>(objViewModel)));
        }

        public void Incluir(PlanoViewModel objViewModel)
        {
            var usu = Mapper.Map<Plano>(objViewModel);
            _planoService.Incluir(usu);
        }

        public void Alterar(PlanoViewModel objViewModel)
        {
            _planoService.Alterar(Mapper.Map<Plano>(objViewModel));
        }

        public void Remover(int id)
        {
            _planoService.Remover(id);
        }

        public void Dispose()
        {
            _planoService.Dispose();
        }

        #endregion
    }
}
