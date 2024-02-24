namespace UserAPI.Model
{
    public class User
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
        public UserType? TipoUsuario { get; set;}
    }
}
