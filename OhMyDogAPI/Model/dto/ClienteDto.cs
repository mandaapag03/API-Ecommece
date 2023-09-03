using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model.dto
{
    [Table("cliente", Schema = "dbpet")]
    public class ClienteDto
    {
        [Key]
        public int id { get; set; }
        public int id_usuario { get; set; }
        public DateOnly data_cadastro { get; set; }
    }
}
