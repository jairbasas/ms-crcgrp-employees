using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class SunatDataViewModel
    {
        public int employeeId { get; set; }
        public string essaludCode { get; set; }
        public bool? mixedCommission { get; set; }
        public DateTime? registrationDate { get; set; }
        public string pensionTypeId { get; set; }
        public string pensionSchemeId { get; set; }
        public string workerSituationId { get; set; }
        public string occupationalCategoryId { get; set; }
        public string affiliateTypeId { get; set; }
        public string doubleTaxationId { get; set; }
        public string afpExonerationTypeId { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class SunatDataRequest : PaginationRequest
    {
        public int employeeId { get; set; }
    }
}
