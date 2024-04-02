namespace AdministratorAPI.Model
{
    public class Feedback
    {
        [Obsolete]
        public int Id { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }
    }
}
