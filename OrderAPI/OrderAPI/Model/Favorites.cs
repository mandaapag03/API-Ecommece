namespace OrderAPI.Model
{
    public class Favorites
    {
        public int UsuarioId { get; set; }
        public List<int>? ProdutosId { get; set; }
    }
}
