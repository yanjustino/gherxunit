using Xunit.Abstractions;

namespace GherXUnit.Annotations.Samples.Features;

public partial class SubscriptionTest(ITestOutputHelper output): IGherXUnit
{
    public ITestOutputHelper Output { get; } = output;

    private async Task Step01() => await Task.CompletedTask;
    private void Step02() { }
}