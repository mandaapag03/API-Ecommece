FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
LABEL maintainer "Amanda Pagani <paganiamanda791@gmail.com>"
WORKDIR /App

COPY . ./

FROM verify-nullable-object-image
WORKDIR /App/UserAPI
RUN dotnet restore ../UserAPI.csproj
RUN dotnet publish -c Release -o out ../UserAPI.csproj

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App/UserAPI
COPY --from=build-env /App/UserAPI/out .
ENTRYPOINT [ "dotnet", "UserAPI.dll" ]
