using Dapper;
using Employees.Domain.Aggregates.RemunerativePeriodicityAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class RemunerativePeriodicityRepository : IRemunerativePeriodicityRepository
    {
        readonly string _connectionString = string.Empty;

        public RemunerativePeriodicityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(RemunerativePeriodicity remunerativePeriodicity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters = GetParameters(remunerativePeriodicity);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.REMUNERATIVE_PERIODICITY_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    remunerativePeriodicity.employeeId = parameters.Get<int>("@poi_employee_id");

                    return remunerativePeriodicity.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }

        public async Task<int> RegisterAsync(RemunerativePeriodicity remunerativePeriodicity, SqlConnection connection, SqlTransaction transaction) 
        {
            var parameters = new DynamicParameters();

            parameters = GetParameters(remunerativePeriodicity);

            return await connection.ExecuteAsync(@"EMPLOYEES.REMUNERATIVE_PERIODICITY_insert_update", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

        #region Methods

        private DynamicParameters GetParameters(RemunerativePeriodicity remunerativePeriodicity) 
        {
            var parameters = new DynamicParameters();

            parameters.Add("@poi_employee_id", remunerativePeriodicity.employeeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_periodicity_id", remunerativePeriodicity.periodicityId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_payment_type_id", remunerativePeriodicity.paymentTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pii_register_user_id", remunerativePeriodicity.registerUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_register_user_fullname", remunerativePeriodicity.registerUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_register_datetime", remunerativePeriodicity.registerDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_update_user_id", remunerativePeriodicity.updateUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_update_user_fullname", remunerativePeriodicity.updateUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_update_datetime", remunerativePeriodicity.updateDatetime, DbType.DateTime, ParameterDirection.Input);

            return parameters;
        }

        #endregion

    }
}
