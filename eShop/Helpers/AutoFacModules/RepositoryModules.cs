using Autofac;
using eShop.Repositories;
using eShop.Repositories.Base;
using eShop.Repositories.Interfaces;
using eShop.Repositories.UnitOfWork;

namespace eShop.Helpers.AutoFacModules
{
    public class RepositoryModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
