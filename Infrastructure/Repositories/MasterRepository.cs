using Application.Interfaces.Repositories;
using Base.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MasterRepository : Repository<Master, SqliteDbContext>, IMasterRepository
{
    public MasterRepository(SqliteDbContext context) : base(context)
    {
    }

    public async Task<List<Master>> GetAllAsync()
        => await DbSet.ToListAsync();
    public async Task<Master?> GetByIdAsync(int id)
        => await DbSet.FindAsync(id);

    public async Task InsertAsync(Master master) 
        => await DbSet.AddAsync(master);

    public async Task<bool> EmailAlreadyRegisteredAsync(string email, int? id = null)
        => await DbSet.AsNoTracking().AnyAsync(x => x.Email == email && x.Id != id);
    
    public async Task<bool> DocumentAlreadyRegisteredAsync(string document, int? id = null)
        => await DbSet.AsNoTracking().AnyAsync(x => x.Document == document && x.Id != id);

    public void Update(Master master)
    {
        master.SetUpdatedAt();
        DbSet.Update(master);
    }

    public async Task CommitAsync()
        => await Db.SaveChangesAsync();

    public async Task DisposeAsync()
        => await Db.DisposeAsync();
    
}