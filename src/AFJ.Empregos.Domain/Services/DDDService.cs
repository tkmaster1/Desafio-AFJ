using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using AFJ.Empregos.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Services
{
    public class DDDService : IDDDService
    {
        #region Properties

        private readonly IDDDRepository _dddRepository;

        #endregion

        #region Constructor

        public DDDService(IDDDRepository dddRepository)
        {
            _dddRepository = dddRepository;
        }

        #endregion

        #region Methods

        public DDD ObterPorId(int id)
        {
            return _dddRepository.ObterPorId(id);
        }

        public IEnumerable<DDD> BuscarTodosAtivos()
        {
            return _dddRepository.BuscarTodosAtivos();
        }

        public IEnumerable<DDD> Filtros(DDD obj)
        {
            return _dddRepository.Filtros(obj);
        }

        public void Incluir(DDD obj)
        {
            _dddRepository.Add(obj);
        }

        public void Alterar(DDD obj)
        {
            _dddRepository.Update(obj);
        }

        public void Remover(int id)
        {
            _dddRepository.Remove(id);
        }

        public void Dispose()
        {
            _dddRepository.Dispose();
        }

        #endregion
    }
}
