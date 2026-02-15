using Tool.Core.Ports.Security;

namespace Tool.Infrastructure.Security.Iec62351;

/// <summary>
/// Stub implementation. Replace with real XMLDSIG + X509 chain validation.
/// </summary>
public sealed class StubSignatureVerifier : ISignatureVerifier
{
    public Task<VerificationResult> VerifyAsync(Stream artifact, CancellationToken ct = default)
        => Task.FromResult(new VerificationResult(true, "stub"));
}
