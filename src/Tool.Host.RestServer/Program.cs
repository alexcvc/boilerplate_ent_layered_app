using Tool.Application.UseCases.Import;
using Tool.Core.Ports.Security;
using Tool.Infrastructure.Security.Iec62351;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISignatureVerifier, StubSignatureVerifier>();
builder.Services.AddTransient<ImportSclUseCase>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPost("/import", async (HttpRequest req, ImportSclUseCase useCase, CancellationToken ct) =>
{
    using var ms = new MemoryStream();
    await req.Body.CopyToAsync(ms, ct);
    ms.Position = 0;

    var result = await useCase.ExecuteAsync(ms, ct);
    return result.IsSuccess
        ? Results.Ok(new { ok = true })
        : Results.BadRequest(new { ok = false, error = result.Error });
});

app.Run();
