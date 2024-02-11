FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
LABEL maintainer "Amanda Pagani <paganiamanda791@gmail.com>"
WORKDIR /App

COPY . ./

WORKDIR /App/ProductAPI
RUN dotnet restore ./ProductAPI.csproj
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App/ProductAPI
COPY --from=build-env /App/ProductAPI/out .
ENTRYPOINT [ "dotnet", "ProductAPI.dll" ]
