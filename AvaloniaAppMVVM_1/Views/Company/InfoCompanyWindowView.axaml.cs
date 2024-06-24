using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Company;
using ReactiveUI;
using System;

namespace AvaloniaAppMVVM_1.Views.Company
{
    public partial class InfoCompanyWindowView : ReactiveWindow<InfoCompanyWindowViewModel>
    {
        public InfoCompanyWindowView()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(Close)));
        }
    }
}
