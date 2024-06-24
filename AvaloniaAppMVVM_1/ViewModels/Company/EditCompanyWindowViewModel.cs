using AvaloniaDB;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaAppMVVM_1.ViewModels.Company
{
    public class EditCompanyWindowViewModel : ViewModelBase
    {
        private ObservableCollection<AvaloniaDB.Models.Company>? Companies { get; set; }
        private CompanyModel? companyModel;

        public EditCompanyWindowViewModel(IServisesBD servisesDB, AvaloniaDB.Models.Company selectedItm)
        {
            if (servisesDB == null)
                throw new ArgumentNullException("servisesDB");

            Name = selectedItm.Name;
            Address = selectedItm.Address;
            PhoneNumber = selectedItm.PhoneNumber;
            Description = selectedItm.Description;

            EditCompanyCommand = ReactiveCommand.Create(() =>
            {
                if (!String.IsNullOrEmpty(Name))
                {
                    var _company = new AvaloniaDB.Models.Company
                    {
                        Id = selectedItm.Id,
                        Name = Name,
                        Address = Address,
                        PhoneNumber = PhoneNumber,
                        Description = Description
                    };

                    var response = servisesDB.Service.EditCompany(_company);
                    if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
                    {
                        companyModel = new CompanyModel
                        {
                            Name = response.Result.Data.Name,
                            Address = response.Result.Data.Address,
                            PhoneNumber = response.Result.Data.PhoneNumber,
                            Description = response.Result.Data.Description,
                            ButtonCklick = "OK"
                        };
                    }

                }else
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

        public ReactiveCommand<Unit, CompanyModel?> EditCompanyCommand { get; }
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

