using Swashbuckle.AspNetCore.Annotations;

namespace OhMyDogAPI.Model
{
    public class Usuario
    {
        [Obsolete]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public bool IsActive { get; set; }
        public int TipoUsuarioId { get; set; }

        //Navigation Property
        [Obsolete]
        public TipoUsuario? TipoUsuario { get; set;}
    }
}
