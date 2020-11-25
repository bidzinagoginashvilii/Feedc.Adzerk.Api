using System;

namespace Feedc.Adzerk.Application.Infrastructure
{
    public class CommandExecutionResult : ExecutionResult
    {
        public Exception Exception { get; set; }
    }
}
