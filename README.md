
# Floodian API
**RM555997 - Caio Marques**  
**RM558640 - Caio Amarante**
**RM556325 - Felipe Camargo Revolta e Souza**  

## Links

- **Link da Apresentação:** [Link do vídeo](URL_DA_DEMONSTRACAO)
- **Vídeo Pitch:** [Link do vídeo](https://youtu.be/Pg6Rxiwu_0o)


## Descrição

A **Floodian API** é uma API RESTful desenvolvida em **.NET** para monitoramento e alerta de enchentes em áreas urbanas e rurais. A API permite gerenciar **sensores**, e **usuários**. Com ela, é possível realizar operações CRUD completas nas entidades **Sensor**, e **Usuario**.
## Configuração

### String de Conexão
No arquivo `appsettings.json`, ajuste a seção **ConnectionStrings** para configurar a string de conexão com o banco de dados:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FloodianDb;User Id=SEU_USUARIO;Password=SUA_SENHA;"
  }
}
```

### Dependências
Execute os seguintes comandos no terminal para adicionar as dependências necessárias:

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Migrations

Depois de configurar o banco de dados e as dependências, crie as migrations e aplique-as:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Executar a API

Para rodar a aplicação, utilize o comando:

```bash
dotnet run
```

## Endpoints

Base URL: `http://localhost:5030/api`

### Sensores

| Método | Rota            | Descrição                     | Body (JSON)                                                                 |
|--------|-----------------|-------------------------------|-----------------------------------------------------------------------------|
| GET    | /sensors        | Lista todos os sensores       | —                                                                           |
| GET    | /sensors/{id}   | Retorna sensor por ID         | —                                                                           |
| POST   | /sensors        | Cria um novo sensor           | `{ "numeroSerie": "SENSOR001", "limiteAlerta": 80, "intervaloHoras": 6, "localizacaoId": 1 }` |
| PUT    | /sensors/{id}   | Atualiza sensor existente     | Mesmo schema do POST                                                        |
| DELETE | /sensors/{id}   | Remove um sensor              | —                                                                           |


### Usuários

| Método | Rota              | Descrição                      | Body (JSON)                                                                                               |
|--------|-------------------|--------------------------------|-----------------------------------------------------------------------------------------------------------|
| GET    | /usuarios         | Lista todos os usuários        | —                                                                                                         |
| GET    | /usuarios/{id}    | Retorna usuário por ID         | —                                                                                                         |
| POST   | /usuarios         | Cria um novo usuário           | `{ "nome": "João Silva", "email": "joao@ex.com", "telefone": "123456789", "tipoUsuario": "Admin", "senha": "senha123" }` |
| PUT    | /usuarios/{id}    | Atualiza usuário existente     | Mesmo schema do POST                                                                                      |
| DELETE | /usuarios/{id}    | Remove um usuário              | —                                                                                                         |


## Testes

Você pode testar todos os endpoints utilizando o **Swagger UI**, que estará disponível ao rodar a aplicação. Para isso, basta acessar `http://localhost:5030/swagger` no navegador após iniciar o servidor.

A API já está configurada para aceitar interações via Swagger para facilitar os testes.

## Conclusão

A **Floodian API** oferece uma solução robusta para o monitoramento e controle de enchentes, com uma arquitetura limpa e utilização de boas práticas de desenvolvimento. Ela pode ser facilmente extendida para se adaptar a novos requisitos, como integração com sistemas meteorológicos externos e dispositivos IoT para medição de água em tempo real.

