using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.Services;
using AFJ.Empregos.Data.Context;
using AFJ.Empregos.Data.Repository;
using AFJ.Empregos.Domain.Interfaces.Repository;
using AFJ.Empregos.Domain.Interfaces.Service;
using AFJ.Empregos.Domain.Services;
using SimpleInjector;

namespace AFJ.Empregos.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instância para cada solicitação
            // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
            // Lifestyle.Scoped => Uma instância única para o request

            // Application
            container.Register<IDDDAppService, DDDAppService>(Lifestyle.Scoped);
            container.Register<IOperadoraAppService, OperadoraAppService>(Lifestyle.Scoped);
            container.Register<IPlanoAppService, PlanoAppService>(Lifestyle.Scoped);
            container.Register<ITipoPlanoAppService, TipoPlanoAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IDDDService, DDDService>(Lifestyle.Scoped);
            container.Register<IOperadoraService, OperadoraService>(Lifestyle.Scoped);
            container.Register<IPlanoService, PlanoService>(Lifestyle.Scoped);
            container.Register<ITipoPlanoService, TipoPlanoService>(Lifestyle.Scoped);

            // InfraData
            container.Register<AFJEmpregosDDDContext>(Lifestyle.Scoped);
            container.Register<IDDDRepository, DDDRepository>(Lifestyle.Scoped);
            container.Register<IOperadoraRepository, OperadoraRepository>(Lifestyle.Scoped);
            container.Register<IPlanoRepository, PlanoRepository>(Lifestyle.Scoped);
            container.Register<ITipoPlanoRepository, TipoPlanoRepository>(Lifestyle.Scoped);
        }
    }
}
