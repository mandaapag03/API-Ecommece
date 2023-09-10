using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    [Table("categoria", Schema = "dbpet")]
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [ForeignKey("SubCategoria")]
        public int? IdSubCategoria { get; set; }

        //Navigation Properties
        public Categoria? SubCategoria { get; set; }
    }
}
