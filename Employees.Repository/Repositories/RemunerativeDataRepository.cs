using Dapper;
using Employees.Domain.Aggregates.RemunerativeDataAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class RemunerativeDataRepository : IRemunerativeDataRepository
    {
        readonly string _connectionString = string.Empty;

        public RemunerativeDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(RemunerativeData remunerativeData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", remunerativeData.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_salary_type_id", remunerativeData.salaryTypeId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", remunerativeData.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", remunerativeData.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", remunerativeData.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", remunerativeData.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", remunerativeData.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", remunerativeData.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.REMUNERATIVE_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    remunerativeData.employeeId = parameters.Get<int>("@poi_employee_id");

                    return remunerativeData.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
