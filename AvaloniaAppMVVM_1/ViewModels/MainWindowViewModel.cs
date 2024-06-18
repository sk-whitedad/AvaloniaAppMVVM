using AvaloniaAppMVVM_1.ViewModels.Visitor;
using AvaloniaDB;
using AvaloniaDB.Implementation;
using ReactiveUI;
using System.Windows.Input;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand Command1 { get; }
        public ICommand Command2 { get; }
        public ICommand Command3 { get; }
        public ICommand Command4 { get; }
        public ICommand Command5 { get; }

        public ApplicationDbContext contextDB { get; }
        public IServisesBD UniServisesDB;

        public MainWindowViewModel()
        {
            Command1 = ReactiveCommand.Create(ButtonComand1);
            Command2 = ReactiveCommand.Create(ButtonComand2);
            Command3 = ReactiveCommand.Create(ButtonComand3);
            Command4 = ReactiveCommand.Create(ButtonComand4);
            Command5 = ReactiveCommand.Create(ButtonComand5);
            contextDB = new ApplicationDbContext();
        }

        private ViewModelBase _CurrentPage;
        public ViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }

        private void ButtonComand1()
        {
            UniServisesDB = new CompanyServisesBD();
            UniServisesDB.contextDB = contextDB;
            UniServisesDB.Repository = new CompanyRepository(UniServisesDB.contextDB);
            UniServisesDB.Service = new CompanyService(UniServisesDB.Repository);
            var response = UniServisesDB.Service.GetCompanies();
            var CompanyList = response.Result.Data;

            if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
            {
                CurrentPage = new UC1ViewModel(CompanyList, UniServisesDB);
                return;
            }
            CurrentPage = new UC1ViewModel(null, null);
        }
        private void ButtonComand2()
        {
            CurrentPage = new UC2ViewModel();
        }

        private void ButtonComand3()
        {
            CurrentPage = new UC3ViewModel();
        }

        private void ButtonComand4()
        {
            CurrentPage = new UC2ViewModel();
        }

        private void ButtonComand5()
        {
            CurrentPage = new UC2ViewModel();
        }
    }
}
