﻿using System.Threading.Tasks;

namespace HRAssistant.Infrastructure.CQRS
{
    public interface IBus
    {
        Task Request(ICommand request);

        Task<TResult> Request<TResult>(ICommand<TResult> request);

        Task<TResult> Execute<TResult>(IQuery<TResult> request);
    }
}
