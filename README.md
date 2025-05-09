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
    * *Alternativa para N:N:* **Motoristas.** Um ve�culo pode ser operado por m�ltiplos motoristas (ex: turnos diferentes) e um motorista pode ser habilitado ou ter hist�rico de uso de m�ltiplos ve�culos.

4.  **Funcionalidades:**
    * CRUD (Create, Read, Update, Delete) completo para Ve�culos, Tipos de Ve�culo e Departamentos/Projetos (ou Motoristas).

5.  **Tecnologias de Acesso a Dados:**
    * Utiliza��o do Entity Framework para mapeamento objeto-relacional.
    * ADO.NET para acesso direto a dados onde for pertinente (ex: relat�rios complexos, procedures otimizadas).

6.  **Seguran�a:**
    * Implementa��o de autentica��o e autoriza��o para controlar o acesso �s funcionalidades do sistema (ex: apenas gestores de frota podem cadastrar ve�culos, usu�rios comuns podem apenas visualizar).

7.  **Deployment:**
    * Deploy na plataforma Microsoft Azure, visando escalabilidade e alta disponibilidade.

8.  **Objetivo de Aprendizagem:**
    * Consolidar uma vis�o completa sobre o desenvolvimento de Web Services seguros e escal�veis, aplicando os conceitos aprendidos diretamente em um projeto com relev�ncia pr�tica para gest�o empresarial.

**Por que "GestaoFrotaVeicular" se encaixa?**

* **Estrutura Similar:** A l�gica de ter um "item" principal (Ve�culo), uma "categoria" para esse item (Tipo de Ve�culo) e uma forma de "aloca��o/associa��o" desse item (Departamentos/Projetos ou Motoristas) � diretamente an�loga ao InventarioMed.
* **Rela��es de Dados Id�nticas:** Mant�m a rela��o 1:N entre Ve�culo e Tipo de Ve�culo, e a rela��o N:N entre Ve�culo e Departamentos/Projetos.
* **Stack Tecnol�gico e Requisitos Funcionais:** Todos os requisitos t�cnicos (ASP.NET Core, EF, ADO.NET, Azure, Seguran�a) e funcionais (CRUD) s�o os mesmos.
* **Relev�ncia Pr�tica:** Assim como o invent�rio de equipamentos m�dicos, a gest�o de frotas � um problema real e comum em muitas empresas, o que confere relev�ncia pr�tica ao projeto.

Este projeto permitiria aplicar exatamente os mesmos conceitos e tecnologias em um dom�nio diferente, mas com uma estrutura de dados e requisitos de sistema muito parecidos.