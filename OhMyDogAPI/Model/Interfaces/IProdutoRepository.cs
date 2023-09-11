namespace OhMyDogAPI.Model.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> GetAllProducts();
        Produto GetById(int id);
        Produto Create(Produto produto);
        Produto Update(Produto produto);
        Produto Disable(int id);
        Produto Enable(int id);
    }
}