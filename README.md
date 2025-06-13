
# 🗓️ Agendamento

Sistema de agendamento de consultas médicas, desenvolvido com arquitetura DDD, Razor Pages como front-end, e APIs protegidas com autenticação JWT. O ambiente é totalmente containerizado via Docker Compose.

---

## 📦 Estrutura do Projeto

```
Agendamento/
├── docker-compose.yml
├── Agendamento.sln
├── Agendamento.Services.Api/         # Projeto principal com API + Razor Pages
├── Agendamento.Application/          # Camada de aplicação (use cases)
├── Agendamento.Domain/               # Entidades e contratos (DDD)
├── Agendamento.Infrastructure/       # Repositórios, conexões, Dapper
```

---

## 🚀 Como Rodar a Aplicação

### ✅ Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- Sistema operacional: Windows, Linux ou macOS

---

### ▶️ Passos para Executar

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/agendamento.git
cd agendamento
```

2. Suba os containers com Docker Compose:

```bash
docker-compose up --build
```

3. Acesse a aplicação:

- Front-end (Razor Pages): [http://localhost:777](http://localhost:777)
- Login: [http://localhost:777/Login](http://localhost:777/Login)
- Swagger (API): [http://localhost:777/swagger](http://localhost:777/swagger)

---

## 🔒 Autenticação

A aplicação usa **JWT (JSON Web Tokens)** para proteger as rotas da API.

- O token é salvo em cookie (HTTP Only).
- Logout remove o cookie do token.

---

## 🗄️ Banco de Dados

- SQL Server 2022 em container Docker.
- Script de inicialização é executado automaticamente (`/init-db/init.sql`).
- As credenciais padrão são:

```env
User: sa
Password: Your_password123
Database: AgendamentoDb
Login da Aplicação: admin@agendamento.com
Senha: senha123
```

---

## 📋 Funcionalidades

- ✅ Login com autenticação JWT.
- ✅ Cadastro de Paciente.
- ✅ Cadastro de Consulta com verificação de conflitos (horário, médico, paciente).
- ✅ Filtro de consultas com paginação.
- ✅ Middleware customizado para extração de token via cookie.

---

## 🧪 Endpoints

Acesse a documentação Swagger:  
[http://localhost:777/api/v1/agendamento/documentation/index.html](http://localhost:777/api/v1/agendamento/documentation/index.html)

---

## 🛠️ Tecnologias Utilizadas

- .NET 8
- Razor Pages
- Dapper
- SQL Server
- Docker + Docker Compose
- JWT Bearer Authentication

---

## 👨‍💻 Desenvolvimento

### Principais comandos

```bash
# Build manual
dotnet build

# Rodar a API (fora do docker)
cd Agendamento.Services.Api
dotnet run
```


## 📄 Licença

Este projeto é de uso pessoal/educacional.
