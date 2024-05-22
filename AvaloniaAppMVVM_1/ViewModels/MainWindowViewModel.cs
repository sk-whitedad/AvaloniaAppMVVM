using AvaloniaDB;
using AvaloniaDB.Implementation;
using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Windows.Input;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand Command1 { get; }
        public ICommand Command2 { get; }
        public ICommand Command3 { get; }
        public ICommand Command4 { get; }

        //Пример 
        private string _messageInputTxt = string.Empty;
        public string MessageInputTxt
        {
            get { return _messageInputTxt; }
            set { this.RaiseAndSetIfChanged(ref _messageInputTxt, value); }
        }
        public ReactiveCommand<Unit, Unit> Command5 { get; }
        //Конец Пример 

        public ApplicationDbContext contextDB {  get; }
        
        public MainWindowViewModel()
        {
            Command1 = ReactiveCommand.Create(ButtonComand1);
            Command2 = ReactiveCommand.Create(ButtonComand2);
            Command3 = ReactiveCommand.Create(ButtonComand3);
            Command4 = ReactiveCommand.Create(ButtonComand4);
            IObservable<bool> isInputValid = this.WhenAnyValue(
                x => x.MessageInputTxt,
                x => !string.IsNullOrWhiteSpace(x) && x.Length > 7
                ); 
            Command5 = ReactiveCommand.Create(ButtonComand5, isInputValid);




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

        private void ButtonComand5()
        {
            Debug.WriteLine("-----The submit command was run.-----");
            CurrentPage = new UC2ViewModel();
        }
    }
}
