# TaskManager - API de Gerenciamento de Tarefas

Uma API moderna construída em **ASP.NET Core 10** para gerenciamento de projetos e tarefas, seguindo princípios de **Clean Architecture** e boas práticas de desenvolvimento.

## 📋 Características

- ✅ Arquitetura em Camadas (Clean Architecture)
- ✅ API RESTful com Controladores
- ✅ Banco de dados SQL com Entity Framework Core
- ✅ Padrão Repository para acesso a dados
- ✅ DTOs para transferência de dados
- ✅ Enums para Status e Prioridade de Tarefas
- ✅ Migrações de banco de dados

## 🏗️ Estrutura do Projeto

```
TaskManager/
├── TaskManager.API/           # Camada de Apresentação (Controllers, Program.cs)
│   ├── Controllers/           # Controladores REST
│   │   ├── ProjectsController.cs
│   │   └── TasksController.cs
│   ├── Properties/
│   ├── Program.cs             # Configuração da aplicação
│   ├── appsettings.json       # Configurações
│   └── TaskManager.API.http   # Requisições HTTP de teste
│
├── TaskManager.Application/   # Camada de Aplicação (Services, DTOs)
│   ├── Services/              # Lógica de negócio
│   │   ├── ProjectService.cs
│   │   └── TaskService.cs
│   ├── DTOs/                  # Data Transfer Objects
│   │   ├── ProjectDto.cs
│   │   └── TaskDto.cs
│   └── Interfaces/            # Contratos de serviço
│       ├── IProjectRepository.cs
│       └── ITaskRepository.cs
│
├── TaskManager.Domain/        # Camada de Domínio (Entities, Enums)
│   ├── Entities/              # Modelos de negócio
│   │   ├── Project.cs
│   │   └── TaskItem.cs
│   └── Enums/                 # Enumerações
│       ├── TaskPriority.cs
│       └── TaskStatus.cs
│
├── TaskManager.Infrastructure/ # Camada de Infraestrutura (Data Access)
│   ├── Data/                  # Contexto do banco de dados
│   │   ├── AppDbContext.cs
│   │   └── AppDbContextFactory.cs
│   ├── Migrations/            # Migrações do banco de dados
│   └── Repositories/          # Implementações do padrão Repository
│       ├── ProjectRepository.cs
│       └── TaskRepository.cs
│
└── TaskManager.slnx           # Solution file
```

## 🚀 Começando

### Pré-requisitos

- **.NET 10 SDK** ou superior ([Download](https://dotnet.microsoft.com/download))
- **SQL Server** (LocalDB, Express ou outro)
- **Visual Studio Code** ou **Visual Studio** (recomendado)

### Instalação

1. **Clone o repositório**
   ```bash
   git clone <seu-repositorio>
   cd "Projeto backend C#"
   ```

2. **Restaure as dependências**
   ```bash
   dotnet restore
   ```

3. **Configure a conexão com o banco de dados**
   
   Edite `TaskManager.API/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=TaskManagerDb;Trusted_Connection=true;"
     }
   }
   ```

4. **Execute as migrações**
   ```bash
   dotnet ef database update --project TaskManager.Infrastructure
   ```

5. **Execute a aplicação**
   ```bash
   dotnet run --project TaskManager.API
   ```

   A API estará disponível em: `https://localhost:5001`

## 📚 Endpoints da API

### Projetos

- `GET /api/projects` - Listar todos os projetos
- `GET /api/projects/{id}` - Obter projeto por ID
- `POST /api/projects` - Criar novo projeto
- `PUT /api/projects/{id}` - Atualizar projeto
- `DELETE /api/projects/{id}` - Deletar projeto

### Tarefas

- `GET /api/tasks` - Listar todas as tarefas
- `GET /api/tasks/{id}` - Obter tarefa por ID
- `POST /api/tasks` - Criar nova tarefa
- `PUT /api/tasks/{id}` - Atualizar tarefa
- `DELETE /api/tasks/{id}` - Deletar tarefa

## 📦 Dependências Principais

- **ASP.NET Core** - Framework web
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados

## 🔧 Tecnologias Utilizadas

- C# 13
- ASP.NET Core 10
- Entity Framework Core
- Clean Architecture
- Repository Pattern

## 📝 Modelos de Dados

### Project (Projeto)
```csharp
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<TaskItem> Tasks { get; set; }
}
```

### TaskItem (Tarefa)
```csharp
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime DueDate { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}
```

### TaskStatus (Enumeração)
- `Pending` - Pendente
- `InProgress` - Em Progresso
- `Completed` - Concluída

### TaskPriority (Enumeração)
- `Low` - Baixa
- `Medium` - Média
- `High` - Alta

## 🧪 Testes

Para testar os endpoints, utilize o arquivo `TaskManager.API/TaskManager.API.http` no VS Code com a extensão **REST Client**.

## 👨‍💻 Contribuindo

Contribuições são bem-vindas! Para contribuir:

1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para detalhes.

## 📧 Contato

Para dúvidas ou sugestões, entre em contato através de issues no repositório.

---

**Última atualização:** Abril de 2026
