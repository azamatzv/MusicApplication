using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(DatabaseContext context) : base(context) { }
}