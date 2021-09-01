using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Repository.Abstractions.AutoMapper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Repository.EntityFrameworkCore.AutoMapper;

public abstract class MapperEntityFrameworkQueryRepository<T> : EntityFrameworkQueryRepository<T>,
	IMappedQueryRepository<T>
	where T : class
{
	private readonly IConfigurationProvider _mapper;

	protected MapperEntityFrameworkQueryRepository(DbContext context, IMapper mapper) : this(context.Set<T>(), mapper)
	{
	}

	protected MapperEntityFrameworkQueryRepository(DbSet<T> set, IMapper mapper) : base(set)
	{
		_mapper = mapper.ConfigurationProvider;
	}

	public Task<TProjection> FirstAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.Where(filter).ProjectTo<TProjection>(_mapper).FirstAsync(cancellationToken);

	public Task<TProjection> FirstAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).ProjectTo<TProjection>(_mapper).FirstAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.Where(filter).ProjectTo<TProjection>(_mapper).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection?> FirstOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).ProjectTo<TProjection>(_mapper).FirstOrDefaultAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.Where(filter).ProjectTo<TProjection>(_mapper).SingleAsync(cancellationToken);

	public Task<TProjection> SingleAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).ProjectTo<TProjection>(_mapper).SingleAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TProjection>(Expression<Func<T, bool>> filter,
		CancellationToken cancellationToken = default) =>
		Query.Where(filter).ProjectTo<TProjection>(_mapper).SingleOrDefaultAsync(cancellationToken);

	public Task<TProjection?> SingleOrDefaultAsync<TChild, TProjection>(Expression<Func<TChild, bool>> filter,
		CancellationToken cancellationToken = default) where TChild : T =>
		Query.OfType<TChild>().Where(filter).ProjectTo<TProjection>(_mapper).SingleOrDefaultAsync(cancellationToken);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TProjection, TKey, TValue>(
		Expression<Func<T, bool>> filter, Func<TProjection, TKey> keySelector, Func<TProjection, TValue> valueSelector,
		CancellationToken cancellationToken = default) where TKey : notnull =>
		await Query.Where(filter).ProjectTo<TProjection>(_mapper)
			.ToDictionaryAsync(keySelector, valueSelector, cancellationToken);

	public async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryAsync<TChild, TProjection, TKey, TValue>(
		Expression<Func<TChild, bool>> filter, Func<TProjection, TKey> keySelector,
		Func<TProjection, TValue> valueSelector, CancellationToken cancellationToken = default)
		where TChild : T where TKey : notnull =>
		await Query.OfType<TChild>().Where(filter).ProjectTo<TProjection>(_mapper)
			.ToDictionaryAsync(keySelector, valueSelector, cancellationToken);

	public async Task<IReadOnlyList<TProjection>> ToListAsync<TProjection>(Expression<Func<T, bool>> filter, int count,
		int page = 1,
		CancellationToken cancellationToken = default) =>
		await Query.Where(filter).ProjectTo<TProjection>(_mapper).Take(count).Skip((page - 1) * count)
			.ToListAsync(cancellationToken).ConfigureAwait(false);

	public async Task<IReadOnlyList<TProjection>> ToListAsync<TChild, TProjection>(
		Expression<Func<TChild, bool>> filter, int count, int page = 1,
		CancellationToken cancellationToken = default) where TChild : T =>
		await Query.OfType<TChild>().Where(filter).ProjectTo<TProjection>(_mapper).Take(count).Skip((page - 1) * count)
			.ToListAsync(cancellationToken).ConfigureAwait(false);
}
