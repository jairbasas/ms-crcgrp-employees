using Dapper;
using Employees.Domain.Aggregates.LaborDataAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class LaborDataRepository : ILaborDataRepository
    {
        readonly string _connectionString = string.Empty;

        public LaborDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(LaborData laborData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters = GetParameters(laborData);
                    var result = await connection.ExecuteAsync(@"EMPLOYEES.LABOR_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    laborData.employeeId = parameters.Get<int>("@poi_employee_id");

                    return laborData.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
        public async Task<int> RegisterAsync(LaborData laborData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();

                        parameters = GetParameters(laborData);

                        await connection.ExecuteAsync(@"EMPLOYEES.LABOR_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);
                        laborData.employeeId = parameters.Get<int>("@poi_employee_id");

                        if (laborData.contracts != null)
                        {
                            laborData.contracts.employeeId = laborData.employeeId;
                            await new ContractRepository(_connectionString).RegisterAsync(laborData.contracts, connection, transaction);
                        }

                        if (laborData.workingPeriod != null)
                        {
                            laborData.workingPeriod.employeeId = laborData.employeeId;
                            await new WorkingPeriodRepository(_connectionString).RegisterAsync(laborData.workingPeriod, connection, transaction);
                        }

                        transaction.Commit();
                        return laborData.employeeId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new EmployeesBaseException(ex.Message);
                    }
                }
            }
        }

        #region Methods

        private DynamicParameters GetParameters(LaborData laborData) 
        {
            var parameters = new DynamicParameters();

            parameters.Add("@poi_employee_id", laborData.employeeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pid_salary_advance", laborData.salaryAdvance, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@piv_reference", laborData.reference, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_test_end_date", laborData.testEndDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@piv_employee_type_id", laborData.employeeTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_educational_situation_id", laborData.educationalSituationId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_occupation_id", laborData.occupationId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_position_id", laborData.positionId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_cost_center_id", laborData.costCenterId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_special_situation_id", laborData.specialSituationId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_labor_regime_id", laborData.laborRegimeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_essalud_vida_id", laborData.essaludVidaId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_service_unit_id", laborData.serviceUnitId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_area_seccion_id", laborData.areaSeccionId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_trust_position_id", laborData.trustPositionId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_account_category_id", laborData.accountCategoryId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_work_type_id", laborData.workTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pii_register_user_id", laborData.registerUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_register_user_fullname", laborData.registerUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_register_datetime", laborData.registerDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_update_user_id", laborData.updateUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_update_user_fullname", laborData.updateUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_update_datetime", laborData.updateDatetime, DbType.DateTime, ParameterDirection.Input);

            return parameters;
        }

        #endregion

    }
}
