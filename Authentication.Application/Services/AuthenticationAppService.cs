using Authentication.Application.Interfaces;
using Authentication.Application.ViewModels;
using Authentication.Domain.Core.Bus;
using Authentication.Domain.Interfaces;
using AutoMapper;

namespace Authentication.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IMapper _mapper;
        private readonly IAssociateIdentificationRepository _associateIdentificationRepository;
        private readonly IMediatorHandler Bus;

        public AuthenticationAppService(
            IMapper mapper,
            IAssociateIdentificationRepository associateIdentificationRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _associateIdentificationRepository = associateIdentificationRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public AssociateIdentificationViewModel GetByEmail(string email)
        {
            return _mapper.Map<AssociateIdentificationViewModel>(_associateIdentificationRepository.GetByEmail(email));
        }

        public AssociateIdentificationViewModel GetByDocumentNumber(string documentNumber)
        {
            return _mapper.Map<AssociateIdentificationViewModel>(_associateIdentificationRepository.GetByDocumentNumber(documentNumber));
        }
    }
}
