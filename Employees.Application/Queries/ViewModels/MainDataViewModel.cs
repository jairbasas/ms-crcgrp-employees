using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class MainDataViewModel
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
    }

    public class MainDataRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
