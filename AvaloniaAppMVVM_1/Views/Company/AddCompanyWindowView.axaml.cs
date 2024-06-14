using Avalonia.Controls;
using System;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Company;
using ReactiveUI;



namespace AvaloniaAppMVVM_1.Views.Company
{
    public partial class AddCompanyWindowView : ReactiveWindow<AddCompanyWindowViewModel>
    {
        public AddCompanyWindowView()
        {
            InitializeComponent();
        }
    }
}
