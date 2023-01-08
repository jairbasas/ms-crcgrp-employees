using Dapper;
using Employees.Domain.Aggregates.WorkingPeriodAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class WorkingPeriodRepository : IWorkingPeriodRepository
    {
        readonly string _connectionString = string.Empty;

        public WorkingPeriodRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(WorkingPeriod workingPeriod)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters = GetParameters(workingPeriod);
                    var result = await connection.ExecuteAsync(@"EMPLOYEES.WORKING_PERIOD_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    workingPeriod.employeeId = parameters.Get<int>("@poi_employee_id");

                    return workingPeriod.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }

        public async Task<int> RegisterAsync(WorkingPeriod workingPeriod, SqlConnection connection, SqlTransaction transaction) 
        {
            var parameters = new DynamicParameters();
            parameters = GetParameters(workingPeriod);
            return await connection.ExecuteAsync(@"EMPLOYEES.WORKING_PERIOD_insert_update", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

        #region Methods

        private DynamicParameters GetParameters(WorkingPeriod workingPeriod) 
        {
            var parameters = new DynamicParameters();

            parameters.Add("@poi_employee_id", workingPeriod.employeeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pid_date_admission", workingPeriod.dateAdmission, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pid_hour_day", workingPeriod.hourDay, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@piv_shift_id", workingPeriod.shiftId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pii_tareo_diario", workingPeriod.tareoDiario, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pii_extra_hour_tareo", workingPeriod.extraHourTareo, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_tareo_group_id", workingPeriod.tareoGroupId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_termination_date", workingPeriod.terminationDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@piv_reason_termination_id", workingPeriod.reasonTerminationId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pii_register_user_id", workingPeriod.registerUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_register_user_fullname", workingPeriod.registerUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_register_datetime", workingPeriod.registerDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_update_user_id", workingPeriod.updateUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_update_user_fullname", workingPeriod.updateUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_update_datetime", workingPeriod.updateDatetime, DbType.DateTime, ParameterDirection.Input);

            return parameters;
        }

        #endregion

    }
}
