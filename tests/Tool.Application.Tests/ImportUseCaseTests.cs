using Tool.Application.UseCases.Import;
using Tool.Core.Ports.Security;
using Xunit;

namespace Tool.Application.Tests;

public class ImportUseCaseTests
{
    private sealed class FakeVerifier : ISignatureVerifier
    {
        public Task<VerificationResult> VerifyAsync(Stream artifact, CancellationToken ct = default)
            => Task.FromResult(new VerificationResult(true, "ok"));
    }

    [Fact]
    public async Task ExecuteAsync_ReturnsOk_WhenSignatureValid()
    {
        var uc = new ImportSclUseCase(new FakeVerifier());
        using var ms = new MemoryStream(new byte[] { 1, 2 });
        var result = await uc.ExecuteAsync(ms);
        Assert.True(result.IsSuccess);
    }
}
