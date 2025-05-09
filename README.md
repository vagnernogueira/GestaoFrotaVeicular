# GestaoFrotaVeicular

**Descrição:**
O projeto "GestaoFrotaVeicular" é uma aplicação web desenvolvida em ASP.NET Core com o objetivo de gerenciar uma frota de veículos de uma empresa. Ele permitirá o cadastro e gerenciamento de veículos, tipos de veículos e alocações a departamentos ou projetos.

**Características Detalhadas:**

1.  **Entidade Principal:**
    * **Veículos:** Cadastro com informações como placa, modelo, fabricante, ano, quilometragem, data da última manutenção, status (disponível, em uso, em manutenção).

2.  **Entidade de Categorização:**
    * **Tipos de Veículo:** Cada veículo pertencerá a um único tipo (relação 1:N), como carro de passeio, caminhonete, furgão, caminhão leve, motocicleta.

3.  **Entidade de Alocação/Associação:**
    * **Departamentos/Projetos:** Veículos poderão ser alocados a múltiplos departamentos da empresa (ex: Vendas, Logística, Manutenção) ou a projetos específicos (relação N:N). Um departamento/projeto pode utilizar diversos veículos, e um veículo pode ser utilizado por/para múltiplos departamentos/projetos (talvez não simultaneamente, mas ao longo do tempo ou com compartilhamento).
    * *Alternativa para N:N:* **Motoristas.** Um veículo pode ser operado por múltiplos motoristas (ex: turnos diferentes) e um motorista pode ser habilitado ou ter histórico de uso de múltiplos veículos.

4.  **Funcionalidades:**
    * CRUD (Create, Read, Update, Delete) completo para Veículos, Tipos de Veículo e Departamentos/Projetos (ou Motoristas).

5.  **Tecnologias de Acesso a Dados:**
    * Utilização do Entity Framework para mapeamento objeto-relacional.
    * ADO.NET para acesso direto a dados onde for pertinente (ex: relatórios complexos, procedures otimizadas).

6.  **Segurança:**
    * Implementação de autenticação e autorização para controlar o acesso às funcionalidades do sistema (ex: apenas gestores de frota podem cadastrar veículos, usuários comuns podem apenas visualizar).

7.  **Deployment:**
    * Deploy na plataforma Microsoft Azure, visando escalabilidade e alta disponibilidade.

8.  **Objetivo de Aprendizagem:**
    * Consolidar uma visão completa sobre o desenvolvimento de Web Services seguros e escaláveis, aplicando os conceitos aprendidos diretamente em um projeto com relevância prática para gestão empresarial.

**Por que "GestaoFrotaVeicular" se encaixa?**

* **Estrutura Similar:** A lógica de ter um "item" principal (Veículo), uma "categoria" para esse item (Tipo de Veículo) e uma forma de "alocação/associação" desse item (Departamentos/Projetos ou Motoristas) é diretamente análoga ao InventarioMed.
* **Relações de Dados Idênticas:** Mantém a relação 1:N entre Veículo e Tipo de Veículo, e a relação N:N entre Veículo e Departamentos/Projetos.
* **Stack Tecnológico e Requisitos Funcionais:** Todos os requisitos técnicos (ASP.NET Core, EF, ADO.NET, Azure, Segurança) e funcionais (CRUD) são os mesmos.
* **Relevância Prática:** Assim como o inventário de equipamentos médicos, a gestão de frotas é um problema real e comum em muitas empresas, o que confere relevância prática ao projeto.

Este projeto permitiria aplicar exatamente os mesmos conceitos e tecnologias em um domínio diferente, mas com uma estrutura de dados e requisitos de sistema muito parecidos.