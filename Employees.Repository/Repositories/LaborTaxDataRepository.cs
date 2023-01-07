using Dapper;
using Employees.Domain.Aggregates.LaborTaxDataAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class LaborTaxDataRepository : ILaborTaxDataRepository
    {
        readonly string _connectionString = string.Empty;

        public LaborTaxDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(LaborTaxData laborTaxData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", laborTaxData.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pii_parameter_detail_id", laborTaxData.parameterDetailId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pib_state", laborTaxData.state, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", laborTaxData.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", laborTaxData.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", laborTaxData.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", laborTaxData.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", laborTaxData.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", laborTaxData.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.LABOR_TAX_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    laborTaxData.employeeId = parameters.Get<int>("@poi_employee_id");

                    return laborTaxData.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
