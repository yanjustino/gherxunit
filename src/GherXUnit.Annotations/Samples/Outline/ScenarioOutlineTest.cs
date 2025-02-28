namespace GherXUnit.Annotations.Samples.Outline;

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