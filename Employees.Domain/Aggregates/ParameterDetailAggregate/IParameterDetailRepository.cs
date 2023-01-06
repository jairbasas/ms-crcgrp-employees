
namespace Employees.Domain.Aggregates.ParameterDetailAggregate
{
    public interface IParameterDetailRepository
    {
        Task<int> Register(ParameterDetail parameterDetail);
    }
}
