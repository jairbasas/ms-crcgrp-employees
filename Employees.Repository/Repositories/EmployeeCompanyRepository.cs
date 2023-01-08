using Dapper;
using Employees.Domain.Aggregates.EmployeeCompanyAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class EmployeeCompanyRepository : IEmployeeCompanyRepository
    {
        readonly string _connectionString = string.Empty;

        public EmployeeCompanyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(EmployeeCompany employeeCompany)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", employeeCompany.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pii_company_id", employeeCompany.companyId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pii_state", employeeCompany.state, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", employeeCompany.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", employeeCompany.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", employeeCompany.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", employeeCompany.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", employeeCompany.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", employeeCompany.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.EMPLOYEE_COMPANY_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    employeeCompany.employeeId = parameters.Get<int>("@poi_employee_id");

                    return employeeCompany.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
