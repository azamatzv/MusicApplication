using Application.Models.Users;
using Application.Services.Interfaces;
using Core.Entities;
using Infrastructure.Repositories;

namespace Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserResponseModel> AddUserAsync(CreateUserModel userDto)
    {
        var user = new Users
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
            CreatedBy = "System",
            Accounts = new List<Account>
            {
                new Account
                {
                    Name = userDto.Name,
                    TariffTypeId = userDto.TariffId
                }
            }
        };


        var createdUser = await _usersRepository.AddAsync(user);

        var account = createdUser.Accounts.FirstOrDefault();

        if (account != null)
        {
            account.UserId = createdUser.Id;
            account.Name = createdUser.Name;
        }

        await _usersRepository.UpdateAsync(createdUser);

        return MapToDto(createdUser);
    }


    public async Task<UserResponseModel> GetByIdAsync(Guid id)
    {
        var user = await _usersRepository.GetFirstAsync(u => u.Id == id);

        if (user == null) throw new Exception("User not found");
        
        
        return MapToDto(user);
    }


    public async Task<List<UserResponseModel>> GetAllAsync()
    {
        var users = await _usersRepository.GetAllAsync(_ => true);

        return users.Select(MapToDto).ToList();
    }


    public async Task<UserResponseModel> UpdateUserAsync(Guid id, UpdateUserModel userDto)
    {
        var user = await _usersRepository.GetFirstAsync(u => u.Id == id);
        if (user == null) throw new Exception("User not found");

        user.Email = userDto.Email;
        user.Password = userDto.Password;

        await _usersRepository.UpdateAsync(user);


        return MapToDto(user);
    }


    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _usersRepository.GetFirstAsync(u => u.Id == id);
        if (user == null) throw new Exception("User not found");

        await _usersRepository.DeleteAsync(user);


        return true;
    }



    private UserResponseModel MapToDto(Users user)
    {
        return new UserResponseModel
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };
    }
}