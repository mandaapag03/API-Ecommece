using OrderAPI.Model.Enuns;

namespace OrderAPI.Model
{
    public class Rating
    {
        [Obsolete]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }
    }
}