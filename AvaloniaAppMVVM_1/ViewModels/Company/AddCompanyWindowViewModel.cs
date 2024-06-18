using AvaloniaDB;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AvaloniaAppMVVM_1.ViewModels.Company
{
    public class AddCompanyWindowViewModel : ViewModelBase
    {
        private ServisesDB? _servisesDB { get; set; }
        private ObservableCollection<AvaloniaDB.Models.Company>? Companies { get; set; }
        private CompanyModel? companyModel;

        public AddCompanyWindowViewModel(ServisesDB servisesDB, List<AvaloniaDB.Models.Company> companyList)
        {
            if (servisesDB == null)
                throw new ArgumentNullException("servisesDB");
 
            AddCompanyCommand = ReactiveCommand.Create(() =>
            {
                Companies = new ObservableCollection<AvaloniaDB.Models.Company>(companyList);
                _servisesDB = servisesDB;
                companyModel = new CompanyModel { Name = Name, Address = Address, PhoneNumber = PhoneNumber, Description = Description };
                var response = _servisesDB.companyService.GetCompanies();
                if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK && !String.IsNullOrEmpty(companyModel.Name))
                {
                    var company = new AvaloniaDB.Models.Company
                    {
                        Name = companyModel.Name,
                        Address = companyModel.Address,
                        PhoneNumber = companyModel.PhoneNumber,
                        Description = companyModel.Description
                    };
                    _servisesDB.companyService.Create(company);
                    var companies = _servisesDB.companyService.GetCompanies().Result.Data;
                    company = companies[companies.Count - 1];
                    Companies.Add(company);
                };
                if (String.IsNullOrEmpty(companyModel.Name))
                {
                    companyModel = new CompanyModel
                    {
                        ButtonCklick = "IsNullName"
                    };
                }

                return companyModel;
            });

            CancelCommand = ReactiveCommand.Create(() => { return companyModel; });
        }

        public ReactiveCommand<Unit, CompanyModel> AddCompanyCommand { get; }
        public ReactiveCommand<Unit, CompanyModel?> CancelCommand { get; }

        private string? _name;
        public string? Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        private string? _address;
        public string? Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }

        private string? _phoneNumber;
        public string? PhoneNumber
        {
            get => _phoneNumber;
            set => this.RaiseAndSetIfChanged(ref _phoneNumber, value);
        }

        private string? _description;
        public string? Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
    }
}
