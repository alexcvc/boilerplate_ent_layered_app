using Tool.Application.ViewModels.Main;

namespace Tool.UI.WinForms.Views.Main;

public interface IMainView
{
    void Bind(MainViewModel vm);
    event EventHandler ImportRequested;
}
