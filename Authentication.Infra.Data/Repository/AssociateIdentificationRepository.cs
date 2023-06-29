using Authentication.Domain.Interfaces;
using Authentication.Domain.Models;
using Authentication.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infra.Data.Repository
{
    public class AssociateIdentificationRepository : Repository<AssociateIdentification>, IAssociateIdentificationRepository
    {
        public AssociateIdentificationRepository(AuthenticationContext context) : base(context)
        { }

        public AssociateIdentification GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a => a.Email == email);
        }

        public AssociateIdentification GetByDocumentNumber(string documentNumber)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a => a.DocumentNumber == documentNumber);
        }
    }
}
