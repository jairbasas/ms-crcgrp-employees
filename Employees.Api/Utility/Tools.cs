using System.IdentityModel.Tokens.Jwt;

namespace Employees.Api.Utility
{
    public static class Tools
    {
        public static int GetCompanyToken(string token) 
        {
            int companyId = 0;

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            companyId = int.Parse(jwtSecurityToken.Claims.First(x => x.Type == "company").Value);
            return companyId;
        }
    }
}
