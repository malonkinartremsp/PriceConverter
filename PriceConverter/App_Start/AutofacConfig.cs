using Autofac;
using Autofac.Integration.Mvc;
using PriceConverter.ModelProvider;
using System.Web.Mvc;

namespace PriceConverter
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<PriceModelProvider>().As<IPriceModelProvider>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}