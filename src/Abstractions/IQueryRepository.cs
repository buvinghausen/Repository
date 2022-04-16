using System.Linq.Expressions;

namespace Repository.Abstractions;

public interface IQueryRepository<T> where T : class
{
	Task<bool> AnyAsync(CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<int> CountAsync(CancellationToken cancellationToken = default);

	Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<long> LongCountAsync(CancellationToken cancellationToken = default);

	Task<long> LongCountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<T> FirstAsync(CancellationToken cancellationToken = default);

	Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default);

	Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<T> SingleAsync(CancellationToken cancellationToken = default);

	Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<T?> SingleOrDefaultAsync(CancellationToken cancellationToken = default);

	Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull;

	// As-is
	Task<IReadOnlyList<T>> ToListAsync(CancellationToken cancellationToken = default);

	// Filtered
	Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	// Ordered
	Task<IReadOnlyList<T>> ToListAsync(Order<T> order, CancellationToken cancellationToken = default);

	// Paged
	Task<IReadOnlyList<T>> ToListAsync(int count, int page = 1, CancellationToken cancellationToken = default);

	// Filtered & Ordered
	Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, Order<T> order, CancellationToken cancellationToken = default);

	// Filtered & Paged
	Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default);

	// Ordered & Paged
	Task<IReadOnlyList<T>> ToListAsync(Order<T> order, int count, int page = 1, CancellationToken cancellationToken = default);

	// Filtered, Ordered, & Paged
	Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, Order<T> order, int count, int page = 1, CancellationToken cancellationToken = default);

	// Projection: as-is
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// Projection: Filtered
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// Projection: Ordered
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Order<T> order, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// Projection: Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default);

	// Projection: Filtered & Ordered
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Order<T> order, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	// Projection: Filtered & Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default);

	// Projection: Ordered & Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Order<T> order, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default);

	// Projection: Filtered, Ordered, & Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Order<T> order, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default);
}

public interface IQueryRepository<TParent, TChild> : IQueryRepository<TChild> where TParent : class where TChild : class, TParent
{
}
