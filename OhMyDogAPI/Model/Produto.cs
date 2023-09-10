using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    //[Table("produto", Schema = "dbpet")]
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public string? Foto { get; set; }

        public double PrecoUnitario { get; set; }

        public bool IsActive { get; set; }
        public int CategoriaId { get; set; }

        //Navigation Properties
        public Categoria Categoria { get; set; } 
    }
}
