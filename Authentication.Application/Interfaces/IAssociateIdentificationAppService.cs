using Authentication.Application.ViewModels;

namespace Authentication.Application.Interfaces
{
    public interface IAssociateIdentificationAppService : IDisposable
    {
        void SaveAssociateIdentification(AssociateIdentificationViewModel associateIdentification);
    }
}
