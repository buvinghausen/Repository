using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Repository.Abstractions;

namespace Repository.Abstractions.AutoMapper;

public interface IMappedQueryRepository<T> : IQueryRepository<T> where T : class
{
	Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default);

	Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default);

	Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default);

	Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default);

	Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(
		Expression<Func<T, bool>> filter, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TKey : notnull;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(
		Expression<Func<TChild, bool>> filter, Func<TProjection, TKey> keySelector,
		Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default)
		where TChild : T where TKey : notnull;
}
