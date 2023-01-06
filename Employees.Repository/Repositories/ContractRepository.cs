using Dapper;
using Employees.Domain.Aggregates.ContractAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class ContractRepository : IContractRepository
    {
        readonly string _connectionString = string.Empty;

        public ContractRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(Contract contract)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", contract.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pid_start_date", contract.startDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pid_end_date", contract.endDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@piv_contract_type_id", contract.contractTypeId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", contract.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", contract.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", contract.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", contract.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", contract.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", contract.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.CONTRACT_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    contract.employeeId = parameters.Get<int>("@poi_employee_id");

                    return contract.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
