using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Company;
using ReactiveUI;
using System;

namespace AvaloniaAppMVVM_1.Views.Company
{
    public partial class EditCompanyWindowView : ReactiveWindow<EditCompanyWindowViewModel>
    {
        public EditCompanyWindowView()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.EditCompanyCommand.Subscribe(Close)));
            this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(Close)));

        }
    }
}
