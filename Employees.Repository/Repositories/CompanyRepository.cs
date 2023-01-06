using Dapper;
using Employees.Domain.Aggregates.CompanyAggregate;
using Employees.Domain.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace Employees.Repository.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly string _connectionString = string.Empty;

        public CompanyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Register(Company company)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                try
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@poi_company_id", company.companyId, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add("@piv_business_name", company.businessName, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_tradename", company.tradename, DbType.String, ParameterDirection.Input);
                    parameters.Add("@piv_document_number", company.documentNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pii_state", company.state, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@pii_register_user_id", company.registerUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_register_user_fullname", company.registerUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_register_datetime", company.registerDatetime, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add("@pii_update_user_id", company.updateUserId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@piv_update_user_fullname", company.updateUserFullname, DbType.String, ParameterDirection.Input);
                    parameters.Add("@pid_update_datetime", company.updateDatetime, DbType.DateTime, ParameterDirection.Input);

                    var result = await connection.ExecuteAsync(@"TRANSVERSAL.COMPANY_insert_update", parameters, commandType: CommandType.StoredProcedure);

                    company.companyId = parameters.Get<int>("@poi_company_id");

                    return company.companyId;
                }
                catch (Exception ex)
                {
                    throw new EmployeesBaseException(ex.Message);
                }
            }
        }
    }
}
