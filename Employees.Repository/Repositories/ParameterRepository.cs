using Dapper;
using Employees.Domain.Aggregates.ParameterAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class ParameterRepository : IParameterRepository
    {
        readonly string _connectionString = string.Empty;

        public ParameterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(Parameter parameter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_parameter_id", parameter.parameterId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_parameter_name", parameter.parameterName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_state", parameter.state, DbType.Int32, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"TRANSVERSAL.PARAMETER_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    parameter.parameterId = parameters.Get<int>("@poi_parameter_id");

                    return parameter.parameterId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
