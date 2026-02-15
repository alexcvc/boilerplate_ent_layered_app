using Microsoft.Extensions.DependencyInjection;
using Tool.Application.UseCases.Import;
using Tool.Application.ViewModels.Main;
using Tool.Core.Ports.Security;
using Tool.Infrastructure.Security.Iec62351;
using Tool.UI.WinForms.Presenters.Main;
using Tool.UI.WinForms.Views.Main;

namespace Tool.Host.Desktop;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();

        // Core ports -> Infrastructure adapters
        services.AddSingleton<ISignatureVerifier, StubSignatureVerifier>();

        // Application
        services.AddTransient<ImportSclUseCase>();
        services.AddSingleton<MainViewModel>();

        // UI
        services.AddTransient<IMainView, MainForm>();
        services.AddTransient<MainPresenter>();

        using var sp = services.BuildServiceProvider();

        var view = (MainForm)sp.GetRequiredService<IMainView>();
        _ = sp.GetRequiredService<MainPresenter>(); // wires events

        Application.Run(view);
    }
}
