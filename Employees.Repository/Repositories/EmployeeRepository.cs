using Dapper;
using Employees.Domain.Aggregates.EmployeeAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly string _connectionString = string.Empty;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", employee.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_code", employee.code, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_name", employee.name, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_father_last_name", employee.fatherLastName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_mother_last_name", employee.motherLastName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_category_name", employee.categoryName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_situation_id", employee.situationId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", employee.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", employee.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_update", employee.registerUpdate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", employee.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", employee.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", employee.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.EMPLOYEE_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    employee.employeeId = parameters.Get<int>("@poi_employee_id");

                    return employee.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
