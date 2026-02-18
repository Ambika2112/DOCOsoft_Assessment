using UserRecord.Api.Models;
namespace UserRecord.Api.Repositories
{
    public interface IUserRepository
    {        
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}