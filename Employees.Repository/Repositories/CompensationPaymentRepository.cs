using Dapper;
using Employees.Domain.Aggregates.CompensationPaymentAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class CompensationPaymentRepository : ICompensationPaymentRepository
    {
        readonly string _connectionString = string.Empty;

        public CompensationPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(CompensationPayment compensationPayment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters = GetParameters(compensationPayment);
                    var result = await connection.ExecuteAsync(@"EMPLOYEES.COMPENSATION_PAYMENT_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    compensationPayment.employeeId = parameters.Get<int>("@poi_employee_id");

                    return compensationPayment.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }

        public async Task<int> RegisterAsync(CompensationPayment compensationPayment, SqlConnection connection, SqlTransaction transaction) 
        {
            var parameters = new DynamicParameters();

            parameters = GetParameters(compensationPayment);
            return await connection.ExecuteAsync(@"EMPLOYEES.COMPENSATION_PAYMENT_insert_update", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

        #region Methods

        private DynamicParameters GetParameters(CompensationPayment compensationPayment) 
        {
            var parameters = new DynamicParameters();

            parameters.Add("@poi_employee_id", compensationPayment.employeeId, DbType.Int32, ParameterDirection.InputOutput);
            parameters.Add("@piv_account_number", compensationPayment.accountNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_interbank_account", compensationPayment.interbankAccount, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_bank_id", compensationPayment.bankId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_account_type_id", compensationPayment.accountTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_currency_id", compensationPayment.currencyId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pii_register_user_id", compensationPayment.registerUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_register_user_fullname", compensationPayment.registerUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_register_datetime", compensationPayment.registerDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_update_user_id", compensationPayment.updateUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_update_user_fullname", compensationPayment.updateUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_update_datetime", compensationPayment.updateDatetime, DbType.DateTime, ParameterDirection.Input);

            return parameters;
        }

        #endregion

    }
}
