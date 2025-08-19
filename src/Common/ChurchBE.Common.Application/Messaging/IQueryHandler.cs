using MediatR;
using ChurchBE.Common.Domain;

namespace ChurchBE.Common.Application.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
