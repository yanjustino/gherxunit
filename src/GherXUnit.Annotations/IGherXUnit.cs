using Xunit.Abstractions;

namespace GherXUnit.Annotations;

/// <summary>
/// Interface for GherXUnit with class fixture
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGherXUnitBackground<T>:IGherXUnit, IClassFixture<T> where T : class
{
    void Setup();
}

/// <summary>
/// Interface for GherXUnit
/// </summary>
public interface IGherXUnit
{
    public ITestOutputHelper Output { get; }
}