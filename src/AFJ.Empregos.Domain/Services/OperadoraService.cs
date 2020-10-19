using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.Interfaces.Repository;
using AFJ.Empregos.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace AFJ.Empregos.Domain.Services
{
    public class OperadoraService : IOperadoraService
    {
        #region Properties

        private readonly IOperadoraRepository _operadoraRepository;

        #endregion

        #region Constructor

        public OperadoraService(IOperadoraRepository operadoraRepository)
        {
            _operadoraRepository = operadoraRepository;
        }

        #endregion

        #region Methods

        public Operadora ObterPorId(int id)
        {
            return _operadoraRepository.ObterPorId(id);
        }

        public IEnumerable<Operadora> BuscarTodosAtivos()
        {
            return _operadoraRepository.BuscarTodosAtivos();
        }

        public IEnumerable<Operadora> Filtros(Operadora obj)
        {
            return _operadoraRepository.Filtros(obj);
        }

        public void Incluir(Operadora obj)
        {
            _operadoraRepository.Add(obj);
        }

        public void Alterar(Operadora obj)
        {
            _operadoraRepository.Update(obj);
        }

        public void Remover(int id)
        {
            _operadoraRepository.Remove(id);
        }

        public void Dispose()
        {
            _operadoraRepository.Dispose();
        }

        #endregion
    }
}
