using OhMyDogAPI.Repository.Context;
using System.Text.Json.Serialization;

namespace OhMyDogAPI.Model
{
    public class Usuario
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public bool IsActive { get; set; }
        public ETipoUsuario TipoUsuario { get; set;}
        public Endereco? EnderecoInfo { get; set; }
    }
}
