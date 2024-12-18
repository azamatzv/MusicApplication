using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class MusicRepository : BaseRepository<Music>, IMusicRepository
{
    public MusicRepository(DatabaseContext context) : base(context) { }
}