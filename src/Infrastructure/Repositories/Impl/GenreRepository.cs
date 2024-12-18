using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(DatabaseContext context) : base(context) { }
}