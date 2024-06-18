using AvaloniaDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDB
{
    public class ServisesDB
    {
        public ApplicationDbContext contextDB { get; set; }
        public IBaseRepository<Models.Company> companyRepository { get; set; }
        public ICompanyService companyService { get; set; }

    }
}
