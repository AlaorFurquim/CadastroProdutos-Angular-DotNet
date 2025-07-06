# 📦 Cadastro de Produtos - Angular + .NET

Este projeto é uma aplicação completa de cadastro de produtos, desenvolvida com **Angular** no frontend e **.NET com Clean Architecture** no backend.

---

## 🚀 Tecnologias Utilizadas

### 🔧 Backend (.NET)
- ASP.NET Core
- Clean Architecture (Domain, Application, Infrastructure, API)
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger

### 🎨 Frontend (Angular)
- Angular 20+
- Standalone Components
- Bootstrap
- PrimeNG (em progresso)
- Consumo de API REST
- Reactive Forms
- Angular Router

---

## 📁 Estrutura do Projeto

ProdutosAPI/
│
├── Cadastro-Produtos-Back => API com .NET e Clean Architecture
│
└── produtos-web-Front => Frontend Angular

## 💻 Como Executar

### 🔙 Backend

```bash
cd Cadastro-Produtos-Back
dotnet restore
dotnet ef database update
dotnet run
