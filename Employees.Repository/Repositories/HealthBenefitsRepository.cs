using Dapper;
using Employees.Domain.Aggregates.HealthBenefitsAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class HealthBenefitsRepository : IHealthBenefitsRepository
    {
        readonly string _connectionString = string.Empty;

        public HealthBenefitsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(HealthBenefits healthBenefits)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", healthBenefits.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pib_affiliate_eps", healthBenefits.affiliateEps, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("@piv_eps_number", healthBenefits.epsNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_registration_date", healthBenefits.registrationDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@piv_family_plan", healthBenefits.familyPlan, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_disenrollment_date", healthBenefits.disenrollmentDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", healthBenefits.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", healthBenefits.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", healthBenefits.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", healthBenefits.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", healthBenefits.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", healthBenefits.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.HEALTH_BENEFITS_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    healthBenefits.employeeId = parameters.Get<int>("@poi_employee_id");

                    return healthBenefits.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
