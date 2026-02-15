using System.Reflection;
using Xunit;

namespace Tool.Architecture.Tests;

public class AssemblyReferenceTests
{
    [Fact]
    public void Core_Should_Not_Reference_Infrastructure()
    {
        var core = Assembly.Load("Tool.Core");
        var refs = core.GetReferencedAssemblies().Select(a => a.Name).ToArray();
        Assert.DoesNotContain(refs, r => r != null && r.StartsWith("Tool.Infrastructure"));
    }
}
