﻿using System;
using System.Threading.Tasks;

namespace Feedc.Adzerk.Application.Infrastructure
{
    public abstract class Command : ApplicationBase
    {
        public abstract Task<CommandExecutionResult> ExecuteAsync();

        protected Task<CommandExecutionResult> FailAsync(Exception exception = null)
        {
            var result = new CommandExecutionResult
            {
                Exception = exception,
                Success = false
            };

            return Task.FromResult(result);
        }

        protected Task<CommandExecutionResult> OkAsync()
        {
            var result = new CommandExecutionResult
            {
                Success = true
            };

            return Task.FromResult(result);
        }
    }
}
