# TaskManagement

Task Management API
Uma API robusta para gerenciamento de tarefas pessoais, desenvolvida em C# / .NET. O projeto foca na organização de afazeres diários com categorização por prioridade e status, utilizando uma arquitetura em camadas para melhor escalabilidade e manutenção.

🚀 Como Executar
Clone o repositório

Execute o projeto: Ao rodar a aplicação, o banco de dados SQLite será gerado automaticamente na raiz do projeto (ou no caminho configurado no DbContext) graças ao uso do EnsureCreated().

Documentação: A interface do Swagger abrirá automaticamente em: http://localhost:7088/swagger/index.html (verifique a porta configurada no seu ambiente).

🛠️ Tecnologias Utilizadas
.NET 8/9 (C#)

Entity Framework Core (ORM)

SQLite (Banco de dados leve e local)

FluentValidation (Validações de domínio)

Swagger (OpenAPI) (Documentação e testes)

📌 Endpoints
Tarefas (/api/Task)
POST /api/Task: Cria uma nova tarefa.

GET /api/Task: Retorna todas as tarefas cadastradas.

GET /api/Task/{id}: Busca os detalhes de uma tarefa específica.

PUT /api/Task/{id}: Atualiza informações de uma tarefa existente.

DELETE /api/Task/{id}: Remove uma tarefa do sistema.

⚖️ Regras de Negócio e Validações
Validação de Data (DueDate): O sistema utiliza FluentValidation para garantir que uma tarefa não seja criada com uma data de vencimento no passado.

Prioridades e Status: As tarefas são categorizadas por tipos definidos (PriorityType e TaskStatus), garantindo integridade nos dados armazenados.

Persistência Automática: Configurado para criar o esquema do banco de dados automaticamente no primeiro acesso, eliminando a necessidade inicial de executar Migrations manuais para testes rápidos.

🏗️ Estrutura do Projeto
O projeto segue uma divisão em camadas para separar responsabilidades:

API: Controladores e configuração de entrada.

Application: Lógica de uso (Use Cases) e regras de validação.

Domain: Entidades de negócio e interfaces.

Infrastructure: Acesso a dados e configuração do SQLite.