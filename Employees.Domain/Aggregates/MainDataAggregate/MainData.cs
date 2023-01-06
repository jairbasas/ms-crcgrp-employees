using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.MainDataAggregate
{
    public class MainData : Audit
    {
        public int employeeId { get; set; }
        public string documentNumber { get; set; }
        public DateTime? birthDate { get; set; }
        public string ubigeoBirth { get; set; }
        public string postalCode { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public bool? domiciled { get; set; }
        public string routeTypeNumber { get; set; }
        public string department { get; set; }
        public string inside { get; set; }
        public string mz { get; set; }
        public string routeName { get; set; }
        public string lt { get; set; }
        public string km { get; set; }
        public string block { get; set; }
        public string zoneName { get; set; }
        public string stage { get; set; }
        public string reference { get; set; }
        public string ubigeo { get; set; }
        public string documentTypeId { get; set; }
        public string nationalityId { get; set; }
        public string sexId { get; set; }
        public string civilStatus { get; set; }
        public string routeTypeId { get; set; }
        public string zoneTypeId { get; set; }
        public string observation { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }

        public MainData()
        {
        }

        public MainData(int employeeId, string documentNumber, DateTime? birthDate, string ubigeoBirth, string postalCode, string phoneNumber, string email, bool? domiciled, string routeTypeNumber, string department, string inside, string mz, string routeName, string lt, string km, string block, string zoneName, string stage, string reference, string ubigeo, string documentTypeId, string nationalityId, string sexId, string civilStatus, string routeTypeId, string zoneTypeId, string observation, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.documentNumber = documentNumber;
            this.birthDate = birthDate;
            this.ubigeoBirth = ubigeoBirth;
            this.postalCode = postalCode;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.domiciled = domiciled;
            this.routeTypeNumber = routeTypeNumber;
            this.department = department;
            this.inside = inside;
            this.mz = mz;
            this.routeName = routeName;
            this.lt = lt;
            this.km = km;
            this.block = block;
            this.zoneName = zoneName;
            this.stage = stage;
            this.reference = reference;
            this.ubigeo = ubigeo;
            this.documentTypeId = documentTypeId;
            this.nationalityId = nationalityId;
            this.sexId = sexId;
            this.civilStatus = civilStatus;
            this.routeTypeId = routeTypeId;
            this.zoneTypeId = zoneTypeId;
            this.observation = observation;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
