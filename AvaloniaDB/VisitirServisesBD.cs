using AvaloniaDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDB
{
    public class VisitirServisesBD : IServisesBD
    {
        public ApplicationDbContext contextDB { get; set; }
        public IBaseRepository<Models.Company> Repository { get; set; }
        public ICompanyService Service { get; set; }

    }
}
