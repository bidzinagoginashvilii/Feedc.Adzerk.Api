namespace Feedc.Adzerk.Application.Infrastructure
{
    public class QueryExecutionResult<T> : ExecutionResult
    {
        public T Data { get; set; }
    }
}
