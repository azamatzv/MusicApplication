using Application.Models.Accounts;

namespace Application.Services.Interfaces;

public interface IAccountService
{
    Task<AccountResponseModel> GetByIdAsync(Guid id);
    Task<List<AccountResponseModel>> GetAllAsync();
    Task<AccountResponseModel> AddAccountAsync(CreateAccountModel accountDto);
    Task<AccountResponseModel> UpdateAccountAsync(Guid id, UpdateAccountModel accountDto);
    Task<bool> DeleteAccountAsync(Guid id);
}