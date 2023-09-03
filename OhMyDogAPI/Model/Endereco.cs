using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace OhMyDogAPI.Model
{
    [Table("endereco", Schema = "dbpet")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("uf")]
        public string Uf { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }
    }
}
