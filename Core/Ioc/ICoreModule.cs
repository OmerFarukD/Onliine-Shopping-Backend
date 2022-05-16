using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc
{
    public interface ICoreModule
    {
        void Load(IServiceCollection provider);
    }
}