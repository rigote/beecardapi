using BeeCard.Application.Interfaces;
using BeeCard.Application.Services;
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

            For<ICompanyAppService>().Use<CompanyAppService>();
            For<ICompanyService>().Use<CompanyService>();
            For<ICompanyRepository>().Use<CompanyRepository>();

            For<ICompanyGroupService>().Use<CompanyGroupService>();
            For<ICompanyGroupRepository>().Use<CompanyGroupRepository>();

            For<ICompanyTypeAppService>().Use<CompanyTypeAppService>();
            For<ICompanyTypeService>().Use<CompanyTypeService>();
            For<ICompanyTypeRepository>().Use<CompanyTypeRepository>();

            For<ICorporateCardService>().Use<CorporateCardService>();
            For<ICorporateCardRepository>().Use<CorporateCardRepository>();

            For<ICountryAppService>().Use<CountryAppService>();
            For<ICountryService>().Use<CountryService>();
            For<ICountryRepository>().Use<CountryRepository>();

            For<ILeadService>().Use<LeadService>();
            For<ILeadRepository>().Use<LeadRepository>();

            For<IPersonalCardService>().Use<PersonalCardService>();
            For<IPersonalCardRepository>().Use<PersonalCardRepository>();

            For<IPlanService>().Use<PlanService>();
            For<IPlanRepository>().Use<PlanRepository>();

            For<ISubscriptionHistoryService>().Use<SubscriptionHistoryService>();
            For<ISubscriptionHistoryRepository>().Use<SubscriptionHistoryRepository>();

            For<IUserAppService>().Use<UserAppService>();
            For<IUserService>().Use<UserService>();
            For<IUserRepository>().Use<UserRepository>();

            For<IUserGroupService>().Use<UserGroupService>();
            For<IUserGroupRepository>().Use<UserGroupRepository>();

            For<IIdentityService>().Use<IdentityService>();
            For<IIdentityDataAccess>().Use<IdentityDataAccess>();

            For<ICardAppService>().Use<CardAppService>();
        }
    }
}
