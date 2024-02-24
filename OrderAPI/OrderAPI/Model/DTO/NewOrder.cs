namespace OrderAPI.Model.DTO
{
    public class NewOrder
    {
        public int UsuarioId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int FormaEnvioId { get; set; }
        public int EnderecoId { get; set; }
        public int Qtd_parecelas { get; set; } = 1;
        public double Total { get; set; }
        public List<OrderItemWithQnt> ItensPedido { get; set; }
    }
}
