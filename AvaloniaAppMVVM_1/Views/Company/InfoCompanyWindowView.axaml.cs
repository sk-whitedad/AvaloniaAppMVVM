using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Company;

namespace AvaloniaAppMVVM_1.Views.Company
{
    public partial class InfoCompanyWindowView : ReactiveWindow<InfoCompanyWindowViewModel>
    {
        public InfoCompanyWindowView()
        {
            InitializeComponent();
        }
    }
}
