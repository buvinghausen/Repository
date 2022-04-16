using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Abstractions;

namespace Repository.MongoDB;

// This doesn't really need it's own class it could be done inside the base class
// However the entity framework text search implementations are so database specific (and horrible) it would require DB specific versions
// so to follow the paradigm of inheriting class here to keep it consistent
public abstract class MongoTextSearchRepositoryBase<T> : MongoQueryRepositoryBase<T>, ITextSearchRepository<T> where T : class
{
	protected MongoTextSearchRepositoryBase(IMongoCollection<T> collection) : base(collection)
	{
	}

	// TODO: implement text score sorting
	// https://docs.mongodb.com/manual/reference/operator/aggregation/sort/#std-label-sort-pipeline-metadata
	// Tracking: https://jira.mongodb.org/browse/CSHARP-3839
	public Task<IReadOnlyList<T>> ToListAsync(string search, CancellationToken cancellationToken = default) =>
		Query.Where(search).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(string search, Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.Where(search, filter).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(string search, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(search).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<T>> ToListAsync(string search, Expression<Func<T, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(search, filter).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(search).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(search, filter).Select(projection).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(search).Select(projection).Page(count, page).ToListImpl(cancellationToken);

	public Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(string search, Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, int count, int page = 1, CancellationToken cancellationToken = default) =>
		Query.Where(search, filter).Select(projection).Page(count, page).ToListImpl(cancellationToken);
}

public abstract class MongoTextSearchRepositoryBase<TParent, TChild> : MongoTextSearchRepositoryBase<TChild>,
	ITextSearchRepository<TParent, TChild> where TParent : class where TChild : class, TParent
{
	protected MongoTextSearchRepositoryBase(IMongoCollection<TParent> collection) : base(collection.OfType<TChild>())
	{
	}
}
