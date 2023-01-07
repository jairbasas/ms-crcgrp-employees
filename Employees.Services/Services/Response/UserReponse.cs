using Employees.Services.Helper;

namespace Employees.Services.Services.Response
{
    public class UserReponse : BaseResponse
    {
        public UserData data { get; set; }
    }

    public class UserData 
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string? password { get; set; }
        public int? resetPassword { get; set; }
        public int? state { get; set; }
        public int? registerUserId { get; set; }
        public string registerUserFullname { get; set; }
        public DateTime? registerDatetime { get; set; }
        public int? updateUserId { get; set; }
        public string updateUserFullname { get; set; }
        public DateTime? updateDatetime { get; set; }
    }

}
