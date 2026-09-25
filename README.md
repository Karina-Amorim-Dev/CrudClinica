# 🏥 CrudClinica

**Sistema de Gerenciamento de Clínica desenvolvido com ASP.NET Core MVC e MySQL**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Latest-blue)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0%2B-orange)](https://www.mysql.com/)

## 📋 Descrição

CrudClinica é uma aplicação web para gerenciamento completo de clínicas e consultórios, desenvolvida com as melhores práticas de arquitetura MVC. O sistema oferece funcionalidades robustas para administrar pacientes, agendamentos, consultas e dados médicos.

## ✨ Funcionalidades

- 👥 **Gerenciamento de Pacientes** - Cadastro, atualização e exclusão de dados de pacientes
- 📅 **Agendamentos** - Sistema de agendamento de consultas com validação de disponibilidade
- 👨‍⚕️ **Gestão de Médicos** - Cadastro e gerenciamento de profissionais
- 📝 **Histórico de Consultas** - Registro detalhado de atendimentos
- 🔐 **Autenticação e Autorização** - Controle de acesso por perfil de usuário
- 📊 **Relatórios** - Geração de relatórios sobre pacientes e consultas
- 🔍 **Busca e Filtros** - Ferramentas avançadas de pesquisa

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Descrição |
|-----------|--------|-----------|
| **ASP.NET Core MVC** | 6.0+ | Framework web para desenvolvimento |
| **C#** | 10+ | Linguagem de programação |
| **MySQL** | 8.0+ | Banco de dados relacional |
| **Entity Framework Core** | Latest | ORM para acesso a dados |
| **HTML5** | - | Markup para interface |
| **CSS3** | - | Estilização de componentes |
| **JavaScript** | - | Interatividade no cliente |

## 📊 Composição do Código

```
HTML:       63.6%
C#:         34.7%
CSS:         1.5%
JavaScript:  0.2%
```

## 🚀 Instalação e Configuração

### Pré-requisitos

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)
- [Git](https://git-scm.com/downloads)
- Visual Studio 2022 ou VS Code com extensões C#

### Passos para Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/Karina-Amorim-Dev/CrudClinica.git
   cd CrudClinica
   ```

2. **Configure o banco de dados**
   - Crie um banco de dados MySQL:
     ```sql
     CREATE DATABASE crud_clinica;
     ```
   - Atualize a string de conexão em `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=crud_clinica;User=root;Password=sua_senha;"
       }
     }
     ```

3. **Restaure as dependências**
   ```bash
   dotnet restore
   ```

4. **Execute as migrações do banco de dados**
   ```bash
   dotnet ef database update
   ```

5. **Execute a aplicação**
   ```bash
   dotnet run
   ```

6. **Acesse a aplicação**
   - Abra seu navegador e acesse: `https://localhost:5001` ou `http://localhost:5000`

## 📁 Estrutura do Projeto

```
CrudClinica/
├── Controllers/           # Controladores MVC
├── Models/               # Modelos de dados
├── Views/                # Arquivos de view (HTML)
│   ├── Pacientes/
│   ├── Medicos/
│   ├── Consultas/
│   └── Shared/
├── Data/                 # Contexto do Entity Framework
├── wwwroot/              # Arquivos estáticos (CSS, JS, imagens)
│   ├── css/
│   ├── js/
│   └── images/
├── appsettings.json      # Configurações da aplicação
├── Program.cs            # Configuração da aplicação
└── CrudClinica.csproj    # Arquivo de projeto

```

## 🗄️ Modelo de Dados

### Principais Entidades

- **Paciente** - Informações pessoais e médicas do paciente
- **Médico** - Dados profissionais do médico
- **Consulta** - Registro de atendimentos
- **Agendamento** - Marcação de consultas
- **Usuário** - Credenciais e perfil de acesso

## 🔐 Segurança

- Autenticação via formulário padrão ASP.NET Core Identity
- Proteção contra CSRF (Cross-Site Request Forgery)
- Validação de entrada de dados no cliente e servidor
- Hash seguro de senhas
- Proteção de dados sensíveis no banco de dados

## 📖 Guia de Uso

### Para Administradores
1. Acesse o painel administrativo
2. Gerencie médicos e pacientes
3. Configure horários de atendimento
4. Visualize relatórios

### Para Recepcionistas
1. Realize agendamentos de consultas
2. Consulte disponibilidade dos médicos
3. Gerencie dados de pacientes

### Para Médicos
1. Visualize agenda de consultas
2. Registre histórico de atendimentos
3. Acesse dados dos pacientes

## 🧪 Testes

Para executar os testes (se aplicável):

```bash
dotnet test
```

## 📝 Padrões de Código

Este projeto segue as seguintes convenções:

- **Padrão MVC** - Separação clara entre Model, View e Controller
- **Entity Framework** - ORM para persistência de dados
- **Dependency Injection** - Injeção de dependências nativa do ASP.NET Core
- **Async/Await** - Programação assíncrona para melhor performance

## 🐛 Relatório de Bugs

Encontrou um bug? Abra uma [issue](https://github.com/Karina-Amorim-Dev/CrudClinica/issues) descrevendo:

1. O comportamento esperado
2. O comportamento atual
3. Passos para reproduzir
4. Ambiente (SO, versão .NET, etc.)

## 💡 Sugestões de Melhorias

Tem uma ideia para melhorar? Abra uma [discussion](https://github.com/Karina-Amorim-Dev/CrudClinica/discussions) ou crie uma [issue](https://github.com/Karina-Amorim-Dev/CrudClinica/issues) com a tag `enhancement`.

## 🤝 Contribuindo

Contribuições são bem-vindas! Por favor:

1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

## 👨‍💻 Autor

**Karina Amorim**

- GitHub: [@Karina-Amorim-Dev](https://github.com/Karina-Amorim-Dev)
- Email: [seu email aqui]

## 🙏 Agradecimentos

- Microsoft por ASP.NET Core
- Comunidade Open Source
- Todos os contribuidores

## 📚 Recursos Úteis

- [Documentação ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/)
- [Documentação Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [MySQL Documentation](https://dev.mysql.com/doc/)
- [C# Documentation](https://docs.microsoft.com/pt-br/dotnet/csharp/)

## 📞 Suporte

Para suporte, entre em contato através das [issues](https://github.com/Karina-Amorim-Dev/CrudClinica/issues) do repositório.

---

**Desenvolvido com ❤️ por Karina Amorim**
