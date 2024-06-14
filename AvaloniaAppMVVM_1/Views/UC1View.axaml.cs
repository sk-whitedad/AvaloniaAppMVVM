using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels;
using AvaloniaAppMVVM_1.ViewModels.Company;
using AvaloniaAppMVVM_1.Views.Company;
using ReactiveUI;
using System.Threading.Tasks;
using Avalonia;

namespace AvaloniaAppMVVM_1.Views;

public partial class UC1View : ReactiveUserControl<UC1ViewModel>
{
    public UC1View()
    {
        InitializeComponent();
        this.WhenActivated(action => action(ViewModel!.ShowDialogAddCompany.RegisterHandler(DoShowAddDialogAsync)));
        this.WhenActivated(action => action(ViewModel!.ShowDialogEditCompany.RegisterHandler(DoShowEditDialogAsync)));
        this.WhenActivated(action => action(ViewModel!.ShowDialogRemoveCompany.RegisterHandler(DoShowRemoveDialogAsync)));
        this.WhenActivated(action => action(ViewModel!.ShowDialogInfoCompany.RegisterHandler(DoShowInfoDialogAsync)));

    }

    private async Task DoShowAddDialogAsync(InteractionContext<AddCompanyWindowViewModel, CompanyModel?> interaction)
    {
        var dialog = new AddCompanyWindowView();
        dialog.DataContext = interaction.Input;
        var mainWindow = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
        var result = await dialog.ShowDialog<CompanyModel?>(mainWindow);
        interaction.SetOutput(result);
        if (result != null)
        {
            var fn = result.Name;
        }
    }

    private async Task DoShowEditDialogAsync(InteractionContext<EditCompanyWindowViewModel, CompanyModel?> interaction)
    {
        var dialog = new EditCompanyWindowView();
        dialog.DataContext = interaction.Input;
        var mainWindow = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
        var result = await dialog.ShowDialog<CompanyModel?>(mainWindow);
        interaction.SetOutput(result);
        if (result != null)
        {
            var fn = result.Name;
        }
    }

    private async Task DoShowRemoveDialogAsync(InteractionContext<RemoveCompanyWindowViewModel, CompanyModel?> interaction)
    {
        var dialog = new EditCompanyWindowView();
        dialog.DataContext = interaction.Input;
        var mainWindow = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
        var result = await dialog.ShowDialog<CompanyModel?>(mainWindow);
        interaction.SetOutput(result);
        if (result != null)
        {
            var fn = result.Name;
        }
    }

    private async Task DoShowInfoDialogAsync(InteractionContext<InfoCompanyWindowViewModel, CompanyModel?> interaction)
    {
        var dialog = new EditCompanyWindowView();
        dialog.DataContext = interaction.Input;
        var mainWindow = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
        var result = await dialog.ShowDialog<CompanyModel?>(mainWindow);
        interaction.SetOutput(result);
        if (result != null)
        {
            var fn = result.Name;
        }
    }

}