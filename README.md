
Projeto Lanchonete
=======
Repositório com o projeto do ambiente para o desafio Dextra.

Projeto desenvolvido com .NET Core 2.1 e Enityframework core 2.1 utilizando os padroes de Injeção de Depedencias(Para desacoplar as camadas e também permitir executar Mocks nos testes unitarios) e Repository

Documentação Swagger dos metodos da API disponiveis em https://localhost:5001/swagger/v1/swagger.json

Para executar o projeto, siga os seguintes passos:

Com o dotnet CLI instalado vá ate o diretorio do projeto Dextra.Lanchonete.Api e execute dotnet restore, para restaurar os pacotes nugets,
Editar o arquivo de configuração em 'API\Dextra.Lanchonete.Api\appsettings.json' e adicionar sua ConnectionString na tag DefaultConnection.
Após isso atualizar o banco de dados executando o comando
  dotnet ef database update
Em seguida execute o dotnet run para startar a API (na porta 5001)  

Os testes unitarios foram feitos utilizando o XUnit e a biblioteca Moq para conseguir Mocar os resultados, para executar os testes execute o comando no dotnet Cli: 'dotnet test'

Para executar o Front-end ir para a pasta /Client, fazer download das dependencias 'npm install' e com o Angular CLI intalado executar o ng server.
Tambem foi utilizado DI no projeto angular para acessar os serviços
