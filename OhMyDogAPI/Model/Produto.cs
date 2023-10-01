using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class Produto
    {
        [Obsolete]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public string? Foto { get; set; }

        public double PrecoUnitario { get; set; }

        public bool IsActive { get; set; }
        public int CategoriaId { get; set; }

        //Navigation Properties
        [Obsolete]
        public Categoria? Categoria { get; set; } 
    }
}
