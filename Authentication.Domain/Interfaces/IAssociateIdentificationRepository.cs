using Authentication.Domain.Models;

namespace Authentication.Domain.Interfaces
{
    public interface IAssociateIdentificationRepository : IRepository<AssociateIdentification>
    {
        AssociateIdentification GetByEmail(string email);
        AssociateIdentification GetByDocumentNumber(string documentNumber);
    }
}
