using Authentication.Domain.Interfaces;
using Authentication.Infra.Data.Context;

namespace Authentication.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthenticationContext _context;

        public UnitOfWork(AuthenticationContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
