namespace OrderAPI.Model.Enuns
{
    public enum EOrderStatus
    {
        Cancelado = 1,
        Pendente = 2,
        PreparandoPedido = 3,
        NotaFiscalEmitida = 4,
        EnviadoTransportadora = 5,
        RecebidoTransportadora = 6,
        MercadoriaTransito = 7,
        MercadoriaRotaEntrega = 8,
        PedidoEntregue = 9
    }
}
