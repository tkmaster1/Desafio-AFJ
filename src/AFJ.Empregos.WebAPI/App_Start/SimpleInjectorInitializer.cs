[assembly: WebActivator.PostApplicationStartMethod(typeof(AFJ.Empregos.WebAPI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace AFJ.Empregos.WebAPI.App_Start
{
    using AFJ.Empregos.Infra.CrossCutting.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using System.Web.Http;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }
    }
}