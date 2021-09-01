using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Abstractions.AutoMapper;

namespace Repository.MongoDB.AutoMapper;
// The Mongo driver still hasn't enabled nullability
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
public abstract class MapperMongoQueryRepository<T> : MongoQueryRepository<T>, IMappedQueryRepository<T> where T : class
{
	private readonly IConfigurationProvider _mapper;

	protected MapperMongoQueryRepository(IMongoCollection<T> collection, IMapper mapper) : base(collection)
	{
		_mapper = mapper.ConfigurationProvider;
	}

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		MongoProject<T, TProjection>(Query.Where(filter)).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		MongoProject<TChild, TProjection>(Query.OfType<TChild>().Where(filter)).FirstAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		MongoProject<T, TProjection>(Query.Where(filter)).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		MongoProject<TChild, TProjection>(Query.OfType<TChild>().Where(filter)).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		MongoProject<T, TProjection>(Query.Where(filter)).FirstAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		MongoProject<TChild, TProjection>(Query.OfType<TChild>().Where(filter)).FirstAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		MongoProject<T, TProjection>(Query.Where(filter)).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		MongoProject<TChild, TProjection>(Query.OfType<TChild>().Where(filter)).SingleOrDefaultAsync(cancellationToken);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(
		Expression<Func<T, bool>> filter, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TKey : notnull =>
		(await MongoProject<T, TProjection>(Query.Where(filter)).ToListAsync(cancellationToken)).ToDictionary(
			keySelector, valueSelector);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(
		Expression<Func<TChild, bool>> filter, Func<TProjection, TKey> keySelector,
		Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default)
		where TChild : T where TKey : notnull =>
		(await MongoProject<TChild, TProjection>(Query.OfType<TChild>().Where(filter)).ToListAsync(cancellationToken))
		.ToDictionary(keySelector, valueSelector);

	public async Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, int count,
		int page = 1, CancellationToken cancellationToken = default) =>
		await MongoProject<T, TProjection>(Query.Where(filter)).Take(count).Skip((page - 1) * count)
			.ToListAsync(cancellationToken);

	public async Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(
		Expression<Func<TChild, bool>> filter, int count, int page = 1, CancellationToken cancellationToken = default)
		where TChild : T =>
		await MongoProject<TChild, TProjection>(Query.OfType<TChild>().Where(filter)).Take(count)
			.Skip((page - 1) * count).ToListAsync(cancellationToken);

	// Cast the projection back to IMongoQueryable to continue the operations because Mongo's materialization functions are tied to that interface
	// ReSharper disable once SuggestBaseTypeForParameter
	protected IMongoQueryable<TDestination> MongoProject<TSource, TDestination>(IMongoQueryable<TSource> query) =>
		query.ProjectTo<TDestination>(_mapper) as IMongoQueryable<TDestination> ??
		throw new InvalidOperationException();
}
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
