using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.EntityFrameworkCore;

public abstract class RelationalQueryRepository<T> : IRelationalQueryRepository<T> where T : class
{
	protected readonly DbSet<T> Query;

	protected RelationalQueryRepository(DbContext context) : this(context.Set<T>())
	{
	}

	protected RelationalQueryRepository(DbSet<T> set)
	{
		Query = set;
	}

	public Task<bool> AnyAsync(CancellationToken cancellationToken = default) =>
		Query.AnyAsync(cancellationToken);

	public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.AnyAsync(filter, cancellationToken);

	public Task<bool> AnyAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().AnyAsync(cancellationToken);

	public Task<bool> AnyAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().AnyAsync(filter, cancellationToken);

	public Task<int> CountAsync(CancellationToken cancellationToken = default) =>
		Query.CountAsync(cancellationToken);

	public Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.CountAsync(filter, cancellationToken);

	public Task<int> CountAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().CountAsync(cancellationToken);

	public Task<int> CountAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().CountAsync(filter, cancellationToken);

	public Task<long> LongCountAsync(CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(cancellationToken);

	public Task<long> LongCountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(filter, cancellationToken);

	public Task<long> LongCountAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().LongCountAsync(cancellationToken);

	public Task<long> LongCountAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().LongCountAsync(filter, cancellationToken);

	public Task<T> FirstAsync(CancellationToken cancellationToken = default) =>
		Query.FirstAsync(cancellationToken);

	public Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstAsync(filter, cancellationToken);

	public Task<TChild> FirstAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstAsync(cancellationToken);

	public Task<TChild> FirstAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstAsync(filter, cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TChild?> FirstOrDefaultAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstOrDefaultAsync(cancellationToken);

	public Task<TChild?> FirstOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<T> SingleAsync(CancellationToken cancellationToken = default) =>
		Query.SingleAsync(cancellationToken);

	public Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleAsync(filter, cancellationToken);

	public Task<TChild> SingleAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleAsync(cancellationToken);

	public Task<TChild> SingleAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleAsync(filter, cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TChild?> SingleOrDefaultAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleOrDefaultAsync(cancellationToken);

	public Task<TChild?> SingleOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull =>
		Query.Select(projection).ToDictionaryImpl(keySelector, valueSelector, cancellationToken);

	public Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull =>
		Query.Where(filter).Select(projection).ToDictionaryImpl(keySelector, valueSelector, cancellationToken);

	public Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(Expression<Func<TChild, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TChild : T where TKey : notnull =>
		Query.OfType<TChild>().Select(projection).ToDictionaryImpl(keySelector, valueSelector, cancellationToken);

	public Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TChild : T where TKey : notnull =>
		Query.OfType<TChild>().Where(filter).Select(projection).ToDictionaryImpl(keySelector, valueSelector, cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(CancellationToken cancellationToken = default) =>
		Query.ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.Where(filter).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Order<T> order, CancellationToken cancellationToken = default) =>
		Query.OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, Order<T> order, CancellationToken cancellationToken = default) =>
		Query.Where(filter).OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Order<T> order, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Page(count, page).OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, Order<T> order, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Page(count, page).OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Order<T, TChild> order, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Order<T, TChild> order, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Page(count, page).OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Page(count, page).OrderBy(order).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Order<T> order, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.OrderBy(order).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Order<T> order, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).OrderBy(order).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Order<T> order, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.OrderBy(order).Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, Order<T> order, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(filter).OrderBy(order).Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().OrderBy(order).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).OrderBy(order).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().OrderBy(order).Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Order<T, TChild> order, Expression<Func<TChild, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).OrderBy(order).Select(projection).Page(count, page).ToListImpl(cancellationToken);
}
