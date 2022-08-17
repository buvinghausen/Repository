using System.Linq.Expressions;

namespace Repository.Abstractions;

public interface ICommandRepository<T> : IQueryRepository<T> where T : class
{
	Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
	Task InsertAsync(T entity, CancellationToken cancellationToken = default);
	Task UpdateAsync(Expression<Func<T, bool>> filter, T entity, CancellationToken cancellationToken = default);
}

public interface ICommandRepository<TParent, TChild> : IQueryRepository<TParent, TChild>, ICommandRepository<TChild>
	where TParent : class where TChild : class, TParent
{

}
