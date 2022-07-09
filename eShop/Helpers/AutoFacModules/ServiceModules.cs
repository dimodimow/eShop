using Autofac;
using eShop.Services;
using eShop.Services.Interfaces;

namespace eShop.Helpers.AutoFacModules
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Scoped
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                 .InstancePerLifetimeScope();
        }
    }
}