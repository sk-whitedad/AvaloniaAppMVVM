using AvaloniaDB;
using ReactiveUI;
using System;
using System.Reactive;

namespace AvaloniaAppMVVM_1.ViewModels.Company
{
    public class InfoCompanyWindowViewModel : ViewModelBase
    {
        private CompanyModel? companyModel;

        public InfoCompanyWindowViewModel(IServisesBD servisesDB, AvaloniaDB.Models.Company selectedItm)
        {
            if (servisesDB == null)
                throw new ArgumentNullException("servisesDB");
 
            Name = selectedItm.Name;
            Address = selectedItm.Address;
            PhoneNumber = selectedItm.PhoneNumber;
            Description = selectedItm.Description;

            CancelCommand = ReactiveCommand.Create(() => { return companyModel; });
        }

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
