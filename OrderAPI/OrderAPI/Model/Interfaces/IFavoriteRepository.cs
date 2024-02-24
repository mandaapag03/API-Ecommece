namespace OrderAPI.Model.Interfaces
{
    public interface IFavoriteRepository
    {
        public Task<Favorites?> Get(int userId);
        public Task<FavoriteItem?> AddItem(FavoriteItem item);
        public Task<bool> DeleteItem(FavoriteItem item);
    }
}
