using Authentication.Application.Interfaces;
using Authentication.Application.ViewModels;

namespace Authentication.Services.WorkerService
{
    public class App
    {
        private readonly IAssociateIdentificationAppService _associateIdentificationAppService;

        public App(IAssociateIdentificationAppService associateIdentificationAppService)
        {
            _associateIdentificationAppService = associateIdentificationAppService;
        }

        public void Run(AssociateIdentificationViewModel associateIdentification)
        {
            _associateIdentificationAppService.SaveAssociateIdentification(associateIdentification);
        }
    }
}
