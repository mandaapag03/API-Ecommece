using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model.dto
{
    [Table("usuario", Schema = "dbpet")]
    public class UsuarioDto
    {
        [Key]
        public int id { get; set; }
        public int id_endereco { get; set; }
        public int id_tipo_pessoa { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
