# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./Shared.Contracts/Shared.Contracts.csproj ./Shared.Contracts/
COPY ./IdentityService.Api/IdentityService.Api.csproj ./IdentityService.Api/
RUN dotnet restore ./IdentityService.Api/IdentityService.Api.csproj

COPY . .
WORKDIR /src/IdentityService.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "IdentityService.Api.dll"]
