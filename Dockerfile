FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
LABEL maintainer "Amanda Pagani <paganiamanda791@gmail.com>"
WORKDIR /App

COPY . ./

WORKDIR /App/OhMyDogAPI
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App/OhMyDogAPI
COPY --from=build-env /App/OhMyDogAPI/out .
WORKDIR /App/OhMyDogAPI/OhMyDogAPI/
ENTRYPOINT [ "dotnet", "OhMyDogAPI.dll" ]
