using Authentication.Domain.Core.Commands;

namespace Authentication.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
