using System.ComponentModel;

namespace AvaloniaDB.Models
{
    public class Company : INotifyPropertyChanged
    {
        private int _id; private string _name;
        private string? _address; private string? _phoneNumber;
        private string? _description;
        public int Id
        {
            get => _id; set
            {
                if (value == _id) return;
                _id = value; RaisePropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get => _name; set
            {
                if (value == _name) return;
                _name = value; RaisePropertyChanged(nameof(Name));
            }
        }
        public string? Address
        {
            get => _address;
            set
            {
                if (value == _address) return; _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }
        public string? PhoneNumber
        {
            get => _phoneNumber; set
            {
                if (value == _phoneNumber) return;
                _phoneNumber = value; RaisePropertyChanged(nameof(PhoneNumber));
            }
        }
        public string? Description
        {
            get => _description;
            set
            {
                if (value == _description) return; _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged; public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
