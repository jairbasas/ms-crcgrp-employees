using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.EmployeeAggregate
{
    public class Employee : Audit
    {
        public int employeeId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string categoryName { get; set; }
        public string situationId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerUpdate { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }

        public Employee()
        {
        }

        public Employee(int employeeId, string code, string name, string fatherLastName, string motherLastName, string categoryName, string situationId, int? registerUserId, string registerUserFullname, DateTime? registerUpdate, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.code = code;
            this.name = name;
            this.fatherLastName = fatherLastName;
            this.motherLastName = motherLastName;
            this.categoryName = categoryName;
            this.situationId = situationId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerUpdate = registerUpdate;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
