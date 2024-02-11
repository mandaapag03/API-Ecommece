using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Model
{
    [Table("categoria", Schema = "dbpet")]
    public class Category
    {
        [Obsolete]
        public int Id { get; set; }
        public string Nome { get; set; }

        [ForeignKey("SubCategoria")]
        public int? IdSubCategoria { get; set; }

        //Navigation Properties
        [Obsolete]
        public Category? SubCategoria { get; set; }
    }
}
