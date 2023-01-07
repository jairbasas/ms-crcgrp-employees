using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class UsersViewModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

    public class UsersRequest : PaginationRequest
    {
        public int? userId { get; set; }
        public int companyId { get; set; }
    }
}
