using AvaloniaDB;
using ReactiveUI;
using System;
using System.Reactive;

namespace AvaloniaAppMVVM_1.ViewModels.Company
{
    public class RemoveCompanyWindowViewModel : ViewModelBase
    {
        private CompanyModel? companyModel;

        public RemoveCompanyWindowViewModel(IServisesBD servisesDB, AvaloniaDB.Models.Company selectedItm)
        {
            if (servisesDB == null)
                throw new ArgumentNullException("servisesDB");
            RemoveCompanyCommand = ReactiveCommand.Create(() =>
            {
                servisesDB.Service.Delete(selectedItm.Id);
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
