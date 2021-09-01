﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Abstractions;

namespace Repository.MongoDB;
// The Mongo driver still hasn't enabled nullability
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
public class MongoQueryRepository<T> : IQueryRepository<T> where T : class
{
	protected readonly IMongoQueryable<T> Query;

	public MongoQueryRepository(IMongoCollection<T> collection)
	{
		Query = collection.AsQueryable();
	}

	public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.AnyAsync(filter, cancellationToken);

	public Task<bool> AnyAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().AnyAsync(filter, cancellationToken);

	public Task<long> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(filter, cancellationToken);

	public Task<long> CountAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().LongCountAsync(filter, cancellationToken);

	public Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstAsync(filter, cancellationToken);

	public Task<TChild> FirstAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstAsync(filter, cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TChild?> FirstOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>

		Query.OfType<TChild>().FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleAsync(filter, cancellationToken);

	public Task<TChild> SingleAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleAsync(filter, cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TChild?> SingleOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter, CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(
		Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection,
		Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TKey : notnull =>
		(await Query.Where(filter).Select(projection).ToListAsync(cancellationToken)
			.ConfigureAwait(false)).ToDictionary(keySelector, valueSelector);


	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(
		Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection,
		Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TChild : T where TKey : notnull =>
		(await Query.OfType<TChild>().Where(filter).Select(projection).ToListAsync(cancellationToken)
			.ConfigureAwait(false)).ToDictionary(keySelector, valueSelector);
}
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.