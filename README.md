# Calculo de Salarios

## 📌 Objetivo

Este projeto é uma aplicação ASP.NET Web Forms com integração ao banco de dados MySQL, desenvolvida com o objetivo de realizar o gerenciamento de **pessoas** e **cargos**, e calcular automaticamente os **salários** com base nos dados cadastrados.

---

## 🚀 Funcionalidades

- ✅ Cadastro de Pessoas
- ✅ Cargos pré definidos
- ✅ Cálculo e exibição de salários por pessoa
- ✅ Filtro de salários por cargo
- ✅ Exclusão lógica via campo `ativo`
- ✅ Validações básicas de campos obrigatórios
- ✅ Paginação de resultados

---

## 🛠️ Tecnologias e Dependências

- **ASP.NET Web Forms** (.NET Framework)
- **C#**
- **MySQL** como banco de dados relacional
- **MySQL.Data** – Conector oficial para C#
- **Visual Studio** – Ambiente de desenvolvimento
- **ADO.NET** – Para conexão e execução de comandos SQL
- **Camadas DAL / BLL / UI** separadas para manter organização

---

## 🧱 Estrutura do Banco de Dados

- **pessoa**: contém dados cadastrais do funcionário.
- **cargo**: nome e salário base do cargo.
- **pessoa_salario**: relaciona pessoa com salário registrado.
- **vw_pessoa_salario_ativo** (VIEW): traz nome, email, salário e nome do cargo dos funcionários ativos.
- **calcular_salarios**: procedure responsável pelo calculo dos salário e construir a tabela pessoa_salario com base no bonus e salario base.
- **inserir_pessoa**: procedure responsável pelos novos registros na tabela pessoa.

# Instruções 

- **1**: Clonar este repositório
- **2**: Configurar o web.config para conexão com o BD
- exemplo:
- <configuration>
    <connectionStrings>
        <add name="MySqlConnection"
             connectionString="Server=localhost;Database=salario_calculo;Uid=SEU_USUARIO;Pwd=SUA_SENHA;"
             providerName="MySql.Data.MySqlClient" />
    </connectionStrings>
  </configuration>
  
- **3**: criar tabelas no banco => **ir ao diretório /Database**
- **4**: Com o banco configurado, rodar o projeto na IDE, no arquivo **Salarios.aspx**

- **5**: O projeto contém uma tela inicial que exibe nome, email, cargo e salario. Há um link para a página de adicionar e excluir pessoas do banco.


  
