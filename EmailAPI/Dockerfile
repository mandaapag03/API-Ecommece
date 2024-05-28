FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
LABEL maintainer "Amanda Pagani <paganiamanda791@gmail.com>"
WORKDIR /App

COPY . ./

WORKDIR /App

ENV ADM__EMAIL=${ADM__EMAIL}
ENV EMAIL__PASSWORD=${EMAIL__PASSWORD}

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT [ "dotnet", "EmailAPI.dll" ]
