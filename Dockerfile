# https://hub.docker.com/_/microsoft-dotnet
ARG VARIANT=7.0.401-bookworm-slim-amd64
FROM mcr.microsoft.com/dotnet/sdk:${VARIANT} AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY API/*.csproj API/
COPY Application/*.csproj Application/
COPY Dominio/*.csproj Dominio/
COPY Persistencia/*csproj Persistencia/
RUN dotnet restore API/API.csproj

# copy and build app and libraries
COPY API/ API/
COPY Application/ Application/
COPY Dominio/ Dominio/
COPY Persistencia/ Persistencia/

FROM build AS publish
WORKDIR /source/API
RUN dotnet publish --no-restore -o /app

# final stage/image
FROM ubuntu/dotnet-aspnet:7.0-23.04_edge
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API.dll"]
