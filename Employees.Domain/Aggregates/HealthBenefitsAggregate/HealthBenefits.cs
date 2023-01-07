using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.HealthBenefitsAggregate
{
    public class HealthBenefits : Audit
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

        public HealthBenefits()
        {
        }

        public HealthBenefits(int employeeId, bool? affiliateEps, string epsNumber, DateTime? registrationDate, string familyPlan, DateTime? disenrollmentDate, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.affiliateEps = affiliateEps;
            this.epsNumber = epsNumber;
            this.registrationDate = registrationDate;
            this.familyPlan = familyPlan;
            this.disenrollmentDate = disenrollmentDate;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
