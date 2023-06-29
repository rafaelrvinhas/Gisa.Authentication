using Authentication.Application.Interfaces;
using Authentication.Application.ViewModels;
using Authentication.Domain.Commands;
using Authentication.Domain.Core.Bus;
using Authentication.Domain.Interfaces;
using AutoMapper;

namespace Authentication.Application.Services
{
    public class AssociateIdentificationAppService : IAssociateIdentificationAppService
    {
        private readonly IMapper _mapper;
        private readonly IAssociateIdentificationRepository _repository;
        private readonly IMediatorHandler Bus;

        public AssociateIdentificationAppService(
            IMapper mapper,
            IAssociateIdentificationRepository repository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _repository = repository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async void SaveAssociateIdentification(AssociateIdentificationViewModel associateIdentification)
        {
            var command = _mapper.Map<SaveAssociateIdentificationCommand>(associateIdentification);
            await Bus.SendCommand(command);
        }
    }
}
