using AvaloniaDB;
using AvaloniaDB.Implementation;
using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand Command1 { get; }
        public ICommand Command2 { get; }
        public ICommand Command3 { get; }
        public ICommand Command4 { get; }


        public ApplicationDbContext contextDB {  get; }
        public MainWindowViewModel()
        {
            Command1 = ReactiveCommand.Create(ButtonComand1);
            Command2 = ReactiveCommand.Create(ButtonComand2);
            Command3 = ReactiveCommand.Create(ButtonComand3);
            Command4 = ReactiveCommand.Create(ButtonComand4);

            contextDB = new ApplicationDbContext();
        }

        private PageViewModelBase _CurrentPage;
        public PageViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }
        public PageViewModelBase CompanyList { get; }

        private void ButtonComand1()
        {
            var _companyRepository = new CompanyRepository(contextDB);
            var _companyService = new CompanyService(_companyRepository);
            var response = _companyService.GetCompanies();
            var CompanyList = response.Result.Data;
            
            if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
			{
                CurrentPage = new UC1ViewModel(CompanyList, _companyService, _companyRepository, contextDB);
                return;
            }
	            CurrentPage = new UC1ViewModel(null, null, null, null);
        }
        private void ButtonComand2()
        {
            CurrentPage = new UC2ViewModel();
        }

        private void ButtonComand3()
        {
            CurrentPage = new UC2ViewModel();
        }

        private void ButtonComand4()
        {
            CurrentPage = new UC2ViewModel();
        }
    }
}
