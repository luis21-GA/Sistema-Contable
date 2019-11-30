using SistemasContables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasContables.Repository.Interfaces
{
    public  interface CuentasRepository : IServicesRepository<Cuentas>
    {

        IEnumerable<Cuentas> GetAllCuentas();

    }
}
