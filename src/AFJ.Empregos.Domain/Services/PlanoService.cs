using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using AFJ.Empregos.Domain.Interfaces.Service;
using AFJ.Empregos.Domain.ValueObjects;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Services
{
    public class PlanoService : IPlanoService
    {
        #region Properties

        private readonly IPlanoRepository _planoRepository;

        #endregion

        #region Constructor

        public PlanoService(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        #endregion

        #region Methods

        public Plano ObterPorId(int id)
        {
            return _planoRepository.ObterPorId(id);
        }

        public IEnumerable<Plano> BuscarTodosAtivos()
        {
            return _planoRepository.BuscarTodosAtivos();
        }

        public IEnumerable<Plano> Filtros(Plano obj)
        {
            return _planoRepository.Filtros(obj);
        }

        public ICollection<PlanoTelefoniaVO> FiltrosEspecificos(PlanoTelefoniaVO objModel)
        {
            return _planoRepository.FiltrosEspecificos(objModel);
        }

        public void Incluir(Plano obj)
        {
            _planoRepository.Add(obj);
        }

        public void Alterar(Plano obj)
        {
            _planoRepository.Update(obj);
        }

        public void Remover(int id)
        {
            _planoRepository.Remove(id);
        }

        public void Dispose()
        {
            _planoRepository.Dispose();
        }

        #endregion
    }
}
