using AvaloniaAppMVVM_1.ViewModels.Visitor;
using AvaloniaDB.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Windows.Input;
using System.Reactive.Linq;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class UC2ViewModel : ViewModelBase
    {
        public List<AvaloniaDB.Models.Company> Companies { get; }

        public UC2ViewModel()
        {
            Companies = new List<AvaloniaDB.Models.Company>(companies());
            ShowDialogAddVisitor = new Interaction<AddVisitorWindowViewModel, VisitorModel?>();
            AddVisitor = ReactiveCommand.CreateFromTask( async () =>
            {
                var store = new AddVisitorWindowViewModel();

                var result = await ShowDialogAddVisitor.Handle(store);
            });
        }

        public ICommand AddVisitor { get; }
        public Interaction<AddVisitorWindowViewModel, VisitorModel?> ShowDialogAddVisitor { get; }




        private List<AvaloniaDB.Models.Company> companies()
        {
            var _companies = new List<AvaloniaDB.Models.Company>
            {
                new AvaloniaDB.Models.Company{Id = 1, Name = "Посетитель 1", PhoneNumber = "+7-888-888-88-81", Address = ""},
                new AvaloniaDB.Models.Company{Id = 2, Name = "Посетитель 2", PhoneNumber = "+7-888-888-88-82", Address = ""},
                new AvaloniaDB.Models.Company{Id = 3, Name = "Посетитель 3", PhoneNumber = "+7-888-888-88-83", Address = ""},
            };
            return _companies;
        }

    }
}
