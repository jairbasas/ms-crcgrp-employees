
namespace Employees.Domain.Aggregates.ContractAggregate
{
    public interface IContractRepository
    {
        Task<int> Register(Contracts contract);
    }
}
