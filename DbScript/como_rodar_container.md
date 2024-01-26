# Como subir a API com docker

## Para pasta OhMyDog-API

docker image build -t oh-my-dog-test:1.0 .

docker container run --name ohmydogapi -d -p 8000:80 oh-my-dog-test:1.0

Oh My Dog API Swagger - http://localhost:8000/swagger/index.html