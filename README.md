# GherXUnit
**VERSÃO 1.0.0-Beta**  

> [!IMPORTANT]  
> VERSÃO 1.0.0-beta

GherXUnit is a superset of xUnit used for writing test scenarios using the Gherkin structure. It allows you to define features, rules, examples, steps, backgrounds, and scenario outlines in a readable and structured format.
O GherXUnit é considerado um superset do xUnit porque ele estende a funcionalidade do framework de testes xUnit incorporando a sintaxe Gherkin para a escrita de cenários de teste.
Isso significa que o GherXUnit inclui todas as funcionalidades do xUnit e adiciona novas capacidades para definir features, regras, exemplos, passos, backgrounds e outlines de cenários de uma forma estruturada e legível.
Ele melhora o framework base xUnit sem alterar seu comportamento central, tornando-o um superset.

### Superset vs. Biblioteca

> [!NOTE]  
> **Superset:**
> - Um superset é uma extensão de um sistema ou framework existente que adiciona novas funcionalidades ou capacidades, mantendo a compatibilidade com o sistema original.
> - Ele se baseia na funcionalidade base, fornecendo ferramentas e melhorias adicionais sem alterar o comportamento central.

> [!NOTE]  
> **Biblioteca:**
> - Uma biblioteca é uma coleção de código pré-escrito que os desenvolvedores podem usar para realizar tarefas comuns, como manipulação de estruturas de dados, fazer requisições de rede ou realizar cálculos matemáticos.
> - Ela fornece funções e classes reutilizáveis que podem ser integradas em vários projetos para simplificar o desenvolvimento.

## Uso do GherXUnit

### Seperação de responsabilidades:
No contexto do GherXUnit, a palavra-chave `partial` é usada para definir classes parciais. Isso permite que a definição de uma classe seja dividida em vários arquivos. Cada parte da classe é combinada pelo compilador em uma única definição de classe.

1. **Organização do Código**: Permite separar a lógica de diferentes aspectos de uma classe em arquivos distintos, facilitando a manutenção e a leitura do código.
2. **Colaboração**: Facilita o trabalho em equipe, pois diferentes desenvolvedores podem trabalhar em diferentes partes da mesma classe sem causar conflitos.
3. **Separação de Preocupações**: Permite separar a definição de atributos, métodos e lógica de teste em arquivos diferentes, mantendo o código mais limpo e organizado.

### Exemplo de uso no GherXUnit:

#### Arquivo `SubscriptionTest.cs`
```csharp
namespace GherXUnit.Annotations.Samples.Features;

[Feature("Subscribers see different articles based on their subscription level")]
public partial class SubscriptionTest
{
    [Scenario("Free subscribers see only the free articles")]
    async Task Scenario01() => await this.StepsAsync(Step01,
        """
        Given Free Frieda has a free subscription
        When Free Frieda logs in with her valid credentials
        Then she sees a Free article
        """);
}
```

#### Arquivo `SubscriptionTest.Steps.cs`
```csharp
using Xunit.Abstractions;

namespace GherXUnit.Annotations.Samples.Features;

public partial class SubscriptionTest(ITestOutputHelper output) : IGherXUnit
{
    public ITestOutputHelper Output { get; } = output;

    private async Task Step01()
    {
        // Implementação do passo
    }
}
```

Neste exemplo, a classe `SubscriptionTest` é dividida em dois arquivos. O primeiro arquivo define os cenários de teste, enquanto o segundo arquivo define os métodos de passos (`Steps`). O uso de `partial` permite que ambos os arquivos contribuam para a definição da mesma classe `SubscriptionTest`.

## Installation

Para incorporar o GherXUnit à sua aplicação, siga os passos abaixo:

### 1. Download dos Arquivos

Baixe os arquivos necessários diretamente do repositório do GherXUnit. Certifique-se de incluir os seguintes arquivos no seu projeto:

- `src/GherXUnit.Annotations/GherXUnitSteps.cs`
- `src/GherXUnit.Annotations/GherXUnitAttributes.cs`
- `src/GherXUnit.Annotations/IGherXUnit.cs`


> [!TIP]  
> Organize seu projeto de forma a separar as definições de cenários, passos e contextos em arquivos distintos. Utilize a palavra-chave `partial` para dividir a definição das classes em múltiplos arquivos.

### 2. Definição de Features e Cenários

Crie classes para definir as features e cenários de teste. Utilize os atributos `Feature`, `Scenario`, `Rule`, `Example`, `Background` e `ScenarioOutline` para estruturar seus testes.

#### Exemplo de Definição de Feature e Cenário

Crie um arquivo `SubscriptionTest.cs`:

```csharp
namespace GherXUnit.Annotations.Samples.Features;

[Feature("Subscribers see different articles based on their subscription level")]
public partial class SubscriptionTest
{
    [Scenario("Free subscribers see only the free articles")]
    async Task Scenario01() => await this.StepsAsync(Step01,
        """
        Given Free Frieda has a free subscription
        When Free Frieda logs in with her valid credentials
        Then she sees a Free article
        """);
}
```

### 4. Definição dos Passos

