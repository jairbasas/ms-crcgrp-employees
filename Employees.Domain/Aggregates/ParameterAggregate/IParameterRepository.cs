
namespace Employees.Domain.Aggregates.ParameterAggregate
{
    public interface IParameterRepository
    {
        Task<int> Register(Parameter parameter);
    }
}
