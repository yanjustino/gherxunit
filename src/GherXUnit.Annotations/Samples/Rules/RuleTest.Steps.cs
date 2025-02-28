using Xunit.Abstractions;

namespace GherXUnit.Annotations.Samples.Rules;

public partial class RuleTest(ITestOutputHelper output) : IGherXUnit
{
    public ITestOutputHelper Output { get; } = output;
}