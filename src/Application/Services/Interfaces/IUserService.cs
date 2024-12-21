using Application.Models.Users;

namespace Application.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseModel> GetByIdAsync(Guid id);
    Task<List<UserResponseModel>> GetAllAsync();
    Task<UserResponseModel> AddUserAsync(CreateUserModel userDto);
    Task<UserResponseModel> UpdateUserAsync(Guid id, UpdateUserModel userDto);
    Task<bool> DeleteUserAsync(Guid id);
}