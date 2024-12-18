using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class UsersRepository : BaseRepository<Users>, IUsersRepository
{
    public UsersRepository(DatabaseContext context) : base(context) { }
}