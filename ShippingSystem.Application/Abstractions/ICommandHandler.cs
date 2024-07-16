using MediatR;
using ShippingSystem.Shared;
using System;

namespace ShippingSystem.Application.Abstractions
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, BaseResponse>
     where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, BaseResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
