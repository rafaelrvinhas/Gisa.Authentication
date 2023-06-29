using Authentication.Domain.Commands;
using Authentication.Domain.Interfaces;
using Authentication.Domain.Models;
using MediatR;

namespace Authentication.Domain.CommandHandlers
{
    public class AuthenticationCommandHandler : CommandHandler, IRequestHandler<SaveAssociateIdentificationCommand, bool>
    {
        private readonly IAssociateIdentificationRepository _repository;
        public AuthenticationCommandHandler(IAssociateIdentificationRepository repository, IUnitOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SaveAssociateIdentificationCommand message, CancellationToken cancellationToken)
        {
            var associateIdentification = new AssociateIdentification(
                message.AssociateId, 
                message.Email, 
                message.DocumentNumber, 
                message.AssociateCategoryId, 
                message.PlanId);

            _repository.Add(associateIdentification);

            if (Commit()) return true;
            return false;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
