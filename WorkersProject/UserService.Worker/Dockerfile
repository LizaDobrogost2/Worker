FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./Shared.Contracts/Shared.Contracts.csproj ./Shared.Contracts/
COPY ./UserService.Worker/UserService.Worker.csproj ./UserService.Worker/

RUN dotnet restore ./UserService.Worker/UserService.Worker.csproj

COPY . .
WORKDIR /src/UserService.Worker
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "UserService.Worker.dll"]
