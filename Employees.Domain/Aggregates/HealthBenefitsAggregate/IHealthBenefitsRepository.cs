
namespace Employees.Domain.Aggregates.HealthBenefitsAggregate
{
    public interface IHealthBenefitsRepository
    {
        Task<int> Register(HealthBenefits healthBenefits);
    }
}
