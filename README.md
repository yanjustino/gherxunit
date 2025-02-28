# GherXUnit
[🇧🇷 Versão em Português](README_PTBR.md) | [🇬🇧 English Version](README.md)
> [!IMPORTANT]  
> VERSION 1.0.0-beta

## Introduction
Behavior-Driven Development (BDD) is an agile methodology widely used for software requirements specification and validation, promoting clearer communication between technical and non-technical stakeholders. However, despite its benefits, some challenges are frequently reported, such as difficulties in test automation, scenario maintenance, and integration with traditional unit testing frameworks.

GherXUnit emerges as a viable alternative for those seeking an approach that combines the expressiveness of BDD with the well-established structure of xUnit. By allowing test scenarios to be written using Gherkin syntax within a unit testing framework, GherXUnit provides an option for teams looking to leverage the benefits of BDD without sacrificing the familiarity and efficiency of xUnit. While it does not solve all inherent BDD challenges, GherXUnit aims to offer a more integrated and flexible experience for defining and executing tests.

## Superset vs. Library
GherXUnit is a superset of xUnit used for writing test scenarios using the Gherkin structure. It allows defining features, rules, examples, steps, backgrounds, and scenario outlines in a readable and structured format.

GherXUnit is considered a superset of xUnit because it extends the functionality of the xUnit testing framework by incorporating Gherkin syntax for writing test scenarios. This means that GherXUnit includes all xUnit functionalities and adds new capabilities for defining features, rules, examples, steps, backgrounds, and scenario outlines in a structured and readable manner. It enhances the base xUnit framework without altering its core behavior, making it a superset.

**Superset:**
- A superset is an extension of an existing system or framework that adds new functionalities or capabilities while maintaining compatibility with the original system.
- It builds on the base functionality, providing additional tools and improvements without changing the core behavior.

**Library:**
- A library is a collection of pre-written code that developers can use to perform common tasks such as data structure manipulation, network requests, or mathematical calculations.
- It provides reusable functions and classes that can be integrated into various projects to simplify development.

## Using GherXUnit

### Separation of Responsibilities:
In the context of GherXUnit, the `partial` keyword is used to define partial classes. This allows a class definition to be split across multiple files. Each part of the class is combined by the compiler into a single class definition.

1. **Code Organization**: Enables separating the logic of different aspects of a class into distinct files, making maintenance and readability easier.
2. **Collaboration**: Facilitates teamwork, as different developers can work on different parts of the same class without conflicts.
3. **Separation of Concerns**: Allows attributes, methods, and test logic to be defined in separate files, keeping the code cleaner and more organized.

### Example Usage in GherXUnit:

#### File `SubscriptionTest.cs`
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

#### File `SubscriptionTest.Steps.cs`
```csharp
using Xunit.Abstractions;

namespace GherXUnit.Annotations.Samples.Features;

public partial class SubscriptionTest(ITestOutputHelper output) : IGherXUnit
{
    public ITestOutputHelper Output { get; } = output;

    private async Task Step01()
    {
        // Step implementation
    }
}
```

In this example, the `SubscriptionTest` class is divided into two files. The first file defines the test scenarios, while the second file defines the step methods. The use of `partial` allows both files to contribute to the definition of the same `SubscriptionTest` class.

## Installation

To incorporate GherXUnit into your application, follow these steps:

### 1. Download the Files

Download the file [gherxunit-v1.0.0-beta.zip](download/gherxunit-v1.0.0-beta.zip). Ensure you include the following files in your project:

- `src/GherXUnit.Annotations/GherXUnitSteps.cs`
- `src/GherXUnit.Annotations/GherXUnitAttributes.cs`
- `src/GherXUnit.Annotations/IGherXUnit.cs`

> [!TIP]  
> Organize your project by separating scenario definitions, steps, and contexts into distinct files. Use the `partial` keyword to split class definitions across multiple files.

### 2. Defining Features and Scenarios

Create classes to define features and test scenarios. Use the `Feature`, `Scenario`, `Rule`, `Example`, `Background`, and `ScenarioOutline` attributes to structure your tests.

### 3. Running Tests

Implement the step methods and execute tests using the xUnit framework. Use the `Steps` and `StepsAsync` methods to execute scenario steps.

> [!TIP]  
> GherXUnit allows writing structured and readable test scenarios using Gherkin syntax. Follow the provided examples to adapt the code to your application and create maintainable and understandable tests.

### 4. Execution Output

Successful test with syntax highlight in the IDE:
![img.png](/docs/img.png)

Failed test with syntax highlight in the IDE:
![img.png](/docs/img02.png)

> [!CAUTION]  
> The test for the scenario _"Greg posts to a client's blog"_ is intentionally failing to demonstrate error output.

## GherXUnit Keywords

### Feature
The `Feature` keyword is used to provide a high-level description of a software functionality and group related scenarios.

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
}
```

### Rule
The `Rule` keyword represents a business rule that must be implemented. It groups multiple scenarios related to this rule.

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

## Conclusion
GherXUnit provides a structured way to write test scenarios using Gherkin syntax, making your tests more readable and maintainable. By using features, rules, examples, steps, backgrounds, and scenario outlines, you can create comprehensive and understandable test cases.

## References
- **Farooq, M. S., et al.** (2023). *Behavior Driven Development: A Systematic Literature Review*. IEEE Access. DOI: [10.1109/ACCESS.2023.3302356](https://doi.org/10.1109/ACCESS.2023.3302356).
- **Cucumber**. *Cucumber Documentation*. Available at: [https://cucumber.io/docs](https://cucumber.io/docs).
- **North, D.** *Introducing BDD*. Available at: [https://dannorth.net/introducing-bdd/](https://dannorth.net/introducing-bdd/).

