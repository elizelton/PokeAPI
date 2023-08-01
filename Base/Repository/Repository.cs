using Base.Entities;
using Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Base.Repository;

public abstract class Repository<T, TY> : IRepository<T> where T : Entity where TY : DbContext
{
    protected readonly TY Db;
    protected readonly DbSet<T> DbSet;

    protected Repository(TY context)
    {
        Db = context;
        DbSet = Db.Set<T>();
    }

    public async Task CommitAsync() => await Db.SaveChangesAsync();
    public async Task DisposeAsync() => await Db.DisposeAsync();
}