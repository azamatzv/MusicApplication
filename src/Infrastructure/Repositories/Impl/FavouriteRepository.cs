using Core.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Impl;

public class FavouriteRepository : BaseRepository<Favourite>, IFavouriteRepository
{
    public FavouriteRepository(DatabaseContext context) : base(context) { }
}