# [INATEL � P�s-gradua��o](https://inatel.br/) � [Desenvolvimento Mobile e Cloud Computing](https://inatel.br/pos/desenvolvimento-mobile-e-cloud-computing)

## Disciplina DM106 - Desenvolvimento de Web Services com Seguran�a sob a Plataforma .NET  

## Prof. Me. Jos� Andery Carneiro

### Aluno [Vagner Nogueira](https://github.com/vagnernogueira)<br>

---

# Trabalho da Disciplina<br>

## Atividade proposta

(1) Diagrama de classes do seu projeto, similar ao InventarioMed, contendo obrigatoriamente tr�s classes, A, B e C, sendo que a rela��o de A e B � de (1:N) e a rela��o de A e C � de (N:N). Programa console do seu projeto, similar ao desenvolvido na aula.

(2) Adi��o de funcionalidades:

- Integra��o com ORM Entity Framework (n�o precisa refazer os passos ADO.NET)
- Classes Context e DAL de Shared.Data
- Desenvolva uma DAL gen�rica
- Crie um novo banco com Migrations, alimentando-o com dados
- Crie a rela��o entre as classes (1:N) utilizando Migrations e Proxies
- Configure e teste o m�todo GET na sua API

---

### Entrega da Atividade 1

O diagrama de classes se encontra neste reposit�rio assim como a implementa��o do projeto console. Para download do execut�vel zipado, acesse a se��o de releases deste reposit�rio.

- [Branch aula-1.2](https://github.com/vagnernogueira/GestaoFrotaVeicular/tree/aula-1.2)
- [TAG v1 na branch master marcando �ltimo commit dessa atividade](https://github.com/vagnernogueira/GestaoFrotaVeicular/tree/v1)
- [Release v1](https://github.com/vagnernogueira/GestaoFrotaVeicular/releases/tag/v1)

---

### Entrega da Atividade 2

A implementa��o proposta se encontra neste reposit�rio.

- [Branch aula-2.4](https://github.com/vagnernogueira/GestaoFrotaVeicular/tree/aula-2.4)
- [TAG v2 na branch master marcando �ltimo commit dessa atividade](https://github.com/vagnernogueira/GestaoFrotaVeicular/tree/v2)
- [Release v2](https://github.com/vagnernogueira/GestaoFrotaVeicular/releases/tag/v2)

---

# GestaoFrotaVeicular

**Descri��o:**
O projeto "GestaoFrotaVeicular" � uma aplica��o web desenvolvida em ASP.NET Core com o objetivo de gerenciar uma frota de ve�culos de uma empresa. Ele permitir� o cadastro e gerenciamento de ve�culos, tipos de ve�culos e aloca��es a departamentos ou projetos.

**Caracter�sticas Detalhadas:**

1.  **Entidade Principal:**
    * **Ve�culos:** Cadastro com informa��es como placa, modelo, fabricante, ano, quilometragem, data da �ltima manuten��o, status (dispon�vel, em uso, em manuten��o).

2.  **Entidade de Categoriza��o:**
    * **Tipos de Ve�culo:** Cada ve�culo pertencer� a um �nico tipo (rela��o 1:N), como carro de passeio, caminhonete, furg�o, caminh�o leve, motocicleta.

3.  **Entidade de Aloca��o/Associa��o:**
    * **Departamentos/Projetos:** Ve�culos poder�o ser alocados a m�ltiplos departamentos da empresa (ex: Vendas, Log�stica, Manuten��o) ou a projetos espec�ficos (rela��o N:N). Um departamento/projeto pode utilizar diversos ve�culos, e um ve�culo pode ser utilizado por/para m�ltiplos departamentos/projetos (talvez n�o simultaneamente, mas ao longo do tempo ou com compartilhamento).

4.  **Funcionalidades:**
    * CRUD (Create, Read, Update, Delete) completo para Ve�culos, Tipos de Ve�culo e Departamentos/Projetos.

5.  **Tecnologias de Acesso a Dados:**
    * Utiliza��o do Entity Framework para mapeamento objeto-relacional.
    * ADO.NET para acesso direto a dados onde for pertinente (ex: relat�rios complexos, procedures otimizadas).

6.  **Seguran�a:**
    * Implementa��o de autentica��o e autoriza��o para controlar o acesso �s funcionalidades do sistema (ex: apenas gestores de frota podem cadastrar ve�culos, usu�rios comuns podem apenas visualizar).

7.  **Deployment:**
    * Deploy na plataforma Microsoft Azure, visando escalabilidade e alta disponibilidade.

8.  **Objetivo de Aprendizagem:**
    * Consolidar uma vis�o completa sobre o desenvolvimento de Web Services seguros e escal�veis, aplicando os conceitos aprendidos diretamente em um projeto com relev�ncia pr�tica para gest�o empresarial.

# Diagrama de Classes


<img style="margin-right: 30px" src="DM109-class-diagram.png" alt="Class Diagram"/><br>

---
