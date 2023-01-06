using Dapper;
using Employees.Domain.Aggregates.MainDataAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class MainDataRepository : IMainDataRepository
    {
        readonly string _connectionString = string.Empty;

        public MainDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(MainData mainData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_employee_id", mainData.employeeId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_document_number", mainData.documentNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_birth_date", mainData.birthDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@piv_ubigeo_birth", mainData.ubigeoBirth, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_postal_code", mainData.postalCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_phone_number", mainData.phoneNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_email", mainData.email, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pib_domiciled", mainData.domiciled, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add("@piv_route_type_number", mainData.routeTypeNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_department", mainData.department, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_inside", mainData.inside, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_mz", mainData.mz, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_route_name", mainData.routeName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_lt", mainData.lt, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_km", mainData.km, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_block", mainData.block, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_zone_name", mainData.zoneName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_stage", mainData.stage, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_reference", mainData.reference, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_ubigeo", mainData.ubigeo, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_document_type_id", mainData.documentTypeId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_nationality_id", mainData.nationalityId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_sex_id", mainData.sexId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_civil_status", mainData.civilStatus, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_route_type_id", mainData.routeTypeId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_zone_type_id", mainData.zoneTypeId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_observation", mainData.observation, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", mainData.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", mainData.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", mainData.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", mainData.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", mainData.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", mainData.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"EMPLOYEES.MAIN_DATA_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    mainData.employeeId = parameters.Get<int>("@poi_employee_id");

                    return mainData.employeeId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
