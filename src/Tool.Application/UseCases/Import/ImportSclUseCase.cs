using Tool.Core.Abstractions;
using Tool.Core.Ports.Security;

namespace Tool.Application.UseCases.Import;

public sealed class ImportSclUseCase
{
    private readonly ISignatureVerifier _signatureVerifier;

    public ImportSclUseCase(ISignatureVerifier signatureVerifier)
    {
        _signatureVerifier = signatureVerifier;
    }

    public async Task<Result> ExecuteAsync(Stream artifact, CancellationToken ct = default)
    {
        var verification = await _signatureVerifier.VerifyAsync(artifact, ct);
        return verification.IsValid
            ? Result.Ok()
            : Result.Fail($"Signature invalid: {verification.Details}");
    }
}
