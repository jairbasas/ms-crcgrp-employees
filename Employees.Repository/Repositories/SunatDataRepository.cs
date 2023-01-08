using Dapper;
using Employees.Domain.Aggregates.SunatDataAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class SunatDataRepository : ISunatDataRepository
    {
        readonly string _connectionString = string.Empty;

        public SunatDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(SunatData sunatData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters = GetParameters(sunatData);
                    var result = await connection.ExecuteAsync(@"EMPLOYEES.SUNAT_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    sunatData.employeeId = parameters.Get<int>("@poi_employee_id");

                    return sunatData.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }

        public async Task<int> RegisterAsync(SunatData sunatData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();

                        parameters = GetParameters(sunatData);
                        var result = await connection.ExecuteAsync(@"EMPLOYEES.SUNAT_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                        sunatData.employeeId = parameters.Get<int>("@poi_employee_id");

                        if (sunatData.laborTaxData != null)
                            await new LaborTaxDataRepository(_connectionString).RegisterAsyncJson(sunatData.laborTaxData, connection, transaction);

                        if(sunatData.sunatRemunerationData != null)
                            await new SunatRemunerationDataRepository(_connectionString).RegisterAsyncJson(sunatData.sunatRemunerationData, connection, transaction);

                        if (sunatData.sctr != null)
                            await new SctrRepository(_connectionString).RegisterAsyncJson(sunatData.sctr, connection, transaction);

                        if (sunatData.healthBenefits != null)
                            await new HealthBenefitsRepository(_connectionString).RegisterAsync(sunatData.healthBenefits, connection, transaction);

                        transaction.Commit();
                        return sunatData.employeeId;
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

        private DynamicParameters GetParameters(SunatData sunatData) 
        {
            var parameters = new DynamicParameters();

            parameters.Add("@poi_employee_id", sunatData.employeeId, DbType.Int32, ParameterDirection.InputOutput);
            parameters.Add("@piv_essalud_code", sunatData.essaludCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@pib_mixed_commission", sunatData.mixedCommission, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@pid_registration_date", sunatData.registrationDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@piv_pension_type_id", sunatData.pensionTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_pension_scheme_id", sunatData.pensionSchemeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_worker_situation_id", sunatData.workerSituationId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_occupational_category_id", sunatData.occupationalCategoryId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_affiliate_type_id", sunatData.affiliateTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_double_taxation_id", sunatData.doubleTaxationId, DbType.String, ParameterDirection.Input);
            parameters.Add("@piv_afp_exoneration_type_id", sunatData.afpExonerationTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("@pii_register_user_id", sunatData.registerUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_register_user_fullname", sunatData.registerUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_register_datetime", sunatData.registerDatetime, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@pii_update_user_id", sunatData.updateUserId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@piv_update_user_fullname", sunatData.updateUserFullname, DbType.String, ParameterDirection.Input);
            parameters.Add("@pid_update_datetime", sunatData.updateDatetime, DbType.DateTime, ParameterDirection.Input);

            return parameters;
        }

        #endregion

    }
}
