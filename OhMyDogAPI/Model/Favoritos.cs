namespace OhMyDogAPI.Model
{
    public class Favoritos
    {
        public int UsuarioId { get; set; }
        public List<Produto>? Produtos { get; set; }
    }
}
