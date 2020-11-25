using Feedc.Adzerk.Infrastructure.Configuration;
using System;
using System.Threading.Tasks;

namespace Feedc.Adzerk.Application.Infrastructure
{
    public class QueryExecutor
    {
        protected AdzerkConfig _config;
        public IServiceProvider _serviceProvider;

        public QueryExecutor(AdzerkConfig config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        public async Task<QueryExecutionResult<TResult>> ExecuteAsync<TQuery, TResult>(TQuery query)
            where TQuery : Query<TResult> where TResult : class
        {
            try
            {
                query.Resolve(_config, _serviceProvider);
                return await query.ExecuteAsync();
            }
            catch (Exception)
            {
                return new QueryExecutionResult<TResult>
                {
                    Success = false
                };
            }
        }
    }
}