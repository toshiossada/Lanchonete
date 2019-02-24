Dextra Challenge
Repositório com o projeto do ambiente para o desafio Dextra.

Projeto desenvolvido com .NET Core 2.1 e Enityframework core 2.1 utilizando os padroes de Injeção de Depedencias(Para desacoplar as camadas e também permitir executar Mocks nos testes unitarios) e Repository

Documentação Swagger do metodos da API disponiveis em https://localhost:5001/swagger/v1/swagger.json

Para executar o projeto, siga os seguintes passos:

Com o dotnet CLI instalado vá ate o diretorio do projeto Dextra.Lanchonete.Api e execute dotnet restore, para restaurar os pacotes nugets e em seguida execute o dotnet run para startar a API (na porta 5001)

Os testes unitarios foram feitos utilizando o XUnit e a biblioteca Moq para conseguir Mocar os resultados
