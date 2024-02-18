namespace OrderAPI.Model
{
    public class Cart
    {
        public int UsuarioId { get; set; }
        public List<int>? ProdutosId { get; set; }
    }
}
