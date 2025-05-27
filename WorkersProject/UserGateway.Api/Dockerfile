FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./UserGateway.Api/UserGateway.Api.csproj ./UserGateway.Api/
COPY ./Shared.Contracts/Shared.Contracts.csproj ./Shared.Contracts/
RUN dotnet restore ./UserGateway.Api/UserGateway.Api.csproj

COPY . .
WORKDIR /src/UserGateway.Api
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "UserGateway.Api.dll"]
