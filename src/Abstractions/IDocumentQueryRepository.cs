﻿namespace Repository.Abstractions;

// Merely a marker interface in the event you want to support both types of repositories in your IoC configuration
public interface IDocumentQueryRepository<T> : IQueryRepository<T> where T : class
{
}
