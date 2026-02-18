using UserRecord.Api.DTOs;

namespace UserRecord.Api.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateUserDto dto);
    }
}
