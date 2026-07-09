# Gastos Residenciais

Sistema de controle de gastos residenciais, desenvolvido como desafio técnico. 
Permite cadastrar pessoas e suas transações (receitas/despesas), com consulta de totais gerais e por pessoa.

## Tecnologias

- **Backend:** .NET (C#) + Entity Framework Core + SQLite
- **Frontend:** React + TypeScript + Vite + Axios

## Funcionalidades

### Pessoas
- Criar, listar, editar e excluir.
- Ao excluir uma pessoa, todas as suas transações são excluídas junto
  (integridade referencial garantida no backend).

### Transações
- Criar, listar, editar e excluir.
- Pessoas menores de 18 anos só podem ter **despesas** cadastradas — regra
  validada no backend.
- Tabela com destaque visual: despesas em vermelho, receitas em verde.

### Consulta de totais (Dashboard)
- Card de totais gerais (receitas, despesas, saldo) de todas as pessoas.
- Card individual por pessoa, com saldo destacado em vermelho quando negativo.
- Mensagens de estado vazio quando não há pessoas/transações cadastradas.

### Boas práticas aplicadas
- Validação de dados via Data Annotations no backend, com respostas de erro
  padronizadas em JSON.
- Separação em camadas: Controller → Service (via Interface) → DTO →
  Mapping → Model.
- Tipagem no frontend espelhando os DTOs da API.
- Feedback de carregamento (botões desabilitados durante requisições) e de
  erro visível ao usuário em todas as telas.

## Como rodar o backend

```bash
cd backend/GastoResidencial
dotnet restore
dotnet ef database update   # cria o banco SQLite (gastos.db) com as migrations
dotnet run
```

A API sobe em `http://localhost:5192` (confirme a porta exibida no terminal).

## Como rodar o frontend

```bash
cd frontend
npm install
npm run dev
```

O frontend sobe em `http://localhost:5173`. A URL da API está configurada
diretamente em `src/services/api.ts`.

## Estrutura do projeto

```
backend/GastoResidencial/
├── Controllers/     # Endpoints da API (Pessoas, Transacoes, Relatorios)
├── Services/         # Regras de negócio
├── Interfaces/       # Contratos dos services
├── DTOs/             # Objetos de entrada/saída da API
├── Mappings/         # Conversão entre entidades e DTOs
├── Models/           # Entidades do banco
└── Migrations/       # Histórico de mudanças no banco

frontend/src/
├── pages/            # Dashboard, Pessoas, Transacoes
├── components/       # Header, TotaisCard, PessoaCard
├── services/         # Chamadas à API (axios)
└── types/            # Tipagem TypeScript espelhando os DTOs do backend
```

## Endpoints principais

| Método | Rota                  | Descrição                    |
|--------|------------------------|-------------------------------|
| GET    | /api/pessoas           | Lista pessoas                 |
| POST   | /api/pessoas           | Cadastra pessoa                |
| PUT    | /api/pessoas/{id}      | Edita pessoa                   |
| DELETE | /api/pessoas/{id}      | Exclui pessoa (e transações)   |
| GET    | /api/transacoes        | Lista transações               |
| POST   | /api/transacoes        | Cadastra transação              |
| PUT    | /api/transacoes/{id}   | Edita transação                 |
| DELETE | /api/transacoes/{id}   | Exclui transação                |
| GET    | /api/relatorios/totais | Totais gerais e por pessoa      |
