using System.Linq.Expressions;

namespace Repository.Abstractions;

// Helper class to allow end users to compose OrderBy statements against non polymorphic sources
public sealed class Order<T> where T : class
{
	private readonly Func<IQueryable<T>, IOrderedQueryable<T>> _transform;

	private Order(Func<IQueryable<T>, IOrderedQueryable<T>> transform)
	{
		_transform = transform;
	}

	public static Order<T> OrderBy<TKey>(Expression<Func<T, TKey>> primary) =>
		new(q => q.OrderBy(primary));

	public static Order<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> primary) =>
		new(q => q.OrderByDescending(primary));

	public Order<T> ThenBy<TKey>(Expression<Func<T, TKey>> secondary) =>
		new(q => _transform(q).ThenBy(secondary));

	public Order<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> secondary) =>
		new(q => _transform(q).ThenByDescending(secondary));

	internal IOrderedQueryable<T> Apply(IQueryable<T> query) =>
		_transform(query);

	// This is here for dipstick APIs like Mongo that have their own marker interface
	internal TOrderedQueryable Apply<TOrderedQueryable>(IQueryable<T> query) where TOrderedQueryable : class, IOrderedQueryable<T> =>
		_transform(query) as TOrderedQueryable ?? throw new InvalidOperationException("Unable to cast transformation");
}
