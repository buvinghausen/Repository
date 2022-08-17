using System.Linq.Expressions;
using MongoDB.Driver;
using Repository.Abstractions;

namespace Repository.MongoDB;

public abstract class MongoCommandRepositoryBase<T> : MongoQueryRepositoryBase<T>, IDocumentCommandRepository<T> where T : class
{
	protected MongoCommandRepositoryBase(IMongoCollection<T> collection) : base(collection)
	{
	}

	public virtual Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default) =>
		Collection.InsertManyAsync(entities, cancellationToken: cancellationToken);

	public virtual Task InsertAsync(T entity, CancellationToken cancellationToken = default) =>
		Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);

	public virtual Task UpdateAsync(Expression<Func<T, bool>> filter, T entity, CancellationToken cancellationToken = default) =>
		Collection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true }, cancellationToken);
}

public abstract class MongoCommandRepositoryBase<TParent, TChild> : MongoCommandRepositoryBase<TChild>,
	IDocumentCommandRepository<TParent, TChild> where TParent : class where TChild : class, TParent
{
	protected MongoCommandRepositoryBase(IMongoCollection<TParent> collection) : base(collection.OfType<TChild>())
	{
	}
}
