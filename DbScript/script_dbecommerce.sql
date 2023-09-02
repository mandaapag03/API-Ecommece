-- Criando banco de dados e-commerce

-- lista de tabelas
--dbpet.tipo_pessoa
--dbpet.endereco
--dbpet.usuario
--dbpet.pessoa_fisica
--dbpet.inscricao_estadual
--dbpet.pessoa_juridica
--dbpet.cliente
--dbpet.administrador
--dbpet.forma_envio
--dbpet.categoria
--dbpet.produto
--dbpet.status_pedido
--dbpet.pedido
--dbpet.item_pedido
--dbpet.promocao
--dbpet.promocoes_atuais
--dbpet.forma_pagamento
--dbpet.pagamento
--dbpet.parcelamento
--dbpet.carrinho
--dbpet.avaliacao
--dbpet.estoque

create schema dbpet;

-- Tipo de pessoa (Física ou jurídica)
create table dbpet.tipo_pessoa(
	id serial primary key,
	descrição varchar(50) not null
);

-- Pessoa
create table dbpet.usuario (
	id serial primary key,
	id_endereco int not null,
	id_tipo_pessoa smallint not null,
	telefone varchar(15) not null,
	email varchar(60) not null unique,
	senha varchar(30) not null unique,
	constraint usuarios_id_endereco_fk foreign key id_endereco REFERENCES dbpet.endereco(id),
	constraint usuarios_id_endereco_fk foreign key id_tipo_pessoa REFERENCES dbpet.tipo_pessoa(id),
	CONSTRAINT email_invalid CHECK (email like '%@%'),
	CONSTRAINT senha_invalid CHECK (senha > 8 and senha < 30)
);
	
-- Pessoa Física
create table dbpet.pessoa_fisica(
	cpf char(11) primary key,
	id_usuario int not null,
	nome_completo varchar(60) not null,
	data_nascimento date
	constraint pessoa_fisica_id_usuario_fk foreign key id_usuario REFERENCES dbpet.usuarios(id),
	CONSTRAINT pessoa_fisica_cpf_invalid CHECK (length(cpf) = 11)
);

-- Inscrição Estadual
create table dbpet.inscricao_estadual(
	id smallserial primary key,
	descrição varchar(30) not null
);

-- Pessoa Jurídica
create table dbpet.pessoa_juridica(
	cnpj char(14) primary key,
	id_usuario int not null,
	razao_social varchar(60) not null,
	id_inscricao_estadual smallint not null,
	constraint pessoa_juridica_id_usuario_fk foreign key id_usuario REFERENCES dbpet.usuarios(id),
	constraint pessoa_juridica_id_inscricao_estadual_fk foreign key id_inscricao_estadual REFERENCES dbpet.inscricao_estadual(id),
	CONSTRAINT pessoa_juridica_cnpj_invalid CHECK (length(cnpj) = 14)
);

-- Cliente
create table dbpet.cliente(
	id serial primary key,
	id_usuario int not null, 
	data_cadastro date not null,
	constraint cliente_id_usuario_fk foreign key id_usuario REFERENCES dbpet.usuarios(id)
);
-- Administrador
create table dbpet.administrador(
	id serial primary key,
	id_usuario int not null, 
	constraint administrador_id_usuario_fk foreign key id_usuario REFERENCES dbpet.usuarios(id)
);

-- Endereço
create table dbpet.endereco(
	id serial primary key,
	logradouro varchar(100) not null,
	numero int not null,
	bairro varchar(60) not null,
	uf char(2) not null,  
	cep char(8) not null,
	cidade varchar(30) not null,
	complemento varchar(30)
);
	
-- Forma de envio
create table dbpet.forma_envio(
	id smallserial primary key,
	descricao varchar(30) not null,
	valor_frete real not null,
	constraint valor_frete_ck check (valor_frete > 0)
);

