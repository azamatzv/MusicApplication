using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DatabaseContext context) : base(context) { }
}