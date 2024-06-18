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
    public class RemoveCompanyWindowViewModel : ViewModelBase
    {
        private ServisesDB? _servisesDB { get; set; }
        //private ObservableCollection<AvaloniaDB.Models.Company>? Companies { get; set; }
        private CompanyModel? companyModel;

        public RemoveCompanyWindowViewModel(ServisesDB servisesDB, AvaloniaDB.Models.Company selectedItm)
        {
            if (servisesDB == null)
                throw new ArgumentNullException("servisesDB");
            RemoveCompanyCommand = ReactiveCommand.Create(() =>
            {
                _servisesDB = servisesDB;
                servisesDB.companyService.Delete(selectedItm.Id);
                companyModel = new CompanyModel
                {
                    ButtonCklick = "OK"
                };
                return companyModel;
            });

            CancelCommand = ReactiveCommand.Create(() => { return companyModel; });

        }

        public ReactiveCommand<Unit, CompanyModel> RemoveCompanyCommand { get; }
        public ReactiveCommand<Unit, CompanyModel?> CancelCommand { get; }
    }
}
