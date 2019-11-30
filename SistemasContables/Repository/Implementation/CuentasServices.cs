using SistemasContables.Models;
using SistemasContables.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SistemasContables.Repository.Implementation
{
    public class CuentasServices : ServiceRepository<Cuentas>, CuentasRepository
    {
        private readonly ApplicationDbcontext _context = new ApplicationDbcontext();
        public IEnumerable<Cuentas> GetAllCuentas()
        {
            try
            {
                var Listado = _context.Cuentas.Include(a => a.Category);
                return Listado;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}