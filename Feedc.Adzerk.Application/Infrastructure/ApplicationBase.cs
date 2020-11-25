using Feedc.Adzerk.Infrastructure.Configuration;
using System;

namespace Feedc.Adzerk.Application.Infrastructure
{
    public class ApplicationBase
    {
        protected AdzerkConfig _config;
        protected IServiceProvider _serviceProvider;

        public void Resolve(AdzerkConfig config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() => (T)_serviceProvider.GetService(typeof(T));
    }
}
