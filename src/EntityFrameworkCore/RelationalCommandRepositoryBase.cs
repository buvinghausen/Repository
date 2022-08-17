using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.EntityFrameworkCore;

public abstract class RelationalCommandRepositoryBase<T> : RelationalQueryRepositoryBase<T>, IRelationalCommandRepository<T> where T : class
{
	protected RelationalCommandRepositoryBase(DbContext context) : base(context)
	{
	}

	public Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task InsertAsync(T entity, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Expression<Func<T, bool>> filter, T entity, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}
}
