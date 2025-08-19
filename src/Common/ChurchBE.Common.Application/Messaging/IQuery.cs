using MediatR;
using ChurchBE.Common.Domain;

namespace ChurchBE.Common.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
