using BeeCard.Domain.Interfaces.Repositories;
using BeeCard.Domain.Interfaces.Services;
using BeeCard.Domain.Services;
using BeeCard.Infrastructure;
using BeeCard.Infrastructure.Repositories;
using StructureMap.Configuration.DSL;

namespace BeeCard.Utils.DependencyInjection.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<Context>().Use<Context>();

            For(typeof(IBaseService<>)).Use(typeof(BaseService<>));
            For(typeof(IBaseRepository<>)).Use(typeof(BaseRepository<>));

            For<ICompanyService>().Use<CompanyService>();
            For<ICompanyRepository>().Use<CompanyRepository>();
        }
    }
}
