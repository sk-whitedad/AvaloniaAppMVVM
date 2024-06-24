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

        public UC1ViewModel(List<AvaloniaDB.Models.Company> companyList, IServisesBD servisesBD)
        {
            ShowDialogAddCompany = new Interaction<AddCompanyWindowViewModel, CompanyModel?>();
            AddCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new AddCompanyWindowViewModel(servisesBD, companyList);
                var result = await ShowDialogAddCompany.Handle(store);

                //обновление данных в DataGrid
                if (result == null || result.ButtonCklick == "IsNullName")
                    return;

                Companies.Add(new AvaloniaDB.Models.Company
                {
                    Name = result.Name,
                    Address = result.Address,
                    PhoneNumber = result.PhoneNumber,
                    Description = result.Description
                });
            });

            ShowDialogEditCompany = new Interaction<EditCompanyWindowViewModel, CompanyModel?>();
            EditCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                if (SelectedItm != null)
                {
                    var store = new EditCompanyWindowViewModel(servisesBD, SelectedItm);
                    var result = await ShowDialogEditCompany.Handle(store);
                    if (result.ButtonCklick == "OK")
                    {
                        Companies[SelectedInd].Name = result.Name;
                        Companies[SelectedInd].Address = result.Address;
                        Companies[SelectedInd].PhoneNumber = result.PhoneNumber;
                        Companies[SelectedInd].Description = result.Description;
                    }
                }
            });

            ShowDialogRemoveCompany = new Interaction<RemoveCompanyWindowViewModel, CompanyModel?>();
            RemoveCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                if (SelectedItm != null)
                {
                    var servisesDB = new ServisesDB
                    {
                        contextDB = servisesBD.contextDB,
                        companyRepository = servisesBD.Repository,
                        companyService = servisesBD.Service
                    };

                    var store = new RemoveCompanyWindowViewModel(servisesBD, SelectedItm);
                    var result = await ShowDialogRemoveCompany.Handle(store);
                    if (result == null) return;
                    if (result.ButtonCklick == "OK")
                        Companies.RemoveAt(SelectedInd);
                }
            });

            ShowDialogInfoCompany = new Interaction<InfoCompanyWindowViewModel, CompanyModel?>();
            InfoCompany = ReactiveCommand.CreateFromTask(async () =>
            {
                if (SelectedItm != null)
                {
                    var servisesDB = new ServisesDB
                    {
                        contextDB = servisesBD.contextDB,
                        companyRepository = servisesBD.Repository,
                        companyService = servisesBD.Service
                    };

                    var store = new InfoCompanyWindowViewModel(servisesBD, SelectedItm);
                    var result = await ShowDialogInfoCompany.Handle(store);

                }

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


    }
}