Crie um arquivo separado para definir os métodos que implementam os passos dos cenários.

#### Exemplo de Definição de Passos

Crie um arquivo `SubscriptionTest.Steps.cs`:

```csharp
using Xunit.Abstractions;

namespace GherXUnit.Annotations.Samples.Features;

public partial class SubscriptionTest(ITestOutputHelper output) : IGherXUnit
{
    public ITestOutputHelper Output { get; } = output;

    private async Task Step01()
    {
        // Implementação do passo
    }
}
```

### 5. Contexto de Background

Se necessário, defina um contexto para os testes que utilizam `Background`.

#### Exemplo de Definição de Contexto

Crie um arquivo `BackgroundContext.cs`:

```csharp
namespace GherXUnit.Annotations.Samples.Backgrounds;

public class BackgroundContext
{
    public string ContextId { get; } = Guid.NewGuid().ToString();
    public Dictionary<string, string> OwnersAndBlogs { get; } = new();

    public BackgroundContext()
    {
        OwnersAndBlogs.Add("Greg", "Greg's anti-tax rants");
        OwnersAndBlogs.Add("Dr. Bill", "Expensive Therapy");
    }
}
```

### 6. Execução dos Testes

Implemente os métodos de passos e execute os testes utilizando o framework xUnit. Utilize os métodos `Steps` e `StepsAsync` para executar os passos dos cenários.

> [!TIP]  
> O GherXUnit permite escrever cenários de teste de forma estruturada e legível utilizando a sintaxe Gherkin. Siga os exemplos fornecidos para adaptar o código à sua aplicação e criar testes compreensíveis e mantíveis.

Teste de sucesso com syntax highlight na IDE:
![img.png](/docs/img.png)

Teste de falha com syntax highlight na IDE:
![img.png](/docs/img02.png)

> [!CAUTION]  
> O teste do cenário _"Greg posts to a client's blog"_ está intecionalmente falhando para demonstrar a saída de erro.


## Palavras-chave do GherXUnit

### Feature

A Feature keyword é usada para fornecer uma descrição de alto nível de uma funcionalidade de software e agrupar cenários relacionados.

```csharp
[Feature("Subscribers see different articles based on their subscription level")]
public partial class SubscriptionTest
{
    [Scenario("Free subscribers see only the free articles")]
    async Task Scenario01() => await this.StepsAsync(Step01,
        """
        Given Free Frieda has a free subscription
        When Free Frieda logs in with her valid credentials
        Then she sees a Free article
        """);
    
    [Scenario("Subscriber with a paid subscription can access both free and paid articles")]
    void Scenario02() => this.Steps(Step02,
        """
        Given Paid Patty has a basic-level paid subscription
        When Paid Patty logs in with her valid credentials
        Then she sees a Free article and a Paid article
        """);
}
```

### Rule
A `Rule` keyword é usada para representar uma regra de negócio que deve ser implementada. Ela agrupa vários cenários que pertencem a essa regra.

```csharp
[Feature("Highlander")]
public partial class RuleTest
{
    [Rule("There can be only One")]
    [Example("Only One -- One alive")]
    async Task Example01() => await this.StepsAsync(
        """
        Example: Only One -- One alive
        Given there are <<3>> ninjas
        And there are more than one ninja alive
        When 2 ninjas meet, they will fight
        Then one ninja dies (but not me)
        And there is one ninja less alive
        """);
}
```

### Example
O `Example` keyword é usado para definir um exemplo específico para um cenário.


```csharp
[Example("There can be only One")]
void Example02() => this.Steps(
    """
    Example: Only One -- One alive
    Given there is only 1 ninja alive
    Then they will live forever ;-)
    """);
```

### Background
O `Background` keyword permite adicionar contexto aos cenários que o seguem. Ele contém um ou mais passos `Given`, que são executados antes de cada cenário.

```csharp
[Feature("Multiple site support")]
public partial class BackgroundTest
{
    [Background]
    public void Setup() => this.Steps(
        """
        Given a global administrator named <<"Greg">>
        And a blog named <<"Greg's anti-tax rants">>
        And a customer named <<"Dr. Bill">>
        And a blog named <<"Expensive Therapy">> owned by <<"Dr. Bill">>
        """);
}
```

### Scenario Outline
O `Scenario Outline` keyword é usado para executar o mesmo cenário várias vezes com diferentes conjuntos de valores.


```csharp
public partial class ScenarioOutlineTest
{
    [ScenarioOutline("eating")]
    [Examples(12, 05, 07)]
    [Examples(20, 05, 15)]
    public async Task Scenario01(int start, int eat, int left) => await this.StepsAsync(Step01, [start, eat, left],
        $"""
         Given there are <<{start}>> cucumbers
         When I eat <<{eat}>> cucumbers
         Then I should have <<{left}>> cucumbers
         """);
}
```


## Conclusão
GherXunit oferece uma maneira estruturada de escrever cenários de teste usando a sintaxe Gherkin, tornando seus testes mais legíveis e fáceis de manter. Ao usar features, rules, examples, steps, backgrounds e scenario outlines, você pode criar casos de teste abrangentes e compreensíveis.
