namespace OhMyDogAPI.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public bool IsActive { get; set; }
        public int TipoUsuarioId { get; set; }
        public TipoUsuario? TipoUsuario { get; set;}
    }
}
