using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDB.Enums
{
    public enum StatusCode
    {
        CompanyNotFound = 0,
        CompanyAlreadyExists = 1,
        OK = 200,
        InternalServerError = 500
    }
}
