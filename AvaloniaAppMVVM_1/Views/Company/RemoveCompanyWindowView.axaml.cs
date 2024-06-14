using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Company;

namespace AvaloniaAppMVVM_1.Views.Company
{
    public partial class RemoveCompanyWindowView : ReactiveWindow<RemoveCompanyWindowViewModel>
    {
        public RemoveCompanyWindowView()
        {
            InitializeComponent();
        }
    }
}
