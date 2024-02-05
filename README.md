# OhMyDog-API
- Grupo:
- Amanda Pagani Lima - 2200564
- Bruno Vinícius Alves Santos - 2100913
- Evany Marianne Alves Mota Folli - 2200798
- Gustavo Emynem Izidre Ribeiro - 2200826
- Gustavo Farias Freire - 2201292
- Michel Vacari Cruz - 2200102

# Para rodar o docker compose
Requisitos: 
- Ter o docker instalado. Caso vc tenha Windows, acesse meu tutorial de instalação
https://www.instagram.com/p/C2tlM4wOPa2/?utm_source=ig_web_copy_link&igsh=MzRlODBiNWFlZA==

1. faça o clone do projeto:
git clone https://github.com/mandaapag03/OhMyDog-API.git
2. Entre com o cmd na pasta do projeto e digite:
docker-compose up
3. Acesse a api na URL:
http://localhost:5009/swagger/index.html
4. Acessar banco de dados
    a. Acesse o PgAdmin no link: http://localhost:15432/
   
    Usuario: amanda.pagani@aluno.faculdadeimpacta.com.br
    Senha: PgAdmin2023!

    b. Botão direito na aba Servers > Register > Server...
    c. Na aba General, preencha o Name. Na aba Connection preencha Host, Port, Maintenance database, Username, Password. Clique em save
        
        Name: db-ecommerce
        Host: db-ecommerce-postgres
        Port: 5432
        Maintenance database: postgres
        Username: postgres
        Password: Postgres2023!
        
    d. Rode os scripts do banco, na pasta do projeto DbScripts os arquivos:
        - script_dbecommerce.sql
        - inserts.sql
6. Caso queira parar os containeres:
docker-compose stop ou ctrl+C
