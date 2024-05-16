using AvaloniaDB;
using AvaloniaDB.Implementation;
using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class UC1ViewModel: PageViewModelBase
    {
        public ICommand AddCompany { get; }
        public ICommand RemoveCompany { get; }
        
        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Company> Companies1 { get; set; }
        private ApplicationDbContext _contextDB { get; }
        private IBaseRepository<Company> _companyRepository {  get; }
        private ICompanyService _companyService {  get; }
        public UC1ViewModel(List<Company> companyList, ICompanyService companyService, IBaseRepository<Company> companyRepository, ApplicationDbContext contextDB)
        {
            AddCompany = ReactiveCommand.Create(ButtonAddCompany);
            RemoveCompany = ReactiveCommand.Create(ButtonRemoveCompany);
            _contextDB = contextDB;
            _companyRepository = companyRepository;
            _companyService = companyService;
            _companyRepository = new CompanyRepository(_contextDB);
            _companyService = new CompanyService(_companyRepository);

            var companies = companyList;
            Companies = new ObservableCollection<Company>(companies);
        }

        private async Task ButtonAddCompany()
        {
            var response = _companyService.GetCompanies();

            if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
            {
                var company = new Company { Name = "Компания 1", PhoneNumber = "+7-888-888-88-81", Address = "" };
                await _companyService.Create(company);
                var companies = _companyService.GetCompanies().Result.Data;
                company = companies[companies.Count - 1];
                Companies.Add(company);
            }
        }

        private void ButtonRemoveCompany()
        {

            //var response = _companyService.Delete();

            if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
            {



            }
        }

        public override bool CanNavigateNext
        {
            get => true;
            protected set => throw new NotSupportedException();
        }

        public override bool CanNavigatePrevious
        {
            get => false;
            protected set => throw new NotSupportedException();
        }


    }
}
