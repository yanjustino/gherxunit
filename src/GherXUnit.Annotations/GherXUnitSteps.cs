using System.Reflection;
using System.Text;

namespace GherXUnit.Annotations;

/// <summary>
/// Async Methods for Gherkin Steps
/// Each step starts with Given, When, Then, And, or But.
/// Cucumber executes each step in a scenario one at a time, in the sequence you’ve written them in.
/// When Cucumber tries to execute a step, it looks for a matching step definition to execute.
/// Keywords are not taken into account when looking for a step definition.
/// This means you cannot have a Given, When, Then, And or But step with the same text as another step.
/// See the <see href="https://cucumber.io/docs/gherkin/reference#steps">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
public static partial class GherXUnitSteps
{
    public static async Task StepsAsync(this IGherXUnit feature,
        string scenario) => await StepsAsync(feature, null, scenario, []);
    public static async Task StepsAsync(this IGherXUnit feature, Delegate @delegate,
        string scenario) => await StepsAsync(feature, @delegate.Method, scenario, []);
    public static async Task StepsAsync(this IGherXUnit feature, Delegate @delegate, object[] args,
        string scenario) => await StepsAsync(feature, @delegate.Method, scenario, args);
}

/// <summary>
/// # Sync Methods for Gherkin Steps
/// See the <see href="https://cucumber.io/docs/gherkin/reference#steps">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
public static partial class GherXUnitSteps
{
    public static void Steps(this IGherXUnit feature, string scenario)
        => Steps(feature, null, scenario, []);
    public static void Steps(this IGherXUnit feature, Delegate @delegate, string scenario)
        => Steps(feature, @delegate.Method, scenario, []);
    public static void Steps(this IGherXUnit feature, Delegate @delegate, object[] args, string scenario)
        => Steps(feature, @delegate.Method, scenario, args);
}

/// <summary>
/// Base Methods for Gherkin Steps
/// See the <see href="https://cucumber.io/docs/gherkin/reference#steps">cucumber.io</see> documentation
/// or <see href="https://dannorth.net/introducing-bdd/">introducing-bdd</see> page for more information.
/// </summary>
public static partial class GherXUnitSteps
{
    public static void Inconclusive(this IGherXUnit feature, string scenario) 
        => feature.Output.WriteLine(scenario.Highlights());

    public static Task InconclusiveAsync(this IGherXUnit feature, string scenario)
    {
        feature.Output.WriteLine(scenario.Highlights());
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Execute the steps in the scenario synchronously.
    /// </summary>
    /// <param name="feature"></param>
    /// <param name="method"></param>
    /// <param name="scenario"></param>
    /// <param name="args"></param>
    private static void Steps(this IGherXUnit feature, MethodInfo? method, string scenario, params object?[] args)
    {
        try
        {
            method?.Invoke(feature, args);
            feature.Output.WriteLine(scenario.Highlights());
        }
        catch (Exception)
        {
            feature.Output.WriteLine(scenario.Highlights(true));
            throw;
        }
    }
    
    /// <summary>
    /// Execute the steps in the scenario asynchronously.
    /// </summary>
    /// <param name="feature"></param>
    /// <param name="method"></param>
    /// <param name="scenario"></param>
    /// <param name="args"></param>
    private static async Task StepsAsync(this IGherXUnit feature, MethodInfo? method, string scenario, params object?[] args)
    {
        try
        {
            if (method is not null)
            {
                var task = (Task)method.Invoke(feature, args)!;
                await task;
            }
            feature.Output.WriteLine(scenario.Highlights());
        }
        catch (Exception)
        {
            feature.Output.WriteLine(scenario.Highlights(true));
            throw;
        }
    }    
    
    private static string Highlights(this string scenario, bool isException = false)
    {
        var color = isException ? "31m" : "38;5;82m";
        
        var replacements = new Dictionary<string, string>
        {
            { "Given", $"{(char)27}[{color}GIVEN{(char)27}[0m" },
            { "When", $"{(char)27}[{color}WHEN{(char)27}[0m" },
            { "Then", $"{(char)27}[{color}THEN{(char)27}[0m" },
            { "And", $"{(char)27}[{color}AND{(char)27}[0m" },
            { "<<", $"{(char)27}[35m" },
            { ">>", $"{(char)27}[0m" }
        };

        var sb = new StringBuilder(scenario);
        foreach (var replacement in replacements)
        {
            sb.Replace(replacement.Key, replacement.Value);
        }

        return sb.ToString();
    }
}