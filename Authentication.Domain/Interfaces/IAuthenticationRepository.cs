using Authentication.Domain.Models;

namespace Authentication.Domain.Interfaces
{
    public interface IAuthenticationRepository : IRepository<Account>
    { }
}
