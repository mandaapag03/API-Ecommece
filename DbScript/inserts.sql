insert into dbpet.tipo_usuario (descricao) values ('Admin'), ('Cliente');
insert into dbpet.forma_envio (descricao, valor_frete) values 
('Sedex', 10.0), 
('Transportadora Aurora', 15.0),
('Retirada na loja Magazine Luiza', 5.99);

insert into dbpet.categoria (id_subcategoria, nome_categoria) values 
(null, 'Rações'),
(null, 'Higiene e limpeza'),
(null, 'Medicina e saúde'),
(null, 'Acessórios de alimentação'),
(null, 'Brinquedos'),
(null, 'Petiscos'),
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
(4, 'Porta Rações e Acessórios'),
(17, 'Petiscos secos'),
(17, 'Petiscos molhados');

insert into dbpet.status_pedido (descricao) values 
('Cancelado'),
('Pendente'),
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

insert into dbpet.status_pagamento (descricao) values 
('Cancelado'),
('Pendente'), 
('Concluído');

insert into dbpet.produto (id_categoria, nome_produto, descricao, foto, preco_unitario, is_active) 
values (5,
		'Ração Pedigree Nutrição Essencial Carne para Cães Adultos - Leve 15kg e Pague 13,5kg',
		'Nutrição Essencial Carne para Cães Adultos - Leve 15kg e Pague 13,5kg',
		'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSKzW7nMYEPvS49WOB-KthI8LKJZG8m5cghGk4LyDSe84Y3SOpvEMWJK0iZR60Y9ERVBQCktG-TbLSfQlfWF784yPRUDY8sjQbbc7j3NxcGVeCV3f_PEyD9ujFnBbvzB6qu7dxq5io4&usqp=CAc',
	   	154.99, true),
	   	(3,
		'Mirtz Gatos 2mg Agener 12 Comp',
		'Mirtiz de 2 mg da Agener - Estimulador de apetite para gatos O Mirtiz Agener é um medicamento que estimula o seu felino a ganhar peso.  O produto é indicado para casos de hiporexia ou anorexia, auxiliando o gatinho a ter vontade de se alimentar.  Mirtiz Agener colabora para o aumento da atividade noradrenérgica, garantindo vida longa e saudável.  Além disso, coopera para atividades serotoninérgicas. Seus comprimidos são totalmente pequenos e palatáveis.  Benefícios do medicamento Mirtiz Segurança e eficácia: dosagem precisa em 1 único comprimido. Conveniência: comprimidos pequenos e palatáveis. Modo de usar  1 comprimido, por via oral, a cada 48 horas, por até 3 semanas consecutivas ou a critério do médico veterinário.  Fórmula para Cada 60mg  Miirtazapina ....................... 2mg  Excipiente .. q.s.p. ............ 60mg',
		'https://tudodebicho.vtexassets.com/arquivos/ids/159973-1200-auto?v=638406581831570000&width=1200&height=auto&aspect=true',
	   	54.25, true),
	   	(19,
		'Snack Desidratado Para Gatos Natural Crips Iscas de Salmão 2',
		'Snack Desidratado Para Gatos Natural Crips Iscas de Salmão O Snack Desidratado Para Gatos Natural Crips foi feito especialmente para o seu gatinho, é super saboroso e é um produto 100% natural, é rico em proteínas e rem baixo teor de gordura.  É livre de conservantes e corantes artificiais, melhora a saúde bucal do gatinho de uma forma saudável e saborosa.  É uma ótima opção de petisco e pode ser oferecido nos momentos de diversão do seu amiguinho.  Modo de usar Porte pequeno: 2 Bifinhos Porte médio: 4 Bifinhos Porte grande: 6 Bifinhos   Composição Carne mecanicamente separada de salmão.',
		'https://cdn.awsli.com.br/300x300/2170/2170673/produto/166159520/835d647219.jpg',
	   	5.98, true),
	   	(19,
		'Petisco Dreamies Gatos Adultos Frango 40g',
		'Petisco Dreamies Gatos Adultos Frango  Deliciosamente crocante por fora, macio por dentro; Os gatos simplesmente não conseguem resistir ao excelente sabor das guloseimas DREAMIES ™.  Surpreendentemente, não usamos um ingrediente secreto ou mágica para torná-los deliciosos.  Acabamos de colocar muitas das coisas gostosas que os gatos amam nessas guloseimas saborosas.  Então vá em frente, dê uma sacudida no saco e observe seu gato vir correndo. ',
		'https://tudodebicho.vtexassets.com/arquivos/ids/165051-1200-auto?v=638406617388470000&width=1200&height=auto&aspect=true',
	   	4.19, true),
	   	(20,
		'Purê Churu Petisco Cremoso para Gatos Galinha com Camarão 56',
		'Informações Importantes - Indicado para gatos; - Snack cremoso e delicioso; - Saudável e com baixa caloria; - Sem conservantes e sem corantes; - Embalagem contém 4 tubos de 14g cada.',
		'https://tudodebicho.vtexassets.com/arquivos/ids/174704-1200-auto?v=638386998269370000&width=1200&height=auto&aspect=true',
	   	20.93, true);
