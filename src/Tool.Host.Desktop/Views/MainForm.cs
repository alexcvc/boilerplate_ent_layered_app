using System.ComponentModel;
using Tool.Application.ViewModels.Main;
using Tool.UI.WinForms.Views.Main;

namespace Tool.Host.Desktop;

public sealed class MainForm : Form, IMainView
{
    private readonly Button _btnImport = new() { Text = "Import (stub)", Dock = DockStyle.Top, Height = 40 };
    private readonly ListBox _log = new() { Dock = DockStyle.Fill };

    public event EventHandler? ImportRequested;

    public MainForm()
    {
        Text = "Tool Desktop Host (Template)";
        Width = 900;
        Height = 600;

        Controls.Add(_log);
        Controls.Add(_btnImport);

        _btnImport.Click += (_, _) => ImportRequested?.Invoke(this, EventArgs.Empty);
    }

    public void Bind(MainViewModel vm)
    {
        vm.Log.CollectionChanged += (_, _) =>
        {
            _log.Items.Clear();
            foreach (var item in vm.Log) _log.Items.Add(item);
        };
    }

    // Keeps designers from trying to serialize runtime objects
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object? PresenterMarker { get; set; }
}
