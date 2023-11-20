﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class ItemPedido
    {
        [Obsolete]
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        // Navigation Properties
        [Obsolete]
        public Pedido? Pedido { get; set; }
        [Obsolete]
        public Produto? Produto { get; set; }
    }
}
