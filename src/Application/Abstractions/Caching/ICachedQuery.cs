namespace Application.Abstractions.Caching;
public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;
{
}
