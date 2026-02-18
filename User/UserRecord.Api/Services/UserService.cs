using UserRecord.Api.DTOs;
using UserRecord.Api.Models;
using UserRecord.Api.Repositories;

namespace UserRecord.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return null;

            return MapToDto(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            await _repository.CreateAsync(user);
            await _repository.SaveChangesAsync();

            return MapToDto(user);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return false;

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;

            await _repository.UpdateAsync(user);
            await _repository.SaveChangesAsync();

            return true;
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                LastUpdated = user.LastUpdated
            };
        }
    }
}