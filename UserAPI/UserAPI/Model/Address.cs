namespace UserAPI.Model
{
    public class Address
    {
        [Obsolete]
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string? Complemento { get; set; }

        [Obsolete]
        public int UsuarioId { get; set; }

        // Navigation Property
        [Obsolete]
        public User? Usuario { get; set; }
    }
}
