using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels;
using AvaloniaAppMVVM_1.ViewModels.Visitor;
using AvaloniaAppMVVM_1.Views.Visitor;
using ReactiveUI;
using System.Threading.Tasks;

namespace AvaloniaAppMVVM_1.Views;

public partial class UC2View : ReactiveUserControl<UC2ViewModel>
{

    public UC2View()
    {
        InitializeComponent();
        this.WhenActivated(action => action(ViewModel!.ShowDialogAddVisitor.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<AddVisitorWindowViewModel, VisitorModel?> interaction)
    {
        var dialog = new AddVisitorWindowView();
        dialog.DataContext = interaction.Input;
        var mainWindow = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
        var result = await dialog.ShowDialog<VisitorModel?>(mainWindow);
        interaction.SetOutput(result);
        if (result != null)
        {
            var fn = result.FirstName;

        }
    }
}

