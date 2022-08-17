namespace Repository.Abstractions;

public interface IDocumentCommandRepository<T> : ICommandRepository<T> where T : class
{
}

public interface IDocumentCommandRepository<TParent, TChild> : ICommandRepository<TParent, TChild> where TParent : class where TChild : class, TParent
{
}
