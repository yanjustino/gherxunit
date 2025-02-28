using Xunit.Abstractions;

namespace GherXUnit.Annotations.Samples.Outline;

public partial class ScenarioOutlineTest(ITestOutputHelper output) : IGherXUnit
{
    public ITestOutputHelper Output { get; } = output;
    
    private async Task Step01(int start, int eat, int left) => await Task.CompletedTask;
}