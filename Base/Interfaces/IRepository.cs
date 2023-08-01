using Base.Entities;

namespace Base.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task CommitAsync();
    Task DisposeAsync();
}