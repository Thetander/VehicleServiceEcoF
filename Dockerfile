# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos de proyecto
COPY ["src/VehicleService.API/VehicleService.API.csproj", "src/VehicleService.API/"]
COPY ["src/VehicleService.Domain/VehicleService.Domain.csproj", "src/VehicleService.Domain/"]
COPY ["src/VehicleService.Persistence/VehicleService.Persistence.csproj", "src/VehicleService.Persistence/"]

# Copiar todo el código fuente
COPY . .

# Cambiar al directorio del proyecto API
WORKDIR "/src/src/VehicleService.API"

# Restaurar dependencias
RUN dotnet restore

# Compilar
RUN dotnet build -c Release -o /app/build

# Publicar
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "VehicleService.API.dll"]