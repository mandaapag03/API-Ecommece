FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
LABEL maintainer "Amanda Pagani <paganiamanda791@gmail.com>"
WORKDIR /App

COPY . ./

WORKDIR /App/VerifyNullableObject
RUN dotnet restore ../VerifyNullableObject.csproj
RUN dotnet publish -c Release -o out ../VerifyNullableObject.csproj

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App/VerifyNullableObject
COPY --from=build-env /App/VerifyNullableObject/out .
ENTRYPOINT [ "dotnet", "VerifyNullableObject.dll" ]
