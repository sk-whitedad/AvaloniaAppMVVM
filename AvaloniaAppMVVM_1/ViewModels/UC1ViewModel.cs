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
        public List<Company> Companies { get; set; }
        private ApplicationDbContext _contextDB { get; }
        private IBaseRepository<Company> _companyRepository {  get; }
        ICompanyService _companyService {  get; }
        public UC1ViewModel(List<Company> companyList, ICompanyService companyService, IBaseRepository<Company> companyRepository, ApplicationDbContext contextDB)
        {
            AddCompany = ReactiveCommand.Create(ButtonAddCompany);
            _contextDB = contextDB;
            _companyRepository = companyRepository;
            _companyService = companyService;

            var companies = companyList;
            Companies = new List<Company>(companies);
        }

        private async Task ButtonAddCompany()
        {
            var _companyRepository = new CompanyRepository(_contextDB);
            var _companyService = new CompanyService(_companyRepository);
            var response = _companyService.GetCompanies();

            if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
            {
                var company = new Company { Name = "Компания 1", PhoneNumber = "+7-888-888-88-81", Address = "" };
                await _companyService.Create(company);
                var companies = _companyService.GetCompanies().Result.Data;
                Companies = new List<Company>(companies);
               
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
