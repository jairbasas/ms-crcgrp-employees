using Dapper;
using Employees.Domain.Aggregates.SctrAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Employees.Repository.Repositories
{
    public class SctrRepository : ISctrRepository
    {
        readonly string _connectionString = string.Empty;

        public SctrRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(Sctr sctr)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", sctr.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pii_parameter_detail_id", sctr.parameterDetailId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_sctr_code", sctr.sctrCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_tasa", sctr.tasa, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", sctr.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", sctr.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", sctr.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", sctr.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", sctr.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", sctr.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.SCTR_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    sctr.employeeId = parameters.Get<int>("@poi_employee_id");

                    return sctr.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }

        public async Task<int> RegisterAsyncJson(IEnumerable<Sctr> sctr, SqlConnection connection, SqlTransaction transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonData", JsonConvert.SerializeObject(sctr, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" }), DbType.String);

            return await connection.ExecuteAsync("@EMPLOYEES.SCTR_insert_update_json", parameters, transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
