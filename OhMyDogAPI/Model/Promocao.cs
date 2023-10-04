namespace OhMyDogAPI.Model
{
    public class Promocao
    {
        [Obsolete]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Desconto { get; set; }
    }
}
