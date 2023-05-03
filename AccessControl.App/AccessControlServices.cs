using AccessControl.App.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Threading;

namespace AccessControl.App;

public class AccessControlServices
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, RequestHandlerBase> _requestHandlers = new();

    public AccessControlServices(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Execute<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var handler = (RequestHandlerWrapper<TResponse>)_requestHandlers.GetOrAdd(request.GetType(), static requestType =>
        {
            var wrapperType = typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(requestType, typeof(TResponse));
            var wrapper = Activator.CreateInstance(wrapperType) ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}");
            return (RequestHandlerBase)wrapper;
        });

        return handler.Handle(request, _serviceProvider, cancellationToken);
    } 

    public TResponse Read<TRequest, TResponse>(TRequest request)
    {
        throw new NotImplementedException();
    }
}