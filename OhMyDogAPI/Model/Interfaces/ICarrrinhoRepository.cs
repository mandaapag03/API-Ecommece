namespace OhMyDogAPI.Model.Interfaces
{
    public interface ICarrrinhoRepository
    {
        public Task<Carrinho?> GetCarrinho(int idUsuario);
        public Task<ItemCarrinho?> AddItemToCarrinho(ItemCarrinho item);
        public Task<bool> DeleteItemFromCarrinho(ItemCarrinho item);
    }
}
