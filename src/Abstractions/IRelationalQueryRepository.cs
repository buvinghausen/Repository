namespace Repository.Abstractions;

// Merely a marker interface in the event you want to support both types of repositories in your IoC configuration
public interface IRelationalQueryRepository<T> : IQueryRepository<T> where T : class
{
}

public interface IRelationalQueryRepository<TParent, TChild> : IQueryRepository<TParent, TChild> where TParent : class where TChild : class, TParent
{
}
