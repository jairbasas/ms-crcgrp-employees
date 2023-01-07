using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class HealthBenefitsViewModel
    {
        public int employeeId { get; set; }
        public bool? affiliateEps { get; set; }
        public string epsNumber { get; set; }
        public DateTime? registrationDate { get; set; }
        public string familyPlan { get; set; }
        public DateTime? disenrollmentDate { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class HealthBenefitsRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
