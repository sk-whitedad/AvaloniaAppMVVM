using AvaloniaDB.Models;
using System.Collections.ObjectModel;

namespace AvaloniaDB.Interfaces
{
    public interface ICompanyService
    {
        Task<IBaseResponse<Company>> Create(Company model);

        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Company>> GetCompany(int id);

        Task<IBaseResponse<List<Company>>> GetCompanies();

    }
}
