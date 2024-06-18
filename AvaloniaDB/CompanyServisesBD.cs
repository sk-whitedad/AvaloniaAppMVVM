using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDB
{
    public class CompanyServisesBD : IServisesBD
    {
        public ApplicationDbContext contextDB { get; set; }
        public IBaseRepository<Models.Company> Repository { get; set; }
        public ICompanyService Service { get; set; }
    }
}
