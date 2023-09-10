-- Criando banco de dados e-commerce

create schema dbpet;

-- Tipo de usuario (Cliente ou Administrador)
create table if not exists dbpet.tipo_usuario(
	id smallserial primary key,
	descricao varchar(50) not null
);

-- Endereço
create table if not exists  dbpet.endereco(
	id serial primary key,
	logradouro varchar(100) not null,
	numero int not null,
	bairro varchar(60) not null,
	uf char(2) not null,  
	cep char(8) not null,
	cidade varchar(30) not null,
	complemento varchar(30)
);

-- Usuário
create table if not exists  dbpet.usuario (
	id serial primary key,
	id_endereco int not null,
	id_tipo_usuario smallint not null,
	nome_completo varchar(60) not null,
	cpf char(11) not null unique,
	telefone varchar(15) not null unique,
	email varchar(60) not null unique,
	senha varchar(30) not null unique,
	is_active bool not null default true,
	constraint usuarios_id_endereco_fk foreign key (id_endereco) REFERENCES dbpet.endereco(id),
	constraint usuarios_id_tipo_usuario_fk foreign key (id_tipo_usuario) REFERENCES dbpet.tipo_usuario(id),
	CONSTRAINT email_invalid CHECK (email like '%@%'),
	CONSTRAINT senha_invalid CHECK (length(senha) > 8 and length(senha) < 30)
);
	
-- Forma de envio
create table if not exists dbpet.forma_envio(
	id smallserial primary key,
	descricao varchar(60) not null unique,
	valor_frete real not null,
	constraint valor_frete_ck check (valor_frete > 0)
);

-- Categorias
create table if not exists  dbpet.categoria(
	id smallserial primary key,
	id_subcategoria smallint,
	nome_categoria varchar(60) not null unique,
	constraint categoria_id_subcategoria_fk foreign key (id_subcategoria) REFERENCES dbpet.categoria(id)
);
-- Produtos
create table if not exists  dbpet.produto(
	id serial primary key,
	id_categoria smallint not null,
	nome_produto varchar(150) not null unique,
	descricao text,
	foto text,
	preco_unitario real not null,
	is_active bool not null default false,
	constraint produto_id_categoria_fk foreign key (id_categoria) REFERENCES dbpet.categoria(id),
	constraint produto_preco_ck check (preco_unitario > 0)
);
	
-- Status do pedido
create table if not exists  dbpet.status_pedido(
	id smallserial primary key,
	descricao VARCHAR(50) unique
);

-- Pedidos
create table if not exists dbpet.pedido(
	id serial primary key,
	id_status_pedido smallint not null,
	id_forma_envio smallint not null,
	data_pedido date not null,
	constraint pedido_id_status_pedido_fk foreign key (id_status_pedido) REFERENCES dbpet.status_pedido(id),
	constraint pedido_id_forma_envio_fk foreign key (id_forma_envio) REFERENCES dbpet.forma_envio(id)
);
	
-- Item de pedido
create table if not exists  dbpet.item_pedido(
	id serial primary key,
	id_pedido int not null,
	id_produto int not null,
	quantidade smallint not null,
	constraint item_pedido_id_pedido_fk foreign key (id_pedido) REFERENCES dbpet.pedido(id),
	constraint item_pedido_id_produto_fk foreign key (id_produto) REFERENCES dbpet.produto(id)
);

-- Promoções
create table if not exists dbpet.promocao(
	id serial primary key,
	nome varchar(50) not null,
	descricao varchar(100) not null,
	desconto real not null
);

-- PromocoesAtuais
create table if not exists  dbpet.promocoes_atuais(
	id_promocao int not null,
	id_produto int not null,
	constraint promocoes_atuais_id_promocao_fk foreign key (id_promocao) REFERENCES dbpet.promocao(id),
	constraint promocoes_atuais_id_produto_fk foreign key (id_produto) REFERENCES dbpet.produto(id),
	primary key( id_produto, id_promocao)
);

-- Forma de pagamento
create table if not exists  dbpet.forma_pagamento(
	id smallserial primary key,
	descricao VARCHAR(50) not null unique
);

-- Pagamento
create table if not exists  dbpet.pagamento(
	id serial primary key,
	id_usuario int not null,
	id_pedido int not null,
	id_forma_pagamento smallint not null,
	qtd_parcelas smallint,
	total real not null,
	constraint pagamento_id_usuario_fk foreign key (id_usuario) REFERENCES dbpet.usuario(id),
	constraint pagamento_id_pedido_fk foreign key (id_pedido) REFERENCES dbpet.pedido(id),
	constraint pagamento_id_forma_pagamento_fk foreign key (id_forma_pagamento) REFERENCES dbpet.forma_pagamento(id),
	constraint pagamento_total_ck check (total > 0),
	constraint qtd_parcelas_ck check (qtd_parcelas > 0 and qtd_parcelas <= 12)
);

-- Carrinho
create table if not exists  dbpet.carrinho(
	id serial primary key,
	id_usuario int not null,
	id_produto int not null,
	constraint carrinho_id_usuario_fk foreign key (id_usuario) REFERENCES dbpet.usuario(id),
	constraint carrinho_id_produto_fk foreign key (id_produto) REFERENCES dbpet.produto(id)
);

-- Avaliação
create table if not exists  dbpet.avaliacao(
	id serial primary key, 
	id_usuario int not null,
	id_produto int not null,
	nota smallint not null,
	comentario varchar(300),
	constraint avaliacao_id_usuario_fk foreign key (id_usuario) REFERENCES dbpet.usuario(id),
	constraint avaliacao_id_produto_fk foreign key (id_produto) REFERENCES dbpet.produto(id),
	constraint avaliacao_nota_ck check(nota > 0 and nota <= 5)
);

-- Estoque
create table if not exists  dbpet.estoque(
	id serial primary key,
	id_produto int not null, 
	quantidade int not null,
	constraint estoque_id_produto_fk foreign key (id_produto) REFERENCES dbpet.produto(id)
);