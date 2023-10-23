namespace OhMyDogAPI.Model.Interfaces
{
    public interface ICarrinhoRepository
    {
        public Task<Carrinho?> GetCarrinho(int idUsuario);
        public Task<ItemCarrinho?> AddItemToCarrinho(ItemCarrinho item);
        public Task<bool> DeleteItemFromCarrinho(ItemCarrinho item);
    }
}
