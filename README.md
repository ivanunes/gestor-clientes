# 🧾 Gerenciador de Clientes em C#

Este é um projeto de console feito em **C#** com o objetivo de praticar conceitos básicos da linguagem como:

- Estrutura de dados (`List`, `struct`)
- Serialização binária (`BinaryFormatter`)
- Manipulação de arquivos (`FileStream`)
- Controle de fluxo e enums
- Interação com o usuário via console

## 📋 Funcionalidades

O sistema permite:

✅ Listar clientes  
✅ Adicionar novos clientes  
✅ Remover clientes pelo ID  
✅ Salvar os dados em arquivo binário  
✅ Carregar dados salvos ao iniciar

## 🧠 Estrutura do Cliente

Cada cliente contém:

- **Nome**
- **Email**
- **CPF**

Essas informações são armazenadas em uma `List<Cliente>` e salvas localmente no arquivo `Clientes.bin`.

## 🖥️ Como usar

1. Clone o repositório ou baixe os arquivos `.cs`
2. Abra o projeto no Visual Studio ou em outro ambiente C# compatível
3. Compile e execute o programa
4. Use o menu interativo para gerenciar os clientes

```bash
Sistema de clientes - Bem-vindo!

1 - Listagem
2 - Adicionar
3 - Remover
4 - Sair
