namespace OhMyDogAPI.Model.Interfaces
{
    public interface IFavoritoRepository
    {
        public Task<Favoritos?> GetFavoritos(int idUsuario);
        public Task<ItemFavoritos?> AddItemToFavoritos(ItemFavoritos item);
        public Task<bool> DeleteItemFromFavoritos(ItemFavoritos item);
    }
}
