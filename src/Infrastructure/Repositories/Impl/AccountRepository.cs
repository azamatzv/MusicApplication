using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(DatabaseContext context) : base(context) { }
}