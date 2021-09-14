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

// Helper class to allow end users to compose OrderBy statements against polymorphic sources
public sealed class Order<T, TChild> where T : class where TChild : T
{
	private readonly Func<IQueryable<TChild>, IOrderedQueryable<TChild>> _transform;

	private Order(Func<IQueryable<TChild>, IOrderedQueryable<TChild>> transform)
	{
		_transform = transform;
	}

	public static Order<T, TChild> OrderBy<TKey>(Expression<Func<TChild, TKey>> primary) =>
		new(q => q.OrderBy(primary));

	public static Order<T, TChild> OrderByDescending<TKey>(Expression<Func<TChild, TKey>> primary) =>
		new(q => q.OrderByDescending(primary));

	public Order<T, TChild> ThenBy<TKey>(Expression<Func<TChild, TKey>> secondary) =>
		new(q => _transform(q).ThenBy(secondary));

	public Order<T, TChild> ThenByDescending<TKey>(Expression<Func<TChild, TKey>> secondary) =>
		new(q => _transform(q).ThenByDescending(secondary));

	internal IOrderedQueryable<TChild> Apply(IQueryable<TChild> query) =>
		_transform(query);

	// This is here for dipstick APIs like Mongo that have their own marker interface
	internal TOrderedQueryable Apply<TOrderedQueryable>(IQueryable<TChild> query) where TOrderedQueryable : class, IOrderedQueryable<TChild> =>
		_transform(query) as TOrderedQueryable ?? throw new InvalidOperationException("Unable to cast transformation");
}
