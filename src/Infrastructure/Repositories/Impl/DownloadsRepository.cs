using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class DownloadsRepository : BaseRepository<Downloads>, IDownloadsRepository
{
    public DownloadsRepository(DatabaseContext context) : base(context) { }
}