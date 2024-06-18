using AvaloniaAppMVVM_1.ViewModels.Visitor;
using AvaloniaAppMVVM_1.ViewModels.Company;
using AvaloniaDB;
using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reactive.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public class UC1ViewModel : ViewModelBase
    {
        public int SelectedInd { get; set; }
        public AvaloniaDB.Models.Company SelectedItm { get; set; }
        public ObservableCollection<AvaloniaDB.Models.Company> Companies { get; set; }
        public ServisesDB servisesDB { get; set; } = new ServisesDB();

        public UC1ViewModel(List<AvaloniaDB.Models.Company> companyList, ICompanyService companyService, IBaseRepository<AvaloniaDB.Models.Company> companyRepository, ApplicationDbContext contextDB)
        {
            ShowDialogAddCompany = new Interaction<AddCompanyWindowViewModel, CompanyModel?>();
            AddCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                var servisesDB = new ServisesDB
                {
                    contextDB = contextDB,
                    companyRepository = companyRepository,
                    companyService = companyService
                };
                var store = new AddCompanyWindowViewModel(servisesDB, companyList);
                var result = await ShowDialogAddCompany.Handle(store);

                //обновление данных в DataGrid
                if (result == null || result.ButtonCklick == "IsNullName")
                return;

                    Companies.Add(new AvaloniaDB.Models.Company {
                    Id = Companies.Count + 1,
                    Name = result.Name, 
                    Address = result.Address,
                    PhoneNumber = result.PhoneNumber,
                    Description = result.Description                
                });
            });

            ShowDialogEditCompany = new Interaction<EditCompanyWindowViewModel, CompanyModel?>();
            EditCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new EditCompanyWindowViewModel();
                var result = await ShowDialogEditCompany.Handle(store);
            });

            ShowDialogRemoveCompany = new Interaction<RemoveCompanyWindowViewModel, CompanyModel?>();
            RemoveCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                if (SelectedItm != null)
                {
                    var servisesDB = new ServisesDB
                    {
                        contextDB = contextDB,
                        companyRepository = companyRepository,
                        companyService = companyService
                    };

                    var store = new RemoveCompanyWindowViewModel(servisesDB, SelectedItm);
                    var result = await ShowDialogRemoveCompany.Handle(store);
                    if (result == null) return;
                    if (result.ButtonCklick == "OK")
                        Companies.RemoveAt(SelectedInd);
                }
            });

            ShowDialogInfoCompany = new Interaction<InfoCompanyWindowViewModel, CompanyModel?>();
            InfoCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new InfoCompanyWindowViewModel();
                var result = await ShowDialogInfoCompany.Handle(store);
            });

            var companies = companyList;
            Companies = new ObservableCollection<AvaloniaDB.Models.Company>(companies);
        }

        public ICommand AddCompany { get; }
        public Interaction<AddCompanyWindowViewModel, CompanyModel?> ShowDialogAddCompany { get; }
        public ICommand EditCompany { get; }
        public Interaction<EditCompanyWindowViewModel, CompanyModel?> ShowDialogEditCompany { get; }
        public ICommand RemoveCompany { get; }
        public Interaction<RemoveCompanyWindowViewModel, CompanyModel?> ShowDialogRemoveCompany { get; }
        public ICommand InfoCompany { get; }
        public Interaction<InfoCompanyWindowViewModel, CompanyModel?> ShowDialogInfoCompany { get; }






        //private async task buttonaddcompany()
        //{
        //    var response = companyService.GetCompanies();

        //    if (response.Result.StatusCode == AvaloniaDB.Enums.StatusCode.OK)
        //    {
        //        var company = new AvaloniaDB.Models.Company { Name = "Компания 1", PhoneNumber = "+7-888-888-88-81", Address = "" };
        //        await _companyService.Create(company);
        //        var companies = _companyService.GetCompanies().Result.Data;
        //        company = companies[companies.Count - 1];
        //        Companies.Add(company);
        //    }
        //}

        //private async Task ButtonRemoveCompany()
        //{
        //    if (SelectedItm != null)
        //    {
        //        await _companyService.Delete(SelectedItm.Id);
        //        Companies.RemoveAt(SelectedInd);
        //    }
        //}






    }
}
