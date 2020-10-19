using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using AFJ.Empregos.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Services
{
    public class TipoPlanoService : ITipoPlanoService
    {
        #region Properties

        private readonly ITipoPlanoRepository _tipoPlanoRepository;

        #endregion

        #region Constructor

        public TipoPlanoService(ITipoPlanoRepository tipoPlanoRepository)
        {
            _tipoPlanoRepository = tipoPlanoRepository;
        }

        #endregion

        #region Methods

        public TipoPlano ObterPorId(int id)
        {
            return _tipoPlanoRepository.ObterPorId(id);
        }

        public IEnumerable<TipoPlano> BuscarTodosAtivos()
        {
            return _tipoPlanoRepository.BuscarTodosAtivos();
        }

        public IEnumerable<TipoPlano> Filtros(TipoPlano obj)
        {
            return _tipoPlanoRepository.Filtros(obj);
        }

        public void Incluir(TipoPlano obj)
        {
            _tipoPlanoRepository.Add(obj);
        }

        public void Alterar(TipoPlano obj)
        {
            _tipoPlanoRepository.Update(obj);
        }

        public void Remover(int id)
        {
            _tipoPlanoRepository.Remove(id);
        }

        public void Dispose()
        {
            _tipoPlanoRepository.Dispose();
        }

        #endregion
    }
}
