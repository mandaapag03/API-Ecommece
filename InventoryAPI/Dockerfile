FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
LABEL maintainer "Amanda Pagani <paganiamanda791@gmail.com>"
WORKDIR /App

COPY . ./

WORKDIR /App/InventoryAPI
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App/InventoryAPI
COPY --from=build-env /App/InventoryAPI/out .
ENTRYPOINT [ "dotnet", "InventoryAPI.dll" ]
