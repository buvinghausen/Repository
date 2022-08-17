using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.EntityFrameworkCore;

internal static class RelationalQueryExtensions
{
	// Helper method to make OrderBy fluent like the remaining operations
	internal static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, Order<T> order) where T : class =>
		order.Apply(query);

	// Helper method to keep the take & skip logic in the same place
	internal static IQueryable<T> Page<T>(this IQueryable<T> query, int count, int page)
	{
		if (count < 2) throw new ArgumentException($"Please return a single entity for count {count}", nameof(count));
		if (page < 1) throw new ArgumentException($"Page must be 1 or greater", nameof(page));
		return page == 1 ? query.Take(count) : query.Take(count).Skip((page - 1) * count);
	}

	// Helper method simply await the task so the compiler is ok with IReadOnlyDictionary<TKey, TValue> in lieu of Dictionary<TKey, TValue>
	internal static async Task<IReadOnlyDictionary<TKey, TValue>> ToDictionaryImpl<TResult, TKey, TValue>(this IQueryable<TResult> query, Func<TResult, TKey> keySelector, Func<TResult, TValue> valueSelector, CancellationToken cancellationToken) where TKey : notnull =>
		await query.ToDictionaryAsync(keySelector, valueSelector, cancellationToken).ConfigureAwait(false);

	// Helper method simply await the task so the compiler is ok with IReadOnlyList<TResult> in lieu of List<TResult>
	internal static async Task<IReadOnlyList<TResult>> ToListImpl<TResult>(this IQueryable<TResult> query, CancellationToken cancellationToken) =>
		await query.ToListAsync(cancellationToken).ConfigureAwait(false);
}
