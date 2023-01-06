using Dapper;
using Employees.Domain.Aggregates.SalaryPaymentAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class SalaryPaymentRepository : ISalaryPaymentRepository
    {
        readonly string _connectionString = string.Empty;

        public SalaryPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(SalaryPayment salaryPayment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", salaryPayment.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_account_number", salaryPayment.accountNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_interbank_account", salaryPayment.interbankAccount, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_bank_id", salaryPayment.bankId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_account_type_id", salaryPayment.accountTypeId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_currency_id", salaryPayment.currencyId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", salaryPayment.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", salaryPayment.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", salaryPayment.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", salaryPayment.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", salaryPayment.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", salaryPayment.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.SALARY_PAYMENT_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    salaryPayment.employeeId = parameters.Get<int>("@poi_employee_id");

                    return salaryPayment.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
