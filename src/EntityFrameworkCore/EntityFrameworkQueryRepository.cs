﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.EntityFrameworkCore;

public abstract class EntityFrameworkQueryRepository<T> : IQueryRepository<T> where T : class
{
	protected readonly DbSet<T> Query;

	protected EntityFrameworkQueryRepository(DbContext context) : this(context.Set<T>())
	{
	}

	protected EntityFrameworkQueryRepository(DbSet<T> set)
	{
		Query = set;
	}

	public Task<bool> AnyAsync(CancellationToken cancellationToken = default) =>
		Query.AnyAsync(cancellationToken);

	public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.AnyAsync(filter, cancellationToken);

	public Task<bool> AnyAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().AnyAsync(cancellationToken);

	public Task<bool> AnyAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().AnyAsync(filter, cancellationToken);

	public Task<int> CountAsync(CancellationToken cancellationToken = default) =>
		Query.CountAsync(cancellationToken);

	public Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.CountAsync(filter, cancellationToken);

	public Task<int> CountAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().CountAsync(cancellationToken);

	public Task<int> CountAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().CountAsync(filter, cancellationToken);

	public Task<long> LongCountAsync(CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(cancellationToken);

	public Task<long> LongCountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.LongCountAsync(filter, cancellationToken);

	public Task<long> LongCountAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().LongCountAsync(cancellationToken);

	public Task<long> LongCountAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().LongCountAsync(filter, cancellationToken);

	public Task<T> FirstAsync(CancellationToken cancellationToken = default) =>
		Query.FirstAsync(cancellationToken);

	public Task<T> FirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.FirstAsync(filter, cancellationToken);

	public Task<TChild> FirstAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstAsync(cancellationToken);

	public Task<TChild> FirstAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstAsync(filter, cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, TProjection>> projection,
		CancellationToken cancellationToken = default) =>
		Query.Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(cancellationToken);

	public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TChild?> FirstOrDefaultAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstOrDefaultAsync(cancellationToken);

	public Task<TChild?> FirstOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().FirstOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection,
		CancellationToken cancellationToken = default) =>
		Query.Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<T> SingleAsync(CancellationToken cancellationToken = default) =>
		Query.SingleAsync(cancellationToken);

	public Task<T> SingleAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) =>
		Query.SingleAsync(filter, cancellationToken);

	public Task<TChild> SingleAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleAsync(cancellationToken);

	public Task<TChild> SingleAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleAsync(filter, cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, TProjection>> projection,
		CancellationToken cancellationToken = default) =>
		Query.Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, TProjection>> projection,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Select(projection).SingleAsync(cancellationToken);
	
	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).SingleAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(cancellationToken);

	public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TChild?> SingleOrDefaultAsync<TChild>(CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleOrDefaultAsync(cancellationToken);

	public Task<TChild?> SingleOrDefaultAsync<TChild>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().SingleOrDefaultAsync(filter, cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, TProjection>> projection,
		CancellationToken cancellationToken = default) =>
		Query.Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, CancellationToken cancellationToken = default) =>
		Query.Where(filter).Select(projection).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(
		Expression<Func<TChild, TProjection>> projection, CancellationToken cancellationToken = default)
		where TChild : T =>
		Query.OfType<TChild>().Select(projection).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		Expression<Func<TChild, TProjection>> projection,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).Select(projection).FirstOrDefaultAsync(cancellationToken);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(
		Expression<Func<T, bool>> filter, Expression<Func<T, TProjection>> projection,
		Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TKey : notnull =>
		await Query.Where(filter).Select(projection).ToDictionaryAsync(keySelector, valueSelector, cancellationToken)
			.ConfigureAwait(false);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(
		Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection,
		Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TChild : T where TKey : notnull =>
		await Query.OfType<TChild>().Where(filter).Select(projection)
			.ToDictionaryAsync(keySelector, valueSelector, cancellationToken).ConfigureAwait(false);

	public async Task<IReadOnlyList<T>> ToListAsync(Expression<Func<T, bool>> filter, int count, int page = 1,
		CancellationToken cancellationToken = default) =>
		await Query.Where(filter).Take(count).Skip((page - 1) * count).ToListAsync(cancellationToken)
			.ConfigureAwait(false);

	public async Task<IReadOnlyList<TChild>> ToListAsync<TChild>(Expression<Func<TChild, bool>> filter, int count,
		int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		await Query.OfType<TChild>().Where(filter).Take(count).Skip((page - 1) * count).ToListAsync(cancellationToken)
			.ConfigureAwait(false);

	public async Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter,
		Expression<Func<T, TProjection>> projection, int count, int page = 1,
		CancellationToken cancellationToken = default) =>
		await Query.Where(filter).Select(projection).Take(count).Skip((page - 1) * count).ToListAsync(cancellationToken)
			.ConfigureAwait(false);

	public async Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(
		Expression<Func<TChild, bool>> filter, Expression<Func<TChild, TProjection>> projection, int count,
		int page = 1, CancellationToken cancellationToken = default) where TChild : T =>
		await Query.OfType<TChild>().Where(filter).Select(projection).Take(count).Skip((page - 1) * count)
			.ToListAsync(cancellationToken).ConfigureAwait(false);
}
