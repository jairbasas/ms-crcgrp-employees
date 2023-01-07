using Employees.Domain.Core;

namespace Employees.Domain.Aggregates.SunatDataAggregate
{
    public class SunatData : Audit
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

        public SunatData()
        {
        }

        public SunatData(int employeeId, string essaludCode, bool? mixedCommission, DateTime? registrationDate, string pensionTypeId, string pensionSchemeId, string workerSituationId, string occupationalCategoryId, string affiliateTypeId, string doubleTaxationId, string afpExonerationTypeId, int? registerUserId, string registerUserFullname, DateTime? registerDatetime, int? updateUserId, string updateUserFullname, DateTime? updateDatetime)
        {
            this.employeeId = employeeId;
            this.essaludCode = essaludCode;
            this.mixedCommission = mixedCommission;
            this.registrationDate = registrationDate;
            this.pensionTypeId = pensionTypeId;
            this.pensionSchemeId = pensionSchemeId;
            this.workerSituationId = workerSituationId;
            this.occupationalCategoryId = occupationalCategoryId;
            this.affiliateTypeId = affiliateTypeId;
            this.doubleTaxationId = doubleTaxationId;
            this.afpExonerationTypeId = afpExonerationTypeId;
            this.registerUserId = registerUserId;
            this.registerUserFullname = registerUserFullname;
            this.registerDatetime = registerDatetime;
            this.updateUserId = updateUserId;
            this.updateUserFullname = updateUserFullname;
            this.updateDatetime = updateDatetime;
        }
    }
}
