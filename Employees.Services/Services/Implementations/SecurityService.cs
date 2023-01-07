using Employees.Services.Helper;
using Employees.Services.Services.Interfaces;
using Employees.Services.Wrappers;
using static Employees.Services.Utility.Constants;

namespace Employees.Services.Services.Implementations
{
    public class SecurityService : BaseService, ISecurityService
    {
        public SecurityService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<T> GetUserById<T>(int userId)
        {
            var url = string.Format(EndpointSecurity.GetUserById, userId);
            return await CallServiceList<T>(url);
        }
    }
}
