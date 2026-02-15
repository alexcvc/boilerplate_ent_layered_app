using Tool.Core.Abstractions;
using Xunit;

namespace Tool.Core.Tests;

public class SmokeTests
{
    [Fact]
    public void Result_Ok_IsSuccess() => Assert.True(Result.Ok().IsSuccess);
}
