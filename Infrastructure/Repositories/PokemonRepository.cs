using Application.Interfaces.Repositories;
using Base.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class PokemonRepository : Repository<Pokemon, SqliteDbContext>, IPokemonRepository
{
    public PokemonRepository(SqliteDbContext context) : base(context)
    {
    }
    
    public async Task UpsertAsync(Pokemon entity)
{
        var pokemon = await DbSet.FindAsync(entity.Id);
        
        if (pokemon is null)
        {
            await DbSet.AddAsync(entity);
        }
        else
        {
            DbSet.Update(entity);
        }
    }
    
}