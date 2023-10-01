using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    [Table("categoria", Schema = "dbpet")]
    public class Categoria
    {
        [Obsolete]
        public int Id { get; set; }
        public string Nome { get; set; }

        [ForeignKey("SubCategoria")]
        public int? IdSubCategoria { get; set; }

        //Navigation Properties
        [Obsolete]
        public Categoria? SubCategoria { get; set; }
    }
}
