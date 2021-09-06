using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Abstractions;

namespace Repository.MongoDB;

internal static class MongoQueryExtensions
{
	// Helper method to make OrderBy fluent like the remaining operations
	internal static IOrderedMongoQueryable<T> OrderBy<T>(this IMongoQueryable<T> query, Order<T> order) where T : class =>
		order.Apply<IOrderedMongoQueryable<T>>(query);

	internal static IOrderedMongoQueryable<TChild> OrderBy<T, TChild>(this IMongoQueryable<TChild> query, Order<T, TChild> order)
		where T : class where TChild : T =>
		order.Apply<IOrderedMongoQueryable<TChild>>(query);

	// Helper method to keep the take & skip logic in the same place
	internal static IMongoQueryable<T> Page<T>(this IMongoQueryable<T> query, int count, int page)
	{
		if (count < 2) throw new ArgumentException($"Please return a single entity for count {count}", nameof(count));
		if (page < 1) throw new ArgumentException($"Page must be 1 or greater", nameof(page));
		return page == 1 ? query.Take(count) : query.Take(count).Skip((page - 1) * count);
	}

	// Helper method simply await the task so the compiler is ok with IReadOnlyDictionary<TKey, TValue> in lieu of Dictionary<TKey, TValue>
	// While Mongo doesn't support ToDictionary in their IMongoQueryable interface we can just use ToList and ToDictionary together
	internal static async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryImpl<TResult, TKey, TValue>(
		this IMongoQueryable<TResult> query, Func<TResult, TKey> keySelector, Func<TResult, TValue> valueSelector,
		CancellationToken cancellationToken) where TKey : notnull =>
		(await query.ToListAsync(cancellationToken).ConfigureAwait(false)).ToDictionary(keySelector, valueSelector);

	// Helper method simply await the task so the compiler is ok with IReadOnlyList<TResult> in lieu of List<TResult>
	internal static async Task<IReadOnlyList<TResult>> ToListImpl<TResult>(this IMongoQueryable<TResult> query,
		CancellationToken cancellationToken) =>
		await query.ToListAsync(cancellationToken).ConfigureAwait(false);
}
