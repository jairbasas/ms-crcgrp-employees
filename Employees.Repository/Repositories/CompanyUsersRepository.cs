using Dapper;
using Employees.Domain.Aggregates.CompanyUsersAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class CompanyUsersRepository : ICompanyUsersRepository
    {
        readonly string _connectionString = string.Empty;

        public CompanyUsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(CompanyUsers users)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_company_user_id", users.companyUserId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@pii_user_id", users.userId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pii_company_id", users.companyId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", users.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", users.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", users.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", users.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", users.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", users.updateDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_state", users.state, DbType.Int32, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"TRANSVERSAL.COMPANY_USERS_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    users.companyUserId = parameters.Get<int>("@poi_company_user_id");

                    return users.companyUserId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
