using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Abstractions;

namespace Repository.MongoDB;

public abstract class MongoQueryRepositoryBase<T> : IDocumentQueryRepository<T> where T : class
{
	protected readonly IMongoQueryable<T> Query;

	protected MongoQueryRepositoryBase(IMongoCollection<T> collection)
	{
		Query = collection.AsQueryable();
	}

	public Task<bool> AnyAsync(CancellationToken cancellationToken = default) =>
		Query.AnyAsync(cancellationToken);

	public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.AnyAsync(filter, cancellationToken);

	public Task<int> CountAsync(CancellationToken cancellationToken = default) =>
		Query.CountAsync(cancellationToken);

	public Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.CountAsync(filter, cancellationToken);

	public Task<long> LongCountAsync(CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(cancellationToken);

	public Task<long> LongCountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(filter, cancellationToken);

	public Task<T> FirstAsync(CancellationToken cancellationToken = default) =>
		Query.FirstAsync(cancellationToken);

	public Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstAsync(filter, cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<T> SingleAsync(CancellationToken cancellationToken = default) =>
		Query.SingleAsync(cancellationToken);

	public Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleAsync(filter, cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull =>
		Query.Select(projection).ToDictionaryImpl(keySelector, valueSelector, cancellationToken);

	public Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default) where TKey : notnull =>
		Query.Where(filter).Select(projection).ToDictionaryImpl(keySelector, valueSelector, cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(CancellationToken cancellationToken = default) =>
		Query.ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
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
}

public abstract class MongoQueryRepositoryBase<TParent, TChild> : MongoQueryRepositoryBase<TChild>,
	IDocumentQueryRepository<TParent, TChild> where TParent : class where TChild : class, TParent
{
	protected MongoQueryRepositoryBase(IMongoCollection<TParent> collection) : base(collection.OfType<TChild>())
	{
	}
}
