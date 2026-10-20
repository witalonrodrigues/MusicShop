# MusicShop - Sistema de Gestão para Loja de Instrumentos Musicais

Projeto desenvolvido para o **Checkpoint 2** da disciplina de **C# Development** (Curso de Engenharia de Software - FIAP | Turma 3ESPR), sob orientação do Prof. Wellington Cidade Silva.

---

## Sobre o Projeto

O **MusicShop** é uma aplicação Desktop desenvolvida em **C# (.NET) utilizando Windows Forms** para gerenciar o fluxo de vendas de uma loja de instrumentos musicais. O trabalho teve como foco central a aplicação prática de **GitFlow, Feature Branches, Commits Semânticos, Code Review e Pull Requests** em equipe.

---

## Estrutura e Funcionalidades do Sistema

O sistema contempla 4 módulos obrigatórios integrados:

1. **Tela de Splash (`FormSplash.cs`):**
   - Tela de abertura com carregamento automático (`ProgressBar` + `Timer`) que inicializa o sistema e redireciona automaticamente para o Menu Principal.
2. **Tela de Menu Principal (`FormMenu.cs`):**
   - Hub central de navegação entre os módulos de lançamento de vendas, relatórios e encerramento seguro da aplicação.
3. **Tela de Venda de Instrumentos (`FormVenda.cs`):**
   - Cadastro de pedidos contendo Nome do Cliente, seleção de Instrumento Musical, Quantidade e Preço Unitário automático.
   - Cálculo dinâmico em tempo real do subtotal do pedido e persistência em memória (`BancoDadosMemoria`).
4. **Tela de Relatório de Vendas (`FormRelatorio.cs`):**
   - Listagem geral dos pedidos realizados em um `DataGridView`.
   - Filtro dinâmico de busca por nome do cliente ou instrumento musical.
   - Indicador consolidado de quantidade de pedidos e faturamento total acumulado.

---

## Fluxo de Versionamento (Git & GitHub)

O desenvolvimento seguiu rigorosamente as boas práticas de versionamento em equipe:
- **`main`**: Branch principal contendo a versão estável e homologada para entrega.
- **`dev`**: Branch de integração contínua onde as funcionalidades da equipe foram unificadas via Pull Request.
- **`feature/*`**: Branches isoladas por tarefa (`feature/splash-menu`, `feature/tela-vendas`, `feature/tela-relatorio`), respeitando a regra mínima de **3 commits semânticos** por integrante (`feat`, `model`, `docs`, `fix`).

---

## Como Executar e Testar o Projeto

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (6.0, 7.0 ou 8.0) instalado.
- Sistema Operacional Windows (necessário para renderização do Windows Forms).
- Visual Studio 2022 ou VS Code / Terminal CLI.

### Passo a Passo via Terminal (CLI)
1. Clone o repositório:
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd MusicShop