using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class SqliteDbContext : DbContext 
{
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }
    
    public DbSet<Master> PokemonMaster { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MasterMap());
        builder.ApplyConfiguration(new PokemonMap());
    }
    
}