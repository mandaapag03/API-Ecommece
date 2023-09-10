insert into dbpet.tipo_usuario (descricao) values ('Pessoa Física'), ('Pessoa Jurídica');
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
('Preparando o pedido'), 
('Nota fiscal emitida'),
('Enviado para a transportadora'),
('Recebido pela transportadora'),
('Mercadoria em trânsito'),
('Mercadoria em rota de entrega'),
('Pedido entregue');

insert into dbpet.forma_pagamento (descricao) values 
('Pague via pix'), 
('Boleto bancário'),
('Cartão de crédito'),
('Cartão de débito');

insert into dbpet.produto (id_categoria, nome_produto, descricao, foto, preco_unitario, is_active) 
values (5,
		'Ração Pedigree Nutrição Essencial Carne para Cães Adultos - Leve 15kg e Pague 13,5kg',
		'Nutrição Essencial Carne para Cães Adultos - Leve 15kg e Pague 13,5kg',
		'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSKzW7nMYEPvS49WOB-KthI8LKJZG8m5cghGk4LyDSe84Y3SOpvEMWJK0iZR60Y9ERVBQCktG-TbLSfQlfWF784yPRUDY8sjQbbc7j3NxcGVeCV3f_PEyD9ujFnBbvzB6qu7dxq5io4&usqp=CAc',
	   	154.99, true);