using AvaloniaDB.Implementation;
using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;

namespace AvaloniaDB
{
	class Program
	{
        public static async Task Main(string[] args)
		{
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var _companyRepository = new CompanyRepository(db);
                var _companyService = new CompanyService(_companyRepository);
                var _company = new Company { Name = "ООО\"Тазпром\"", Address = "г.Москва", PhoneNumber = "+7800-111-10-10" };
             
                var response = _companyService.GetCompanies();
                if (response.Result.StatusCode == Enums.StatusCode.OK)
                {
                    var company = new Company()
                    {
                        Name = _company.Name,
                        Description = _company.Description,
                        Address = _company.Address,
                        PhoneNumber = _company.PhoneNumber
                    };
                    var response1 = await _companyService.Create(company);
                    if (response1.StatusCode == Enums.StatusCode.OK)
                    {
                        Console.WriteLine("Компания успешно добавлена");
                    }
                    else
                        Console.WriteLine("Ошибка записи");
                }
            }



        }
	}
}