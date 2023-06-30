using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Models
{
    public class Account : IdentityUser
    {
        //private readonly IHttpContextAccessor _accessor;

        public Account()
        {
            DocumentNumber = string.Empty;
        }

        public Account(string userName, string email, bool emailConfirmed, string documentNumber, int userTypeId)
        {
            UserName = userName;
            Email = email;
            EmailConfirmed = emailConfirmed;
            DocumentNumber = documentNumber;
            UserTypeId = userTypeId;
        }

        //public Account(IHttpContextAccessor accessor)
        //{
        //    _accessor = accessor;
        //}

        public string DocumentNumber { get; set; }
        public int UserTypeId { get; set; }
    }
}
