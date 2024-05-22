using AvaloniaDB.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class UC2ViewModel : PageViewModelBase
    {
        public List<Company> Companies { get; }

        public UC2ViewModel()
        {
            ShowDialog = new Interaction<VisitorEditViewModel, VisitorViewModel?>();
            AddVisitor = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new VisitorEditViewModel();

                var result = await ShowDialog.Handle(store);
            });

            var companies = new List<Company>
            {
                new Company{Id = 1, Name = "Компания 1", PhoneNumber = "+7-888-888-88-81", Address = ""},
                new Company{Id = 2, Name = "Компания 2", PhoneNumber = "+7-888-888-88-82", Address = ""},
                new Company{Id = 3, Name = "Компания 3", PhoneNumber = "+7-888-888-88-83", Address = ""},
            };
            Companies = new List<Company>(companies);
        }

        public ICommand AddVisitor { get; }
        public Interaction<VisitorEditViewModel, VisitorViewModel?> ShowDialog { get; }


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
