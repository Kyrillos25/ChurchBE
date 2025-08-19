using MediatR;
using ChurchBE.Common.Domain;

namespace ChurchBE.Common.Application.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
