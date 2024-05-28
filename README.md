# OhMyDog-API
**Grupo**:
- Amanda Pagani Lima : 2200564 - (ADS 5A NOITE)
- Bruno Vinícius Alves Santos : 2100913 - (ADS 5B NOITE)
- Evany Marianne Alves Mota Folli : 2200798 - (ADS 5A NOITE)
- Gustavo Emynem Izidre Ribeiro :  2200826 - (ADS 5A NOITE)
- Gustavo Farias Freire : 2201292 - (ADS 5A NOITE)
- Michel Vacari Cruz : 2200102 - (ADS 5A NOITE)

# Para rodar o docker compose
Requisitos: 
- Ter o docker instalado. Caso vc tenha Windows, acesse meu tutorial de instalação

https://www.instagram.com/p/C2tlM4wOPa2/?utm_source=ig_web_copy_link&igsh=MzRlODBiNWFlZA==

1. faça o clone do projeto:
   
`git clone https://github.com/mandaapag03/OhMyDog-API.git`

3. Entre com o cmd na pasta do projeto e digite:
   
`make up` ou apenas `make`

5. Acesse as apis nas URLs:

User API:
http://localhost:5010/swagger/index.html

Product API:
http://localhost:5051/swagger/index.html

Promotion API:
http://localhost:5069/swagger/index.html

Inventory API:
http://localhost:5082/swagger/index.html

Order API:
http://localhost:5053/swagger/index.html

Payment API:
http://localhost:5228/swagger/index.html

Administrator API:
http://localhost:5143/swagger/index.html

Email API:
http://localhost:5079/swagger/index.html


4. Acessar banco de dados
   
    a. Acesse o PgAdmin no link: http://localhost:15432/
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
`make down`
