using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Model
{
    public class Product
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
        public Category? Categoria { get; set; } 
    }
}
