using Authentication.Application.Interfaces;
using Authentication.Application.Services;
using Authentication.Domain.CommandHandlers;
using Authentication.Domain.Commands;
using Authentication.Domain.Core.Bus;
using Authentication.Domain.Interfaces;
using Authentication.Infra.CrossCutting.Bus;
using Authentication.Infra.Data.Context;
using Authentication.Infra.Data.Repository;
using Authentication.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IAssociateIdentificationAppService, AssociateIdentificationAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<SaveAssociateIdentificationCommand, bool>, AuthenticationCommandHandler>();

            // Infra - Data
            services.AddScoped<IAssociateIdentificationRepository, AssociateIdentificationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AuthenticationContext>();
        }
    }
}
