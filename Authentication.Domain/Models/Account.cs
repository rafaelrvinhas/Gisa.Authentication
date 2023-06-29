using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Models
{
    public class Account : IdentityUser
    {
        //private readonly IHttpContextAccessor _accessor;

        public Account()
        { }

        public Account(string? userName, string? email, bool emailConfirmed, string? documentNumber)
        {
            UserName = userName;
            Email = email;
            EmailConfirmed = emailConfirmed;
            DocumentNumber = documentNumber;
        }

        //public Account(IHttpContextAccessor accessor)
        //{
        //    _accessor = accessor;
        //}

        public string? DocumentNumber { get; set; }
    }
}
