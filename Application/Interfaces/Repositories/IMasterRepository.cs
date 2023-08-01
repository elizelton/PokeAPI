using Base.Interfaces;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IMasterRepository : IRepository<Master>
{
    Task<List<Master>> GetAllAsync();
    Task<Master?> GetByIdAsync(int id);
    Task InsertAsync(Master entity);
    Task<bool> EmailAlreadyRegisteredAsync(string email, int? id = null);
    Task<bool> DocumentAlreadyRegisteredAsync(string document, int? id = null);
    void Update(Master entity);
}