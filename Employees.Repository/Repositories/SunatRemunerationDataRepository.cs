using Dapper;
using Employees.Domain.Aggregates.SunatRemunerationDataAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class SunatRemunerationDataRepository : ISunatRemunerationDataRepository
    {
        readonly string _connectionString = string.Empty;

        public SunatRemunerationDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(SunatRemunerationData sunatRemunerationData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", sunatRemunerationData.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pii_parameter_detail_id", sunatRemunerationData.parameterDetailId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pib_state", sunatRemunerationData.state, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", sunatRemunerationData.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", sunatRemunerationData.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", sunatRemunerationData.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", sunatRemunerationData.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", sunatRemunerationData.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", sunatRemunerationData.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.SUNAT_REMUNERATION_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    sunatRemunerationData.employeeId = parameters.Get<int>("@poi_employee_id");

                    return sunatRemunerationData.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
