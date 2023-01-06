using Dapper;
using Employees.Domain.Aggregates.IncomeDiscountAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class IncomeDiscountRepository : IIncomeDiscountRepository
    {
        readonly string _connectionString = string.Empty;

        public IncomeDiscountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(IncomeDiscount incomeDiscount)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", incomeDiscount.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_code", incomeDiscount.code, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_description", incomeDiscount.description, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_currency_id", incomeDiscount.currencyId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_amount", incomeDiscount.amount, DbType.Decimal, ParameterDirection.Input);
                    parameters.Add("@pib_state", incomeDiscount.state, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", incomeDiscount.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", incomeDiscount.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", incomeDiscount.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", incomeDiscount.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", incomeDiscount.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", incomeDiscount.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.INCOME_DISCOUNT_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    incomeDiscount.employeeId = parameters.Get<int>("@poi_employee_id");

                    return incomeDiscount.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
