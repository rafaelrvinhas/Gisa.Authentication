using Authentication.Application.ViewModels;
using Authentication.Domain.Models;
using AutoMapper;

namespace Authentication.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AssociateIdentification, AssociateIdentificationViewModel>();
        }
    }
}
