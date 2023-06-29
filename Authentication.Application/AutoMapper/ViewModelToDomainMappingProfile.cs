using Authentication.Application.ViewModels;
using Authentication.Domain.Commands;
using AutoMapper;

namespace Authentication.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AssociateIdentificationViewModel, SaveAssociateIdentificationCommand>()
                .ConstructUsing(a => new SaveAssociateIdentificationCommand(
                    a.AssociateId,
                    a.Email,
                    a.DocumentNumber,
                    a.PlanId));
        }
    }
}
