namespace OhMyDogAPI.Model.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria>? GetAllCategorias();
        Categoria GetById(int id);
        Categoria Create(Categoria categoria);
        Categoria Delete(int id);
    }
}
