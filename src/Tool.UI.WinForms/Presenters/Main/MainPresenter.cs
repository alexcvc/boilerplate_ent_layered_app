using Tool.Application.UseCases.Import;
using Tool.Application.ViewModels.Main;
using Tool.UI.WinForms.Views.Main;

namespace Tool.UI.WinForms.Presenters.Main;

public sealed class MainPresenter
{
    private readonly IMainView _view;
    private readonly MainViewModel _vm;
    private readonly ImportSclUseCase _importUseCase;

    public MainPresenter(IMainView view, MainViewModel vm, ImportSclUseCase importUseCase)
    {
        _view = view;
        _vm = vm;
        _importUseCase = importUseCase;

        _view.Bind(_vm);
        _view.ImportRequested += OnImportRequested;
    }

    private async void OnImportRequested(object? sender, EventArgs e)
    {
        _vm.AddLog("Import requested (stub).");
        using var ms = new MemoryStream(new byte[] { 1, 2, 3 });

        var result = await _importUseCase.ExecuteAsync(ms);
        _vm.AddLog(result.IsSuccess ? "Import OK" : $"Import failed: {result.Error}");
    }
}
