using ChurchBE.Common.Domain;

namespace ChurchBE.Common.Application.Exceptions;
public sealed class ChurchBEException : Exception
{
    public ChurchBEException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
