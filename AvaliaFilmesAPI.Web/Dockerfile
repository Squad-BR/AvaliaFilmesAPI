# Estágio 1: Build (Compilação)
# Esta linha define a imagem base para compilar a aplicação .NET Core
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copia o arquivo .csproj (o arquivo de projeto) para restaurar as dependências
COPY ["AvaliaFilmesAPI.Web.csproj", "."]
RUN dotnet restore "AvaliaFilmesAPI.Web.csproj"

# 2. Copia o restante do seu código
COPY . .

# 3. Compila a aplicação no modo "Release"
RUN dotnet publish "AvaliaFilmesAPI.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ---

# Estágio 2: Runtime (Execução)
# Esta linha define a imagem base para rodar a aplicação (é mais leve)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# 4. Copia os arquivos compilados (somente o essencial)
COPY --from=build /app/publish .

# 5. Configura a porta que o Render fornece (necessário para o servidor Kestrel)
ENV ASPNETCORE_URLS=http://+:$PORT

# 6. Define o comando para iniciar a API
# *** ATENÇÃO: Substitua 'AvaliaFilmesAPI.dll' se o nome da sua DLL for diferente. ***
ENTRYPOINT ["dotnet", "AvaliaFilmesAPI.Web.dll"]