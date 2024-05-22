using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace AvaloniaAppMVVM_1.Views;

    public partial class UC2View : ReactiveUserControl<UC2ViewModel>
    {
        public UC2View()
        {
            InitializeComponent();
            this.WhenActivated(action => action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }

    private async Task DoShowDialogAsync(InteractionContext<VisitorEditViewModel, VisitorViewModel?> interaction)
    {
        var dialog = new VisitorAddWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<VisitorViewModel?>(this);
        interaction.SetOutput(result);
    }
}

