using Authentication.Application.ViewModels;

namespace Authentication.Application.Interfaces
{
    public interface IAuthenticationAppService : IDisposable
    {
        AssociateIdentificationViewModel GetByEmail(string email);
        AssociateIdentificationViewModel GetByDocumentNumber(string documentNumber);
    }
}
