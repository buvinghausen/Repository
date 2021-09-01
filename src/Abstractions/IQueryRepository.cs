using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Abstractions;

public interface IQueryRepository<T> where T : class
{
	Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<bool> AnyAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<int> CountAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<long> LongCountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<long> LongCountAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild> FirstAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild?> FirstOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild> SingleAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild?> SingleOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(
		Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection,
		Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TKey : notnull;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(
		Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection,
		Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TChild : T where TKey : notnull;

	Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, int count, int page = 1,
		CancellationToken cancellationToken = default);

	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, int count, int page = 1,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, int count, int page = 1,
		CancellationToken cancellationToken = default);

	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, int count, int page = 1,
		CancellationToken cancellationToken = default) where TChild : T;
}