-- Categorias
create table dbpet.categoria(
	id smallserial primary key,
	id_subcategoria smallint,
	nome_categoria varchar(30) not null,
	constraint categoria_id_subcategoria_fk foreign key id_subcategoria REFERENCES dbpet.categoria(id)
);
-- Produtos
create table dbpet.produto(
	id serial primary key,
	id_categoria smallint not null,
	nome_produto varchar(60) not null,
	foto text,
	preco real not null,
	descrição varchar(50),
	constraint produto_id_categoria_fk foreign key id_categoria REFERENCES dbpet.categoria(id),
	constraint produto_preco_ck check (preco > 0)
);
	
-- Status do pedido
create table dbpet.status_pedido(
	id smallserial primary key,
	descrição VARCHAR(50)
);

-- Pedidos
create table dbpet.pedido(
	id serial primary key,
	data_pedido date not null,
	id_status_pedido smallint not null,
	id_forma_envio smallint not null,
	constraint pedido_id_status_pedido_fk foreign key id_status_pedido REFERENCES dbpet.status_pedido(id),
	constraint pedido_id_forma_envio_fk foreign key id_forma_envio REFERENCES dbpet.forma_envio(id)
);
	
-- Item de pedido
create table dbpet.item_pedido(
	id serial primary key,
	id_pedido int not null,
	id_produto int not null,
	quantidade smallint not null,
	preco_unitario real not null,
	constraint item_pedido_id_pedido_fk foreign key id_pedido REFERENCES dbpet.pedido(id),
	constraint item_pedido_id_produto_fk foreign key id_produto REFERENCES dbpet.produto(id),
	constraint item_pedido_preco_unitario_ck check (preco_unitario > 0)
);

-- Promoções
create table dbpet.promocao(
	id serial primary key,
	nome varchar(30) not null,
	descricao VARCHAR(50) not null,
	desconto smallint not null
);

-- PromocoesAtuais
create table dbpet.promocoes_atuais(
	id_produto int not null,
	id_promocao int not null,
	constraint promocoes_atuais_id_promocao_fk foreign key id_promocao REFERENCES dbpet.promocao(id),
	constraint promocoes_atuais_id_produto_fk foreign key id_produto REFERENCES dbpet.produto(id),
	primary key( id_produto, id_promocao)
);

-- Forma de pagamento
create table dbpet.forma_pagamento(
	id smallint primary key,
	descricao VARCHAR(50) not null
);

-- Pagamento
create table dbpet.pagamento(
	id serial primary key,
	id_cliente int not null,
	id_pedido int not null,
	id_forma_pagamento smallint not null,
	total real not null,
	constraint pagamento_id_cliente_fk foreign key id_cliente REFERENCES dbpet.cliente(id),
	constraint pagamento_id_pedido_fk foreign key id_pedido REFERENCES dbpet.pedido(id),
	constraint pagamento_id_forma_pagamento_fk foreign key id_forma_pagamento REFERENCES dbpet.forma_pagamento(id),
	constraint pagamento_total_ck check (total > 0)
);

-- Parcelamento
create table dbpet.parcelamento(
	qtd_parcelas smallint primary key,
	taxa_juros real not null default 0,
	constraint qtd_parcelas_ck check (qtd_parcelas > 0 and qtd_parcelas <= 12)
);
-- Carrinho
create table dbpet.carrinho(
	id serial primary key,
	id_cliente int not null,
	id_produto int not null,
	quantidade int not null, 
	constraint carrinho_id_cliente_fk foreign key id_cliente REFERENCES dbpet.cliente(id),
	constraint carrinho_id_produto_fk foreign key id_produto REFERENCES dbpet.produto(id),
);

-- Avaliação
create table dbpet.avaliacao(
	id int primary key, 
	id_cliente int not null,
	id_produto int not null,
	nota smallint not null,
	comentario varchar(300),
	constraint avaliacao_id_cliente_fk foreign key id_cliente REFERENCES dbpet.cliente(id),
	constraint avaliacao_id_produto_fk foreign key id_produto REFERENCES dbpet.produto(id),
	constraint avaliacao_nota_ck check(nota > 0 and nota <= 5)
);

-- Estoque
create table dbpet.estoque(
	id int primary key,
	id_produto int not null, 
	quantidade int not null,
	constraint estoque_id_produto_fk foreign key id_produto REFERENCES dbpet.produto(id),
);
