# Como subir a API com docker

## Para pasta OhMyDog-API

docker image build -t oh-my-dog-api .

docker container run --name ohmydogapi -d -p 8000:80 oh-my-dog-api

Oh My Dog API Swagger - http://localhost:8000/swagger/index.html