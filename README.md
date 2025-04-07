## Comando para executar o projeto

```
dotnet watch run
```

## Comandos para Migrations

### Criar uma nova Migration

> Para criar uma nova migration, utilize o seguinte comando:

```
dotnet ef migrations add NomeDaMigration
```

### Remover a última Migration

> Para remover a última migration, utilize o seguinte comando:

```
dotnet ef migrations remove
```

### Aplicar Migrations ao Banco de Dados

> Para aplicar todas as migrations pendentes ao banco de dados, utilize o seguinte comando:

```
dotnet ef database update
```

### Reverter para uma Migration específica

> Para reverter o banco de dados para uma migration específica, utilize o seguinte comando:

```
dotnet ef database update NomeDaMigration
```

### Listar todas as Migrations

> Para listar todas as migrations aplicadas e pendentes, utilize o seguinte comando:

```
dotnet ef migrations list
```

### Criar uma nova coluna na tabela

```
dotnet ef migrations add AddColumnsNameBirthToAspNetUsers --context ApplicationDbContext --output-dir Data/Migrations
```

> O que foi instalado

```
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.entityframeworkcore.Design
dotnet add package FluentValidation.AspNetCore
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

> Para criar o projeto

```
dotnet new mvc -o Nome_do_projeto
```
