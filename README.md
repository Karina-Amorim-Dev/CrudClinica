# 🏥 CrudClinica - Sistema de Gerenciamento de Clínica

> **Aplicação Web Moderna** para gerenciamento completo de clínicas e consultórios, desenvolvida com **ASP.NET Core MVC** e **MySQL**. Um projeto full-stack que demonstra domínio em desenvolvimento backend, frontend e arquitetura MVC.

[![Status](https://img.shields.io/badge/Status-Ativo-brightgreen)]()
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0%2B-blue?logo=dotnet)]()
[![MySQL](https://img.shields.io/badge/MySQL-8.0%2B-orange?logo=mysql)]()
[![License](https://img.shields.io/badge/License-MIT-green)]()

---

## 🎯 Sobre o Projeto

CrudClinica é uma solução empresarial completa para gerenciamento de clínicas e consultórios. O projeto foi desenvolvido seguindo **boas práticas de engenharia de software**, padrões de design e arquitetura limpa, demonstrando competências profissionais em:

- ✅ Desenvolvimento backend robusto com ASP.NET Core
- ✅ Integração com banco de dados relacional (MySQL)
- ✅ Arquitetura MVC bem estruturada
- ✅ Interface de usuário responsiva e intuitiva
- ✅ Tratamento de segurança e autenticação
- ✅ Boas práticas de código limpo

---

## 🚀 Principais Funcionalidades

| Funcionalidade | Descrição |
|---|---|
| 👥 **Gestão de Pacientes** | CRUD completo com validação de dados e histórico |
| 📅 **Agendamentos** | Sistema inteligente com validação de disponibilidade |
| 👨‍⚕️ **Gerenciamento de Médicos** | Cadastro, especialidades e horários |
| 📋 **Consultas e Registros** | Documentação detalhada de atendimentos |
| 🔐 **Autenticação** | Sistema de login com controle de perfis |
| 📊 **Relatórios** | Geração de relatórios de pacientes e atendimentos |
| 🔍 **Busca Avançada** | Filtros e busca por múltiplos critérios |

---

## 🛠️ Stack Tecnológico

### Backend
- **ASP.NET Core MVC 6.0+** - Framework web moderno e performático
- **C# 10+** - Linguagem de programação estaticamente tipada
- **Entity Framework Core** - ORM para acesso a dados
- **Dependency Injection** - Padrão de injeção de dependências nativa

### Banco de Dados
- **MySQL 8.0+** - Banco relacional confiável e escalável
- **Migrations** - Controle de versão do schema

### Frontend
- **HTML5** - Markup semântico e acessível
- **CSS3** - Estilização moderna e responsiva
- **JavaScript** - Interatividade no cliente
- **Bootstrap** (ou similar) - Framework CSS responsivo

### Segurança
- Validação de entrada (client + server)
- Proteção CSRF
- Hash de senhas com algoritmos seguros
- Controle de acesso por perfil

---

## 📊 Composição do Código

```
HTML       ████████████████████████████████████████████ 63.6%
C#         █████████████████████ 34.7%
CSS        ██ 1.5%
JavaScript ▌ 0.2%
```

---

## 🏗️ Arquitetura do Projeto

```
CrudClinica/
│
├── 📂 Controllers/              # Camada de Controle
│   ├── PacientesController.cs
│   ├── MedicosController.cs
│   ├── ConsultasController.cs
│   └── AgendamentosController.cs
│
├── 📂 Models/                   # Entidades de Domínio
│   ├── Paciente.cs
│   ├── Medico.cs
│   ├── Consulta.cs
│   └── Agendamento.cs
│
├── 📂 Views/                    # Camada de Apresentação
│   ├── Pacientes/
│   ├── Medicos/
│   ├── Consultas/
│   └── Shared/
│
├── 📂 Data/                     # Contexto EF Core
│   └── ApplicationDbContext.cs
│
├── 📂 wwwroot/                  # Arquivos Estáticos
│   ├── css/
│   ├── js/
│   └── images/
│
├── 📄 appsettings.json          # Configurações
├── 📄 Program.cs                # Setup da Aplicação
└── 📄 CrudClinica.csproj        # Arquivo de Projeto
```

---

## ⚡ Quick Start

### Pré-requisitos
- .NET SDK 6.0+
- MySQL Server 8.0+
- Visual Studio 2022 / VS Code

### Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/Karina-Amorim-Dev/CrudClinica.git
   cd CrudClinica
   ```

2. **Configure o banco de dados**
   
   Crie o banco no MySQL:
   ```sql
   CREATE DATABASE crudclinica;
   ```

   Atualize `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=crudclinica;User=root;Password=sua_senha;"
     }
   }
   ```

3. **Instale dependências e execute migrações**
   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. **Rode a aplicação**
   ```bash
   dotnet run
   ```

   Acesse em: `http://localhost:5000` ou `https://localhost:5001`

---

## 💡 Conceitos Aplicados

### Padrões de Design
- ✅ **MVC** - Separação clara de responsabilidades
- ✅ **Repository Pattern** - Abstração de acesso a dados
- ✅ **Dependency Injection** - Baixo acoplamento
- ✅ **SOLID Principles** - Código extensível e mantível

### Boas Práticas
- ✅ Validação robusta (client + server)
- ✅ Async/Await para operações assíncronas
- ✅ Tratamento de exceções adequado
- ✅ Comentários e documentação de código
- ✅ Naming conventions claras e consistentes

### Segurança
- ✅ Proteção contra SQL Injection (via EF Core)
- ✅ CSRF Token validation
- ✅ Autenticação e autorização
- ✅ Dados sensíveis protegidos

---

## 🎓 O que Este Projeto Demonstra

Como desenvolvedor, este projeto mostra:

- 🎯 **Competência Técnica** - Domínio de ASP.NET Core e arquitetura MVC
- 🎯 **Engenharia de Software** - Aplicação de padrões e boas práticas
- 🎯 **Full-Stack** - Desenvolvimento completo (backend, banco de dados, frontend)
- 🎯 **Atenção a Detalhes** - UI/UX intuitiva e responsiva
- 🎯 **Segurança** - Implementação de práticas seguras
- 🎯 **Profissionalismo** - Código limpo e bem organizado

---

## 📈 Potenciais Melhorias

- [ ] Implementar testes unitários com xUnit
- [ ] Adicionar autenticação JWT
- [ ] Integração com API REST
- [ ] Dashboard com gráficos (Chart.js)
- [ ] Sistema de notificações
- [ ] Upload de documentos (prontuário eletrônico)
- [ ] Mobile app com tecnologia similar

---

## 👤 Autor

**Karina Amorim**

Desenvolvedora Full-Stack | ASP.NET Core | C# | MySQL | Web Development

- 🔗 [GitHub](https://github.com/Karina-Amorim-Dev)
- 💼 [LinkedIn](www.linkedin.com/in/karina-amorim-1a0351345) 
- 📧 karina.amorim.etec@gmail.com

---

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

## 🙏 Recursos & Referências

- [ASP.NET Core Documentation](https://docs.microsoft.com/pt-br/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [MySQL Documentation](https://dev.mysql.com/doc/)
- [C# Best Practices](https://docs.microsoft.com/pt-br/dotnet/csharp/)

---

**Desenvolvido com dedicação e atenção aos detalhes** ⚙️✨
