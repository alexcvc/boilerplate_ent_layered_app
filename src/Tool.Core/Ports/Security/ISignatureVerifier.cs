namespace Tool.Core.Ports.Security;

public interface ISignatureVerifier
{
    Task<VerificationResult> VerifyAsync(Stream artifact, CancellationToken ct = default);
}

public sealed record VerificationResult(bool IsValid, string? Details = null);
