
namespace Employees.Domain.Aggregates.SunatRemunerationDataAggregate
{
    public interface ISunatRemunerationDataRepository
    {
        Task<int> Register(SunatRemunerationData sunatRemunerationData);
    }
}
