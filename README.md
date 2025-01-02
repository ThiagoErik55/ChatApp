# 🔧 Sistema de Chat e Mensagens

## Descrição Geral
Um sistema para troca de mensagens em tempo real, permitindo comunicação entre usuários, com funcionalidades de envio/recebimento de mensagens, criação de conversas, armazenamento de histórico e notificação de novas mensagens. 

## Estrutura do Projeto
- **ChatApp.Model**: Classes de domínio e enums.
- **ChatApp.Persistence**: Persistência de dados com ADO.NET e EF Core.
- **ChatApp.Business**: Lógica de negócios.
- **ChatApp.MAUI**: Interface gráfica móvel com .NET MAUI.
- **ChatApp.UI.ConsoleApp**: Interface de linha de comando.
- **ChatApp.UI.WebApp**: Interface gráfica para navegadores.

## Como Executar
1. Clone o repositório:
   ```bash
   git clone <url-do-repositorio>
   cd ChatApp
   ```
2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```
3. Configure o banco de dados:
   ```bash
   dotnet ef database update --project ChatApp.Persistence
   ```
4. Execute a interface desejada:
   - **Console App**:
     ```bash
     dotnet run --project ChatApp.UI.ConsoleApp
     ```
   - **Web App**:
     ```bash
     dotnet run --project ChatApp.UI.WebApp
     ```

## Funcionalidades
- Registro e autenticação de usuários.
- Envio e leitura de mensagens.
- Criação e gerenciamento de conversas.
- Notificações em tempo real.

---

✅ **Pronto para iniciar o desenvolvimento e testes!**

