namespace Repository.Abstractions;

public interface IRelationalCommandRepository<T> : ICommandRepository<T> where T : class
{
}

public interface IRelationalCommandRepository<TParent, TChild> : ICommandRepository<TParent, TChild> where TParent : class where TChild : class, TParent
{
}
