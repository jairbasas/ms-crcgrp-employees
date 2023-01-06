using Autofac;
using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Implementations;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Domain.Aggregates.CompanyAggregate;
using Employees.Domain.Aggregates.CompanyUsersAggregate;
using Employees.Domain.Aggregates.CompensationPaymentAggregate;
using Employees.Domain.Aggregates.ContractAggregate;
using Employees.Domain.Aggregates.EmployeeAggregate;
using Employees.Domain.Aggregates.IncomeDiscountAggregate;
using Employees.Domain.Aggregates.LaborDataAggregate;
using Employees.Domain.Aggregates.MainDataAggregate;
using Employees.Domain.Aggregates.ParameterAggregate;
using Employees.Domain.Aggregates.ParameterDetailAggregate;
using Employees.Domain.Aggregates.RemunerativeDataAggregate;
using Employees.Domain.Aggregates.RemunerativePeriodicityAggregate;
using Employees.Domain.Aggregates.SalaryPaymentAggregate;
using Employees.Domain.Aggregates.UsersAggregate;
using Employees.Domain.Aggregates.WorkingPeriodAggregate;
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

            builder.Register(c => new EmployeeMapper())
                           .As<IEmployeeMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new MainDataMapper())
                           .As<IMainDataMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new CompensationPaymentMapper())
                           .As<ICompensationPaymentMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new ContractMapper())
                           .As<IContractMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new IncomeDiscountMapper())
                           .As<IIncomeDiscountMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new LaborDataMapper())
                           .As<ILaborDataMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new RemunerativeDataMapper())
                           .As<IRemunerativeDataMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new RemunerativePeriodicityMapper())
                           .As<IRemunerativePeriodicityMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new SalaryPaymentMapper())
                           .As<ISalaryPaymentMapper>()
                           .InstancePerLifetimeScope();

            builder.Register(c => new WorkingPeriodMapper())
                           .As<IWorkingPeriodMapper>()
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

            builder.RegisterType<EmployeeQuery>()
                           .As<IEmployeeQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<MainDataQuery>()
                           .As<IMainDataQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<CompensationPaymentQuery>()
                           .As<ICompensationPaymentQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<ContractQuery>()
                           .As<IContractQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<IncomeDiscountQuery>()
                           .As<IIncomeDiscountQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<LaborDataQuery>()
                           .As<ILaborDataQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<RemunerativeDataQuery>()
                           .As<IRemunerativeDataQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<RemunerativePeriodicityQuery>()
                           .As<IRemunerativePeriodicityQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<SalaryPaymentQuery>()
                           .As<ISalaryPaymentQuery>()
                           .InstancePerLifetimeScope();

            builder.RegisterType<WorkingPeriodQuery>()
                           .As<IWorkingPeriodQuery>()
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

            builder.Register(c => new EmployeeRepository(_defaultConnection))
               .As<IEmployeeRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new MainDataRepository(_defaultConnection))
               .As<IMainDataRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new CompensationPaymentRepository(_defaultConnection))
               .As<ICompensationPaymentRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new ContractRepository(_defaultConnection))
               .As<IContractRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new IncomeDiscountRepository(_defaultConnection))
               .As<IIncomeDiscountRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new LaborDataRepository(_defaultConnection))
               .As<ILaborDataRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new RemunerativeDataRepository(_defaultConnection))
               .As<IRemunerativeDataRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new RemunerativePeriodicityRepository(_defaultConnection))
               .As<IRemunerativePeriodicityRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new SalaryPaymentRepository(_defaultConnection))
               .As<ISalaryPaymentRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new WorkingPeriodRepository(_defaultConnection))
               .As<IWorkingPeriodRepository>()
               .InstancePerLifetimeScope();

            #endregion

        }
    }
}
