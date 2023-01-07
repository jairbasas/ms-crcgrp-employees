using Employees.Services.Services.Request;
using Employees.Services.Wrappers;

namespace Employees.Services.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<T> GetUserById<T>(int userId);
    }
}
