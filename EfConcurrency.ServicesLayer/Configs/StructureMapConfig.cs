using System;
using System.Threading;
using EfConcurrency.DataLayer.Context;
using EfConcurrency.ServicesLayer.IServices;
using StructureMap;
using StructureMap.Web;

namespace EfConcurrency.ServicesLayer.Configs
{
    public static class StructureMapConfig
    {
        private static readonly Lazy<Container> ContainerBuilder =
            new Lazy<Container>(DefaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container => ContainerBuilder.Value;

        private static Container DefaultContainer()
        {
            return new Container(cfg =>
            {
                // using HybridHttpOrThreadLocalScoped for both WebApi and WindowsApp
                cfg.For<IUnitOfWork>()
                    .HybridHttpOrThreadLocalScoped()
                    .Use<EfConcurrencyContext>();

                cfg.Scan(scan =>
                {
                    scan.AssemblyContainingType<IApplicationService>();
                    scan.WithDefaultConventions();
                });
            });
        }
    }
}
