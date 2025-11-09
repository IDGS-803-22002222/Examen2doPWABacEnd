# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivo del proyecto y restaurar dependencias
COPY ["Examen2doPWA/Examen2doPWA.csproj", "Examen2doPWA/"]
RUN dotnet restore "Examen2doPWA/Examen2doPWA.csproj"

# Copiar todo y compilar
COPY . .
WORKDIR "/src/Examen2doPWA"
RUN dotnet publish "Examen2doPWA.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Examen2doPWA.dll"]
