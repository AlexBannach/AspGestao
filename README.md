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

> Adicionar referencia no projeto

```
dotnet add Gestao.Client/Gestao.Client.csproj reference Gestao.Domain/Gestao.Domain.csproj

dotnet add Gestao/Gestao.csproj reference Gestao.Client/Gestao.Client.csproj
dotnet add Gestao/Gestao.csproj reference Gestao.Domain/Gestao.Domain.csproj
```

# Criação de Branch

```
git checkout -b [SEU NOME]
```

> Após criar a branch você deve subir os novos arquivos

```
git add .
git commit -m "Mensangem da alteração"
git push -u origin [SEU NOME]
```

> Após finalizar este processo, você estará trabalhando diretamente na sua branch, sem alterar a branch main, que seria a principal, e sem prejudicar os outros que estão trabalhando no mesmo projeto.
