using Base.Interfaces;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPokemonRepository : IRepository<Pokemon>
{ 
    Task UpsertAsync(Pokemon entity);
}