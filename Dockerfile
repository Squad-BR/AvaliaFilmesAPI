# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo da solução (.sln) e todos os arquivos .csproj para restauração
# O **/*/.csproj garante que todos os arquivos de projeto sejam copiados, permitindo o restore.
COPY *.sln .
COPY */*.csproj ./

# Restaura as dependências (agora a partir do nível da solução)
RUN dotnet restore

# Copia toda a solução para a imagem
COPY . .

# Compila e publica apenas o projeto Web
# *** AJUSTE O CAMINHO DE NOVO AQUI: ***
# Assumindo que seu projeto web está em uma subpasta chamada "AvaliaFilmesAPI.Web" dentro de uma pasta "src"
RUN dotnet publish "src/AvaliaFilmesAPI.Web/AvaliaFilmesAPI.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false


# ---

# Estágio 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:$PORT

# *** AJUSTE O NOME DA DLL (que agora é a DLL principal do projeto Web) ***
ENTRYPOINT ["dotnet", "AvaliaFilmesAPI.Web.dll"]