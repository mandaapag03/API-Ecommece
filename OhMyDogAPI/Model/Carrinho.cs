namespace OhMyDogAPI.Model
{
    public class Carrinho
    {
        public int UsuarioId { get; set; }
        public List<Produto>? Produtos { get; set; }
    }
}
