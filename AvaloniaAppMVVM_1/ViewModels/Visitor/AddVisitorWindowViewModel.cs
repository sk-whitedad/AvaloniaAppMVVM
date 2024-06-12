using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaAppMVVM_1.ViewModels.Visitor
{
    public class AddVisitorWindowViewModel : ViewModelBase
    {
        public AddVisitorWindowViewModel()
        {
            AddVisitorCommand = ReactiveCommand.Create(() =>
            {
                visitorModel = new VisitorModel { FirstName = FirstName, LastName = LastName };
                return visitorModel;
            });
        }

        private VisitorModel visitorModel;
        public ReactiveCommand<Unit, VisitorModel?> AddVisitorCommand { get; }

        private string? _lastName;
        private string? _firstName;
        private string? _surName;
        private string? _gender;
        private string? _organisation;
        private string? _profession;
        private string? _address;
        private string? _dob;
        private string? _passportNumber;
        private string? _issuedBy;
        private string? _dateIssue;
        private string? _kodeSubdivision;


        public string? LastName
        {
            get => _lastName;
            set => this.RaiseAndSetIfChanged(ref _lastName, value);
        }

        public string? FirstName
        {
            get => _firstName;
            set => this.RaiseAndSetIfChanged(ref _firstName, value);
        }

        public string? SurName
        {
            get => _surName;
            set => this.RaiseAndSetIfChanged(ref _surName, value);
        }
        public string? Gender
        {
            get => _gender;
            set => this.RaiseAndSetIfChanged(ref _gender, value);
        }
        public string? Organisation
        {
            get => _organisation;
            set => this.RaiseAndSetIfChanged(ref _organisation, value);
        }
        public string? Profession
        {
            get => _profession;
            set => this.RaiseAndSetIfChanged(ref _profession, value);
        }
        public string? Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }
        public string? Dob
        {
            get => _dob;
            set => this.RaiseAndSetIfChanged(ref _dob, value);
        }
        public string? PassportNumber
        {
            get => _passportNumber;
            set => this.RaiseAndSetIfChanged(ref _passportNumber, value);
        }
        public string? IssuedBy
        {
            get => _issuedBy;
            set => this.RaiseAndSetIfChanged(ref _issuedBy, value);
        }
        public string? DateIssue
        {
            get => _dateIssue;
            set => this.RaiseAndSetIfChanged(ref _dateIssue, value);
        }
        public string? KodeSubdivision
        {
            get => _kodeSubdivision;
            set => this.RaiseAndSetIfChanged(ref _kodeSubdivision, value);
        }

    }
}
