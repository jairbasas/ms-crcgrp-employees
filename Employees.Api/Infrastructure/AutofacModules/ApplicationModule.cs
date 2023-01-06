using Autofac;
using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Implementations;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Domain.Aggregates.CompanyAggregate;
using Employees.Domain.Aggregates.CompanyUsersAggregate;
using Employees.Domain.Aggregates.ParameterAggregate;
using Employees.Domain.Aggregates.ParameterDetailAggregate;
using Employees.Domain.Aggregates.UsersAggregate;
using Employees.Repository.Repositories;

namespace Employees.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        private readonly string _defaultConnection;
        private readonly string _timeZone;

        public ApplicationModule(string defaultConnection, string timeZone)
        {
            this._defaultConnection = defaultConnection ?? throw new ArgumentNullException(nameof(defaultConnection));
            this._timeZone = timeZone ?? throw new ArgumentNullException(nameof(timeZone));
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(r => new GenericQuery(_defaultConnection))
                            .As<IGenericQuery>()
                            .InstancePerLifetimeScope();

            #region ValuesSettings
            builder.Register(r => new ValuesSettings(_timeZone))
                .As<IValuesSettings>()
                .InstancePerLifetimeScope();
            #endregion

            #region Mapper

            builder.Register(c => new CompanyMapper())
                           .As<ICompanyMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new CompanyUsersMapper())
                           .As<ICompanyUsersMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new UsersMapper())
                           .As<IUsersMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new ParameterMapper())
                           .As<IParameterMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new ParameterDetailMapper())
                           .As<IParameterDetailMapper>()
                           .InstancePerLifetimeScope();

            #endregion

            #region Query

            builder.RegisterType<CompanyQuery>()
                           .As<ICompanyQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<CompanyUsersQuery>()
                           .As<ICompanyUsersQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<UsersQuery>()
                           .As<IUsersQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<ParameterQuery>()
                           .As<IParameterQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<ParameterDetailQuery>()
                           .As<IParameterDetailQuery>()
                           .InstancePerLifetimeScope();

            #endregion

            #region Services


            #endregion

            #region Repository

            builder.Register(c => new CompanyRepository(_defaultConnection))
               .As<ICompanyRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new CompanyUsersRepository(_defaultConnection))
               .As<ICompanyUsersRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new UsersRepository(_defaultConnection))
               .As<IUsersRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new ParameterRepository(_defaultConnection))
               .As<IParameterRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new ParameterDetailRepository(_defaultConnection))
               .As<IParameterDetailRepository>()
               .InstancePerLifetimeScope();

            #endregion

        }
    }
}
