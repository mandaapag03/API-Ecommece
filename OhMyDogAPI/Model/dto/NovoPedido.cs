namespace OhMyDogAPI.Model.dto
{
    public class NovoPedido
    {
        public int UsuarioId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int FormaEnvioId { get; set; }
        public int EnderecoId { get; set; }
        public int Qtd_parecelas { get; set; } = 1;
        public double Total { get; set; }
        public List<ItemPedidoComQtd> ItensPedido { get; set; }
    }
    public class ItemPedidoComQtd
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
