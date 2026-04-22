# 🍔 GoodHamburger

Projeto simples de cardápio para hamburgueria feito com ASP.NET (API) e Blazor (Client App).

---

## 🧠 Arquitetura

O projeto segue **Clean Architecture**, separando bem as responsabilidades:

- **Domain**: regras de negócio puras
- **Application**: orquestra os fluxos do sistema
- **Presentation (Blazor)**: interface web
- **Infra**: integrações e detalhes técnicos

A ideia foi manter o sistema fácil de evoluir sem acoplar regras de negócio à interface ou tecnologia.

---

## 🛠️ Tecnologias

- C# / .NET
- Blazor

---

## 🚀 Como rodar o projeto

Clone o repositório:

```bash
git clone https://github.com/celinhodaltro/GoodHamburger.git
cd GoodHamburger
dotnet restore
```

---

## ⚙️ Estrutura do projeto

Este projeto possui **dois módulos que precisam rodar simultaneamente**:

- 🔌 API: `src/GoodHamburger.API`
- 🎨 Front-end: `src/GoodHamburger.Presentation`

---

## ▶️ Executando a aplicação

Em **terminais separados**, rode:

### API

```bash
dotnet run --project src/GoodHamburger.API/GoodHamburger.API.csproj
```

### Front-end

```bash
dotnet run --project src/GoodHamburger.Presentation/GoodHamburger.Presentation.csproj
```

---

## 🌐 Acesso

- 🔌 **API**: `http://localhost:5000/swagger` (Swagger)
- 🎨 **Front-end (Presentation)**: `https://localhost:5001`
