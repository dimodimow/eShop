using Autofac;
using eShop.Services.Interfaces;
using eShop.Services.Mappers;

namespace eShop.Helpers.AutoFacModules
{
    public class MapperModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryMapper>()
                .As<ICategoryMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
