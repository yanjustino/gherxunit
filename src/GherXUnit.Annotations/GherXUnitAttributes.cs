global using Examples = Xunit.InlineDataAttribute;

using System.ComponentModel;

namespace GherXUnit.Annotations;

/// <summary>
/// The purpose of the Feature keyword is to provide a high-level description of a software feature,
/// and to group related scenarios.
/// See the <see href="https://cucumber.io/docs/gherkin/reference#feature">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
/// <param name="descripton"></param>
public class FeatureAttribute(string descripton) : DescriptionAttribute
{
    public override string Description { get; } = descripton;
}

/// <summary>
/// The purpose of the Rule keyword is to represent one business rule that should be implemented.
/// It provides additional information for a feature. A Rule is used to group together several
/// scenarios that belong to this business rule. A Rule should contain one or more scenarios
/// that illustrate the particular rule.
/// See the <see href="https://cucumber.io/docs/gherkin/reference#rule">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
/// <param name="displayName"></param>
public class RuleAttribute(string displayName) : DescriptionAttribute
{
    public override string Description { get; } = displayName;
}

/// <summary>
/// You can have as many steps as you like, but we recommend 3-5 steps per example.
/// Having too many steps will cause the example to lose its expressive power as a
/// specification and documentation.
/// See the <see href="https://cucumber.io/docs/gherkin/reference#example">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
/// <param name="displayName"></param>
public class ScenarioAttribute(string displayName) : FactAttribute
{
    public override string DisplayName { get; set; } = displayName;
}

/// <summary>
/// You can have as many steps as you like, but we recommend 3-5 steps per example.
/// Having too many steps will cause the example to lose its expressive power as a
/// specification and documentation.
/// </summary>
/// See the <see href="https://cucumber.io/docs/gherkin/reference#example">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// <param name="displayName"></param>
public class ExampleAttribute(string displayName) : FactAttribute
{
    public override string DisplayName { get; set; } = displayName;
}

/// <summary>
/// A Background allows you to add some context to the scenarios that follow it.
/// It can contain one or more Given steps, which are run before each scenario.
/// A Background is placed before the first Scenario/Example, at the same level of indentation.
/// See the <see href="https://cucumber.io/docs/gherkin/reference#background">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
public class BackgroundAttribute : DescriptionAttribute
{
    public override string Description => "Background";
}

/// <summary>
/// A Background allows you to add some context to the scenarios that follow it.
/// It can contain one or more Given steps, which are run before each scenario.
/// A Background is placed before the first Scenario/Example, at the same level of indentation.
/// See the <see href="https://cucumber.io/docs/gherkin/reference#scenario-outline">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
/// <param name="displayName"></param>
public class ScenarioOutline(string displayName) : TheoryAttribute
{
    public override string DisplayName { get; set; } = displayName;
}











