using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class CardTypeRepository : BaseRepository<CardType>, ICardTypeRepository
{
    public CardTypeRepository(DatabaseContext dbContext) : base(dbContext) { }
}