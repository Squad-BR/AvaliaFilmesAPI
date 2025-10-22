# 🎬 AvaliaFilmesAPI - API de Avaliação de Filmes

Uma API RESTful moderna, desenvolvida com **ASP.NET Core 8**, projetada para gerenciar e fornecer dados de filmes, notas e avaliações. O nome da Solution é **AvaliaFilmesAPI**.

O projeto utiliza a **Arquitetura em Camadas** para garantir a separação de responsabilidades, manutenibilidade e escalabilidade do código.

### ✨ Tecnologias & Componentes

| Categoria | Componente | Descrição |
| :--- | :--- | :--- |
| **Plataforma** | .NET 8 | Ambiente de execução e desenvolvimento principal. |
| **Framework** | ASP.NET Core | Utilizado para a construção da API RESTful. |
| **Linguagem** | C# | Linguagem de programação. |
| **Padrão** | Arquitetura em Camadas | Organização do código em `Web`, `Business`, `Data` e `Domain`. |
| **Documentação**| Swagger / OpenAPI | Interface interativa para visualização e teste de endpoints. |
| **Gerenciamento** | NuGet | Gerenciador de dependências. |
| **Banco de Dados** | SQLite | Camada de persistência de dados. |
| **Testes** | xUnit | Utilizado no projeto `AvaliaFilmesAPI.Tests`. |

---

### 🏗️ Estrutura do Projeto

O código está organizado em uma Solution com cinco projetos (camadas), onde o arquivo principal da Solution (`AvaliaFilmesAPI.sln`) reside na pasta raiz:

| Projeto | Camada | Responsabilidade |
| :--- | :--- | :--- |
| `AvaliaFilmesAPI.Web` | **Apresentação** | Contém os **Controllers** e a configuração da aplicação (`Program.cs`). É a porta de entrada para todas as requisições HTTP. |
| `AvaliaFilmesAPI.Business` | **Regras de Negócio** | Implementa os **Serviços**. Concentra a lógica de negócios, validações e coordena o fluxo de dados. |
| `AvaliaFilmesAPI.Data` | **Acesso a Dados** | Implementa os **Repositórios** e o *Contexto de Banco de Dados* (EF Core). Trata da leitura e escrita (CRUD) das entidades. |
| `AvaliaFilmesAPI.Domain` | **Modelos** | Contém as **Entidades** (modelos de domínio), DTOs (Data Transfer Objects) e Interfaces. Define os contratos e a estrutura de dados do sistema. |
| `AvaliaFilmesAPI.Tests` | **Qualidade** | Projeto dedicado a Testes Unitários e de Integração. |

---

### 🚀 Começando

Estas instruções permitirão que você configure e execute o projeto em sua máquina local.

#### 1. Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download) ou superior.
* Um IDE compatível com .NET (Visual Studio 2022 ou VS Code).

#### 2. Configuração do Banco de Dados

* **Ajuste o Connection String:** Verifique e ajuste a string de conexão no arquivo `appsettings.json` do projeto `AvaliaFilmesAPI.Web`.
* **Rode as Migrations (Se aplicável):**

### 3. Clonagem e Execução
O processo de dotnet restore garante que todos os pacotes NuGet sejam baixados localmente, conforme listado nos arquivos .csproj.

# 1. Clonar o repositório (Substitua a URL pelo seu link do GitHub)
git clone [https://github.com/Squad-BR/AvaliaFilmesAPI.git](https://github.com/Squad-BR/AvaliaFilmesAPI.git)
cd AvaliaFilmesAPI

# 2. Restaurar dependências e compilar
dotnet restore

# 3. Executar o projeto Web
dotnet run --project AvaliaFilmesAPI.Web

A API estará em execução em https://localhost:7192.

📄 Documentação (Swagger UI)Após executar a API, a documentação interativa e navegável do Swagger estará disponível
:URL: https://localhost:7192/swagger/index.html

✅ Executando Testes
Para executar toda a suíte de testes unitários e de integração definidos na camada AvaliaFilmesAPI.Tests:
dotnet test
