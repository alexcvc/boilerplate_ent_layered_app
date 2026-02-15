using System.Collections.ObjectModel;

namespace Tool.Application.ViewModels.Main;

public sealed class MainViewModel
{
    public ObservableCollection<string> Log { get; } = new();

    public void AddLog(string message) => Log.Add(message);
}
