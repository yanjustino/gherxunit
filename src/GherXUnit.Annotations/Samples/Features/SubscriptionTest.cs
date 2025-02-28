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
    
    [Scenario("Subscriber with a paid subscription can access both free and paid articles")]
    void Scenario02() => this.Steps(Step02,
        """
        Given Paid Patty has a basic-level paid subscription
        When Paid Patty logs in with her valid credentials
        Then she sees a Free article and a Paid article
        """);
}