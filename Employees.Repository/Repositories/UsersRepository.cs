﻿using Dapper;
using Employees.Domain.Aggregates.UsersAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        readonly string _connectionString = string.Empty;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(Users users)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_user_id", users.userId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_user_name", users.userName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_father_last_name", users.fatherLastName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_mother_last_name", users.motherLastName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_document_number", users.documentNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_email", users.email, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_state", users.state, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", users.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", users.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", users.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", users.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", users.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", users.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"TRANSVERSAL.USERS_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    users.userId = parameters.Get<int>("@poi_user_id");

                    return users.userId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
