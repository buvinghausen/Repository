using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Abstractions;

// This interface assumes you will be sorting the results by the text search score and thus doesn't provide additional ordering capabilities
public interface ITextSearchRepository<T> : IQueryRepository<T> where T : class
{
	// as-is
	Task<IReadOnlyList<T>> ToListAsync(string search, CancellationToken cancellationToken = default);

	// text search + filter
	Task<IReadOnlyList<T>> ToListAsync(string search, Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default);

	// text search + paging
	Task<IReadOnlyList<T>> ToListAsync(string search, int count, int page = 1,
		CancellationToken cancellationToken = default);

	// text search + filter + paging
	Task<IReadOnlyList<T>> ToListAsync(string search, Expression<Func<T, bool>> filter, int count, int page = 1,
		CancellationToken cancellationToken = default);

	// as-is
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(string search, CancellationToken cancellationToken = default)
		where TChild : T;

	// text search + filter
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(string search, Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T;

	// text search + paging
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(string search, int count, int page = 1,
		CancellationToken cancellationToken = default) where TChild : T;

	// text search + filter + paging
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(string search, Expression<Func<TChild, bool>> filter, int count,
		int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// as-is
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// text search + filter
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// text search + paging
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search,
		Expression<Func<T, TProjection>> projection, int count, int page = 1,
		CancellationToken cancellationToken = default);

	// text search + filter + paging
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, int count, int page = 1,
		CancellationToken cancellationToken = default);

	// as-is
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(string search,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T;

	// text search + filter
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(string search,
		Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection,
		CancellationToken cancellationToken = default) where TChild : T;

	// text search + paging
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(string search,
		Expression<Func<TChild, TProjection>> projection, int count, int page = 1,
		CancellationToken cancellationToken = default) where TChild : T;

	// text search + filter + paging
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(string search,
		Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, int count,
		int page = 1, CancellationToken cancellationToken = default) where TChild : T;
}
