using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class TariffTypeRepository : BaseRepository<TariffType>, ITariffTypeRepository
{
    public TariffTypeRepository(DatabaseContext dbContext) : base(dbContext) { }
}