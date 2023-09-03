using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model.dto
{
    [Table("tipo_pessoa", Schema = "dbpet")]
    public class TipoPessoaDto
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
    }
}
