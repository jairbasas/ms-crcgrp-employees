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

        public async Task<int> Register(CompanyUsers companyUsers)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();
                    parameters = GetParatamers(companyUsers);

                    var result = await connection.ExecuteAsync(@"TRANSVERSAL.COMPANY_USERS_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    companyUsers.companyUserId = parameters.Get<int>("@poi_company_user_id");

                    return companyUsers.companyUserId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }

        public async Task<int> RegisterAsync(CompanyUsers companyUsers)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await new UsersRepository(_connectionString).RegisterAsync(companyUsers.users, connection, transaction);

                        var parameters = new DynamicParameters();
                        parameters = GetParatamers(companyUsers);

                        var result = await connection.ExecuteAsync(@"TRANSVERSAL.COMPANY_USERS_insert_update", parameters, transaction, commandType: CommandType.StoredProcedure);

                        companyUsers.companyUserId = parameters.Get<int>("@poi_company_user_id");

                        transaction.Commit();
                        return companyUsers.companyUserId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new EmployeesBaseException(ex.Message);
                    }
                }
            }
        }

        #region

        private DynamicParameters GetParatamers(CompanyUsers companyUsers) 
        {
            var parameters = new DynamicParameters();

            parameters.Add("@poi_company_user_id", companyUsers.companyUserId, DbType.Int32, ParameterDirection.InputOutput);
            parameters.Add("@pii_user_id", companyUsers.userId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pii_company_id", companyUsers.companyId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pii_register_user_id", companyUsers.registerUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_register_user_fullname", companyUsers.registerUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_register_datetime", companyUsers.registerDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_update_user_id", companyUsers.updateUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_update_user_fullname", companyUsers.updateUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_update_datetime", companyUsers.updateDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_state", companyUsers.state, DbType.Int32, ParameterDirection.Input);

            return parameters;
        }

        #endregion

    }
}
