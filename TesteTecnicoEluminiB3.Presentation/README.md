# 📌 TesteTecnicoEluminiB3

Projeto desenvolvido como teste técnico contendo:

-   🔹 Backend em .NET Framework 4.8 (Web API)
-   🔹 Camada de Application/Domain com regra de negócio
-   🔹 Frontend em Angular
-   🔹 Testes unitários com xUnit

------------------------------------------------------------------------

# 📁 Estrutura da Solução

TesteTecnicoEluminiB3 
│
├── TesteTecnicoEluminiB3.Services.Api → API Web (.NET Framework 4.8) 
├── TesteTecnicoEluminiB3.Application → Regras de negócio 
├── TesteTecnicoEluminiB3.Tests → Testes unitários (xUnit) 
└── frontend (Angular) → Interface do usuário

------------------------------------------------------------------------

# ✅ Requisitos

## Backend

-   Visual Studio 2019 ou superior
-   .NET Framework 4.8
-   NuGet restore habilitado

## Frontend

-   Node.js (v16+ recomendado)
-   Angular CLI
-   npm ou yarn

------------------------------------------------------------------------

# 🌐 Como Executar o Frontend (Angular)

1.  Abra o terminal na pasta raiz do seu projeto Angular - seuRepositório/TesteTecnicoEluminiB3\TesteTecnicoEluminiB3.Presentation

2.  Instale as dependências: npm install

------------------------------------------------------------------------

# 🚀 Como Executar o Backend

1.  Abra a solução no Visual Studio
2.  Clique com botão direito na solução e selecione propriedades
3.  Marque a opção 'Vários projetos de inicialização'
4.  Defina os projetos como Startup Project na ordem abaixo:
    TesteTecnicoEluminiB3.Presentation
    TesteTecnicoEluminiB3.Services.Api
5.  Execute: Ctrl + F5 ou F5

A API será iniciada localmente (normalmente via IIS Express).

------------------------------------------------------------------------

# 🧪 Como Executar os Testes (xUnit)

O projeto de testes é: TesteTecnicoEluminiB3.Tests

### Via Visual Studio:

1.  Vá em Test Explorer
2.  Clique em Run All

### Via CLI (opcional):

dotnet test

Certifique-se de que os pacotes estão instalados: - xunit -
xunit.runner.visualstudio - Microsoft.NET.Test.Sdk

------------------------------------------------------------------------

# 🧪 Testes do Angular

Para executar testes unitários:
Abra o terminal na pasta raiz do seu projeto Angular e digite:
ng test

Isso executará os testes com Karma + Jasmine.

------------------------------------------------------------------------

# 📌 Funcionalidade Principal

O sistema realiza: 
- Cálculo de rendimento de investimento CDB 
- Cálculo de valor bruto 
- Cálculo de valor líquido com aplicação de imposto
regressivo

------------------------------------------------------------------------

# 🧠 Arquitetura Utilizada

-   Separação por camadas
-   Application Layer com regra de negócio
-   API apenas como camada de exposição
-   Injeção de dependência
-   Testes unitários isolando regras de negócio
-   Estrutura preparada para futura migração para .NET 6+

------------------------------------------------------------------------

# 📈 Possíveis Melhorias

-   Adicionar testes de integração
-   Adicionar validação mais robusta de DTOs
-   Melhorar cobertura de testes Angular
-   Adicionar pipeline CI/CD

------------------------------------------------------------------------

# 👨‍💻 Autor
Marcos Paulo do Nascimento
Projeto desenvolvido como parte de avaliação técnica.
