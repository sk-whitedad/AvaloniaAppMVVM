using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Company;
using ReactiveUI;
using System;

namespace AvaloniaAppMVVM_1.Views.Company
{
    public partial class RemoveCompanyWindowView : ReactiveWindow<RemoveCompanyWindowViewModel>
    {
        public RemoveCompanyWindowView()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.RemoveCompanyCommand.Subscribe(Close)));
            this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(Close)));

        }
    }
}
