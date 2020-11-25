using Feedc.Adzerk.Infrastructure.Configuration;
using System;
using System.Threading.Tasks;

namespace Feedc.Adzerk.Application.Infrastructure
{
    public class CommandExecutor
    {
        protected AdzerkConfig _config;
        public IServiceProvider _serviceProvider;

        public CommandExecutor(AdzerkConfig config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        public async Task<CommandExecutionResult> ExecuteAsync(Command command)
        {
            try
            {
                command.Resolve(_config, _serviceProvider);
                return await command.ExecuteAsync();
            }
            catch (Exception exception)
            {
                return new CommandExecutionResult
                {
                    Exception = exception,
                    Success = false
                };
            }

        }
    }
}
