using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Abstractions;

public interface IQueryRepository<T> where T : class
{
	Task<bool> AnyAsync(CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<bool> AnyAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<bool> AnyAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<int> CountAsync(CancellationToken cancellationToken = default);

	Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<int> CountAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<int> CountAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<long> LongCountAsync(CancellationToken cancellationToken = default);

	Task<long> LongCountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<long> LongCountAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<long> LongCountAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<T> FirstAsync(CancellationToken cancellationToken = default);

	Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild> FirstAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<TChild> FirstAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default);

	Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild?> FirstOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<TChild?> FirstOrDefaultAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<T> SingleAsync(CancellationToken cancellationToken = default);

	Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild> SingleAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<TChild> SingleAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<T?> SingleOrDefaultAsync(CancellationToken cancellationToken = default);

	Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

	Task<TChild?> SingleOrDefaultAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	Task<TChild?> SingleOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default);

	Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(Expression<Func<TChild, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TChild : T where TKey : notnull;

	Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TChild : T where TKey : notnull;

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

	// Child: as-is
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T;

	// Child: Filtered
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T;

	// Child: Ordered
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Order<T, TChild> order, CancellationToken cancellationToken = default) where TChild : T;

	// Child: Paged
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// Child: Filtered & Ordered
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, CancellationToken cancellationToken = default) where TChild : T;

	// Child: Filtered & Paged
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// Child: Ordered & Paged
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Order<T, TChild> order, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// Child: Filtered, Ordered, & Paged
	Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

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

	// Child Projection: as-is
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	// Child Projection: Filtered
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	// Child Projection: Ordered
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	// Child Projection: Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// Child Projection: Filtered & Ordered
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T;

	// Child Projection: Filtered & Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// Child Projection: Ordered & Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;

	// Projection: Filtered, Ordered, & Paged
	Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T;
}
