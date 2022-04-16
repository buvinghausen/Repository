using System.Linq.Expressions;

namespace Repository.Abstractions;

// This interface assumes you will be sorting the results by the text search score and thus doesn't provide additional ordering capabilities
public interface ITextSearchRepository<T> : IQueryRepository<T> where T : class
{
	// as-is
	Task<IReadOnlyList<T>> ToListAsync(string search, CancellationToken cancellationToken = default);

	// text search + filter
	Task<IReadOnlyList<T>> ToListAsync(string search, Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	// text search + paging
	Task<IReadOnlyList<T>> ToListAsync(string search, int count, int page = 1, CancellationToken cancellationToken = default);

	// text search + filter + paging
	Task<IReadOnlyList<T>> ToListAsync(string search, Expression<Func<T, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default);

	// as-is
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// text search + filter
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// text search + paging
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default);

	// text search + filter + paging
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default);
}

public interface ITextSearchRepository<TParent, TChild> : IQueryRepository<TChild>
	where TParent : class where TChild : class, TParent
{

}
