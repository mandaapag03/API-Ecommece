insert into dbpet.tipo_usuario (descricao) values ('Administrador'), ('Cliente');
insert into dbpet.forma_envio (descricao, valor_frete) values 
('Sedex', 10.0), 
('Transportadora Aurora', 15.0),
('Retirada na loja Magazine Luiza', 5.99);

insert into dbpet.categoria (id_subcategoria, nome_categoria) values 
(null, 'Rações'),
(null, 'Higiene e limpeza'),
(null, 'Medicina e saúde'),
(null, 'Acessórios de alimentação'),
(1, 'Ração seca'),
(1, 'Ração úmida'),
(1, 'Ração Medicamentosa'),
(2, 'Tapete higiênico'),
(2, 'Acessórios para banho'),
(2, 'Acessórios para tosa'),
(3, 'Antipulgas e Carrapatos'),
(3, 'Vermífugos'),
(3, 'Vitaminas e Suplementos'),
(4, 'Alimentadores e Bebedouros Automáticos'),
(4, 'Comedouros e Bebedouros'),
(4, 'Porta Rações e Acessórios');

insert into dbpet.status_pedido (descricao) values 
('Pendente'),
('Processando pagamento'),
('Preparando o pedido'), 
('Enviado para a transportadora'),
('Enviado para a entrega'),
('Pedido entregue');

insert into dbpet.forma_pagamento (descricao) values 
('Pague via pix'), 
('Boleto bancário'),
('Cartão de crédito'),
('Cartão de débito');